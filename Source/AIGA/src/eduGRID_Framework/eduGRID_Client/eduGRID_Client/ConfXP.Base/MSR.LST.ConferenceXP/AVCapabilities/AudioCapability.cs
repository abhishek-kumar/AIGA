using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;

using MSR.LST.MDShow;
using MSR.LST.Net.Rtp;

namespace MSR.LST.ConferenceXP
{
    [Capability.Name("Audio")]
    [Capability.PayloadType(PayloadType.dynamicAudio)]
    [Capability.Channel(false)]
    [Capability.Fec(true)]
    [Capability.FormType(typeof(FAudioVideo))]
    [Capability.FecRatio(0, 1)]
    public class AudioCapability : CapabilityDeviceWithWindow, ICapabilitySender, ICapabilityViewer, ICapabilityWindowAutoSize
    {
        #region Statics
        
        /// <summary>
        /// Check the registry and compare to the current list of microphones on 
        /// the machine (in case there is a mismatch).
        /// </summary>
        /// <returns>
        /// The FilterInfo for the mics that were selected and still exist
        /// </returns>
        public static FilterInfo[] SelectedMicrophones()
        {
            ArrayList selectedMics = new ArrayList();

            string[] regSelectedMics = AVReg.ValueNames(AVReg.SelectedMicrophone);
            if(regSelectedMics != null)
            {
                FilterInfo[] mics = AudioSource.Sources();

                for(int i = 0; i < mics.Length; i++)
                {
                    for(int j = 0; j < regSelectedMics.Length; j++)
                    {
                        if(mics[i].Moniker == regSelectedMics[j])
                        {
                            selectedMics.Add(mics[i]);
                            break;
                        }
                    }
                }
            }

            return (FilterInfo[])selectedMics.ToArray(typeof(FilterInfo));
        }
        
        /// <summary>
        /// Check the registry and compare to the current list of speakers on 
        /// the machine (in case there is a mismatch).  Or return the default
        /// system speaker if none were selected.
        /// </summary>
        /// <returns>
        /// The FilterInfo of the speaker that was selected and still exists
        /// </returns>
        public static FilterInfo SelectedSpeaker()
        {
            FilterInfo selectedSpeaker = AudioRenderer.DefaultFilterInfo();

            string[] regSelectedSpeaker = AVReg.ValueNames(AVReg.SelectedSpeaker);
            if(regSelectedSpeaker != null)
            {
                FilterInfo[] spkrs = AudioRenderer.Renderers();

                for(int i = 0; i < spkrs.Length; i++)
                {
                    for(int j = 0; j < regSelectedSpeaker.Length; j++)
                    {
                        if(spkrs[i].Moniker == regSelectedSpeaker[j])
                        {
                            selectedSpeaker = spkrs[i];
                            break;
                        }
                    }
                }
            }
            else
            {
                selectedSpeaker = AudioRenderer.DefaultFilterInfo();
            }

            return selectedSpeaker;
        }


        #endregion

        #region Members

        // Audio volume control related variable members
        private IBasicAudio iBA = null;
        // Note: The currentVolume member is used to store the volume in case the SetVolume method
        // is called before the stream added event is fired (no fgm existing at that point).
        // ResumePlayingAudio is using this member when calling the SetVolume method.
        private int currentVolume = 0;

        #endregion Members

        #region Constructors
        
        public AudioCapability(FilterInfo fi) : base(fi)
        {
            AutoPlayLocal = false; // Don't usually want to play your own audio (can create loopback)
            
            RtpStream.FirstFrameReceived += new RtpStream.FirstFrameReceivedEventHandler(RtpStream_FirstFrameReceived);
        }

        public AudioCapability(DynamicProperties dynaProps) : base(dynaProps) 
        {
            RtpStream.FirstFrameReceived += new RtpStream.FirstFrameReceivedEventHandler(RtpStream_FirstFrameReceived);
        }
        
        
        public override void Dispose()
        {
            base.Dispose ();

            RtpStream.FirstFrameReceived -= new RtpStream.FirstFrameReceivedEventHandler(RtpStream_FirstFrameReceived);

            DisposeFgm();
            DeactivateMicrophone();
        }


        #endregion

        #region Public

        #region Sending side / Capture graph

        /// <summary>
        /// Get the AudioCaptureGraph for this capability
        /// </summary>
        public AudioCaptureGraph AudioCaptureGraph
        {
            get { return (AudioCaptureGraph)this.cg; }
        }
        
        /// <summary>
        /// Creates the microphone (capture graph)
        /// </summary>
        public void ActivateMicrophone()
        {
            Log(string.Format("\r\nInitializing microphone - {0}, {1}", fi.DisplayName, fi.Moniker));

            // Get microphone up and running
            CreateAudioGraph(fi);
            RestoreMicrophoneSettings();
            RestoreAudioSettings();
            LogCurrentMediaType(acg.Source);

            // Add compressor if necessary
            AddAudioCompressor();
            LogCurrentMediaType(acg.Compressor);

            // Log all the filters in the graph
            Log(FilterGraph.Debug(acg.IFilterGraph));
        }

        /// <summary>
        /// Adds an audio compressor if needed (by checking the registry)
        /// </summary>
        public void AddAudioCompressor()
        {
            if(RegCompressorEnabled)
            {
                try
                {
                    acg.AddCompressor(AudioCompressor.DefaultFilterInfo());
                    Log(acg.Compressor.Dump());

                    DefaultAudioCompressorSettings();
                }
                catch (Exception e)
                {
                    // If we encounter an error trying to add or configure the
                    // compressor, just disable compressor and log it 
                    RegCompressorEnabled = false;
                    Log(e.ToString());
                }
            }
        }

        /// <summary>
        /// Disposes the microphone (capture graph)
        /// </summary>
        public void DeactivateMicrophone()
        {
            if(cg != null)
            {
                Log(string.Format("\r\nDisposing graph - {0}", cg.Source.FriendlyName));

                cg.Dispose();
                cg = null;
            }
        }


        public override void Send()
        {
            lock(Conference.ActiveVenue)
            {
                lock(this)
                {
                    try
                    {
                        if (!isSending)
                        {
                            base.Send();
                            
                            if(cg.Renderer == null)
                            {
                                cg.RenderNetwork(RtpSender);
                            }

                            cg.Run();

                            // TODO: We shouldn't have to deal with adding capabilities
                            //       in the capabilitySenders collection here. This code should
                            //       be removed from here when Conference has been cleaned-up
                            if (!Conference.CapabilitySenders.ContainsKey(ID))
                            {
                                Conference.AddCapabilitySender(this);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        eventLog.WriteEntry(e.ToString(), System.Diagnostics.EventLogEntryType.Error, 99);

                        StopSending();

                        throw;
                    }
                }
            }
        }

        public override void StopSending()
        {
            lock(this)
            {
                if (isSending)
                {
                    // We must shut down the device before calling base, since base will dispose
                    // the RtpSender that device is using.
                    cg.Stop();

                    base.StopSending();
                }
            }
        }

        public void StopSendingAudio()
        {
            cg.Stop();

            uiState |= (int)FAudioVideo.UIState.LocalAudioSendStopped;
            ((FAudioVideo)form).UpdateAudioUI(uiState);
        }

        public void ResumeSendingAudio()
        {
            cg.Run();

            uiState &= ~(int)FAudioVideo.UIState.LocalAudioSendStopped;
            ((FAudioVideo)form).UpdateAudioUI(uiState);
        }

        
        /// <summary>
        /// Save the microphone's current settings to the registry
        /// </summary>
        public void SaveMicrophoneSettings()
        {
            AVReg.WriteValue(DeviceKey(), AVReg.MicrophoneSourceIndex, 
                acg.AudioSource.InputPinIndex);

            SaveDeviceSettings();
        }

        /// <summary>
        /// Save the audio stream's current settings to the registry
        /// </summary>
        public void SaveAudioSettings()
        {
            SaveStreamSettings();
        }
        

        #endregion Sending side / Capture graph

        #region Receiving side / Playing graph

        public FilgraphManagerClass PlayGraph
        {
            get{return fgm;}
        }

        /// <summary>
        /// Overridden because we don't want to hook the frame received event
        /// </summary>
        /// <param name="rtpStream"></param>
        public override void StreamAdded(RtpStream rtpStream)
        {
            if(this.rtpStream != null)
            {
                this.rtpStream.DataStarted -= new MSR.LST.Net.Rtp.RtpStream.DataStartedEventHandler(rtpStream_DataStarted);
                this.rtpStream.DataStopped -= new MSR.LST.Net.Rtp.RtpStream.DataStoppedEventHandler(rtpStream_DataStopped);
            }

            lock(this)
            {
                this.rtpStream = rtpStream;
                this.rtpStreams.Add(rtpStream);
            }

            rtpStream.IsUsingNextFrame = true;

            // We only need to hook these events if we are remote players, not senders
            if(!IsSender)
            {
                rtpStream.DataStarted += new MSR.LST.Net.Rtp.RtpStream.DataStartedEventHandler(rtpStream_DataStarted);
                rtpStream.DataStopped += new MSR.LST.Net.Rtp.RtpStream.DataStoppedEventHandler(rtpStream_DataStopped);
            }
        }

        // Important note: 
        // We don't use base.Play() because:
        //    - We want to control when ShowForm is called
        //    - We don't want to hook streams FrameReceived events
        public override void Play()
        {
            lock(Conference.ActiveVenue)
            {
                lock(this)
                {
                    if (disposed)
                    {
                        throw new ObjectDisposedException(name);
                    }

                    if(!isPlaying)
                    {
                        isPlaying = true;

                        // Show as close to RaiseCapabilityPlaying as possible
                        // In order to minimize repaints, and improve perceived perf
                        CreateForm();
                        ShowForm();

                        Conference.RaiseCapabilityPlaying(this);
                        
                        ResumePlayingAudio();

                        // Capability state and fgm state could be different
                        ((FAudioVideo)form).UpdateAudioUI(uiState);
                    }
                }
            }
        }

        public override void StopPlaying()
        {
            lock(Conference.ActiveVenue)
            {
                lock(this)
                {
                    if (isPlaying)
                    {
                        StopPlayingAudio();
                        base.StopPlaying();

                        // Capability state and fgm state could be different
                        // And capability / form state are different between Sender and Receiver
                        if(form != null)
                        {
                            ((FAudioVideo)form).UpdateAudioUI(uiState);
                        }
                    }
                }
            }
        }

        public void StopPlayingAudio()
        {
            lock(fgmLock)
            {
                if(fgmState != FilterGraph.State.Stopped)
                {
                    fgmState = FilterGraph.State.Stopped;

                    if (fgm != null)
                    {
                        // We need to manually unblock the stream in case there is no data flowing
                        if(rtpStream != null)
                        {
                            rtpStream.UnblockNextFrame();
                        }

                        fgm.Stop();
                        iBA = null;
                    }

                    uiState |= (int)FAudioVideo.UIState.LocalAudioPlayStopped;
                    ((FAudioVideo)form).UpdateAudioUI(uiState);
                }
            }
        }

        public void ResumePlayingAudio()
        {
            lock(fgmLock)
            {
                if(fgmState != FilterGraph.State.Running)
                {
                    fgmState = FilterGraph.State.Running;

                    if (fgm != null)
                    {
                        iBA = (IBasicAudio)fgm;
                        // Note: We use the currentVolume member to set the volume.
                        //       This member is actually initialized in SetVolume
                        //       in case SetVolume was called before the fgm (and iBA)
                        //       was created (before stream added is called)
                        SetVolume(currentVolume);

                        // MethodInvoke the PositionVolumeSlider to set the position of the slider in the AV form
                        // Note: There is no parameter. The AV from reads the volume parameter using the
                        // volume accessor in AudioCapability.
                        ((FAudioVideo)form).PositionVolumeSlider();

                        // We need to manually block the stream to reset its state in case it
                        // became inconsistent during shutdown
                        if(rtpStream != null)
                        {
                            rtpStream.BlockNextFrame();
                        }

                        fgm.Run();
                    }

                    uiState &= ~(int)FAudioVideo.UIState.LocalAudioPlayStopped;
                    ((FAudioVideo)form).UpdateAudioUI(uiState);
                }
            }
        }

        /// <summary>
        /// Ensure that the volume is within the range [0, 100]
        /// </summary>
        /// <param name="volume">The volume to validate</param>
        protected void ValidateVolume(int volume)
        {
            if (volume < 0 || volume > 100)
            {
                throw new ArgumentException("volume value should be between [0, 100]");
            }
        }

        /// <summary>
        /// Change the playing volume of remote participants
        /// </summary>
        /// <remarks>The volume is in the range [0, 100] (where 0 is silence and 100 is full volume)</remarks>
        public void SetVolume(int volume)
        {
            ValidateVolume(volume);

            // Store the value passed in, in case this is called before stream added 
            currentVolume = volume;

            if (iBA != null)
            {
                // Set the volume by converting a linear slider value [0, 100] (where 0 is silence and 100 is full volume)
                // to logarithmic value [-10000, 0] (where -10000 is silence, 0 is full volume)
                // Note: divide iBA.Volume by 100 to get equivalent decibel value. For example, -10,000 is -100 dB.
                iBA.Volume = (volume != 0) ? (int)(Math.Round( (10000.0 * Math.Log10((double)volume)) / 2.0) - 10000) : -10000;
            }
        }
        
        /// <summary>
        /// Accessor to the current volume.
        /// </summary>
        /// <remarks>
        /// This is used by the AV form to get the volume in the PositionVolumeSlider.
        ///  
        /// </remarks>
        public int Volume
        {
            get{return currentVolume;}
        }


        /// <summary>
        /// Allows the AV form to set the width of the UI.
        /// </summary>
        /// <remarks>
        /// This is then used in the override Size accessor to calulate
        /// the actual size of the AV form given the video ratio and the
        /// size of the UI.
        /// </remarks>
        public int UIBorderWidth
        {
            set{uIBorderWidth = value;}
        }

        /// <summary>
        /// Allows the AV form to set the height of the UI.
        /// </summary>
        /// <remarks>
        /// This is then used in the override Size accessor to calulate
        /// the actual size of the AV form given the video ratio and the
        /// size of the UI.
        /// </remarks>
        public int UIBorderHeight
        {
            set{uIBorderHeight = value;}
        }
        
        #endregion Receiving side / Playing graph
        
        #endregion Public

        #region Private

        #region Sending side / Capture graph

        private AudioCaptureGraph acg
        {
            get{return AudioCaptureGraph;}
        }

        /// <summary>
        /// Creates the actual FilgraphManager with the chosen microphone
        /// </summary>
        private void CreateAudioGraph(FilterInfo fi)
        {
            Debug.Assert(acg == null);

            // Create the graph, which creates the source filter
            cg = new AudioCaptureGraph(fi);
            Log(acg.AudioSource.Dump());
        }

        /// <summary>
        /// By default, we use the Windows Media Audio V2 compressor
        /// 
        /// We support 2 default bit rates for audio
        /// For 1 channel, we use 32 Kbit
        /// For 2 channel, we use 64 Kbit
        /// 
        /// We have to use a specific media type index in order to get low
        /// latency audio
        /// </summary>
        private void DefaultAudioCompressorSettings()
        {
            Debug.Assert(AudioCompressor.DefaultName == "Windows Media Audio V2");

            // Find out the media type of the microphone
            _AMMediaType mt;
            object fb;
            acg.AudioSource.GetMediaType(out mt, out fb);
            WAVEFORMATEX wfe = (WAVEFORMATEX)fb;

            // Assume single channel
            int mtIdx = AudioCompressor.MediaTypeIndices[0];

            if(wfe.Channels >= 2)
            {
                mtIdx = AudioCompressor.MediaTypeIndices[1];
            }

            acg.AudioCompressor.SetMediaType(
                acg.AudioCompressor.PreConnectMediaTypes[mtIdx]);
        }


        #region Registry
        
        /// <summary>
        /// Restore the microphone's last settings from the registry
        /// </summary>
        private void RestoreMicrophoneSettings()
        {
            object setting = AVReg.ReadValue(DeviceKey(), AVReg.MicrophoneSourceIndex);
            if(setting != null)
            {
                if((int)setting < acg.Source.InputPins.Count)
                {
                    acg.AudioSource.InputPinIndex = (int)setting;
                }
            }
        }

        /// <summary>
        /// Restore the audio stream's last settings from the registry
        /// </summary>
        private void RestoreAudioSettings()
        {
            // Read media type from registry
            byte[] bytes = (byte[])AVReg.ReadValue(DeviceKey(), AVReg.MediaType);

            if(bytes != null)
            {
                AVReg.ms.Position = 0;
                AVReg.ms.Write(bytes, 0, bytes.Length);

                AVReg.ms.Position = 0;
                _AMMediaType mt = (_AMMediaType)AVReg.bf.Deserialize(AVReg.ms);
                
                // Read format block from registry
                if(mt.cbFormat != 0)
                {
                    bytes = (byte[])AVReg.ReadValue(DeviceKey(), AVReg.FormatBlock);
                    Debug.Assert(bytes.Length == mt.cbFormat);

                    mt.pbFormat = Marshal.AllocCoTaskMem((int)mt.cbFormat);
                    Marshal.Copy(bytes, 0, mt.pbFormat, (int)mt.cbFormat);

                    Log("Restoring stream settings...");
                    Log(MediaType.Dump(mt));

                    try
                    {
                        // Set and free
                        acg.Source.SetMediaType(ref mt);
                    }
                    catch(COMException ex)
                    {
                        Log(DShowError._AMGetErrorText(ex.ErrorCode));
                        Log(ex.ToString());
                    }
                    catch(Exception ex)
                    {
                        Log(ex.ToString());
                    }
                }
            }
        }

        
        #endregion Registry

        #endregion Sending side / Capture graph

        #region Receiving side / Playing graph

        private void DisposeFgm()
        {
            lock(fgmLock)
            {
                if (fgm != null)
                {
                    // We need to manually unblock the stream in case there is no data flowing
                    if(rtpStream != null)
                    {
                        rtpStream.UnblockNextFrame();
                    }

                    FilterGraph.RemoveFromRot(rotID);
                    fgm.Stop();
                    FilterGraph.RemoveAllFilters(fgm);
                    fgm = null;
                    iBA = null;
                }
            }
        }

        private void RtpStream_FirstFrameReceived(object sender, EventArgs ea)
        {
            // It is safe to render the graph, because there is a frame available
            if(sender == rtpStream)
            {
                // Creation of the fgm and the adding / removing of filters needs to happen on the
                // same thread.  So make sure it all happens on the UI thread.
                Conference.FormInvoke(new System.Windows.Forms.MethodInvoker(_RtpStream_FirstFrameReceived), null);
            }
        }

        /// <summary>
        /// Creation of the fgm and the adding / removing of filters needs to happen on the
        /// same thread.  So make sure it all happens on the UI thread.
        /// </summary>
        private void _RtpStream_FirstFrameReceived()
        {
            lock(fgmLock)
            {
                DisposeFgm();

                Debug.Assert(fgm == null);

                fgm = new FilgraphManagerClass();
                IGraphBuilder iGB = (IGraphBuilder)fgm;            
                rotID = FilterGraph.AddToRot(iGB);

                IBaseFilter rtpSource = RtpSourceClass.CreateInstance();
                ((MSR.LST.MDShow.Filters.IRtpSource)rtpSource).Initialize(rtpStream);
                iGB.AddFilter(rtpSource, "RtpSource");

                // Add the chosen audio renderer
                FilterInfo fi = SelectedSpeaker();
                iGB.AddFilter(Filter.CreateBaseFilter(fi), fi.Name);

                iGB.Render(Filter.GetPin(rtpSource, _PinDirection.PINDIR_OUTPUT, Guid.Empty, 
                    Guid.Empty, false, 0));

                iBA = (IBasicAudio)fgm;
                currentVolume = (int)Math.Round(Math.Pow(10.0, (2.0*(double)(iBA.Volume+10000))/10000.0));
                iBA = null;

                uiState &= ~(int)FAudioVideo.UIState.RemoteAudioStopped;

                if(form != null)
                {
                    ((FAudioVideo)form).UpdateAudioUI(uiState);
                }

                // FirstFrameReceived interprets fgmState as the *desired* state for the fgm
                // Because ResumePlayingAudio won't actually start if the state is already 
                // Running, we change it to Stopped so that it will start
                if(IsPlaying && fgmState == FilterGraph.State.Running)
                {
                    fgmState = FilterGraph.State.Stopped;
                    ResumePlayingAudio();
                }
            }
        }
 
        private void rtpStream_DataStarted(object sender, EventArgs ea)
        {
            // Let the form know data has started flowing again
            uiState &= ~(int)FAudioVideo.UIState.RemoteAudioStopped;
            ((FAudioVideo)form).UpdateAudioUI(uiState);
        }


        private void rtpStream_DataStopped(object sender, EventArgs ea)
        {
            // Let the form know data has stopped flowing again
            uiState |= (int)FAudioVideo.UIState.RemoteAudioStopped;
            ((FAudioVideo)form).UpdateAudioUI(uiState);
        }


        #endregion Receiving side / Playing graph

        #endregion
    }
}