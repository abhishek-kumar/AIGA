#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	ExecutorContainer.cs
* Project		:	Alchemi Core
* Created on	:	Aug 2006
* Copyright		:	Copyright © 2006 The University of Melbourne
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
using System.Configuration;
using System.Threading;
using Alchemi.Core;

namespace Alchemi.Executor
{
	public delegate void ExecutorConnectStatusEventHandler(string statusMessage, int percentDone);
	
	/// <summary>
	/// Summary description for ExecutorContainer.
	/// </summary>
	public class ExecutorContainer
	{
		private const int DefaultNumberOfExecutors = 1;
		public event GotDisconnectedEventHandler GotDisconnected;
		public event NonDedicatedExecutingStatusChangedEventHandler NonDedicatedExecutingStatusChanged;
		public event ExecutorConnectStatusEventHandler ExecConnectEvent;
		
		public Configuration Config=null;
		public GExecutor[] Executors = null;

		// Create a logger for use in this class
		private static readonly Logger logger = new Logger();

		private int GetNumberOfExecutors()
		{
			int numberOfExecutors;

			object appSetting = ConfigurationSettings.AppSettings["NumberOfExecutors"];

			try
			{
				numberOfExecutors = Convert.ToInt32(appSetting);

				if (numberOfExecutors <= 0)
				{
					numberOfExecutors = DefaultNumberOfExecutors;
				}

				return numberOfExecutors;
			}
			catch
			{
				numberOfExecutors = DefaultNumberOfExecutors;
			}

			return numberOfExecutors;
		}

		public ExecutorContainer()
		{
		}

		public bool Connected
		{
			get { return (Executors == null? false : true);}
		}

		public void Connect()
		{
			logger.Info("Connecting....");

			if (ExecConnectEvent!=null){
				ExecConnectEvent("Connecting....",0);
			}


			Executors = new GExecutor[GetNumberOfExecutors()];

			for (int executorIndex = 0; executorIndex < Executors.Length; executorIndex++)
			{
				RemoteEndPoint rep = new RemoteEndPoint(
					Config.ManagerHost,
					Config.ManagerPort,
					RemotingMechanism.TcpBinary
					);

				logger.Debug("Created remote-end-point");
				if (ExecConnectEvent!=null)
				{
					ExecConnectEvent("Created remote-end-point",20);
				}

				// TODO: kind of hack-ish way of determining the port for higher thread numbers
				OwnEndPoint oep = new OwnEndPoint(
					Config.OwnPort + executorIndex,
					RemotingMechanism.TcpBinary
					);

				logger.Debug("Created own-end-point");
				if (ExecConnectEvent!=null)
				{
					ExecConnectEvent("Created own-end-point",40);
				}

				string executorId = Config.GetIdAtLocation(executorIndex);

				// the executorId is used in the remoting URI so it MUST be initialized here
				if (executorId == String.Empty)
				{
					executorId = Guid.NewGuid().ToString();
				}

				// connect to manager
				Executors[executorIndex] = new GExecutor(rep, oep, executorId, Config.Dedicated, new SecurityCredentials(Config.Username, Config.Password), AppDomain.CurrentDomain.BaseDirectory);
			
				if (ExecConnectEvent!=null)
				{
					ExecConnectEvent("Updating executor configuration.",80);
				}
				Config.ConnectVerified = true;
				Config.SetIdAtLocation(executorIndex, Executors[executorIndex].Id);
				Config.Dedicated = Executors[executorIndex].Dedicated;

				if (ExecConnectEvent!=null)
				{
					ExecConnectEvent("Saved configuration.",60);
				}


				if (ExecConnectEvent!=null)
				{
					ExecConnectEvent("Connected successfully.",100);
				}

				Executors[executorIndex].GotDisconnected += new GotDisconnectedEventHandler(GExecutor_GotDisconnected);
				Executors[executorIndex].NonDedicatedExecutingStatusChanged += new NonDedicatedExecutingStatusChangedEventHandler(GExecutor_NonDedicatedExecutingStatusChanged);

			}

			Config.Slz();

			Config.ConnectVerified = true;

			logger.Info("Connected successfully.");
		}

		/// <summary>
		/// Reconnect to the Manager.
		/// </summary>
		public void Reconnect()
		{
			Reconnect(Config.RetryMax ,Config.RetryInterval);
		}

		/// <summary>
		/// Try to Reconnect to the Manager.
		///
		/// </summary>
		/// <param name="maxRetryCount">Maximum number of times to retry, if connection fails. -1 signifies: try forever.</param>
		/// <param name="retryInterval">Retry connection after every 'retryInterval' seconds.</param>
		public void Reconnect(int maxRetryCount, int retryInterval)
		{
			int retryCount = 0;
			const int DEFAULT_RETRY_INTERVAL = 30; //30 seconds
			while (true)
			{
				if (maxRetryCount >= 0 && retryCount < maxRetryCount)
					break;

				logger.Debug ("Attempting to reconnect ... attempt: "+(retryCount+1));
				retryCount++;
				try //handle the error since we want to retry later.
				{
					Connect();						
				}
				catch (Exception ex)
				{
					//ignore the error. retry later.
					logger.Debug("Error re-connecting attempt: " + retryCount, ex);
				} 

				if (!Connected)
				{
					//play safe.
					if (retryInterval<0 || retryInterval>System.Int32.MaxValue)
						retryInterval = DEFAULT_RETRY_INTERVAL;
					Thread.Sleep(retryInterval*1000); //convert to milliseconds
				}
				else
				{
					break;
				}
			}

			//if Executor is null, then it is not Connected. The Connected property actually checks for that.
			if (Executors!=null)
			{
				foreach (GExecutor executor in Executors)
				{
					if (executor.Dedicated)
					{
						logger.Debug("Reconnected successfully.[Dedicated mode.]");
					}
					else //not dedicated...
					{
						logger.Debug("Reconnected successfully.[Non-dedicated mode.]");
						executor.StartNonDedicatedExecuting(1000);
					}
				}
			}
		}

		public void Disconnect()
		{
			if (Connected)
			{
				if (Executors != null)
				{
					foreach (GExecutor executor in Executors)
					{
						if (executor != null)
						{
							executor.Disconnect();
						}
					}
				}

				Executors = null;
				logger.Info("Disconnected successfully.");
			}
		}

		/// <summary>
		/// Read the configuration file.
		/// </summary>
		/// <param name="useDefault"></param>
		public void ReadConfig(bool useDefault)
		{
			if (!useDefault)
			{
				//handle the error and lets use default if the config cannot be found.
				try
				{
					lock (this) // since we may reload the config dynamically from another thread, if needed.
					{
						Config = Configuration.GetConfiguration();
					}
					logger.Debug("Using configuration from Alchemi.Executor.config.xml ...");
				}
				catch (Exception ex)
				{
					logger.Debug("Error getting existing config. Continuing with default config...",ex);
					useDefault = true;
				}
			}

			//this needs to be a seperate if-block, since we may have a problem getting existing config. then we use default
			if (useDefault)
			{
				Config = new Configuration();
				logger.Debug("Using default configuration...");
			}
		}

		/// <summary>
		/// Returns a value specifying whether the Connection has been verified previously.
		/// </summary>
		public bool ConnectVerified
		{
			get { return Config.ConnectVerified; }
		}

		/// <summary>
		/// Stops the Executor Container
		/// </summary>
		public void Stop()
		{
			if (Config!=null)
			{
				Config.Slz();
			}
			
			Disconnect();
		}

		/// <summary>
		/// Starts the Executor Container
		/// </summary>
		public void Start()
		{
			logger.Debug("debug mode: curdir env="+Environment.CurrentDirectory + " app-base="+AppDomain.CurrentDomain.BaseDirectory);

			ReadConfig(false);

			if (ConnectVerified)
			{
				logger.Info("Using last verified configuration ...");
				Connect();
			}
			else
			{
				if (!Connected)
					Connect();
			}
		}

		private void GExecutor_GotDisconnected()
		{
			//always handle errors when raising events
			try
			{
				//bubble the event to whoever handles this.
				if (GotDisconnected!=null)
					GotDisconnected();
			}catch {}
		}

		private void GExecutor_NonDedicatedExecutingStatusChanged()
		{
			//always handle errors when raising events
			try
			{
				//bubble the event up
				if (NonDedicatedExecutingStatusChanged!=null)
					NonDedicatedExecutingStatusChanged();
			}catch {}
		}

		public void UpdateHeartBeatBInterval(int newHBInterval)
		{
			if (Executors != null)
			{
				foreach (GExecutor executor in Executors)
				{
					executor.HeartBeatInterval = newHBInterval;
				}
			}
		}

	}
}
