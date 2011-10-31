using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Diagnostics;
using System.Runtime.InteropServices;

using Microsoft.Win32;
using MSR.LST.MDShow;

namespace MSR.LST.ConferenceXP
{
    public class frmAVDevices : System.Windows.Forms.Form
    {
        #region Windows Form Designer generated code

        private System.Windows.Forms.CheckBox chkAutoPlayVideo;
        private System.Windows.Forms.RadioButton rdbtnWindowTiled;
        private System.Windows.Forms.RadioButton rdbtnWindowFourWay;
        private System.Windows.Forms.RadioButton rdbtnWindowFullScreen;
        private System.Windows.Forms.Label lblVideoCameras;
        private System.Windows.Forms.Label lblMicrophone;
        private System.Windows.Forms.Button btnAdvancedVideoSettings;
        private System.Windows.Forms.Label lblSpeaker;
        private System.Windows.Forms.Button btnAdvancedAudioSettings;
        private System.Windows.Forms.CheckBox ckPlayAudio;
        private System.Windows.Forms.Label lblTestAudio;
        private System.Windows.Forms.CheckBox ckPlayVideo;
        private System.Windows.Forms.Label lblVideoInfo;
        private System.Windows.Forms.Button btnTroubleshooting;
        private System.Windows.Forms.CheckedListBox clbCameras;
        private System.Windows.Forms.ComboBox cboMicrophones;
        private System.Windows.Forms.ComboBox cboSpeakers;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Timer tmrPerf;
        private System.Windows.Forms.Label lblPerf;
        private System.Windows.Forms.CheckBox chkAutoPlayRemoteAudio;
        private System.Windows.Forms.CheckBox chkAutoPlayRemoteVideo;
        private System.Windows.Forms.GroupBox gbAutoPlay;
        private System.Windows.Forms.GroupBox gbAudioDevices;
        private System.Windows.Forms.GroupBox gbVideoDevices;
        private System.Windows.Forms.GroupBox gbWindowLayout;
        private System.Windows.Forms.GroupBox gbPerf;
        private System.ComponentModel.IContainer components;
        
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAVDevices));
            this.btnClose = new System.Windows.Forms.Button();
            this.chkAutoPlayRemoteAudio = new System.Windows.Forms.CheckBox();
            this.gbAudioDevices = new System.Windows.Forms.GroupBox();
            this.btnAdvancedAudioSettings = new System.Windows.Forms.Button();
            this.cboSpeakers = new System.Windows.Forms.ComboBox();
            this.lblSpeaker = new System.Windows.Forms.Label();
            this.lblMicrophone = new System.Windows.Forms.Label();
            this.cboMicrophones = new System.Windows.Forms.ComboBox();
            this.ckPlayAudio = new System.Windows.Forms.CheckBox();
            this.lblTestAudio = new System.Windows.Forms.Label();
            this.gbVideoDevices = new System.Windows.Forms.GroupBox();
            this.clbCameras = new System.Windows.Forms.CheckedListBox();
            this.btnAdvancedVideoSettings = new System.Windows.Forms.Button();
            this.lblVideoCameras = new System.Windows.Forms.Label();
            this.ckPlayVideo = new System.Windows.Forms.CheckBox();
            this.lblVideoInfo = new System.Windows.Forms.Label();
            this.chkAutoPlayVideo = new System.Windows.Forms.CheckBox();
            this.rdbtnWindowFourWay = new System.Windows.Forms.RadioButton();
            this.rdbtnWindowFullScreen = new System.Windows.Forms.RadioButton();
            this.rdbtnWindowTiled = new System.Windows.Forms.RadioButton();
            this.gbWindowLayout = new System.Windows.Forms.GroupBox();
            this.gbPerf = new System.Windows.Forms.GroupBox();
            this.lblPerf = new System.Windows.Forms.Label();
            this.btnTroubleshooting = new System.Windows.Forms.Button();
            this.tmrPerf = new System.Windows.Forms.Timer(this.components);
            this.chkAutoPlayRemoteVideo = new System.Windows.Forms.CheckBox();
            this.gbAutoPlay = new System.Windows.Forms.GroupBox();
            this.gbAudioDevices.SuspendLayout();
            this.gbVideoDevices.SuspendLayout();
            this.gbWindowLayout.SuspendLayout();
            this.gbPerf.SuspendLayout();
            this.gbAutoPlay.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnClose.Location = new System.Drawing.Point(480, 260);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 23);
            this.btnClose.TabIndex = 37;
            this.btnClose.Text = "Close";
            // 
            // chkAutoPlayRemoteAudio
            // 
            this.chkAutoPlayRemoteAudio.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkAutoPlayRemoteAudio.Location = new System.Drawing.Point(8, 40);
            this.chkAutoPlayRemoteAudio.Name = "chkAutoPlayRemoteAudio";
            this.chkAutoPlayRemoteAudio.Size = new System.Drawing.Size(128, 16);
            this.chkAutoPlayRemoteAudio.TabIndex = 53;
            this.chkAutoPlayRemoteAudio.Text = "Others audio streams";
            // 
            // gbAudioDevices
            // 
            this.gbAudioDevices.Controls.Add(this.btnAdvancedAudioSettings);
            this.gbAudioDevices.Controls.Add(this.cboSpeakers);
            this.gbAudioDevices.Controls.Add(this.lblSpeaker);
            this.gbAudioDevices.Controls.Add(this.lblMicrophone);
            this.gbAudioDevices.Controls.Add(this.cboMicrophones);
            this.gbAudioDevices.Controls.Add(this.ckPlayAudio);
            this.gbAudioDevices.Controls.Add(this.lblTestAudio);
            this.gbAudioDevices.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbAudioDevices.Location = new System.Drawing.Point(296, 8);
            this.gbAudioDevices.Name = "gbAudioDevices";
            this.gbAudioDevices.Size = new System.Drawing.Size(280, 188);
            this.gbAudioDevices.TabIndex = 52;
            this.gbAudioDevices.TabStop = false;
            this.gbAudioDevices.Text = "Audio Settings";
            // 
            // btnAdvancedAudioSettings
            // 
            this.btnAdvancedAudioSettings.Enabled = false;
            this.btnAdvancedAudioSettings.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdvancedAudioSettings.Location = new System.Drawing.Point(8, 112);
            this.btnAdvancedAudioSettings.Name = "btnAdvancedAudioSettings";
            this.btnAdvancedAudioSettings.Size = new System.Drawing.Size(112, 23);
            this.btnAdvancedAudioSettings.TabIndex = 71;
            this.btnAdvancedAudioSettings.Text = "Advanced Settings...";
            this.btnAdvancedAudioSettings.Click += new System.EventHandler(this.btnAdvancedAudioSettings_Click);
            // 
            // cboSpeakers
            // 
            this.cboSpeakers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSpeakers.Location = new System.Drawing.Point(8, 36);
            this.cboSpeakers.Name = "cboSpeakers";
            this.cboSpeakers.Size = new System.Drawing.Size(264, 21);
            this.cboSpeakers.Sorted = true;
            this.cboSpeakers.TabIndex = 47;
            this.cboSpeakers.SelectedIndexChanged += new System.EventHandler(this.cboSpeakers_SelectedIndexChanged);
            // 
            // lblSpeaker
            // 
            this.lblSpeaker.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSpeaker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblSpeaker.Location = new System.Drawing.Point(8, 20);
            this.lblSpeaker.Name = "lblSpeaker";
            this.lblSpeaker.Size = new System.Drawing.Size(88, 16);
            this.lblSpeaker.TabIndex = 46;
            this.lblSpeaker.Text = "Sound playback:";
            // 
            // lblMicrophone
            // 
            this.lblMicrophone.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMicrophone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblMicrophone.Location = new System.Drawing.Point(8, 66);
            this.lblMicrophone.Name = "lblMicrophone";
            this.lblMicrophone.Size = new System.Drawing.Size(96, 16);
            this.lblMicrophone.TabIndex = 45;
            this.lblMicrophone.Text = "Sound recording:";
            // 
            // cboMicrophones
            // 
            this.cboMicrophones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMicrophones.Location = new System.Drawing.Point(8, 82);
            this.cboMicrophones.Name = "cboMicrophones";
            this.cboMicrophones.Size = new System.Drawing.Size(264, 21);
            this.cboMicrophones.Sorted = true;
            this.cboMicrophones.TabIndex = 28;
            this.cboMicrophones.SelectedIndexChanged += new System.EventHandler(this.cboMicrophones_SelectedIndexChanged);
            // 
            // ckPlayAudio
            // 
            this.ckPlayAudio.Appearance = System.Windows.Forms.Appearance.Button;
            this.ckPlayAudio.Enabled = false;
            this.ckPlayAudio.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ckPlayAudio.Location = new System.Drawing.Point(192, 112);
            this.ckPlayAudio.Name = "ckPlayAudio";
            this.ckPlayAudio.Size = new System.Drawing.Size(80, 24);
            this.ckPlayAudio.TabIndex = 82;
            this.ckPlayAudio.Text = "Test Audio";
            this.ckPlayAudio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckPlayAudio.CheckedChanged += new System.EventHandler(this.ckPlayAudio_CheckedChanged);
            // 
            // lblTestAudio
            // 
            this.lblTestAudio.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTestAudio.Location = new System.Drawing.Point(8, 144);
            this.lblTestAudio.Name = "lblTestAudio";
            this.lblTestAudio.Size = new System.Drawing.Size(264, 28);
            this.lblTestAudio.TabIndex = 81;
            this.lblTestAudio.Text = "lblTestAudio";
            // 
            // gbVideoDevices
            // 
            this.gbVideoDevices.Controls.Add(this.clbCameras);
            this.gbVideoDevices.Controls.Add(this.btnAdvancedVideoSettings);
            this.gbVideoDevices.Controls.Add(this.lblVideoCameras);
            this.gbVideoDevices.Controls.Add(this.ckPlayVideo);
            this.gbVideoDevices.Controls.Add(this.lblVideoInfo);
            this.gbVideoDevices.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbVideoDevices.Location = new System.Drawing.Point(8, 8);
            this.gbVideoDevices.Name = "gbVideoDevices";
            this.gbVideoDevices.Size = new System.Drawing.Size(280, 188);
            this.gbVideoDevices.TabIndex = 51;
            this.gbVideoDevices.TabStop = false;
            this.gbVideoDevices.Text = "Video Settings";
            // 
            // clbCameras
            // 
            this.clbCameras.HorizontalScrollbar = true;
            this.clbCameras.Location = new System.Drawing.Point(8, 36);
            this.clbCameras.Name = "clbCameras";
            this.clbCameras.Size = new System.Drawing.Size(256, 64);
            this.clbCameras.Sorted = true;
            this.clbCameras.TabIndex = 68;
            this.clbCameras.SelectedIndexChanged += new System.EventHandler(this.clbCameras_SelectedIndexChanged);
            this.clbCameras.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbCameras_ItemCheck);
            // 
            // btnAdvancedVideoSettings
            // 
            this.btnAdvancedVideoSettings.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdvancedVideoSettings.Location = new System.Drawing.Point(8, 108);
            this.btnAdvancedVideoSettings.Name = "btnAdvancedVideoSettings";
            this.btnAdvancedVideoSettings.Size = new System.Drawing.Size(112, 23);
            this.btnAdvancedVideoSettings.TabIndex = 66;
            this.btnAdvancedVideoSettings.Text = "Advanced Settings...";
            this.btnAdvancedVideoSettings.Click += new System.EventHandler(this.btnAdvancedVideoSettings_Click);
            // 
            // lblVideoCameras
            // 
            this.lblVideoCameras.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblVideoCameras.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblVideoCameras.Location = new System.Drawing.Point(8, 20);
            this.lblVideoCameras.Name = "lblVideoCameras";
            this.lblVideoCameras.Size = new System.Drawing.Size(104, 16);
            this.lblVideoCameras.TabIndex = 68;
            this.lblVideoCameras.Text = "Select camera(s):";
            // 
            // ckPlayVideo
            // 
            this.ckPlayVideo.Appearance = System.Windows.Forms.Appearance.Button;
            this.ckPlayVideo.Enabled = false;
            this.ckPlayVideo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ckPlayVideo.Location = new System.Drawing.Point(184, 108);
            this.ckPlayVideo.Name = "ckPlayVideo";
            this.ckPlayVideo.Size = new System.Drawing.Size(80, 24);
            this.ckPlayVideo.TabIndex = 75;
            this.ckPlayVideo.Text = "Test Video";
            this.ckPlayVideo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckPlayVideo.CheckedChanged += new System.EventHandler(this.ckPlayVideo_CheckedChanged);
            // 
            // lblVideoInfo
            // 
            this.lblVideoInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblVideoInfo.Location = new System.Drawing.Point(8, 140);
            this.lblVideoInfo.Name = "lblVideoInfo";
            this.lblVideoInfo.Size = new System.Drawing.Size(260, 42);
            this.lblVideoInfo.TabIndex = 84;
            this.lblVideoInfo.Text = "lblVideoInfo";
            // 
            // chkAutoPlayVideo
            // 
            this.chkAutoPlayVideo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkAutoPlayVideo.Location = new System.Drawing.Point(8, 20);
            this.chkAutoPlayVideo.Name = "chkAutoPlayVideo";
            this.chkAutoPlayVideo.Size = new System.Drawing.Size(128, 16);
            this.chkAutoPlayVideo.TabIndex = 65;
            this.chkAutoPlayVideo.Text = "My video stream(s)";
            // 
            // rdbtnWindowFourWay
            // 
            this.rdbtnWindowFourWay.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdbtnWindowFourWay.Location = new System.Drawing.Point(8, 40);
            this.rdbtnWindowFourWay.Name = "rdbtnWindowFourWay";
            this.rdbtnWindowFourWay.Size = new System.Drawing.Size(64, 16);
            this.rdbtnWindowFourWay.TabIndex = 70;
            this.rdbtnWindowFourWay.Text = "Four-way";
            // 
            // rdbtnWindowFullScreen
            // 
            this.rdbtnWindowFullScreen.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdbtnWindowFullScreen.Location = new System.Drawing.Point(8, 60);
            this.rdbtnWindowFullScreen.Name = "rdbtnWindowFullScreen";
            this.rdbtnWindowFullScreen.Size = new System.Drawing.Size(72, 16);
            this.rdbtnWindowFullScreen.TabIndex = 71;
            this.rdbtnWindowFullScreen.Text = "Full screen";
            // 
            // rdbtnWindowTiled
            // 
            this.rdbtnWindowTiled.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdbtnWindowTiled.Location = new System.Drawing.Point(8, 20);
            this.rdbtnWindowTiled.Name = "rdbtnWindowTiled";
            this.rdbtnWindowTiled.Size = new System.Drawing.Size(48, 16);
            this.rdbtnWindowTiled.TabIndex = 72;
            this.rdbtnWindowTiled.Text = "Tiled";
            // 
            // gbWindowLayout
            // 
            this.gbWindowLayout.Controls.Add(this.rdbtnWindowFullScreen);
            this.gbWindowLayout.Controls.Add(this.rdbtnWindowFourWay);
            this.gbWindowLayout.Controls.Add(this.rdbtnWindowTiled);
            this.gbWindowLayout.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbWindowLayout.Location = new System.Drawing.Point(176, 204);
            this.gbWindowLayout.Name = "gbWindowLayout";
            this.gbWindowLayout.Size = new System.Drawing.Size(112, 80);
            this.gbWindowLayout.TabIndex = 73;
            this.gbWindowLayout.TabStop = false;
            this.gbWindowLayout.Text = "Window Layout";
            // 
            // gbPerf
            // 
            this.gbPerf.Controls.Add(this.lblPerf);
            this.gbPerf.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbPerf.Location = new System.Drawing.Point(296, 204);
            this.gbPerf.Name = "gbPerf";
            this.gbPerf.Size = new System.Drawing.Size(280, 46);
            this.gbPerf.TabIndex = 74;
            this.gbPerf.TabStop = false;
            this.gbPerf.Text = "Resource Utilization";
            // 
            // lblPerf
            // 
            this.lblPerf.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPerf.Location = new System.Drawing.Point(8, 20);
            this.lblPerf.Name = "lblPerf";
            this.lblPerf.Size = new System.Drawing.Size(264, 16);
            this.lblPerf.TabIndex = 85;
            this.lblPerf.Text = "lblPerf";
            // 
            // btnTroubleshooting
            // 
            this.btnTroubleshooting.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnTroubleshooting.Location = new System.Drawing.Point(296, 260);
            this.btnTroubleshooting.Name = "btnTroubleshooting";
            this.btnTroubleshooting.Size = new System.Drawing.Size(128, 24);
            this.btnTroubleshooting.TabIndex = 75;
            this.btnTroubleshooting.Text = "Troubleshooting Log...";
            this.btnTroubleshooting.Click += new System.EventHandler(this.btnTroubleshooting_Click);
            // 
            // tmrPerf
            // 
            this.tmrPerf.Interval = 2000;
            this.tmrPerf.Tick += new System.EventHandler(this.tmrPerf_Tick);
            // 
            // chkAutoPlayRemoteVideo
            // 
            this.chkAutoPlayRemoteVideo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkAutoPlayRemoteVideo.Location = new System.Drawing.Point(8, 60);
            this.chkAutoPlayRemoteVideo.Name = "chkAutoPlayRemoteVideo";
            this.chkAutoPlayRemoteVideo.Size = new System.Drawing.Size(128, 16);
            this.chkAutoPlayRemoteVideo.TabIndex = 76;
            this.chkAutoPlayRemoteVideo.Text = "Others video streams";
            // 
            // gbAutoPlay
            // 
            this.gbAutoPlay.Controls.Add(this.chkAutoPlayVideo);
            this.gbAutoPlay.Controls.Add(this.chkAutoPlayRemoteAudio);
            this.gbAutoPlay.Controls.Add(this.chkAutoPlayRemoteVideo);
            this.gbAutoPlay.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbAutoPlay.Location = new System.Drawing.Point(8, 204);
            this.gbAutoPlay.Name = "gbAutoPlay";
            this.gbAutoPlay.Size = new System.Drawing.Size(152, 80);
            this.gbAutoPlay.TabIndex = 77;
            this.gbAutoPlay.TabStop = false;
            this.gbAutoPlay.Text = "Auto-play";
            // 
            // frmAVDevices
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(586, 292);
            this.ControlBox = false;
            this.Controls.Add(this.gbAutoPlay);
            this.Controls.Add(this.btnTroubleshooting);
            this.Controls.Add(this.gbPerf);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbWindowLayout);
            this.Controls.Add(this.gbAudioDevices);
            this.Controls.Add(this.gbVideoDevices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAVDevices";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Audio/Video Settings";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmAVDevices_Closing);
            this.Load += new System.EventHandler(this.frmAVDevices_Load);
            this.gbAudioDevices.ResumeLayout(false);
            this.gbVideoDevices.ResumeLayout(false);
            this.gbWindowLayout.ResumeLayout(false);
            this.gbPerf.ResumeLayout(false);
            this.gbAutoPlay.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if(components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }


        #endregion

        #region Members

        private RegistryKey cxpclientRegKey = null;
        
        internal Hashtable vcs = new Hashtable();
        private VideoCapability vc = null;
        private AudioCapability ac = null;
        
        private VideoCaptureGraph vcg = null;
        private AudioCaptureGraph acg = null;

        private PerformanceCounter pcCPU;
        private PerformanceCounter pcMem;

        private frmAVTroubleshooting trouble;

        #endregion Members

        #region Constructor

        public frmAVDevices(RegistryKey cxpclientkey)
        {
            InitializeComponent();

            cxpclientRegKey = cxpclientkey;

            if(PerformanceCounterCategory.Exists("Processor") && 
               PerformanceCounterCategory.CounterExists("% Processor Time", "Processor") &&
               PerformanceCounterCategory.InstanceExists("_Total", "Processor"))
            {
                pcCPU = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            }

            if(PerformanceCounterCategory.Exists("Process") && 
               PerformanceCounterCategory.CounterExists("Working Set", "Process") &&
               PerformanceCounterCategory.InstanceExists(
                 System.Reflection.Assembly.GetEntryAssembly().GetName(false).Name, "Process"))
            {
                pcMem = new PerformanceCounter("Process", "Working Set", 
                    System.Reflection.Assembly.GetEntryAssembly().GetName(false).Name);
            }
        }

        
        #endregion Constructor

        #region Load

        private void frmAVDevices_Load(object sender, System.EventArgs e)
        {
            StaticText();
            InitializeCXPValues();

            // Perf thread
            UpdatePerfLabel();
            if(pcCPU != null || pcMem != null)
            {
                tmrPerf.Start();
            }

            // Create the form we will be logging to
            trouble = new frmAVTroubleshooting();

            try
            {
                // Populate device lists
                DiscoverDevices();

                // Show the form before initializing devices, since that can take a while
                this.Text = "Audio/Video Settings - Initializing devices...";
                this.Cursor = Cursors.WaitCursor;
                Show();
                Refresh();

                // Restore any previously selected devices
                RestoreAudio();
                RestoreVideo();
            }
            finally
            {
                this.Text = "Audio/Video Settings";
                this.Cursor = Cursors.Default;
            }
        }

        private void frmAVDevices_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveSettings();

            if(ac != null)
            {
                // If a camera hasn't been linked, link the first one
                if(clbCameras.CheckedItems.Count > 0)
                {
                    bool goodLink = false;

                    // Read from registry and select camera, if in list
                    string[] linkedCamera = AVReg.ValueNames(AVReg.LinkedCamera);
                    if(linkedCamera != null && linkedCamera.Length > 0)
                    {
                        Debug.Assert(linkedCamera.Length == 1);

                        for(int i = 0; i < clbCameras.CheckedItems.Count; i++)
                        {
                            FilterInfo fi = (FilterInfo)clbCameras.CheckedItems[i];
                            if(fi.Moniker == linkedCamera[0])
                            {
                                goodLink = true;
                                break;
                            }
                        }
                    }

                    if(!goodLink)
                    {
                        SaveLinkedCamera((FilterInfo)clbCameras.CheckedItems[0]);
                    }
                }

                ac.Dispose();
            }

            foreach(VideoCapability vc in vcs.Values)
            {
                vc.Dispose();
            }

            if(ckPlayVideo.Checked)
            {
                // To clean up any video windows
                GC.Collect();
            }

            tmrPerf.Stop();
            trouble.Close();
        }


        private void StaticText()
        {
            lblTestAudio.Text = "Warning: Depending on your configuration, " + 
                "testing audio may create an audio feedback loop.";
        }

        private void InitializeCXPValues()
        {
            // Load previously saved or default settings
            chkAutoPlayVideo.Checked = Conference.AutoPlayLocal;
            chkAutoPlayRemoteAudio.Checked = FMain.AutoPlayRemoteAudio;
            chkAutoPlayRemoteVideo.Checked = FMain.AutoPlayRemoteVideo;

            // Only one of these will be true
            rdbtnWindowFourWay.Checked = (Conference.AutoPosition == Conference.AutoPositionMode.FourWay);
            rdbtnWindowTiled.Checked = (Conference.AutoPosition == Conference.AutoPositionMode.Tiled);
            rdbtnWindowFullScreen.Checked = (Conference.AutoPosition == Conference.AutoPositionMode.FullScreen);
        }

        private void DiscoverDevices()
        {
            Log("Cameras");
            foreach(FilterInfo fi in VideoSource.Sources())
            {
                clbCameras.Items.Add(fi);
                Log(string.Format("{0}, {1}", fi.DisplayName, fi.Moniker));
            }

            Log("\r\nMicrophones");
            // Add a blank so they can unselect the microphone
            cboMicrophones.Items.Add("<none>");
            foreach(FilterInfo fi in AudioSource.Sources())
            {
                cboMicrophones.Items.Add(fi);
                Log(string.Format("{0}, {1}", fi.DisplayName, fi.Moniker));
            }

            Log("\r\nSpeakers");
            foreach(FilterInfo fi in AudioRenderer.Renderers())
            {
                cboSpeakers.Items.Add(fi);
                Log(string.Format("{0}, {1}", fi.DisplayName, fi.Moniker));
            }
        }

        private void RestoreVideo()
        {
            // Get the UI set up correctly in the event there are no selected cameras
            ClearVideoBox();

            foreach(FilterInfo fi in VideoCapability.SelectedCameras())
            {
                int idx = clbCameras.Items.IndexOf(fi);
                clbCameras.SetItemChecked(idx, true);
                clbCameras.SetSelected(idx, true);
            }
        }

        private void RestoreAudio()
        {
            foreach(FilterInfo fi in AudioCapability.SelectedMicrophones())
            {
                cboMicrophones.SelectedIndex = cboMicrophones.Items.IndexOf(fi);
            }

            if(cboMicrophones.SelectedIndex == -1)
            {
                cboMicrophones.SelectedIndex = 0;
            }

            cboSpeakers.SelectedIndex = cboSpeakers.Items.IndexOf(AudioCapability.SelectedSpeaker());
        }

                
        #endregion Load

        #region Perf

        private void tmrPerf_Tick(object sender, System.EventArgs e)
        {
            UpdatePerfLabel();
        }

        private void UpdatePerfLabel()
        {
            string cpu = "unknown";
            if(pcCPU != null)
            {
                cpu = ((uint)pcCPU.NextValue()).ToString() + " %";
            }

            string mem = "unknown";
            if(pcMem != null)
            {
                mem = ((uint)(pcMem.NextValue() / (1024 * 1024))).ToString();
            }

            lblPerf.Text = string.Format("Machine CPU: {0}{1}" +
                "ConferenceXP memory: {2} MB", cpu, "     ", mem);
        }


        #endregion Perf

        #region Video

        private void ClearVideoBox()
        {
            ckPlayVideo.Enabled = vcs.Count > 0;
            btnAdvancedVideoSettings.Enabled = false;
            lblVideoInfo.Enabled = false;
            
            lblVideoInfo.Text = "Resolution:\r\nFrame rate:\r\nCompressor:";
        }

        private void UpdateVideoBox()
        {
            btnAdvancedVideoSettings.Enabled = true;
            lblVideoInfo.Enabled = true;

            // Update video info about the camera
            _AMMediaType mt;
            object formatBlock;
            vcg.Source.GetMediaType(out mt, out formatBlock);

            // TODO - Is VIH the right type for all video
            VIDEOINFOHEADER vih = (VIDEOINFOHEADER)formatBlock;
            BITMAPINFOHEADER bmih = vih.BitmapInfo;

            string info = string.Format("Resolution: {0}x{1}\r\nFrame rate: {2} fps", 
                bmih.Width, bmih.Height, vih.FrameRate.ToString("F2"));

            if(vcg.Compressor == null)
            {
                info += string.Format("\r\nCompressor: Disabled");
            }
            else
            {
                info += string.Format("\r\nCompressed bit rate: {0} Kbps", 
                    vcg.VideoCompressor.QualityInfo.BitRate / 1000);
            }

            lblVideoInfo.Text = info;
        }


        private void clbCameras_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                ClearVideoBox();

                vc = (VideoCapability)vcs[(FilterInfo)clbCameras.SelectedItem];
                vcg = vc != null ? vc.VideoCaptureGraph : null;

                if(clbCameras.GetItemChecked(clbCameras.SelectedIndex))
                {
                    UpdateVideoBox();
                }
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

        private void clbCameras_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
        {
            try
            {
                if(e.NewValue == CheckState.Checked)
                {
                    ActivateVideoCapability((FilterInfo)clbCameras.Items[e.Index]);

                    // Only save the camera after we were able to successfully activate it
                    AVReg.WriteValue(AVReg.SelectedCameras, vcg.Source.Moniker, 
                        vcg.Source.FriendlyName);
                }
                else if(e.NewValue == CheckState.Unchecked)
                {
                    // Remove the camera from the registry, even if we can't shut it down
                    AVReg.DeleteValue(AVReg.SelectedCameras, vcg.Source.Moniker);

                    DeactivateVideoCapability((FilterInfo)clbCameras.SelectedItem);
                }
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

        private void btnAdvancedVideoSettings_Click(object sender, System.EventArgs e)
        {
            new frmVideoSettings(vc, this).ShowDialog(this);
            UpdateVideoBox();
        }

        private void ckPlayVideo_CheckedChanged(object sender, System.EventArgs e)
        {
            foreach(VideoCapability vc in vcs.Values)
            {
                try
                {
                    ckPlayVideo.Text = ckPlayVideo.Checked ? "Stop Video" : "Test Video";
                    RenderAndRunVideo(vc.VideoCaptureGraph);
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

        
        private void ActivateVideoCapability(FilterInfo fi)
        {
            Debug.Assert(!vcs.Contains(fi));
            vc = new VideoCapability(fi);
            vcs.Add(fi, vc);
            
            vc.SetLogger(new AVLogger(Log));
            vc.ActivateCamera();
            vcg = vc.VideoCaptureGraph;

            RenderAndRunVideo(vcg);
        }
        
        private void DeactivateVideoCapability(FilterInfo fi)
        {
            RenderAndRunVideo(vcg, false);
            vcg = null;
            
            VideoCapability vc = (VideoCapability)vcs[fi];
            vcs.Remove(fi);
            vc.DeactivateCamera();
        }


        public void RenderAndRunVideo(VideoCaptureGraph vcg)
        {
            RenderAndRunVideo(vcg, ckPlayVideo.Checked);
        }

        public void RenderAndRunVideo(VideoCaptureGraph vcg, bool playIt)
        {
            if(playIt)
            {
                Log("Playing video (render and run graph) - " + vcg.Source.FriendlyName);

                vcg.RenderLocal();

                VideoCapability.DisableDXVA(vcg.FilgraphManager);
                
                // Set device name in the video window and turn off the system menu
                IVideoWindow iVW = (IVideoWindow)vcg.FilgraphManager;
                iVW.Caption = vcg.Source.FriendlyName;
                iVW.WindowStyle &= ~0x00080000; // WS_SYSMENU

                vcg.Run();
            }
            else
            {
                Log("Stop video (stop and unrender graph) - " + vcg.Source.FriendlyName);

                vcg.Stop();
                vcg.RemoveRenderer();
                
                // I have no idea why the video window stays up but this fixes it
                GC.Collect();
            }
            
            Log(FilterGraph.Debug(vcg.IFilterGraph));
        }

        #endregion Video

        #region Audio

        private void cboSpeakers_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // Delete previous value
            string[] selectedSpeaker = AVReg.ValueNames(AVReg.SelectedSpeaker);
            if(selectedSpeaker != null)
            {
                Debug.Assert(selectedSpeaker.Length == 1);
                AVReg.DeleteValue(AVReg.SelectedSpeaker, selectedSpeaker[0]);
            }

            // Store current value
            FilterInfo fi = (FilterInfo)cboSpeakers.SelectedItem;
            AVReg.WriteValue(AVReg.SelectedSpeaker, fi.Moniker, fi.Name);

            if(acg != null)
            {
                RenderAndRunAudio(acg, false);
                RenderAndRunAudio(acg);
            }
        }

        private void cboMicrophones_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if(acg != null)
                {
                    AVReg.DeleteValue(AVReg.SelectedMicrophone, acg.Source.Moniker);
                    DeactivateAudioCapability();
                }

                if(cboMicrophones.SelectedIndex != 0)
                {
                    FilterInfo fi = (FilterInfo)cboMicrophones.SelectedItem;
                    ActivateAudioCapability(fi);

                    AVReg.WriteValue(AVReg.SelectedMicrophone, fi.Moniker, fi.Name);
                }

                btnAdvancedAudioSettings.Enabled = cboMicrophones.SelectedIndex > 0;
                ckPlayAudio.Enabled = cboMicrophones.SelectedIndex > 0;
                lblTestAudio.Enabled = cboMicrophones.SelectedIndex > 0;
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

        private void btnAdvancedAudioSettings_Click(object sender, System.EventArgs e)
        {
            new frmAudioSettings(ac, this).ShowDialog(this);
        }

        private void ckPlayAudio_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                ckPlayAudio.Text = ckPlayAudio.Checked ? "Stop Audio" : "Test Audio";
                RenderAndRunAudio(acg, ckPlayAudio.Checked);
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
        

        private void ActivateAudioCapability(FilterInfo fi)
        {
            ac = new AudioCapability(fi);
            ac.SetLogger(new AVLogger(Log));
            ac.ActivateMicrophone();
            acg = ac.AudioCaptureGraph;
            
            RenderAndRunAudio(acg, ckPlayAudio.Checked);
        }
        
        private void DeactivateAudioCapability()
        {
            RenderAndRunAudio(acg, false);
            acg = null;
            
            ac.DeactivateMicrophone();
        }

        public void RenderAndRunAudio(AudioCaptureGraph acg)
        {
            RenderAndRunAudio(acg, ckPlayAudio.Checked);
        }

        public void RenderAndRunAudio(AudioCaptureGraph acg, bool playIt)
        {
            if(acg == null)
            {
                throw new ArgumentNullException("Can't render an audio graph without an audio capture device");
            }

            if(playIt)
            {
                Log("Playing audio (render and run graph) - " + acg.Source.FriendlyName);

                // Re-add the renderer in case they changed it since the last 
                // time they played the audio
                acg.AddRenderer((FilterInfo)cboSpeakers.SelectedItem);
                
                acg.Run();
            }
            else
            {
                Log("Stop audio (stop and unrender graph) - " + acg.Source.FriendlyName);

                acg.Stop();
                acg.RemoveRenderer();
            }

            Log(FilterGraph.Debug(acg.IFilterGraph));
        }

        
        #endregion Audio

        public void SaveLinkedCamera(FilterInfo fi)
        {
            // Delete previous link value
            string[] linkedCamera = AVReg.ValueNames(AVReg.LinkedCamera);
            if(linkedCamera != null && linkedCamera.Length > 0)
            {
                Debug.Assert(linkedCamera.Length == 1);
                AVReg.DeleteValue(AVReg.LinkedCamera, linkedCamera[0]);
            }

            // Set the new value
            AVReg.WriteValue(AVReg.LinkedCamera, fi.Moniker, fi.Name);
        }

        private void btnTroubleshooting_Click(object sender, System.EventArgs e)
        {
             trouble.Show();
        }


        private void SaveSettings()
        {
            Conference.AutoPlayLocal = chkAutoPlayVideo.Checked;
            FMain.AutoPlayRemoteAudio = chkAutoPlayRemoteAudio.Checked;
            FMain.AutoPlayRemoteVideo = chkAutoPlayRemoteVideo.Checked;

            cxpclientRegKey.SetValue("AutoPlayLocal", Conference.AutoPlayLocal);
            cxpclientRegKey.SetValue("AutoPlayRemote", Conference.AutoPlayRemote);

            // Auto-position settings
            if (rdbtnWindowFourWay.Checked)
            {
                Conference.AutoPosition = Conference.AutoPositionMode.FourWay;
            }
            else if (rdbtnWindowTiled.Checked)
            {
                Conference.AutoPosition = Conference.AutoPositionMode.Tiled;
            }
            else if (rdbtnWindowFullScreen.Checked)
            {
                Conference.AutoPosition = Conference.AutoPositionMode.FullScreen;
            }
         
            cxpclientRegKey.SetValue("AutoPosition", Conference.AutoPosition);

            cxpclientRegKey.Flush();
        }

        
        public void Log(string msg)
        {
            if(trouble != null)
            {
                trouble.Log(msg);
            }

            Trace.WriteLine(msg);
        }
    }
}
