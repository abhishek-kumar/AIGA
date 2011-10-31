#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  ManagerStorageFactory.cs
* Project       :  Alchemi.Core.Manager.Storage
* Created on    :  30 August 2005
* Copyright     :  Copyright © 2005 The University of Melbourne
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
using System.Configuration;

using Alchemi.Core.Manager.Storage;

namespace Alchemi.Manager.Storage
{
	/// <summary>
	/// Takes care of choosing the right storage.
	/// </summary>
	public class ManagerStorageFactory
	{
		private static IManagerStorage m_managerStorage = null;
		private static object m_inMemoryManagerStorageLock = new object();

		public ManagerStorageFactory()
		{
		}

		public static IManagerStorage ManagerStorage()
		{
			if (m_managerStorage == null)
			{
				CreateManagerStorage(null);
			}

			return m_managerStorage;
		}

		/// <summary>
		/// Set the manager storage.
		/// Used to control the current storage from the caller.
		/// </summary>
		/// <param name="managerStorage"></param>
		public static void SetManagerStorage(IManagerStorage managerStorage)
		{
			m_managerStorage = managerStorage;
		}

		/// <summary>
		/// Create the right manager storage object based on the storage type in the configuration file.
		/// This will set the default database to the one specified in the configuration file
		/// </summary>
		/// <param name="config"></param>
		/// <returns></returns>
		public static IManagerStorage CreateManagerStorage(Configuration config)
		{
			return CreateManagerStorage(config, true);
		}

		/// <summary>
		/// Create the right manager storage object based on the storage type in the configuration file.
		/// </summary>
		/// <param name="config"></param>
		/// <param name="overwriteDefaultDatabase">Specify if the default catalog is set to the database name in the config file.</param>
		/// <returns></returns>
		public static IManagerStorage CreateManagerStorage(Configuration config, bool overwriteDefaultDatabase)
		{
			Configuration configuration = config;
			
			if (configuration==null)
			{
				configuration = Configuration.GetConfiguration();
			}

			string sqlConnStr;

			switch(configuration.DbType)
			{
					case ManagerStorageEnum.SqlServer:

					if (overwriteDefaultDatabase)
					{ 
						// build sql server configuration string
						sqlConnStr = string.Format(
							"user id={1};password={2};initial catalog={3};data source={0};Connect Timeout=5; Max Pool Size=5; Min Pool Size=5",
							configuration.DbServer,
							configuration.DbUsername,
							configuration.DbPassword,
							configuration.DbName
							);
					}
					else
					{
						sqlConnStr = string.Format(
							"user id={1};password={2};data source={0};Connect Timeout=5; Max Pool Size=5; Min Pool Size=5",
							configuration.DbServer,
							configuration.DbUsername,
							configuration.DbPassword
							);
					}

					m_managerStorage = new SqlServerManagerDatabaseStorage(sqlConnStr);
					break;

				case ManagerStorageEnum.MySql:

					if (overwriteDefaultDatabase)
					{ 
						// build sql server configuration string
						sqlConnStr = string.Format(
							"user id={1};password={2};database={3};data source={0};Connect Timeout=5; Max Pool Size=5; Min Pool Size=5",
							configuration.DbServer,
							configuration.DbUsername,
							configuration.DbPassword,
							configuration.DbName
							);
					}
					else
					{
						sqlConnStr = string.Format(
							"user id={1};password={2};data source={0};Connect Timeout=5; Max Pool Size=5; Min Pool Size=5",
							configuration.DbServer,
							configuration.DbUsername,
							configuration.DbPassword
							);						
					}

					m_managerStorage = new MySqlManagerDatabaseStorage(sqlConnStr);
					break;

				case ManagerStorageEnum.InMemory:
					/// in memory storage is volatile so we always return the same object
					if (m_managerStorage == null)
					{
						lock (m_inMemoryManagerStorageLock)
						{
							// make sure that when we got the lock we are still uninitialized
							if (m_managerStorage == null)
							{
								InMemoryManagerStorage inMemoryStorage = new InMemoryManagerStorage();

								// volatile storage, we must initialize the data here
								inMemoryStorage.InitializeStorageData();

								m_managerStorage = inMemoryStorage;
							}
						}
					}

					break;

				default:
					throw new ConfigurationException(String.Format("Unknown storage type: {0}", configuration.DbType));
			}

			return m_managerStorage;
		}

	}
}
