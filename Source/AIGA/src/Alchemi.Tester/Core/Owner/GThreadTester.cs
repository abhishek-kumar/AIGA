#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  GThreadTester.cs
* Project       :  Alchemi.Tester.Core.Owner
* Created on    :  19 April 2006
* Copyright     :  Copyright © 2006 Tibor Biro (tb@tbiro.com)
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
using System.Collections.Generic;
using System.Text;

using Alchemi.Core.Owner;

using NUnit.Framework;

namespace Alchemi.Tester.Core.Owner
{
    [TestFixture]
    public class GThreadTester
    {
        #region "SetId tests"

        [Test]
        public void SetIdTestSimpleScenario()
        {
            Int32 threadId = 324;

            GThread thread = new GThreadMock();

            thread.SetId(threadId);

            Assert.AreEqual(threadId, thread.Id);
        }

        #endregion

        #region "SetWorkingDirectory tests"

        [Test]
        public void SetWorkingDirectoryTestSimpleScenario()
        {
            String workingDirectory = @"C:\";

            GThreadMock threadFiller = new GThreadMock();
            GThread thread = threadFiller;

            thread.SetWorkingDirectory(workingDirectory);

            Assert.AreEqual(workingDirectory, threadFiller.GetWorkingDirectory());
        }

        #endregion


        #region "SetApplication tests"

        [Test]
        public void SetApplicationTestSimpleScenario()
        {
            GApplication application = new GApplication();

            GThread thread = new GThreadMock();

            thread.SetApplication(application);

            Assert.AreSame(application, thread.Application);
        }

        #endregion

        #region "Priority tests"

        [Test]
        public void SetPriorityTestSimpleScenario()
        {
            Int32 priority = 123;

            GThread thread = new GThreadMock();

            thread.Priority = priority;

            Assert.AreEqual(priority, thread.Priority);
        }

        #endregion

        #region "State tests"

        [Test]
        public void SetStateTestSimpleScenario()
        {
            GApplicationMock application = new GApplicationMock();

            GThreadMock thread = new GThreadMock();

            // NOTE: In fact, this exercises the State implementation found in GThreadMock
            thread.SetState(ThreadState.Scheduled);

            Assert.AreEqual(ThreadState.Scheduled, thread.State);
        }

        #endregion

    }
}
