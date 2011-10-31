#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	ManagerMainForm.cs
* Project		:	Alchemi Manager Application
* Created on	:	2003
* Copyright		:	Copyright © 2006 The University of Melbourne
*					This technology has been developed with the support of 
*					the Australian Research Council and the University of Melbourne
*					research grants as part of the Gridbus Project
*					within GRIDS Laboratory at the University of Melbourne, Australia.
* Author         :  Akshay Luther (akshayl@csse.unimelb.edu.au), Rajkumar Buyya (raj@csse.unimelb.edu.au), and Krishna Nadiminti (kna@csse.unimelb.edu.au)
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
using Alchemi.Manager;
using log4net;


// Configure log4net using the .config file
[assembly: log4net.Config.XmlConfigurator(Watch=true)]

namespace Alchemi.ManagerExec
{
	public class ManagerMainForm : ManagerTemplateForm
	{
		public ManagerMainForm():base()
		{
			InitializeComponent();
			this.Text = "Alchemi Manager";
			Logger.LogHandler += new LogEventHandler(LogHandler);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tabPage1.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.gpBoxNodeConfig.SuspendLayout();
			this.gpBoxLog.SuspendLayout();
			this.gpBoxDB.SuspendLayout();
			this.gpBoxActions.SuspendLayout();
			this.SuspendLayout();
			// 
			// btStart
			// 
			this.btStart.Name = "btStart";
			// 
			// txLog
			// 
			this.txLog.Name = "txLog";
			// 
			// txOwnPort
			// 
			this.txOwnPort.Name = "txOwnPort";
			// 
			// txManagerHost
			// 
			this.txManagerHost.Name = "txManagerHost";
			// 
			// txManagerPort
			// 
			this.txManagerPort.Name = "txManagerPort";
			// 
			// txId
			// 
			this.txId.Name = "txId";
			// 
			// cbIntermediate
			// 
			this.cbIntermediate.Name = "cbIntermediate";
			this.cbIntermediate.CheckedChanged += new System.EventHandler(this.cbIntermediate_CheckedChanged);
			// 
			// btStop
			// 
			this.btStop.Name = "btStop";
			// 
			// btReset
			// 
			this.btReset.Name = "btReset";
			// 
			// cbDedicated
			// 
			this.cbDedicated.Name = "cbDedicated";
			// 
			// txDbPassword
			// 
			this.txDbPassword.Name = "txDbPassword";
			// 
			// txDbUsername
			// 
			this.txDbUsername.Name = "txDbUsername";
			// 
			// txDbServer
			// 
			this.txDbServer.Name = "txDbServer";
			// 
			// txDbName
			// 
			this.txDbName.Name = "txDbName";
			// 
			// statusBar
			// 
			this.statusBar.Name = "statusBar";
			// 
			// tabPage1
			// 
			this.tabPage1.Name = "tabPage1";
			// 
			// pbar
			// 
			this.pbar.Name = "pbar";
			// 
			// tabControl
			// 
			this.tabControl.Name = "tabControl";
			// 
			// lbMgrHost
			// 
			this.lbMgrHost.Name = "lbMgrHost";
			// 
			// lbOwnPort
			// 
			this.lbOwnPort.Name = "lbOwnPort";
			// 
			// gpBoxNodeConfig
			// 
			this.gpBoxNodeConfig.Name = "gpBoxNodeConfig";
			// 
			// lbId
			// 
			this.lbId.Name = "lbId";
			// 
			// lbMgrPort
			// 
			this.lbMgrPort.Name = "lbMgrPort";
			// 
			// gpBoxLog
			// 
			this.gpBoxLog.Name = "gpBoxLog";
			// 
			// lbDBPassword
			// 
			this.lbDBPassword.Name = "lbDBPassword";
			// 
			// lbDBUsername
			// 
			this.lbDBUsername.Name = "lbDBUsername";
			// 
			// lbDBServer
			// 
			this.lbDBServer.Name = "lbDBServer";
			// 
			// lbDBName
			// 
			this.lbDBName.Name = "lbDBName";
			// 
			// gpBoxDB
			// 
			this.gpBoxDB.Name = "gpBoxDB";
			// 
			// gpBoxActions
			// 
			this.gpBoxActions.Name = "gpBoxActions";
			// 
			// ManagerMainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(458, 579);
			this.Name = "ManagerMainForm";
			this.Load += new System.EventHandler(this.ManagerMainForm_Load);
			this.tabPage1.ResumeLayout(false);
			this.tabControl.ResumeLayout(false);
			this.gpBoxNodeConfig.ResumeLayout(false);
			this.gpBoxLog.ResumeLayout(false);
			this.gpBoxDB.ResumeLayout(false);
			this.gpBoxActions.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		//-----------------------------------------------------------------------------------------------    

		private void LogHandler(object sender, LogEventArgs e)
		{
			// Create a logger for use in this class
			ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
			switch (e.Level)
			{
				case LogLevel.Debug:
					string message = e.Source  + ":" + e.Member + " - " + e.Message;
					logger.Debug(message,e.Exception);
					break;
				case LogLevel.Info:
					logger.Info(e.Message);
					break;
				case LogLevel.Error:
					logger.Error(e.Message,e.Exception);
					break;
				case LogLevel.Warn:
					logger.Warn(e.Message, e.Exception);
					break;
			}
		}
   
		//-----------------------------------------------------------------------------------------------    

		private void ManagerMainForm_Load(object sender, EventArgs e)
		{
			//normal startup. not a service
			_container = new  ManagerContainer();
			_container.ReadConfig(false);
			Config = _container.Config;
			
			RefreshUIControls();
			btStart.Focus();
		}

		//-----------------------------------------------------------------------------------------------    

		private void cbIntermediate_CheckedChanged(object sender, EventArgs e)
		{
			Config.Intermediate = cbIntermediate.Checked;
			_container.Config = Config;
			RefreshUIControls();
		}

		#region Implementation of methods from ManagerTemplateForm
		protected override bool Started
		{
			get
			{
				bool started = false;
				if (_container != null && _container.Started)
				{
					started = true;
				}
				return started;
			}
		}
		protected override void Exit()
		{
			StopManager();

			this.Close();
			Application.Exit();
		}

		protected override void ResetManager()
		{
			_container.ReadConfig(true);
			Config = _container.Config;

			RefreshUIControls();
		}
     
		protected override void StopManager()
		{
			if (Started)
			{
				pbar.Value = 0;
				pbar.Show();
				pbar.Value = pbar.Maximum / 2;
				
				statusBar.Text = "Stopping Manager...";
				Log("Stopping Manager...");
				btStop.Enabled = false;
				btStart.Enabled = false;
				try
				{
					_container.Stop();
					_container = null;
				}
				catch (Exception ex)
				{
					logger.Error("Error stopping manager",ex);
				}

				pbar.Value = pbar.Maximum;
	
				Log("Manager stopped.");

			}
			
			RefreshUIControls();

		}
    
		protected override void StartManager()
		{

			if (Started)
			{
				RefreshUIControls();
				return;
			}

			//to avoid people from clicking this again
			btStart.Enabled = false;
			btReset.Enabled = false;
			btStop.Enabled = false;

			statusBar.Text = "Starting Manager...";

			Log("Attempting to start Manager...");

			pbar.Value = 0;
			pbar.Show();

			Config = GetConfigFromUI();

			if (_container == null)
				_container = new ManagerContainer();

			_container.Config = Config;
			_container.RemotingConfigFile = "Alchemi.ManagerExec.exe.config";

			Log("app name == " + System.IO.Path.GetFileName(Application.ExecutablePath));

			try
			{
				_container.Start();

				Log("Manager started");

				//for heirarchical stuff
				//				if (Config.Intermediate)
				//				{
				//					//Config.Id = Manager.Id;
				//					//Config.Dedicated = Manager.Dedicated;
				//				}

			}
			catch (Exception ex)
			{
				_container = null;
				string errorMsg = string.Format("Could not start Manager. Reason: {0}{1}", Environment.NewLine, ex.Message);
				if (ex.InnerException != null)
				{
					errorMsg += string.Format("{0}", ex.InnerException.Message);
				}
				Log(errorMsg);
				logger.Error(errorMsg,ex);
			}
			RefreshUIControls();
		}
		#endregion

	}
}
