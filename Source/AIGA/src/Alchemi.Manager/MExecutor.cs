#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	MExecutor.cs
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
using System.Threading;
using Alchemi.Core;
using Alchemi.Core.Executor;
using Alchemi.Core.Owner;
using Alchemi.Manager.Storage;
using Alchemi.Core.Manager.Storage;
using ThreadState = Alchemi.Core.Owner.ThreadState;

namespace Alchemi.Manager
{
	/// <summary>
	/// Represents a container for the executor reference held by the manager.
	/// </summary>
    public class MExecutor
    {
		// Create a logger for use in this class
		private static readonly Logger logger = new Logger();
		
		private readonly static Hashtable _DedicatedExecutors = new Hashtable();
        
        private string _Id;
		private ThreadIdentifier currentTI;

		private const int MAX_CONCURRENT_THREADS = 1;

		/// <summary>
		/// Creates a new instance of the MExecutor class.
		/// </summary>
		/// <param name="id">id of the executor</param>
        public MExecutor(string id)
        {
            _Id = id;
        }

		/// <summary>
		/// Connects to the executor in non-dedicated mode.
		/// </summary>
        public void ConnectNonDedicated(RemoteEndPoint ep)
        {
			logger.Debug("Trying to connect NON-Dedicated to executor: "+_Id);
            if (!VerifyExists(ep))
            {
				logger.Debug("The supplied Executor ID does not exist.");
				throw new InvalidExecutorException("The supplied Executor ID does not exist.", null);
            }

			//here we don't ping back, since we know non-dedicated nodes can't be pinged back.
            
			ExecutorStorageView executorStorage = ManagerStorageFactory.ManagerStorage().GetExecutor(_Id);
			
			executorStorage.Connected = true;
			executorStorage.Dedicated = false;

			// update state in db
			ManagerStorageFactory.ManagerStorage().UpdateExecutor(executorStorage);

			logger.Debug("Connected non-dedicated. Updated db. executor_id="+_Id);
        }

		/// <summary>
		/// Connects to the executor in dedicated mode.
		/// </summary>
		/// <param name="ep">end point of the executor</param>
        public void ConnectDedicated(RemoteEndPoint ep)
        {
			logger.Debug("Trying to connect Dedicated to executor: "+_Id);
			if (!VerifyExists(ep))
			{
				logger.Debug("The supplied Executor ID does not exist.");
				throw new InvalidExecutorException("The supplied Executor ID does not exist.", null);
			}

            bool success = false;
            IExecutor executor;
            try
            {
                executor = (IExecutor) GNode.GetRemoteRef(ep, _Id);
                executor.PingExecutor(); //connect back to executor.
                success = true;
				logger.Debug("Connected dedicated. Executor_id="+_Id);
				ExecutorStorageView executorStorage = ManagerStorageFactory.ManagerStorage().GetExecutor(_Id);

				executorStorage.Connected = success;
				executorStorage.Dedicated = true;
				executorStorage.HostName = ep.Host;
				executorStorage.Port = ep.Port;

                // update state in db (always happens even if cannnot connect back to executor
				ManagerStorageFactory.ManagerStorage().UpdateExecutor(executorStorage);
				
				logger.Debug("Updated db after ping back to executor. dedicated executor_id="+_Id + ", dedicated = true, connected = "+success);
				// update hashtable
				if (!_DedicatedExecutors.ContainsKey(_Id))
				{
					_DedicatedExecutors.Add(_Id, executor);
					logger.Debug("Added to list of dedicated executors: executor_id="+_Id);
				}
			}
            catch (Exception e)
            {
				logger.Error("Error connecting to exec: "+_Id,e);
                throw new ExecutorCommException(_Id, e);
            }
        }

		/// <summary>
		/// Verify if the executor exists in the database.
		/// </summary>
		/// <returns></returns>
		public bool VerifyExists()
		{
			return VerifyExists(null);
		}

		/// <summary>
		/// Verify if the executor exists in the database and the remote endpoint host matches the database setting
		/// </summary>
		/// <param name="ep"></param>
		/// <returns></returns>
        private bool VerifyExists(RemoteEndPoint ep)
        {
            bool exists = false;

            try
            {
				logger.Debug("Checking if executor :"+_Id+" exists in db");

				ExecutorStorageView executorStorage = ManagerStorageFactory.ManagerStorage().GetExecutor(_Id);

				bool remoteEndPointNullOrHostIsSameAsExecutor;
				remoteEndPointNullOrHostIsSameAsExecutor = 
					ep == null || (ep != null && executorStorage.HostName == ep.Host);

				if (executorStorage != null && remoteEndPointNullOrHostIsSameAsExecutor)
				{
					exists = true;
				}

				logger.Debug("Executor :" + _Id + " exists in db=" + exists);
            }
            catch (Exception ex)
            {
				logger.Error("Executor :"+_Id+ " invalid id? ",ex);
                throw new InvalidExecutorException("The supplied Executor ID is invalid.", ex);
            }

			return exists;
        }

		/// <summary>
		/// Updates the database with the heartbeat info of this executor
		/// </summary>
		/// <param name="info"></param>
        public void HeartbeatUpdate(HeartbeatInfo info)
        {
            // update ping time and other heartbeatinfo
			ExecutorStorageView executorStorage = ManagerStorageFactory.ManagerStorage().GetExecutor(_Id);

			executorStorage.PingTime = DateTime.Now;
			executorStorage.Connected = true;
			executorStorage.CpuUsage = info.PercentUsedCpuPower;
			executorStorage.AvailableCpu = info.PercentAvailCpuPower;
			executorStorage.TotalCpuUsage += info.Interval * (float)info.PercentUsedCpuPower / 100;

			ManagerStorageFactory.ManagerStorage().UpdateExecutor(executorStorage);
        }

		/// <summary>
		/// Disconnect from the executor. 
		/// (Updates the database to reflect the executor disconnection.)
		/// </summary>
        public void Disconnect()
        {
            // maybe should reset threads here as part of the disconnection rather than explicitly ...
			ExecutorStorageView executorStorage = ManagerStorageFactory.ManagerStorage().GetExecutor(_Id);

			executorStorage.Connected = false;

			ManagerStorageFactory.ManagerStorage().UpdateExecutor(executorStorage);
        }

		/// <summary>
		/// Gets the remote reference to the executor node
		/// </summary>
        public IExecutor RemoteRef
        {
            get
            {
                return (IExecutor) _DedicatedExecutors[_Id];
            }
        }

		/// <summary>
		/// Execute a thread on a dedicated Executor.
		/// 
		/// Right before the execution the thread's status is set the Scheduled 
		/// and the thread's executor is set to the executor's ID.
		/// Spawn a new thread that remotes the execution to the Executor.
		/// 
		/// </summary>
		/// <param name="ds">Containes the Thread ID and the Executor ID.</param>
		/// <returns>True if the thread was successfully started on the Executor.</returns>
		public bool ExecuteThread(DedicatedSchedule ds)
		{
			bool success = false;

			//kna added this to allow controlling MAX_CONCURRENT_THREADS per executor. Aug19. 05
			//find # of executing threads from the db.
			int numConcurrentThreads = 0;

			MThread mt = new MThread(ds.TI);

			try
			{
				numConcurrentThreads = ManagerStorageFactory.ManagerStorage().GetExecutorThreadCount(
					_Id, 
					ThreadState.Ready, 
					ThreadState.Scheduled,
					ThreadState.Started);

				if (numConcurrentThreads >= MAX_CONCURRENT_THREADS)
				{
					success = false;
				}
				else
				{
					/// tb@tbiro.com - Feb 28, 2006:
					/// moved the thread status updating here from ManagerContainer.ScheduleDedicated 
					/// to make sure that the thread state is written in the right order
					mt.CurrentExecutorId = ds.ExecutorId;
					mt.State = ThreadState.Scheduled;

					logger.Debug(String.Format("Scheduling thread {0} to executor: {1}", ds.TI.ThreadId, ds.ExecutorId));

					this.currentTI = ds.TI;
					Thread dispatchThread = new Thread(new ThreadStart(this.ExecuteCurrentThread));
					dispatchThread.Name = "ScheduleDispatchThread";
					dispatchThread.Start();

					success = true;
				}

			}
			catch (Exception ex)
			{
				// restore the thread status so another executor can pick it up
				mt.CurrentExecutorId = null;
				mt.State = ThreadState.Ready;

				logger.Debug("Error scheduling thread on executor "+ _Id, ex);
			}

			return success;
		}

		private void ExecuteCurrentThread()
		{
			this.RemoteRef.Manager_ExecuteThread(this.currentTI);
		}

    }
}
