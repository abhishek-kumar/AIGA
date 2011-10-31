using System;
using System.Diagnostics;
using System.Threading;
using System.Collections;
using System.Net;
using System.Text;
using MSR.LST.Net.Rtp;


namespace MSR.LST.ConferenceXP.ArchiveService
{
    /// <summary>
    /// Responsible for recording a conference. Acts as the high-level recording application
    /// </summary>
    internal class ConferenceRecorder
    {
        #region ParticipantWrapper
        /// <summary>
        /// Used to map an rtp participant to a database participant
        /// </summary>
        internal class  ParticipantWrapper
        {
            public RtpParticipant   participant;
            public int              participantID;

            public ParticipantWrapper( RtpParticipant participant, int id) 
            {
                this.participant = participant;
                participantID = id;
            }
        }
        #endregion

        #region Private/Internal Variables
        private IPEndPoint  venueIPE = null;
        private bool        recording = false;      // if we're.. umm... recording?
        private Hashtable   streams;                // the streams we're reading
        private RtpSession  rtpSession;             // and what we're using to listen for new ones
        private Hashtable   participants;           // the participants we are recording
        private int         conferenceID;           // the id of the conference being recorded
        private Timer       stopTimer;              // timer to stop recording x seconds after the venue is empty

        private string      conferenceDescription;
        private string      venueIdentifier;
        private IPEndPoint  venue;

        private ConferenceRecorderPC perfCounter;
        #endregion

        #region EventLog
        /// <summary>
        /// A singleton event log wrapper.
        /// </summary>
        private static ArchiveServiceEventLog eventLog = null;

        private static void InitEventLog()
        {
            eventLog = new ArchiveServiceEventLog( ArchiveServiceEventLog.Source.ConferenceRecorder);
        }
        #endregion

        #region CTor
        static ConferenceRecorder()
        {
            InitEventLog();
        }
        #endregion

        #region Record
        /// <summary>
        /// Starts recording a conference. Sets up the conference data and then records all streams received until told to stop.
        /// </summary>
        public void RecordConference( string conferenceDescription, string venueIdentifier, IPEndPoint venue )
        {
            if( conferenceDescription.Length >= Constants.MaxDBStringSize || venueIdentifier.Length >= Constants.MaxDBStringSize )
                throw new ArgumentException("String longer than accepted by database.");

            recording = true;
            venueIPE = venue;

            streams = new Hashtable(Constants.InitialStreams);
            participants = new Hashtable();

            conferenceID = DBHelper.CreateConference( conferenceDescription, venueIdentifier, DateTime.Now);
            
            // Store info about this conference to the instance, for debugging reference (mostly)
            this.conferenceDescription  = conferenceDescription;
            this.venueIdentifier = venueIdentifier;
            this.venue = venue;

            // Create our performance counter
            perfCounter = new ConferenceRecorderPC( venueIdentifier + " : " + conferenceDescription );

            // Set up RTCP properties
            RtpEvents.RtpParticipantAdded += new MSR.LST.Net.Rtp.RtpEvents.RtpParticipantAddedEventHandler(this.OnNewRtpParticipant);
            RtpEvents.RtpStreamAdded += new MSR.LST.Net.Rtp.RtpEvents.RtpStreamAddedEventHandler(this.OnNewRtpStream);
            RtpEvents.RtpStreamRemoved += new MSR.LST.Net.Rtp.RtpEvents.RtpStreamRemovedEventHandler(this.OnRtpStreamRemoved);

            // Start listening
            RtpParticipant rtpMe = new RtpParticipant(Constants.PersistenceCName, Constants.PersistenceName + " (RECORDING)");
            rtpSession = new RtpSession(venue, rtpMe, true, true);
        }

        public IPEndPoint Venue
        {
            get
            {
                return venueIPE;
            }
        }
        #endregion

        #region Event handlers
        private void OnNewRtpParticipant( object sender, RtpEvents.RtpParticipantEventArgs ea )
        {
            if (this.rtpSession != sender)
                return;

            RtpParticipant participant = ea.RtpParticipant;

            Trace.WriteLine("New participant: " + participant.CName);

            // we want to ignore ourselves
            if (participant.CName != Constants.PersistenceCName )
            {
                // Make sure this isn't someone who briefly lost connectivity.
                if( !participants.ContainsKey(participant.CName) )
                {
                    string newPartName = participant.Name;
                    if (newPartName == null || newPartName == String.Empty)
                        newPartName = participant.CName;

                    int participantID = DBHelper.CreateParticipant(
                        conferenceID,
                        participant.CName, 
                        newPartName);

                    participants.Add( participant.CName, new ParticipantWrapper(participant, participantID) );
                }

                foreach( uint ssrc in participant.SSRCs )
                {
                    OnNewRtpStream( sender, new RtpEvents.RtpStreamEventArgs(rtpSession.Streams[ssrc]) );
                }
            }
        }


        /// <summary>
        /// we have a new stream - start recording
        /// </summary>
        /// <param name="SSRC">what's arrived</param>
        private void OnNewRtpStream( object sender, RtpEvents.RtpStreamEventArgs ea)
        {
            if (this.rtpSession != sender)
                return;

            RtpStream stream = ea.RtpStream;

            if( streams.ContainsKey(stream.SSRC) )
                return;

            Trace.WriteLine("New stream found: " + stream.Properties.CName + ", " + stream.Properties.Name);

            if ( participants[stream.Properties.CName] != null )
            {
                ParticipantWrapper participant = (ParticipantWrapper)participants[stream.Properties.CName];

                StreamRecorder sm = new StreamRecorder(participant.participantID, stream, perfCounter);
                streams[stream.SSRC] = sm;

                perfCounter.AddInstanceForCollection(sm);

                // Make sure we don't stop recording now
                if( this.stopTimer != null )
                {
                    stopTimer.Dispose();
                    stopTimer = null;
                }
            }
            else
            {
                eventLog.WriteEntry("Detected stream for unknown participant, ignoring.  CNAME: " + 
                    stream.Properties.CName, EventLogEntryType.Error, ArchiveServiceEventLog.ID.Error);
            }
        }

        /// <summary>
        /// the streams gone away...stop recording
        /// </summary>
        /// <param name="SSRC">what's gone</param>
        private void OnRtpStreamRemoved( object sender, RtpEvents.RtpStreamEventArgs ea )
        {
            if (this.rtpSession != sender)
                return;

            RtpStream stream = ea.RtpStream;

            Trace.WriteLine("Rtp stream ended: "  + stream.Properties.CName + ", " + stream.Properties.Name);

            // Stop listening to the stream.
            StreamRecorder sm = (StreamRecorder)streams[stream.SSRC];
            perfCounter.RemoveInstanceForCollection(sm);
            sm.StopListening();
            streams.Remove(stream.SSRC);

            // Set the countdown timer if the venue is empty
            if( streams.Count == 0 )
            {
                this.stopTimer = new Timer(new TimerCallback(StopRecordingCallee), null,
                    Constants.StopAfterVenueEmptySec*1000, Timeout.Infinite);
            }
        }
        #endregion

        #region Stop / IsRecording
        private void StopRecordingCallee(object state)
        {
            StopRecording();
        }

        /// <summary>
        /// Stops recording the current conference
        /// </summary>
        public void StopRecording()
        {
            if( stopTimer != null )
            {
                stopTimer.Dispose();
                stopTimer = null;
            }

            if( this.perfCounter != null )
            {
                this.perfCounter.Dispose();
            }

            if( this.recording )
            {
                perfCounter.Dispose();

                // Stop all the streams
                foreach ( StreamRecorder sm in streams.Values)
                {
                    sm.StopListening();
                }

                streams = null;
                participants = null;

                // Stop the rtpSession
                RtpEvents.RtpParticipantAdded -= new RtpEvents.RtpParticipantAddedEventHandler(this.OnNewRtpParticipant);
                RtpEvents.RtpStreamAdded -= new RtpEvents.RtpStreamAddedEventHandler(this.OnNewRtpStream);
                RtpEvents.RtpStreamRemoved -= new RtpEvents.RtpStreamRemovedEventHandler(this.OnRtpStreamRemoved);

                if( rtpSession != null )
                {
                    rtpSession.Dispose();
                    rtpSession = null;
                }

                DBHelper.RecordConferenceEndTime( conferenceID, System.DateTime.Now);

                this.recording = false;
            }
        }

        public bool IsRecording
        { get{ return recording; } }
        #endregion
    }
}
