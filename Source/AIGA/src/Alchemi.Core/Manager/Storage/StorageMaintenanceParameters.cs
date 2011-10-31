#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  StorageMaintenanceParameters.cs
* Project       :  Alchemi.Core.Manager.Storage
* Created on    :  05 May 2006
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
using System.Collections;
using System.Text;

using Alchemi.Core.Owner;

namespace Alchemi.Core.Manager.Storage
{
    /// <summary>
    /// Parameters passed to the Maintenance class to perform storage maintenance tasks.
    /// </summary>
    [Serializable]
    public class StorageMaintenanceParameters
    {
        // Application maintenance parameters

        private TimeSpan m_applicationTimeCreatedCutOff;
        private bool m_applicationTimeCreatedCutOffSet = false;

        private TimeSpan m_applicationTimeCompletedCutOff;
        private bool m_applicationTimeCompletedCutOffSet = false;

        private ArrayList m_applicationStatesToRemove;

        private bool m_removeAllApplications = false;

        // Executor maintenance parameters

        private TimeSpan m_executorPingTimeCutOff;

        private bool m_executorPingTimeCutOffSet = false;

        private bool m_removeAllExecutors = false;

        #region Field encapsulations into properties

        public TimeSpan ApplicationTimeCreatedCutOff
        {
            get { return m_applicationTimeCreatedCutOff; }
            
            set 
            { 
                m_applicationTimeCreatedCutOff = value;
                m_applicationTimeCreatedCutOffSet = true;
            }
        }

        public bool ApplicationTimeCreatedCutOffSet
        {
            get { return m_applicationTimeCreatedCutOffSet; }
        }

        public TimeSpan ApplicationTimeCompletedCutOff
        {
            get { return m_applicationTimeCompletedCutOff; }
            set 
            { 
                m_applicationTimeCompletedCutOff = value;
                m_applicationTimeCompletedCutOffSet = true;
            }
        }

        public bool ApplicationTimeCompletedCutOffSet
        {
            get { return m_applicationTimeCompletedCutOffSet; }
        }

        public ApplicationState[] ApplicationStatesToRemove
        {
            get 
            {
                if (m_applicationStatesToRemove == null)
                {
                    m_applicationStatesToRemove = new ArrayList();
                }

                return (ApplicationState[])m_applicationStatesToRemove.ToArray(typeof(ApplicationState));
            }
        }

        public bool RemoveAllApplications
        {
            get { return m_removeAllApplications; }
            set { m_removeAllApplications = value; }
        }

        public TimeSpan ExecutorPingTimeCutOff
        {
            get { return m_executorPingTimeCutOff; }
            set 
            { 
                m_executorPingTimeCutOff = value;
                m_executorPingTimeCutOffSet = true;
            }
        }

        public bool ExecutorPingTimeCutOffSet
        {
            get { return m_executorPingTimeCutOffSet; }
        }

        public bool RemoveAllExecutors
        {
            get { return m_removeAllExecutors; }
            set { m_removeAllExecutors = value; }
        }

        #endregion

        public void AddApplicationStateToRemove(ApplicationState stateToAdd)
        {
            if (m_applicationStatesToRemove == null)
            {
                m_applicationStatesToRemove = new ArrayList();
            }

            m_applicationStatesToRemove.Add(stateToAdd);
        }

        public void AddApplicationStatesToRemove(IEnumerable<ApplicationState> enumerable)
        {
            if (enumerable == null)
            {
                return;
            }

            IEnumerator<ApplicationState> enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                AddApplicationStateToRemove(enumerator.Current);
            }
        }

    }
}
