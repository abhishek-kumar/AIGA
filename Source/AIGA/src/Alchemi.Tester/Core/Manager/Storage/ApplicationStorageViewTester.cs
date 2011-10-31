#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  ApplicationStorageViewTester.cs
* Project       :  Alchemi.Tester.Core.Manager.Storage
* Created on    :  22 October 2005
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

using Alchemi.Core.Manager.Storage;
using Alchemi.Core.Owner;

using NUnit.Framework;

namespace Alchemi.Tester.Core.Manager.Storage
{
	/// <summary>
	/// Test constrains devined on the ApplicationStorageView object.
	/// </summary>
	[TestFixture]
	public class ApplicationStorageViewTester
	{
		/// <summary>
		/// Try to get the TotalThreads value when it was not initialized
		/// It should throw an exception.
		/// </summary>
		[Test]
		public void TotalThreadsTestNotSet()
		{
			ApplicationStorageView application = new ApplicationStorageView("username1");

			try
			{
				Int32 result = application.TotalThreads;
			}
			catch
			{
				// exception expected
				return;
			}

			Assert.Fail("An exception was expected");
		}

		/// <summary>
		/// Try to get the UnfinishedThreads value when it was not initialized
		/// It should throw an exception.
		/// </summary>
		[Test]
		public void UnfinishedThreadsTestNotSet()
		{
			ApplicationStorageView application = new ApplicationStorageView("username1");

			try
			{
				Int32 result = application.UnfinishedThreads;
			}
			catch
			{
				// exception expected
				return;
			}

			Assert.Fail("An exception was expected");
		}

        [Test]
        public void TimeCreatedSetTestSettingIt()
        {
            ApplicationStorageView application = new ApplicationStorageView("username1");

            Assert.IsFalse(application.TimeCreatedSet);

            application = new ApplicationStorageView(ApplicationState.AwaitingManifest, DateTime.Now, false, "username1");

            Assert.IsTrue(application.TimeCreatedSet);
        }

        [Test]
        public void TimeCompletedSetTestSettingIt()
        {
            ApplicationStorageView application = new ApplicationStorageView("username1");

            Assert.IsFalse(application.TimeCompletedSet);

            application.TimeCompleted = DateTime.Now;

            Assert.IsTrue(application.TimeCompletedSet);

        }
	
	}
}
