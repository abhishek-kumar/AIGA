using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;
using MSR.LST;


namespace MSR.LST.ConferenceXP.ArchiveService
{
    /// <summary>
    /// Summary description for AdminUI.
    /// </summary>
    public class AdminUI : System.Windows.Forms.Form
    {
        #region WinForm Designer Privates
        private System.Windows.Forms.Button cleanUpBtn;
        private System.Windows.Forms.Button deleteRangeBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Label databaseLbl;
        private MSR.LST.ConferenceXP.ArchiveService.ConferencesTreeView conferencesTreeView;
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Button refreshBtn;
        private MSR.LST.Services.BasicServiceButtons basicButtons;
        private MSR.LST.Services.ServiceControlButtons serviceButtons;
        #endregion

        #region Privates
        private const string helpUrlArchiver = "http://research.microsoft.com/conferencexp/redirects/services/archiveservicehelp.htm";
        #endregion
        
        #region Main, Ctor, Dispose
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) 
        {
            Application.EnableVisualStyles();
            Application.Run(new AdminUI());
        }
        
        public AdminUI()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            this.basicButtons.HelpUrl = helpUrlArchiver;
            this.basicButtons.AboutClicked += new EventHandler(this.aboutBtn_Click);
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
        #endregion

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AdminUI));
            this.databaseLbl = new System.Windows.Forms.Label();
            this.cleanUpBtn = new System.Windows.Forms.Button();
            this.deleteRangeBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.conferencesTreeView = new MSR.LST.ConferenceXP.ArchiveService.ConferencesTreeView();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.basicButtons = new MSR.LST.Services.BasicServiceButtons();
            this.serviceButtons = new MSR.LST.Services.ServiceControlButtons();
            this.SuspendLayout();
            // 
            // databaseLbl
            // 
            this.databaseLbl.ForeColor = System.Drawing.Color.Blue;
            this.databaseLbl.Location = new System.Drawing.Point(16, 0);
            this.databaseLbl.Name = "databaseLbl";
            this.databaseLbl.Size = new System.Drawing.Size(96, 32);
            this.databaseLbl.TabIndex = 1;
            this.databaseLbl.Text = "Archive Database";
            this.databaseLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cleanUpBtn
            // 
            this.cleanUpBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cleanUpBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cleanUpBtn.Location = new System.Drawing.Point(256, 340);
            this.cleanUpBtn.Name = "cleanUpBtn";
            this.cleanUpBtn.Size = new System.Drawing.Size(96, 24);
            this.cleanUpBtn.TabIndex = 3;
            this.cleanUpBtn.Text = "Clean Up...";
            this.cleanUpBtn.Click += new System.EventHandler(this.cleanUpBtn_Click);
            // 
            // deleteRangeBtn
            // 
            this.deleteRangeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteRangeBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.deleteRangeBtn.Location = new System.Drawing.Point(368, 376);
            this.deleteRangeBtn.Name = "deleteRangeBtn";
            this.deleteRangeBtn.Size = new System.Drawing.Size(96, 24);
            this.deleteRangeBtn.TabIndex = 3;
            this.deleteRangeBtn.Text = "Delete Range...";
            this.deleteRangeBtn.Click += new System.EventHandler(this.deleteRangeBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteBtn.Enabled = false;
            this.deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.deleteBtn.Location = new System.Drawing.Point(368, 340);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(96, 24);
            this.deleteBtn.TabIndex = 3;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // conferencesTreeView
            // 
            this.conferencesTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.conferencesTreeView.LabelEdit = true;
            this.conferencesTreeView.Location = new System.Drawing.Point(16, 28);
            this.conferencesTreeView.Name = "conferencesTreeView";
            this.conferencesTreeView.Size = new System.Drawing.Size(448, 296);
            this.conferencesTreeView.TabIndex = 5;
            this.conferencesTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.conferencesTreeView_AfterSelect);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.refreshBtn.Location = new System.Drawing.Point(144, 340);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(96, 24);
            this.refreshBtn.TabIndex = 3;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // basicButtons
            // 
            this.basicButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.basicButtons.HelpUrl = null;
            this.basicButtons.Location = new System.Drawing.Point(16, 432);
            this.basicButtons.Name = "basicButtons";
            this.basicButtons.Size = new System.Drawing.Size(448, 24);
            this.basicButtons.TabIndex = 6;
            // 
            // serviceButtons
            // 
            this.serviceButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.serviceButtons.Location = new System.Drawing.Point(16, 340);
            this.serviceButtons.Name = "serviceButtons";
            this.serviceButtons.ServiceName = null;
            this.serviceButtons.Size = new System.Drawing.Size(336, 68);
            this.serviceButtons.TabIndex = 7;
            // 
            // AdminUI
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(480, 466);
            this.Controls.Add(this.basicButtons);
            this.Controls.Add(this.conferencesTreeView);
            this.Controls.Add(this.databaseLbl);
            this.Controls.Add(this.deleteRangeBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.cleanUpBtn);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.serviceButtons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(488, 500);
            this.Name = "AdminUI";
            this.Text = "ConferenceXP Archive Service Manager";
            this.Resize += new System.EventHandler(this.AdminUI_Resize);
            this.Load += new System.EventHandler(this.AdminUI_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AdminUI_Paint);
            this.ResumeLayout(false);

        }
        #endregion

        #region Form Events - Paint & Load
        private void AdminUI_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            using(Graphics g = e.Graphics)
            {
                // Draw line across bottom of UI
                int stopBottom = serviceButtons.Top + serviceButtons.Height;
                int lineY = stopBottom + (basicButtons.Top - stopBottom)/2;
                int lineRight = conferencesTreeView.Left + conferencesTreeView.Width;
                int lineLeft = conferencesTreeView.Left;
                DrawLine(g, lineY, lineLeft, lineRight);

                // Draw line next to ArchiveService label
                lineY = databaseLbl.Top + databaseLbl.Height/2;
                lineLeft = databaseLbl.Left + databaseLbl.Width;
                DrawLine(g, lineY, lineLeft, lineRight);
            }
        }

        private void DrawLine(Graphics g, int lineY, int lineLeft, int lineRight)
        {
            g.DrawLine(SystemPens.ControlDark, lineLeft, lineY, lineRight, lineY);
            lineY += 1;
            g.DrawLine(SystemPens.ControlLightLight, lineLeft, lineY, lineRight, lineY);
        }

        private void AdminUI_Resize(object sender, System.EventArgs e)
        {
            // Do a refresh to re-paint the lines on the UI
            this.Refresh();
        }

        private void AdminUI_Load(object sender, System.EventArgs e)
        {
            // Connect to service
            string name = ConfigurationManager.AppSettings["ServiceName"];
            if( name != null )
            {
                serviceButtons.ServiceName = name;
            }
            bool serviceFound = serviceButtons.ConnectToService();

            // Verify that we're connected to the service
            if( !serviceFound )
            {
                MessageBox.Show(this, 
                    "The "+this.Text+" could not connect to the windows servce \n"+
                    "\"ConferenceXP Archive Service\". Please check to make sure that the ServiceName \n"+
                    "specified in the application configuration file is correct.",
                    "Error Connecting to Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return; // early return to skip the code below
            }

            // Connect to the DB
            conferencesTreeView.Connect();

            // Report errors about both connections in one dialog
            if( !conferencesTreeView.Connected )
            {
                MessageBox.Show(this, 
                    "The "+this.Text+" could not connect to the Microsoft \n"+
                    "SQL database. Ensure that the database is properly created and that the \n"+
                    "SqlConnectionString specified in the application configuration file is correct.",
                    "Error Connecting to Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private Bitmap GiveTransparentBkgnd(Image img)
        {
            Bitmap icon = new Bitmap(img);
            icon.MakeTransparent( icon.GetPixel(0,0) );
            return icon;
        }
        #endregion

        #region UI Actions - Database
        private void cleanUpBtn_Click(object sender, System.EventArgs e)
        {
            // Verify the user is ok w/ stopping the archive service
            DialogResult dr = MessageBox.Show(this, 
                "The Clean Up Database feature removes the following \n" +
                "records from your Archive Service database:\n" +
                " - Conferences without participants\n" +
                " - Participants without streams\n" +
                " - Streams without recorded frames\n" +
                " - Streams without raw data\n\n" +
                "To complete these tasks, the Archive Service must be\n" + 
                "stopped. Clicking OK temporarily stops this service,\n" +
                "causing any current conference recordings to stop.",
                "Clean Up Database", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, 
                MessageBoxDefaultButton.Button2);

            if( dr != DialogResult.OK )
                return;

            // Stop the archive service, if we can.
            bool stoppedService = false;
            if( serviceButtons.ServiceController != null && serviceButtons.ServiceController.Running )
            {
                stoppedService = true;
                serviceButtons.ServiceController.StopServiceAndWait();
            }
            if( serviceButtons.ServiceController != null && serviceButtons.ServiceController.Running )
                return;

            // Do the DB operation
            conferencesTreeView.CleanUpDatabase();

            // Restart Service
            if( stoppedService )
                serviceButtons.ServiceController.StartServiceAndWait();
        }

        private void deleteRangeBtn_Click(object sender, System.EventArgs e)
        {
            // Show DeleteRangeForm as Dialog
            DeleteRange rangeDialog = new DeleteRange();
            DialogResult dr = rangeDialog.ShowDialog(this);
            if( dr != DialogResult.OK )
                return;

            // Find all of the conferences we will delete (in an ineffecient manner)
            DateTime start = rangeDialog.StartDateTime;
            DateTime end = rangeDialog.EndDateTime;
            TreeNode[] confs = conferencesTreeView.GetConferencesInRange(start, end);

            // Check for no conferences found
            if( confs.Length == 0 )
            {
                MessageBox.Show(this, "No conferences were found during that time period.", 
                    "Invalid Range", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Are you sure?
                String areYouSure = String.Format(
                    "Are you sure you want to delete {0} conferences\n"+
                    "created from {1} at {2}\nto {3} at {4}?", confs.Length, start.ToLongDateString(),
                    start.ToShortTimeString(), end.ToLongDateString(), end.ToShortTimeString());
                dr = MessageBox.Show(this, areYouSure, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if( dr != DialogResult.Yes )
                    return;

                // Display wait cursor
                Cursor.Current = Cursors.WaitCursor;

                // Delete the conferences
                conferencesTreeView.DeleteConferences(confs);

                // Return to normal cursor
                Cursor.Current = Cursors.Default;
            }
        }

        private void deleteBtn_Click(object sender, System.EventArgs e)
        {
            if( conferencesTreeView.SelectedNode == null )
                return;

            StringBuilder str = new StringBuilder();
            str.Append("Are you sure you want to delete the ");

            if( conferencesTreeView.SelectedNode.Tag is Conference )
            {
                Conference conf = (conferencesTreeView.SelectedNode.Tag as Conference);
                str.AppendFormat("conference \n\"{0}\" and all the content it contains?", conf.Description);
            }
            else if( conferencesTreeView.SelectedNode.Tag is Participant )
            {
                Participant part = (conferencesTreeView.SelectedNode.Tag as Participant);
                str.AppendFormat("participant \n\"{0}\" \" and all the content it contains?", part.Name);
            }
            else if( conferencesTreeView.SelectedNode.Tag is Stream )
            {
                Stream stream = (conferencesTreeView.SelectedNode.Tag as Stream);
                str.AppendFormat("stream \"{0}\"?", stream.Name);
            }
            else
            {
                str.AppendFormat("folder \n\"{0}\" and all the content it contains?", conferencesTreeView.SelectedNode.Text);
            }

            // Ask "are you sure?"
            DialogResult result = MessageBox.Show( str.ToString(),
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if( result != DialogResult.Yes )
                return;

            // Display wait cursor
            Cursor.Current = Cursors.WaitCursor;

            // Delete node
            conferencesTreeView.DeleteNode(conferencesTreeView.SelectedNode);

            // Return to normal cursor
            Cursor.Current = Cursors.Default;
        }

        private void refreshBtn_Click(object sender, System.EventArgs e)
        {
            conferencesTreeView.Connect();        
        }

        private void conferencesTreeView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (conferencesTreeView.SelectedNode != null)
                deleteBtn.Enabled = true;
            else
                deleteBtn.Enabled = false;
        }

        private void conferencesTreeView_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if( e.KeyCode == Keys.Delete )
                this.deleteBtn_Click(this, e);
        }
        #endregion

        #region UI Actions - About
        private void aboutBtn_Click(object sender, System.EventArgs e)
        {
            string versions = 
                GetAssemblyDescription(Assembly.GetExecutingAssembly()) + "\n" +
                GetAssemblyDescription(Assembly.Load("MSR.LST.Net.Rtp")) + "\n" +
                GetAssemblyDescription(Assembly.Load("Archiver"));

            MessageBox.Show( this, 
                "ConferenceXP Archive Service\n" +
                "Microsoft Research\n\n" +
                versions + "\n\n" +
                "For more information, see http://research.microsoft.com/conferencexp/",
                "About ConferenceXP Archive Service" );
        }

        /// <summary>
        /// Stolen from Conference.dll for Help->About
        /// </summary>
        private static string GetAssemblyDescription(Assembly a)
        {
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(a.Location);
            return a.GetName().Name + " : " + fvi.FileVersion;
        }
        #endregion

    }
}
