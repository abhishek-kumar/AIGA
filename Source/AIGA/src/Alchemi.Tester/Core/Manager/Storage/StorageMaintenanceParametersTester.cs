#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  StorageMaintenanceParametersTester.cs
* Project       :  Alchemi.Tester.Core.Manager.Storage
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
using System.Text;

using Alchemi.Core.Manager.Storage;
using Alchemi.Core.Owner;

using NUnit.Framework;

namespace Alchemi.Tester.Core.Manager.Storage
{
    [TestFixture]
    public class StorageMaintenanceParametersTester
    {

        [Test]
        public void ApplicationStatesToRemoveTestGettingItEmpty()
        {
            StorageMaintenanceParameters maintanenceParameters = new StorageMaintenanceParameters();

            // I want it to return a 0 length array rather than a null
            Assert.AreEqual(0, maintanenceParameters.ApplicationStatesToRemove.Length);
        }


        [Test]
        public void ApplicationTimeCompletedCutOffSetTestSettingIt()
        {
            StorageMaintenanceParameters maintanenceParameters = new StorageMaintenanceParameters();

            Assert.IsFalse(maintanenceParameters.ApplicationTimeCompletedCutOffSet);

            maintanenceParameters.ApplicationTimeCompletedCutOff = new TimeSpan(1, 0, 0);

            Assert.IsTrue(maintanenceParameters.ApplicationTimeCompletedCutOffSet);
        }

        [Test]
        public void ApplicationTimeCreatedCutOffSetTestSettingIt()
        {
            StorageMaintenanceParameters maintanenceParameters = new StorageMaintenanceParameters();

            Assert.IsFalse(maintanenceParameters.ApplicationTimeCreatedCutOffSet);

            maintanenceParameters.ApplicationTimeCreatedCutOff = new TimeSpan(1, 0, 0);

            Assert.IsTrue(maintanenceParameters.ApplicationTimeCreatedCutOffSet);
        }

        [Test]
        public void ExecutorPingTimeCutOffSetTestSettingIt()
        {
            StorageMaintenanceParameters maintanenceParameters = new StorageMaintenanceParameters();

            Assert.IsFalse(maintanenceParameters.ExecutorPingTimeCutOffSet);

            maintanenceParameters.ExecutorPingTimeCutOff = new TimeSpan(1, 0, 0);

            Assert.IsTrue(maintanenceParameters.ExecutorPingTimeCutOffSet);
        }

        [Test]
        public void AddApplicationStateToRemoveTestAddOne()
        {
            StorageMaintenanceParameters maintanenceParameters = new StorageMaintenanceParameters();

            maintanenceParameters.AddApplicationStateToRemove(ApplicationState.Ready);

            Assert.AreEqual(1, maintanenceParameters.ApplicationStatesToRemove.Length);
            Assert.AreEqual(ApplicationState.Ready, maintanenceParameters.ApplicationStatesToRemove[0]);
        }

        [Test]
        public void AddApplicationStatesToRemoveTestNull()
        {
            StorageMaintenanceParameters maintanenceParameters = new StorageMaintenanceParameters();

            maintanenceParameters.AddApplicationStatesToRemove(null);

            Assert.AreEqual(0, maintanenceParameters.ApplicationStatesToRemove.Length);
        }

        [Test]
        public void AddApplicationStatesToRemoveTestAddingFromArray()
        {
            StorageMaintenanceParameters maintanenceParameters = new StorageMaintenanceParameters();

            ApplicationState[] states = new ApplicationState[2];
            states[0] = ApplicationState.Ready;
            states[1] = ApplicationState.Stopped;

            maintanenceParameters.AddApplicationStatesToRemove(states);

            Assert.AreEqual(2, maintanenceParameters.ApplicationStatesToRemove.Length);
            Assert.AreEqual(ApplicationState.Ready, maintanenceParameters.ApplicationStatesToRemove[0]);
            Assert.AreEqual(ApplicationState.Stopped, maintanenceParameters.ApplicationStatesToRemove[1]);
        }

    }
}
