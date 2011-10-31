#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  ManagerContainerTester.cs
* Project       :  Alchemi.Tester.Manager
* Created on    :  08 November 2005
* Copyright     :  Copyright © 2006 The University of Melbourne
*                    This technology has been developed with the support of
*                    the Australian Research Council and the University of Melbourne
*                    research grants as part of the Gridbus Project
*                    within GRIDS Laboratory at the University of Melbourne, Australia.
* Author        :  Tibor Biro (tb@tbiro.com)
* License       :  GPL
*                    This program is free software; you can redistribute it and/or
*                    modify it under the terms of the GNU General Public
*                    License as published by the Free Software Foundation;
*                    See the GNU General Public License
*                    (http://www.gnu.org/copyleft/gpl.html) for more 
details.
*
*/
#endregion

using System;

using NUnit.Framework;

using Alchemi.Core;
using Alchemi.Core.Manager;
using Alchemi.Core.Manager.Storage;
using Alchemi.Manager;
using Alchemi.Manager.Storage;

namespace Alchemi.Tester.Manager
{
	/// <summary>
	/// Summary description for ManagerContainerTester.
	/// </summary>
	[TestFixture]
	public class ManagerContainerTester : ManagerContainer
	{
		private InMemoryManagerStorage m_managerStorage;

		[SetUp]
		public void SetUp()
		{
			m_managerStorage = new InMemoryManagerStorage();
			ManagerStorageFactory.SetManagerStorage(m_managerStorage);
		}

		[TearDown]
		public void TearDown()
		{
			m_managerStorage = null;
			ManagerStorageFactory.SetManagerStorage(null);
		}

		/// <summary>
		/// Add a few executors. 
		/// Disconnect all timed out executors.
		/// </summary>
		[Test]
		public void DisconnectTimedOutExecutorsTestSimpleScenario()
		{
			// add one that is OK
			ExecutorStorageView executor1 = new ExecutorStorageView(true, true, DateTime.Now, "hostname", 10, "username", 1, 1, 1, 1);
			// add one that is timed out
			ExecutorStorageView executor2 = new ExecutorStorageView(true, true, DateTime.Now.AddDays((-1)), "hostname", 10, "username", 1, 1, 1, 1);
			// add one that is not connected
			ExecutorStorageView executor3 = new ExecutorStorageView(false, false, DateTime.Now, "hostname", 10, "username", 1, 1, 1, 1);

			String executorId1 = m_managerStorage.AddExecutor(executor1);
			String executorId2 = m_managerStorage.AddExecutor(executor2);
			String executorId3 = m_managerStorage.AddExecutor(executor3);

			// whatever was not responsive in the last 60 seconds should get lost
			TimeSpan timeSpan = new TimeSpan(0, 0, 60);
			DisconnectTimedOutExecutors(timeSpan);
			
			// check what was disconnected

			Assert.IsTrue(m_managerStorage.GetExecutor(executorId1).Connected);
			Assert.IsFalse(m_managerStorage.GetExecutor(executorId2).Connected);
			Assert.IsFalse(m_managerStorage.GetExecutor(executorId3).Connected);
		}

		/// <summary>
		/// Add no executor. 
		/// Disconnect all timed out executors.
		/// Nothing should happen. No exception is expected and the executor count should stay at 0.
		/// </summary>
		[Test]
		public void DisconnectTimedOutExecutorsTestNoExecutors()
		{
			// whatever was not responsive in the last 60 seconds should get lost
			TimeSpan timeSpan = new TimeSpan(0, 0, 60);
			DisconnectTimedOutExecutors(timeSpan);
			
			Assert.AreEqual(0, m_managerStorage.GetExecutors().Length);
		}

	}
}
