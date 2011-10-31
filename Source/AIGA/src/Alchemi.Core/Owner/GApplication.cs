#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	GApplication.cs
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
using System.Net.Sockets;
using System.Threading;
using Alchemi.Core.Utility;

namespace Alchemi.Core.Owner
{
	/// <summary>
	/// Represents a grid application
	/// </summary>
	public class GApplication : GNode
	{
		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		//----------------------------------------------------------------------------------------------- 
		// member variables
		//----------------------------------------------------------------------------------------------- 

		// Create a logger for use in this class
		private static readonly Logger logger = new Logger();
       
		private Container components = null;
		private FileDependencyCollection _Manifest = new FileDependencyCollection();
		private ThreadCollection _Threads = new ThreadCollection();
		private string _Id = "";
		private int _LastThreadId = -1;
        private String _ApplicationName;

		private int _NumThreadsFinished = 0;
		private Thread _GetFinishedThreadsThread;
		private bool _Running = false;
		private bool _Initted = false;
		private bool _MultiUse = false;

		//to prevent starting of already started app. also to prevent re-suing single-use apps.
		private bool firstuse = true;

		private bool _stopGetFinished = false;

		/// <summary>
		/// ThreadFinish event: is raised when the thread has completed execution successfully.
		/// </summary>
		public event GThreadFinish ThreadFinish;
		/// <summary>
		/// ThreadFailed event: is raised when the thread has completed execution and failed.
		/// </summary>
		public event GThreadFailed ThreadFailed;
		/// <summary>
		/// ApplicationFinish event: is raised when all the threads in the application have completed execution, i.e finished/failed.
		/// This event is NOT raised when the GApplication is declared as "multi-use".
		/// </summary>
		public event GApplicationFinish ApplicationFinish;

		//----------------------------------------------------------------------------------------------- 
		// properties
		//----------------------------------------------------------------------------------------------- 

		/// <summary>
		/// Gets the application manifest (a manifest is a collection file dependencies)
		/// </summary>
		public FileDependencyCollection Manifest
		{
			get { return _Manifest; }
		}

		/// <summary>
		/// Gets the collection  threads in the application
		/// </summary>
		public ThreadCollection Threads
		{
			get { return _Threads; }
		}

		/// <summary>
		/// Gets the application id
		/// </summary>
		public string Id
		{
			get { return _Id; }
		}

        public String ApplicationName
        {
            set
            {
                _ApplicationName = value;
            }
        }

		/// <summary>
		/// Gets a value indicating whether the application is currently running
		/// </summary>
		public bool Running
		{
			get { return _Running; }
		}

		/// <summary>
		/// Gets the state of the given GThread
		/// </summary>
		/// <param name="thread"></param>
		/// <returns>ThreadState indicating its status</returns>
		internal ThreadState GetThreadState(GThread thread)
		{
			if (_Running)
			{
				return Manager.Owner_GetThreadState(Credentials, new ThreadIdentifier(_Id, thread.Id));			
			}
			else
			{
				return ThreadState.Unknown;
			}
		}

		//----------------------------------------------------------------------------------------------- 
		// constructors and disposal
		//----------------------------------------------------------------------------------------------- 

		/// <summary>
		/// Creates an instance of the GApplication
		/// </summary>
		/// <param name="container"></param>
		public GApplication(IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}

		/// <summary>
		/// Creates an instance of the GApplication
		/// </summary>
		public GApplication()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Creates an instance of the GApplication
		/// </summary>
		/// <param name="connection"></param>
		public GApplication(GConnection connection) : base(connection) 
		{
			InitializeComponent();
		}

		/// <summary>
		/// Creates an instance of the GApplication
		/// </summary>
		/// <param name="multiUse">specifies if the GApplication instance is re-usable</param>
		public GApplication(bool multiUse)
		{
			InitializeComponent();
			_MultiUse = multiUse;
		}

		/// <summary>
		/// Disposes the GApplication object and performs clean up operations.
		/// </summary>
		/// <param name="disposing"></param>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (_Running & (_GetFinishedThreadsThread != null))
				{
					_stopGetFinished = true;
					//_GetFinishedThreadsThread.Abort();
					_GetFinishedThreadsThread.Join();
				}

				try
				{
					Manager.Owner_CleanupApplication(Credentials,_Id);
				}
				catch (Exception ex)
				{
					logger.Debug("Error while cleanUp: Dispose: ",ex);
				}

				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		//----------------------------------------------------------------------------------------------- 
		// public methods
		//----------------------------------------------------------------------------------------------- 

		/// <summary>
		/// Starts the grid application
		/// </summary>
        public virtual void Start()
		{
			logger.Debug("Start GApp..."+ _Id + " with " + _Threads.Count+" threads.");
			if (_Running) return;

			if (!_MultiUse)
			{
				logger.Debug("This is not a multi-use GApplication");
				if (!firstuse) 
					throw new InvalidOperationException("Cannot re-use a single-use GApplication.");
			}

			Init();

			logger.Debug("Completed Init...for GApp");

			//lock it to make doubly sure that the collection enumeration is sync-ed.
			lock(_Threads)
			{
				logger.Debug("Enter Thread Lock to SetThreads On Manager...GApp " + _Id);
				foreach (GThread thread in _Threads)
				{
					if (thread.Id == -1)
					{
						SetThreadOnManager(thread);
					}
				}
			}
			logger.Debug("Exit Thread Lock. Finished setting threads on Manager...GApp " + _Id);

			StartGetFinishedThreads();

			firstuse = false; //this should be the only place this value should be set. to make sure the first use is over
		}
        
		//----------------------------------------------------------------------------------------------- 
        
		/// <summary>
		/// Starts the given thread
		/// </summary>
		/// <param name="thread">thread to start</param>
		public virtual void StartThread(GThread thread)
		{
            /// May 10, 2006 michael@meadows.force9.co.uk: Fix for bug 1482578
            /// Prevents the client from executing StartThread on single-use 
            /// applications. StartThread should only be called for starting 
            /// on-the-fly threads to multi-use applications.
            if (!_MultiUse)
            {
                throw new InvalidOperationException("Cannot use StartThread with single-use GApplication objects.");
            }

			Init();
			Threads.Add(thread);
			SetThreadOnManager(thread);
			StartGetFinishedThreads();
		}
        
		//----------------------------------------------------------------------------------------------- 

		/// <summary>
		/// Stops the grid application
		/// </summary>
		public virtual void Stop()
		{
			if (_Running)
			{

				Manager.Owner_StopApplication(Credentials, this._Id);
            
				if (_GetFinishedThreadsThread != null && _GetFinishedThreadsThread.IsAlive)
				{
					_stopGetFinished = true;
					//_GetFinishedThreadsThread.Abort();
					_GetFinishedThreadsThread.Join();
				}
			}
			_Running = false; //just making sure again

			//TODO: may be we need not have a seperate "state" for the application. if all threads are dead, app should have state: stopped as well isnt it?
			//how do we handle multi-use apps then?
		}
        
		//----------------------------------------------------------------------------------------------- 
        
		/// <summary>
		/// Aborts the given thread
		/// </summary>
		/// <param name="thread">thread to abort</param>
		internal void AbortThread(GThread thread)
		{
			if (_Running)
			{
				Manager.Owner_AbortThread(Credentials, new ThreadIdentifier(_Id, thread.Id));
			}
		}
        
		//----------------------------------------------------------------------------------------------- 
		// private methods
		//----------------------------------------------------------------------------------------------- 

		//initialises the GApplication. overrides the base class init
		new private void Init()
		{
			base.Init();

			logger.Debug(string.Format("GApp credentials appId: {0}, username: {1}", _Id, Credentials.Username));
			if (!_Initted)
			{
				logger.Debug("Not initted. Initting GApp..."+_Id);
				if (Connection == null)
				{
					throw new InvalidOperationException("No connection specified.");
				}

				_Id = Manager.Owner_CreateApplication(Credentials);
				Manager.Owner_SetApplicationManifest(Credentials, _Id, _Manifest);
				_Initted = true;
			}
			else
			{
				//the app seems to be already initt-ed
				//verify anyway. - in case of apps re-started etc.

				logger.Debug("Already initted. GApp..."+_Id);
				if (!Manager.Owner_VerifyApplication(Credentials,_Id))
				{
					logger.Debug("Couldnot verify application setup. Creating a new id for GApp..."+_Id);
					_Id = Manager.Owner_CreateApplication(Credentials);
					logger.Debug("newId for GApp..."+_Id);
				}

				logger.Debug("Checking for manifest...GApp id= " + _Id);

                if (!Manager.Owner_HasApplicationManifest(Credentials, _Id))
                {
                    //app manifest needs to be set again, since the manager doesnt have it.
                    logger.Debug("Setting manifest...GApp id= " + _Id);
                    Manager.Owner_SetApplicationManifest(Credentials, _Id, _Manifest);
                }
				
                logger.Debug("Manifest set up...GApp id= " + _Id);
			}
        
            Manager.Owner_SetApplicationName(Credentials, Id, _ApplicationName);
        }

		//----------------------------------------------------------------------------------------------- 
		
		//initialises the thread on the manager
		private void SetThreadOnManager(GThread thread)
		{
			thread.SetId(++_LastThreadId);
			thread.SetApplication(this);
      
			Manager.Owner_SetThread(
				Credentials, 
				new ThreadIdentifier(_Id, thread.Id, thread.Priority),
				Utils.SerializeToByteArray(thread));
		}

		//----------------------------------------------------------------------------------------------- 
        
		//gets the finished threads
		private void GetFinishedThreads()
		{
			bool appCleanedup = false;
			logger.Info("GetFinishedThreads thread started.");
			try
			{
				while (!_stopGetFinished)
				{
					try
					{
						Thread.Sleep(1000);
        
						byte[][] FinishedThreads = Manager.Owner_GetFinishedThreads(Credentials, _Id);

						_NumThreadsFinished = Manager.Owner_GetFinishedThreadCount(Credentials,_Id);
						//we replace this with the above, to have the correct count always.
						//_NumThreadsFinished += FinishedThreads.Length;

						logger.Debug("Threads finished this poll..."+FinishedThreads.Length);
						logger.Debug("Total Threads finished so far..."+_NumThreadsFinished);

						for (int i=0; i<FinishedThreads.Length; i++)
						{
							GThread th = (GThread) Utils.DeserializeFromByteArray(FinishedThreads[i]);
							// assign [NonSerialized] members from the old local copy
							th.SetApplication(this);
							// HACK: need to change this if the user is allowed to set the id
							_Threads[th.Id] = th;
							Exception ex = Manager.Owner_GetFailedThreadException(Credentials, new ThreadIdentifier(_Id, th.Id));
                        
							if (ex == null)
							{
                                logger.Debug("Thread completed successfully:" + th.Id);
                                //raise the thread finish event
                                OnThreadFinish(th);
							}
							else
							{
                                logger.Debug("Thread failed:" + th.Id);
                                //raise the thread failed event
                                OnThreadFailed(th, ex);
							}
						}

                        // May 10, 2006 michael@meadows.force9.co.uk: Fix for bug 1485426
						if ((!_MultiUse) && (_NumThreadsFinished == Threads.Count))
						{
							logger.Debug("Application finished!"+_Id);

							if (!appCleanedup)
							{
								//clean up manager,executor.
								logger.Debug("SingleUse-Application finished cleaning up..."+_Id);
								Manager.Owner_CleanupApplication(Credentials,_Id);
								appCleanedup = true;
							}
							if (ApplicationFinish != null)
							{
								/// January 25, 2006 tb@tbiro.com: Fix for bug 1410797 
								/// Mark the application as stopped in the database
								/// This relies on the client to mark the application as stopped on the server, 
								/// maybe not the best approach
								Manager.Owner_StopApplication(Credentials, _Id);

								logger.Debug("Raising AppFinish event (for single-use app)..."+_Id);
								_Running = false;
								try
								{
									ApplicationFinish.BeginInvoke(null, null);
								}
								catch (Exception ex)
								{
									logger.Debug("ApplicationFinish Event-handler error: "+ex.ToString());
								}
							}
							break;
							//we break here since there is no point raising events mutliple times.!!! :kna: dec 3, 2006.
							//logger.Debug("App finished, but still looping since some-one might subscribe to this event, and we can send it to them now.");
						}
					}
					catch (SocketException se)
					{
						// lost connection to Manager
						logger.Error("Lost connection to manager. Stopping GetFinishedThreads...",se);
						break;
					}
					catch (RemotingException re)
					{
						// lost connection to Manager
						logger.Error("Lost connection to manager. Stopping GetFinishedThreads...",re);
						break;
					}
					catch (Exception e)
					{
						logger.Error("Error in GetFinishedThreads. Continuing to poll for finished threads...",e);
					}
				}
			}
			catch (ThreadAbortException)
			{
				logger.Debug("GetFinishedThreads Thread aborted.");
				Thread.ResetAbort();
			}
			catch (Exception e)
			{
				logger.Error("Error in GetFinishedThreads. GetFinishedThreads thread stopping...",e);
			}

			logger.Info("GetFinishedThreads thread exited..");
		}

        /// <summary>
        /// Fires the thread finish event.
        /// </summary>
        /// <param name="th">thread</param>
        protected virtual void OnThreadFinish(GThread th)
        {
            if (ThreadFinish != null)
            {
                logger.Debug("Raising thread finish event...");
                try
                {
                    ThreadFinish(th); //TODO: Need to see the effect of calling it async. 
                }
                catch (Exception eventhandlerEx)
                {
                    logger.Debug("Error in ThreadFinish Event handler: " + eventhandlerEx);
                }
            }
        }

        /// <summary>
        /// Fires the thread failed event.
        /// </summary>
        /// <param name="th">thread</param>
        /// <param name="ex">ex</param>
        protected virtual void OnThreadFailed(GThread th, Exception ex)
        {
            if (ThreadFailed != null)
            {
                logger.Debug("Raising thread failed event...");
                try
                {
                    ThreadFailed(th, ex); //TODO: Need to see the effect of calling it async. 
                }
                catch (Exception eventhandlerEx)
                {
                    logger.Debug("Error in ThreadFailed Event handler: " + eventhandlerEx);
                }
            }
        }

		//----------------------------------------------------------------------------------------------- 
        
		//start seperate threads to get the finished grid-threads.
		private void StartGetFinishedThreads()
		{
			if (!_Running)
			{
				logger.Debug("Starting a thread to get finished threads...");
				_stopGetFinished = false;
				_GetFinishedThreadsThread = new Thread(new ThreadStart(GetFinishedThreads));
				_GetFinishedThreadsThread.Start();
			}

			_Running = true;
		}
	}
}

