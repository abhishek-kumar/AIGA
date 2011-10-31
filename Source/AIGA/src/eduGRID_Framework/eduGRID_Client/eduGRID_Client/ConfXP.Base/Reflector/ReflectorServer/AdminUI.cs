using System;
using System.Net;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using MSR.LST.Services;

namespace MSR.LST.ConferenceXP.ReflectorService
{
    public class AdminUI : System.Windows.Forms.Form
    {
        #region Windows Form Designer generated private members

        private System.Windows.Forms.Label lblDynamicPort;
        private System.Windows.Forms.Label lblJoinPort;
        private System.Windows.Forms.Button forceLeaveBtn;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.ListBox tableListBox;
        private System.Windows.Forms.Label addressLbl;
        private System.Windows.Forms.Label participantsLbl;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenu contextMenu;
        private System.Windows.Forms.MenuItem openMenuItem;
        private MSR.LST.Services.BasicServiceButtons serviceBtns;
        private System.ComponentModel.IContainer components;
        
        #endregion

        #region Members

        private const string helpUrlReflector = "http://research.microsoft.com/conferencexp/redirects/services/reflectorservicehelp.htm";
        private SimpleServiceController service;

        #endregion
        
        #region Constructor, Dispose
        
        public AdminUI()
        {
            // Required for Windows Form Designer support.
            InitializeComponent();
            
            service = new SimpleServiceController(ReflectorMgr.ReflectorServiceName);

            serviceBtns.HelpUrl = helpUrlReflector;
            serviceBtns.AboutClicked += new EventHandler(ShowAboutMsg);
        }

        
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            trayIcon.Dispose();

            if( disposing )
            {
                if (components != null) 
                {
                    components.Dispose();
                }
            }

            base.Dispose( disposing );
        }

        #endregion

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AdminUI));
            this.refreshBtn = new System.Windows.Forms.Button();
            this.forceLeaveBtn = new System.Windows.Forms.Button();
            this.participantsLbl = new System.Windows.Forms.Label();
            this.addressLbl = new System.Windows.Forms.Label();
            this.tableListBox = new System.Windows.Forms.ListBox();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenu();
            this.openMenuItem = new System.Windows.Forms.MenuItem();
            this.serviceBtns = new MSR.LST.Services.BasicServiceButtons();
            this.lblDynamicPort = new System.Windows.Forms.Label();
            this.lblJoinPort = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // refreshBtn
            // 
            this.refreshBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.refreshBtn.Location = new System.Drawing.Point(320, 408);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(96, 24);
            this.refreshBtn.TabIndex = 0;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // forceLeaveBtn
            // 
            this.forceLeaveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.forceLeaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.forceLeaveBtn.Location = new System.Drawing.Point(208, 408);
            this.forceLeaveBtn.Name = "forceLeaveBtn";
            this.forceLeaveBtn.Size = new System.Drawing.Size(96, 24);
            this.forceLeaveBtn.TabIndex = 1;
            this.forceLeaveBtn.Text = "Force Leave";
            this.forceLeaveBtn.Click += new System.EventHandler(this.forceLeaveBtn_Click);
            // 
            // participantsLbl
            // 
            this.participantsLbl.ForeColor = System.Drawing.Color.Blue;
            this.participantsLbl.Location = new System.Drawing.Point(16, 0);
            this.participantsLbl.Name = "participantsLbl";
            this.participantsLbl.Size = new System.Drawing.Size(112, 32);
            this.participantsLbl.TabIndex = 9;
            this.participantsLbl.Text = "Reflector Participants";
            this.participantsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // addressLbl
            // 
            this.addressLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.addressLbl.Location = new System.Drawing.Point(16, 24);
            this.addressLbl.Name = "addressLbl";
            this.addressLbl.Size = new System.Drawing.Size(384, 25);
            this.addressLbl.TabIndex = 8;
            this.addressLbl.Text = "Client Address            Group Address       Group Port   Join Time";
            this.addressLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableListBox
            // 
            this.tableListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.tableListBox.Location = new System.Drawing.Point(16, 48);
            this.tableListBox.Name = "tableListBox";
            this.tableListBox.Size = new System.Drawing.Size(400, 355);
            this.tableListBox.TabIndex = 7;
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenu = this.contextMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "ConferenceXP Reflector Service Monitor";
            this.trayIcon.Visible = true;
            this.trayIcon.DoubleClick += new System.EventHandler(this.openMenuItem_Click);
            // 
            // contextMenu
            // 
            this.contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                        this.openMenuItem});
            // 
            // openMenuItem
            // 
            this.openMenuItem.Index = 0;
            this.openMenuItem.Text = "Open ConferenceXP Reflector Monitor";
            this.openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
            // 
            // serviceBtns
            // 
            this.serviceBtns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceBtns.HelpUrl = null;
            this.serviceBtns.Location = new System.Drawing.Point(16, 448);
            this.serviceBtns.Name = "serviceBtns";
            this.serviceBtns.Size = new System.Drawing.Size(400, 24);
            this.serviceBtns.TabIndex = 10;
            // 
            // lblDynamicPort
            // 
            this.lblDynamicPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDynamicPort.ForeColor = System.Drawing.Color.Black;
            this.lblDynamicPort.Location = new System.Drawing.Point(120, 404);
            this.lblDynamicPort.Name = "lblDynamicPort";
            this.lblDynamicPort.Size = new System.Drawing.Size(64, 32);
            this.lblDynamicPort.TabIndex = 11;
            this.lblDynamicPort.Text = "*dynamic*";
            this.lblDynamicPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblJoinPort
            // 
            this.lblJoinPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblJoinPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.lblJoinPort.ForeColor = System.Drawing.Color.Black;
            this.lblJoinPort.Location = new System.Drawing.Point(16, 404);
            this.lblJoinPort.Name = "lblJoinPort";
            this.lblJoinPort.Size = new System.Drawing.Size(104, 32);
            this.lblJoinPort.TabIndex = 11;
            this.lblJoinPort.Text = "Reflector join port:";
            this.lblJoinPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AdminUI
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(436, 486);
            this.Controls.Add(this.lblDynamicPort);
            this.Controls.Add(this.serviceBtns);
            this.Controls.Add(this.tableListBox);
            this.Controls.Add(this.addressLbl);
            this.Controls.Add(this.participantsLbl);
            this.Controls.Add(this.forceLeaveBtn);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.lblJoinPort);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(444, 65536);
            this.MinimumSize = new System.Drawing.Size(444, 232);
            this.Name = "AdminUI";
            this.Text = "ConferenceXP Reflector Service Monitor";
            this.Resize += new System.EventHandler(this.AdminUI_Resize);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.AdminUI_Closing);
            this.Load += new System.EventHandler(this.AdminUI_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AdminUI_Paint);
            this.ResumeLayout(false);

        }
        #endregion 

        #region Event Handlers, Form - Load, Paint & Resize

        private void AdminUI_Load(object sender, System.EventArgs e)
        {
            RefreshClientTable();

            // Display join port
            string joinPort = null; 
            if ( (joinPort = ConfigurationManager.AppSettings[AppConfig.JoinPort]) != null )
            {
                lblDynamicPort.Text = joinPort;
            }
        }

        private void AdminUI_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            using(Graphics g = e.Graphics)
            {
                // Draw line across bottom of UI
                int forceLeaveBottom = forceLeaveBtn.Top + forceLeaveBtn.Height;
                int lineY = forceLeaveBottom + (serviceBtns.Top - forceLeaveBottom )/2;
                int lineRight = tableListBox.Left + tableListBox.Width;
                int lineLeft = tableListBox.Left;
                DrawLine(g, lineY, lineLeft, lineRight);

                // Draw line next to Reflector Participants label
                lineY = participantsLbl.Top + participantsLbl.Height/2;
                lineLeft = participantsLbl.Left + participantsLbl.Width;
                DrawLine(g, lineY, lineLeft, lineRight);
            }
        }

        private static void DrawLine(Graphics g, int lineY, int lineLeft, int lineRight)
        {
            g.DrawLine(SystemPens.ControlDark, lineLeft, lineY, lineRight, lineY);
            lineY += 1;
            g.DrawLine(SystemPens.ControlLightLight, lineLeft, lineY, lineRight, lineY);
        }

        private void AdminUI_Resize(object sender, System.EventArgs e)
        {
            Refresh();
        }
        #endregion

        #region Event Handlers, Tray Icon - Form.Closing & Open

        /// <summary>
        /// Hide the form since the system tray icon is associated with the form.
        /// Use the tray icon to show the form without reconstructing.
        /// </summary>
        private void AdminUI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        /// <summary>
        /// Handler for double-click and open in the context menu
        /// </summary>
        private void openMenuItem_Click(object sender, System.EventArgs e)
        {
            RefreshClientTable();
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }

        #endregion

        #region Event Handlers, UI Actions
        
        private void refreshBtn_Click(object sender, System.EventArgs e)
        {
            RefreshClientTable();
        }

        private void forceLeaveBtn_Click(object sender, System.EventArgs e)
        {
            ClientEntry entry = (ClientEntry)tableListBox.SelectedItem;
            
            // List is not empty
            if (entry != null)
            {
                if (RegistrarServer.ClientRegTable.ContainsKey(entry.ClientIP))
                {
                    RegistrarServer.ForceLeave(entry);
                    RefreshClientTable();
                }
                else
                {
                    MessageBox.Show(this, "The Client IP address does not exist. " +
                        "Click the Refresh button to get the current list.", "ConferenceXP Reflector");
                } 
            }
        }

        private void ShowAboutMsg(object sender, System.EventArgs e)
        {
            Assembly reflector = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(reflector.Location);
            string version = reflector.GetName().Name + " : " + fvi.FileVersion;

            MessageBox.Show( this, 
                "ConferenceXP Reflector Service\n" +
                "Microsoft Research\n\n" +
                version + "\n\n" +
                "For more information, see http://research.microsoft.com/conferencexp/",
                "About ConferenceXP Reflector Service" );
        }

        #endregion

        #region Helper method

        private void RefreshClientTable()
        {
            ClientEntry[] clientTable = null;

            lock (RegistrarServer.ClientRegTable.SyncRoot)
            {
                int count = RegistrarServer.ClientRegTable.Count;
                if (count > 0)
                {
                    clientTable = new ClientEntry[count];
                    RegistrarServer.ClientRegTable.Values.CopyTo(clientTable, 0);
                }
            }

            tableListBox.DataSource = clientTable;
        }
        #endregion
    }
}