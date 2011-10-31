#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  IManagerStorage.cs
* Project       :  Alchemi.Core.Manager.Storage
* Created on    :  30 August 2005
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
using Alchemi.Core.Utility;

namespace Alchemi.Core.Manager.Storage
{
	/// <summary>
	/// Define the Manager Storage interface.
	/// Contains an entry for each storage operation the manager needs to do
	/// The manager storage is meant to offer a uniform look at the data needed by the manager.
	/// 
	/// Storage guildelines:
	/// Writing and returning data from the storage should not be done with storage specific data structures
	///		such as DataSet, DataTable and so on. Rather, the data should be handled in the format needed by 
	///		the application such as custom objects.
	/// </summary>
	public interface IManagerStorage
	{
		/// <summary>
		/// Verifies if the connection to the back-end storage is alive and valid.
		/// </summary>
		/// <returns></returns>
		bool VerifyConnection();

		/// <summary>
		/// Check if a permission is set.
		/// </summary>
		/// <param name="sc">Security credentials to use in the check.</param>
		/// <param name="perm">Permission to check for</param>
		/// <returns>true if the permission is set, false otherwise</returns>
		bool CheckPermission(SecurityCredentials sc, Permission perm);

		/// <summary>
		/// Authenticate a user's security credentials.
		/// </summary>
		/// <param name="sc">Security credentials to authenticate.</param>
		/// <returns>True if the authentication is successful, false otherwise.</returns>
		bool AuthenticateUser(SecurityCredentials sc);

		/// <summary>
		/// Add a list of users to the storage.
		/// </summary>
		/// <param name="users"></param>
		void AddUsers(UserStorageView[] users);

		/// <summary>
		/// Update a list of users in the storage.
		/// </summary>
		/// <param name="updates">Users to be updated.</param>
		void UpdateUsers(UserStorageView[] updates);

		/// <summary>
		/// Get an array with all the users found in the current storage.
		/// </summary>
		/// <returns></returns>
		UserStorageView[] GetUsers();

		/// <summary>
		/// Delete the given user.
		/// Only the username has to be set in the UserStorageView structure, all other data is ignored.
		/// </summary>
		/// <param name="userToDelete"></param>
		void DeleteUser(UserStorageView userToDelete);

		/// <summary>
		/// Add alist of groups to the storage.
		/// </summary>
		/// <param name="groups"></param>
		void AddGroups(GroupStorageView[] groups);
		
		/// <summary>
		/// Get a list of all the groups in the storage.
		/// </summary>
		/// <returns></returns>
		GroupStorageView[] GetGroups();

		/// <summary>
		/// Get the details for the group with the requested Id from storage.
		/// </summary>
		/// <param name="groupId"></param>
		/// <returns></returns>
		GroupStorageView GetGroup(Int32 groupId);

		/// <summary>
		/// Add group permissions to the given group Id.
		/// The permission is added to the existing group permissions.
		/// </summary>
		/// <param name="groupId">The group Id</param>
		/// <param name="permission">Permission to set.</param>
		void AddGroupPermission(Int32 groupId, Permission permission);

		/// <summary>
		/// Get a list of the current group permissions.
		/// </summary>
		/// <param name="groupId"></param>
		/// <returns></returns>
		Permission[] GetGroupPermissions(Int32 groupId);

		/// <summary>
		/// Get a list of the current group permissions.
		/// </summary>
		/// <param name="groupId"></param>
		/// <returns></returns>
		PermissionStorageView[] GetGroupPermissionStorageView(Int32 groupId);

		/// <summary>
		/// Delete the given group and all the users associated with it.
		/// </summary>
		/// <param name="groupToDelete"></param>
		void DeleteGroup(GroupStorageView groupToDelete);

		/// <summary>
		/// Get a list with all the users in a given group.
		/// </summary>
		/// <param name="groupId"></param>
		/// <returns></returns>
		UserStorageView[] GetGroupUsers(Int32 groupId);

		/// <summary>
		/// Add an executor to the storage.
		/// </summary>
		/// <param name="executor"></param>
		/// <returns></returns>
		String AddExecutor(ExecutorStorageView executor);

		/// <summary>
		/// Update the details for an existing executor in the storage.
		/// </summary>
		/// <param name="executor"></param>
		void UpdateExecutor(ExecutorStorageView executor);

        /// <summary>
        /// Delete the given executor from storage.
        /// </summary>
        /// <param name="executor"></param>
        void DeleteExecutor(ExecutorStorageView executor);

		/// <summary>
		/// Get a list with all the executors in the storage.
		/// </summary>
		/// <returns></returns>
		ExecutorStorageView[] GetExecutors();

		/// <summary>
		/// Get a list with all executors in the storage that have the requested Dedicated property.
		/// </summary>
		/// <param name="dedicated"></param>
		/// <returns></returns>
		ExecutorStorageView[] GetExecutors(TriStateBoolean dedicated);

		/// <summary>
		/// Get a list with all the executors in the storage that have the requested Dedicated and Connected properties.
		/// </summary>
		/// <param name="dedicated"></param>
		/// <param name="connected"></param>
		/// <returns></returns>
		ExecutorStorageView[] GetExecutors(TriStateBoolean dedicated, TriStateBoolean connected);

		/// <summary>
		/// Get the details for the exector with the given executor Id.
		/// </summary>
		/// <param name="executorId"></param>
		/// <returns></returns>
		ExecutorStorageView GetExecutor(String executorId);

		/// <summary>
		/// Add an application to the storage.
		/// </summary>
		/// <param name="application"></param>
		/// <returns></returns>
		String AddApplication(ApplicationStorageView application);

		/// <summary>
		/// Update the details of an application in the storage.
		/// </summary>
		/// <param name="updatedApplication"></param>
		void UpdateApplication(ApplicationStorageView updatedApplication);

		/// <summary>
		/// Get all applications in the storage.
		/// Do not populate the thread count properties for the returned objects.
		/// </summary>
		/// <returns></returns>
		ApplicationStorageView[] GetApplications();

		/// <summary>
		/// Get all applications in the storage.
		/// </summary>
		/// <param name="populateThreadCount"></param>
		/// <returns></returns>
		ApplicationStorageView[] GetApplications(bool populateThreadCount);

		/// <summary>
		/// Delete application and all associated threads
		/// </summary>
		/// <param name="applicationToDelete"></param>
		void DeleteApplication(ApplicationStorageView applicationToDelete);

		/// <summary>
		/// Get the user's applications
		/// </summary>
		/// <param name="userName"></param>
		/// <param name="populateThreadCount"></param>
		/// <returns></returns>
		ApplicationStorageView[] GetApplications(String userName, bool populateThreadCount);

		/// <summary>
		/// Get the details for the application with the given application Id.
		/// </summary>
		/// <param name="applicationId"></param>
		/// <returns></returns>
		ApplicationStorageView GetApplication(String applicationId);

		/// <summary>
		/// Add a thread to the storage.
		/// </summary>
		/// <param name="thread"></param>
		/// <returns></returns>
		Int32 AddThread(ThreadStorageView thread);

		/// <summary>
		/// Update the details of a thread in the storage.
		/// </summary>
		/// <param name="updatedThread"></param>
		void UpdateThread(ThreadStorageView updatedThread);

		/// <summary>
		/// Get the details for a given thread in an application.
		/// </summary>
		/// <param name="applicationId"></param>
		/// <param name="threadId"></param>
		/// <returns></returns>
		ThreadStorageView GetThread(String applicationId, Int32 threadId);
		
		/// <summary>
		/// Get all threads with the given states.
		/// </summary>
		/// <param name="state">a parameter array with a list of all requested thread states.</param>
		/// <returns></returns>
		ThreadStorageView[] GetThreads(params ThreadState[] state);

		/// <summary>
		/// Get all threads whose application has the requested thread state.
		/// </summary>
		/// <param name="appState">Application state.</param>
		/// <param name="threadState">Thread states.</param>
		/// <returns></returns>
		ThreadStorageView[] GetThreads(ApplicationState appState, params ThreadState[] threadState);

		/// <summary>
		/// Get all threads with the given states whithin an application.
		/// </summary>
		/// <param name="applicationId"></param>
		/// <param name="state"></param>
		/// <returns></returns>
		ThreadStorageView[] GetThreads(String applicationId, params ThreadState[] state);

		/// <summary>
		/// Get all threads with the given states whithin an executor.
		/// </summary>
		/// <param name="executorId"></param>
		/// <param name="state"></param>
		/// <returns></returns>
		ThreadStorageView[] GetExecutorThreads(String executorId, params ThreadState[] state);

		/// <summary>
		/// Get all threads with the given states and where the executors's dedicated status is as requested.
		/// </summary>
		/// <param name="dedicatedExecutor"></param>
		/// <param name="state"></param>
		/// <returns></returns>
		ThreadStorageView[] GetExecutorThreads(bool dedicatedExecutor, params ThreadState[] state);

		/// <summary>
		/// Get all threads with the given states and where the executors's dedicated and connected statuses are as requested.
		/// </summary>
		/// <param name="dedicatedExecutor"></param>
		/// <param name="connectedExecutor"></param>
		/// <param name="state"></param>
		/// <returns></returns>
		ThreadStorageView[] GetExecutorThreads(bool dedicatedExecutor, bool connectedExecutor, params ThreadState[] state);

		/// <summary>
		/// Get total and unfinished thread count for an application.
		/// </summary>
		/// <param name="applicationId"></param>
		/// <param name="totalthreads"></param>
		/// <param name="unfinishedThreads"></param>
		void GetApplicationThreadCount(String applicationId, out Int32 totalthreads, out Int32 unfinishedThreads);

		/// <summary>
		/// Get the number of threads with a given state in an application.
		/// </summary>
		/// <param name="applicationId"></param>
		/// <param name="threadState"></param>
		/// <returns></returns>
		Int32 GetApplicationThreadCount(String applicationId, ThreadState threadState);

		/// <summary>
		/// Get the number of threads on an executor.
		/// </summary>
		/// <param name="executorId"></param>
		/// <param name="threadState"></param>
		/// <returns></returns>
		Int32 GetExecutorThreadCount(String executorId, params ThreadState[] threadState);

		/// <summary>
		/// Delete a thread from the storage.
		/// </summary>
		/// <param name="threadToDelete"></param>
		void DeleteThread(ThreadStorageView threadToDelete);


		/// <summary>
		/// Get system summary information from the storage.
		/// </summary>
		/// <returns>
		/// An object with the summary information or null if the storage does not implement system summary.
		/// </returns>
		SystemSummary GetSystemSummary();

		//for generic queries
		//	22 January 2006 - Tibor Biro (tb@tbiro.com) - Removed from the IManagerStorage interface.
		//DataSet RunSqlReturnDataSet(string query);

		//	22 January 2006 - Tibor Biro (tb@tbiro.com) - Do not use through this interface!
		//	This will be removed as soon as the DBInstall utility is retired.
		//void RunSql(string sqlQuery);
	}
}
