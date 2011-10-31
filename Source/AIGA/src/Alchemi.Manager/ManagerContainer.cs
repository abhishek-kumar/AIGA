#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	ManagerContainer.cs
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
using System.IO;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading;
using ThreadState = Alchemi.Core.Owner.ThreadState;

using Alchemi.Core;
using Alchemi.Core.Manager.Storage;
using Alchemi.Manager.Storage;
using Alchemi.Core.Utility;

namespace Alchemi.Manager
{
	/// <summary>
	/// Event handler for status changes during Manager startup.
	/// </summary>
	public delegate void ManagerStartStatusEventHandler(string statusMessage, int percentDone);

	/// <summary>
	/// This class acts as a container for the manager and the applications,executors collections.
	/// </summary>
    public class ManagerContainer
    {

		//----------------------------------------------------------------------------------------------- 
        // member variables
        //----------------------------------------------------------------------------------------------- 
		
		/// <summary>
		/// Manager Configuration
		/// </summary>
		public Configuration Config=null;

		/// <summary>
		/// The configuration file used to set remoting parameters for the Manager.
		/// </summary>
		public string RemotingConfigFile = "Alchemi.Manager.exe.config"; //this will be changed by the service/exec application and set to the right value.

		/// <summary>
		/// Specifies if the Manager is started.
		/// </summary>
		public bool Started = false;

		//since starting and stopping may take a while, we better avoid calling start/stop twice,
		//when the process of start/stop is in progress
		private bool _Starting = false;
		private bool _Stopping = false;

		private TcpChannel _Chnl;

		private Thread _DedicatedSchedulerThread;
        private Thread _WatchDogThread;
		private Thread _InitExecutorsThread;

        private MExecutorCollection _Executors = new MExecutorCollection();
        private MApplicationCollection _Applications = new MApplicationCollection();

		private bool _stopWatchDog = false;
		private bool _stopScheduler = false;

		private static readonly Logger logger = new Logger();


		//----------------------------------------------------------------------------------------------
		// events
		//----------------------------------------------------------------------------------------------

		/// <summary>
		/// This event is raised when the start is called, to notify the progress of the "Start" call.
		/// </summary>
		public static event ManagerStartStatusEventHandler ManagerStartEvent;
    
        //----------------------------------------------------------------------------------------------- 
        // constructors
        //----------------------------------------------------------------------------------------------- 

		/// <summary>
		/// Creates an instance of the ManagerContainer.
		/// </summary>
		public ManagerContainer()
		{
			Started = false;	
		}

		/// <summary>
		/// Starts the Manager
		/// </summary>
        public void Start()
        {
			if (Started || _Starting)
				return;

			_Starting = true;

            try
            {
				if (Config==null)
				{
					ReadConfig(false);
					logger.Debug("Config is null. Getting config from file...");
				}

				OwnEndPoint ownEP = new OwnEndPoint(
					Config.OwnPort,
					RemotingMechanism.TcpBinary
					);

				logger.Debug("Configuring remoting");

				try
				{
					if (ManagerStartEvent!=null)
						ManagerStartEvent("Configuring remoting",10);
				}
				catch (Exception ex)
				{
					logger.Debug("Error in ManagerStartStatus event-handler: "+ex.ToString());
				}

            	RemotingConfiguration.Configure(AppDomain.CurrentDomain.BaseDirectory+RemotingConfigFile);
				//TODO: for hierarchical grids
//				RemoteEndPoint managerEP = null;
//				if (Config.Intermediate)
//				{
//					managerEP = new RemoteEndPoint(
//						Config.ManagerHost, 
//						Config.ManagerPort, 
//						RemotingMechanism.TcpBinary
//						);
//				}

				logger.Debug("Registering tcp channel on port: "+ownEP.Port);

                try
                {
                    _Chnl = new TcpChannel(ownEP.Port);
                	ChannelServices.RegisterChannel(_Chnl);
                }
                catch (Exception ex)
                {
                	logger.Error("Error registering channel...",ex);
                }

				try
				{
					if (ManagerStartEvent!=null)
						ManagerStartEvent("Registered tcp channel on port: "+ownEP.Port,30);
				}
				catch (Exception ex)
				{
					logger.Debug("Error in ManagerStartStatus event-handler: "+ex.ToString());
				}

				//since this is a single call thing, thread safety isnt an issue

				logger.Debug("Registering well known service type");

                RemotingConfiguration.RegisterWellKnownServiceType(
                    typeof(GManager), "Alchemi_Node",
                    WellKnownObjectMode.SingleCall);
                				
				// TODO: hierarchical grids ignored until after v1.0.0
                /*
                _Dedicated = dedicated;
                _Id = id;

                if (Manager != null)
                {
                    if (_Id == "")
                    {
                        Log("Registering new executor ...");
                        _Id = Manager.Executor_RegisterNewExecutor(null, new ExecutorInfo);
                        Log("New ExecutorID = " + _Id);
                    }

                    try
                    {
                        try
                        {
                            ConnectToManager();
                        }
                        catch (InvalidExecutorException)
                        {
                            Log("Invalid executor! Registering new executor ...");
                            _Id = Manager.Executor_RegisterNewExecutor(null, new ExecutorInfo);
                            Log("New ExecutorID = " + _Id);
                            ConnectToManager();
                        }
                    }
                    catch (ConnectBackException)
                    {
                        Log("Couldn't connect as dedicated executor. Reverting to non-dedicated executor.");
                        _Dedicated = false;
                        ConnectToManager();
                    }
                }
                */
      
                string datDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"dat");
                logger.Debug("datadir="+datDir);
                if (!Directory.Exists(datDir))
                {
                    Directory.CreateDirectory(datDir);
					logger.Debug("Data directory not found. Creating a new one:"+datDir);
                }

				try
				{
					if (ManagerStartEvent!=null)
						ManagerStartEvent("Initialising a new scheduler",50);
				}
				catch (Exception ex)
				{
					logger.Debug("Error in ManagerStartStatus event-handler: "+ex.ToString());
				}

				logger.Debug("Initialising a new scheduler");
                IScheduler scheduler = new DefaultScheduler();
                scheduler.Executors = _Executors;
                scheduler.Applications = _Applications;

				logger.Debug("Configuring internal shared class...");

				ManagerStorageFactory.CreateManagerStorage(Config);
				
				try
				{
					if (!ManagerStorageFactory.ManagerStorage().VerifyConnection())
					{
						throw new Exception("Error connecting to manager storage. Please check manager log file for details.");
					}
				}
				catch (Exception ex)
				{
					throw new Exception("Error connecting to manager storage.", ex);
				}

				InternalShared common = InternalShared.GetInstance(datDir,scheduler);
				logger.Debug("Initialising scheduler - done");
				logger.Debug("Starting scheduler thread");

				try
				{
					if (ManagerStartEvent!=null)
						ManagerStartEvent("Starting scheduler thread",60);
				}
				catch (Exception ex)
				{
					logger.Debug("Error in ManagerStartStatus event-handler: "+ex.ToString());
				}

                _stopScheduler = false;
				_DedicatedSchedulerThread = new Thread(new ThreadStart(ScheduleDedicated));
                _DedicatedSchedulerThread.Start();

				try
				{
					if (ManagerStartEvent!=null)
						ManagerStartEvent("Starting watchdog thread",70);
				}
				catch (Exception ex)
				{
					logger.Debug("Error in ManagerStartStatus event-handler: "+ex.ToString());
				}

				logger.Info("Starting watchdog thread");
				
				_stopWatchDog = false;
                _WatchDogThread = new Thread(new ThreadStart(Watchdog));
                _WatchDogThread.Start();

				try
				{
					if (ManagerStartEvent!=null)
						ManagerStartEvent("Updating configuration",80);
				}
				catch (Exception ex)
				{
					logger.Debug("Error in ManagerStartStatus event-handler: "+ex.ToString());
				}

				//start a seperate thread to init-known executors, since this may take a while.
				_InitExecutorsThread = new Thread(new ThreadStart(InitExecutors));
				_InitExecutorsThread.Start();

				Config.Slz();

				try
				{
					if (ManagerStartEvent!=null)
						ManagerStartEvent("Started Manager",100);
				}
				catch (Exception ex)
				{
					logger.Debug("Error in ManagerStartStatus event-handler: "+ex.ToString());
				}

				Started = true;
				_Starting = false;

			}
            catch (Exception e)
            {
                Stop();
				logger.Error("Error Starting Manager Container",e);
                throw e;
            }
        }

		/// <summary>
		/// Reads the Manager configuration from the Alchemi.Manager.config.xml file, 
		/// <br /> or gets the default configuration if useDefault = true.
		/// </summary>
		/// <param name="useDefault"></param>
		public void ReadConfig(bool useDefault)
		{
			if (!useDefault)
			{
				try
				{
					Config = Configuration.GetConfiguration();
				}
				catch (Exception)
				{
					useDefault = true;
				}
			}

			if (useDefault)
			{
				Config = new Configuration();
			}
		}

        public void ReadConfig(bool useDefault, string location, string filename)
        {
            if (!useDefault)
            {
                try
                {
                    Config = Configuration.GetConfiguration(location, filename);
                }
                catch (Exception)
                {
                    useDefault = true;
                }
            }

            if (useDefault)
            {
                Config = new Configuration();
            }
        }

		private void InitExecutors()
		{
			try
			{
				logger.Info("Initialising known executors...");
				lock (_Executors) 
				{
					_Executors.Init();
				}
				logger.Info("Initialising known executors...done");
			}
			catch(Exception ex)
			{
				logger.Debug("Exception in InitExecutors: ",ex);
			}
		}

        //----------------------------------------------------------------------------------------------- 
        // public methods
        //----------------------------------------------------------------------------------------------- 

		/// <summary>
		/// Stop the scheduler and watchdog threads, and shut down the manager.
		/// </summary>
        public void Stop()
        {
			if (!Started && !_Stopping)
				return;

			_Stopping = true;

			if (_InitExecutorsThread != null)
			{
				logger.Info("Stopping init-executors thread...");
				_InitExecutorsThread.Abort();
				_InitExecutorsThread.Join();
			}
            if (_DedicatedSchedulerThread != null)
            {
				logger.Info("Stopping the scheduler thread...");
				_stopScheduler = true; //cleaner way of aborting
				InternalShared.Instance.DedicatedSchedulerActive.Set();

				_DedicatedSchedulerThread.Abort(); //still use abort?
                _DedicatedSchedulerThread.Join();
            }
            if (_WatchDogThread != null)
            {
				logger.Info("Stopping the watchdog thread...");
				_stopWatchDog = true; //cleaner way of aborting.
                _WatchDogThread.Abort();
                _WatchDogThread.Join();
            }

			logger.Info("Cleaning up all apps...");
			CleanUpApps();

			logger.Info("Unregistering the remoting channel...");
            ChannelServices.UnregisterChannel(_Chnl);

			Config.Slz();

			Started = false;
			_Stopping = false;
        }

		private void CleanUpApps()
		{
			try
			{
				logger.Debug("Cleaning up all apps before disconnect...");
				
				string datDir = string.Format("{0}\\dat", AppDomain.CurrentDomain.BaseDirectory);
				string[] dirs = Directory.GetDirectories(datDir);
				foreach(string s in dirs)
				{
					try
					{
						Directory.Delete(s,true);
						logger.Debug("Deleted directory: " + s);
					}
					catch{}
				}
				logger.Debug("Clean up all apps done.");
				
			}
			catch (Exception e)
			{
				logger.Debug("Clean up error : ",e);
			}
		}

		private void ScheduleDedicated()
		{
			logger.Info("Scheduler thread started.");
			try 
			{
				// TODO: allow scheduling of multiple threads in one go
				while (!_stopScheduler)
				{
					try
					{
						//logger.Debug("WaitOne for 1000 millis on DedicatedSchedulerActive");
						InternalShared.Instance.DedicatedSchedulerActive.WaitOne(1000, false);

						//logger.Debug("Getting a dedicated schedule");
						DedicatedSchedule ds = InternalShared.Instance.Scheduler.ScheduleDedicated();

						if (ds == null)
						{
							//to avoid blocking again if stop has been called.
							if (!_stopScheduler)
							{
								InternalShared.Instance.DedicatedSchedulerActive.Reset();
								//logger.Debug("Dedicatd schedule is null. Reset the DedicatedSchedulerActive waithandle");
							}
							
							continue;
						}

						MExecutor me = _Executors[ds.ExecutorId];
                    
						try          
						{
							logger.Debug("Trying to schedule thread " + ds.TI.ThreadId + " to executor:"+ds.ExecutorId);
							// dispatch thread
							
							me.ExecuteThread(ds);

							/// tb@tbiro.com - Feb 28, 2006:
							/// updating the thread's status is done inside ExecuteThread after it was decided 
							/// whether this executor can take it or not
							/// this prevents race conditions if the Executor finishes very quickly
							/// and we overwrite here the Executor's status back to Scheduled after it was finished
//								// update thread state 'after' it is dispatched. (kna changed this: aug19,05). to prevent the scheduler from hanging here.
//								mt.CurrentExecutorId = ds.ExecutorId;
//								mt.State = ThreadState.Scheduled;
//								logger.Debug("Scheduled thread " + ds.TI.ThreadId + " to executor:"+ds.ExecutorId);
						}
						catch (Exception e)
						{
							logger.Error("Some error occured trying to schedule. Reset-ing the thread to be scheduled. Continuing...",e);
							// remove executor and reset thread so it can be rescheduled
							//me.Disconnect(); //Krishna Aug10, 05. let us not disconnect the Executor. perhaps it can do other threads.
							MThread mt = new MThread(ds.TI);
							mt.Reset(); // this should happen as part of the disconnection
						}	
					}
					catch (ThreadAbortException)
					{
						logger.Debug("Scheduler Thread resetting abort (1)...");
						Thread.ResetAbort();
					}
					catch (Exception e)
					{
						if (e is System.Data.SqlClient.SqlException || e is System.Data.OleDb.OleDbException)
						{
							//some problem contacting database
							//wait for a bit and try again
							logger.Debug("Error contacting database:",e);
							Thread.Sleep(30000); 
							//TODO: need to provide fault tolerance here: what if the database/storage cannot be contacted.?
							//TODO: in that case, just raise an event, and let the Service/exec deal with it.
						}
						else
						{
							logger.Error("ScheduleDedicated thread error. Continuing...",e);
						}
					}
				} //while
			}
			catch (ThreadAbortException)
			{
				logger.Debug("Scheduler Thread resetting abort (2)...");
				Thread.ResetAbort();
			}
			catch (Exception e)
			{
				logger.Error("ScheduleDedicated thread error. Scheduler thread stopped.",e);
			}
			logger.Info("Scheduler thread exited.");
		}

        private void Watchdog()
        {			
			logger.Info("WatchDog thread started.");
			try
			{
				while (!_stopWatchDog)
				{
					try
					{
						Thread.Sleep(7000);

						// ping dedicated executors running threads and reset executor and thread if can't ping
						ThreadStorageView[] dedicatedRunningThreadsStorage = ManagerStorageFactory.ManagerStorage().GetExecutorThreads(true, ThreadState.Scheduled, ThreadState.Started);

						foreach (ThreadStorageView threadStorage in dedicatedRunningThreadsStorage)
						{
							MExecutor me = _Executors[threadStorage.ExecutorId];
							try
							{
								me.RemoteRef.PingExecutor();
							}
							catch
							{
								me.Disconnect();
								new MThread(threadStorage.ApplicationId, threadStorage.ThreadId).Reset();
							}
						}

						// disconnect nde if not recd alive notification in the last 30 seconds
						// TODO: make time interval configurable
						Int32 secondsToTimeout = 30;
						DisconnectTimedOutExecutors(new TimeSpan(0, 0, secondsToTimeout));

						// reset threads whose executors have been disconnected
						ThreadStorageView[] nonDedicatedLostThreadsStorage = ManagerStorageFactory.ManagerStorage().GetExecutorThreads(
							false, 
							false, 
							ThreadState.Scheduled, 
							ThreadState.Started, 
							ThreadState.Finished,
							ThreadState.Dead);

						foreach (ThreadStorageView threadStorage in nonDedicatedLostThreadsStorage)
						{
							new MThread(threadStorage.ApplicationId, threadStorage.ThreadId).Reset();
							new MExecutor(threadStorage.ExecutorId).Disconnect();
						}
				
					}
					catch (ThreadAbortException)
					{
						logger.Debug("Watchdog thread aborting...");
						Thread.ResetAbort();
					}
					catch (Exception ex)
					{
						logger.Debug("Error in WatchDog thread. Continuing after error...",ex);
					}
				} //while
			}
			catch (ThreadAbortException)
			{
				logger.Debug("Watchdog thread aborting...");
				Thread.ResetAbort();
			}
			catch (Exception e)
			{
				logger.Error("WatchDog thread error. WatchDog thread stopped.",e);
			}

			logger.Info("WatchDog thread exited.");
        }

		/// <summary>
		/// Disconnect executors if the alive notification was not received in the alloted time.
		/// </summary>
		/// <param name="time"></param>
		protected void DisconnectTimedOutExecutors(TimeSpan time)
		{
			DateTime currentTime = DateTime.Now; // storing the current time so we don't unfairly disconnect executors in case this process takes some time to complete
			ExecutorStorageView[] connectedExecutorsStorage = ManagerStorageFactory.ManagerStorage().GetExecutors(TriStateBoolean.Undefined, TriStateBoolean.True);

			foreach (ExecutorStorageView executorStorage in connectedExecutorsStorage)
			{
				if (executorStorage.PingTime.Add(time) < currentTime)
				{
					executorStorage.Connected = false;
					ManagerStorageFactory.ManagerStorage().UpdateExecutor(executorStorage);
				}
			}

		}
    }
}

