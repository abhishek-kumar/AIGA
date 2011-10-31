#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  InMemoryManagerStorage.cs
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
using System.Collections;
using System.Data;
using System.Xml;

using Alchemi.Core;
using Alchemi.Core.Owner;
using Alchemi.Core.Manager;
using Alchemi.Core.Manager.Storage;
using Alchemi.Core.Utility;

namespace Alchemi.Manager.Storage
{
	/// <summary>
	/// Store all manager information in memory.
	/// 
	/// This type of storage is not persistent but usefull for testing or for running 
	/// lightweight managers.
	/// </summary>
	public class InMemoryManagerStorage : ManagerStorageBase, IManagerStorage, IManagerStorageSetup
	{
		private ArrayList m_users;
		private ArrayList m_groups;
		private Hashtable m_groupPermissions;
		private ArrayList m_executors;
		private ArrayList m_applications;
		private ArrayList m_threads;

		public InMemoryManagerStorage()
		{
		}

		#region IManagerStorage Members

		public bool VerifyConnection()
		{
			return true; //for a In-memory storage, the connection is always alive and valid.
		}

		public SystemSummary GetSystemSummary()
		{
			// calculate total number of executors
			Int32 totalExecutors = m_executors != null ? m_executors.Count : 0;

			// calculate number of unfinished applications
			Int32 unfinishedApps = 0;
			if (m_applications != null)
			{
				foreach(ApplicationStorageView application in m_applications)
				{
					if (application.State == ApplicationState.AwaitingManifest || application.State == ApplicationState.Ready)
					{
						unfinishedApps++;
					}
				}
			}
			
			Int32 unfinishedThreads = 0;
			if (m_threads != null)
			{
				foreach(ThreadStorageView thread in m_threads)
				{
					if (thread.State != ThreadState.Dead && thread.State != ThreadState.Finished)
					{
						unfinishedThreads++;
					}
				}
			}			

			float maxPowerValue = 0;
			Int32 powerUsage = 0;
			Int32 powerAvailable = 0;
			float totalUsageValue = 0;
			if (m_executors != null)
			{
				int connectedExecutorCount = 0;

				foreach(ExecutorStorageView executor in m_executors)
				{
					if (executor.Connected)
					{
						connectedExecutorCount++;
						maxPowerValue += executor.MaxCpu;
						powerAvailable += executor.AvailableCpu;
						powerUsage += executor.CpuUsage;
						totalUsageValue += executor.TotalCpuUsage * executor.MaxCpu / (3600 * 1000);
					}
				}

				powerAvailable /= connectedExecutorCount;
				powerUsage /= connectedExecutorCount;
			}

			String powerTotalUsage = String.Format("{0} GHz*Hr", Math.Round(totalUsageValue, 6));
			String maxPower = String.Format("{0} GHz", Math.Round(maxPowerValue / 1000, 6));

			SystemSummary summary = new SystemSummary(
				maxPower, 
				totalExecutors,
				powerUsage,
				powerAvailable,
				powerTotalUsage,
				unfinishedApps,
				unfinishedThreads);

			return summary;
		}

		public DataSet RunSqlReturnDataSet(string query)
		{
			//throw new NotImplementedException();
			return null;
		}//TODO: need to get rid of this from the interface
		public void RunSql(string sqlQuery)
		{
			//throw new NotImplementedException();
		} //TODO: need to clean this up, and get rid of this from the interface

		public void AddUsers(UserStorageView[] users)
		{
			if (users == null)
			{
				return;
			}

			if (m_users == null)
			{
				m_users = new ArrayList();
			}

			m_users.AddRange(users);
		}

		public void UpdateUsers(UserStorageView[] updates)
		{
			if (m_users == null || updates == null)
			{
				return;
			}

			for(int indexInList=0; indexInList<m_users.Count; indexInList++)
			{
				UserStorageView userInList = (UserStorageView)m_users[indexInList];

				foreach(UserStorageView userInUpdates in updates)
				{
					if (userInList.Username == userInUpdates.Username)
					{
						userInList.Password = userInUpdates.Password;
						userInList.GroupId = userInUpdates.GroupId;
					}
				}
			}
		}

		public void DeleteUser(UserStorageView userToDelete)
		{
			if (m_users == null || userToDelete == null)
			{
				return;
			}

			ArrayList remainingUsers = new ArrayList();

			for(int indexInList=0; indexInList<m_users.Count; indexInList++)
			{
				UserStorageView userInList = (UserStorageView)m_users[indexInList];

				if (userInList.Username != userToDelete.Username)
				{
					remainingUsers.Add(userInList);
				}
			}

			m_users = remainingUsers;
		}

		public bool AuthenticateUser(SecurityCredentials sc)
		{
			if (sc == null || m_users == null)
			{
				return false;
			}

			for(int index=0; index<m_users.Count; index++)
			{
				UserStorageView user = (UserStorageView)m_users[index];

				if (user.Username == sc.Username && user.PasswordMd5Hash == sc.Password)
				{
					return true;
				}
			}

			return false;
		}

		public UserStorageView[] GetUsers()
		{
			if (m_users == null)
			{
				return new UserStorageView[0];
			}
			else
			{
				return (UserStorageView[])m_users.ToArray(typeof(UserStorageView));
			}
		}

		public void AddGroups(GroupStorageView[] groups)
		{
			if (groups == null)
			{
				return;
			}

			if (m_groups == null)
			{
				m_groups = new ArrayList();
			}

			m_groups.AddRange(groups);
		}
		
		public GroupStorageView[] GetGroups()
		{
			if (m_groups == null)
			{
				return new GroupStorageView[0];
			}
			else
			{
				return (GroupStorageView[])m_groups.ToArray(typeof(GroupStorageView));
			}
		}

		public GroupStorageView GetGroup(Int32 groupId)
		{
			if (m_groups == null)
			{
				return null;
			}

			foreach (GroupStorageView group in m_groups)
			{
				if (group.GroupId == groupId)
				{
					return group;
				}
			}

			return null;
		}

		public void AddGroupPermission(Int32 groupId, Permission permission)
		{
			if (m_groupPermissions == null)
			{
				m_groupPermissions = new Hashtable();
			}

			ArrayList permissions = null;

			if (m_groupPermissions[groupId] != null)
			{
				permissions = (ArrayList)m_groupPermissions[groupId];
			}
			else
			{
				permissions = new ArrayList();

				m_groupPermissions.Add(groupId, permissions);
			}

			Int32 index = permissions.IndexOf(permission);

			// only add it if it is not already in the array
			if (index < 0)
			{
				permissions.Add(permission);
			}

			m_groupPermissions[groupId] = permissions;
		}

		public Permission[] GetGroupPermissions(Int32 groupId)
		{
			if (m_groupPermissions == null || m_groupPermissions[groupId] == null)
			{
				return new Permission[0];
			}

			ArrayList permissions = (ArrayList)m_groupPermissions[groupId];

			return (Permission[])permissions.ToArray(typeof(Permission));
		}

		public PermissionStorageView[] GetGroupPermissionStorageView(Int32 groupId)
		{
			return PermissionStorageView.GetPermissionStorageView(GetGroupPermissions(groupId));
		}

		public void DeleteGroup(GroupStorageView groupToDelete)
		{
			if (m_groups == null || groupToDelete == null)
			{
				return;
			}

			ArrayList remainingGroups = new ArrayList();
			ArrayList remainingUsers = new ArrayList();

			if (m_users != null)
			{
				foreach (UserStorageView user in m_users)
				{
					if (user.GroupId != groupToDelete.GroupId)
					{
						remainingUsers.Add(user);
					}
				}
			}

			foreach (GroupStorageView group in m_groups)
			{
				if (group.GroupId != groupToDelete.GroupId)
				{
					remainingGroups.Add(group);
				}
			}

			m_groups = remainingGroups;
			m_users = remainingUsers;
		}

		public UserStorageView[] GetGroupUsers(Int32 groupId)
		{
			if (m_users == null)
			{
				return new UserStorageView[0];
			}

			ArrayList result = new ArrayList();

			foreach (UserStorageView user in m_users)
			{
				if (user.GroupId == groupId)
				{
					result.Add(user);
				}
			}

			return (UserStorageView[])result.ToArray(typeof(UserStorageView));
		}

		public bool CheckPermission(SecurityCredentials sc, Permission perm)
		{
			if (m_users == null || m_groups == null || m_groupPermissions == null)
			{
				return false;
			}

			// get the user's groupId
			Int32 groupId = -1;
			foreach(UserStorageView user in m_users)
			{
				if(String.Compare(user.Username, sc.Username, true) == 0 && user.PasswordMd5Hash == sc.Password)
				{
					groupId = user.GroupId;
					break;
				}
			}

			if (groupId == -1)
			{
				return false;
			}

			foreach(Permission permission in GetGroupPermissions(groupId))
			{
				// in the SQL implementation the higher leverl permissions are considered to 
				// include the lower leverl permissions
				if ((int)permission >= (int)perm)
				{
					return true;
				}
			}

			return false;
		}

		public String AddExecutor(ExecutorStorageView executor)
		{
			if (executor == null)
			{
				return null;
			}

			if (m_executors == null)
			{
				m_executors = new ArrayList();
			}

			String executorId;
			if (executor.ExecutorId == null)
			{
				executorId = Guid.NewGuid().ToString();
			}
			else
			{
				executorId = executor.ExecutorId;
			}

			executor.ExecutorId = executorId;

			m_executors.Add(executor);

			return executorId;
		}

		public void UpdateExecutor(ExecutorStorageView updatedExecutor)
		{
			if (m_executors == null || updatedExecutor == null)
			{
				return;
			}

			ArrayList newExecutorList = new ArrayList();

			foreach(ExecutorStorageView executor in m_executors)
			{
				if (executor.ExecutorId == updatedExecutor.ExecutorId)
				{
					newExecutorList.Add(updatedExecutor);
				}
				else
				{
					newExecutorList.Add(executor);
				}
			}

			m_executors = newExecutorList;
		}

        public void DeleteExecutor(ExecutorStorageView executorToDelete)
        {
            if (m_executors == null || executorToDelete == null)
            {
                return;
            }

            ArrayList newExecutorList = new ArrayList();

            foreach (ExecutorStorageView executor in m_executors)
            {
                if (executor.ExecutorId != executorToDelete.ExecutorId)
                {
                    newExecutorList.Add(executor);
                }
            }

            m_executors = newExecutorList;
        }

		public ExecutorStorageView[] GetExecutors()
		{
			if (m_executors == null)
			{
				return new ExecutorStorageView[0];
			}
			else
			{
				return (ExecutorStorageView[])m_executors.ToArray(typeof(ExecutorStorageView));
			}
		}

		public ExecutorStorageView[] GetExecutors(TriStateBoolean dedicated)
		{
			return GetExecutors(dedicated, TriStateBoolean.Undefined);
		}

		public ExecutorStorageView[] GetExecutors(TriStateBoolean dedicated, TriStateBoolean connected)
		{
			if (m_executors == null || m_executors.Count == 0)
			{
				return new ExecutorStorageView[0];
			}

			ArrayList executorList = new ArrayList();

			foreach(ExecutorStorageView executor in m_executors)
			{
				bool onlyLookingForDedicatedAndExecutorIsDedicated = (dedicated == TriStateBoolean.True && executor.Dedicated);
				bool dedicatedTestPassed = (onlyLookingForDedicatedAndExecutorIsDedicated || dedicated == TriStateBoolean.Undefined);

				bool onlyLookingForConnectedAndExecutorIsConnected = (connected == TriStateBoolean.True && executor.Connected);
				bool connectedTestPassed = (onlyLookingForConnectedAndExecutorIsConnected || connected == TriStateBoolean.Undefined);
				
				if (dedicatedTestPassed && connectedTestPassed)
				{
					executorList.Add(executor);
				}
			}

			return (ExecutorStorageView[])executorList.ToArray(typeof(ExecutorStorageView));
		}

		public ExecutorStorageView GetExecutor(String executorId)
		{
			if (m_executors == null)
			{
				return null;
			}

			foreach(ExecutorStorageView executor in m_executors)
			{
				if (executor.ExecutorId == executorId)
				{
					return executor;
				}
			}

			return null;
		}


		public String AddApplication(ApplicationStorageView application)
		{
			if (application == null)
			{
				return null;
			}

			if (m_applications == null)
			{
				m_applications = new ArrayList();
			}

			String applicationId = Guid.NewGuid().ToString();

			application.ApplicationId = applicationId;

			m_applications.Add(application);

			return applicationId;
		}

		public void UpdateApplication(ApplicationStorageView updatedApplication)
		{
			if (m_applications == null || updatedApplication == null)
			{
				return;
			}

			ArrayList newApplicationList = new ArrayList();

			foreach(ApplicationStorageView application in m_applications)
			{
				if (application.ApplicationId == updatedApplication.ApplicationId)
				{
					newApplicationList.Add(updatedApplication);
				}
				else
				{
					newApplicationList.Add(application);
				}
			}

			m_applications = newApplicationList;
		}

		public ApplicationStorageView[] GetApplications()
		{
			return GetApplications(false);
		}

		public ApplicationStorageView[] GetApplications(bool populateThreadCount)
		{
			if (m_applications == null || m_applications.Count == 0)
			{
				return new ApplicationStorageView[0];
			}

			ArrayList applicationList = new ArrayList();

			foreach(ApplicationStorageView application in m_applications)
			{
				if (populateThreadCount)
				{
					Int32 totalThreads;
					Int32 unfinishedThreads;

					GetApplicationThreadCount(application.ApplicationId, out totalThreads, out unfinishedThreads);

					application.TotalThreads = totalThreads;
					application.UnfinishedThreads = unfinishedThreads;
				}

				applicationList.Add(application);
			}

			return (ApplicationStorageView[])applicationList.ToArray(typeof(ApplicationStorageView));
		}

		public ApplicationStorageView[] GetApplications(String userName, bool populateThreadCount)
		{
			ArrayList applicationList = new ArrayList();

			foreach(ApplicationStorageView application in m_applications)
			{
				if (String.Compare(application.Username, userName, false) == 0)
				{
					if (populateThreadCount)
					{
						Int32 totalThreads;
						Int32 unfinishedThreads;

						GetApplicationThreadCount(application.ApplicationId, out totalThreads, out unfinishedThreads);

						application.TotalThreads = totalThreads;
						application.UnfinishedThreads = unfinishedThreads;
					}

					applicationList.Add(application);
				}
			}

			return (ApplicationStorageView[])applicationList.ToArray(typeof(ApplicationStorageView));
		}

		public ApplicationStorageView GetApplication(String applicationId)
		{
			if (m_applications == null)
			{
				return null;
			}

			IEnumerator enumerator = m_applications.GetEnumerator();

			while(enumerator.MoveNext())
			{
				ApplicationStorageView application = (ApplicationStorageView)enumerator.Current;

				if (application.ApplicationId == applicationId)
				{
					return application;
				}
			}

			// data not found
			return null;

		}

		public void DeleteApplication(ApplicationStorageView applicationToDelete)
		{
			if (m_applications == null || applicationToDelete == null)
			{
				return;
			}

			ArrayList remainingApplications = new ArrayList();
			ArrayList remainingThreads = new ArrayList();

			if (m_threads != null)
			{
				foreach (ThreadStorageView thread in m_threads)
				{
					if (thread.ApplicationId != applicationToDelete.ApplicationId)
					{
						remainingThreads.Add(thread);
					}
				}
			}

			foreach (ApplicationStorageView application in m_applications)
			{
				if (application.ApplicationId != applicationToDelete.ApplicationId)
				{
					remainingApplications.Add(application);
				}
			}

			m_threads= remainingThreads;
			m_applications= remainingApplications;
		}


		public Int32 AddThread(ThreadStorageView thread)
		{
			if (thread == null)
			{
				return -1;
			}

			if (m_threads == null)
			{
				m_threads = new ArrayList();
			}

			lock(m_threads)
			{
				// generate the next threadID from the length, this will make sure the thread ID is unique
				// generating from the length also requires thread synchronization code here
				thread.InternalThreadId = m_threads.Count;

				m_threads.Add(thread);
			}

			return thread.InternalThreadId;
		}

		public void UpdateThread(ThreadStorageView updatedThread)
		{
			if (m_threads == null || updatedThread == null)
			{
				return;
			}

			ArrayList newThreadList = new ArrayList();

			foreach(ThreadStorageView thread in m_threads)
			{
				if (thread.InternalThreadId == updatedThread.InternalThreadId)
				{
					newThreadList.Add(updatedThread);
				}
				else
				{
					newThreadList.Add(thread);
				}
			}

			m_threads = newThreadList;
		}

		public ThreadStorageView GetThread(String applicationId, Int32 threadId)
		{
			if (m_threads == null)
			{
				return null;
			}

			foreach(ThreadStorageView thread in m_threads)
			{
				if (thread.ApplicationId == applicationId && thread.ThreadId == threadId)
				{
					return thread;
				}
			}

			return null;
		}

		public ThreadStorageView[] GetThreads(ApplicationState appState, params ThreadState[] threadStates)
		{
			if (m_threads == null || m_applications == null || m_threads.Count == 0 || m_applications.Count == 0)
			{
				return new ThreadStorageView[0];
			}

			ArrayList threadList = new ArrayList();

			foreach(ApplicationStorageView application in m_applications)
			{
				if (application.State == appState)
				{
					foreach (ThreadStorageView thread in GetThreads(application.ApplicationId, threadStates))
					{
						threadList.Add(thread);
					}
				}
			}

			return (ThreadStorageView[])threadList.ToArray(typeof(ThreadStorageView));
		}

		public ThreadStorageView[] GetThreads(params ThreadState[] state)
		{
			return GetThreads(null, state);
		}

		public ThreadStorageView[] GetThreads(String applicationId, params ThreadState[] threadStates)
		{
			if (m_threads == null)
			{
				return new ThreadStorageView[0];
			}

			ArrayList threadList = new ArrayList();

			foreach(ThreadStorageView thread in m_threads)
			{
				if (thread.ApplicationId == applicationId || applicationId == null)
				{
					bool threadStateCorrect = false;

					if (threadStates == null || threadStates.Length == 0)
					{
						threadStateCorrect = true;
					}
					else
					{
						foreach(ThreadState state in threadStates)
						{
							if (state == thread.State)
							{
								threadStateCorrect = true;
								break;
							}
						}
					}

					if (threadStateCorrect)
					{
						threadList.Add(thread);
					}
				}
			}

			return (ThreadStorageView[])threadList.ToArray(typeof(ThreadStorageView));
		}

		public ThreadStorageView[] GetExecutorThreads(String executorId, params ThreadState[] threadStates)
		{
			if (m_threads == null)
			{
				return new ThreadStorageView[0];
			}

			ArrayList threadList = new ArrayList();

			foreach(ThreadStorageView thread in m_threads)
			{
				if (thread.ExecutorId == executorId)
				{
					bool threadStateCorrect = false;

					if (threadStates == null || threadStates.Length == 0)
					{
						threadStateCorrect = true;
					}
					else
					{
						foreach(ThreadState state in threadStates)
						{
							if (state == thread.State)
							{
								threadStateCorrect = true;
								break;
							}
						}
					}

					if (threadStateCorrect)
					{
						threadList.Add(thread);
					}
				}
			}

			return (ThreadStorageView[])threadList.ToArray(typeof(ThreadStorageView));
		}

		public ThreadStorageView[] GetExecutorThreads(bool dedicatedExecutor, params ThreadState[] state)
		{
			if (m_threads == null || m_executors == null)
			{
				return new ThreadStorageView[0];
			}

			ArrayList threadList = new ArrayList();

			foreach(ExecutorStorageView executor in m_executors)
			{
				if (executor.Dedicated == dedicatedExecutor)
				{
					threadList.AddRange(GetExecutorThreads(executor.ExecutorId, state));
				}
			}

			return (ThreadStorageView[])threadList.ToArray(typeof(ThreadStorageView));
		}

		public ThreadStorageView[] GetExecutorThreads(bool dedicatedExecutor, bool connectedExecutor, params ThreadState[] state)
		{
			if (m_threads == null || m_executors == null)
			{
				return new ThreadStorageView[0];
			}

			ArrayList threadList = new ArrayList();

			foreach(ExecutorStorageView executor in m_executors)
			{
				if (executor.Dedicated == dedicatedExecutor && executor.Connected == connectedExecutor)
				{
					threadList.AddRange(GetExecutorThreads(executor.ExecutorId, state));
				}
			}

			return (ThreadStorageView[])threadList.ToArray(typeof(ThreadStorageView));
		}


		public void GetApplicationThreadCount(String applicationId, out Int32 totalThreads, out Int32 unfinishedThreads)
		{
			totalThreads = unfinishedThreads = 0;

			if (m_threads == null || m_threads.Count == 0)
			{
				return;
			}

			foreach(ThreadStorageView thread in m_threads)
			{
				if (thread.ApplicationId == applicationId)
				{
					totalThreads ++;

					if (thread.State == ThreadState.Ready || thread.State == ThreadState.Scheduled || thread.State == ThreadState.Started)
					{
						unfinishedThreads ++;
					}
				}
			}
		}

		public Int32 GetApplicationThreadCount(String applicationId, ThreadState threadState)
		{
			Int32 threadCount = 0;

			if (m_threads == null || m_threads.Count == 0)
			{
				return threadCount;
			}

			foreach(ThreadStorageView thread in m_threads)
			{
				if (thread.ApplicationId == applicationId && thread.State == threadState)
				{
					threadCount ++;
				}
			}

			return threadCount;
		}

		public Int32 GetExecutorThreadCount(String executorId, params ThreadState[] threadState)
		{
			Int32 threadCount = 0;

			if (m_threads == null || m_threads.Count == 0 || threadState == null && threadState.Length == 0)
			{
				return threadCount;
			}

			foreach(ThreadStorageView thread in m_threads)
			{
				if (thread.ExecutorId != null && thread.ExecutorId == executorId)
				{
					foreach(ThreadState state in threadState)
					{
						if (thread.State == state)
						{
							threadCount ++;
							break; // no point in continuing since there is only one state for a thread
						}
					}
				}
			}

			return threadCount;
		}

		public void DeleteThread(ThreadStorageView threadToDelete)
		{
			if (m_threads == null || threadToDelete == null)
			{
				return;
			}

			ArrayList remainingThreads = new ArrayList();

			foreach (ThreadStorageView thread in m_threads)
			{
				if (thread.ApplicationId != threadToDelete.ApplicationId || thread.ThreadId != threadToDelete.ThreadId)
				{
					remainingThreads.Add(thread);
				}
			}

			m_threads = remainingThreads;
		}


		#endregion

		#region "XML storage persistence implementation - incomplete"
		/// THIS FUNCTIONALITY IS NOT FULLY IMPLEMENTED AND IT MIGHT BE DISCARDED ALTOGETHER
		/// 
		/// Loading from an XML file is the perfect tool for complex storage setups which would be useful for more in-depth unit testing
		/// Saving to an XML file could be used to dump the current storage state for troubleshooting, for example to receive faulty storages from the field.


		/// <summary>
		/// Save the current storage state into an XML file.
		/// It is important that the file format is easily editable by humans so test cases can easily be maintained.
		/// For this reason we do not use the build-in persistence modules.
		/// </summary>
		/// <param name="filename"></param>
		public void SaveToHumanReadableXmlFile(String filename)
		{
			const String storageDocumentTemplate = "<storage><users/><groups/><group_permissions/><executors/><applications/><threads/></storage>";
			XmlDocument storageDocument = new XmlDocument();

			storageDocument.LoadXml(storageDocumentTemplate);

			XmlNode usersNode = storageDocument.SelectSingleNode("/storage/users");
			XmlNode groupsNode = storageDocument.SelectSingleNode("/storage/groups");
			//XmlNode groupPermissionsNode = storageDocument.SelectSingleNode("/storage/group_permissions");
			XmlNode executorsNode = storageDocument.SelectSingleNode("/storage/executors");
			XmlNode applicationsNode = storageDocument.SelectSingleNode("/storage/applications");
			XmlNode threadsNode = storageDocument.SelectSingleNode("/storage/threads");

			if (m_users != null)
			{
				IEnumerator usersEnumerator = m_users.GetEnumerator();

				while(usersEnumerator.MoveNext())
				{
					UserStorageView user = usersEnumerator.Current as UserStorageView;

					XmlElement userElement = storageDocument.CreateElement("user");

					userElement.SetAttribute("username", user.Username);
					userElement.SetAttribute("password", user.Password);
					userElement.SetAttribute("groupid", user.GroupId.ToString());

					usersNode.AppendChild(userElement);
				}
			}

			if (m_groups != null)
			{
				IEnumerator groupsEnumerator = m_groups.GetEnumerator();

				while(groupsEnumerator.MoveNext())
				{
					GroupStorageView group = groupsEnumerator.Current as GroupStorageView;

					XmlElement groupElement = storageDocument.CreateElement("group");

					groupElement.SetAttribute("groupname", group.GroupName);
					groupElement.SetAttribute("groupid", group.GroupId.ToString());

					groupsNode.AppendChild(groupElement);
				}
			}

			//		private Hashtable m_groupPermissions;
//			if (m_groupPermissions != null)
//			{
//				IEnumerator groupPermissionsEnumerator = m_groupPermissions.GetEnumerator();
//
//				while(groupPermissionsEnumerator.MoveNext())
//				{
//					GroupPermissionStorageView group = groupPermissionsEnumerator.Current as GroupStorageView;
//
//					XmlElement groupElement = storageDocument.CreateElement("group");
//
//					groupElement.SetAttribute("groupname", group.GroupName);
//					groupElement.SetAttribute("groupid", group.GroupId.ToString());
//
//					groupsNode.AppendChild(groupElement);
//				}
//			}


			if (m_executors != null)
			{
				IEnumerator executorsEnumerator = m_executors.GetEnumerator();

				while(executorsEnumerator.MoveNext())
				{
					ExecutorStorageView executor = executorsEnumerator.Current as ExecutorStorageView;

					XmlElement executorElement = storageDocument.CreateElement("executor");

					executorElement.SetAttribute("executorid", executor.ExecutorId);
					executorElement.SetAttribute("dedicated", executor.Dedicated.ToString());
					executorElement.SetAttribute("connected", executor.Connected.ToString());
					executorElement.SetAttribute("pingtime", executor.PingTime.ToString());
					executorElement.SetAttribute("hostname", executor.HostName);
					executorElement.SetAttribute("port", executor.Port.ToString());
					executorElement.SetAttribute("username", executor.Username);
					executorElement.SetAttribute("maxcpu", executor.MaxCpu.ToString());
					executorElement.SetAttribute("cpuusage", executor.CpuUsage.ToString());
					executorElement.SetAttribute("availablecpu", executor.AvailableCpu.ToString());
					executorElement.SetAttribute("totalcpuusage", executor.TotalCpuUsage.ToString());
					executorElement.SetAttribute("maxmemory", executor.MaxMemory.ToString());
					executorElement.SetAttribute("maxdisk", executor.MaxDisk.ToString());
					executorElement.SetAttribute("numberofcpu", executor.NumberOfCpu.ToString());
					executorElement.SetAttribute("os", executor.Os);
					executorElement.SetAttribute("architecture", executor.Architecture);

					executorsNode.AppendChild(executorElement);
				}
			}

			if (m_applications != null)
			{
				IEnumerator applicationsEnumerator = m_applications.GetEnumerator();

				while(applicationsEnumerator.MoveNext())
				{
					ApplicationStorageView application = applicationsEnumerator.Current as ApplicationStorageView;

					XmlElement applicationElement = storageDocument.CreateElement("application");

					applicationElement.SetAttribute("applicationid", application.ApplicationId);
					applicationElement.SetAttribute("state", application.State.ToString());
					applicationElement.SetAttribute("timecreated", application.TimeCreated.ToString());
					applicationElement.SetAttribute("primary", application.Primary.ToString());
					applicationElement.SetAttribute("username", application.Username.ToString());
					applicationElement.SetAttribute("totalthreads", application.TotalThreads.ToString());
					applicationElement.SetAttribute("unfinishedthreads", application.UnfinishedThreads.ToString());

					applicationsNode.AppendChild(applicationElement);
				}
			}

			if (m_threads != null)
			{
				IEnumerator threadsEnumerator = m_threads.GetEnumerator();

				while(threadsEnumerator.MoveNext())
				{
					ThreadStorageView thread = threadsEnumerator.Current as ThreadStorageView;

					XmlElement threadElement = storageDocument.CreateElement("thread");

					threadElement.SetAttribute("internalthreadid", thread.InternalThreadId.ToString());
					threadElement.SetAttribute("applicationid", thread.ApplicationId);
					threadElement.SetAttribute("executorid", thread.ExecutorId);
					threadElement.SetAttribute("threadid", thread.ThreadId.ToString());
					threadElement.SetAttribute("state", thread.State.ToString());
					threadElement.SetAttribute("timestarted", thread.TimeStarted.ToString());
					threadElement.SetAttribute("timefinished", thread.TimeFinished.ToString());
					threadElement.SetAttribute("priority", thread.Priority.ToString());
					threadElement.SetAttribute("failed", thread.Failed.ToString());

					threadsNode.AppendChild(threadElement);
				}
			}

			storageDocument.Save(filename);
		}

		/// <summary>
		/// Load the storage information from an XML file.
		/// </summary>
		/// <param name="filename"></param>
		public void LoadFromHumanReadableXmlFile(String filename)
		{
			
		}
		#endregion

		#region IManagerStorageSetup Members

		public void TearDownStorage()
		{
		}

		public void CreateStorage(String databaseName)
		{
		}

		public void InitializeStorageData()
		{
			CreateDefaultObjects(this);
		}

		public void SetUpStorage()
		{
		}

		#endregion
	}
}
