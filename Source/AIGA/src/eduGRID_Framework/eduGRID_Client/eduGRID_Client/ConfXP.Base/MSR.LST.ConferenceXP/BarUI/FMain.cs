using System;
using System.Configuration;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Net;
using System.Threading;
using System.Windows.Forms;

using Microsoft.Win32;

using MSR.LST;
using MSR.LST.ConferenceXP.ArchiveService;
using MSR.LST.Net.Rtp;
using MSR.LST.MDShow;


namespace MSR.LST.ConferenceXP
{
    public class FMain : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        #region Windows Form Designer generated code

        #region Controls

        private System.ComponentModel.IContainer components;

        private System.Windows.Forms.MenuItem menuActionsCapabilities;
        private System.Windows.Forms.MenuItem menuActionsRecord;
        internal System.Windows.Forms.MenuItem menuActionsPlayback;
        private System.Windows.Forms.MenuItem menuActionsUnicast;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuSettingsNetworkDiagnostics;
        private System.Windows.Forms.MenuItem menuActionsPresentation;
        private System.Windows.Forms.MenuItem menuActionsChat;
        private System.Windows.Forms.MenuItem menuActionsActiveCapabilities;
        private System.Windows.Forms.MenuItem menuSettingsServices;

        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ContextMenu contextParticipant;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ColumnHeader columnHeader;
        internal System.Windows.Forms.Button btnLeaveConference;
        private System.Windows.Forms.StatusBar statusBar;

        private System.Windows.Forms.Timer statusBarTimer;

        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuSettings;
        private System.Windows.Forms.MenuItem menuHelpAbout;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuHelpCommunity;
        private System.Windows.Forms.MenuItem menuMyProfile;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuHelpConferenceXP;
        private System.Windows.Forms.MenuItem menuHelpPresentation;
        private System.Windows.Forms.MenuItem menuSettingsAudioVideo2;
        private System.Windows.Forms.MenuItem menuSettingsRTDocViewer;
        private System.Windows.Forms.MenuItem menuActions;
        private System.Windows.Forms.MenuItem menuActionsWMPlayback;
        private System.Windows.Forms.MenuItem menuActionsScreenScraper;
        private System.Windows.Forms.MenuItem menuActionsSharedBrowser;
        private System.Windows.Forms.MenuItem menuActionsUWClassroomPresenter;
        private System.Windows.Forms.MenuItem menuItem7;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem audioVideoToolStripMenuItem;
        private ToolStripMenuItem servicesToolStripMenuItem;
        private ToolStripMenuItem actionsToolStripMenuItem;
        private ToolStripMenuItem startPresentationToolStripMenuItem;
        private ToolStripMenuItem startChatToolStripMenuItem;
        private ToolStripMenuItem startWindowsMediaPlaybackToolStripMenuItem;
        private ToolStripMenuItem startLocalScreenStreamingToolStripMenuItem;
        private ToolStripMenuItem startSharedBrowserToolStripMenuItem;
        private ToolStripMenuItem startClassroomPresenterToolStripMenuItem;
        private System.Windows.Forms.MenuItem menuSettingsAppConfig;

        #endregion

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader = new System.Windows.Forms.ColumnHeader();
            this.contextParticipant = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.btnLeaveConference = new System.Windows.Forms.Button();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuSettings = new System.Windows.Forms.MenuItem();
            this.menuSettingsAudioVideo2 = new System.Windows.Forms.MenuItem();
            this.menuSettingsServices = new System.Windows.Forms.MenuItem();
            this.menuSettingsRTDocViewer = new System.Windows.Forms.MenuItem();
            this.menuSettingsNetworkDiagnostics = new System.Windows.Forms.MenuItem();
            this.menuMyProfile = new System.Windows.Forms.MenuItem();
            this.menuSettingsAppConfig = new System.Windows.Forms.MenuItem();
            this.menuActions = new System.Windows.Forms.MenuItem();
            this.menuActionsPresentation = new System.Windows.Forms.MenuItem();
            this.menuActionsChat = new System.Windows.Forms.MenuItem();
            this.menuActionsWMPlayback = new System.Windows.Forms.MenuItem();
            this.menuActionsScreenScraper = new System.Windows.Forms.MenuItem();
            this.menuActionsSharedBrowser = new System.Windows.Forms.MenuItem();
            this.menuActionsUWClassroomPresenter = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuActionsCapabilities = new System.Windows.Forms.MenuItem();
            this.menuActionsActiveCapabilities = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuActionsRecord = new System.Windows.Forms.MenuItem();
            this.menuActionsPlayback = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuActionsUnicast = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuHelpConferenceXP = new System.Windows.Forms.MenuItem();
            this.menuHelpPresentation = new System.Windows.Forms.MenuItem();
            this.menuHelpCommunity = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuHelpAbout = new System.Windows.Forms.MenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.statusBarTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audioVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.servicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startPresentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startWindowsMediaPlaybackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startLocalScreenStreamingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startSharedBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startClassroomPresenterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader});
            this.listView.ContextMenu = this.contextParticipant;
            this.listView.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView.ForeColor = System.Drawing.Color.Silver;
            this.listView.LargeImageList = this.imageList;
            this.listView.Location = new System.Drawing.Point(0, 117);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(364, 280);
            this.listView.SmallImageList = this.imageList;
            this.listView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Tile;
            this.listView.ItemActivate += new System.EventHandler(this.listView_ItemActivate);
            this.listView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listView_MouseMove);
            // 
            // columnHeader
            // 
            this.columnHeader.Width = 80;
            // 
            // contextParticipant
            // 
            this.contextParticipant.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2});
            this.contextParticipant.Popup += new System.EventHandler(this.contextParticipant_Popup);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "";
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.imageList.ImageSize = new System.Drawing.Size(48, 48);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 403);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(364, 19);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "Loading";
            // 
            // btnLeaveConference
            // 
            this.btnLeaveConference.BackColor = System.Drawing.Color.Black;
            this.btnLeaveConference.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLeaveConference.ForeColor = System.Drawing.Color.White;
            this.btnLeaveConference.Location = new System.Drawing.Point(0, 24);
            this.btnLeaveConference.Name = "btnLeaveConference";
            this.btnLeaveConference.Size = new System.Drawing.Size(364, 24);
            this.btnLeaveConference.TabIndex = 1;
            this.btnLeaveConference.Text = "Leave Venue";
            this.btnLeaveConference.UseVisualStyleBackColor = false;
            this.btnLeaveConference.Visible = false;
            this.btnLeaveConference.Click += new System.EventHandler(this.btnLeaveConference_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuSettings,
            this.menuActions,
            this.menuItem5});
            // 
            // menuSettings
            // 
            this.menuSettings.Index = 0;
            this.menuSettings.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuSettingsAudioVideo2,
            this.menuSettingsServices,
            this.menuSettingsRTDocViewer,
            this.menuSettingsNetworkDiagnostics,
            this.menuMyProfile,
            this.menuSettingsAppConfig});
            this.menuSettings.Text = "&Settings";
            // 
            // menuSettingsAudioVideo2
            // 
            this.menuSettingsAudioVideo2.Index = 0;
            this.menuSettingsAudioVideo2.Text = "&Audio/Video...";
            this.menuSettingsAudioVideo2.Click += new System.EventHandler(this.menuSettingsAudioVideo2_Click);
            // 
            // menuSettingsServices
            // 
            this.menuSettingsServices.Index = 1;
            this.menuSettingsServices.Text = "&Services...";
            this.menuSettingsServices.Click += new System.EventHandler(this.menuSettingsServices_Click);
            // 
            // menuSettingsRTDocViewer
            // 
            this.menuSettingsRTDocViewer.Index = 2;
            this.menuSettingsRTDocViewer.Text = "&Presentation Viewer";
            // 
            // menuSettingsNetworkDiagnostics
            // 
            this.menuSettingsNetworkDiagnostics.Index = 3;
            this.menuSettingsNetworkDiagnostics.Text = "Start &Connectivity Detector";
            this.menuSettingsNetworkDiagnostics.Click += new System.EventHandler(this.menuSettingsNetworkDiagnostics_Click);
            // 
            // menuMyProfile
            // 
            this.menuMyProfile.Index = 4;
            this.menuMyProfile.Text = "&Profile...";
            this.menuMyProfile.Click += new System.EventHandler(this.menuMyProfile_Click);
            // 
            // menuSettingsAppConfig
            // 
            this.menuSettingsAppConfig.Index = 5;
            this.menuSettingsAppConfig.Text = "App &Config...";
            this.menuSettingsAppConfig.Visible = false;
            this.menuSettingsAppConfig.Click += new System.EventHandler(this.menuSettingsAppConfig_Click);
            // 
            // menuActions
            // 
            this.menuActions.Index = 1;
            this.menuActions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuActionsPresentation,
            this.menuActionsChat,
            this.menuActionsWMPlayback,
            this.menuActionsScreenScraper,
            this.menuActionsSharedBrowser,
            this.menuActionsUWClassroomPresenter,
            this.menuItem7,
            this.menuActionsCapabilities,
            this.menuActionsActiveCapabilities,
            this.menuItem4,
            this.menuActionsRecord,
            this.menuActionsPlayback,
            this.menuItem6,
            this.menuActionsUnicast});
            this.menuActions.Text = "&Actions";
            this.menuActions.Select += new System.EventHandler(this.menuActions_Select);
            // 
            // menuActionsPresentation
            // 
            this.menuActionsPresentation.Enabled = false;
            this.menuActionsPresentation.Index = 0;
            this.menuActionsPresentation.Text = "Start &Presentation...";
            this.menuActionsPresentation.Click += new System.EventHandler(this.menuActionsPresentation_Click);
            // 
            // menuActionsChat
            // 
            this.menuActionsChat.Enabled = false;
            this.menuActionsChat.Index = 1;
            this.menuActionsChat.Text = "Start &Chat...";
            this.menuActionsChat.Click += new System.EventHandler(this.menuActionsChat_Click);
            // 
            // menuActionsWMPlayback
            // 
            this.menuActionsWMPlayback.Enabled = false;
            this.menuActionsWMPlayback.Index = 2;
            this.menuActionsWMPlayback.Text = "Start Windows Media Playback...";
            this.menuActionsWMPlayback.Click += new System.EventHandler(this.menuActionsWMPlayback_Click);
            // 
            // menuActionsScreenScraper
            // 
            this.menuActionsScreenScraper.Enabled = false;
            this.menuActionsScreenScraper.Index = 3;
            this.menuActionsScreenScraper.Text = "Start Local Screen Streaming...";
            this.menuActionsScreenScraper.Click += new System.EventHandler(this.menuActionsScreenScraper_Click);
            // 
            // menuActionsSharedBrowser
            // 
            this.menuActionsSharedBrowser.Enabled = false;
            this.menuActionsSharedBrowser.Index = 4;
            this.menuActionsSharedBrowser.Text = "Start Shared Browser...";
            this.menuActionsSharedBrowser.Click += new System.EventHandler(this.menuActionsSharedBrowser_Click);
            // 
            // menuActionsUWClassroomPresenter
            // 
            this.menuActionsUWClassroomPresenter.Enabled = false;
            this.menuActionsUWClassroomPresenter.Index = 5;
            this.menuActionsUWClassroomPresenter.Text = "Start UW Classroom Presenter...";
            this.menuActionsUWClassroomPresenter.Visible = false;
            this.menuActionsUWClassroomPresenter.Click += new System.EventHandler(this.menuActionsUWClassroomPresenter_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 6;
            this.menuItem7.Text = "-";
            // 
            // menuActionsCapabilities
            // 
            this.menuActionsCapabilities.Enabled = false;
            this.menuActionsCapabilities.Index = 7;
            this.menuActionsCapabilities.Text = "Start &Other Capabilities";
            // 
            // menuActionsActiveCapabilities
            // 
            this.menuActionsActiveCapabilities.Enabled = false;
            this.menuActionsActiveCapabilities.Index = 8;
            this.menuActionsActiveCapabilities.Text = "&Active Venue Capabilities";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 9;
            this.menuItem4.Text = "-";
            // 
            // menuActionsRecord
            // 
            this.menuActionsRecord.Enabled = false;
            this.menuActionsRecord.Index = 10;
            this.menuActionsRecord.Text = "&Record This Conference...";
            this.menuActionsRecord.Click += new System.EventHandler(this.menuActionsRecord_Click);
            // 
            // menuActionsPlayback
            // 
            this.menuActionsPlayback.Index = 11;
            this.menuActionsPlayback.Text = "&Play a Previously Recorded Conference...";
            this.menuActionsPlayback.Click += new System.EventHandler(this.menuActionsPlayback_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 12;
            this.menuItem6.Text = "-";
            // 
            // menuActionsUnicast
            // 
            this.menuActionsUnicast.Index = 13;
            this.menuActionsUnicast.Text = "Start a Two-Way Unicast Conference...";
            this.menuActionsUnicast.Click += new System.EventHandler(this.menuActionsUnicast_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 2;
            this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuHelpConferenceXP,
            this.menuHelpPresentation,
            this.menuHelpCommunity,
            this.menuItem3,
            this.menuHelpAbout});
            this.menuItem5.Text = "&Help";
            // 
            // menuHelpConferenceXP
            // 
            this.menuHelpConferenceXP.Index = 0;
            this.menuHelpConferenceXP.Text = "&ConferenceXP Help";
            this.menuHelpConferenceXP.Click += new System.EventHandler(this.menuHelpConferenceXP_Click);
            // 
            // menuHelpPresentation
            // 
            this.menuHelpPresentation.Index = 1;
            this.menuHelpPresentation.Text = "&Presentation Help";
            this.menuHelpPresentation.Click += new System.EventHandler(this.menuHelpPresentation_Click);
            // 
            // menuHelpCommunity
            // 
            this.menuHelpCommunity.Index = 2;
            this.menuHelpCommunity.Text = "Community &Site";
            this.menuHelpCommunity.Click += new System.EventHandler(this.menuHelpCommunity_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 3;
            this.menuItem3.Text = "-";
            // 
            // menuHelpAbout
            // 
            this.menuHelpAbout.Index = 4;
            this.menuHelpAbout.Text = "&About ConferenceXP Client";
            this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            this.toolTip.ShowAlways = true;
            // 
            // statusBarTimer
            // 
            this.statusBarTimer.Interval = 750;
            this.statusBarTimer.Tick += new System.EventHandler(this.statusBarTimer_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.actionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(364, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.audioVideoToolStripMenuItem,
            this.servicesToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.settingsToolStripMenuItem.Text = "&Settings";
            // 
            // audioVideoToolStripMenuItem
            // 
            this.audioVideoToolStripMenuItem.Name = "audioVideoToolStripMenuItem";
            this.audioVideoToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.audioVideoToolStripMenuItem.Text = "Audio/Video...";
            this.audioVideoToolStripMenuItem.Click += new System.EventHandler(this.menuSettingsAudioVideo2_Click);
            // 
            // servicesToolStripMenuItem
            // 
            this.servicesToolStripMenuItem.Name = "servicesToolStripMenuItem";
            this.servicesToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.servicesToolStripMenuItem.Text = "Services...";
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startPresentationToolStripMenuItem,
            this.startChatToolStripMenuItem,
            this.startWindowsMediaPlaybackToolStripMenuItem,
            this.startLocalScreenStreamingToolStripMenuItem,
            this.startSharedBrowserToolStripMenuItem,
            this.startClassroomPresenterToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.actionsToolStripMenuItem.Text = "&Actions";
            // 
            // startPresentationToolStripMenuItem
            // 
            this.startPresentationToolStripMenuItem.Name = "startPresentationToolStripMenuItem";
            this.startPresentationToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.startPresentationToolStripMenuItem.Text = "Start Presentation";
            // 
            // startChatToolStripMenuItem
            // 
            this.startChatToolStripMenuItem.Name = "startChatToolStripMenuItem";
            this.startChatToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.startChatToolStripMenuItem.Text = "Start Chat";
            // 
            // startWindowsMediaPlaybackToolStripMenuItem
            // 
            this.startWindowsMediaPlaybackToolStripMenuItem.Name = "startWindowsMediaPlaybackToolStripMenuItem";
            this.startWindowsMediaPlaybackToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.startWindowsMediaPlaybackToolStripMenuItem.Text = "Start Windows Media Playback...";
            // 
            // startLocalScreenStreamingToolStripMenuItem
            // 
            this.startLocalScreenStreamingToolStripMenuItem.Name = "startLocalScreenStreamingToolStripMenuItem";
            this.startLocalScreenStreamingToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.startLocalScreenStreamingToolStripMenuItem.Text = "Start Local Screen Streaming";
            this.startLocalScreenStreamingToolStripMenuItem.Click += new System.EventHandler(this.menuActionsScreenScraper_Click);
            // 
            // startSharedBrowserToolStripMenuItem
            // 
            this.startSharedBrowserToolStripMenuItem.Name = "startSharedBrowserToolStripMenuItem";
            this.startSharedBrowserToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.startSharedBrowserToolStripMenuItem.Text = "Start Shared Browser";
            // 
            // startClassroomPresenterToolStripMenuItem
            // 
            this.startClassroomPresenterToolStripMenuItem.Name = "startClassroomPresenterToolStripMenuItem";
            this.startClassroomPresenterToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.startClassroomPresenterToolStripMenuItem.Text = "Start Classroom Presenter";
            // 
            // FMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(364, 422);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.btnLeaveConference);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Menu = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(160, 240);
            this.Name = "FMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "00";
            this.Text = "eduGRID - Virtual Classroom";
            this.Resize += new System.EventHandler(this.FMain_Resize);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FMain_Closing);
            this.Load += new System.EventHandler(this.FMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        #region Statics

        const int archiverUnicastPort = 7004; // the default port to do a unicast playback on

        private const string helpurlCommunity = "http://research.microsoft.com/conferencexp/";
        private const string helpurlConferenceXP = "http://research.microsoft.com/conferencexp/redirects/cxp_client/gettingstartedwithconferencexp.htm";
        private const string helpurlStudentEdition = "http://research.microsoft.com/conferencexp/redirects/cxp_client/conferencexpstudentedition.htm";
        private const string helpurlPresentation = "http://research.microsoft.com/conferencexp/redirects/cxp_client/usingpresentation.htm";
        internal const string helpurlConnectivity = "http://research.microsoft.com/conferencexp/redirects/cxp_client/connectivitydetector.htm";
        internal const string helpurlServices = "http://research.microsoft.com/conferencexp/redirects/cxp_client/conferencexpservices.htm";
        internal const string helpurlNotification = "http://research.microsoft.com/conferencexp/redirects/services/archiveservice.htm";

        private static ArgumentParser arguments = null;
        private static bool bStudentMode = false;
        private static bool recordNotify = true;

        private static bool autoPlayRemoteAudio = true;
        private static bool autoPlayRemoteVideo = true;

        internal static bool AutoPlayRemoteAudio
        {
            get { return autoPlayRemoteAudio; }
            set
            {
                autoPlayRemoteAudio = value;
                AVReg.WriteValue(AVReg.RootKey, AVReg.AutoPlayRemoteAudio, value);
            }
        }

        internal static bool AutoPlayRemoteVideo
        {
            get { return autoPlayRemoteVideo; }
            set
            {
                autoPlayRemoteVideo = value;
                AVReg.WriteValue(AVReg.RootKey, AVReg.AutoPlayRemoteVideo, value);
            }
        }


        const string venueServiceSuffix = "/venueservice.asmx";

        static RegistryKey baseRegKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft Research\ConferenceXP\Client\" +
            System.Reflection.Assembly.GetExecutingAssembly().CodeBase);

        // Specify all registry keys in one place
        static RegistryKey cxpclientRegKey = baseRegKey.CreateSubKey("CXPClient");
        static RegistryKey rtdocsRegKey = baseRegKey.CreateSubKey("CapabilityViewers");
        static RegistryKey venuesRegKey = baseRegKey.CreateSubKey("VenueService");
        static RegistryKey reflectorsRegKey = baseRegKey.CreateSubKey("ReflectorService");
        static RegistryKey archiversRegKey = baseRegKey.CreateSubKey("ArchiveService");

        public static IPAddress remoteIP = null;

        [STAThread]
        static void Main(string[] args)
        {
            // Name the UI thread, so it is more easily identified during debugging
            Thread.CurrentThread.Name = "CXPClient UI";

            // Parse the command line arguments
            arguments = new ArgumentParser(args); // Must keep this around so Parameters doesn't go out of scope
            InvokeSettingsArguments(arguments.Parameters);
            UnhandledExceptionHandler.Register();

            Application.EnableVisualStyles();
            Application.Run(new FMain());
        }

        public static void InvokeSettingsArguments()
        {
            arguments = new ArgumentParser(new string[0]);
            InvokeSettingsArguments(arguments.Parameters);
        }

        private static void InvokeSettingsArguments(StringDictionary parameters)
        {
            #region Set LocalParticipant Properties
            // Note: this must be done before the static Conference.ctor is called, hence it is first
            if (parameters.ContainsKey("email") || parameters.ContainsKey("e"))
            {
                string email = parameters["email"];
                if (parameters.ContainsKey("e"))
                {
                    email = parameters["e"];
                }

                // Cannot cleanly do this because the participant properties are read only and the only ctor takes a VenueParticipant...
                // Need a clean way to change these properties on LocalParticipant...
                //Participant p = Conference.LocalParticipant;
                //p.Email = parameters["email"];
                //Conference.LocalParticipant = p;
                MSR.LST.ConferenceXP.Identity.Identifier = email;
            }
            if (parameters.ContainsKey("name") || parameters.ContainsKey("n"))
            {
                string name = parameters["name"];
                if (parameters.ContainsKey("n"))
                {
                    name = parameters["n"];
                }
                //Participant p = Conference.LocalParticipant;
                //p.Name = parameters["name"];
                //Conference.LocalParticipant = p;
                throw new NotImplementedException();
            }
            #endregion
            #region Set Venue Server
            if (parameters.ContainsKey("venueservice") || parameters.ContainsKey("vs"))
            {
                string venueService = parameters["venueservice"];
                if (parameters.ContainsKey("vs"))
                {
                    venueService = parameters["vs"];
                }

                venueService = venueService.ToLower();

                if (venueService == "none")
                {
                    VenueServiceBaseUrl = null;
                }
                else
                {
                    VenueServiceBaseUrl = venueService;
                    venuesRegKey.SetValue(VenueServiceBaseUrl, "false");
                }
            }

            #endregion
            #region Set Behavior Properties

            if (parameters.ContainsKey("autoplaylocal"))
            {
                Conference.AutoPlayLocal = true;
            }
            if (parameters.ContainsKey("autoplayremote"))
            {
                Conference.AutoPlayRemote = true;
            }

            #endregion
            #region Disable Recording Notification
            if (parameters.ContainsKey("recordnotify") || parameters.ContainsKey("rn"))
            {
                string notify = parameters["recordnotify"];
                if (notify == null)
                {
                    notify = parameters["rn"];
                }

                recordNotify = bool.Parse(notify);
            }
            #endregion
        }


        #endregion Statics

        #region Members

        // Used to reference from a Device MenuItem to the Device, due to the lack of MenuItem.Tag
        public Hashtable deviceMenuItems = new Hashtable(3);
        private Hashtable contextMenuItems = new Hashtable(3);
        private Hashtable menuItemTags = new Hashtable();
        private frmStopLight stoplight = null;
        private string archiveServiceDefault = null;
        private IArchiveServer archiver;
        private ArchiverState archiverState = ArchiverState.Stopped;
        private bool twoWayUnicast = false;

        #endregion Members

        #region Handle command line startup
        private void InvokeActionArguments(StringDictionary parameters)
        {
            #region Show Help
            if (parameters.ContainsKey("help"))
            {
                MessageBox.Show(
                    "  By using one or more command line parameters, you can specify or change\n" +
                    "  ConferenceXP configuration options. The name of venues and capabilities\n" +
                    "  are case sensitive. For a venue or capability name that includes a space,\n" +
                    "  use quotation marks around the name.\n" +
                    "  \n" +
                    "  -help\t\t\t\tView help\n" +
                    "  \n" +
                    "  -venue VenueName\t\tJoin a venue\n" +
                    "  -v VenueName\n" +
                    "  \n" +
                    "  -capability CapabilityName\t\tStart a capability\n" +
                    "  -c CapabilityName\n" +
                    "  \n" +
                    "  -venueservice http://server/web \t\tSpecify a different Venue Service\n" +
                    "  -vs http://server/web\n" +
                    "  \n" +
                    "  -venueservice none\t\tUse no Venue Service\n" +
                    "  -vs none\n" +
                    "  \n" +
                    "  -ip x.x.x.x -port xxxx\t\tJoin a custom venue\n" +
                    "  \n" +
                    "  -recordnotify false\t\t\tDisable Recording Notification\n" +
                    "  -rn false\n" +
                    "  \n" +
                    "  -email name@domain.org\t\tSpecify a different identifier\n" +
                    "  -e name@domain.org", "ConferenceXP Command Line Parameters");
                return;
            }
            #endregion
            #region Join Venue
            if (parameters.ContainsKey("venue") || parameters.ContainsKey("v"))
            {
                string venueName = parameters["venue"];
                if (parameters.ContainsKey("v"))
                {
                    venueName = parameters["v"];
                }

                if (!Conference.VenueServiceWrapper.Venues.ContainsKey(venueName))
                {
                    string dialogText = "Available venues are:\n\n";
                    foreach (Venue v in Conference.VenueServiceWrapper.Venues)
                    {
                        dialogText += "  " + v.Name + "\n";
                    }
                    MessageBox.Show(dialogText, "Venue '" + venueName + "' not found.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
                }
                Conference.JoinVenue(Conference.VenueServiceWrapper.Venues[venueName]);
                AutoSendAV();
            }
            if (parameters.ContainsKey("ip"))
            {
                if (parameters.ContainsKey("port"))
                {
                    VenueData vd = new VenueData("Custom Venue",
                        new IPEndPoint(IPAddress.Parse(parameters["ip"]),
                        int.Parse(parameters["port"])), 127, VenueType.Custom,
                        null, null, null);
                    Venue v = Conference.VenueServiceWrapper.AddCustomVenue(vd);
                    Conference.JoinVenue(v);
                    AutoSendAV();
                }
                else
                {
                    MessageBox.Show("If you specify the -ip parameter, you must also specify the -port parameter.");
                }
            }
            #endregion
            #region Play Capability
            if (parameters.ContainsKey("capability") || parameters.ContainsKey("c"))
            {
                if (Conference.ActiveVenue == null)
                {
                    MessageBox.Show("If you specify -capability, you must also specify -venue");
                }

                string capabilityName = parameters["capability"];
                if (parameters.ContainsKey("c"))
                {
                    capabilityName = parameters["c"];
                }

                ArrayList alOtherCapabilitySenders = new ArrayList(Conference.OtherCapabilitySenders);
                if (alOtherCapabilitySenders.Contains(capabilityName))
                {
                    ICapabilitySender cs = Conference.CreateCapabilitySender(capabilityName);
                }
                else
                {
                    string dialogText = "Available OtherCapabilitySenders are:\n\n";
                    foreach (string s in Conference.OtherCapabilitySenders)
                    {
                        dialogText += "  " + s + "\n";
                    }
                    dialogText += "\n\nNote that Capability names are case sensitive.";
                    MessageBox.Show(dialogText, "CapabilitySender '" + capabilityName + "' not found.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
                }
            }
            #endregion
        }
        #endregion

        #region CTor / Dispose
        public FMain()
        {
            InitializeComponent();
            archiver = null;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }

            }
            base.Dispose(disposing);
        }
        #endregion

        #region UI Tasks

        private void FMain_Load(object sender, System.EventArgs e)
        {
            // display Recording Notification
            if (!System.Diagnostics.Debugger.IsAttached && recordNotify)
            {
                frmNotification notification = new frmNotification();
                notification.ShowDialog();
            }

            Cursor = Cursors.AppStarting;

            // Hook up this form to ConferenceAPI so it knows where to post back Events so they occur on the form thread.
            DisplayStatusInProgress("Loading ConferenceAPI.");

            Conference.CallingForm = this;

            // Set the default Conferencing behavior
            Conference.AutoPlayLocal = true;
            Conference.AutoPlayRemote = true;
            Conference.AutoPosition = Conference.AutoPositionMode.FourWay;

            // Hook the Conference events to this form's events
            Conference.ParticipantAdded += new Conference.ParticipantAddedEventHandler(OnParticipantAdded);
            Conference.ParticipantRemoved += new Conference.ParticipantRemovedEventHandler(OnParticipantRemoved);
            Conference.CapabilityAdded += new CapabilityAddedEventHandler(OnCapabilityAdded);
            Conference.CapabilityRemoved += new CapabilityRemovedEventHandler(OnCapabilityRemoved);
            Conference.DuplicateIdentityDetected += new Conference.DuplicateIdentityDetectedEventHandler(OnDuplicateIdentityDetected);

            // Make use of the internal socket exceptions to determine network status
            RtpEvents.HiddenSocketException += new RtpEvents.HiddenSocketExceptionEventHandler(HiddenSockExHandler);

            #region Load Settings from Registry
            try
            {
                // Load the form location settings from the registry
                object val;

                if ((val = cxpclientRegKey.GetValue("Top")) != null)
                {
                    this.Top = Convert.ToInt32(val);
                }
                else
                {
                    this.Top = SystemInformation.WorkingArea.Top;
                }

                if ((val = cxpclientRegKey.GetValue("Left")) != null)
                {
                    this.Left = Convert.ToInt32(val);
                }
                else
                {
                    this.Left = SystemInformation.WorkingArea.Right - this.Width;
                }

                if ((val = cxpclientRegKey.GetValue("Width")) != null)
                {
                    this.Width = Convert.ToInt32(val);
                }

                if ((val = cxpclientRegKey.GetValue("Height")) != null)
                {
                    this.Height = Convert.ToInt32(val);
                }

                if ((val = cxpclientRegKey.GetValue("AutoPlayRemote")) != null)
                {
                    Conference.AutoPlayRemote = Convert.ToBoolean(val);
                }

                if ((val = cxpclientRegKey.GetValue("AutoPlayLocal")) != null)
                {
                    Conference.AutoPlayLocal = Convert.ToBoolean(val);
                }

                if ((val = AVReg.ReadValue(AVReg.RootKey, AVReg.AutoPlayRemoteAudio)) != null)
                {
                    autoPlayRemoteAudio = bool.Parse((string)val);
                }

                if ((val = AVReg.ReadValue(AVReg.RootKey, AVReg.AutoPlayRemoteVideo)) != null)
                {
                    autoPlayRemoteVideo = bool.Parse((string)val);
                }

                if ((val = cxpclientRegKey.GetValue("AutoPosition")) != null)
                {
                    Conference.AutoPosition = (Conference.AutoPositionMode)Enum.Parse(Conference.AutoPosition.GetType(), val.ToString());
                }
            }
            catch
            {
                // Set the default location of the form to the top right corner of the working area
                this.Top = SystemInformation.WorkingArea.Top;
                this.Left = SystemInformation.WorkingArea.Right - this.Width;
                // Width and Height defaults are set by the development environment
            }
            #endregion

            #region Set RTDocs Viewers, Services, and Check for Student Mode
            DisplayRTDocumentViewers();

            // Pre-populate Archive service if there are no entries in the registry and one is specified in app.config
            string setting = null;
            if (archiversRegKey.ValueCount == 0)
            {
                string asKey = "MSR.LST.ConferenceXP.ArchiveService";
                if ((setting = ConfigurationManager.AppSettings[asKey]) != null)
                {
                    archiversRegKey.SetValue(setting, "False");
                }

                // The next entry in the app.config starts with the postfix 2
                // i.e. - MSR.LST.ConferenceXP.ArchiveService2
                int postfix = 2;

                while ((setting = ConfigurationManager.AppSettings[asKey + postfix]) != null)
                {
                    archiversRegKey.SetValue(setting, "False");
                    postfix++; // Move to the next entry
                }
            }

            // Pre-populate Reflector service if there are no entries in the 
            // registry and one (or more) is specified in app.config
            // Disabled by default
            if (reflectorsRegKey.ValueCount == 0)
            {
                string rsKey = "MSR.LST.ConferenceXP.ReflectorService";

                if ((setting = ConfigurationManager.AppSettings[rsKey]) != null)
                {
                    reflectorsRegKey.SetValue(setting, "False");
                }

                // The next entry in the app.config starts with the postfix 2
                // i.e. - MSR.LST.ConferenceXP.ReflectorService2
                int postfix = 2;

                while ((setting = ConfigurationManager.AppSettings[rsKey + postfix]) != null)
                {
                    reflectorsRegKey.SetValue(setting, "False");
                    postfix++; // Move to the next entry
                }
            }

            // Check if student mode has been configured, and disable appropriate menus if needed           
            setting = ConfigurationManager.AppSettings["MSR.LST.ConferenceXP.StudentMode"];
            bStudentMode = (setting != null && bool.Parse(setting));

            if (bStudentMode)
            {
                // Disable menu settings
                menuActions.Visible = false;
                menuSettingsAudioVideo2.Visible = false;
                menuSettingsServices.Visible = false;
                menuSettingsNetworkDiagnostics.Visible = false;
                menuSettingsNetworkDiagnostics.Visible = false;
                menuMyProfile.Visible = false;
            }
            else
            {
                DisplayStatusInProgress("Loading Venues.");
                InitVenueService();
                GetArchiveService();
                SetReflectorService();
                DisplayOtherCapabilitySenders();
                SetDefaultDevices();
            }
            #endregion

            InvokeActionArguments(arguments.Parameters);

            if (bStudentMode && Conference.ActiveVenue == null)
            {
                // Create a custom venue and enter it
                JoinVenue(AddLocalVenue(), false);
            }

            // Auto-start the connectivity detector, if it's set to
            setting = ConfigurationManager.AppSettings["MSR.LST.Net.ConnectivityDetector.AutoStart"];
            if (setting != null && bool.Parse(setting))
            {
                stoplight = new frmStopLight();
            }

            // Detect whether or not the UW Classroom Presenter Capability has been installed, and if so, display it on the Actions menu
            ArrayList alCapabilitySenders = new ArrayList(Conference.OtherCapabilitySenders);
            if (alCapabilitySenders.Contains("Classroom Presenter"))
            {
                menuActionsUWClassroomPresenter.Visible = true;
            }

            // A venue may already be entered by command line parameters
            if (Conference.ActiveVenue == null)
            {
                DisplayVenues();
            }
            else
            {
                InVenueUIState();
            }

            Cursor = Cursors.Default;
        }

        private void FMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                // Check to see if we are minimized, and if so, restore before saving settings
                // Otherwise when relaunching, the form will "appear" off screen
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;
                }

                // Save the Form position information to the registry
                cxpclientRegKey.SetValue("Top", this.Top);
                cxpclientRegKey.SetValue("Left", this.Left);
                cxpclientRegKey.SetValue("Width", this.Width);
                cxpclientRegKey.SetValue("Height", this.Height);

                cxpclientRegKey.Flush();
            }
            catch { }

            if (this.btnLeaveConference.Visible)
            {
                this.btnLeaveConference.PerformClick();
            }

            try
            {
                if (stoplight != null)
                {
                    stoplight.Dispose();
                }
            }
            catch { }
        }

        private void FMain_Resize(object sender, System.EventArgs e)
        {
            return;
            if (Conference.ActiveVenue == null)
            {
                listView.Height = this.ClientSize.Height - this.statusBar.Height;
                listView.Top = 0;
            }
            else
            {
                listView.Height = this.ClientSize.Height - this.btnLeaveConference.Height - this.statusBar.Height;
                listView.Top = this.btnLeaveConference.Bottom;
            }
        }

        private void JoinVenue(Venue venueToJoin, bool sendAV)
        {
            listView.Items.Clear();
            imageList.Images.Clear();
            toolTip.RemoveAll();

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Conference.JoinVenue(venueToJoin);

                if (sendAV) // in unicast archive playback, we don't want to send AV
                    AutoSendAV();

                InVenueUIState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error occured joining venue", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Button is not visible, so we can't call the .PerformClick() method, but we need to
                // leave the conference anyhow to clean up properly.
                btnLeaveConference_Click(this, null);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void InVenueUIState()
        {
            this.Text = ' ' + Conference.ActiveVenue.Name + " - ConferenceXP";

            this.FMain_Resize(this, EventArgs.Empty);

            menuMyProfile.Enabled = false;

            SetArchiverMenuStatus();

            menuActionsPresentation.Enabled = true;
            menuSettingsServices.Enabled = false;
            menuSettingsAudioVideo2.Enabled = false;
            menuActionsChat.Enabled = true;
            menuActionsWMPlayback.Enabled = true;
            menuActionsScreenScraper.Enabled = true;
            menuActionsSharedBrowser.Enabled = true;
            menuActionsUWClassroomPresenter.Enabled = true;

            if (menuActionsCapabilities.MenuItems.Count > 0)
            {
                menuActionsCapabilities.Enabled = true;
            }
            else
            {
                menuActionsCapabilities.Enabled = false;
            }

            menuActionsActiveCapabilities.Enabled = false;
            menuActionsUnicast.Enabled = false;

            // Only allow one to leave the venue if we are not in student mode
            if (!bStudentMode)
            {
                btnLeaveConference.Visible = true;
            }
            DisplayParticipantCount();
        }


        /// <summary>
        /// This should only be executed during the first run.
        /// To make sure it is the first run, we look for reg keys of selected
        /// devices and if they aren't there we create them for the first 
        /// device of each type
        /// </summary>
        private void SetDefaultDevices()
        {
            string[] regSelectedMics = AVReg.ValueNames(AVReg.SelectedMicrophone);
            string[] regSelectedCameras = AVReg.ValueNames(AVReg.SelectedCameras);

            // Null means the key doesn't exist
            if (regSelectedMics == null && regSelectedCameras == null)
            {
                FilterInfo[] mics = AudioSource.Sources();
                FilterInfo[] cameras = VideoSource.Sources();

                if (mics.Length > 0 && cameras.Length > 0)
                {
                    // Select the first device of each type and link them
                    AVReg.WriteValue(AVReg.SelectedMicrophone, mics[0].Moniker, mics[0].Name);
                    AVReg.WriteValue(AVReg.SelectedCameras, cameras[0].Moniker, cameras[0].Name);
                    AVReg.WriteValue(AVReg.LinkedCamera, cameras[0].Moniker, cameras[0].Name);
                }
            }
        }

        private void AutoSendAV()
        {
            // Determine if the form is shared
            string[] linkedCamera = AVReg.ValueNames(AVReg.LinkedCamera);
            if (linkedCamera != null)
            {
                Debug.Assert(linkedCamera.Length <= 1);
            }

            // Create the audio capability
            FilterInfo[] mics = AudioCapability.SelectedMicrophones();
            Debug.Assert(mics.Length <= 1);  // For now we only support 1

            AudioCapability ac = null;
            foreach (FilterInfo fi in mics)
            {
                ac = new AudioCapability(fi);
            }

            // Create the video capabilities and start sending their data
            foreach (FilterInfo fi in VideoCapability.SelectedCameras())
            {
                VideoCapability vc = new VideoCapability(fi);

                // Set the shared form ID
                if (ac != null && linkedCamera != null && linkedCamera.Length > 0)
                {
                    if (fi.Moniker == linkedCamera[0])
                    {
                        Guid sharedFormID = Guid.NewGuid();
                        ac.SharedFormID = sharedFormID;
                        vc.SharedFormID = sharedFormID;
                    }
                }

                try
                {
                    vc.ActivateCamera();
                    vc.Send();
                }
                catch (Exception)
                {
                    vc.Dispose();

                    MessageBox.Show(string.Format("ConferenceXP was unable to send video from " +
                        "the device - {0}.  See the ConferenceAPI Event Log for details.", vc.Name),
                        "Unable to send video", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Start sending the audio data
            try
            {
                if (ac != null)
                {
                    ac.ActivateMicrophone();
                    ac.Send();
                }
            }
            catch (Exception)
            {
                ac.Dispose();

                MessageBox.Show(string.Format("ConferenceXP was unable to send audio from " +
                    "the device - {0}.  See the ConferenceAPI Event Log for details.", ac.Name),
                    "Unable to send audio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Gets and sets the venue service URL from Conference, adding and removing the venueServiceSuffix as necessary.
        /// </summary>
        static string VenueServiceBaseUrl
        {
            get
            {
                string url = Conference.VenueServiceWrapper.VenueServiceUrl;
                if (url == null)
                    return null;
                else
                    return url.Substring(0, url.Length - venueServiceSuffix.Length);
            }
            set
            {
                try
                {
                    if (value != null)
                        Conference.SetVenueServiceUrl(value + venueServiceSuffix);
                    else
                        Conference.SetVenueServiceUrl(null);
                }
                catch (UriFormatException)
                {
                    MessageBox.Show(string.Format(
                        "The Universal Resource Identifier supplied for the "
                        + "Venue Service is improperly formatted.\r\nOne example "
                        + "of such a formatting error is trying to connect to "
                        + "an IPv6 address without enabling IPv6 support on the "
                        + "local machine.\r\nThe address you supplied is: {0}", 
                        value), "Invalid Venue Service URI",                        
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // The address provided was improperly formatted, get back to a clean state
                    VenueServiceBaseUrl = null;
                }

                // Always show a local venue
                AddLocalVenue();
            }
        }


        private void InitVenueService()
        {
            // If we set a venue service via the command-line, we don't need to do this
            if (arguments.Parameters.ContainsKey("venueservice") || arguments.Parameters.ContainsKey("vs"))
                return;

            // Check to see if any new Venue Services were added to the app.config
            // If so, the first new one will be the one returned (app.config wins)
            string vs = AddVenueServicesFromAppConfig();

            if (vs == null) // Nothing new in app.config
            {
                // Check registry
                string[] names = venuesRegKey.GetValueNames();
                foreach (string key in names)
                {
                    if (bool.Parse((string)venuesRegKey.GetValue(key)))
                    {
                        vs = key;
                        break;
                    }
                }

                Debug.Assert(vs != null, "Why isn't there a venue service selected?");
            }

            VenueServiceBaseUrl = vs; // retries the venue service, and creates a local venue if necessary
        }

        /// <summary>
        /// Adds a new venue service from the app.config to the list of VSs in the registry
        /// If there is one or more new VSs in the app.config, we will activate 
        /// and return the first one.
        /// </summary>
        private static string AddVenueServicesFromAppConfig()
        {
            string vsKey = "MSR.LST.ConferenceXP.VenueService";
            string newVS = null;

            // Check to see if the default venue service has changed
            string setting;
            if ((setting = ConfigurationManager.AppSettings[vsKey]) != null)
            {
                ProcessVenueService(setting, ref newVS);
            }

            // The next entry in the app.config starts with the postfix 2
            // i.e. - MSR.LST.ConferenceXP.VenueService2
            int postfix = 2;

            while ((setting = ConfigurationManager.AppSettings[vsKey + postfix]) != null)
            {
                ProcessVenueService(setting, ref newVS);

                postfix++; // Move to the next entry
            }

            return newVS;
        }

        private static void ProcessVenueService(string setting, ref string newVS)
        {
            // Trim off suffix, if it has one
            if (setting.EndsWith(venueServiceSuffix))
            {
                setting = setting.Substring(0, setting.Length - venueServiceSuffix.Length);
            }

            // If it's not already in the registry...
            if (venuesRegKey.GetValue(setting) == null)
            {
                if (newVS == null)
                {
                    // This is a new entry, clear old entries
                    string[] names = venuesRegKey.GetValueNames();
                    foreach (string key in names)
                    {
                        venuesRegKey.SetValue(key, false);
                    }

                    // Set new value in registry and return it in newVS
                    venuesRegKey.SetValue(setting, true);
                    newVS = setting;
                }
                else
                {
                    venuesRegKey.SetValue(setting, false);
                }
            }
        }

        private void DisplayVenues()
        {
            this.FMain_Resize(this, EventArgs.Empty);

            listView.Items.Clear();
            imageList.Images.Clear();
            toolTip.RemoveAll();
            int cnt = 0;

            // This set of code may be causing a very long delay in showing the UI...
            Cursor prevCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            // Check that the version is good
            if (!Conference.VenueServiceWrapper.VersionIsCompatible)
            {
                MessageBox.Show(this, Conference.VenueServiceWrapper.VersionError,
                    "Version Incompatible", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                VenueServiceBaseUrl = null;
            }

            foreach (Venue v in Conference.VenueServiceWrapper.Venues)
            {
                // Add the venue to the list
                imageList.Images.Add(GenerateThumbnail48(v.Icon));

                ListViewItem i = new ListViewItem();
                i.Text = v.Name;
                i.Tag = v;
                i.ImageIndex = cnt++;
                listView.Items.Add(i);
            }
            Cursor.Current = prevCursor;

            menuMyProfile.Enabled = true;
            menuActionsCapabilities.Enabled = false;

            menuActionsPresentation.Enabled = false;
            menuActionsChat.Enabled = false;
            menuActionsWMPlayback.Enabled = false;
            menuActionsScreenScraper.Enabled = false;
            menuActionsSharedBrowser.Enabled = false;
            menuActionsUWClassroomPresenter.Enabled = false;
            menuActionsCapabilities.Enabled = false;
            menuActionsActiveCapabilities.Enabled = false;
            menuActionsUnicast.Enabled = true;
            menuSettingsServices.Enabled = true;
            menuSettingsAudioVideo2.Enabled = true;
            menuSettingsRTDocViewer.Enabled = true;

            SetArchiverMenuStatus();
            DisplayVenueStatus();
        }

        /// <summary>
        /// Find the default venue service in the registry and use it as the current VS.
        /// </summary>
        private void SetVenueService()
        {
            string currentVenue = VenueServiceBaseUrl;

            // Check to see if a new venue service has been selected
            string[] names = venuesRegKey.GetValueNames();
            string venueService = null;
            foreach (string venue in names)
            {
                string venueState = (string)venuesRegKey.GetValue(venue);
                if (Boolean.Parse(venueState))
                {
                    venueService = venue;
                    break;
                }
            }

            if (currentVenue != venueService)
            {
                VenueServiceBaseUrl = venueService;
                DisplayVenues();
            }
        }

        /// <summary>
        /// Create a custom Local venue. The TTL parameter doesn't matter since currently the only way to overide the default of ttl=255 is through app.config
        /// </summary>
        private static Venue AddLocalVenue()
        {
            if (!Conference.VenueServiceWrapper.Venues.ContainsKey("Local Venue"))
            {
                VenueData vd = new VenueData("Local Venue",
                    new IPEndPoint(IPAddress.Parse("234.9.8.7"), 5004), 255, VenueType.Custom, null);

                Conference.VenueServiceWrapper.AddCustomVenue(vd);
            }

            return Conference.VenueServiceWrapper.Venues["Local Venue"];
        }
        private void DisplayRTDocumentViewers()
        {
            string[] names = rtdocsRegKey.GetValueNames();
            foreach (string key in names)
            {
                MenuItem mi = new MenuItem(key, new EventHandler(RTDocsViewerClick));

                // check the one marked as default
                object val = rtdocsRegKey.GetValue(key);
                if (val.ToString() == "default")
                {
                    mi.Checked = true;
                }

                menuSettingsRTDocViewer.MenuItems.Add(mi);
            }
        }

        private void GetArchiveService()
        {
            // Get list of registered archivers, and select the one that is enabled, if any
            string[] keys = archiversRegKey.GetValueNames();
            archiveServiceDefault = null;

            // Find the default Archive Service, if there is one
            if (keys != null)
            {
                foreach (string key in keys)
                {
                    // See whether or not it is enabled based on the value of the key/value pair
                    if (bool.Parse((string)archiversRegKey.GetValue(key)))
                    {
                        archiveServiceDefault = key;
                        break;
                    }
                }
            }

            // If we found a default, use it
            if (archiveServiceDefault != null)
            {
                archiverState = ArchiverState.Stopped;
                GetNewArchiver();
            }
            else
            {
                archiverState = ArchiverState.Unavailable;
                // Disable the archiver menu
                SetArchiverMenuStatus();
            }
        }

        /// <summary>
        /// Creates a new IArchiveServer object to make remote calls to.
        /// </summary>
        internal void GetNewArchiver()
        {
            if (archiveServiceDefault != null)
            {
                try
                {
                    object factoryObj = Activator.GetObject(typeof(IArchiveServer), GetArchiveUri() + "/ArchiveServer");
                    this.archiver = (IArchiveServer)factoryObj;
                }
                catch (Exception ex)
                {
                    archiverState = ArchiverState.Unavailable;
                    MessageBox.Show(this,
                        "The Archive Service is currently unavailable\n" +
                        "or may have encountered an unexpected error.\n" +
                        "Please contact your server's administrator.\n\nException:\n" + ex.ToString(),
                        "Archive Service Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            SetArchiverMenuStatus();
        }

        /// <summary>
        /// Add "tcp://" prefix as well as port postfix if needed 
        /// </summary>
        /// <returns>formatted URI</returns>
        private string GetArchiveUri()
        {
            if (archiveServiceDefault == null)
                return null;

            string archiverUri = archiveServiceDefault;

            // Add the tcp:// prefix to the ArchiveService address if it needs it
            if (!archiverUri.StartsWith("tcp://"))
            {
                archiverUri = "tcp://" + archiverUri;
            }

            // Add port postfix, if needed
            if (archiverUri.IndexOf(':', 4) < 4)
            {
                archiverUri += ":8082"; // NOTE: hardcoded default port here
            }

            return archiverUri;
        }

        /// <summary>
        /// Accessor to enable/disable the playback menu
        /// </summary>
        internal bool EnableMenuActionsPlayback
        {
            set
            {
                menuActionsPlayback.Enabled = value;
            }
        }

        /// <summary>
        /// Accessor to enable/disable the record menu
        /// </summary>
        internal bool EnableMenuActionsRecord
        {
            set
            {
                menuActionsRecord.Enabled = value;
            }
        }

        internal void SetArchiverMenuStatus()
        {
            if ((archiveServiceDefault != null) && (!twoWayUnicast))
            {
                if (archiverState == ArchiverState.Unavailable)
                {
                    menuActionsRecord.Enabled = false;
                    menuActionsPlayback.Enabled = false;
                }
                else
                {
                    if (Conference.ActiveVenue == null)
                    {
                        menuActionsRecord.Enabled = false;
                        menuActionsPlayback.Enabled = true;

                        if (archiverState == ArchiverState.Playing)
                        {
                            menuActionsPlayback.Enabled = false;
                        }
                    }
                    else
                    {
                        menuActionsRecord.Enabled = true;
                        menuActionsPlayback.Enabled = true;

                        // TODO: Combine these to if statements since thy set the
                        //       same value
                        if (archiverState == ArchiverState.Playing)
                        {
                            menuActionsRecord.Enabled = false;
                            menuActionsPlayback.Enabled = false;
                        }
                        else if (archiverState == ArchiverState.Recording)
                        {
                            menuActionsPlayback.Enabled = false;
                            menuActionsRecord.Enabled = false;
                        }
                    }
                }
            }
            else // There is no default archive service
            {
                menuActionsPlayback.Enabled = false;
                menuActionsRecord.Enabled = false;
            }
        }

        private void SetReflectorService()
        {
            // Check to see if any reflector is marked as enabled (True)
            string[] keys = reflectorsRegKey.GetValueNames();
            string reflectorDefault = null;

            // Find the default reflector service, if there is one
            if (keys != null)
            {
                DisplayVenueStatus(); // We display venue service in the status bar when reflector is not enabled

                foreach (string key in keys)
                {
                    // See whether or not it is enabled (based on the value of the key/value pair)
                    if (bool.Parse((string)reflectorsRegKey.GetValue(key)))
                    {
                        reflectorDefault = key;
                    }
                }
            }

            Conference.ReflectorEnabled = false;

            // If we found a default, use it
            if (reflectorDefault != null)
            {
                Uri reflectorUri = MSR.LST.ConferenceXP.frmServices2.ValidateUri(reflectorDefault);
                if (reflectorUri != null)
                {
                    // NOTE: hardcoded default port here
                    // The Uri parser defaults the Port number property to 0 (invalid port number) or -1 in case the specified port is not parsable.
                    Conference.ReflectorJoinPort = reflectorUri.Port > 0 ? reflectorUri.Port : 8083;
                    Conference.ReflectorAddress = reflectorUri.Host;
                    Conference.ReflectorEnabled = true;
                }
            }

            // Update the status bar 
            DisplayVenueStatus();
        }

        private void DisplayOtherCapabilitySenders()
        {
            menuActionsCapabilities.MenuItems.Clear();
            foreach (string s in Conference.OtherCapabilitySenders)
            {
                if (s != "Presentation" && s != "Chat" && s != "Windows Media Playback" && s != "Local Screen Streaming"
                    && s != "Shared Browser" && s != "Classroom Presenter")
                {
                    MenuItem mi = new MenuItem("Start " + s + "...", new EventHandler(OtherCapabilitySenderClick));
                    menuActionsCapabilities.MenuItems.Add(mi);
                }
            }
        }

        private void UpdateActionMenu()
        {
            menuActionsActiveCapabilities.MenuItems.Clear();

            foreach (ICapabilityViewer cv in Conference.CapabilityViewers.Values)
            {
                // Skip the CapabilityViewers associated with a participant
                if (cv.Owner != null)
                {
                    continue;
                }
                MenuItem mi = new MenuItem(cv.Name, new EventHandler(ActiveCapabilityClick));
                if (cv.IsPlaying == true)
                {
                    mi.Checked = true;
                }
                else
                {
                    mi.Checked = false;
                }

                menuActionsActiveCapabilities.MenuItems.Add(mi);
                menuItemTags.Add(mi, cv);
            }

            if (menuActionsActiveCapabilities.MenuItems.Count > 0)
            {
                menuActionsActiveCapabilities.Enabled = true;
            }
            else
            {
                menuActionsActiveCapabilities.Enabled = false;
            }
        }


        private void RefreshImages()
        {
            for (int i = 0; i < listView.Items.Count; i++)
            {
                listView.Items[i].ImageIndex = i;
                imageList.Images[i] = GenerateThumbnail48(((Participant)listView.Items[i].Tag).DecoratedIcon);
            }
            listView.Refresh();
        }

        private Image GenerateThumbnail48(Image masterImage)
        {
            Bitmap icon = new Bitmap(48, 48, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            using (Graphics g = Graphics.FromImage(icon))
            {
                g.FillRectangle(new SolidBrush(listView.BackColor), 0, 0, 48, 48);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(masterImage, 0, 0, 48, 48);
            }
            return icon;
        }

        #endregion

        #region ConferenceAPI Event Handlers

        private void OnParticipantAdded(IParticipant p)
        {
            if (Conference.ActiveVenue != null) // We may have already left the venue and this is coming in late because it's invoked on the form thread and comes in via the message loop
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = p.Name;
                lvi.Tag = p;
                //toolTip.SetToolTip(lvi, p.ToString());
                listView.Items.Add(lvi);
                imageList.Images.Add(p.DecoratedIcon);
                RefreshImages();
                DisplayParticipantCount();
            }
        }

        private void OnParticipantRemoved(IParticipant p)
        {
            if (Conference.ActiveVenue != null) // We may have already left the venue and this is coming in late because it's invoked on the form thread and comes in via the message loop
            {
                // Remove the receiver participant from the list
                foreach (ListViewItem lvi in listView.Items)
                {
                    if (lvi.Tag == p)
                    {
                        imageList.Images.RemoveAt(lvi.Index);
                        listView.Items.Remove(lvi);
                    }
                }

                RefreshImages();
                DisplayParticipantCount();
            }
        }

        private void OnCapabilityAdded(object conference, CapabilityEventArgs cea)
        {
            if (Conference.ActiveVenue != null) // We may have already left the venue and this is coming in late because it's invoked on the form thread and comes in via the message loop
            {
                RefreshImages();

                if (cea.Capability is AudioCapability)
                {
                    ((AudioCapability)cea.Capability).AutoPlayRemote = AutoPlayRemoteAudio;
                }

                if (cea.Capability is VideoCapability)
                {
                    ((VideoCapability)cea.Capability).AutoPlayRemote = AutoPlayRemoteVideo;
                }
            }
        }

        private void OnCapabilityRemoved(object conference, CapabilityEventArgs cea)
        {
            if (Conference.ActiveVenue != null) // We may have already left the venue and this is coming in late because it's invoked on the form thread and comes in via the message loop
            {
                RefreshImages();
            }
        }

        private void HiddenSockExHandler(object session, RtpEvents.HiddenSocketExceptionEventArgs hseea)
        {
            if (Conference.ActiveVenue != null && hseea.Session == Conference.RtpSession)
            {
                btnLeaveConference.PerformClick();

                MessageBox.Show(this, "Your internet connection no longer appears to be working.  Please check your internet connection.",
                    "SocketException", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnDuplicateIdentityDetected(object conference, Conference.DuplicateIdentityDetectedEventArgs ea)
        {
            btnLeaveConference.PerformClick();

            MessageBox.Show(this, string.Format("You exited the venue because a participant with " +
                "your same name joined the venue from a different IP address - {0}, {1}",
                ea.IPAddresses[0].ToString(), ea.IPAddresses[1].ToString()));
        }

        #endregion

        #region Menu Handlers

        #region Settings menu
        private void menuSettingsAudioVideo2_Click(object sender, System.EventArgs e)
        {
            new frmAVDevices(cxpclientRegKey).ShowDialog();
        }

        private void menuSettingsNetworkDiagnostics_Click(object sender, System.EventArgs e)
        {
            if (stoplight != null)
            {
                stoplight.Dispose();
            }

            // Create a new one each time
            stoplight = new frmStopLight();
            stoplight.WindowState = FormWindowState.Normal;
            stoplight.Show();
        }

        private void menuSettingsServices_Click(object sender, System.EventArgs e)
        {
            frmServices services = new frmServices(venuesRegKey, archiversRegKey, reflectorsRegKey);
            if (services.ShowDialog() == DialogResult.OK)
            {
                SetVenueService();
                GetArchiveService();
                SetReflectorService();
            }

        }

        private void menuSettingsAppConfig_Click(object sender, System.EventArgs e)
        {
            // This is *really* cheap, but hey, it works!
            Process.Start("notepad.exe", Process.GetCurrentProcess().ProcessName + ".exe.config");
        }

        private void menuMyProfile_Click(object sender, System.EventArgs e)
        {
            Conference.EditProfileUI();
        }

        private void RTDocsViewerClick(object o, EventArgs ea)
        {
            MenuItem mi = (MenuItem)o;
            if (mi.Checked == true) { } // do nothing
            else
            {
                // Reset all the devices to false and check new default
                foreach (MenuItem miSib in mi.Parent.MenuItems)
                {
                    miSib.Checked = false;
                }
                mi.Checked = true;

                // Update registry with new default and set others to non-default
                string[] names = rtdocsRegKey.GetValueNames();
                foreach (string key in names)
                {
                    rtdocsRegKey.SetValue(key, "non-default");
                }
                rtdocsRegKey.SetValue(mi.Text, "default");

                // Tell user this takes effect next time the client starts
                MessageBox.Show(this,
                    "You have selected " + mi.Text + ". This change will take effect \n" +
                    "the next time you start ConferenceXP.",
                    "Presentation Viewer Change", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Actions menu
        private void menuActions_Select(object sender, System.EventArgs e)
        {
            if (Conference.VenueServiceWrapper.Venues != null)
            {
                UpdateActionMenu();
            }
        }

        private void menuActionsPresentation_Click(object sender, System.EventArgs e)
        {
            ICapabilitySender cs = Conference.CreateCapabilitySender("Presentation");
        }

        private void menuActionsChat_Click(object sender, System.EventArgs e)
        {
            ICapabilitySender cs = Conference.CreateCapabilitySender("Chat");
        }

        private void menuActionsWMPlayback_Click(object sender, System.EventArgs e)
        {
            ICapabilitySender cs = Conference.CreateCapabilitySender("Windows Media Playback");
        }

        private void menuActionsScreenScraper_Click(object sender, System.EventArgs e)
        {
            ICapabilitySender cs = Conference.CreateCapabilitySender("Local Screen Streaming");
        }

        private void menuActionsSharedBrowser_Click(object sender, System.EventArgs e)
        {
            ICapabilitySender cs = Conference.CreateCapabilitySender("Shared Browser");
        }

        private void menuActionsUWClassroomPresenter_Click(object sender, System.EventArgs e)
        {
            ICapabilitySender cs = Conference.CreateCapabilitySender("Classroom Presenter");
        }

        private void ActiveCapabilityClick(object o, EventArgs ea)
        {
            MenuItem mi = (MenuItem)o;
            ICapabilityViewer cv = (ICapabilityViewer)menuItemTags[mi];

            try
            {
                if (mi.Checked)
                {
                    // Stop sending as well if this cv is also an ICapabilitySender
                    if (cv is ICapabilitySender)
                    {
                        ((ICapabilitySender)cv).StopSending();
                    }

                    cv.StopPlaying();
                    mi.Checked = false;
                }
                else
                {
                    //Pri2: We want to check for success here and notify the user if a failure occurs?
                    cv.Play();
                    mi.Checked = true;
                }
                UpdateActionMenu();
            }
            catch (ObjectDisposedException)
            {
                // If a channel capability is accessed after it has been closed, but before the BYE
                // packet is received we may try to access the capability after it has been
                // disposed.
            }

        }

        private void OtherCapabilitySenderClick(object o, EventArgs ea)
        {
            MenuItem mi = (MenuItem)o;
            string name = mi.Text.Substring(6);
            name = name.Remove(name.Length - 3, 3);

            ICapabilitySender cs = Conference.CreateCapabilitySender(name);
        }

        /// <summary>
        /// menuActionsRecord Click event handler. Open the record dialog box.
        /// </summary>
        /// <param name="sender">The event sender object</param>
        /// <param name="e">The event arguments</param>
        private void menuActionsRecord_Click(object sender, System.EventArgs e)
        {
            frmRecord record = new frmRecord(this);
            record.Show();
            record.Location = new Point(
                SystemInformation.WorkingArea.Right - record.Width,
                SystemInformation.WorkingArea.Bottom - record.Height);


            // TODO: FYI: I removed code to change cursor:
            //       Begining: this.Cursor = Cursors.WaitCursor;
            //       End: this.Cursor = Cursors.Default;
            //       Check if this code needs to be added again
        }

        /// <summary>
        /// Find a playback venue to join.
        /// </summary>
        /// <returns>The venue</returns>
        private Venue GetPlayBackVenue()
        {
            Venue playbackVenue;

            // Check to make sure we aren't playing back from our machine to our machine
            Uri archiverUri = new Uri(GetArchiveUri());
            if (archiverUri.IsLoopback)
            {
                // In the odd case that we're trying to play back from a local archiver, do a multicast playback
                //  (becasue unicast isn't technically possible), in a random venue
                playbackVenue = Conference.VenueServiceWrapper.CreateRandomMulticastVenue("Playback Venue", null);
            }
            else
            {
                // Get the Archiver's IPAddress
                IPHostEntry archiverHE = Dns.GetHostEntry(archiverUri.Host);
                IPAddress archiverIP = archiverHE.AddressList[0];

                // Get the port to playback on
                int playbackPort = archiverUnicastPort;
                string portOverrideStr = ConfigurationManager.AppSettings["MSR.LST.ConferenceXP.ArchiveService.UnicastPort"];
                if (portOverrideStr != null)
                    playbackPort = Int32.Parse(portOverrideStr);

                // Join to the Archiver's IPAddress as a "venue"
                VenueData ven = new VenueData("Playback Venue", new IPEndPoint(archiverIP, playbackPort), ushort.MaxValue,
                    VenueType.PrivateVenue, null);
                playbackVenue = Conference.VenueServiceWrapper.AddCustomVenue(ven);
            }
            return playbackVenue;
        }

        /// <summary>
        /// Display the playback info in the status bar
        /// </summary>
        private void DisplayPlayBackInfo(ArchiveService.Conference selectedConference)
        {
            MSR.LST.ConferenceXP.ArchiveService.Conference conf = selectedConference;

            // TODO: Put Debug.Assert instead of if ( conf != null )
            if (conf != null)
            {
                DisplayStatusMessage("Playback of conference: " + conf.Description);
            }
        }

        private void menuActionsPlayback_Click(object sender, System.EventArgs e)
        {
            // Create and show the play back dialog box to select a conference
            // to play back
            // Note: we pass a reference to FMain form in the ctor so the created form
            //       can communicate with FMain

            if (sender != this && (this.archiverState == ArchiverState.Stopped))
            {
                GetNewArchiver();
                frmArchiveConf client = new frmArchiveConf(this.archiver, this);
                if (!client.IsDisposed)
                {
                    client.Show();
                    client.Location = new Point(
                        SystemInformation.WorkingArea.Right - client.Width,
                        SystemInformation.WorkingArea.Bottom - client.Height);

                }
            }
            else if (sender != this && this.archiverState == ArchiverState.Playing)
            {
                StopPlayBack();
            }
        }

        private void menuActionsUnicast_Click(object sender, System.EventArgs e)
        {
            frmNetworkUnicast unicastSession = new frmNetworkUnicast();
            if (unicastSession.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    VenueData vd = new VenueData("Unicast Venue", new System.Net.IPEndPoint(remoteIP, Convert.ToInt32("5004")), 127, VenueType.Custom, null, null, null);
                    Venue v = Conference.VenueServiceWrapper.AddCustomVenue(vd);
                    JoinVenue(v, true);
                    twoWayUnicast = true;
                    SetArchiverMenuStatus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    twoWayUnicast = false;
                    SetArchiverMenuStatus();
                }
            }
        }
        #endregion

        #region Help menu

        private void menuHelpAbout_Click(object sender, System.EventArgs e)
        {
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(Application.ExecutablePath);

            MessageBox.Show(
                "ConferenceXP Client\n" +
                "Microsoft Research\n\n" +
                "Acknowledgements:\nJay Beavers, Patrick Bristow, Tim Chou, Sauleh Eetemadi,\n" +
                "Chris Moffatt, Michel Pahud, Lynn Powers, Jason Van Eaton\n\n" +
                "CXP Client : " + fvi.FileVersion + "\n" +
                Conference.About + "\n\n" +
                "For more information, see http://research.microsoft.com/conferencexp/",
                "About ConferenceXP Client");
        }

        private void menuHelpCommunity_Click(object sender, System.EventArgs e)
        {
            Process.Start(helpurlCommunity);
        }

        private void menuHelpConferenceXP_Click(object sender, System.EventArgs e)
        {
            if (bStudentMode)
            {
                Process.Start(helpurlStudentEdition);
            }
            else
            {
                Process.Start(helpurlConferenceXP);
            }
        }

        private void menuHelpPresentation_Click(object sender, System.EventArgs e)
        {
            Process.Start(helpurlPresentation);
        }


        # endregion

        #endregion Menu handlers

        #region Context handlers
        private void listView_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Point clientCoords = listView.PointToClient(Cursor.Position);
            ListViewItem lvi = listView.GetItemAt(clientCoords.X, clientCoords.Y);
            string toolTipString = "";

            if (lvi != null)
            {
                if (lvi.Tag is Participant)
                {
                    Participant p = (Participant)lvi.Tag;

                    // rtpParticpant can be null if the participant is leaving
                    if (p.RtpParticipant != null)
                    {
                        toolTipString =
                            "Name: " + p.Name + "\n" +
                            "Identifier: " + p.Identifier + "\n" +
                            "IP Address: " + p.RtpParticipant.IPAddress + "\n" +
                            "Email Address: " + p.Email + "\n\n" +
                            "CapabilityViewers:\n";

                        foreach (ICapabilityViewer cv in p.Capabilities)
                        {
                            toolTipString += cv.PayloadType + ": " + cv.Name;
                            if (cv.IsPlaying)
                            {
                                toolTipString += " Playing";
                            }
                            toolTipString += "\n";
                        }
                    }
                }
                if (lvi.Tag is Venue)
                {
                    Venue v = (Venue)lvi.Tag;

                    if (v.VenueData.VenueType == VenueType.Invalid)
                    {
                        toolTipString = "Venue Not Available";
                    }
                    else
                    {
                        toolTipString = "Enter the " + v.Name + " Venue" + "\n\n" +
                            "Identifier: " + v.Identifier + "\n" +
                            "IP Address: " + v.EndPoint.Address.ToString() + "\n" +
                            "Port: " + v.EndPoint.Port;
                    }

                }
            }

            if (toolTip.GetToolTip(listView) != toolTipString)
                toolTip.SetToolTip(listView, toolTipString);
        }


        private void contextParticipant_Popup(object sender, System.EventArgs e)
        {
            //Point clientCoords = listView.PointToClient(Cursor.Position);
            //ListViewItem lvi = listView.GetItemAt(clientCoords.X, clientCoords.Y);
            if (listView.SelectedItems.Count == 0)
            {
                contextParticipant.MenuItems.Clear();
                return;
            }

            ListViewItem lvi = listView.SelectedItems[0];

            contextParticipant.MenuItems.Clear();

            if (lvi.Tag is Participant)
            {
                Participant p = (Participant)lvi.Tag;

                foreach (ICapabilityViewer cv in p.Capabilities)
                {
                    string menuText;
                    if (cv.IsPlaying)
                        menuText = "Stop " + cv.Name + " " + cv.PayloadType.ToString();
                    else
                        menuText = "Play " + cv.Name + " " + cv.PayloadType.ToString();

                    MenuItem mi = new MenuItem(menuText, new EventHandler(OnParticipantContextClick));
                    contextMenuItems.Add(mi, cv);
                    contextParticipant.MenuItems.Add(mi);
                }

                if (lvi.Tag is Venue)
                    return;
            }
        }


        private void OnParticipantContextClick(object sender, System.EventArgs e)
        {
            ICapabilityViewer cv = (ICapabilityViewer)contextMenuItems[sender];

            try
            {
                // Toggle the cv
                if (cv.IsPlaying)
                {
                    cv.StopPlaying();
                }
                else
                {
                    //Pri2: We want to check the result here and notify the user upon failure instead of fail silently

                    cv.Play();
                }
            }
            catch (ObjectDisposedException)
            {
                // If the context menu for a participant is selected before a capability for that
                // participant goes away, we may try to access the capability after it has been
                // disposed.
            }
        }

        internal void LeaveConference()
        {
            this.DisplayStatusInProgress("Leaving conference.");

            Cursor.Current = Cursors.WaitCursor;

            // Stop recording or playing
            if (archiverState == ArchiverState.Recording)
            {
                StopRecording();
            }
            else if (archiverState == ArchiverState.Playing)
            {
                StopPlayBack();
            }

            twoWayUnicast = false;
            SetArchiverMenuStatus();

            if (Conference.ActiveVenue != null)
            {
                Conference.LeaveVenue();

                // If we just leaft a unicast venue, then remove it
                foreach (Venue v in Conference.VenueServiceWrapper.Venues)
                {
                    if (v.Name.StartsWith("Unicast") || v.Name.StartsWith("Playback"))
                    {
                        Conference.VenueServiceWrapper.Venues.Remove(v.Name);
                        break;
                    }
                }
            }

            btnLeaveConference.Visible = false;

            listView.Enabled = true;

            this.Text = " ConferenceXP";

            DisplayVenues();

            Cursor.Current = Cursors.Default;
        }

        private void btnLeaveConference_Click(object sender, System.EventArgs e)
        {
            LeaveConference();
        }


        private void listView_ItemActivate(object sender, System.EventArgs e)
        {
            // because there is no locking to prevent the listView.SelectedItems from being cleared
            //  before this call, we have to expect the worst.  Note: this was added because I was
            //  seeing exceptions being thrown on this line in rare cases
            ListViewItem lvi;
            try
            {
                lvi = (ListViewItem)listView.SelectedItems[0];
            }
            catch
            {
                return;
            }

            if (lvi.Tag is Venue)
            {
                if (((Venue)lvi.Tag).VenueData.VenueType == VenueType.Invalid)
                {
                    MessageBox.Show(this, "This computer does not support the address protocol of this venue.\n" +
                        "To join an IPv6 venue, see ConferenceXP Help.",
                        "Venue Join Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.DisplayStatusInProgress("Joining venue.");
                    JoinVenue((Venue)lvi.Tag, true);
                }
            }
        }

        #endregion

        #region Status Bar Utilities
        /// <summary>Keeps something moving on the UI while a task is occuring, to prevent 
        /// the user from expecting the application is hung</summary>
        private void DisplayStatusInProgress(string message)
        {
            statusBarTimer.Stop();
            statusBar.Text = message;
            statusBar.Font = new Font(statusBar.Font, FontStyle.Bold);
            statusBarTimer.Interval = 750;
            statusBarTimer.Start();
        }

        private void DisplayParticipantCount()
        {
            statusBarTimer.Stop();

            // TODO: Is the code I commented below really useful??
            //       In any case, I am not checking/unchecking the menu anymore, so
            //       if we need this code we need to implement it differently (i.e. member var)
            // During playback we just want to display the "Playing back..." message.
            // if( menuActionsPlayback.Checked )
            //   return;

            // Attempt to check and update participant count.
            // Throw away exception if Conference.ActiveVenue becomes null (i.e. leaving venue)
            try
            {
                int numParticipants = Conference.Participants.Length;
                DisplayStatusMessage("Participants: " + numParticipants);
            }
            catch { };

            statusBar.Font = new Font(statusBar.Font, FontStyle.Regular);
        }

        // Displays static status
        private void DisplayStatusMessage(string message)
        {
            statusBarTimer.Stop();
            statusBar.Font = new Font(statusBar.Font, FontStyle.Regular);
            statusBar.Text = message;
        }

        private void DisplayVenueStatus()
        {
            statusBarTimer.Stop();
            statusBar.Font = new Font(statusBar.Font, FontStyle.Regular);

            if (Conference.ReflectorEnabled)
            {
                statusBar.Text = "Reflector enabled (Unicast Mode): " + Conference.ReflectorAddress;
            }
            else
            {
                statusBar.Text = "Venue Service: " + VenueServiceBaseUrl;
            }
        }

        private void statusBarTimer_Tick(object sender, EventArgs e)
        {
            string text = statusBar.Text;
            if (text.EndsWith("...."))
                statusBar.Text = text.Remove(text.Length - 3, 3);
            else
                statusBar.Text += ".";
        }
        #endregion

        #region Internal

        /// <summary>
        /// Allows the UI to get the archiver state.
        /// </summary>
        /// <example>
        /// Used when the user move the play back slider to ensure
        /// we jump in the archive only if the archive is still playing
        /// </example>
        internal ArchiverState GetArchiverState
        {
            get
            {
                return archiverState;
            }
        }

        /// <summary>
        /// Start a new recording of a conference.
        /// </summary>
        /// <param name="ConferenceName">Name of the recorded conference</param>
        internal void StartRecording(string ConferenceName)
        {
            if (this.archiverState == ArchiverState.Stopped)
            {
                GetNewArchiver();
                archiver.Record(ConferenceName, Conference.ActiveVenue.Name, Conference.ActiveVenue.EndPoint);
                this.archiverState = ArchiverState.Recording;
            }

            SetArchiverMenuStatus();
        }

        /// <summary>
        /// Stop the current recording.
        /// </summary>
        internal void StopRecording()
        {
            try
            {
                if (this.archiverState == ArchiverState.Recording)
                {
                    if (archiver != null && Conference.ActiveVenue != null)
                    {
                        int refs = archiver.StopRecording(Conference.ActiveVenue.EndPoint);
                        archiver = null;

                        if (refs > 0)
                        {
                            MessageBox.Show(this, "Recording will continue, as other participants have requested this recording as well."
                                + "\n  When the recording participant leaves, recording has stopped.",
                                "Recording not stopped.");
                        }
                        else if (refs == 0)
                        {
                            MessageBox.Show(this,
                                "Recording has stopped. To ensure proper playback after the initial recording, make sure \n"
                                + "all participants leave the venue before choosing to play back the recording.",
                                "Recording Stopped", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else // refs < 0 (i.e. error)
                        {
                            MessageBox.Show(this, "Warning: Recording was already stopped!  Either there was an error on the server, or the"
                                + "\n venue had been empty for some amount of time and recording automatically stopped.",
                                "Recording stopped prematurely.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    this.archiverState = ArchiverState.Stopped;
                }
            }
            catch (Exception ex)
            {
                archiverState = ArchiverState.Stopped;

                MessageBox.Show(this,
                    "The Archive Service is currently unavailable\n" +
                    "or may have encountered an unexpected error.\n" +
                    "Please contact your server's administrator.\n\nException:\n" + ex.ToString(),
                    "Archive Service Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            SetArchiverMenuStatus();
        }

        /// <summary>
        /// Play back an archive in the appropriate venue
        /// </summary>
        /// <param name="Streams">Streams ID to play back</param>
        /// <param name="selectedConference">Selected Conference</param>
        /// <returns>The IP adress where the archive is played back</returns>
        internal System.Net.IPEndPoint PlayArchive(int[] streams, ArchiveService.Conference selectedConference)
        {
            // TODO: Move PlayArchive out of BarUI

            // IP adresse where the archive is played back
            System.Net.IPEndPoint archivePlayBackIP = null;

            // TODO: Make sure we cannot get to an infinite loop by removing test on sender
            // if ( sender != this && (this.archiverState == ArchiverState.Stopped) )

            if (this.archiverState == ArchiverState.Stopped)
            {
                if (Conference.ActiveVenue == null) // Join a venue to playback to (generally unicast)
                {
                    // We've established a venue to join to, so do it
                    JoinVenue(GetPlayBackVenue(), false);
                }

                // We're definitely in a venue now
                Debug.Assert(Conference.ActiveVenue != null);

                // We're in a venue - playback to it
                if (MSR.LST.Net.Utility.IsMulticast(Conference.ActiveVenue.EndPoint))
                {
                    // Multicast playback - send directly to the multicast group
                    archivePlayBackIP = Conference.ActiveVenue.EndPoint;
                    archiver.Play(Conference.ActiveVenue.EndPoint, streams);
                }
                else
                {
                    // Unicast playback - send data directly to the local IP
                    archivePlayBackIP = new IPEndPoint(Conference.RtpSession.MulticastInterface,
                        Conference.ActiveVenue.EndPoint.Port);
                    archiver.Play(archivePlayBackIP, streams);
                }

                DisplayPlayBackInfo(selectedConference);

                this.archiverState = ArchiverState.Playing;
            }

            SetArchiverMenuStatus();
            return archivePlayBackIP;
        }

        /// <summary>
        /// Stop the playback.
        /// </summary>
        internal void StopPlayBack()
        {
            if (archiver != null && Conference.ActiveVenue != null)
            {
                IPEndPoint remoteVenue; // find the remote venue, which is different from out venue in unicast playback
                if (MSR.LST.Net.Utility.IsMulticast(Conference.ActiveVenue.EndPoint))
                {
                    remoteVenue = Conference.ActiveVenue.EndPoint;
                }
                else
                {
                    remoteVenue = new IPEndPoint(Conference.RtpSession.MulticastInterface,
                        Conference.ActiveVenue.EndPoint.Port);
                }

                archiver.StopPlaying(remoteVenue);
                archiver = null;
            }

            this.archiverState = ArchiverState.Stopped;

            // Reset the status message to participants
            this.DisplayParticipantCount();
        }

        #endregion Internal
    }
}