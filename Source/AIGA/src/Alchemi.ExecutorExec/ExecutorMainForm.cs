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

namespace Alchemi.ExecutorExec
{
    public class ExecutorMainForm : ExecutorTemplateForm
    {

		public ExecutorMainForm() : base()
		{
            InitializeComponent();
			this.Text = "Alchemi Executor";
		}

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udHBInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMaxRetry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udReconnectInterval)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabConnection.SuspendLayout();
            this.tabExecution.SuspendLayout();
            this.tabOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // udHBInterval
            // 
            this.udHBInterval.ValueChanged += new System.EventHandler(this.udHBInterval_ValueChanged);
            // 
            // chkRetryConnect
            // 
            this.chkRetryConnect.CheckedChanged += new System.EventHandler(this.chkRetryConnect_CheckedChanged);
            // 
            // udMaxRetry
            // 
            this.udMaxRetry.ValueChanged += new System.EventHandler(this.udMaxRetry_ValueChanged);
            // 
            // udReconnectInterval
            // 
            this.udReconnectInterval.ValueChanged += new System.EventHandler(this.udReconnectInterval_ValueChanged);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 540);
            // 
            // cmbId
            // 
            this.cmbId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // ExecutorMainForm
            // 
            this.ClientSize = new System.Drawing.Size(458, 562);
            this.Name = "ExecutorMainForm";
            this.Load += new System.EventHandler(this.ExecutorMainForm_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udHBInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMaxRetry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udReconnectInterval)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabConnection.ResumeLayout(false);
            this.tabExecution.ResumeLayout(false);
            this.tabOptions.ResumeLayout(false);
            this.ResumeLayout(false);

		}
        #endregion
    
		#region Form Event Handlers

        private void ExecutorMainForm_Load(object sender, EventArgs e)
        {
			Logger.LogHandler += new LogEventHandler(this.LogHandler);

			//not a service. normal exec startup mode.
			_container = new ExecutorContainer();
			_container.ReadConfig(false);
			Config = _container.Config;

			this.btConnect.Text = "Connect";
			this.btDisconnect.Text = "Disconnect";

			_container.NonDedicatedExecutingStatusChanged += new NonDedicatedExecutingStatusChangedEventHandler(this.RefreshUIControls);
			_container.GotDisconnected += new GotDisconnectedEventHandler(this.Executor_GotDisconnected);
			_container.ExecConnectEvent += new ExecutorConnectStatusEventHandler(this.ExecutorConnect_Status);

			ConnectOnStartup();

			RefreshUIControls();
			btConnect.Focus();

        }
    
		private void chkRetryConnect_CheckedChanged(object sender, EventArgs e)
		{
			udReconnectInterval.Enabled = chkRetryConnect.Checked;
			udMaxRetry.Enabled = chkRetryConnect.Checked;
			Config.RetryConnect = chkRetryConnect.Checked;
		}

		private void udHBInterval_ValueChanged(object sender, EventArgs e)
		{
			_container.UpdateHeartBeatBInterval((int)udHBInterval.Value);

			Config.HeartBeatInterval = (int) udHBInterval.Value;
		}

		private void udReconnectInterval_ValueChanged(object sender, EventArgs e)
		{
			Config.RetryInterval = (int)udReconnectInterval.Value;
		}

		private void udMaxRetry_ValueChanged(object sender, EventArgs e)
		{
			Config.RetryMax = (int)udMaxRetry.Value;
		}

		#endregion
		
		#region Executor Events

		//just for showing the progress bar.
		public void ExecutorConnect_Status(string msg, int percentDone)
		{
			statusBar.Text = msg;
			Log(msg);
			logger.Info("Status message from ExecutorContainer: "+msg);
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

		//happens only for non-dedicated mode.
        private void Executor_GotDisconnected()
        {
			try
			{
				_container.Executors = null;
				RefreshUIControls();

				//just double check.
				//flag to find out if the disconnect was a manual operation by the user.
				if (btDisconnect.Tag == null)
				{
					Log("Got disconnected!");
					logger.Debug ("Got disconnected!");
					if (chkRetryConnect.Checked)
					{
						Log("Trying to reconnect...");
						logger.Debug("Trying to reconnect...");
						_container.Reconnect((int)udMaxRetry.Value,(int)udReconnectInterval.Value);
					}
				}
				btDisconnect.Tag = null; //reset it here
			}
			catch (Exception e)
			{
				logger.Error("Error Executor_GotDisconnected ",e) ;
				RefreshUIControls();
			}
        }
		#endregion

		private void ConnectOnStartup()
		{
			try
			{
				//we dont call start here, because we are doing the same thing here
				_container.ReadConfig(false);
				Config = _container.Config;
				RefreshUIControls();
				if (Config.ConnectVerified)
				{
					Log("Using last verified configuration ...");
					ConnectExecutor();
					HideTimer.Enabled = true;
				}
			}
			catch (Exception ex)
			{
				logger.Error("Error connecting to manager",ex);
				Log("Error connecting to manager. " + ex.Message);
			}
		}

				
		#region Implementation for methods from ExecutorTemplateForm
		
		/// <summary>
		/// Specifies whether the Executor is Connected
		/// </summary>
		protected override bool Started
		{
			get
			{
				bool started = false;
				started =_container==null ? false : _container.Connected;
				return started;
			}
		}

		protected override void DisconnectExecutor()
		{
			if (!Started)
			{
				RefreshUIControls();
				return;
			}

			try
			{
				pbar.Visible = true;
				pbar.Value = pbar.Maximum / 2;

				//set a flag to show that this is a manual disconnect,
				//so should not reconnect.
				btDisconnect.Tag = "true";
				_container.Disconnect();
				Log("Disconnected successfully.");
				pbar.Value = pbar.Maximum;
			}
			catch (Exception ex)
			{
				logger.Debug("Error disconnecting from Manager.",ex);
				Log("Error disconnecting from Manager." + ex.Message);
			}
			RefreshUIControls();
		}

		protected override void ResetExecutor()
		{
			_container.ReadConfig(true);
			Config = _container.Config;
			RefreshUIControls();
		}

		protected override void Exit()
		{
			DisconnectExecutor();

			this.Close();
			Application.Exit();

		}

		protected override void ConnectExecutor()
		{
			if (Started)
			{
				RefreshUIControls();
				return;
			}

			try
			{
				Log("Attempting to connect to Manager...");
				GetConfigFromUI();
				_container.Config = Config;
				_container.Connect();
				Log("Connected to Manager.");
			}
			catch (Exception ex)
			{
				logger.Error("Error connecting to manager.",ex);
				Log("Error connecting to manager.");
			}
			RefreshUIControls();
		}

		protected override void StartExecuting()
		{
			try
			{
				foreach (GExecutor executor in _container.Executors)
				{
					executor.StartNonDedicatedExecuting(1000);
				}
			}
			catch (Exception ex)
			{
				logger.Error("Error starting non-dedication execution.",ex) ;
				Log("Error starting non-dedication execution.");
			}
			RefreshUIControls();
		}

		protected override void StopExecuting()
		{
			try
			{
				foreach (GExecutor executor in _container.Executors)
				{
					executor.StopNonDedicatedExecuting();
				}
			}
			catch (Exception ex)
			{
				logger.Error("Error stopping non-dedication execution.",ex) ;
				Log("Error stopping non-dedication execution.");
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
           
			bool executing = false;
			if (_container!=null && _container.Executors!=null)
			{
				foreach (GExecutor executor in _container.Executors)
				{
					if (executor != null && executor.ExecutingNonDedicated)
					{
						executing = true;
						break;
					}
				}
				
			}
			btStartExec.Enabled = ((!Config.Dedicated) && (connected) && (!executing));
			btStopExec.Enabled = ((!Config.Dedicated) && (connected) && (executing));

			string sbAppend = (Config.Dedicated? " (dedicated)" : " (non-dedicated)");
			if ((connected && executing) || (connected && Config.Dedicated))
			{
				statusBar.Text = "Executing" + sbAppend;
			}
			else if(connected)
			{
				statusBar.Text = "Connected" + sbAppend;
			}
			else
			{
				statusBar.Text = "Disconnected";
			}			
		}

		#endregion

    }
}
