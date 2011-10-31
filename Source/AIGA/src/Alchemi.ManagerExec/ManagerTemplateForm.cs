#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	ManagerTemplateForm.cs
* Project		:	Alchemi Manager 
* Created on	:	2005
* Copyright		:	Copyright © 2005 The University of Melbourne
*					This technology has been developed with the support of 
*					the Australian Research Council and the University of Melbourne
*					research grants as part of the Gridbus Project
*					within GRIDS Laboratory at the University of Melbourne, Australia.
* Author         :  Krishna Nadiminti (kna@csse.unimelb.edu.au) and Rajkumar Buyya (raj@csse.unimelb.edu.au)
* License        :  GPL
*					This program is free software; you can redistribute it and/or 
*					modify it under the terms of the GNU General Public
*					License as published by the Free Software Foundation;
*					See the GNU General Public License 
*					(http://www.gnu.org/copyleft/gpl.html) for more details.
*
*/ 
#endregion

using System;
using System.ComponentModel;
using System.Reflection;
using System.ServiceProcess;
using System.Threading;
using System.Windows.Forms;
using Alchemi.Core;
using Alchemi.Core.Manager;
using Alchemi.ManagerExec;
using Alchemi.Manager;

	public class ManagerTemplateForm : Form
	{
		protected Button btStart;
		protected IContainer components;
		protected TextBox txLog;
		protected TextBox txOwnPort;
		protected TextBox txManagerHost;
		protected TextBox txManagerPort;
		protected TextBox txId;
		protected CheckBox cbIntermediate;
		protected Button btStop;
		protected Button btReset;
		protected CheckBox cbDedicated;
		protected NotifyIcon TrayIcon;
		protected ContextMenu TrayMenu;
		protected MenuItem tmExit;
		protected MainMenu MainMenu;
		protected MenuItem mmExit;
		protected TextBox txDbPassword;
		protected TextBox txDbUsername;
		protected TextBox txDbServer;
		protected TextBox txDbName;
		protected MenuItem mmAbout;

		protected ManagerContainer _container = null;
		protected Configuration Config = null;
		protected static readonly Logger logger = new Logger();

		protected StatusBar statusBar;
		protected TabPage tabPage1;
		protected ProgressBar pbar;
		
		protected System.Windows.Forms.MenuItem miManager;
		protected System.Windows.Forms.MenuItem miHelp;
		protected System.Windows.Forms.TabControl tabControl;
		protected System.Windows.Forms.Label lbMgrHost;
		protected System.Windows.Forms.Label lbOwnPort;
		protected System.Windows.Forms.GroupBox gpBoxNodeConfig;
		protected System.Windows.Forms.Label lbId;
		protected System.Windows.Forms.Label lbMgrPort;
		protected System.Windows.Forms.GroupBox gpBoxLog;
		protected System.Windows.Forms.Label lbDBPassword;
		protected System.Windows.Forms.Label lbDBUsername;
		protected System.Windows.Forms.Label lbDBServer;
		protected System.Windows.Forms.Label lbDBName;
		protected System.Windows.Forms.GroupBox gpBoxDB;
		protected System.Windows.Forms.GroupBox gpBoxActions;

		public ManagerTemplateForm()
		{
			InitializeComponent();
			ManagerContainer.ManagerStartEvent += new ManagerStartStatusEventHandler(this.Manager_StartStatusEvent);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ManagerTemplateForm));
			this.lbMgrHost = new System.Windows.Forms.Label();
			this.lbOwnPort = new System.Windows.Forms.Label();
			this.txManagerHost = new System.Windows.Forms.TextBox();
			this.txOwnPort = new System.Windows.Forms.TextBox();
			this.btStart = new System.Windows.Forms.Button();
			this.gpBoxNodeConfig = new System.Windows.Forms.GroupBox();
			this.cbDedicated = new System.Windows.Forms.CheckBox();
			this.lbId = new System.Windows.Forms.Label();
			this.cbIntermediate = new System.Windows.Forms.CheckBox();
			this.txId = new System.Windows.Forms.TextBox();
			this.lbMgrPort = new System.Windows.Forms.Label();
			this.txManagerPort = new System.Windows.Forms.TextBox();
			this.btReset = new System.Windows.Forms.Button();
			this.btStop = new System.Windows.Forms.Button();
			this.gpBoxLog = new System.Windows.Forms.GroupBox();
			this.txLog = new System.Windows.Forms.TextBox();
			this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.TrayMenu = new System.Windows.Forms.ContextMenu();
			this.tmExit = new System.Windows.Forms.MenuItem();
			this.MainMenu = new System.Windows.Forms.MainMenu();
			this.miManager = new System.Windows.Forms.MenuItem();
			this.mmExit = new System.Windows.Forms.MenuItem();
			this.miHelp = new System.Windows.Forms.MenuItem();
			this.mmAbout = new System.Windows.Forms.MenuItem();
			this.lbDBPassword = new System.Windows.Forms.Label();
			this.txDbPassword = new System.Windows.Forms.TextBox();
			this.lbDBUsername = new System.Windows.Forms.Label();
			this.txDbUsername = new System.Windows.Forms.TextBox();
			this.lbDBServer = new System.Windows.Forms.Label();
			this.txDbServer = new System.Windows.Forms.TextBox();
			this.lbDBName = new System.Windows.Forms.Label();
			this.txDbName = new System.Windows.Forms.TextBox();
			this.gpBoxDB = new System.Windows.Forms.GroupBox();
			this.gpBoxActions = new System.Windows.Forms.GroupBox();
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.pbar = new System.Windows.Forms.ProgressBar();
			this.gpBoxNodeConfig.SuspendLayout();
			this.gpBoxLog.SuspendLayout();
			this.gpBoxDB.SuspendLayout();
			this.gpBoxActions.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbMgrHost
			// 
			this.lbMgrHost.Location = new System.Drawing.Point(48, 128);
			this.lbMgrHost.Name = "lbMgrHost";
			this.lbMgrHost.Size = new System.Drawing.Size(72, 16);
			this.lbMgrHost.TabIndex = 1;
			this.lbMgrHost.Text = "ManagerHost";
			this.lbMgrHost.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// lbOwnPort
			// 
			this.lbOwnPort.Location = new System.Drawing.Point(72, 24);
			this.lbOwnPort.Name = "lbOwnPort";
			this.lbOwnPort.Size = new System.Drawing.Size(48, 16);
			this.lbOwnPort.TabIndex = 2;
			this.lbOwnPort.Text = "OwnPort";
			this.lbOwnPort.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// txManagerHost
			// 
			this.txManagerHost.Location = new System.Drawing.Point(120, 128);
			this.txManagerHost.Name = "txManagerHost";
			this.txManagerHost.Size = new System.Drawing.Size(104, 20);
			this.txManagerHost.TabIndex = 9;
			this.txManagerHost.Text = "";
			// 
			// txOwnPort
			// 
			this.txOwnPort.Location = new System.Drawing.Point(120, 24);
			this.txOwnPort.Name = "txOwnPort";
			this.txOwnPort.Size = new System.Drawing.Size(104, 20);
			this.txOwnPort.TabIndex = 5;
			this.txOwnPort.Text = "";
			// 
			// btStart
			// 
			this.btStart.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btStart.Location = new System.Drawing.Point(88, 50);
			this.btStart.Name = "btStart";
			this.btStart.Size = new System.Drawing.Size(128, 23);
			this.btStart.TabIndex = 12;
			this.btStart.Text = "Start";
			this.btStart.Click += new System.EventHandler(this.btStart_Click);
			// 
			// gpBoxNodeConfig
			// 
			this.gpBoxNodeConfig.Controls.Add(this.cbDedicated);
			this.gpBoxNodeConfig.Controls.Add(this.lbId);
			this.gpBoxNodeConfig.Controls.Add(this.cbIntermediate);
			this.gpBoxNodeConfig.Controls.Add(this.txId);
			this.gpBoxNodeConfig.Controls.Add(this.lbMgrPort);
			this.gpBoxNodeConfig.Controls.Add(this.txManagerPort);
			this.gpBoxNodeConfig.Controls.Add(this.lbMgrHost);
			this.gpBoxNodeConfig.Controls.Add(this.lbOwnPort);
			this.gpBoxNodeConfig.Controls.Add(this.txOwnPort);
			this.gpBoxNodeConfig.Controls.Add(this.txManagerHost);
			this.gpBoxNodeConfig.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gpBoxNodeConfig.Location = new System.Drawing.Point(8, 99);
			this.gpBoxNodeConfig.Name = "gpBoxNodeConfig";
			this.gpBoxNodeConfig.Size = new System.Drawing.Size(416, 192);
			this.gpBoxNodeConfig.TabIndex = 6;
			this.gpBoxNodeConfig.TabStop = false;
			this.gpBoxNodeConfig.Text = "Node Configuration";
			// 
			// cbDedicated
			// 
			this.cbDedicated.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbDedicated.Location = new System.Drawing.Point(120, 96);
			this.cbDedicated.Name = "cbDedicated";
			this.cbDedicated.Size = new System.Drawing.Size(88, 24);
			this.cbDedicated.TabIndex = 8;
			this.cbDedicated.Text = "Dedicated";
			// 
			// lbId
			// 
			this.lbId.Location = new System.Drawing.Point(96, 72);
			this.lbId.Name = "lbId";
			this.lbId.Size = new System.Drawing.Size(16, 16);
			this.lbId.TabIndex = 12;
			this.lbId.Text = "Id";
			this.lbId.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// cbIntermediate
			// 
			this.cbIntermediate.Enabled = false;
			this.cbIntermediate.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbIntermediate.Location = new System.Drawing.Point(120, 48);
			this.cbIntermediate.Name = "cbIntermediate";
			this.cbIntermediate.Size = new System.Drawing.Size(88, 24);
			this.cbIntermediate.TabIndex = 6;
			this.cbIntermediate.TabStop = false;
			this.cbIntermediate.Text = "Intermediate";
			// 
			// txId
			// 
			this.txId.Enabled = false;
			this.txId.Location = new System.Drawing.Point(120, 72);
			this.txId.Name = "txId";
			this.txId.Size = new System.Drawing.Size(240, 20);
			this.txId.TabIndex = 7;
			this.txId.TabStop = false;
			this.txId.Text = "";
			// 
			// lbMgrPort
			// 
			this.lbMgrPort.Location = new System.Drawing.Point(48, 160);
			this.lbMgrPort.Name = "lbMgrPort";
			this.lbMgrPort.Size = new System.Drawing.Size(72, 16);
			this.lbMgrPort.TabIndex = 6;
			this.lbMgrPort.Text = "ManagerPort";
			this.lbMgrPort.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// txManagerPort
			// 
			this.txManagerPort.Location = new System.Drawing.Point(120, 160);
			this.txManagerPort.Name = "txManagerPort";
			this.txManagerPort.Size = new System.Drawing.Size(104, 20);
			this.txManagerPort.TabIndex = 10;
			this.txManagerPort.Text = "";
			// 
			// btReset
			// 
			this.btReset.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btReset.Location = new System.Drawing.Point(88, 20);
			this.btReset.Name = "btReset";
			this.btReset.Size = new System.Drawing.Size(248, 23);
			this.btReset.TabIndex = 11;
			this.btReset.TabStop = false;
			this.btReset.Text = "Reset";
			this.btReset.Click += new System.EventHandler(this.btReset_Click);
			// 
			// btStop
			// 
			this.btStop.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btStop.Location = new System.Drawing.Point(224, 50);
			this.btStop.Name = "btStop";
			this.btStop.Size = new System.Drawing.Size(112, 23);
			this.btStop.TabIndex = 13;
			this.btStop.Text = "Stop";
			this.btStop.Click += new System.EventHandler(this.btStop_Click);
			// 
			// gpBoxLog
			// 
			this.gpBoxLog.Controls.Add(this.txLog);
			this.gpBoxLog.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gpBoxLog.Location = new System.Drawing.Point(10, 424);
			this.gpBoxLog.Name = "gpBoxLog";
			this.gpBoxLog.Size = new System.Drawing.Size(432, 120);
			this.gpBoxLog.TabIndex = 7;
			this.gpBoxLog.TabStop = false;
			this.gpBoxLog.Text = "Log Messages";
			// 
			// txLog
			// 
			this.txLog.Location = new System.Drawing.Point(8, 16);
			this.txLog.Multiline = true;
			this.txLog.Name = "txLog";
			this.txLog.ReadOnly = true;
			this.txLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txLog.Size = new System.Drawing.Size(416, 96);
			this.txLog.TabIndex = 14;
			this.txLog.TabStop = false;
			this.txLog.Text = "";
			this.txLog.DoubleClick += new System.EventHandler(this.txLog_DoubleClick);
			// 
			// TrayIcon
			// 
			this.TrayIcon.ContextMenu = this.TrayMenu;
			this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
			this.TrayIcon.Text = "Alchemi Manager";
			this.TrayIcon.Visible = true;
			this.TrayIcon.Click += new System.EventHandler(this.TrayIcon_Click);
			// 
			// TrayMenu
			// 
			this.TrayMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.tmExit});
			// 
			// tmExit
			// 
			this.tmExit.Index = 0;
			this.tmExit.Text = "Exit";
			this.tmExit.Click += new System.EventHandler(this.tmExit_Click);
			// 
			// MainMenu
			// 
			this.MainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.miManager,
																					 this.miHelp});
			// 
			// miManager
			// 
			this.miManager.Index = 0;
			this.miManager.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mmExit});
			this.miManager.Text = "Manager";
			// 
			// mmExit
			// 
			this.mmExit.Index = 0;
			this.mmExit.Text = "Exit";
			this.mmExit.Click += new System.EventHandler(this.mmExit_Click);
			// 
			// miHelp
			// 
			this.miHelp.Index = 1;
			this.miHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.mmAbout});
			this.miHelp.Text = "Help";
			// 
			// mmAbout
			// 
			this.mmAbout.Index = 0;
			this.mmAbout.Text = "About";
			this.mmAbout.Click += new System.EventHandler(this.mmAbout_Click);
			// 
			// lbDBPassword
			// 
			this.lbDBPassword.Location = new System.Drawing.Point(176, 56);
			this.lbDBPassword.Name = "lbDBPassword";
			this.lbDBPassword.Size = new System.Drawing.Size(88, 16);
			this.lbDBPassword.TabIndex = 13;
			this.lbDBPassword.Text = "DbPassword";
			this.lbDBPassword.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// txDbPassword
			// 
			this.txDbPassword.Location = new System.Drawing.Point(264, 56);
			this.txDbPassword.Name = "txDbPassword";
			this.txDbPassword.PasswordChar = '*';
			this.txDbPassword.Size = new System.Drawing.Size(104, 20);
			this.txDbPassword.TabIndex = 4;
			this.txDbPassword.Text = "";
			// 
			// lbDBUsername
			// 
			this.lbDBUsername.Location = new System.Drawing.Point(192, 24);
			this.lbDBUsername.Name = "lbDBUsername";
			this.lbDBUsername.Size = new System.Drawing.Size(72, 16);
			this.lbDBUsername.TabIndex = 15;
			this.lbDBUsername.Text = "DbUsername";
			this.lbDBUsername.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// txDbUsername
			// 
			this.txDbUsername.Location = new System.Drawing.Point(264, 24);
			this.txDbUsername.Name = "txDbUsername";
			this.txDbUsername.Size = new System.Drawing.Size(104, 20);
			this.txDbUsername.TabIndex = 3;
			this.txDbUsername.Text = "";
			// 
			// lbDBServer
			// 
			this.lbDBServer.Location = new System.Drawing.Point(16, 24);
			this.lbDBServer.Name = "lbDBServer";
			this.lbDBServer.Size = new System.Drawing.Size(56, 16);
			this.lbDBServer.TabIndex = 17;
			this.lbDBServer.Text = "DbServer";
			this.lbDBServer.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// txDbServer
			// 
			this.txDbServer.Location = new System.Drawing.Point(72, 24);
			this.txDbServer.Name = "txDbServer";
			this.txDbServer.Size = new System.Drawing.Size(104, 20);
			this.txDbServer.TabIndex = 1;
			this.txDbServer.Text = "";
			// 
			// lbDBName
			// 
			this.lbDBName.Location = new System.Drawing.Point(16, 56);
			this.lbDBName.Name = "lbDBName";
			this.lbDBName.Size = new System.Drawing.Size(56, 16);
			this.lbDBName.TabIndex = 19;
			this.lbDBName.Text = "DbName";
			this.lbDBName.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// txDbName
			// 
			this.txDbName.Location = new System.Drawing.Point(72, 56);
			this.txDbName.Name = "txDbName";
			this.txDbName.Size = new System.Drawing.Size(104, 20);
			this.txDbName.TabIndex = 2;
			this.txDbName.Text = "";
			// 
			// gpBoxDB
			// 
			this.gpBoxDB.Controls.Add(this.txDbPassword);
			this.gpBoxDB.Controls.Add(this.lbDBPassword);
			this.gpBoxDB.Controls.Add(this.txDbName);
			this.gpBoxDB.Controls.Add(this.txDbUsername);
			this.gpBoxDB.Controls.Add(this.lbDBName);
			this.gpBoxDB.Controls.Add(this.lbDBServer);
			this.gpBoxDB.Controls.Add(this.lbDBUsername);
			this.gpBoxDB.Controls.Add(this.txDbServer);
			this.gpBoxDB.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gpBoxDB.Location = new System.Drawing.Point(8, 6);
			this.gpBoxDB.Name = "gpBoxDB";
			this.gpBoxDB.Size = new System.Drawing.Size(416, 88);
			this.gpBoxDB.TabIndex = 8;
			this.gpBoxDB.TabStop = false;
			this.gpBoxDB.Text = "Database Configuration";
			// 
			// gpBoxActions
			// 
			this.gpBoxActions.Controls.Add(this.btReset);
			this.gpBoxActions.Controls.Add(this.btStop);
			this.gpBoxActions.Controls.Add(this.btStart);
			this.gpBoxActions.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gpBoxActions.Location = new System.Drawing.Point(8, 295);
			this.gpBoxActions.Name = "gpBoxActions";
			this.gpBoxActions.Size = new System.Drawing.Size(416, 80);
			this.gpBoxActions.TabIndex = 9;
			this.gpBoxActions.TabStop = false;
			this.gpBoxActions.Text = "Actions";
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 557);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(458, 22);
			this.statusBar.TabIndex = 10;
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPage1);
			this.tabControl.Location = new System.Drawing.Point(8, 8);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(440, 408);
			this.tabControl.TabIndex = 12;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.gpBoxDB);
			this.tabPage1.Controls.Add(this.gpBoxNodeConfig);
			this.tabPage1.Controls.Add(this.gpBoxActions);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(432, 382);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Setup Connection";
			// 
			// pbar
			// 
			this.pbar.Location = new System.Drawing.Point(200, 566);
			this.pbar.Name = "pbar";
			this.pbar.Size = new System.Drawing.Size(240, 8);
			this.pbar.Step = 1;
			this.pbar.TabIndex = 13;
			this.pbar.Visible = false;
			// 
			// ManagerTemplateForm
			// 
			this.AcceptButton = this.btStart;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(458, 579);
			this.Controls.Add(this.pbar);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.gpBoxLog);
			this.Controls.Add(this.statusBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Menu = this.MainMenu;
			this.Name = "ManagerTemplateForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Alchemi Manager";
			this.Load += new System.EventHandler(this.ManagerTemplateForm_Load);
			this.gpBoxNodeConfig.ResumeLayout(false);
			this.gpBoxLog.ResumeLayout(false);
			this.gpBoxDB.ResumeLayout(false);
			this.gpBoxActions.ResumeLayout(false);
			this.tabControl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		//-----------------------------------------------------------------------------------------------    
  
		protected Configuration GetConfigFromUI()
		{
			Alchemi.Manager.Configuration conf = new Configuration();

			// HACK: preserve the storage type, this is not displayed on the UI right now.
			conf.DbType = Config.DbType;

			conf.DbServer = txDbServer.Text;
			conf.DbUsername = txDbUsername.Text;
			conf.DbPassword = txDbPassword.Text;
			conf.DbName = txDbName.Text;

			conf.OwnPort = int.Parse(txOwnPort.Text);
			conf.ManagerHost = txManagerHost.Text;
			conf.ManagerPort = int.Parse(txManagerPort.Text);
			conf.Intermediate = cbIntermediate.Checked;
			conf.Dedicated = cbDedicated.Checked;
			conf.Id = txId.Text;

			return conf;
		}

		//-----------------------------------------------------------------------------------------------    
    
		//the children forms have their own load method.
		private void ManagerTemplateForm_Load(object sender, EventArgs e)
		{
			//this should normally not create any problems, but then during design time it doesnt work, so we need to catch any exceptions
			//that may occur during design time.
			try
			{
				AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(DefaultErrorHandler);
				Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

				// avoid multiple instances
				bool isOnlyInstance = false;
				Mutex mtx = new Mutex(true, "AlchemiManager_Mutex", out isOnlyInstance);
				if(!isOnlyInstance)
				{
					MessageBox.Show(this,"An instance of this application is already running. The program will now exit.", "Alchemi Manager", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					Application.Exit();
				}

				RefreshUIControls();
				btStart.Focus();
			}
			catch{}
		}

		protected void RefreshUIControls()
		{
			txDbServer.Text = Config.DbServer;
			txDbUsername.Text = Config.DbUsername;
			txDbPassword.Text = Config.DbPassword;
			txDbName.Text = Config.DbName;
			txOwnPort.Text = Config.OwnPort.ToString();
			cbDedicated.Checked = Config.Dedicated;
			txManagerHost.Text = Config.ManagerHost;
			txManagerPort.Text = Config.ManagerPort.ToString();

			txId.Text = Config.Id;
			cbIntermediate.Checked = Config.Intermediate;
      		
			//dont need to keep calling the property getter...since it queries the status on each call.
			bool started = this.Started;

			btStart.Enabled = !started;
			btReset.Enabled = !started;
			txDbServer.Enabled = !started;
			txDbUsername.Enabled = !started;
			txDbPassword.Enabled = !started;
			txDbName.Enabled = !started;
			txOwnPort.Enabled = !started;
			cbIntermediate.Enabled = false /* !started */; // <-- hierarchical grid disabled for now
			cbDedicated.Enabled = !started & cbIntermediate.Checked;
			txManagerHost.Enabled = !started & cbIntermediate.Checked;
			txManagerPort.Enabled = !started & cbIntermediate.Checked;
			btStop.Enabled = started;

			if (started)
			{
				statusBar.Text = "Manager Started.";
			}
			else
			{
				statusBar.Text = "Manager Stopped.";
			}

			pbar.Hide();
			pbar.Value = 0;
		}
    
		//-----------------------------------------------------------------------------------------------    
    
		private void btStop_Click(object sender, EventArgs e)
		{
			StopManager();
		}

		//-----------------------------------------------------------------------------------------------    
    
		private void btStart_Click(object sender, EventArgs e)
		{
			StartManager();
		}
		
		//-----------------------------------------------------------------------------------------------    

		private void btReset_Click(object sender, EventArgs e)
		{
			ResetManager();
		}

		//-----------------------------------------------------------------------------------------------    

		private void tmExit_Click(object sender, EventArgs e)
		{
			Exit();
		}
    
		//-----------------------------------------------------------------------------------------------    
    
		protected override void WndProc(ref Message m)
		{
			const int WM_SYSCOMMAND = 0x0112;
			const int SC_CLOSE = 0xF060;
			if (m.Msg == WM_SYSCOMMAND & (int) m.WParam == SC_CLOSE)
			{
				// 'x' button clicked .. minimise to system tray
				Hide();
				return;
			}
			base.WndProc(ref m);
		}
    
		//-----------------------------------------------------------------------------------------------    
    
		private void TrayIcon_Click(object sender, EventArgs e)
		{
			Restore();
		}
    
		//-----------------------------------------------------------------------------------------------    
    
		private void Restore()
		{
			this.WindowState = FormWindowState.Normal;
			this.Show();
			this.Activate();
		}

		//-----------------------------------------------------------------------------------------------    

		private void mmExit_Click(object sender, EventArgs e)
		{
			Exit();
		}

		//-----------------------------------------------------------------------------------------------    

		static void DefaultErrorHandler(object sender, UnhandledExceptionEventArgs args)
		{
			Exception e = (Exception) args.ExceptionObject;
			HandleAllUnknownErrors(sender.ToString(),e);
		}

		static void HandleAllUnknownErrors(string sender, Exception e)
		{
			logger.Error("Unknown Error from: " + sender,e);
		}

		//-----------------------------------------------------------------------------------------------    

		private void mmAbout_Click(object sender, EventArgs e)
		{
			new SplashScreen().ShowDialog();
		}

		private void txLog_DoubleClick(object sender, EventArgs e)
		{
			txLog.Clear();
		}

		private void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			HandleAllUnknownErrors(sender.ToString(),e.Exception);
		}
		
		protected void Log(string s)
		{
			if (txLog != null)
			{
				if (txLog.Text.Length + s.Length >= txLog.MaxLength)
				{
					//remove all old stuff except the last 10 lines.
					string[] s1 = new string[10];
					for (int i = 0 ; i < 10 ; i++)
					{
						s1[9-i]=txLog.Lines[txLog.Lines.Length-1-i];
					}
					txLog.Lines = s1;
				}
				txLog.AppendText(s + Environment.NewLine);
			}  
			logger.Info(s);
		}

		    
		public void Manager_StartStatusEvent(string msg, int percentDone)
		{
			statusBar.Text = msg;
			Log(msg);
			if (percentDone==0)
			{
				pbar.Value = 0;
				pbar.Visible = true;
			}
			else if (percentDone >= 100)
			{
				pbar.Value = pbar.Maximum;
				pbar.Visible = false;
			}
			else
			{
				if ((percentDone + pbar.Value) <= pbar.Maximum)
				{
					pbar.Value = percentDone;
				}
				else
				{
					pbar.Value = pbar.Maximum;
				}
			}    	
		}

		#region Methods to be implemented by sub-classes

		//These methods actually should be "abstract", so that the methods are forcibly implemented.
		//but we need the template class to be non-abstract, for designer-support.
		//this is why we have declared these as virtual

		protected virtual void StartManager(){}

		protected virtual void StopManager(){}

		protected virtual void ResetManager(){}

		protected virtual void Exit(){}

		protected virtual bool Started
		{
			get
			{
				throw new NotImplementedException("This property is meant to be implemented by a subclass");
			}
		}
		#endregion

	}