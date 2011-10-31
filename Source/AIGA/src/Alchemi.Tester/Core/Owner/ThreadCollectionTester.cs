#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  ThreadCollectionTester.cs
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
    public class ThreadCollectionTester
    {
        #region "Remove tests"
        
        [Test]
        public void RemoveTestEmptyCollection()
        {
            ThreadCollection tc = new ThreadCollection();
            GThreadMock threadToRemove = new GThreadMock();

            tc.Remove(threadToRemove);

            // if we get this far then there was no exception so we are happy
            Assert.IsTrue(true);
        }

        [Test]
        public void RemoveTestNullThreadToRemove()
        {
            ThreadCollection tc = new ThreadCollection();
            GThreadMock threadToRemove = null;

            tc.Remove(threadToRemove);

            // if we get this far then there was no exception so we are happy
            Assert.IsTrue(true);
        }

        [Test]
        public void RemoveTestRemoveExistingDeadOrFinishedThread()
        {
            ThreadCollection tc = new ThreadCollection();
            GThreadMock threadToRemove1 = new GThreadMock();
            GThreadMock threadToRemove2 = new GThreadMock();

            tc.Add(threadToRemove1);
            tc.Add(threadToRemove2);

            Assert.AreEqual(2, tc.Count);

            threadToRemove1.SetState(ThreadState.Dead);
            threadToRemove2.SetState(ThreadState.Finished);

            tc.Remove(threadToRemove1);

            // the thread should have been removed
            Assert.AreEqual(1, tc.Count);

            tc.Remove(threadToRemove2);

            // the thread should have been removed
            Assert.AreEqual(0, tc.Count);
        }


        [Test]
        public void RemoveTestRemoveExistingActiveThreads()
        {
            ThreadCollection tc = new ThreadCollection();
            GThreadMock threadToRemove1 = new GThreadMock();
            GThreadMock threadToRemove2 = new GThreadMock();
            GThreadMock threadToRemove3 = new GThreadMock();
            GThreadMock threadToRemove4 = new GThreadMock();

            tc.Add(threadToRemove1);
            tc.Add(threadToRemove2);
            tc.Add(threadToRemove3);
            tc.Add(threadToRemove4);

            Assert.AreEqual(4, tc.Count);

            threadToRemove1.SetState(ThreadState.Ready);
            threadToRemove2.SetState(ThreadState.Scheduled);
            threadToRemove3.SetState(ThreadState.Started);
            threadToRemove4.SetState(ThreadState.Unknown);

            tc.Remove(threadToRemove1);
            tc.Remove(threadToRemove2);
            tc.Remove(threadToRemove3);
            tc.Remove(threadToRemove4);

            // the thread should not have been removed
            // this remove function only allows the removal of Dead or Finished threads
            Assert.AreEqual(4, tc.Count);
        }


        #endregion
    }
}
