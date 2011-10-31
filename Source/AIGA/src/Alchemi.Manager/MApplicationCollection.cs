#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	MApplicationCollection.cs
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
using System.IO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Specialized;
using System.Runtime.Remoting;
using System.Threading;

using Alchemi.Core;
using Alchemi.Core.Owner;
using Alchemi.Core.Utility;
using Alchemi.Core.Manager.Storage;
using Alchemi.Manager.Storage;
using ThreadState = Alchemi.Core.Owner.ThreadState;

namespace Alchemi.Manager
{
    /// <summary>
    /// Represents a collection of grid applications. A particular application is referred to by its ID via the indexer.
    /// </summary>
    public class MApplicationCollection
    {
		/// <summary>
		/// Gets the MApplication with the given id
		/// </summary>
        public MApplication this[string applicationId]
        {
            get
            {
                return new MApplication(applicationId);
            }
        }
        
		/// <summary>
		/// Creates a new application
		/// </summary>
		/// <param name="username">the user associated with the application</param>
		/// <returns>Id of the newly created application</returns>
		public string CreateNew(string username)
		{
            //Krishna: changed to use the constructor with created-time
            ApplicationStorageView application =
                new ApplicationStorageView(ApplicationState.Ready, DateTime.Now, true, username);
                //new ApplicationStorageView(username);
			
			string appId = ManagerStorageFactory.ManagerStorage().AddApplication(application);

			this[appId].CreateDataDirectory();
			return appId;
		}

		/// <summary>
		/// Verify if the database is properly set up.
		/// 
		/// </summary>
		/// <param name="id">application id</param>
		/// <returns>true if the application is set up in the database</returns>
		public bool VerifyApp(string id)
		{
			bool appSetup = true;

			//create directory can be repeated, and wont throw an error even if the dir already exists.
			this[id].CreateDataDirectory();

			ApplicationStorageView application = ManagerStorageFactory.ManagerStorage().GetApplication(id);

			if (application == null)
			{
				appSetup = false;
			}

			return appSetup;
		}


		/// <summary>
		/// Gets the list of applications.
		/// </summary>
		public ApplicationStorageView[] LiveList
		{
			get 
			{
				return ManagerStorageFactory.ManagerStorage().GetApplications(true);
			}
		}

		/// <summary>
		/// Gets the list of applications for the given user.
		/// </summary>
		/// <param name="user_name"></param>
		/// <returns>ApplicationStorageView array with the requested information.</returns>
		public ApplicationStorageView[] GetApplicationList(string user_name)
		{
			return ManagerStorageFactory.ManagerStorage().GetApplications(user_name, true);
		}

		/// <summary>
		/// Gets the list of threads which are ready to be scheduled.
		/// </summary>
        public ThreadStorageView[] ReadyThreads
        {
            get 
            {
				return ManagerStorageFactory.ManagerStorage().GetThreads(ThreadState.Ready);
            }
        }

    }
}