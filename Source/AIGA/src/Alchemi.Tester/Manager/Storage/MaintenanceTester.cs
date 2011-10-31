#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  MaintenanceTester.cs
* Project       :  Alchemi.Tester.Manager.Storage
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

using NUnit.Framework;

using Alchemi.Manager.Storage;
using Alchemi.Core.Manager.Storage;
using Alchemi.Core.Owner;

namespace Alchemi.Tester.Manager.Storage
{
    [TestFixture]
    public class MaintenanceTester
    {
        InMemoryManagerStorage m_managerStorage = null;

        [SetUp]
        public void SetUp()
        {
            m_managerStorage = new InMemoryManagerStorage();
        }

        [TearDown]
        public void TearDown()
        {
            m_managerStorage = null;
        }

        /// <summary>
        /// Add all kinds of objects to the storage so the maintenance functions have something to play with.
        /// </summary>
        private void PrepareComplexStorageForMaintenanceTests()
        {
            DateTime pingTime = DateTime.Now;

            m_managerStorage.AddExecutor(new ExecutorStorageView(true, true, pingTime.AddDays(-1), "hostname", 1, "username", 1, 2, 3, 4));
            m_managerStorage.AddExecutor(new ExecutorStorageView(false, true, pingTime.AddDays(2), "hostname", 1, "username", 1, 2, 3, 4));
            m_managerStorage.AddExecutor(new ExecutorStorageView(true, false, pingTime.AddDays(1), "hostname", 1, "username", 1, 2, 3, 4));
            m_managerStorage.AddExecutor(new ExecutorStorageView(false, false, pingTime.AddDays(-2), "hostname", 1, "username", 1, 2, 3, 4));

            DateTime timeCreated = DateTime.Now;

            ApplicationStorageView application1;
            ApplicationStorageView application2;
            ApplicationStorageView application3;
            ApplicationStorageView application4;
            ApplicationStorageView application5;

            application1 = new ApplicationStorageView(ApplicationState.AwaitingManifest, timeCreated.AddDays(-5), false, "username1");
            application2 = new ApplicationStorageView(ApplicationState.Stopped, timeCreated.AddDays(-4), false, "username1");
            application3 = new ApplicationStorageView(ApplicationState.Ready, timeCreated.AddDays(1), false, "username1");
            application4 = new ApplicationStorageView(ApplicationState.AwaitingManifest, timeCreated.AddDays(-3), false, "username1");
            application5 = new ApplicationStorageView(ApplicationState.Stopped, timeCreated.AddDays(2), false, "username1");

            // leave time completed not set for application1 to test that scenario as well
            application2.TimeCompleted = DateTime.Now.AddDays(-4);
            application3.TimeCompleted = DateTime.Now.AddDays(2);
            application4.TimeCompleted = DateTime.Now.AddDays(-3);
            application5.TimeCompleted = DateTime.Now.AddDays(3);

            m_managerStorage.AddApplication(application1);
            m_managerStorage.AddApplication(application2);
            m_managerStorage.AddApplication(application3);
            m_managerStorage.AddApplication(application4);
            m_managerStorage.AddApplication(application5);
        
        }

        #region "RemoveApplications tests"

        [Test]
        public void RemoveApplicationsByApplicationStateTestNothingToRemove()
        {
            Maintenance maintenance = new Maintenance();

            Assert.AreEqual(0, m_managerStorage.GetApplications().Length);

            maintenance.RemoveApplications(m_managerStorage);

            Assert.AreEqual(0, m_managerStorage.GetApplications().Length);
        }

        [Test]
        public void RemoveApplicationsByApplicationStateTestRemoveNonExistingState()
        {
            Maintenance maintenance = new Maintenance();

            m_managerStorage.AddApplication(new ApplicationStorageView(ApplicationState.AwaitingManifest, DateTime.Now, false, "username1"));

            Assert.AreEqual(1, m_managerStorage.GetApplications().Length);

            maintenance.RemoveApplications(m_managerStorage, ApplicationState.Stopped);

            Assert.AreEqual(1, m_managerStorage.GetApplications().Length);
        }

        [Test]
        public void RemoveApplicationsByApplicationStateTestRemoveOneExistingState()
        {
            Maintenance maintenance = new Maintenance();

            m_managerStorage.AddApplication(new ApplicationStorageView(ApplicationState.AwaitingManifest, DateTime.Now, false, "username1"));
            m_managerStorage.AddApplication(new ApplicationStorageView(ApplicationState.Stopped, DateTime.Now, false, "username1"));

            Assert.AreEqual(2, m_managerStorage.GetApplications().Length);

            maintenance.RemoveApplications(m_managerStorage, ApplicationState.Stopped);

            Assert.AreEqual(1, m_managerStorage.GetApplications().Length);
        }

        [Test]
        public void RemoveApplicationsByApplicationStateTestRemoveMultipleExistingStates()
        {
            Maintenance maintenance = new Maintenance();

            m_managerStorage.AddApplication(new ApplicationStorageView(ApplicationState.AwaitingManifest, DateTime.Now, false, "username1"));
            m_managerStorage.AddApplication(new ApplicationStorageView(ApplicationState.Stopped, DateTime.Now, false, "username1"));
            m_managerStorage.AddApplication(new ApplicationStorageView(ApplicationState.Ready, DateTime.Now, false, "username1"));
            m_managerStorage.AddApplication(new ApplicationStorageView(ApplicationState.AwaitingManifest, DateTime.Now, false, "username1"));
            m_managerStorage.AddApplication(new ApplicationStorageView(ApplicationState.Stopped, DateTime.Now, false, "username1"));

            Assert.AreEqual(5, m_managerStorage.GetApplications().Length);

            maintenance.RemoveApplications(m_managerStorage, ApplicationState.Stopped, ApplicationState.Ready);

            Assert.AreEqual(2, m_managerStorage.GetApplications().Length);
        }

        [Test]
        public void RemoveApplicationsByTimeCreatedTestNothingToRemove()
        {
            Maintenance maintenance = new Maintenance();

            Assert.AreEqual(0, m_managerStorage.GetApplications().Length);

            maintenance.RemoveApplications(m_managerStorage, DateTime.Now);

            Assert.AreEqual(0, m_managerStorage.GetApplications().Length);
        }

        [Test]
        public void RemoveApplicationsByTimeCreatedTestRemoveNonExistingDates()
        {
            Maintenance maintenance = new Maintenance();
            DateTime timeCreated = DateTime.Now;

            m_managerStorage.AddApplication(new ApplicationStorageView(ApplicationState.AwaitingManifest, timeCreated, false, "username1"));

            Assert.AreEqual(1, m_managerStorage.GetApplications().Length);

            maintenance.RemoveApplications(m_managerStorage, timeCreated.AddDays(-1));

            Assert.AreEqual(1, m_managerStorage.GetApplications().Length);
        }

        [Test]
        public void RemoveApplicationsByTimeCreatedTestRemoveMultipleOldApplications()
        {
            Maintenance maintenance = new Maintenance();

            DateTime timeCreated = DateTime.Now;

            m_managerStorage.AddApplication(new ApplicationStorageView(ApplicationState.AwaitingManifest, timeCreated.AddDays(-5), false, "username1"));
            m_managerStorage.AddApplication(new ApplicationStorageView(ApplicationState.Stopped, timeCreated.AddDays(-4), false, "username1"));
            m_managerStorage.AddApplication(new ApplicationStorageView(ApplicationState.Ready, timeCreated.AddDays(1), false, "username1"));
            m_managerStorage.AddApplication(new ApplicationStorageView(ApplicationState.AwaitingManifest, timeCreated.AddDays(-3), false, "username1"));
            m_managerStorage.AddApplication(new ApplicationStorageView(ApplicationState.Stopped, timeCreated.AddDays(2), false, "username1"));

            Assert.AreEqual(5, m_managerStorage.GetApplications().Length);

            maintenance.RemoveApplications(m_managerStorage, timeCreated);

            Assert.AreEqual(2, m_managerStorage.GetApplications().Length);
        }

        [Test]
        public void RemoveApplicationsByTimeCreatedSpanTestNothingToRemove()
        {
            Maintenance maintenance = new Maintenance();

            Assert.AreEqual(0, m_managerStorage.GetApplications().Length);

            maintenance.RemoveApplications(m_managerStorage, new TimeSpan(1000));

            Assert.AreEqual(0, m_managerStorage.GetApplications().Length);
        }

        [Test]
        public void RemoveApplicationsByTimeCreatedSpanTestRemoveNonExistingDates()
        {
            Maintenance maintenance = new Maintenance();
            DateTime timeCreated = DateTime.Now;

            m_managerStorage.AddApplication(new ApplicationStorageView(ApplicationState.AwaitingManifest, timeCreated, false, "username1"));

            Assert.AreEqual(1, m_managerStorage.GetApplications().Length);

            // one hour should be enough to avoid removing this one.
            maintenance.RemoveApplications(m_managerStorage, new TimeSpan(1, 0, 0));

            Assert.AreEqual(1, m_managerStorage.GetApplications().Length);
        }

        [Test]
        public void RemoveApplicationsByTimeCreatedSpanTestRemoveMultipleOldApplications()
        {
            Maintenance maintenance = new Maintenance();

            DateTime timeCreated = DateTime.Now;

            m_managerStorage.AddApplication(new ApplicationStorageView(ApplicationState.AwaitingManifest, timeCreated.AddDays(-5), false, "username1"));
            m_managerStorage.AddApplication(new ApplicationStorageView(ApplicationState.Stopped, timeCreated.AddDays(-4), false, "username1"));
            m_managerStorage.AddApplication(new ApplicationStorageView(ApplicationState.Ready, timeCreated.AddDays(1), false, "username1"));
            m_managerStorage.AddApplication(new ApplicationStorageView(ApplicationState.AwaitingManifest, timeCreated.AddDays(-3), false, "username1"));
            m_managerStorage.AddApplication(new ApplicationStorageView(ApplicationState.Stopped, timeCreated.AddDays(2), false, "username1"));

            Assert.AreEqual(5, m_managerStorage.GetApplications().Length);

            // put a 20 hour cut-off, this should remove 3 of the applications
            maintenance.RemoveApplications(m_managerStorage, new TimeSpan(20, 0, 0));

            Assert.AreEqual(2, m_managerStorage.GetApplications().Length);
        }

        #endregion

        #region "RemoveAllApplications tests"

        [Test]
        public void RemoveAllApplicationsTestNothingToRemove()
        {
            Maintenance maintenance = new Maintenance();

            Assert.AreEqual(0, m_managerStorage.GetApplications().Length);

            maintenance.RemoveAllApplications(m_managerStorage);

            Assert.AreEqual(0, m_managerStorage.GetApplications().Length);
        }

        [Test]
        public void RemoveAllApplicationsTestRemovingMultiple()
        {
            Maintenance maintenance = new Maintenance();

            m_managerStorage.AddApplication(new ApplicationStorageView(ApplicationState.AwaitingManifest, DateTime.Now, false, "username1"));
            m_managerStorage.AddApplication(new ApplicationStorageView(ApplicationState.Stopped, DateTime.Now, false, "username1"));
            m_managerStorage.AddApplication(new ApplicationStorageView(ApplicationState.Ready, DateTime.Now, false, "username1"));
            m_managerStorage.AddApplication(new ApplicationStorageView(ApplicationState.AwaitingManifest, DateTime.Now, false, "username1"));
            m_managerStorage.AddApplication(new ApplicationStorageView(ApplicationState.Stopped, DateTime.Now, false, "username1"));

            Assert.AreEqual(5, m_managerStorage.GetApplications().Length);

            maintenance.RemoveAllApplications(m_managerStorage);

            Assert.AreEqual(0, m_managerStorage.GetApplications().Length);
        }

        #endregion

        #region "RemoveExecutors tests"

        [Test]
        public void RemoveExecutorsByPingTimeTestNothingToRemove()
        {
            Maintenance maintenance = new Maintenance();

            Assert.AreEqual(0, m_managerStorage.GetExecutors().Length);

            maintenance.RemoveExecutors(m_managerStorage, DateTime.Now);

            Assert.AreEqual(0, m_managerStorage.GetExecutors().Length);
        }

        [Test]
        public void RemoveExecutorsByPingTimeTestRemoveNonExistingDates()
        {
            Maintenance maintenance = new Maintenance();
            DateTime pingTime = DateTime.Now;

            m_managerStorage.AddExecutor(new ExecutorStorageView(true, true, pingTime, "hostname", 1, "username", 1, 2, 3, 4));

            Assert.AreEqual(1, m_managerStorage.GetExecutors().Length);

            maintenance.RemoveExecutors(m_managerStorage, pingTime.AddDays(-1));

            Assert.AreEqual(1, m_managerStorage.GetExecutors().Length);
        }

        [Test]
        public void RemoveExecutorsByPingTimeTestRemoveMultipleOldApplications()
        {
            Maintenance maintenance = new Maintenance();

            DateTime pingTime = DateTime.Now;

            m_managerStorage.AddExecutor(new ExecutorStorageView(true, true, pingTime.AddDays(-1), "hostname", 1, "username", 1, 2, 3, 4));
            m_managerStorage.AddExecutor(new ExecutorStorageView(false, true, pingTime.AddDays(2), "hostname", 1, "username", 1, 2, 3, 4));
            m_managerStorage.AddExecutor(new ExecutorStorageView(true, false, pingTime.AddDays(1), "hostname", 1, "username", 1, 2, 3, 4));
            m_managerStorage.AddExecutor(new ExecutorStorageView(false, false, pingTime.AddDays(-2), "hostname", 1, "username", 1, 2, 3, 4));

            Assert.AreEqual(4, m_managerStorage.GetExecutors().Length);

            maintenance.RemoveExecutors(m_managerStorage, pingTime);

            Assert.AreEqual(2, m_managerStorage.GetExecutors().Length);
        }

        [Test]
        public void RemoveExecutorsByPingTimeSpanTestNothingToRemove()
        {
            Maintenance maintenance = new Maintenance();

            Assert.AreEqual(0, m_managerStorage.GetExecutors().Length);

            maintenance.RemoveExecutors(m_managerStorage, new TimeSpan(1000));

            Assert.AreEqual(0, m_managerStorage.GetExecutors().Length);
        }

        [Test]
        public void RemoveExecutorsByPingTimeSpanTestRemoveNonExistingDates()
        {
            Maintenance maintenance = new Maintenance();
            DateTime pingTime = DateTime.Now;

            m_managerStorage.AddExecutor(new ExecutorStorageView(true, true, pingTime, "hostname", 1, "username", 1, 2, 3, 4));

            Assert.AreEqual(1, m_managerStorage.GetExecutors().Length);

            maintenance.RemoveExecutors(m_managerStorage, new TimeSpan(1, 0, 0));

            Assert.AreEqual(1, m_managerStorage.GetExecutors().Length);
        }

        [Test]
        public void RemoveExecutorsByPingTimeSpanTestRemoveMultipleOldApplications()
        {
            Maintenance maintenance = new Maintenance();

            DateTime pingTime = DateTime.Now;

            m_managerStorage.AddExecutor(new ExecutorStorageView(true, true, pingTime.AddDays(-1), "hostname", 1, "username", 1, 2, 3, 4));
            m_managerStorage.AddExecutor(new ExecutorStorageView(false, true, pingTime.AddDays(2), "hostname", 1, "username", 1, 2, 3, 4));
            m_managerStorage.AddExecutor(new ExecutorStorageView(true, false, pingTime.AddDays(1), "hostname", 1, "username", 1, 2, 3, 4));
            m_managerStorage.AddExecutor(new ExecutorStorageView(false, false, pingTime.AddDays(-2), "hostname", 1, "username", 1, 2, 3, 4));

            Assert.AreEqual(4, m_managerStorage.GetExecutors().Length);

            maintenance.RemoveExecutors(m_managerStorage, new TimeSpan(20, 0, 0));

            Assert.AreEqual(2, m_managerStorage.GetExecutors().Length);
        }

        #endregion

        #region "RemoveAllExecutors tests"

        [Test]
        public void RemoveAllExecutorsTestNothingToRemove()
        {
            Maintenance maintenance = new Maintenance();

            Assert.AreEqual(0, m_managerStorage.GetExecutors().Length);

            maintenance.RemoveAllExecutors(m_managerStorage);

            Assert.AreEqual(0, m_managerStorage.GetExecutors().Length);
        }

        [Test]
        public void RemoveAllExecutorsTestRemovingMultiple()
        {
            Maintenance maintenance = new Maintenance();

            m_managerStorage.AddExecutor(new ExecutorStorageView(true, true, DateTime.Now, "hostname", 123, "username", 0, 0, 0, 0));
            m_managerStorage.AddExecutor(new ExecutorStorageView(true, false, DateTime.Now, "hostname", 4543, "username", 1, 2, 3, 4));
            m_managerStorage.AddExecutor(new ExecutorStorageView(false, true, DateTime.Now, "hostname", 1, "username", 0, 0, 7, 0));
            m_managerStorage.AddExecutor(new ExecutorStorageView(false, false, DateTime.Now, "hostname", 33, "username", 0, 4, 0, 0));

            Assert.AreEqual(4, m_managerStorage.GetExecutors().Length);

            maintenance.RemoveAllExecutors(m_managerStorage);

            Assert.AreEqual(0, m_managerStorage.GetExecutors().Length);
        }

        #endregion

        #region "PerformMaintenance tests"

        [Test]
        public void PerformMaintenanceTestRemoveAllExecutors()
        {
            Maintenance maintenance = new Maintenance();
            StorageMaintenanceParameters maintenanceParameters = new StorageMaintenanceParameters();

            maintenanceParameters.RemoveAllExecutors = true;

            PrepareComplexStorageForMaintenanceTests();

            maintenance.PerformMaintenance(m_managerStorage, maintenanceParameters);

            Assert.AreEqual(0, m_managerStorage.GetExecutors().Length);
            Assert.AreEqual(5, m_managerStorage.GetApplications().Length);
        }

        [Test]
        public void PerformMaintenanceTestRemoveExecutorsByPingTime()
        {
            Maintenance maintenance = new Maintenance();
            StorageMaintenanceParameters maintenanceParameters = new StorageMaintenanceParameters();

            maintenanceParameters.ExecutorPingTimeCutOff = new TimeSpan(20, 0, 0);

            PrepareComplexStorageForMaintenanceTests();

            maintenance.PerformMaintenance(m_managerStorage, maintenanceParameters);

            Assert.AreEqual(2, m_managerStorage.GetExecutors().Length);
            Assert.AreEqual(5, m_managerStorage.GetApplications().Length);
        }

        [Test]
        public void PerformMaintenanceTestRemoveAllApplications()
        {
            Maintenance maintenance = new Maintenance();
            StorageMaintenanceParameters maintenanceParameters = new StorageMaintenanceParameters();

            maintenanceParameters.RemoveAllApplications = true;

            PrepareComplexStorageForMaintenanceTests();

            maintenance.PerformMaintenance(m_managerStorage, maintenanceParameters);

            Assert.AreEqual(4, m_managerStorage.GetExecutors().Length);
            Assert.AreEqual(0, m_managerStorage.GetApplications().Length);
        }

        [Test]
        public void PerformMaintenanceTestRemoveApplicationsByTimeCreated()
        {
            Maintenance maintenance = new Maintenance();
            StorageMaintenanceParameters maintenanceParameters = new StorageMaintenanceParameters();

            maintenanceParameters.ApplicationTimeCreatedCutOff = new TimeSpan(20, 0, 0);

            PrepareComplexStorageForMaintenanceTests();

            maintenance.PerformMaintenance(m_managerStorage, maintenanceParameters);

            Assert.AreEqual(4, m_managerStorage.GetExecutors().Length);
            Assert.AreEqual(2, m_managerStorage.GetApplications().Length);
        }

        [Test]
        public void PerformMaintenanceTestRemoveApplicationsByTimeCompleted()
        {
            Maintenance maintenance = new Maintenance();
            StorageMaintenanceParameters maintenanceParameters = new StorageMaintenanceParameters();

            maintenanceParameters.ApplicationTimeCompletedCutOff = new TimeSpan(20, 0, 0);

            PrepareComplexStorageForMaintenanceTests();

            maintenance.PerformMaintenance(m_managerStorage, maintenanceParameters);

            Assert.AreEqual(4, m_managerStorage.GetExecutors().Length);
            // we should have left the one that didn't have the time completed set
            // and 2 more that were not in the cut-off range
            Assert.AreEqual(3, m_managerStorage.GetApplications().Length);
        }

        [Test]
        public void PerformMaintenanceTestRemoveApplicationByState()
        {
            Maintenance maintenance = new Maintenance();
            StorageMaintenanceParameters maintenanceParameters = new StorageMaintenanceParameters();

            maintenanceParameters.AddApplicationStateToRemove(ApplicationState.AwaitingManifest);
            maintenanceParameters.AddApplicationStateToRemove(ApplicationState.Ready);

            PrepareComplexStorageForMaintenanceTests();

            maintenance.PerformMaintenance(m_managerStorage, maintenanceParameters);

            Assert.AreEqual(4, m_managerStorage.GetExecutors().Length);
            Assert.AreEqual(2, m_managerStorage.GetApplications().Length);
        }

        [Test]
        public void PerformMaintenanceTestNothingToRemove()
        {
            Maintenance maintenance = new Maintenance();
            StorageMaintenanceParameters maintenanceParameters = new StorageMaintenanceParameters();

            PrepareComplexStorageForMaintenanceTests();

            maintenance.PerformMaintenance(m_managerStorage, maintenanceParameters);

            Assert.AreEqual(4, m_managerStorage.GetExecutors().Length);
            Assert.AreEqual(5, m_managerStorage.GetApplications().Length);
        }


        [Test]
        public void PerformMaintenanceTestNullStorageMaintenanceParameters()
        {
            Maintenance maintenance = new Maintenance();
            StorageMaintenanceParameters maintenanceParameters = null;

            PrepareComplexStorageForMaintenanceTests();

            try
            {
                maintenance.PerformMaintenance(m_managerStorage, maintenanceParameters);
            }
            catch (NullReferenceException)
            {
                // expecting to get this
                return;
            }

            Assert.Fail("This should have thrown a NullReferenceException");
        }

        [Test]
        public void PerformMaintenanceTestMultipleParameters()
        {
            Maintenance maintenance = new Maintenance();
            StorageMaintenanceParameters maintenanceParameters = new StorageMaintenanceParameters();

            maintenanceParameters.AddApplicationStateToRemove(ApplicationState.AwaitingManifest);
            maintenanceParameters.ExecutorPingTimeCutOff = new TimeSpan(20, 0, 0);

            PrepareComplexStorageForMaintenanceTests();

            maintenance.PerformMaintenance(m_managerStorage, maintenanceParameters);

            Assert.AreEqual(2, m_managerStorage.GetExecutors().Length);
            Assert.AreEqual(3, m_managerStorage.GetApplications().Length);
        }

        #endregion
    }
}
