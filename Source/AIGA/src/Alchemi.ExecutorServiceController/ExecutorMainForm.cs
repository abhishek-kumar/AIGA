#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	ExecutorMainForm.cs
* Project		:	Alchemi Core
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
using Alchemi.Executor;

using log4net;
using Timer = System.Windows.Forms.Timer;

// Configure log4net using the .config file
[assembly: log4net.Config.XmlConfigurator(Watch=true)]

namespace Alchemi.ExecutorService
{
    public class ExecutorMainForm : ExecutorTemplateForm
    {
		private const string serviceName = "Alchemi Executor Service";

		public ExecutorMainForm()
		{
            InitializeComponent();
			tabControl.Controls.Remove(tabExecution); //we dont want this tabPage yet. and there seems to be no way to dynamically hide it!
			tabControl.SelectedTab = tabConnection;
		}

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.SuspendLayout();
			this.Name = "ExecutorMainForm";
			this.Text = "Alchemi Executor Service Controller";
			this.Load += new EventHandler(ExecutorMainForm_Load);
			this.ResumeLayout(false);
		}
        #endregion
    
		#region Form Event Handlers
        
		private void ExecutorMainForm_Load(object sender, EventArgs e)
        {
			//this should normally not create any problems, but then during design time it doesnt work, so we need to catch any exceptions
			//that may occur during design time.
			try
			{
				// avoid multiple instances
				bool isOnlyInstance = false;
				Mutex mtx = new Mutex(true, "AlchemiExecutorServiceController_Mutex", out isOnlyInstance);
				if(!isOnlyInstance)
				{
					MessageBox.Show(this,"An instance of this application is already running. The program will now exit.", "Alchemi Executor Service Controller", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					Application.Exit();
				}

				Logger.LogHandler += new LogEventHandler(this.LogHandler);

				//this is a service. just read the config.
				ExecutorContainer ec = new ExecutorContainer();
				ec.ReadConfig(false);
				Config = ec.Config;
				ec = null;

				this.btConnect.Text = "Start";
				this.btDisconnect.Text = "Stop";

				RefreshUIControls();
				btConnect.Focus();
			}
			catch {}

        }

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

		#endregion
    
		#region Implementation for methods from ExecutorTemplateForm
    	protected override void ConnectExecutor()
		{
			//This is actually the StartExecutorService method.

			if (Started)
			{
				Log("Executor Service is already started.");
				RefreshUIControls();
				return;
			}

			try
			{
				//to avoid people from clicking this again
				btConnect.Enabled = false;
				statusBar.Text = "Starting Executor Service...";
				Log("Attempting to start Executor Service...");

				ServiceController sc = new ServiceController(serviceName);
				if (sc.Status != ServiceControllerStatus.Running && sc.Status != ServiceControllerStatus.StartPending)
				{
					//get latest config and serialize the  object, so that the service uses the latest config.
					if (Config!=null)
					{
						GetConfigFromUI();
						Config.Slz();
					}
					sc.Start();
					sc.WaitForStatus(ServiceControllerStatus.Running,new TimeSpan(0,0,28));
					Log("Executor Service started.");
				}
			}
            catch (System.ServiceProcess.TimeoutException)
			{
				Log("Timeout expired trying to start Executor Service.");
			}
			catch (Exception ex)
			{
				Log("Error starting ExecutorService");
				logger.Error("Error starting ExecutorService",ex);
				DisconnectExecutor(); //which is actually the Stop executor service method
			}
			RefreshUIControls();
		}
	
        protected override void RefreshUIControls()
        {
			//dont need to keep calling the getter of the property, since it keeps querying the service
			bool connected = Started;

            txMgrHost.Text = Config.ManagerHost;
            txMgrPort.Text = Config.ManagerPort.ToString();
			
			cmbId.Items.Clear();
			for(int index=0; index < Config.GetIdCount(); index++)
			{
				cmbId.Items.Add(Config.GetIdAtLocation(index));

				if (index == 0)
				{
					cmbId.SelectedIndex = index;
				}
			}
			
			txOwnPort.Text = Config.OwnPort.ToString();
            txUsername.Text = Config.Username;
            txPassword.Text = Config.Password;
            cbDedicated.Checked = Config.Dedicated;
      
            btConnect.Enabled = !connected;
            btReset.Enabled = !connected;
            btDisconnect.Enabled = !btConnect.Enabled;

            txMgrHost.Enabled = !connected;
            txMgrPort.Enabled = !connected;
            txUsername.Enabled = !connected;
            txPassword.Enabled = !connected;
            txOwnPort.Enabled = !connected;
            cbDedicated.Enabled = !connected;

			udHBInterval.Value = (decimal)Config.HeartBeatInterval;
			udMaxRetry.Value = (decimal)Config.RetryMax;

			chkRetryConnect.Checked = Config.RetryConnect;
			udReconnectInterval.Value = (decimal)Config.RetryInterval;

			pbar.Visible = false;
			pbar.Value = 0;

			//hide the non-dedicated mode controls:
			//for now hide the Options tab.
			//Options tab should be enabled only when the service is stopped. when it is started again, new options will be 
			//picked up.
			//if (isService)
			//{	
			cbDedicated.Enabled = false;

			if (connected)
			{
				//the TABCONTROL tabPage Show/Hide, Visible properties and methods are obsolete.
				if (tabControl.Controls.Contains(tabOptions))
				{	
					tabControl.Controls.Remove(tabOptions);
				}
				statusBar.Text = "Executor Started.";
			}
			else
			{
				if (!tabControl.Controls.Contains(tabOptions))
				{
					tabControl.Controls.Add(tabOptions);
				}
				statusBar.Text = "Executor Stopped.";
			}
			//}	
			//not needed yet, since these features are not yet available in service mode.
//			else
//			{           
//				bool executing = false;
//				if (_container!=null && _container.Executor!=null && _container.Executor.ExecutingNonDedicated)
//                {
//                    executing = true;
//                }
//				btStartExec.Enabled = ((!Config.Dedicated) && (connected) && (!executing));
//				btStopExec.Enabled = ((!Config.Dedicated) && (connected) && (executing));
//
//				string sbAppend = (Config.Dedicated? " (dedicated)" : " (non-dedicated)");
//				if ((connected && executing) || (connected && Config.Dedicated))
//				{
//					statusBar.Text = "Executing" + sbAppend;
//				}
//				else if(connected)
//				{
//					statusBar.Text = "Connected" + sbAppend;
//				}
//				else
//				{
//					statusBar.Text = "Disconnected";
//				}
//			}
        }

        protected override void Exit()
        {
			//we dont stop the service just because the serviceController is closed. let it continue running.
			this.Close();
			Application.Exit();
        }

    	protected override void DisconnectExecutor()
    	{
			//this is actually the StopExecutorService method.

			if (!Started)
			{
				Log("The Executor Service is already stopped.");
				RefreshUIControls();
				return;
			}

			try
			{
				statusBar.Text = "Stopping Executor Service...";
				Log("Stopping Executor Service...");

				btDisconnect.Enabled = false; //to avoid clicking on this again.
				ServiceController sc = new ServiceController(serviceName);
				if (sc.CanStop)
				{
					sc.Stop();
					sc.WaitForStatus(ServiceControllerStatus.Stopped,new TimeSpan(0,0,28));
					Log("Executor Service stopped.");
				}
				else
				{
					logger.Debug("Couldnot stop service: CanStop = false");	
				}
			}
            catch (System.ServiceProcess.TimeoutException)
			{
				Log("Timeout expired trying to stop Executor Service.");
			}
			catch (Exception ex)
			{
				Log("Error stopping Executor Service");
				logger.Error("Error stopping Executor Service",ex);
			}
			RefreshUIControls();
    	}
	
		/// <summary>
		/// Specifies whether the Executor is Connected / ExecutorService is Started
		/// </summary>
		protected override  bool Started
		{
			get
			{
				bool started = false;
				try
				{
					ServiceController sc = new ServiceController(serviceName);
					if (sc.Status == ServiceControllerStatus.Running || sc.Status == ServiceControllerStatus.StartPending)
					{
						started = true;
					}
					sc = null;
				}
				catch (Exception ex)
				{
					logger.Error("Error trying to determine service status",ex);
				}
				return started;
			}
		}

		protected override void ResetExecutor()
		{
			ExecutorContainer ec = new ExecutorContainer();
			ec.ReadConfig(true);
			Config = ec.Config;
			ec = null;
			RefreshUIControls();
		}

		#endregion

    }
}
