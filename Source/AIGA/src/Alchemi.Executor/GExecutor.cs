#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	GExecutor.cs
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
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Security;
using System.Security.Policy;
using System.Threading;
using Alchemi.Core;
using Alchemi.Core.Owner;
using Alchemi.Core.Executor;
using Microsoft.Win32;

namespace Alchemi.Executor
{
    public delegate void NonDedicatedExecutingStatusChangedEventHandler();
    public delegate void GotDisconnectedEventHandler();
 
	/// <summary>
	/// The GExecutor class is an implementation of the IExecutor interface and represents an Executor node.
	/// </summary>
    public class GExecutor : GNode, IExecutor, IOwner
    {
        //----------------------------------------------------------------------------------------------- 
        // member variables
        //----------------------------------------------------------------------------------------------- 
        
		// Create a logger for use in this class
		private static readonly Logger logger = new	Logger();

		private static object applicationDirectoryLock = new object();

        private string _Id;
        private bool _Dedicated;
        private Thread _NonDedicatedMonitorThread;
        private Thread _HeartbeatThread;
        private Thread _ThreadExecutorThread;
        private int _EmptyThreadInterval;
        private bool _ExecutingNonDedicated = false;
        private ThreadIdentifier _CurTi;

		// tb@tbiro.com - having the App domains hashtable as a Singleton means that only one app domain will be created for an application
		// tb@tbiro.com - so a bunch of synchronization code needs to be added
        private static readonly Hashtable _GridAppDomains = new Hashtable();
        
		private ManualResetEvent _ReadyToExecute = new ManualResetEvent(true);
        private string _BaseDir;
        
        private int _HeartbeatInterval = 2;

		private bool _stopHeartBeat = false;
		private bool _stopNonDedicatedMonitor = false;

        //eduGRID Addition:
        private AIMLBot.iBOT iBot; //provides the main Class the GThread communicates with
        private AppDomainExecutor GridThreadExecutor;
        private AppDomain GridThreadApplicationDomain;

		/// <summary>
		/// Raised when the connection status of a non-dedicated Executor is changed.
		/// </summary>
        public event NonDedicatedExecutingStatusChangedEventHandler NonDedicatedExecutingStatusChanged;
		
		/// <summary>
		/// This event is raised only when a Executor loses connection to the Manager.
		/// (This can happen in both non-dedicated and dedicated modes.
		/// </summary>
        public event GotDisconnectedEventHandler GotDisconnected;

        //----------------------------------------------------------------------------------------------- 
        // properties
        //----------------------------------------------------------------------------------------------- 

		/// <summary>
		/// Gets the executor id
		/// </summary>
        public string Id
        {
            get { return _Id; }
        }

		/// <summary>
		/// Gets whether the executor is dedicated
		/// </summary>
        public bool Dedicated
        {
            get { return _Dedicated; }
        }

		/// <summary>
		/// Gets whether the executor is currently running a grid thread in non-dedicated mode.
		/// </summary>
        public bool ExecutingNonDedicated
        {
            get { return _ExecutingNonDedicated; }
        }

        private ExecutorInfo Info
        {
            get 
            {
				//TODO need to see how executor info. is passed to manager, when and how things are updated.
				//TODO need to discover/report these properly
                ExecutorInfo info = new ExecutorInfo();
				//info.Dedicated = this._Dedicated;
				info.Hostname = this.OwnEP.Host;
				info.OS = Environment.OSVersion.ToString();
				info.Number_of_CPUs = 1; //default for now
				info.MaxDiskSpace = 0; //need to fix
				info.MaxMemory = 0; //need to fix

				//here we can better catch the error, since it is not a show-stopper. just informational.
				try
				{
					//need to find a better way to do these things.
					RegistryKey hklm = Registry.LocalMachine;
					hklm = hklm.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0");
					info.MaxCpuPower = int.Parse(hklm.GetValue("~MHz").ToString());
					info.Architecture = hklm.GetValue("Identifier","x86").ToString(); //CPU arch.
					hklm.Close();
				}catch (Exception e)
				{
					logger.Debug("Error getting executorInfo. Continuing...",e);
				}

                return info;
            }
        }

		/// <summary>
		/// Gets the base directory for the executor
		/// </summary>
        public string BaseDir
        {
            get
            {
                return _BaseDir;
            }
        }

		/// <summary>
		/// Gets or sets the heartbeat interval for the executor (in seconds).
		/// </summary>
		public int HeartBeatInterval
		{
			get 
			{
				return _HeartbeatInterval;
			}
			set
			{
				_HeartbeatInterval = value;
			}
		}

        //----------------------------------------------------------------------------------------------- 
        // constructors
        //----------------------------------------------------------------------------------------------- 
        
		/// <summary>
		/// Creates an instance of the GExecutor with the given end points 
		/// (one for itself, and one for the manager), credentials and other options.
		/// </summary>
		/// <param name="managerEP">Manager end point</param>
		/// <param name="ownEP">Own end point</param>
		/// <param name="id">executor id</param>
		/// <param name="dedicated">Specifies whether the executor is dedicated</param>
		/// <param name="sc">Security credentials</param>
		/// <param name="baseDir">Working directory for the executor</param>
        public GExecutor(RemoteEndPoint managerEP, OwnEndPoint ownEP, string id, bool dedicated, SecurityCredentials sc, string baseDir) : base(managerEP, ownEP, sc, id)
        {
            //eduGRID Addition
                iBot = new AIMLBot.iBOT();
            //Edn of eduGRID Addition

            _BaseDir = baseDir;
            if (_BaseDir == "" || _BaseDir==null)
            {
                _BaseDir = AppDomain.CurrentDomain.BaseDirectory;
            }

            string datDir = Path.Combine(_BaseDir,"dat");
            
			logger.Debug("datadir="+datDir);
            if (!Directory.Exists(datDir))
            {
				logger.Debug("Couldnot find datadir. Creating it..."+datDir);
                Directory.CreateDirectory(datDir);
            }
      
            _Dedicated = dedicated;
            _Id = id;

            if (_Id == "")
            {
				logger.Info("Registering new executor");
                _Id = Manager.Executor_RegisterNewExecutor(Credentials, null, Info);
				logger.Info("Successfully Registered new executor:"+_Id);
            }
			else
            {
				// update the executor data if it exists in the database or create a new one if it is not found
				_Id = Manager.Executor_RegisterNewExecutor(Credentials, _Id, Info);
				logger.Debug("Id is "+_Id);
            }

			//handle exception since we want to connect to the manager 
			//even if it doesnt succeed the first time.
			//that is, we need to handle InvalidExecutor and ConnectBack Exceptions.
            try 
            {
                try
                {
                    ConnectToManager();
                }
                catch (InvalidExecutorException)
                {
					logger.Info("Invalid executor! Registering new executor again...");

                    _Id = Manager.Executor_RegisterNewExecutor(Credentials, null, Info);
                    
					logger.Info("New ExecutorID = " + _Id);
                    ConnectToManager();
                }
            }
            catch (ConnectBackException) 
            {
                logger.Warn("Couldn't connect as dedicated executor. Reverting to non-dedicated executor. ConnectBackException");
                _Dedicated = false;
                ConnectToManager();
            }

			//for non-dedicated mode, the heart-beat thread will be started 
            if (_Dedicated)
            {
				logger.Debug("Dedicated mode: starting heart-beat thread");
				StartHeartBeatThread();
            }
        }

		private void StartHeartBeatThread()
		{
			_stopHeartBeat = false;
            _HeartbeatThread = new Thread(new ThreadStart(Heartbeat));
			_HeartbeatThread.Name = "HeartBeat-Thread";
            _HeartbeatThread.Start();
		}

		private void CleanUpApps()
		{
			//handle errors since clean up shouldnt hold up the other actions.
			try
			{
				logger.Debug("Cleaning up all apps before disconnect...");
				string datDir = Path.Combine(_BaseDir,"dat");
				string[] dirs = Directory.GetDirectories(datDir);
				foreach(string s in dirs)
				{
					//handle error since clean up shouldnt hold up the other actions.
					try
					{
						Directory.Delete(s,true);
						logger.Debug("Deleted directory: " + s);
					}catch{}
				}
				logger.Debug("Clean up all apps done.");
			}
			catch (Exception e)
			{
				logger.Debug("Clean up error. Continuing...", e);
			}
		}

        //----------------------------------------------------------------------------------------------- 
        // public methods
        //----------------------------------------------------------------------------------------------- 

		/// <summary>
		/// Abort all running threads and Disconnect from the Manager. 
		/// </summary>
        public void Disconnect()
        {
            StopNonDedicatedExecuting();
            
            if (_Dedicated)
            {
				logger.Debug("Stopping heartbeat thread...");
                _stopHeartBeat = true;
				//_HeartbeatThread.Abort();
                _HeartbeatThread.Join();
				logger.Debug("HeartBeat stopped.");
            }

			//handle disconnection error, since we dont want that to hold up the disconnect process.
			try
			{
				Manager.Executor_DisconnectExecutor(Credentials, _Id);
				logger.Debug("Disconnected executor");
			}
			catch (SocketException se)
			{
				logger.Debug("Error trying to disconnect from Manager. Continuing disconnection process...",se);
			}
			catch (System.Runtime.Remoting.RemotingException re)
			{
				logger.Debug("Error trying to disconnect from Manager. Continuing disconnection process...",re);
			}
			catch (Exception ex)
			{
				logger.Debug("Error trying to disconnect from Manager. Continuing disconnection process...",ex);
			}

            RelinquishIncompleteThreads();
            UnRemoteSelf();

			lock (_GridAppDomains)
			{
				logger.Debug("Unloading AppDomains on this executor...");
				foreach (object gad in _GridAppDomains.Values)
				{
					//handle error while unloading appDomain and continue...
					try
					{
						AppDomain.Unload(((GridAppDomain) gad).Domain);
					}
					catch (Exception e)
					{
						logger.Error("Error unloading appDomain. Continuing disconnection process...",e);
					}
				}
				_GridAppDomains.Clear();
			}
			//clean up all apps
			CleanUpApps();
        }

        //-----------------------------------------------------------------------------------------------    

		/// <summary>
		/// Start execution in non-dedicated mode.
		/// </summary>
		/// <param name="emptyThreadInterval">Interval to wait in between attempts to get a thread from the manager</param>
        public void StartNonDedicatedExecuting(int emptyThreadInterval)
        {
            if (!_Dedicated & !_ExecutingNonDedicated)
            {
				logger.Debug("Starting Non-dedicatedMonitor thread");
                _EmptyThreadInterval = emptyThreadInterval;
				_stopNonDedicatedMonitor = false;
                _NonDedicatedMonitorThread = new Thread(new ThreadStart(NonDedicatedMonitor));
				_NonDedicatedMonitorThread.Name = "NonDedicatedMonitor-thread";
                _NonDedicatedMonitorThread.Start();

                _ExecutingNonDedicated = true;


				try
				{
					//raise an event to indicate the status change into non-dedicated execution mode.
					if (NonDedicatedExecutingStatusChanged!=null)
						NonDedicatedExecutingStatusChanged();
				}
				catch (Exception ex)
				{
					logger.Debug("Error in NonDedicatedExecutingStatusChanged event-handler: "+ex.ToString());
				}

				//start the heartbeat thread.
				logger.Debug("Starting heart-beat thread: non-dedicated mode");
				StartHeartBeatThread();
			}
        }

        //-----------------------------------------------------------------------------------------------    

		/// <summary>
		/// Stops execution in non-dedicated mode.
		/// </summary>
        public void StopNonDedicatedExecuting()
        {
            if (!_Dedicated & _ExecutingNonDedicated)
            {
				logger.Debug("Stopping Non-dedicated execution monitor thread...");
                _stopNonDedicatedMonitor = true; //clean way to abort thread
                _NonDedicatedMonitorThread.Join(5000);

				try
				{
					if (_NonDedicatedMonitorThread.IsAlive)
					{
						logger.Debug("Nondedicated monitor still alive. forcing abort...");
						//even after 5 seconds if it doesnt stop, forcibly abort.
						_NonDedicatedMonitorThread.Abort();
						_NonDedicatedMonitorThread.Join();
					}
					else
					{
						logger.Debug("Nondedicated monitor thread stopped.");
					}
				}
				catch (Exception e)
				{
					logger.Error("Error trying to abort NonDedicatedMonitor thread. Continuing to stop non-dedicated executor...",e);
				}

                _ExecutingNonDedicated = false;
				
				logger.Debug("Raising event: NonDedicatedExecutingStatusChanged");
				
				try
				{
					if (NonDedicatedExecutingStatusChanged!=null)
						NonDedicatedExecutingStatusChanged();
				}
				catch (Exception ex)
				{
					logger.Debug("Error in NonDedicatedExecutingStatusChanged event-handler: "+ex.ToString());
				}
            }
        }

        //-----------------------------------------------------------------------------------------------    

		/// <summary>
		/// Pings the executor node. If this method runs successfully, it means that the remoting set up 
		/// between the manager and executor is working.
		/// </summary>
        public void PingExecutor()
        {
            // for testing communication
			logger.Debug("Executor pinged successfully");
        }
    
        //-----------------------------------------------------------------------------------------------    

		/// <summary>
		/// Executes the given thread
		/// </summary>
		/// <param name="ti">ThreadIdentifier representing the GridThread to be executed on this node.</param>
        public void Manager_ExecuteThread(ThreadIdentifier ti)
        {
            _ReadyToExecute.WaitOne();
            _ReadyToExecute.Reset();
            _CurTi = ti;

            //eduGRID modification:

            _ThreadExecutorThread = new Thread(new ThreadStart(ExecuteThreadInAppDomain));
			_ThreadExecutorThread.Name = "ExecuteThreadInAppDomain-thread";
            //_ThreadExecutorThread = new Thread(new ThreadStart(ExecuteThread));
            //_ThreadExecutorThread.Name = "ExecuteThread-thread";
            
            //end of edugrid modification

            _ThreadExecutorThread.Priority = ThreadPriority.Lowest;
            _ThreadExecutorThread.Start();
			logger.Debug("Started thread for executing GridThread:"+ti.ThreadId);
        }

		/// <summary>
		/// Cleans up all the application related files on the executor.
		/// </summary>
		/// <param name="appid">Application Id</param>
		public void Manager_CleanupApplication(string appid)
		{
			try
			{
				//unload the app domain and clean up all the files here, for this application.
				try
				{
					lock (_GridAppDomains)
					{
						GridAppDomain gad = (GridAppDomain)_GridAppDomains[appid];
						if (gad!=null && _GridAppDomains.ContainsKey(appid))
						{	
							logger.Debug("Unloading AppDomain for application:" + appid);
							
                            //eduGRID Addition
                            //AppDomain.Unload(gad.Domain);
							
                            _GridAppDomains.Remove(appid);
						}
						else
						{
							logger.Debug("Appdomain not found in collection.");
						}
					}
				}
				catch (Exception e)
				{
					logger.Debug("Error unloading appdomain:",e);
				}

				string appDir = GetApplicationDirectory(appid);
				logger.Debug("Cleaning up files on executor:"+_Id+" for application:" + appid);
				
				logger.Debug("Deleting: " + appDir);
				Directory.Delete(appDir,true);
				logger.Debug("Clean up finished for app:"+appid);
			}
			catch (Exception e)
			{
				//just debug info. to see why clean up failed.
				logger.Debug("Clean up app error: "+e.Message);
			}
		}

        //----------------------------------------------------------------------------------------------- 
        // private methods
        //----------------------------------------------------------------------------------------------- 

        /// <summary>
        /// Written by Abhishek Kumar on March 05, 2007
        /// purpose: to initiate the central Application Domain that
        /// all Grid Threads will be run on.
        /// 
        /// Police and permissions will also be set.
        /// ADV: a crash in this App Domain(because of poor code in GThread)
        /// does not affect eduGRID's Framework i.e. the Alchemi executor is maintained steady even in error
        /// 
        /// initially Alchemi created separate app domains for each Gthread it received.
        /// now, instead, we create 1 appdomain and run all gthreads on it
        /// the Bot Logic resides in this app domain.
        /// (this saves the overhead of initializing bot logic for every Gthread (or every query))
        /// </summary>
        private void initialize_GridThreadExecutor()
        {
            if (GridThreadExecutor == null)
            {
                string appDir = GetApplicationDirectory(_CurTi.ApplicationId);
                AppDomainSetup info = new AppDomainSetup();
                info.PrivateBinPath = appDir;
                GridThreadApplicationDomain = AppDomain.CreateDomain("Central_AppDomain", null, info);

                // ***
                // http://www.dotnetthis.com/Articles/DynamicSandboxing.htm
                PolicyLevel domainPolicy = PolicyLevel.CreateAppDomainLevel();
                AllMembershipCondition allCodeMC = new AllMembershipCondition();
                // TODO: 'FullTrust' in the following line needs to be replaced with something like 'AlchemiGridThread'
                //        This permission set needs to be defined and set automatically as part of the installation.
                PermissionSet internetPermissionSet = domainPolicy.GetNamedPermissionSet("FullTrust");
                PolicyStatement internetPolicyStatement = new PolicyStatement(internetPermissionSet);
                CodeGroup allCodeInternetCG = new UnionCodeGroup(allCodeMC, internetPolicyStatement);
                domainPolicy.RootCodeGroup = allCodeInternetCG;
                GridThreadApplicationDomain.SetAppDomainPolicy(domainPolicy);

                GridThreadExecutor = (AppDomainExecutor) GridThreadApplicationDomain.CreateInstanceFromAndUnwrap(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Alchemi.Executor.dll"), "Alchemi.Executor.AppDomainExecutor");
            }

            if (!GridThreadExecutor.Initialized)
            {
                try
                {
                    GridThreadExecutor.initialize();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error during initialization of GridThreadExecutor");
                }
            }
        }

        private void ConnectToManager()
        {
            if (_Dedicated)
            {
				logger.Debug("Connecting to Manager dedicated...");
                Manager.Executor_ConnectDedicatedExecutor(Credentials, _Id, OwnEP.ToRemoteEndPoint());
            }
            else
            {
				logger.Debug("Connecting to Manager NON-dedicated...");
                Manager.Executor_ConnectNonDedicatedExecutor(Credentials, _Id, OwnEP.ToRemoteEndPoint());
            }
        }

        //-----------------------------------------------------------------------------------------------    
    
        private void NonDedicatedMonitor()
        {
            bool gotDisconnected = false;
			logger.Info("NonDedicatedMonitor Thread Started.");
			try
			{
				while (!gotDisconnected && !_stopNonDedicatedMonitor)
				{
					try
					{
						_ReadyToExecute.WaitOne();
						//get the next thread-id from the manager - only if we can execute something here.
						//in non-dedicated mode...the executor pulls threads instead of the manager giving it threads to execute.
						ThreadIdentifier ti = Manager.Executor_GetNextScheduledThreadIdentifier(Credentials, _Id);

						if (ti == null)
						{
							//if there is no thread to execute, sleep for a random time and ask again later
							Random rnd = new Random();
							Thread.Sleep(rnd.Next(_EmptyThreadInterval, _EmptyThreadInterval * 2));
						}
						else
						{
							logger.Debug("Non-dedicated mode: Calling own method to execute thread");
							Manager_ExecuteThread(ti);
						}
					}
					catch (SocketException se)
					{
						gotDisconnected = true;
						logger.Error("Got disconnected. Non-dedicated mode.",se);
					}
					catch (System.Runtime.Remoting.RemotingException re)
					{
						gotDisconnected = true;
						logger.Error("Got disconnected. Non-dedicated mode.",re);
					}
				}

				// got disconnected
				_ExecutingNonDedicated = false;

				if (NonDedicatedExecutingStatusChanged!=null)
				{
					//raise status changed event
					logger.Debug("Raising event: NonDedicatedExecutingStatusChanged");
					try
					{
						NonDedicatedExecutingStatusChanged();
					}
					catch (Exception ex)
					{
						logger.Debug("Error in NonDedicatedExecutingStatusChanged event-handler: "+ex.ToString());
					}
				}

				logger.Debug("Non-dedicated executor: Unremoting self");
				UnRemoteSelf();

				//raise the event for non-dedicated mode only.
				if (!Dedicated && GotDisconnected!=null)
				{
					GotDisconnected();
					logger.Debug("Raising event: Executor GotDisconnected.");
				}
			}
			catch (ThreadAbortException)
			{
				_ExecutingNonDedicated = false;
				logger.Warn("ThreadAbortException. Non-dedicated executor");
				Thread.ResetAbort();
			}
			catch (Exception e)
			{
				logger.Error("Error in non-dedicated monitor: "+e.Message,e);
			}

			logger.Info("NonDedicatedMonitor Thread Exited.");
        }

        //-----------------------------------------------------------------------------------------------    

        //eduGRID Addition
        //written by Abhishek kumar dated March 5, 2007
        //Reason: Inter process communication is not our concern here
        //we wish to allow communication bw the Gthread and 
        //and the bot wrapper class that runs on executor node
        private void ExecuteThread()
        {
            byte[] rawThread = null; //this will contain the serialized Gthread

            logger.Info("Started ExecuteThread...");
            
            try
            {
               
                //note: the above statement means that ibot will be initialized only when it 
                //receives its first thread. this means that the response time for the first query
                //to this GExector will be high. 
                //TODO: put initialize bot else where .. probably in constructor
                logger.Info("Bot is initialized.");

                //Get Thread
                rawThread = Manager.Executor_GetThread(Credentials, _CurTi);
                logger.Debug("Got thread from manager. executing it: " + _CurTi.ThreadId);

                //execute it
                byte[] thread = new byte[rawThread.Length];
                rawThread.CopyTo(thread, 0);
                
                GThread gridThread = (GThread)Alchemi.Core.Utility.Utils.DeserializeFromByteArray(thread);
                logger.Debug("Executor running GThread: " + gridThread.Id);
                logger.Debug("Working dir=" + AppDomain.CurrentDomain.SetupInformation.PrivateBinPath);

                gridThread.SetWorkingDirectory(AppDomain.CurrentDomain.SetupInformation.PrivateBinPath);

                //eduGRID main link
                gridThread.SetiBOT(iBot);

                gridThread.Start();

                logger.Debug("GThread " + gridThread.Id + " done. Serializing it to send back to the manager...");

                byte[] finishedThread = Alchemi.Core.Utility.Utils.SerializeToByteArray(gridThread);

                //set its status to finished
                Manager.Executor_SetFinishedThread(Credentials, _CurTi, finishedThread, null);
                logger.Info(string.Format("Finished executing grid thread # {0}.{1}", _CurTi.ApplicationId, _CurTi.ThreadId));
            }
            catch (ThreadAbortException)
            {
                if (_CurTi != null)
                    logger.Warn(string.Format("aborted grid thread # {0}.{1}", _CurTi.ApplicationId, _CurTi.ThreadId));
                else
                    logger.Warn(string.Format("aborted grid thread # {0}.{1}", null, null));

                Thread.ResetAbort();
            }
            catch (Exception e)
            {
                logger.Warn(string.Format("grid thread # {0}.{1} failed ({2})", _CurTi.ApplicationId, _CurTi.ThreadId, e.GetType()), e);
                try
                {
                    //some exceptions such as Win32Exception caused problems when passed directly into this method.
                    //so better create another new exception object and send it over.
                    Exception eNew = new Exception(e.ToString());
                    Manager.Executor_SetFinishedThread(Credentials, _CurTi, rawThread, eNew);
                }
                catch (Exception ex1)
                {
                    if (_CurTi != null)
                    {
                        logger.Warn("Error trying to set failed thread for App: " + _CurTi.ApplicationId + ", thread=" + _CurTi.ThreadId + ". Original Exception = \n" + e.ToString(), ex1);
                    }
                    else
                    {
                        logger.Warn("Error trying to set failed thread: Original exception = " + e.ToString(), ex1);
                    }
                }
            }
            finally
            {

                _CurTi = null;
                _ReadyToExecute.Set();

                logger.Info("Exited ExecuteThread...");
            }
        }

		private void ExecuteThreadInAppDomain()
		{
			byte[] rawThread = null;
            
			try
			{
				logger.Info("Started ExecuteThreadInAppDomain...");

				logger.Info(string.Format("executing grid thread # {0}.{1}", _CurTi.ApplicationId, _CurTi.ThreadId));
				
				string appDir = GetApplicationDirectory(_CurTi.ApplicationId);
				logger.Debug("AppDir on executor=" + appDir);

				if (!_GridAppDomains.Contains(_CurTi.ApplicationId))
				{
					lock(_GridAppDomains)
					{ 
						// make sure that by the time the lock was acquired the app domain is still not created
						if (!_GridAppDomains.Contains(_CurTi.ApplicationId))
						{
							// create application domain for newly encountered grid application
							logger.Debug("app dir on executor: " + appDir);

							//before initializing clear dir..
                            foreach (string F in Directory.GetFiles(appDir))
                            {
                                try //becoz exception should not be created for an issue as small as this
                                {
                                    File.Delete(F);
                                }
                                catch (Exception ex)
                                {

                                }
                            }

							FileDependencyCollection manifest = Manager.Executor_GetApplicationManifest(Credentials, _CurTi.ApplicationId);
							if (manifest != null)
							{
								foreach (FileDependency dep in manifest)
								{
                                    try //so that IO error does not occur if files already exist
                                    {
                                        logger.Debug("Unpacking file: " + dep.FileName + " to " + appDir);
                                        dep.UnPackToFolder(appDir);
                                    }
                                    catch (Exception ex)
                                    {
                                    }
								}
							}
							else
							{
								logger.Warn("Executor_GetApplicationManifest from the Manager returned null");	
							}


                            initialize_GridThreadExecutor();
                            
							_GridAppDomains.Add(
								_CurTi.ApplicationId,
								new GridAppDomain(GridThreadApplicationDomain, GridThreadExecutor)
								);

							logger.Info("Created app domain, policy, got instance of GridAppDomain and added to hashtable...all done once for this application");
						}
						else
						{
							logger.Info("I got the lock but this app domain is already created.");
						}
					}
				}

				//get thread from manager
				GridAppDomain gad = (GridAppDomain) _GridAppDomains[_CurTi.ApplicationId];

				//if we have an exception in the secondary appdomain, it will raise an exception in this method, since the cross-app-domain call 
				//uses remoting internally, and it is just as if a remote method has caused an exception. we have a handler for that below anyway.

				rawThread = Manager.Executor_GetThread(Credentials, _CurTi);
				logger.Debug("Got thread from manager. executing it: "+_CurTi.ThreadId);
				
				//execute it
				
                byte[] finishedThread = gad.Executor.ExecuteThread(rawThread);
				logger.Info(string.Format("ExecuteThread returned for thread # {0}.{1}", _CurTi.ApplicationId, _CurTi.ThreadId));

                
				//set its status to finished
				Manager.Executor_SetFinishedThread(Credentials, _CurTi, finishedThread, null);
				logger.Info(string.Format("Finished executing grid thread # {0}.{1}", _CurTi.ApplicationId, _CurTi.ThreadId));

                
			}
			catch (ThreadAbortException)
			{
				if (_CurTi!=null)
					logger.Warn(string.Format("aborted grid thread # {0}.{1}", _CurTi.ApplicationId, _CurTi.ThreadId));
				else
					logger.Warn(string.Format("aborted grid thread # {0}.{1}",null, null));

				Thread.ResetAbort();
			}
			catch (Exception e)
			{
				logger.Warn(string.Format("grid thread # {0}.{1} failed ({2})", _CurTi.ApplicationId, _CurTi.ThreadId, e.GetType()),e);
				try
				{
					//some exceptions such as Win32Exception caused problems when passed directly into this method.
					//so better create another new exception object and send it over.
					Exception eNew = new Exception(e.ToString());
					Manager.Executor_SetFinishedThread(Credentials, _CurTi, rawThread, eNew);
				}
				catch (Exception ex1)
				{
					if (_CurTi!=null)
					{
						logger.Warn("Error trying to set failed thread for App: "+_CurTi.ApplicationId+", thread="+_CurTi.ThreadId + ". Original Exception = \n" + e.ToString(),ex1);
					}
					else
					{
						logger.Warn("Error trying to set failed thread: Original exception = " + e.ToString(), ex1);	
					}
				}
			}
			finally
			{

				_CurTi = null;
				_ReadyToExecute.Set();

				logger.Info("Exited ExecuteThreadInAppDomain...");
			}
		}

        //-----------------------------------------------------------------------------------------------    

        private void RelinquishIncompleteThreads()
        {
			if (_CurTi != null)
			{
				ThreadIdentifier ti = _CurTi;
				logger.Debug("Relinquishing incomplete thread:"+ti.ThreadId);
				Manager_AbortThread(ti);
				Manager.Executor_RelinquishThread(Credentials, ti);
			}
			else
			{
				logger.Debug("No threads to relinquish. _CurTi = null");
			}
        }
        
        //-----------------------------------------------------------------------------------------------    

		//heart beat thread
        private void Heartbeat()
        {
			int pingFailCount=0;

			logger.Info("HeartBeat Thread Started.");

			//heart-beat thread handles its own errors.
			try
			{
				HeartbeatInfo info = new HeartbeatInfo();
				info.Interval = _HeartbeatInterval;
	            
				// init for cpu usage
				TimeSpan oldTime = Process.GetCurrentProcess().TotalProcessorTime;
				DateTime timeMeasured = DateTime.Now;
				TimeSpan newTime = new TimeSpan(0);

				//TODO: be language neutral here. how??
				// init for cpu avail
				PerformanceCounter cpuCounter = new PerformanceCounter(); 
				cpuCounter.ReadOnly = true;
				cpuCounter.CategoryName = "Processor"; 
				cpuCounter.CounterName = "% Processor Time"; 
				cpuCounter.InstanceName = "_Total"; 

				while (!_stopHeartBeat)
				{
					// calculate usage
					newTime = Process.GetCurrentProcess().TotalProcessorTime;
					TimeSpan absUsage = newTime - oldTime;
					float flUsage = ((float) absUsage.Ticks / (DateTime.Now - timeMeasured).Ticks) * 100;
					info.PercentUsedCpuPower = (int) flUsage > 100 ? 100 : (int) flUsage;
					info.PercentUsedCpuPower = (int) flUsage < 0 ? 0 : (int) flUsage;
					timeMeasured = DateTime.Now;
					oldTime = newTime;

					try
					{
						// calculate avail
						info.PercentAvailCpuPower = 100 - (int) cpuCounter.NextValue() + info.PercentUsedCpuPower;
						info.PercentAvailCpuPower = info.PercentAvailCpuPower > 100 ? 100 : info.PercentAvailCpuPower;
						info.PercentAvailCpuPower = info.PercentAvailCpuPower < 0 ? 0 : info.PercentAvailCpuPower;
					}
					catch (Exception e)
					{
						logger.Debug("HeartBeat thread error: " + e.Message + Environment.NewLine + " Heartbeat continuing after error...");
					}

					//have a seperate try...block since we try 3 times before giving up
					try
					{
						//send a heartbeat to the manager.
						Manager.Executor_Heartbeat(Credentials, _Id, info);
						pingFailCount = 0;
					}
					catch (Exception e)
					{
						if (e is SocketException || e is System.Runtime.Remoting.RemotingException)
						{
							pingFailCount++;
							//we disconnect the executor if the manager cant be pinged three times
							if (pingFailCount >= 3)
							{
								logger.Error("Failed to contact manager "+pingFailCount+" times...",e);
								
								//if we call the disconnect here should be started off on a seperate thread because:
								//disconnect itself waits for HeartBeatThread to stop. If the method call
								//to disconnect from HeartBeat wont return immediately, then there is a deadlock
								//with disconnect waiting for the HeartBeatThread to stop and the HeartBeatThread waiting
								//for the call to disconnect to return.

								//raise the event to indicate that the Executor has got disconnected.
								if (GotDisconnected!=null)
									GotDisconnected();

								//new Thread(new ThreadStart(Disconnect)).Start();
							}
						}
						else
						{
							logger.Debug("Error during heartbeat. Continuing after error...",e);
						}
					}

					Thread.Sleep(_HeartbeatInterval * 1000);
				}
			}
			catch (ThreadAbortException)
			{
				Thread.ResetAbort();
				logger.Debug("HeartBeat thread aborted.");
			}
			catch (Exception e) 
			{
				logger.Error("HeartBeat Exception. Heartbeat thread stopping...",e);
			}

			logger.Info("HeartBeat Thread Exited.");
        }

        //-----------------------------------------------------------------------------------------------

		/// <summary>
		/// Abort the given thread.
		/// </summary>
		/// <param name="ti">ThreadIdentifier object representing the GridThread to be aborted</param>
        public void Manager_AbortThread(ThreadIdentifier ti)
        {
			try
			{
				if (_ThreadExecutorThread!=null && _ThreadExecutorThread.IsAlive)
				{
					logger.Debug(string.Format("Starting to abort executor Thread: {0}:{1}", ti.ApplicationId, ti.ThreadId));
					_ThreadExecutorThread.Abort();
					logger.Debug("Waiting for thread to join:"+ti.ThreadId);
					_ThreadExecutorThread.Join();
					logger.Debug(string.Format("Aborted Executor Thread: {0}:{1}", ti.ApplicationId, ti.ThreadId));
				}
				else
				{
					logger.Debug(string.Format("AbortThread: Thread {0}:{1} not alive. Not doing anything.",ti.ApplicationId , ti.ThreadId));
				}
			}
			catch (Exception e)
			{
				logger.Warn(string.Format("Error aborting thread: {0}:{1}. Continuing...", ti.ApplicationId, ti.ThreadId),e);
			}
		}

		/// <summary>
		/// Create the application path for the given application Id.
		/// I had to move the application paths to be unique per running executor thread
		/// in order to avoid I/O errors when multiple threads tried to create the same file
		/// </summary>
		/// <param name="applicationId"></param>
		/// <returns></returns>
		private string GetApplicationDirectory(string applicationId)
		{
			//return Path.Combine(
			//	_BaseDir,
			//	string.Format(@"dat\application_{0}\executor_{1}",applicationId, _Id));
            
            //eduGRID Addition
            string appDir = Path.Combine(
                            _BaseDir,
                            @"eduGRID_dat\GridThreadAssemblyProbe_Path");
            if (!Directory.Exists(appDir))
            {
                try
                {
                    Directory.CreateDirectory(appDir);
                }
                catch(Exception ex)
                {
                    throw new Exception("Error while creating AssemblyProbe Directory for GridThreadExecutor:Path=" + appDir + Environment.NewLine + "More Details: " + ex.ToString());
                }
            }
            return appDir;
		}

		/*
		private void GridAppDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			//this error handler handles errors that occur in the GridAppDomain in which the GThread/GJob runs
			logger.Warn("Unhandled Error in GridAppDomain. Sender = "+sender, (Exception)e.ExceptionObject);
		}
		*/
	}
}

