#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  FileDepencencyCollectionTester.cs
* Project       :  Alchemi.Tester.Core.Owner
* Created on    :  08 February 2006
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

using Alchemi.Core.Owner;

using NUnit.Framework;

namespace Alchemi.Tester.Core.Owner
{
	/// <summary>
	/// Summary description for FileDepencencyCollectionTester.
	/// </summary>
	[TestFixture]
	public class FileDepencencyCollectionTester
	{
		public FileDepencencyCollectionTester()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region "Contains Tests"

		[Test]
		public void ContainsTestNullValue()
		{
			FileDependencyCollection collection = new FileDependencyCollection();

			bool result = collection.Contains(null);

			Assert.IsFalse(result);
		}

		[Test]
		public void ContainsTestEmptyCollection()
		{
			FileDependencyCollection collection = new FileDependencyCollection();
			FileDependency fd = new FileDependencyMock(@"c:\tst.txt");

			bool result = collection.Contains(fd);

			Assert.IsFalse(result);
		}

		[Test]
		public void ContainsTestDependencyFound()
		{
			FileDependencyCollection collection = new FileDependencyCollection();
			FileDependency fd1 = new FileDependencyMock(@"c:\test1.txt");
			FileDependency fd2 = new FileDependencyMock(@"c:\test2.txt");

			collection.Add(fd1);
			collection.Add(fd2);

			bool result = collection.Contains(fd1);

			Assert.IsTrue(result);
		}

		[Test]
		public void ContainsTestDependencyNotFound()
		{
			FileDependencyCollection collection = new FileDependencyCollection();
			FileDependency fd1 = new FileDependencyMock(@"c:\test1.txt");
			FileDependency fd2 = new FileDependencyMock(@"c:\test2.txt");
			FileDependency fd3 = new FileDependencyMock(@"c:\test3.txt");

			collection.Add(fd1);
			collection.Add(fd2);

			bool result = collection.Contains(fd3);

			Assert.IsFalse(result);
		}

		[Test]
		public void ContainsTestDependencyFoundCaseOnlyDifferent()
		{
			FileDependencyCollection collection = new FileDependencyCollection();
			FileDependency fd1 = new FileDependencyMock(@"c:\test1.txt");
			FileDependency fd2 = new FileDependencyMock(@"c:\test2.txt");
			FileDependency fd3 = new FileDependencyMock(@"c:\TEST2.txt");

			collection.Add(fd1);
			collection.Add(fd2);

			bool result = collection.Contains(fd3);

			Assert.IsTrue(result);
		}

		#endregion

		#region "Add Tests"

		[Test]
		public void AddTestNullValue()
		{
			FileDependencyCollection collection = new FileDependencyCollection();

			try
			{
				collection.Add((FileDependency)null);

				Assert.IsTrue(false, "Adding a null value to the collection should throw an InvalidOretationException.");
			}
			catch (InvalidOperationException e)
			{
				Console.Write(e);
				// pass if we get here
				Assert.IsTrue(true);
			}
		}

		[Test]
		public void AddTestDuplicatedValue()
		{
			FileDependencyCollection collection = new FileDependencyCollection();
			FileDependency fd1 = new FileDependencyMock(@"c:\test1.txt");
			FileDependency fd2 = new FileDependencyMock(@"c:\test1.txt");

			collection.Add(fd1);

			try
			{
				collection.Add(fd2);

				Assert.IsTrue(false, "Adding a duplicate value to the collection should throw an InvalidOretationException.");
			}
			catch (InvalidOperationException e)
			{
				Console.Write(e);
				// pass if we get here
				Assert.IsTrue(true);
			}
		}

		[Test]
		public void AddTestSimpleScenario()
		{
			FileDependencyCollection collection = new FileDependencyCollection();
			FileDependency fd1 = new FileDependencyMock(@"c:\test1.txt");
			FileDependency fd2 = new FileDependencyMock(@"c:\test2.txt");

			collection.Add(fd1);
			collection.Add(fd2);

			Assert.IsTrue(collection.Contains(fd1));
			Assert.IsTrue(collection.Contains(fd2));
		}

		#endregion

        #region "Add list Tests"

        [Test]
        public void AddListTestNullValue()
        {
            FileDependencyCollection collection = new FileDependencyCollection();

            try
            {
                collection.Add((FileDependency[])null);

                Assert.IsTrue(false, "Adding a null value to the collection should throw an InvalidOretationException.");
            }
            catch (InvalidOperationException e)
            {
                Console.Write(e);
                // pass if we get here
                Assert.IsTrue(true);
            }
        }

        [Test]
        public void AddListTestNullValueInList()
        {
            FileDependencyCollection collection = new FileDependencyCollection();
            FileDependency[] fdList = new FileDependency[1];
            fdList[0] = null;

            try
            {
                collection.Add(fdList);

                Assert.IsTrue(false, "Adding a null value to the collection should throw an InvalidOretationException.");
            }
            catch (InvalidOperationException e)
            {
                Console.Write(e);
                // pass if we get here
                Assert.IsTrue(true);
            }
        }

        [Test]
        public void AddListTestDuplicatedValue()
        {
            FileDependencyCollection collection = new FileDependencyCollection();
            FileDependency[] fdList = new FileDependency[1];
            FileDependency fd1 = new FileDependencyMock(@"c:\test1.txt");
            fdList[0] = new FileDependencyMock(@"c:\test1.txt");

            collection.Add(fd1);

            try
            {
                collection.Add(fdList);

                Assert.IsTrue(false, "Adding a duplicate value to the collection should throw an InvalidOretationException.");
            }
            catch (InvalidOperationException e)
            {
                Console.Write(e);
                // pass if we get here
                Assert.IsTrue(true);
            }
        }

        [Test]
        public void AddListTestSimpleScenario()
        {
            FileDependencyCollection collection = new FileDependencyCollection();
            FileDependency[] fdList = new FileDependency[2];
            FileDependency fd1 = new FileDependencyMock(@"c:\test1.txt");
            FileDependency fd2 = new FileDependencyMock(@"c:\test2.txt");
            fdList[0] = fd1;
            fdList[1] = fd2;

            collection.Add(fdList);

            Assert.IsTrue(collection.Contains(fd1));
            Assert.IsTrue(collection.Contains(fd2));
        }

        #endregion

	}
}
