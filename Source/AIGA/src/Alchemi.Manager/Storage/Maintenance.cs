#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  Maintenance.cs
* Project       :  Alchemi.Manager.Storage
* Created on    :  27 April 2006
* Copyright     :  Copyright © 2006 Tibor Biro (tb@tbiro.com)
* Author        :  Tibor Biro (tb@tbiro.com)
* License       :  GPL
*                    This program is free software; you can redistribute it and/or
*                    modify it under the terms of the GNU General Public
*                    License as published by the Free Software Foundation;
*                    See the GNU General Public License
*                    (http://www.gnu.org/copyleft/gpl.html) for more details.
*
*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;

using Alchemi.Core;
using Alchemi.Core.Owner;
using Alchemi.Core.Manager.Storage;

namespace Alchemi.Manager.Storage
{
    /// <summary>
    /// Implement storage maintenance routines such as:
    /// 
    /// Removing old applications and threads
    /// Removing old executors
    /// </summary>
    public class Maintenance
    {
        /// <summary>
        /// Remove applications that have the given application state
        /// This will also remove the threads associated with these applications
        /// </summary>
        /// <param name="storage">Target storage where this maintanance will be performed.</param>
        /// <param name="applicationStates"></param>
        public void RemoveApplications(IManagerStorage storage, params ApplicationState[] applicationStates)
        {
            if (applicationStates == null || applicationStates.Length == 0)
            {
                return;
            }

            ApplicationStorageView[] applications = storage.GetApplications();
            foreach (ApplicationStorageView application in applications)
            {
                int stateIndex;

                stateIndex = Array.IndexOf<ApplicationState>(applicationStates, application.State);

                if (stateIndex >= 0)
                {
                    storage.DeleteApplication(application);
                }
            }
        }

        /// <summary>
        /// Remove all applications that were submitted before the given cut-off date.
        /// </summary>
        /// <param name="storage">Target storage where this maintanance will be performed.</param>
        /// <param name="timeCreatedCutOff"></param>
        public void RemoveApplications(IManagerStorage storage, DateTime timeCreatedCutOff)
        {
            ApplicationStorageView[] applications = storage.GetApplications();
            foreach (ApplicationStorageView application in applications)
            {
                if (application.TimeCreated < timeCreatedCutOff)
                {
                    storage.DeleteApplication(application);
                }
            }
        }

        /// <summary>
        /// Remove all applications what were submitted before the given time span
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="cutOff"></param>
        public void RemoveApplications(IManagerStorage storage, TimeSpan cutOff)
        {
            DateTime timeCreatedCutOff = DateTime.Now.Subtract(cutOff);

            RemoveApplications(storage, timeCreatedCutOff);
        }

        /// <summary>
        /// Remove all applications from storage.
        /// </summary>
        /// <param name="storage">Target storage where this maintanance will be performed.</param>
        public void RemoveAllApplications(IManagerStorage storage)
        {
            ApplicationStorageView[] applications = storage.GetApplications();

            foreach (ApplicationStorageView application in applications)
            {
                storage.DeleteApplication(application);
            }
        }

        /// <summary>
        /// Remove all executors that have not been pinged since the given time.
        /// </summary>
        /// <param name="storage">Target storage where this maintanance will be performed.</param>
        /// <param name="pingTimeCutOff"></param>
        public void RemoveExecutors(IManagerStorage storage, DateTime pingTimeCutOff)
        {
            ExecutorStorageView[] executors = storage.GetExecutors();

            foreach (ExecutorStorageView executor in executors)
            {
                if (executor.PingTime < pingTimeCutOff)
                {
                    storage.DeleteExecutor(executor);
                }
            }
        }

        /// <summary>
        /// Remove all executors that have not been pinged in the given time span
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="cutOff"></param>
        public void RemoveExecutors(IManagerStorage storage, TimeSpan cutOff)
        {
            DateTime pingTimeCutOff = DateTime.Now.Subtract(cutOff);

            RemoveExecutors(storage, pingTimeCutOff);
        }

        /// <summary>
        /// Remove all executors from storage.
        /// 
        /// </summary>
        /// <remarks>
        /// Q: What to do with applications that have running threads on any of the executors?
        /// A: This is a storage level function so we cannot stop the applications on the executors from here. 
        /// </remarks>
        /// <param name="storage">Target storage where this maintanance will be performed.</param>
        public void RemoveAllExecutors(IManagerStorage storage)
        {
            ExecutorStorageView[] executors = storage.GetExecutors();

            foreach (ExecutorStorageView executor in executors)
            {
                storage.DeleteExecutor(executor);
            }
        }

        /// <summary>
        /// Perform various maintenance actions as defined in the maintenance parameters.
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="maintenanceParameters"></param>
        public void PerformMaintenance(IManagerStorage storage, StorageMaintenanceParameters maintenanceParameters)
        {
            RemoveApplications(storage, maintenanceParameters.ApplicationStatesToRemove);

            if (maintenanceParameters.RemoveAllApplications)
            {
                RemoveAllApplications(storage);
            }

            if (maintenanceParameters.RemoveAllExecutors)
            {
                RemoveAllExecutors(storage);
            }

            if (maintenanceParameters.ApplicationTimeCreatedCutOffSet)
            {
                RemoveApplications(storage, maintenanceParameters.ApplicationTimeCreatedCutOff);
            }

            if (maintenanceParameters.ExecutorPingTimeCutOffSet)
            {
                RemoveExecutors(storage, maintenanceParameters.ExecutorPingTimeCutOff);
            }

            if (maintenanceParameters.ApplicationTimeCompletedCutOffSet)
            {
                DateTime timeCompletedCutOff = DateTime.Now.Subtract(maintenanceParameters.ApplicationTimeCompletedCutOff);

                ApplicationStorageView[] applications = storage.GetApplications();
                foreach (ApplicationStorageView application in applications)
                {
                    if (application.TimeCompletedSet && application.TimeCompleted < timeCompletedCutOff)
                    {
                        storage.DeleteApplication(application);
                    }
                }
            }
        }

    }
}
