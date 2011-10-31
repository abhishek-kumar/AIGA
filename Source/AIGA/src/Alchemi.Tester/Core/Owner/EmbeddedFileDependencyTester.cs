#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  EmbededFileDepencencyTester.cs
* Project       :  Alchemi.Tester.Core.Owner
* Created on    :  12 April 2006
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
using System.IO;

using Alchemi.Core.Owner;

using NUnit.Framework;

namespace Alchemi.Tester.Core.Owner
{
    [TestFixture]
    public class EmbeddedFileDependencyTester
    {
        private string _rootFolderName;

        [SetUp]
        public void SetUp()
        {
            _rootFolderName = Path.Combine(Path.GetTempPath(), "embeded_test_folder");

            if (Directory.Exists(_rootFolderName))
            {
                // if this folder exists means that a test failed to clean up after itself
                Directory.Delete(_rootFolderName, true);
            }

            Directory.CreateDirectory(_rootFolderName);
        }

        [TearDown]
        public void TearDown()
        {
            if (Directory.Exists(_rootFolderName))
            {
                Directory.Delete(_rootFolderName, true);
            }
        }

        /// <summary>
        /// Create a dummy test file under the root folder name
        /// </summary>
        /// <param name="fileName"></param>
        private void CreateDummyFileUnderRootFolder(string fileName)
        {
            byte[] randomArray = new byte[100];
            string targetFileName;

            targetFileName = Path.Combine(_rootFolderName, fileName);

            Directory.CreateDirectory(Path.GetDirectoryName(targetFileName));

            using (FileStream stream = File.Create(targetFileName))
            {
                stream.Write(randomArray, 0, randomArray.Length);
            }
        }

        #region "GetEmbeddedFileDependencyFromFolder Tests"

        [Test]
        public void GetEmbeddedFileDependencyFromFolderTestNullFolderName()
        {
            EmbeddedFileDependency[] result;

            result = EmbeddedFileDependency.GetEmbeddedFileDependencyFromFolder(null);

            Assert.IsNull(result);
        }

        [Test]
        public void GetEmbeddedFileDependencyFromFolderTestNonExistentFolder()
        {
            EmbeddedFileDependency[] result;
            string folderName = Path.Combine(Path.GetTempPath(), "does_Not_Exist");

            // make sure that the folder does not exist
            Assert.IsFalse(Directory.Exists(folderName));

            result = EmbeddedFileDependency.GetEmbeddedFileDependencyFromFolder(folderName);

            Assert.IsNull(result);
        }

        [Test]
        public void GetEmbeddedFileDependencyFromFolderTestNoFolders()
        {
            EmbeddedFileDependency[] result;
            string fileName = "test1.txt";

            CreateDummyFileUnderRootFolder(fileName);

            result = EmbeddedFileDependency.GetEmbeddedFileDependencyFromFolder(_rootFolderName);

            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(fileName, result[0].FileName);
        }

        [Test]
        public void GetEmbeddedFileDependencyFromFolderTestFolders()
        {
            EmbeddedFileDependency[] result;
            string fileName = @"someFolder\test1.txt";

            CreateDummyFileUnderRootFolder(fileName);

            result = EmbeddedFileDependency.GetEmbeddedFileDependencyFromFolder(_rootFolderName);

            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(fileName, result[0].FileName);
        }

        [Test]
        public void GetEmbeddedFileDependencyFromFolderTestRecursiveFolders()
        {
            EmbeddedFileDependency[] result;
            string fileName = @"someFolder\anotherFolder\test1.txt";

            CreateDummyFileUnderRootFolder(fileName);

            result = EmbeddedFileDependency.GetEmbeddedFileDependencyFromFolder(_rootFolderName);

            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(fileName, result[0].FileName);
        }

        [Test]
        public void GetEmbeddedFileDependencyFromFolderTestMultipleFiles()
        {
            EmbeddedFileDependency[] result;
            string fileName1 = @"someFolder3\anotherFolder1\test1.txt";
            string fileName2 = @"someFolder1\test2.txt";
            string fileName3 = @"someFolder2\test3.txt";
            string fileName4 = @"test4.txt";

            CreateDummyFileUnderRootFolder(fileName1);
            CreateDummyFileUnderRootFolder(fileName2);
            CreateDummyFileUnderRootFolder(fileName3);
            CreateDummyFileUnderRootFolder(fileName4);

            result = EmbeddedFileDependency.GetEmbeddedFileDependencyFromFolder(_rootFolderName);

            Assert.AreEqual(4, result.Length);

            // all files above should exist in the resulting array
            bool fileName1Found = false;
            bool fileName2Found = false;
            bool fileName3Found = false;
            bool fileName4Found = false;

            foreach (EmbeddedFileDependency dep in result)
            {
                if (dep.FileName == fileName1)
                {
                    fileName1Found = true;
                }

                if (dep.FileName == fileName2)
                {
                    fileName2Found = true;
                }
                
                if (dep.FileName == fileName3)
                {
                    fileName3Found = true;
                }
                
                if (dep.FileName == fileName4)
                {
                    fileName4Found = true;
                }
            }

            Assert.IsTrue(fileName1Found);
            Assert.IsTrue(fileName2Found);
            Assert.IsTrue(fileName3Found);
            Assert.IsTrue(fileName4Found);
        }

        #endregion

    }
}
