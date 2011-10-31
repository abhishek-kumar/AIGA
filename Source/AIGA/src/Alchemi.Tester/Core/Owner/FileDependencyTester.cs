#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  FileDepencencyTester.cs
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
    public class FileDependencyTester
    {
        private string _rootFolderName;
        private string _rootFolderNameToExtractTo;

        [SetUp]
        public void SetUp()
        {
            _rootFolderName = Path.Combine(Path.GetTempPath(), "embeded_test_folder");
            _rootFolderNameToExtractTo = Path.Combine(Path.GetTempPath(), "target_test_folder");

            if (Directory.Exists(_rootFolderName))
            {
                // if this folder exists means that a test failed to clean up after itself
                Directory.Delete(_rootFolderName, true);
            }

            if (Directory.Exists(_rootFolderNameToExtractTo))
            {
                // if this folder exists means that a test failed to clean up after itself
                Directory.Delete(_rootFolderNameToExtractTo, true);
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

            if (Directory.Exists(_rootFolderNameToExtractTo))
            {
                Directory.Delete(_rootFolderNameToExtractTo, true);
            }
        }

        /// <summary>
        /// Create a dummy test file under the root folder name
        /// </summary>
        /// <param name="fileName"></param>
        private string CreateDummyFileUnderRootFolder(string fileName)
        {
            byte[] randomArray = new byte[100];
            string targetFileName;

            targetFileName = Path.Combine(_rootFolderName, fileName);

            Directory.CreateDirectory(Path.GetDirectoryName(targetFileName));

            using (FileStream stream = File.Create(targetFileName))
            {
                stream.Write(randomArray, 0, randomArray.Length);
            }

            return targetFileName;
        }

        #region "UnPackToFolder tests"

        [Test]
        public void UnPackToFolderTestNoFolders()
        {
            string fileName = @"test1.txt";
            
            // create the file
            string fileLocation = CreateDummyFileUnderRootFolder(fileName);

            FileDependency fd = new EmbeddedFileDependency(fileName, fileLocation);

            fd.UnPackToFolder(_rootFolderNameToExtractTo);

            // just make sure the file is there
            Assert.IsTrue(File.Exists(Path.Combine(_rootFolderNameToExtractTo, fileName)));
        }

        [Test]
        public void UnPackToFolderTestFolders()
        {
            string fileName1 = @"test1.txt";
            string fileName2 = @"somefolder\And another with spaces\test1.txt";

            // create the file
            string fileLocation1 = CreateDummyFileUnderRootFolder(fileName1);
            string fileLocation2 = CreateDummyFileUnderRootFolder(fileName2);

            FileDependency fd1 = new EmbeddedFileDependency(fileName1, fileLocation1);
            FileDependency fd2 = new EmbeddedFileDependency(fileName2, fileLocation2);

            fd1.UnPackToFolder(_rootFolderNameToExtractTo);
            fd2.UnPackToFolder(_rootFolderNameToExtractTo);

            // just make sure the files are there
            Assert.IsTrue(File.Exists(Path.Combine(_rootFolderNameToExtractTo, fileName1)));
            Assert.IsTrue(File.Exists(Path.Combine(_rootFolderNameToExtractTo, fileName2)));
        }

        #endregion
    }
}
