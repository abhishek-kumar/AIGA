#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	EmbeddedFileDependency.cs
* Project		:	Alchemi Core
* Created on	:	2003
* Copyright		:	Copyright © 2006 The University of Melbourne
*					This technology has been developed with the support of 
*					the Australian Research Council and the University of Melbourne
*					research grants as part of the Gridbus Project
*					within GRIDS Laboratory at the University of Melbourne, Australia.
* Author         :  Akshay Luther (akshayl@csse.unimelb.edu.au) and Rajkumar Buyya (raj@csse.unimelb.edu.au)
* License        :  GPL
*					This program is free software; you can redistribute it and/or 
*					modify it under the terms of the GNU General Public
*					License as published by the Free Software Foundation;
*					See the GNU General Public License 
*					(http://www.gnu.org/copyleft/gpl.html) for more details.
*
*/ 
#endregion

using System;
using System.Reflection;
using System.IO;
using System.Collections;

using Alchemi.Core.Owner;
using Alchemi.Core.Utility;

namespace Alchemi.Core.Owner
{
	/// <summary>
	/// The EmbeddedFileDependency Class extends from the FileDependency class
	/// and provides concrete implementation of the methods to pack and unpack files using base64 encoding.
	/// </summary>
    [Serializable]
    public class EmbeddedFileDependency : FileDependency
    {
		/// <summary>
		/// Contents of the file representing using base64 encoding.
		/// </summary>
        protected string _Base64EncodedContents = "";

		/// <summary>
		/// Gets or sets the file contents in base64-encoded format
		/// </summary>
        public string Base64EncodedContents
        {
            get { return _Base64EncodedContents; }
            set { _Base64EncodedContents = value; }
        }
    
        //-----------------------------------------------------------------------------------------------        
    
		/// <summary>
		/// Creates an instance of an EmbeddedFileDependency
		/// </summary>
		/// <param name="name">file name</param>
        public EmbeddedFileDependency(string name) : base(name) {}

		/// <summary>
		/// Creates an instance of an EmbeddedFileDependency
		/// </summary>
		/// <param name="name">file name</param>
		/// <param name="fileLocation">file location</param>
        public EmbeddedFileDependency(string name, string fileLocation) : base(name)
        {
            Pack(fileLocation);
        }

        //-----------------------------------------------------------------------------------------------        

		/// <summary>
		/// Reads the file and converts its contents to base64 format
		/// </summary>
		/// <param name="fileLocation">location of the file</param>
        public void Pack(string fileLocation)
        {
            _Base64EncodedContents = Utils.ReadBase64EncodedFromFile(fileLocation);
        }

        //-----------------------------------------------------------------------------------------------    

		/// <summary>
		/// Unpacks (writes out) the file to the specified location
		/// </summary>
		/// <param name="fileLocation">file location</param>
        public override void UnPack(string fileLocation)
        {
            Utils.WriteBase64EncodedToFile(fileLocation, _Base64EncodedContents);
        }

        /// <summary>
        /// Create an array of dependencies from the given folder. 
        /// All files under the folder structure will be recursively added to the array.
        /// </summary>
        /// <remarks>
        /// This will preserve the folder structure for any sub-folders. The root folder will not be preserved though
        /// </remarks>
        /// <param name="folderName">The root folder to start from</param>
        /// <returns></returns>
        public static EmbeddedFileDependency[] GetEmbeddedFileDependencyFromFolder(string rootFolderName)
        {
            if (rootFolderName == null || !Directory.Exists(rootFolderName))
            {
                return null;
            }

            ArrayList list = new ArrayList();

            AddFilesToList(list, rootFolderName, "");

            return (EmbeddedFileDependency[])list.ToArray(typeof(EmbeddedFileDependency));
        }

        #region "GetEmbeddedFileDependencyFromFolder helpers"

        private static void AddFilesToList(ArrayList list, string folderName, string subFolderToAddToFileName)
        {
            foreach (string filePath in Directory.GetFiles(folderName))
            {
                EmbeddedFileDependency fileDep = 
                    new EmbeddedFileDependency(
                        Path.Combine(subFolderToAddToFileName, Path.GetFileName(filePath)), 
                        filePath);

                list.Add(fileDep);
            }

            foreach (string folderPath in Directory.GetDirectories(folderName))
            {
                AddFilesToList(
                    list, 
                    folderPath, 
                    Path.Combine(subFolderToAddToFileName, Path.GetFileName(folderPath)));
            }

        }
        #endregion
    }
}
