using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using MSR.LST.ConferenceXP.ArchiveService;

namespace MSR.LST.ConferenceXP
{
    /// <summary>
    /// Summary description for frmArchiveConf.
    /// </summary>
    public class frmArchiveConf : System.Windows.Forms.Form
    {
        #region Windows Form Designer generated code

        #region Controls

        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.ColumnHeader time;
        private System.Windows.Forms.ColumnHeader duration;
        private System.Windows.Forms.Button btnSelect;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.ListView lvwConferences;
        private System.Windows.Forms.ColumnHeader conferenceID;
        private System.Windows.Forms.GroupBox gbHorizontalSeparation;

        private System.Windows.Forms.ListView lvwStreams;
        private System.Windows.Forms.ColumnHeader Participant;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader payload;
        private System.Windows.Forms.ColumnHeader frames;
        private System.Windows.Forms.ColumnHeader streamID;
        private System.Windows.Forms.Label lblConferencesDesc;
        private System.Windows.Forms.Label lblStreamsDesc;
        private System.Windows.Forms.GroupBox gbHorizontalSeparation2; 

        #endregion Controls

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmArchiveConf));
            this.lvwConferences = new System.Windows.Forms.ListView();
            this.name = new System.Windows.Forms.ColumnHeader();
            this.date = new System.Windows.Forms.ColumnHeader();
            this.time = new System.Windows.Forms.ColumnHeader();
            this.duration = new System.Windows.Forms.ColumnHeader();
            this.conferenceID = new System.Windows.Forms.ColumnHeader();
            this.lblConferencesHeader = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.lblConferencesDesc = new System.Windows.Forms.Label();
            this.gbHorizontalSeparation = new System.Windows.Forms.GroupBox();
            this.lvwStreams = new System.Windows.Forms.ListView();
            this.Participant = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.payload = new System.Windows.Forms.ColumnHeader();
            this.frames = new System.Windows.Forms.ColumnHeader();
            this.streamID = new System.Windows.Forms.ColumnHeader();
            this.gbHorizontalSeparation2 = new System.Windows.Forms.GroupBox();
            this.lblStreamsHeader = new System.Windows.Forms.Label();
            this.gbHorizontalSeparation3 = new System.Windows.Forms.GroupBox();
            this.lblStreamsDesc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvwConferences
            // 
            this.lvwConferences.AllowColumnReorder = true;
            this.lvwConferences.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                                             this.name,
                                                                                             this.date,
                                                                                             this.time,
                                                                                             this.duration,
                                                                                             this.conferenceID});
            this.lvwConferences.FullRowSelect = true;
            this.lvwConferences.GridLines = true;
            this.lvwConferences.HideSelection = false;
            this.lvwConferences.Location = new System.Drawing.Point(16, 52);
            this.lvwConferences.MultiSelect = false;
            this.lvwConferences.Name = "lvwConferences";
            this.lvwConferences.Size = new System.Drawing.Size(504, 176);
            this.lvwConferences.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwConferences.TabIndex = 14;
            this.lvwConferences.View = System.Windows.Forms.View.Details;
            this.lvwConferences.Click += new System.EventHandler(this.lvwConferences_Click);
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 205;
            // 
            // date
            // 
            this.date.Text = "Date";
            this.date.Width = 86;
            // 
            // time
            // 
            this.time.Text = "Time";
            this.time.Width = 85;
            // 
            // duration
            // 
            this.duration.Text = "Duration";
            this.duration.Width = 124;
            // 
            // conferenceID
            // 
            this.conferenceID.Width = 0;
            // 
            // lblConferencesHeader
            // 
            this.lblConferencesHeader.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblConferencesHeader.Location = new System.Drawing.Point(16, 16);
            this.lblConferencesHeader.Name = "lblConferencesHeader";
            this.lblConferencesHeader.Size = new System.Drawing.Size(68, 16);
            this.lblConferencesHeader.TabIndex = 15;
            this.lblConferencesHeader.Text = "Conferences";
            this.lblConferencesHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(424, 488);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Enabled = false;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSelect.Location = new System.Drawing.Point(312, 488);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(95, 23);
            this.btnSelect.TabIndex = 17;
            this.btnSelect.Text = "Select";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // lblConferencesDesc
            // 
            this.lblConferencesDesc.Location = new System.Drawing.Point(16, 32);
            this.lblConferencesDesc.Name = "lblConferencesDesc";
            this.lblConferencesDesc.Size = new System.Drawing.Size(232, 16);
            this.lblConferencesDesc.TabIndex = 18;
            this.lblConferencesDesc.Text = "Select the conference you want to play back:";
            this.lblConferencesDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbHorizontalSeparation
            // 
            this.gbHorizontalSeparation.Location = new System.Drawing.Point(84, 18);
            this.gbHorizontalSeparation.Name = "gbHorizontalSeparation";
            this.gbHorizontalSeparation.Size = new System.Drawing.Size(436, 8);
            this.gbHorizontalSeparation.TabIndex = 19;
            this.gbHorizontalSeparation.TabStop = false;
            // 
            // lvwStreams
            // 
            this.lvwStreams.AllowColumnReorder = true;
            this.lvwStreams.CheckBoxes = true;
            this.lvwStreams.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                                         this.Participant,
                                                                                         this.columnHeader1,
                                                                                         this.payload,
                                                                                         this.frames,
                                                                                         this.streamID});
            this.lvwStreams.GridLines = true;
            this.lvwStreams.HideSelection = false;
            this.lvwStreams.Location = new System.Drawing.Point(16, 276);
            this.lvwStreams.Name = "lvwStreams";
            this.lvwStreams.Size = new System.Drawing.Size(504, 184);
            this.lvwStreams.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwStreams.TabIndex = 20;
            this.lvwStreams.View = System.Windows.Forms.View.Details;
            this.lvwStreams.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvwStreams_MouseUp);
            // 
            // Participant
            // 
            this.Participant.Text = "Participant";
            this.Participant.Width = 123;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Stream";
            this.columnHeader1.Width = 170;
            // 
            // payload
            // 
            this.payload.Text = "Type";
            this.payload.Width = 99;
            // 
            // frames
            // 
            this.frames.Text = "Frames";
            this.frames.Width = 107;
            // 
            // streamID
            // 
            this.streamID.Text = "Stream ID";
            this.streamID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.streamID.Width = 0;
            // 
            // gbHorizontalSeparation2
            // 
            this.gbHorizontalSeparation2.Location = new System.Drawing.Point(64, 242);
            this.gbHorizontalSeparation2.Name = "gbHorizontalSeparation2";
            this.gbHorizontalSeparation2.Size = new System.Drawing.Size(456, 8);
            this.gbHorizontalSeparation2.TabIndex = 28;
            this.gbHorizontalSeparation2.TabStop = false;
            // 
            // lblStreamsHeader
            // 
            this.lblStreamsHeader.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblStreamsHeader.Location = new System.Drawing.Point(16, 240);
            this.lblStreamsHeader.Name = "lblStreamsHeader";
            this.lblStreamsHeader.Size = new System.Drawing.Size(48, 16);
            this.lblStreamsHeader.TabIndex = 27;
            this.lblStreamsHeader.Text = "Streams";
            this.lblStreamsHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbHorizontalSeparation3
            // 
            this.gbHorizontalSeparation3.Location = new System.Drawing.Point(16, 468);
            this.gbHorizontalSeparation3.Name = "gbHorizontalSeparation3";
            this.gbHorizontalSeparation3.Size = new System.Drawing.Size(504, 8);
            this.gbHorizontalSeparation3.TabIndex = 29;
            this.gbHorizontalSeparation3.TabStop = false;
            // 
            // lblStreamsDesc
            // 
            this.lblStreamsDesc.Location = new System.Drawing.Point(16, 256);
            this.lblStreamsDesc.Name = "lblStreamsDesc";
            this.lblStreamsDesc.Size = new System.Drawing.Size(216, 16);
            this.lblStreamsDesc.TabIndex = 30;
            this.lblStreamsDesc.Text = "Select the streams you want to play back:";
            this.lblStreamsDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmArchiveConf
            // 
            this.AcceptButton = this.btnSelect;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(538, 528);
            this.ControlBox = false;
            this.Controls.Add(this.lblStreamsDesc);
            this.Controls.Add(this.gbHorizontalSeparation3);
            this.Controls.Add(this.gbHorizontalSeparation2);
            this.Controls.Add(this.lblStreamsHeader);
            this.Controls.Add(this.lvwStreams);
            this.Controls.Add(this.gbHorizontalSeparation);
            this.Controls.Add(this.lblConferencesDesc);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblConferencesHeader);
            this.Controls.Add(this.lvwConferences);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmArchiveConf";
            this.Text = "Recorded Conferences";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmArchiveConf_Closing);
            this.Load += new System.EventHandler(this.frmArchiveConf_Load);
            this.ResumeLayout(false);

        }
        #endregion

        #region Statics

        private enum ColumnsLvwConferences {Name, Date, Time, Duration, ConferenceID};
        private enum ColumnsLvwStreams {Participant, Name, Payload, Frames, StreamID};

        #endregion Statics

        #region Members

        private IArchiveServer archiver;

        // Reference to BarUI form used to communicate between the Play Back
        // forms and BarUI. It is set in the ctor of frmArchiveConf class.
        private FMain refFMain = null;
        private System.Windows.Forms.Label lblConferencesHeader;
        private System.Windows.Forms.Label lblStreamsHeader;
        private System.Windows.Forms.GroupBox gbHorizontalSeparation3;

        private ArchiveService.Conference[] conferences;

        #endregion Members

        #region Ctor / Dispose

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="archiver"></param>
        public frmArchiveConf( IArchiveServer archiver, FMain refFMain )
        {
            InitializeComponent();
            this.archiver = archiver;
            this.refFMain = refFMain;

            PopulateConferences();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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

        #endregion Ctor / Dispose

        #region UI Tasks

        // TODO: Investigate columns sorting feature
 
        //        #region sorting feature stolen from MSDN docs example (verbatim cut&paste)
        //        // so, umm, that's like (c) Microsoft 2000 (2002? '04? <shrug>) ... (thanks!)  :-)
        //        // ColumnClick event handler.
        //        private void ColumnClick(object o, ColumnClickEventArgs e)
        //        {
        //            // Set the ListViewItemSorter property to a new ListViewItemComparer 
        //            // object. Setting this property immediately sorts the 
        //            // ListView using the ListViewItemComparer object.
        //            this.lvwStreams.ListViewItemSorter = new ListViewItemComparer(e.Column);
        //        }
        //
        //        // Implements the manual sorting of items by columns.
        //        class ListViewItemComparer : IComparer
        //        {
        //            private int col;
        //            public ListViewItemComparer()
        //            {
        //                col = 0;
        //            }
        //            public ListViewItemComparer(int column)
        //            {
        //                col = column;
        //            }
        //            public int Compare(object x, object y)
        //            {
        //                return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
        //            }
        //        }
        //        #endregion

        /// <summary>
        /// Populate the conferences in the list view lvwConferences
        /// </summary>
        private void PopulateConferences()
        {
            try
            {
                conferences = archiver.GetConferences();
            
                if (conferences.Length > 0)
                {
                    lvwConferences.Enabled = true;

                    for ( int i = 0; i < conferences.Length; i++)
                    {
                        TimeSpan duration = conferences[i].End - conferences[i].Start;
                        string formattedDuration = duration.Hours.ToString("00") + ":" + duration.Minutes.ToString("00") + ":" + duration.Seconds.ToString("00");

                        // Add conferences to the list view 
                        // TODO: Uses something like Enum.GetNames(ColumnsLvwConferences).Length instead of hardcoded value 5
                        string[] cols = new string[5];

                        cols[(int)ColumnsLvwConferences.Name] = conferences[i].Description;
                        cols[(int)ColumnsLvwConferences.Date] = conferences[i].Start.ToShortDateString();
                        cols[(int)ColumnsLvwConferences.Time] = conferences[i].Start.ToLongTimeString();
                        cols[(int)ColumnsLvwConferences.Duration] = formattedDuration;
                        cols[(int)ColumnsLvwConferences.ConferenceID] = conferences[i].ConferenceID.ToString();
                        ListViewItem conferenceItem = new ListViewItem(cols);
                        // TODO: use the LVI.Tag feature and remove the private variable 'conferences'
                        conferenceItem.Tag = conferences[i];
                        lvwConferences.Items.Add(conferenceItem);
                    } 
                }
                else
                {
                    lvwConferences.Enabled = false;                
                }
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                MessageBox.Show(this, 
                    "The Archive Service did not respond. Make sure the Archive Service you \n" +
                    "specified in ConferenceXP is correct and that server is online. \n" +
                    "For further assistance, contact your server's administrator. \n" +
                    "\nException Message: " + ex.Message, 
                    "Archive Service Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,
                    "The Archive Service is currently unavailable or may have encountered an \n" +
                    "unexpected error. For further assistance contact your server's administrator. \n" +
                    "\nException:\n" + ex.ToString(), "Archive Service Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        /// <summary>
        /// Get the selected conference and open the dialog box that allows to
        /// select the streams to play for this conference
        /// </summary>
        /// <param name="sender">The event sender object</param>
        /// <param name="e">The event arguments</param>
        private void btnSelect_Click(object sender, System.EventArgs e)
        {           
            // Ensure there is an item selected (the listview is configured for single row select)
            Debug.Assert(lvwConferences.SelectedItems.Count == 1);

            // Get the conference ID of the selected item in the listview
            ArchiveService.Conference conf = (ArchiveService.Conference)lvwConferences.SelectedItems[0].Tag;

            this.Hide();
            
            // Note: we pass a reference to FMain form and this form in the ctor so the created form
            //       can communicate with FMain and this form
            frmArchiveClient client = new frmArchiveClient(this.archiver, conf, Streams, this.refFMain, this);

            client.Show();
            client.Location = new Point(
                SystemInformation.WorkingArea.Right - client.Width,
                SystemInformation.WorkingArea.Bottom - client.Height);
        }

        /// <summary>
        /// frmArchiveConf Load event handler.
        /// </summary>
        /// <param name="sender">The event sender object</param>
        /// <param name="e">The event arguments</param>
        private void frmArchiveConf_Load(object sender, System.EventArgs e)
        {
            // TODO: Instead we could have a hastable of forms on FMain and forms could add their
            //       ref to it when they are created. When the participant leaves the venue,
            //       we close all the forms referred in the hashtable.
            this.refFMain.btnLeaveConference.Click += new EventHandler(btnLeaveConference_Click);

            // Ensure that the playback (and record) menu are disabled to avoid
            // that the user opens several forms
            this.refFMain.EnableMenuActionsPlayback = false;
            this.refFMain.EnableMenuActionsRecord =  false;
        }

        /// <summary>
        /// btnLeaveConference Click event handler. The local participant is leaving 
        /// the venue by clicking "Leave Venue" on BarUI.
        /// </summary>
        /// <param name="sender">The event sender object</param>
        /// <param name="e">The event arguments</param>
        private void btnLeaveConference_Click(object sender, EventArgs e)
        {
            // The participant is leaving the venue, so we can close this form 
            this.Close();
        }

        /// <summary>
        /// btnCancel Click event handler.
        /// </summary>
        /// <param name="sender">The event sender object</param>
        /// <param name="e">The event arguments</param>
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        // TODO: Rename to GetSelectedStreams and place it next to Play_Click
        public int[] Streams
        {
            get
            {
                int [] streams = new int[lvwStreams.CheckedItems.Count];

                for( int i=0; i < lvwStreams.CheckedItems.Count; i++)
                {
                    streams[i] = Int32.Parse(lvwStreams.CheckedItems[i].SubItems[(int)ColumnsLvwStreams.StreamID].Text);
                }
                return streams;
            }
        }

        /// <summary>
        /// Enable the select button if there is one conference selected and at least one
        /// stream checked. 
        /// </summary>
        private void UpdateSelectButtonState()
        {
            if ((lvwConferences.SelectedItems.Count > 0) && (Streams.Length > 0))
            {
                btnSelect.Enabled = true;
            } 
            else
            {
                btnSelect.Enabled = false;
            }                                            
        }

        /// <summary>
        /// lvwConferences_Click get the streams information of the selected conference and 
        /// display it in the lvwStreams list view.
        /// </summary>
        /// <param name="sender">The event sender object</param>
        /// <param name="e">The event arguments</param>
        private void lvwConferences_Click(object sender, System.EventArgs e)
        {
            try
            {
                ArchiveService.Conference conf = (ArchiveService.Conference)lvwConferences.SelectedItems[0].Tag;
                Debug.Assert( conf != null );
            
                if ( conf != null )
                {
                    ArchiveService.Participant[] participants = archiver.GetParticipants(conf.ConferenceID);
                    lvwStreams.Items.Clear();
                    foreach ( ArchiveService.Participant participant in participants )
                    {
                        ArchiveService.Stream[] streams = archiver.GetStreams( participant.ParticipantID);

                        foreach( ArchiveService.Stream s in streams )
                        {
                            // TODO: Create the string array with enum (same as frmArchiveConf)
                            // TODO: Eventually use Tag to set to the stream
                            ListViewItem stream = new ListViewItem( 
                                new string[] { participant.Name, s.Name, s.Payload, s.Frames.ToString(), s.StreamID.ToString() } );
                            stream.Checked = true;
                            lvwStreams.Items.Add( stream);
                        }
                    }
                }

                UpdateSelectButtonState();
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                MessageBox.Show(this, 
                    "The Archive Service did not respond. Make sure the Archive Service you \n" +
                    "specified in ConferenceXP is correct and that server is online. \n" +
                    "For further assistance, contact your server's administrator. \n" +
                    "\nException Message: " + ex.Message, 
                    "Archive Service Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,
                    "The Archive Service is currently unavailable or may have encountered an \n" +
                    "unexpected error. For further assistance contact your server's administrator. \n" +
                    "\nException:\n" + ex.ToString(), "Archive Service Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// frmArchiveConf Closing event handler.
        /// </summary>
        /// <param name="sender">The event sender object</param>
        /// <param name="e">The event arguments</param>
        private void frmArchiveConf_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Reinitialize Archiver Menu Status
            this.refFMain.SetArchiverMenuStatus();
        }

        /// <summary>
        /// lvwStreams MouseUp event handler. A stream check box might have been selected or deselected,
        /// so update the select button state if needed (if no streams selected the user should not
        /// have the possibility to play)
        /// </summary>
        /// <param name="sender">The event sender object</param>
        /// <param name="e">The event arguments</param>
        private void lvwStreams_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            UpdateSelectButtonState();
        }

        #endregion UI Tasks
    }
}
