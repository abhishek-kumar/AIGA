#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	DefaultScheduler.cs
* Project		:	Alchemi Core
* Created on	:	2003
* Copyright		:	Copyright © 2006 The University of Melbourne
*					This technology has been developed with the support of 
*					the Australian Research Council and the University of Melbourne
*					research grants as part of the Gridbus Project
*					within GRIDS Laboratory at the University of Melbourne, Australia.
* Author         :  Akshay Luther (akshayl@csse.unimelb.edu.au) and Rajkumar Buyya (raj@csse.unimelb.edu.au)
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
using Alchemi.Core;
using Alchemi.Core.Manager.Storage;
using Alchemi.Core.Owner;
using Alchemi.Core.Utility;
using Alchemi.Manager.Storage;

namespace Alchemi.Manager
{
	/// <summary>
	/// This is the default implementation of the IScheduler interface provided by Alchemi.
	/// The Default scheduler works on the basis of priority-based FIFO.
	/// The threads are all ordered by priority, and time of creation. It ensures that 
	/// the thread with the highest priority execute first on the next available executor.
	/// It also assumes that all executors are equal, and the next thread is given to 
	/// any available dedicated executor.
	/// </summary>
    public class DefaultScheduler : IScheduler
    {
		// Create a logger for use in this class
		private static readonly Logger logger = new Logger();

		private MApplicationCollection _Applications;
        private MExecutorCollection _Executors;

		private static object threadChooserLock = new object();

        private int nextExecutorIndex = 0;

        /// <summary>
        /// Sets the collection of applications.
        /// </summary>
        public MApplicationCollection Applications { set { _Applications = value; } }

		/// <summary>
		/// Sets the collection of executors
		/// </summary>
        public MExecutorCollection Executors { set { _Executors = value; } }
        
		/// <summary>
		/// Return a non-dedicated schedule: i.e a threadIdentifier of the next thread to be executed.
		/// This is to support voluntary / non-dedicated execution, where an executor asks for the next
		/// work unit. 
		/// </summary>
		/// <param name="executorId">The executorId passed in refers to the Executor which will run this thread.</param>
		/// <returns>ThreadIdentifier of the next available thread</returns>
        public ThreadIdentifier ScheduleNonDedicated(string executorId)
        {
			ThreadStorageView threadStorage = GetNextAvailableThread();
            if (threadStorage == null)
            {
                return null;
            }
			
			logger.Debug(String.Format("Schedule non-dedicated. app_id={0},threadID={1}",
				threadStorage.ApplicationId,
				threadStorage.ThreadId)
				);

			string appid = threadStorage.ApplicationId;
			int threadId = threadStorage.ThreadId;
			int priority = threadStorage.Priority;
			

            return new ThreadIdentifier(appid, threadId, priority);
        }

        /// <summary>
        /// Return the next available ExecutorId. 
        /// For an executor to be available the following considions have to be met:
        /// - executor is dedicated
        /// - executor is conected
        /// - executor has no threads running or scheduled
        /// </summary>
        /// <returns></returns>
        protected ExecutorStorageView GetNextAvailableExecutor()
        {
            // michael@meadows.force9.co.uk; gets next available executor without bias based upon position in executors list.
            ExecutorStorageView[] executors = ManagerStorageFactory.ManagerStorage().GetExecutors(TriStateBoolean.True, TriStateBoolean.True);

            for (int i = 0; i < executors.Length; i++)
            {
                nextExecutorIndex++;
                if (nextExecutorIndex >= executors.Length)
                {
                    nextExecutorIndex = 0;
                }

                ExecutorStorageView executor = executors[nextExecutorIndex];
                if (ManagerStorageFactory.ManagerStorage().GetExecutorThreadCount(executor.ExecutorId, ThreadState.Ready, ThreadState.Scheduled, ThreadState.Started) == 0)
                {
                    return executor;
                }
            }

            return null;
        }

		/// <summary>
		/// Return the thread with the highest priority from the pool of Ready threads.
		/// 
		/// Note: pathetic way of selecting the highest priority thread. 
		///		This should be moved into the storage for a more efficient implementation.
		/// </summary>
		/// <returns></returns>
		protected ThreadStorageView GetNextAvailableThread()
		{
			// achieve thread safety by locking on a static variable
			// this lock is not enough, we should lock until the thread status changes
			lock(threadChooserLock)
			{
				ThreadStorageView[] threads = ManagerStorageFactory.ManagerStorage().GetThreads(
					ApplicationState.Ready,  
					ThreadState.Ready);

				if (threads == null || threads.Length == 0)
				{
					return null;
				}

				ThreadStorageView highestPriorityThread = threads[0];

				foreach (ThreadStorageView thread in threads)
				{
					if (thread.Priority > highestPriorityThread.Priority)
					{
						highestPriorityThread = thread;
					}
				}

				return highestPriorityThread;
			}
		}


		/// <summary>
		/// Queries the database to return the next dedicated schedule.
		/// </summary>
		/// <returns>DedicatedSchedule</returns>
        public DedicatedSchedule ScheduleDedicated()
        {
			ExecutorStorageView executorStorage = GetNextAvailableExecutor();

			if (executorStorage == null)
			{
				return null;
			}

			ThreadStorageView threadStorage = GetNextAvailableThread();
			if (threadStorage == null)
			{
				return null;
			}

			DedicatedSchedule dsched = null;

			string executorId = executorStorage.ExecutorId;
				
			string appid = threadStorage.ApplicationId;
				
			int threadId = threadStorage.ThreadId;
				
			int priority = threadStorage.Priority;

//			if (priority == -1)
//			{
//				priority = 5; //DEFAULT PRIORITY - TODO: have to put this in some Constants.cs file or something...
//			}
			
			ThreadIdentifier ti= new ThreadIdentifier(appid, threadId,priority);
			logger.Debug(String.Format("Schedule dedicated. app_id={0},threadID={1}, executor-id={2}",																								   
				appid, 
				threadId, 
				executorId)
				);

			dsched = new DedicatedSchedule(ti, executorId);

            return dsched;
        }

		 
		/*
		 * //non-optimised code for demonstration on how a custom scheduler might be written
			DataTable executors = _Executors.AvailableDedicatedExecutors;
			if (executors.Rows.Count == 0)
			{
				return null;
			}
			string executorId = executors.Rows[0]["executor_id"].ToString();

            
			DataTable threads = _Applications.ReadyThreads;
			if (threads.Rows.Count == 0)
			{
				return null;
			}
			ThreadIdentifier ti = new ThreadIdentifier(
				threads.Rows[0]["application_id"].ToString(),
				int.Parse(threads.Rows[0]["thread_id"].ToString()),
				int.Parse(threads.Rows[0]["priority"].ToString())
				);
		*/
    }
}