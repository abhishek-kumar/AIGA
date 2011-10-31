#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	MExecutorCollection.cs
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
using System.Collections;
using System.Data;

using Alchemi.Core;
using Alchemi.Core.Executor;
using Alchemi.Core.Owner;
using Alchemi.Core.Utility;
using Alchemi.Core.Manager.Storage;
using Alchemi.Manager.Storage;
using ThreadState = Alchemi.Core.Owner.ThreadState;

namespace Alchemi.Manager
{
	/// <summary>
	/// Represents a collection of the MExecutor objects held by the manager
	/// </summary>
    public class MExecutorCollection
    {
		// Create a logger for use in this class
		private static readonly Logger logger = new Logger();

		/// <summary>
		/// Gets the MExecutor object with the given executorId
		/// </summary>
        public MExecutor this[string executorId]
        {
            get
            {
                return new MExecutor(executorId);
            }
        }

		/// <summary>
		/// Registers a new executor with the manager
		/// </summary>
		/// <param name="sc">security credentials used to perform this operation.</param>
		/// <param name="executorId">The preferred executor ID. Set it to null to generate a new ID.</param>
		/// <param name="info">information about the executor (see ExecutorInfo)</param>
		/// <returns></returns>
		public string RegisterNew(SecurityCredentials sc, string executorId, ExecutorInfo info)
		{
			//NOTE: when registering, all executors are initially set to non-dedicated.non-connected.
			//once they connect and can be pinged back, then these values are set accordingly.
			ExecutorStorageView executorStorage = new ExecutorStorageView(
				executorId,
				false,
				false,
				info.Hostname,
				sc.Username,
				info.MaxCpuPower,
				info.MaxMemory,
				info.MaxDiskSpace,
				info.Number_of_CPUs,
				info.OS,
				info.Architecture
				);

			if (this[executorId].VerifyExists())
			{
				// executor already exists, just update the details
				ManagerStorageFactory.ManagerStorage().UpdateExecutor(executorStorage);

				logger.Debug("Updated executor details = " + executorId);

				return executorId;
			}
			else
			{
				String newExecutorId = ManagerStorageFactory.ManagerStorage().AddExecutor(executorStorage);

				logger.Debug("Registered new executor id=" + newExecutorId);

				return newExecutorId;
			}
		}

		/// <summary>
		/// Registers a new executor with the manager
		/// </summary>
		/// <param name="sc">security credentials used to perform this operation.</param>
		/// <param name="info">information about the executor (see ExecutorInfo)</param>
		/// <returns></returns>
        public string RegisterNew(SecurityCredentials sc, ExecutorInfo info)
        {
			return RegisterNew(sc, null, info);
        }

		/// <summary>
		/// Initialise the properties of this executor collection.
		/// This involves verfiying  the connection to all the dedicated executors in the database.
		/// </summary>
        public void Init()
        {
			logger.Debug("Init-ing executor collection from db");

			ExecutorStorageView[] executorsStorage = ManagerStorageFactory.ManagerStorage().GetExecutors(TriStateBoolean.True);

			logger.Debug("# of dedicated executors = " + executorsStorage.Length);

            foreach (ExecutorStorageView executorStorage in executorsStorage)
            {
                string executorId = executorStorage.ExecutorId;
                RemoteEndPoint ep = new RemoteEndPoint(executorStorage.HostName, executorStorage.Port, RemotingMechanism.TcpBinary);
                MExecutor me = new MExecutor(executorId);
				try
                {
					logger.Debug("Creating a MExecutor and connecting-dedicated to it");
                    me.ConnectDedicated(ep);
                }
                catch (Exception)
				{
					logger.Debug("Exception while init-ing exec.collection. Continuing with other executors...");
				}
            }

			logger.Debug("Executor collection init done");
        }

		/// <summary>
		/// Gets a collection containing all the available dedicated executors.
		/// This includes executors that satisfy all these conditions:
		/// - Are dedicated
		/// - Are connected
		/// - Don't have any threads Started or Scheduled
		/// </summary>
        public ExecutorStorageView[] AvailableDedicatedExecutors
        {
            get 
            {
				ArrayList executors = new ArrayList();

				IManagerStorage managerStorage = ManagerStorageFactory.ManagerStorage();

				ExecutorStorageView[] dedicatedConnectedExecutors = managerStorage.GetExecutors(TriStateBoolean.True,  TriStateBoolean.True);

            	foreach (ExecutorStorageView executor in dedicatedConnectedExecutors)
            	{
					bool executorHasNoThreadsScheduledOrStarted = (managerStorage.GetExecutorThreadCount(executor.ExecutorId, ThreadState.Scheduled, ThreadState.Started) == 0);
					if (executorHasNoThreadsScheduledOrStarted)
					{
						executors.Add(executor);
					}
				}

				return (ExecutorStorageView[])executors.ToArray(typeof(ExecutorStorageView));
            }
        }
    }
}