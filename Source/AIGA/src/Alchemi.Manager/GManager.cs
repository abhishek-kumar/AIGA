#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	GManager.cs
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
using System.Threading;
using Alchemi.Core;
using Alchemi.Core.Executor;
using Alchemi.Core.Manager;
using Alchemi.Core.Manager.Storage;
using Alchemi.Core.Owner;
using Alchemi.Core.Utility;
using Alchemi.Manager.Storage;
using ThreadState = Alchemi.Core.Owner.ThreadState;

namespace Alchemi.Manager
{
    /// <summary>
    /// Represents an Alchemi Manager
    /// </summary>
	public class GManager : MarshalByRefObject, IManager
    {
		// Create a logger for use in this class
		private static readonly Logger logger = new Logger();

		MApplicationCollection _Applications = new MApplicationCollection();
        MExecutorCollection _Executors = new MExecutorCollection();

		/// <summary>
		/// Verifies if this manager can be contacted via the network. If this method returns without 
		/// an exception, then we can assume that the remoting connection setup between the caller
		/// and this node is OK.
		/// </summary>
        public void PingManager()
        {
            // for testing communication
			logger.Debug("Manager pinged successfully.");
        }

        //-----------------------------------------------------------------------------------------------          

		/// <summary>
		/// Verifies if this node is up. This method is used when the manager itself is part of a hierarchy
		/// </summary>
        public void PingExecutor()
        {
            // for testing communication
			logger.Debug("Sub-Manager pinged successfully.");
        }

		/// <summary>
		/// Cleans up an application and its related temporary files.
		/// </summary>
		/// <param name="appid">Application id</param>
		public void Manager_CleanupApplication(string appid)
		{
			//TODO: implement when doing heirarchical grids
		}
        
        //-----------------------------------------------------------------------------------------------          

		/// <summary>
		/// Authenticates a user with the given security credentials
		///	
		/// </summary>
		/// <param name="sc">security credentials of the user</param>
        public void AuthenticateUser(SecurityCredentials sc)
        {
			//the password in the db is Md-5 hashed.

			string temp = sc.Password;

			//first try non-hashed version.i.e assume we dont have hashed password, MD5Hash it and check
			sc.Password = HashUtil.GetHash(sc.Password, HashUtil.HashType.MD5);
			bool result = ManagerStorageFactory.ManagerStorage().AuthenticateUser(sc);

			if (!result)
			{
				//now, try again...with original password, in case the user is giving us a MD5-hashed password
				sc.Password = temp;
				result = ManagerStorageFactory.ManagerStorage().AuthenticateUser(sc);
			}

			if (!result)
            {
				throw new AuthenticationException(string.Format("Authentication failed for user {0}.", sc.Username), null);
            }
        }
        
        //-----------------------------------------------------------------------------------------------          

		/// <summary>
		/// Creates a new application on the manager
		/// </summary>
		/// <param name="sc">security credentials to verify if the owner has permission to perform this operation 
		/// (i.e CreateApplication, which is associated with the ManageOwnApp permission)</param>
		/// <returns></returns>
        public string Owner_CreateApplication(SecurityCredentials sc)
        {
            AuthenticateUser(sc);
            EnsurePermission(sc, Permission.ManageOwnApp);

			logger.Debug("Creating new application...");
            return _Applications.CreateNew(sc.Username);
        }

        public void Owner_SetApplicationName(SecurityCredentials sc, string appId, String applicationName)
        {
            AuthenticateUser(sc);
            EnsurePermission(sc, Permission.ManageOwnApp);

            logger.Debug("Creating new application...");

            _Applications[appId].ApplicationName = applicationName;
        }

        //-----------------------------------------------------------------------------------------------          

		/// <summary>
		/// Sets the manifest for the application, which consists for the input/output dependencies for this application.
		/// </summary>
		/// <param name="sc">security credentials to verify if the owner has permission to perform this operation 
		/// (i.e SetApplicationManifest, which is associated with the ManageOwnApp permission)</param>
		/// <param name="appId">application whose manifest needs to be set</param>
		/// <param name="manifest">the manifest to set</param>
        public void Owner_SetApplicationManifest(SecurityCredentials sc, string appId, FileDependencyCollection manifest)
        {
            AuthenticateUser(sc);
            ApplicationAuthorizationCheck(sc, appId);

			logger.Debug("Setting manifest for application: "+appId);
            _Applications[appId].Manifest = manifest;
        }

        //-----------------------------------------------------------------------------------------------

        /// <summary>
        /// Determines whether the manager has the application manifest for the given application id.
        /// </summary>
        /// <param name="sc">security credentials</param>
        /// <param name="appId">application id</param>
        /// <returns>whether the manager has the application manifest</returns>
        public bool Owner_HasApplicationManifest(SecurityCredentials sc, string appId)
        {
            // This method only returns whether an application has a manifest or not and should not require authentication or authorization.

            //AuthenticateUser(sc);
            //ApplicationAuthorizationCheck(sc, appId);

            logger.Debug("Checking application for manifest: " + appId);

            try
            {
                MApplication app = _Applications[appId];
                return ((app != null) && (app.Manifest != null));
            }
            catch
            {
                return false;
            }
        }

        //-----------------------------------------------------------------------------------------------

		/// <summary>
		/// Initializes a thread and stores it into the database.
		/// </summary>
		/// <param name="sc">security credentials to verify if the owner has permission to perform this operation 
		/// (i.e SetThread, which is associated with the ManageOwnApp permission)</param>
		/// <param name="ti">ThreadIdentifier</param>
		/// <param name="thread">byte array representing the serialized thread</param>
        public void Owner_SetThread(SecurityCredentials sc, ThreadIdentifier ti, byte[] thread)
        {
            AuthenticateUser(sc);
            ApplicationAuthorizationCheck(sc, ti.ApplicationId);

            MThread t = _Applications[ti.ApplicationId][ti.ThreadId];
            t.Value = thread;
            t.Init(true);
            t.Priority = ti.Priority; //??
            
			logger.Debug("Initialised thread:"+ti.ThreadId );
            InternalShared.Instance.DedicatedSchedulerActive.Set();
        }

		//-----------------------------------------------------------------------------------------------

		/// <summary>
		/// Verify if an application is already initialised or not.
		/// </summary>
		/// <param name="sc">security credentials to verify if the owner has permission to perform this operation 
		/// (i.e SetThread, which is associated with the ManageOwnApp/ManageAllApps permission)</param>
		/// <param name="appId">application id</param>
		/// <returns>true if the applicationtrue if the application is successfully set up, and initialised in the database, false otherwise</returns>
		public bool Owner_VerifyApplication(SecurityCredentials sc, string appId)
		{
			bool appSetup = true;
			try
			{
				appSetup = _Applications.VerifyApp(appId);
			}
			catch
			{
				appSetup = false;
			}

			logger.Debug("Verifying application for id=" + appId + " success = " + appSetup);
			return appSetup;
		}

        //-----------------------------------------------------------------------------------------------       

		/// <summary>
		/// Aborts the thread. This is called by the owner of the thread.
		/// </summary>
		/// <param name="sc">security credentials to verify if the owner has permission to perform this operation 
		/// (i.e abort thread, which is associated with the ManageOwnApp / ManageAllApps permission)</param>
		/// <param name="ti">ThreadIdentifier of the thread to abort</param>
        public void Owner_AbortThread(SecurityCredentials sc, ThreadIdentifier ti)
        {
            AuthenticateUser(sc);
            ApplicationAuthorizationCheck(sc, ti.ApplicationId);

            MThread thread = _Applications[ti.ApplicationId][ti.ThreadId];
            
            logger.Debug("Owner called abort thread:"+ti.ThreadId);

            // if running on an executor, ask it to abort the thread
            if (thread.State != ThreadState.Dead && thread.State != ThreadState.Finished)
            {
				AbortThread(ti, thread.CurrentExecutorId);
				thread.State = ThreadState.Dead;
            }
        }
        
        //-----------------------------------------------------------------------------------------------          

		/// <summary>
		/// Gets the finished threads as a byte array.
		/// </summary>
		/// <param name="sc">security credentials to verify if the owner has permission to perform this operation 
		/// (i.e get finished threads, which is associated with the ManageOwnApp / ManageAllApps permission)</param>
		/// <param name="appId">id of the application whose completed threads need to be retrieved</param>
		/// <returns>2-D byte array representing all the finished threads in serialized form.</returns>
        public byte[][] Owner_GetFinishedThreads(SecurityCredentials sc, string appId)
        {
            AuthenticateUser(sc);
            ApplicationAuthorizationCheck(sc, appId);

			//logger.Debug("getting finished thread for app:"+appId);
            return _Applications[appId].FinishedThreads;
        }

		/// <summary>
		/// Gets the count of the finished threads.
		/// </summary>
		/// <param name="sc"></param>
		/// <param name="appId"></param>
		/// <returns>Number of threads finished</returns>
		public int Owner_GetFinishedThreadCount(SecurityCredentials sc, string appId)
		{
			AuthenticateUser(sc);
			ApplicationAuthorizationCheck(sc, appId);

			//logger.Debug("Getting count of total finished threads for app: " + appId);
			int totCount = 0;

			//get the count of threads which have the state "dead" in the database 
			//..i.e returned to owner after finishing or aborted.
			totCount = _Applications[appId].ThreadCount(ThreadState.Dead);

			return totCount;
		}

        //-----------------------------------------------------------------------------------------------          

		/// <summary>
		/// Gets the state of the given thread.
		/// </summary>
		/// <param name="sc">security credentials to verify if the owner has permission to perform this operation 
		/// (i.e get thread state, which is associated with the ManageOwnApp / ManageAllApps permission)</param>
		/// <param name="ti">ThreadIdentifier of thread whose state is to be retrieved</param>
		/// <returns>state of the given thread</returns>
        public ThreadState Owner_GetThreadState(SecurityCredentials sc, ThreadIdentifier ti)
        {
            AuthenticateUser(sc);
            ApplicationAuthorizationCheck(sc, ti.ApplicationId);

			logger.Debug("Getting state for thread: "+ti.ThreadId);
            return _Applications[ti.ApplicationId][ti.ThreadId].State;
        }

        //-----------------------------------------------------------------------------------------------       
        
		/// <summary>
		/// Gets the current state of the given application.
		/// </summary>
		/// <param name="sc">security credentials to verify if the owner has permission to perform this operation 
		/// (i.e GetApplicationState, which is associated with the ManageOwnApp / ManageAllApps permission)</param>
		/// <param name="appId">application id of the application whose state is to be queried</param>
		/// <returns>the state of the application</returns>
        public ApplicationState Owner_GetApplicationState(SecurityCredentials sc, string appId)
        {
            AuthenticateUser(sc);
            ApplicationAuthorizationCheck(sc, appId);
			logger.Debug("Getting application state..."+appId);
            return _Applications[appId].State;
        }

        //-----------------------------------------------------------------------------------------------       
        
		/// <summary>
		/// Stops an application with the given id.
		/// </summary>
		/// <param name="sc">security credentials to verify if the owner has permission to perform this operation 
		/// (i.e stop application, which is associated with the ManageOwnApp / ManageAllApps permission)</param>
		/// <param name="appId">id of the application to be stopped</param>
        public void Owner_StopApplication(SecurityCredentials sc, string appId)
        {
			if (ManagerStorageFactory.ManagerStorage().GetApplication(appId) == null)
			{
				return;
			}

            AuthenticateUser(sc);
            ApplicationAuthorizationCheck(sc, appId);

			logger.Debug("Stopping application:"+appId);
            MApplication a = _Applications[appId];
            a.Stop();
			logger.Debug("App. "+appId+" stopped");
        }

		//-----------------------------------------------------------------------------------------------

		/// <summary>
		/// Clean up all application related files on the executors.
		/// </summary>
		/// <param name="sc">security credentials to verify if the owner has permission to perform this operation 
		/// (i.e stop application, which is associated with the ManageOwnApp / ManageAllApps permission)</param>
		/// <param name="appid"></param>
		public void Owner_CleanupApplication(SecurityCredentials sc, string appid)
		{
			try
			{
				AuthenticateUser(sc);
				ApplicationAuthorizationCheck(sc, appid);

				ExecutorStorageView[] executorsStorage = _Executors.AvailableDedicatedExecutors;
				foreach (ExecutorStorageView executorStorage in executorsStorage)
				{
					try
					{
						string executorId = executorStorage.ExecutorId;
						MExecutor me = new MExecutor(executorId);
						//do it for dedicated ones only.
						if (me.RemoteRef!=null)
							me.RemoteRef.Manager_CleanupApplication(appid);
					}
					catch{}
				}
				logger.Debug("Cleaning up files on the manager for app: "+appid);
				string appDir = string.Format("{0}\\dat\\application_{1}", AppDomain.CurrentDomain.BaseDirectory, appid);
				logger.Debug("Deleting: " + appDir);
				Directory.Delete(appDir,true);
				logger.Debug("Clean up finished for app: "+appid);
			}
			catch (Exception e)
			{
				logger.Debug("Clean up app: " + appid + " error: " + e.Message );
			}
		}
        
        //-----------------------------------------------------------------------------------------------          

		/// <summary>
		/// Gets the exception that occured when the given thread was executing.
		/// </summary>
		/// <param name="sc">security credentials to verify if the owner has permission to perform this operation 
		/// (i.e get failed thread exception, which is associated with the ManageOwnApp / ManageAllApps permission)</param>
		/// <param name="ti">ThreadIdentifier of the failed thread</param>
		/// <returns></returns>
        public Exception Owner_GetFailedThreadException(SecurityCredentials sc, ThreadIdentifier ti)
        {
            AuthenticateUser(sc);
            ApplicationAuthorizationCheck(sc, ti.ApplicationId);

			logger.Debug("Getting exception for thread:"+ti.ThreadId);
            return _Applications[ti.ApplicationId][ti.ThreadId].FailedThreadException;
        }

        //-----------------------------------------------------------------------------------------------       
		
		/// <summary>
		/// Register a new executor with this manager
		/// </summary>
		/// <param name="sc">security credentials to verify if the executor has permission to perform this operation 
		/// (i.e register executor, which is associated with the ExecuteThread permission)</param>
		/// <param name="info">executor information</param>
		/// <returns>the id of the executor registered</returns>
        public string Executor_RegisterNewExecutor(SecurityCredentials sc, string existingExecutorId, ExecutorInfo info)
        {
            AuthenticateUser(sc);
            EnsurePermission(sc, Permission.ExecuteThread);

			//logger.Debug("Registering new executor");
            return _Executors.RegisterNew(sc, existingExecutorId, info);
        }

        //-----------------------------------------------------------------------------------------------          

		/// <summary>
		/// Connect to an executor which is in non-dedicated mode.
		/// This is called by a non-dedicated executor using its reference to this manager.
		/// </summary>
		/// <param name="sc">security credentials to verify if the executor has permission to perform this operation 
		/// (i.e connect non-dedicated, which is associated with the ExecuteThread permission)</param>
		/// <param name="executorId">executor id</param>
        public void Executor_ConnectNonDedicatedExecutor(SecurityCredentials sc, string executorId, RemoteEndPoint executorEP)
        {
            logger.Debug("Executor called: ConnectNonDedicated");
			AuthenticateUser(sc);
            EnsurePermission(sc, Permission.ExecuteThread);

            _Executors[executorId].ConnectNonDedicated(executorEP);

			logger.Debug("Connected to executor non-dedicated: "+executorId);
            _Executors[executorId].HeartbeatUpdate(new HeartbeatInfo(0, 0, 0));
        }
    
        //-----------------------------------------------------------------------------------------------          
    
		/// <summary>
		/// Connect to an executor which is in dedicated mode.
		/// This method is called by the remote executor using its reference to this manager.
		/// </summary>
		/// <param name="sc">security credentials to verify if the executor has permission to perform this operation 
		/// (i.e connect dedicated, which is associated with the ExecuteThread permission)</param>
		/// <param name="executorId">executor id</param>
		/// <param name="executorEP">end point of the executor</param>
        public void Executor_ConnectDedicatedExecutor(SecurityCredentials sc, string executorId, RemoteEndPoint executorEP)
        {
			logger.Debug("Executor called: ConnectDedicated: Authenticate,EnsurePermission,Connect,Set DedicatedScheduler");
            AuthenticateUser(sc);
            EnsurePermission(sc, Permission.ExecuteThread);

            try
            {
                _Executors[executorId].ConnectDedicated(executorEP);
                InternalShared.Instance.DedicatedSchedulerActive.Set();
            }
            catch (ExecutorCommException ece)
            {
				logger.Error("Couldnt connect back to the supplied executor",ece);
                throw new ConnectBackException("Couldn't connect back to the supplied Executor", ece);
            }
        }

        //-----------------------------------------------------------------------------------------------          

		/// <summary>
		/// Disconnect an executor.
		/// This is called by a remote executor using its reference to this manager.
		/// </summary>
		/// <param name="sc">security credentials to verify if the executor has permission to perform this operation 
		/// (i.e disconnect, which is associated with the ExecuteThread permission)</param>
		/// <param name="executorId"></param>
        public void Executor_DisconnectExecutor(SecurityCredentials sc, string executorId)
        {
            AuthenticateUser(sc);
            EnsurePermission(sc, Permission.ExecuteThread);

			logger.Debug("Disconnecting Executor:"+executorId);
            _Executors[executorId].Disconnect();
        }

        //-----------------------------------------------------------------------------------------------          

		/// <summary>
		/// Gets the identifier of the  next scheduled thread.
		/// </summary>
		/// <param name="sc">security credentials to verify if the executor has permission to perform this operation 
		/// (i.e GetNextScheduledThreadIdentifier, which is associated with the ExecuteThread permission)</param>
		/// <param name="executorId">executor id</param>
		/// <returns>ThreadIdentifier object representing the next scheduled grid thread</returns>
        public ThreadIdentifier Executor_GetNextScheduledThreadIdentifier(SecurityCredentials sc, string executorId)
        {
            AuthenticateUser(sc);
            EnsurePermission(sc, Permission.ExecuteThread);

            bool scheduled = false;
            ThreadIdentifier ti;
            
            // critical section .. don't want to schedule same thread on multiple executors
			Monitor.Enter(InternalShared.Instance);

			//logger.Debug("Entering monitor...");
            // try and get a local thread
            ti = InternalShared.Instance.Scheduler.ScheduleNonDedicated(executorId);
            if (ti != null)
            {
				//logger.Debug("Schedule-non-dedicated gave Ti:"+ti.ThreadId);
                scheduled = true;
            }
            else
            {
                // no thread, so can release lock immediately
                Monitor.Exit(InternalShared.Instance);
				//logger.Debug("No thread. so releasing lock immediately.");
            }
            // TODO: hierarchical grids ignored until after v1.0.0
            /*
            else if ((ti == null) & (Manager != null))
            {
                // no local threads .. request thread from next manager and "simulate" the fact that it was scheduled locally
                ti = Manager.Executor_GetNextScheduledThreadIdentifier(null, _Id);
                
                if (ti != null)
                {
                    scheduled = true;
                    MThread t = new MThread(ti);
                    t.Init(false);
                    t.Priority = ti.Priority + 1;
                }
            }
            */

            if (scheduled)
            {
				logger.Debug("obtained thread..."+ti.ThreadId);
                MThread t = new MThread(ti);
                t.State = ThreadState.Scheduled;
                t.CurrentExecutorId = executorId;
                // finished scheduling thread, can release lock
                Monitor.Exit(InternalShared.Instance);
				logger.Debug("set state of thread to scheduled. set executorID for the thread. released lock");
            }

            return ti;
        }

        //-----------------------------------------------------------------------------------------------          

		/// <summary>
		/// Gets the application manifest.
		/// This is called by the remote executor to retrieve the application manifest, prior to executing the first thread.
		/// </summary>
		/// <param name="sc">security credentials to verify if the executor has permission to perform this operation 
		/// (i.e GetApplicationManifest, which is associated with the ExecuteThread permission)</param>
		/// <param name="appId">appication id</param>
		/// <returns>FileDependencyCollection containing the application manifest (i.e the input files for the app.) </returns>
        public FileDependencyCollection Executor_GetApplicationManifest(SecurityCredentials sc, string appId)
        {
            AuthenticateUser(sc);
            EnsurePermission(sc, Permission.ExecuteThread);

            MApplication a = _Applications[appId];

			FileDependencyCollection manifest = a.Manifest;
			logger.Debug("Returning application manifest for app:"+appId);
            // TODO: hierarchical grids ignored until after v1.0.0
            //if (a.IsPrimary)
            //{
            return manifest;
            //}
            //else
            //{
            //    
            //    //TODO: could copy manifest locally to save bandwidth
            //    return Manager.Executor_GetApplicationManifest(null, appId);
            //    
            //}
        }

        //-----------------------------------------------------------------------------------------------          
    
		/// <summary>
		/// Gets the thread with the given identifier, as a byte array.
		/// This is called by a remote executor requesting a thread from the manager.
		/// </summary>
		/// <param name="sc">security credentials to verify if the executor has permission to perform this operation 
		/// (i.e GetThread, which is associated with the ExecuteThread permission)</param>
		/// <param name="ti">ThreadIdentifier</param>
		/// <returns>A byte array representing the serialized thread</returns>
        public byte[] Executor_GetThread(SecurityCredentials sc, ThreadIdentifier ti)
        {
            AuthenticateUser(sc);
            EnsurePermission(sc, Permission.ExecuteThread);

            byte[] retval;
            MThread t = _Applications[ti.ApplicationId][ti.ThreadId];

            // TODO: hierarchical grids ignored until after v1.0.0
            //if (_Applications[ti.ApplicationId].IsPrimary)
            //{
            retval = t.Value;
            //}
            //else
            //{
            //    retval =  Manager.Executor_GetThread(null, ti);
            //}
            t.State = ThreadState.Started;

			logger.Debug("set thread status to started. returning the byte array:"+ti.ThreadId);
            return retval;
        }
    
        //-----------------------------------------------------------------------------------------------          

		/// <summary>
		/// Sets the given thread to a finished state.
		/// This is called by a remote executor after completing execution of this thread.
		/// The thread may be successfully finished or failed.
		/// </summary>
		/// <param name="sc">security credentials to verify if the executor has permission to perform this operation 
		/// (i.e SetFinishedThread, which is associated with the ExecuteThread permission)</param>
		/// <param name="ti">ThreadIdentifier</param>
		/// <param name="thread">the byte array representing the serialized thread</param>
		/// <param name="e">Any exception that may have occured during the execution of the thread</param>
        public void Executor_SetFinishedThread(SecurityCredentials sc, ThreadIdentifier ti, byte[] thread, Exception e)
        {
            AuthenticateUser(sc);
            EnsurePermission(sc, Permission.ExecuteThread);

			MApplication app = _Applications[ti.ApplicationId];
            MThread t = _Applications[ti.ApplicationId][ti.ThreadId];

			if (app == null)
			{
				//invalid application id passed. normally this should not happen.
				throw new InvalidApplicationException("Invalid application id: "+ti.ApplicationId, null);
			}

			if (t == null)
			{
				//invalid thread id. this should normally not happen.
				throw new InvalidThreadException("Invalid thread id: "+ti.ApplicationId+":"+ti.ThreadId, null);
			}

            if (app.IsPrimary)
            {
				if (thread!=null)
				{
					try
					{
						t.Value = thread;
					}
					catch(Exception ex)
					{
						logger.Debug("Error saving thread to disk:"+ex.Message);
						//thread could not be saved to disk on the Manager
						//so set it as failed!

						//if e is not null, then let us get the exception which caused it to fail anyway.
						if (e==null) 
							e = ex; 
					}
				}

				if (e != null)
				{
					try
					{
						logger.Debug("thread failed. ti: " + ti.ThreadId + "," + e.Message);
						t.FailedThreadException = e;
					}
					catch (Exception ex)
					{
						logger.Debug("error saving thread-exception for failed thread to disk: threadId="+ti.ThreadId+", thread-fail-reason:" + e.Message, ex);
					}
				}
				else
				{
					logger.Debug("thread completed successfully. ti:"+ti.ThreadId );
				}
            }
            else
            {
                // TODO: hierarchical grids ignored until after v1.0.0
                //Manager.Executor_SetFinishedThread(null, ti, thread, e);
            }

            t.State = ThreadState.Finished;
            InternalShared.Instance.DedicatedSchedulerActive.Set();
			logger.Debug("Set the thread ("+ti.ThreadId +") state to finished. And set the dedicatedSchedulerActive.");
        }

        //-----------------------------------------------------------------------------------------------          

		/// <summary>
		/// Updates the heartbeat info of an executor
		/// </summary>
		/// <param name="sc">security credentials to verify if the executor has permission to perform this operation 
		/// (i.e HeartBeat, which is associated with the ExecuteThread permission)</param>
		/// <param name="executorId">executor id</param>
		/// <param name="info">heartbeat info</param>
        public void Executor_Heartbeat(SecurityCredentials sc, string executorId, HeartbeatInfo info)
        {
            AuthenticateUser(sc);
            EnsurePermission(sc, Permission.ExecuteThread);

            _Executors[executorId].HeartbeatUpdate(info);
        }

        //-----------------------------------------------------------------------------------------------       

		/// <summary>
		/// Resets a thread which is executing.
		/// </summary>
		/// <param name="sc">security credentials to verify if the executor has permission to perform this operation 
		/// (i.e RelinquishThread, which is associated with the ExecuteThread permission)</param>
		/// <param name="ti">ThreadIdentifier of the thread to relinquish</param>
        public void Executor_RelinquishThread(SecurityCredentials sc, ThreadIdentifier ti)
        {
            AuthenticateUser(sc);
            EnsurePermission(sc, Permission.ExecuteThread);

            new MThread(ti).Reset();
			logger.Debug("Reset thread: "+ti.ThreadId);
        }

        //-----------------------------------------------------------------------------------------------          

		/// <summary>
		/// Executes a thread given to this manager by another manager above itself.
		/// This method is *NOT* implemented in the current version.
		/// An implementation is expected to be provided in a future version after v.1.0.0
		/// </summary>
		/// <param name="ti">ThreadIdentifier of the thread to execute</param>
        public void Manager_ExecuteThread(ThreadIdentifier ti)
        {
            // TODO: hierarchical grids ignored until after v1.0.0
            /*
            MThread t = _Applications[ti.ApplicationId][ti.ThreadId];
            t.Init(false);
            t.Priority = ti.Priority + 1;
            InternalShared.Instance.DedicatedSchedulerActive.Set();
            */
        }

        //-----------------------------------------------------------------------------------------------          
        
		/// <summary>
		/// Aborts a thread given to this manager by another manager.
		/// This method is *NOT* implemented in the current version.
		/// An implementation is expected to be provided in a future version after v.1.0.0
		/// </summary>
		/// <param name="ti">ThreadIdentifier</param>
        public void Manager_AbortThread(ThreadIdentifier ti)
        {
            // TODO: hierarchical grids ignored until after v1.0.0
			logger.Debug("Manager_AbortThread called. NOT IMPLEMENTED IN THIS VERSION");
        }

        //-----------------------------------------------------------------------------------------------      

		/// <summary>
		/// Gets the list of live applications (i.e those that are currently running).
		/// 
		/// </summary>
		/// <param name="sc">security credentials to verify if the user has permissions to perform this operation.
		/// (i.e get list of applications, which is associated with the permission: ManageAllApps).</param>
		/// <returns>An ApplicationStorageView array containing all the applications running currently, with the attributes:
		/// application_id, usr_name, state, time_created, total_threads, unfinished_threads
		/// </returns>
		public ApplicationStorageView[] Admon_GetLiveApplicationList(SecurityCredentials sc)
		{
			AuthenticateUser(sc);
            
			try
			{
				EnsurePermission(sc, Permission.ManageAllApps);
				logger.Debug("Getting list of live applications.");
				return _Applications.LiveList;
			}
			catch (AuthorizationException)
			{
				//the user doesnt seem to have permissions for ManageAllApps.
				//let us try ManageOwnApp
				logger.Debug("User doesnot have permission for ManageAllApps, checking ManageOwnApp");
				EnsurePermission(sc,Permission.ManageOwnApp);
				logger.Debug("Getting list of live applications for user: "+sc.Username);
				return _Applications.GetApplicationList(sc.Username);
			}
			catch (Exception ex)
			{
				logger.Debug("Error getting list of applications...",ex);
				throw ex;
			}
		}

		/// <summary>
		/// Gets the application list for the current user.
		/// 
		/// </summary>
		/// <param name="sc"></param>
		/// <returns>ApplicationStorageView array with application info</returns>
		public ApplicationStorageView[] Admon_GetUserApplicationList(SecurityCredentials sc)
		{
			EnsurePermission(sc,Permission.ManageOwnApp);
			logger.Debug("Getting list of live applications for user: "+sc.Username);
			return _Applications.GetApplicationList(sc.Username);
		}

        //-----------------------------------------------------------------------------------------------       
        
		/// <summary>
		/// Gets the list of threads for the given application
		/// </summary>
		/// <param name="sc">security credentials to verify if the user has permissions to perform this operation.
		/// (i.e get list of threads, which is associated with the permission: ManageOwnApp / ManageAllApps(if querying an app which is not created by this user)).</param>
		/// <param name="appId">Application id</param>
		/// <returns>A ThreadStorageView array containing the thread list
		/// </returns>
        public ThreadStorageView[] Admon_GetThreadList(SecurityCredentials sc, string appId)
        {
            AuthenticateUser(sc);
            ApplicationAuthorizationCheck(sc, appId);
			logger.Debug("Getting thread list for app:"+appId);
            return _Applications[appId].ThreadList;
        }

		/// <summary>
		/// Gets the list of threads for the given application, and thread status.
		/// </summary>
		/// <param name="sc">security credentials to verify if the user has permissions to perform this operation.
		/// (i.e get list of threads, which is associated with the permission: ManageOwnApp / ManageAllApps(if querying an app which is not created by this user)).</param>
		/// <param name="appId">Application id</param>
		/// <returns>A ThreadStorageView array containing the thread list
		/// </returns>
    	public ThreadStorageView[] Admon_GetThreadList(SecurityCredentials sc, string appId, ThreadState status)
    	{
    		AuthenticateUser(sc);
			ApplicationAuthorizationCheck(sc, appId);
			logger.Debug("Getting thread list for app:"+appId);			
			return _Applications[appId].GetThreadList(status);
    	}

    	//-----------------------------------------------------------------------------------------------          

		/// <summary>
		/// Gets the list of users from the database
		/// 
		/// </summary>
		/// <param name="sc">security credentials to verify if the user has permissions to perform this operation.
		/// (i.e get list of users, which is associated with the permission: ManageUsers)</param>
		/// <returns>A DataTable containing the list of users with the attributes:
		/// usr_name, password, grp_id
		/// </returns>
		public UserStorageView[] Admon_GetUserList(SecurityCredentials sc)
		{
			AuthenticateUser(sc);
			EnsurePermission(sc, Permission.ManageUsers);
			logger.Debug("Getting the list of users.");
			
			return ManagerStorageFactory.ManagerStorage().GetUsers();
		}
        
        //-----------------------------------------------------------------------------------------------          
        
		/// <summary>
		/// Gets the list of groups in the database
		/// 
		/// </summary>
		/// <param name="sc">security credentials to verify if the user has permissions to perform this operation.
		/// (i.e get list of groups, which is associated with the permission: ManageUsers).
		/// </param>
		/// <returns>a DataTable containing the list of groups with the following attributes:
		/// gri_id, grp_name</returns>
		public GroupStorageView[] Admon_GetGroups(SecurityCredentials sc)
		{
			AuthenticateUser(sc);
			EnsurePermission(sc, Permission.ManageUsers);
			logger.Debug("Getting list of groups from the db");

			return ManagerStorageFactory.ManagerStorage().GetGroups();
		}

		public GroupStorageView Admon_GetGroup(SecurityCredentials sc, Int32 groupId)
		{
			AuthenticateUser(sc);
			EnsurePermission(sc, Permission.ManageUsers);

			logger.Debug(String.Format("Getting of group details from the db for group {0}", groupId));

			return ManagerStorageFactory.ManagerStorage().GetGroup(groupId);
		}

		/// <summary>
		/// Delete group and all associated users.
		/// </summary>
		/// <param name="sc"></param>
		/// <param name="groupToDelete"></param>
		public void Admon_DeleteGroup(SecurityCredentials sc, GroupStorageView groupToDelete)
		{
			AuthenticateUser(sc);
			EnsurePermission(sc, Permission.ManageUsers);

			logger.Debug(String.Format("Deleting group.", groupToDelete.GroupId));

			ManagerStorageFactory.ManagerStorage().DeleteGroup(groupToDelete);
		}

		public UserStorageView[] GetGroupUsers(SecurityCredentials sc, Int32 groupId)
		{
			AuthenticateUser(sc);
			EnsurePermission(sc, Permission.ManageUsers);

			logger.Debug(String.Format("Getting group {0} users.", groupId));

			return ManagerStorageFactory.ManagerStorage().GetGroupUsers(groupId);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sc"></param>
		/// <param name="group"></param>
		/// <returns></returns>
		public PermissionStorageView[] Admon_GetGroupPermissions(SecurityCredentials sc, GroupStorageView group)
		{
			AuthenticateUser(sc);
			EnsurePermission(sc, Permission.ManageUsers);

			logger.Debug(String.Format("Getting group permission for group ", group.GroupId));

			return ManagerStorageFactory.ManagerStorage().GetGroupPermissionStorageView(group.GroupId);
		}

		public PermissionStorageView[] Admon_GetPermissions(SecurityCredentials sc)
		{
			AuthenticateUser(sc);
			EnsurePermission(sc, Permission.ManageUsers);

			return PermissionStorageView.GetPermissionStorageView((Permission[])Enum.GetValues(typeof(Permission)));
		}


        //-----------------------------------------------------------------------------------------------          

		/// <summary>
		/// Updates the list of users with the data table given.
		/// 
		/// </summary>
		/// <param name="sc">security credentials to verify if the user has permissions to perform this operation.
		/// (i.e update users, which is associated with the permission: ManageUsers).</param>
		/// <param name="updates">DataTable containing users details to update</param>
		public void Admon_UpdateUsers(SecurityCredentials sc, UserStorageView[] updates)
		{
			AuthenticateUser(sc);
			EnsurePermission(sc, Permission.ManageUsers);

			ManagerStorageFactory.ManagerStorage().UpdateUsers(updates);
		}

        //-----------------------------------------------------------------------------------------------          

		/// <summary>
		/// Adds the list of users to the Alchemi database
		/// 
		/// </summary>
		/// <param name="sc">security credentials to verify if the user has permissions to perform this operation.
		/// (i.e add list of users, which is associated with the permission: ManageUsers).</param>
		/// <param name="adds">a DataTable object containing the list of users to be added</param>
		public void Admon_AddUsers(SecurityCredentials sc, UserStorageView[] adds)
		{
			AuthenticateUser(sc);
			EnsurePermission(sc, Permission.ManageUsers);

			ManagerStorageFactory.ManagerStorage().AddUsers(adds);
		}

		public void Admon_DeleteUser(SecurityCredentials sc, UserStorageView userToDelete)
		{
			AuthenticateUser(sc);
			EnsurePermission(sc, Permission.ManageUsers);

			ManagerStorageFactory.ManagerStorage().DeleteUser(userToDelete);
		}

        //-----------------------------------------------------------------------------------------------          

		/// <summary>
		/// Gets the list of executors from the database
		/// 
		/// </summary>
		/// <param name="sc">security credentials to verify if the user has permission to perform this operation 
		/// (i.e get list of executors, which is associated with the ManageOwnApp permission)</param>
		/// <returns>a DataTable containing the list of executors and the properties:
		/// executor_id, host, port, usr_name, is_connected, is_dedicated, cpu_max, cpu_totalusage
		/// </returns>
		public ExecutorStorageView[] Admon_GetExecutors(SecurityCredentials sc)
		{
			AuthenticateUser(sc);
			EnsurePermission(sc, Permission.ManageOwnApp);

			logger.Debug("Getting list of executors from database");

			return ManagerStorageFactory.ManagerStorage().GetExecutors();
		}

		public ExecutorStorageView Admon_GetExecutor(SecurityCredentials sc, String executorId)
		{
			AuthenticateUser(sc);
			EnsurePermission(sc, Permission.ManageOwnApp);

			logger.Debug(String.Format("Getting details for executor {0} from database", executorId));

			return ManagerStorageFactory.ManagerStorage().GetExecutor(executorId);
		}

		/// <summary>
		/// Executes a select query against the Manager database.
		/// 
		/// </summary>
		/// <param name="sc"></param>
		/// <param name="perm"></param>
		/// <param name="query"></param>
		/// <returns>results of the query as a Dataset</returns>
//		public DataSet Admon_ExecQuery(SecurityCredentials sc, Permission perm, string query)
//		{
//			DataSet result = null;
//			AuthenticateUser(sc); 
//			EnsurePermission(sc,perm);
//
//			//just make sure there is no mischief, such as dropping tables!
//			string temp = query.Trim().ToLower();
//
//			if (temp.IndexOf("drop")==-1 && (temp.StartsWith("select") || temp.StartsWith("insert") || temp.StartsWith("update") || temp.StartsWith("delete")))
//			{
//				logger.Warn("Query passed in: "+query);
//				try
//				{
//					result = ManagerStorageFactory.ManagerStorage().RunSqlReturnDataSet(query);
//				}
//				catch (Exception ex)
//				{
//					logger.Debug("Admon_ExecQuery ERROR executing query :"+query, ex);
//				}
//			}
//			else
//			{
//				logger.Warn("Invalid query passed in: "+query);
//				//throw new Exception("Invalid Query");
//			}
//			return result;
//		}

    	//----------------------------------------------------------------------------------------------- 

		/// <summary>
		/// Gets the summary of the system status.
		/// </summary>
		/// <param name="sc">security credentials to verify if the user has permission to perform this operation 
		/// (i.e get system summary. which is associated with the ManageOwnApp permission)</param>
		/// <returns>A DataTable containing attributes such as:
		/// total_executors,
		///	max_power varchar,
		///	power_usage,
		///	power_avail,
		///	power_totalusage,
		///	unfinished_threads.
		/// </returns>
        public SystemSummary Admon_GetSystemSummary(SecurityCredentials sc)
        {
            AuthenticateUser(sc);
            EnsurePermission(sc, Permission.ManageOwnApp);
			IManagerStorage mstore = ManagerStorageFactory.ManagerStorage();
			return mstore.GetSystemSummary();
        }

        //----------------------------------------------------------------------------------------------- 
        // private methods
        //----------------------------------------------------------------------------------------------- 

        private void ConnectToManager()
        {
            // TODO: hierarchical grids ignored until after v1.0.0
            /*
            if (_Dedicated)
            {
                Manager.Executor_ConnectDedicatedExecutor(null, _Id, OwnEP.ToRemoteEndPoint());
            }
            else
            {
                Manager.Executor_ConnectNonDedicatedExecutor(null, _Id);
            }
            */
        }
    
        //-----------------------------------------------------------------------------------------------    
    


        //-----------------------------------------------------------------------------------------------          

		/// <summary>
		/// Check if the given user is the application creator.
		/// 
		/// </summary>
		/// <param name="sc"></param>
		/// <param name="appId"></param>
		/// <returns></returns>
		protected bool IsApplicationCreator(SecurityCredentials sc, string appId)
		{
			ApplicationStorageView application = ManagerStorageFactory.ManagerStorage().GetApplication(appId);

			if (application == null)
			{
				return false;
			}

			if (String.Compare(application.Username, sc.Username, true) == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
        
        //-----------------------------------------------------------------------------------------------          
        
        private void ApplicationAuthorizationCheck(SecurityCredentials sc, string appId)
        {
            if (IsApplicationCreator(sc, appId))
            {
                // assume the user has permission 'ManageOwnApp' because this would have been verified during creation
            }
            else
            {
                // ensure permission 'ManageAllApps'
                EnsurePermission(sc, Permission.ManageAllApps);
            }
        }

        //-----------------------------------------------------------------------------------------------          

		/// <summary>
		/// Check if the permission was set
		/// 
		/// </summary>
		/// <param name="sc"></param>
		/// <param name="perm"></param>
		protected void EnsurePermission(SecurityCredentials sc, Permission perm)
		{
			bool result = ManagerStorageFactory.ManagerStorage().CheckPermission(sc, perm);

			if (!result)
			{
				logger.Debug("User"+sc.Username+" doesnt have permission "+perm.ToString());
				throw new AuthorizationException(
					string.Format("User '{0}' is not associated with permission '{1}'", sc.Username, perm.ToString()),
					null
					);
			}
		}
        
        //-----------------------------------------------------------------------------------------------          

		/// <summary>
		/// Aborts the thread with the given id, on the given executor.
		/// </summary>
		/// <param name="ti">ThreadIdentifier</param>
		/// <param name="executorId">Executor id</param>
        internal static void AbortThread(ThreadIdentifier ti, string executorId)
        {
            if (executorId == null)
            {
                // not being executed on any executor
				logger.Debug(string.Format("Null executorID passed in to AbortThread: {0}:{1}. Not aborting...",ti.ApplicationId,ti.ThreadId));
                return;
            }

            MExecutor me = new MExecutor(executorId);
            if (me.RemoteRef == null)
            {
                // not being executed on a dedicated executor .. so can't abort
				logger.Debug("AbortThread: not doing anything since the executor is not dedicated.");
                return;
            }

			try
			{
				logger.Debug("Aborting thread "+ ti.ThreadId +" on executor:"+executorId);
				me.RemoteRef.Manager_AbortThread(ti);
				logger.Debug("Aborting thread "+ ti.ThreadId +" on executor:"+executorId + ":: Complete.");
			}
			catch (ExecutorCommException ece)
			{
				logger.Error("ExecutorCommException...while aborting thread. Disconnecting executor...",ece);
				me.Disconnect();
			}
			catch (Exception e)
			{
				logger.Debug("Exception aborting thread on executor : " + e.Message,e);
			}
        }

		public void Admon_DeleteThread(SecurityCredentials sc, ThreadStorageView threadToDelete)
		{
			AuthenticateUser(sc);
			EnsurePermission(sc, Permission.ManageAllApps);

			logger.Debug(String.Format("Deleting thread {0}.", threadToDelete.ThreadId));

			ManagerStorageFactory.ManagerStorage().DeleteThread(threadToDelete);
		}

		public void Admon_DeleteApplication(SecurityCredentials sc, ApplicationStorageView applicationToDelete)
		{
			AuthenticateUser(sc);
			EnsurePermission(sc, Permission.ManageAllApps);

			logger.Debug(String.Format("Deleting application {0}.", applicationToDelete.ApplicationId));

			ManagerStorageFactory.ManagerStorage().DeleteApplication(applicationToDelete);
		}

        public void Admon_PerformStorageMaintenance(SecurityCredentials sc, StorageMaintenanceParameters maintenanceParameters)
        {
            AuthenticateUser(sc);
            EnsurePermission(sc, Permission.ManageAllApps);

            logger.Debug(String.Format("Performing maintenance with parameters {0}.", maintenanceParameters));

            Maintenance maintenance = new Maintenance();

            maintenance.PerformMaintenance(ManagerStorageFactory.ManagerStorage(), maintenanceParameters);
        }

        //-----------------------------------------------------------------------------------------------
    }
}

