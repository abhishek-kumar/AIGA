#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  ManagerStorageTester.cs
* Project       :  Alchemi.Tester.Manager.Storage
* Created on    :  22 September 2005
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

using Alchemi.Core;
using Alchemi.Core.Manager;
using Alchemi.Core.Manager.Storage;
using Alchemi.Core.Owner;
using Alchemi.Core.Utility;

using NUnit.Framework;

namespace Alchemi.Tester.Manager.Storage
{
	/// <summary>
	/// Test ManagerStorage features. 
	/// While this is not a TestFixture all classes that inherit it will automatically get the tests
	/// defined here. So we can easily define storage tests, and test all storage providers against them
	/// to make sure there is consistent behavior.
	/// </summary>
	public abstract class ManagerStorageTester
	{
		private const Int32 c_DefaultGroupCount = 3;
		private const Int32 c_DefaultUserCount = 3;

		public abstract IManagerStorage ManagerStorage
		{
			get;
		}

		private void AddUser(String username, String password)
		{
			AddUser(username, password, 0);
		}

		private void AddUser(String username, String password, Int32 groupId)
		{
			UserStorageView[] users = new UserStorageView[1];

			users[0] = new UserStorageView(username, password, groupId);

			ManagerStorage.AddUsers(users);
		}

		private void AddGroup(Int32 groupId, String groupName)
		{
			GroupStorageView[] groups = new GroupStorageView[1];

			groups[0] = new GroupStorageView(groupId, groupName);

			ManagerStorage.AddGroups(groups);
		}

		private String AddExecutor(
			bool dedicated,
			bool connected,
			DateTime pingTime,
			String hostname,
			Int32 port,
			String username,
			Int32 maxCpu,
			Int32 cpuUsage,
			Int32 availableCpu,
			float totalCpuUsage
		)
		{
			ExecutorStorageView executor = new ExecutorStorageView(
						dedicated,
						connected,
						pingTime,
						hostname,
						port,
						username,
						maxCpu,
						cpuUsage,
						availableCpu,
						totalCpuUsage
					);

			return ManagerStorage.AddExecutor(executor);
		}

		private String AddApplication(
			ApplicationState state,
			DateTime timeCreated,
			bool primary,
			String username
			)
		{
			ApplicationStorageView application = new ApplicationStorageView(
				state,
				timeCreated,
				primary,
				username
				);

			return ManagerStorage.AddApplication(application);
		}

		private void AddThread(
			String applicationId,
			String executorId,
			Int32 threadId,
			ThreadState state,
			DateTime timeStarted,
			DateTime timeFinished,
			Int32 priority,
			bool failed
			)
		{
			ThreadStorageView thread = new ThreadStorageView(
				applicationId,
				executorId,
				threadId,
				state,
				timeStarted,
				timeFinished,
				priority,
				failed
				);

			ManagerStorage.AddThread(thread);
		}


		#region "AddUsers Tests"

		/// <summary>
		/// Add a new user.
		/// Make sure there are no errors.
		/// </summary>
		[Test]
		public void AddUsersTest1()
		{
			AddUser("username", "password");
		}

		/// <summary>
		/// Add a null array.
		/// No errors are expected.
		/// </summary>
		[Test]
		public void AddUsersTest2()
		{
			ManagerStorage.AddUsers(null);
		}

		#endregion

		#region "UpdateUsers Tests"
		
		/// <summary>
		/// Add a new user.
		/// Update the user's password and group.
		/// The updates should stick.
		/// </summary>
		[Test]
		public void UpdateUsersTest1()
		{
			AddUser("username1", "password1", 0);

			UserStorageView[] userUpdates = new UserStorageView[1];

			userUpdates[0] = new UserStorageView("username1", "password2", 1);

			ManagerStorage.UpdateUsers(userUpdates);

			UserStorageView[] users = ManagerStorage.GetUsers();
			
			Assert.AreEqual(c_DefaultUserCount + 1, users.Length);
			Assert.AreEqual("username1", users[c_DefaultUserCount].Username);
			Assert.AreEqual(HashUtil.GetHash("password2", HashUtil.HashType.MD5), users[c_DefaultUserCount].PasswordMd5Hash);
			Assert.AreEqual(1, users[c_DefaultUserCount].GroupId);
		}

		/// <summary>
		/// Add no user
		/// Update the user's password and group.
		/// The user list should be empty, no errors are expected.
		/// </summary>
		[Test]
		public void UpdateUsersTest2()
		{
			UserStorageView[] userUpdates = new UserStorageView[1];

			userUpdates[0] = new UserStorageView("username1", "password2", 55);

			ManagerStorage.UpdateUsers(userUpdates);

			UserStorageView[] users = ManagerStorage.GetUsers();
			
			Assert.AreEqual(c_DefaultUserCount, users.Length);
		}

		/// <summary>
		/// Add a new user
		/// Set the update array to null;
		/// The user list should not be modified, no errors are expected.
		/// </summary>
		[Test]
		public void UpdateUsersTest3()
		{
			AddUser("username1", "password1", 0);

			ManagerStorage.UpdateUsers(null);

			UserStorageView[] users = ManagerStorage.GetUsers();
			
			Assert.AreEqual(c_DefaultUserCount + 1, users.Length);
			Assert.AreEqual("username1", users[c_DefaultUserCount].Username);
			Assert.AreEqual(HashUtil.GetHash("password1", HashUtil.HashType.MD5), users[c_DefaultUserCount].PasswordMd5Hash);
			Assert.AreEqual(0, users[c_DefaultUserCount].GroupId);
		}

		#endregion

		#region "DeleteUser Tests"
		
		/// <summary>
		/// Add a new user.
		/// Delete the user.
		/// </summary>
		[Test]
		public void DeleteUserTest1()
		{
			AddUser("username1", "password1", 0);

			UserStorageView[] usersBefore = ManagerStorage.GetUsers();

			ManagerStorage.DeleteUser(new UserStorageView("username1"));

			UserStorageView[] usersAfter = ManagerStorage.GetUsers();
			
			Assert.AreEqual(c_DefaultUserCount + 1, usersBefore.Length);
			Assert.AreEqual(c_DefaultUserCount, usersAfter.Length);
		}

		/// <summary>
		/// Add no user
		/// Delete a user
		/// The user list should be empty, no errors are expected.
		/// </summary>
		[Test]
		public void DeleteUserTest2()
		{
			ManagerStorage.DeleteUser(new UserStorageView("username1"));

			UserStorageView[] users = ManagerStorage.GetUsers();
			
			Assert.AreEqual(c_DefaultUserCount, users.Length);
		}

		/// <summary>
		/// Add a new user
		/// Set the delete user object to null;
		/// The user list should not be modified, no errors are expected.
		/// </summary>
		[Test]
		public void DeleteUserTest3()
		{
			AddUser("username1", "password1", 0);

			ManagerStorage.DeleteUser(null);

			UserStorageView[] users = ManagerStorage.GetUsers();
			
			Assert.AreEqual(c_DefaultUserCount + 1, users.Length);
			Assert.AreEqual("username1", users[c_DefaultUserCount].Username);
			Assert.AreEqual(HashUtil.GetHash("password1", HashUtil.HashType.MD5), users[c_DefaultUserCount].PasswordMd5Hash);
			Assert.AreEqual(0, users[c_DefaultUserCount].GroupId);
		}

		#endregion

		#region "AuthenticateUser Tests"
		
		/// <summary>
		/// Add a new user.
		/// Verify user credentials with valid user.
		/// Should authenticate.
		/// </summary>
		[Test]
		public void AuthenticateUserTest1()
		{
			AddUser("username1", "password1");
			SecurityCredentials sc = new SecurityCredentials("username1", HashUtil.GetHash("password1", HashUtil.HashType.MD5));

			bool result = ManagerStorage.AuthenticateUser(sc);

			Assert.IsTrue(result);
		}

		/// <summary>
		/// Add a new user.
		/// Verify user credentials with invalid user.
		/// Should not authenticate.
		/// </summary>
		[Test]
		public void AuthenticateUserTest2()
		{
			AddUser("username1", "password1");
			SecurityCredentials sc = new SecurityCredentials("username2", HashUtil.GetHash("password2", HashUtil.HashType.MD5));

			bool result = ManagerStorage.AuthenticateUser(sc);

			Assert.IsFalse(result);
		}
	
		/// <summary>
		/// Do not add any user. This will leave the user array empty.
		/// Verify user credentials with valid user.
		/// Should not authenticate.
		/// </summary>
		[Test]
		public void AuthenticateUserTest3()
		{
			SecurityCredentials sc = new SecurityCredentials("username1", HashUtil.GetHash("password1", HashUtil.HashType.MD5));

			bool result = ManagerStorage.AuthenticateUser(sc);

			Assert.IsFalse(result);
		}

		/// <summary>
		/// Add a new user.
		/// Verify user credentials with null values.
		/// Should not authenticate, no errors are expected.
		/// </summary>
		[Test]
		public void AuthenticateUserTest4()
		{
			AddUser("username1", "password1");
			SecurityCredentials sc = new SecurityCredentials(null, null);

			bool result = ManagerStorage.AuthenticateUser(sc);

			Assert.IsFalse(result);
		}
	
		/// <summary>
		/// Add a new user.
		/// Verify user credentials with null credential object.
		/// Should not authenticate, no errors are expected.
		/// </summary>
		[Test]
		public void AuthenticateUserTest5()
		{
			AddUser("username1", "password1");

			bool result = ManagerStorage.AuthenticateUser(null);

			Assert.IsFalse(result);
		}
	
		#endregion

		#region "GetUserList Tests"

		/// <summary>
		/// Add a new user.
		/// Get the users list.
		/// The list should only contain the newly added user.
		/// </summary>
		[Test]
		public void GetUserListTest1()
		{
			AddUser("username1", "password1");
			
			UserStorageView[] users;

			users = ManagerStorage.GetUsers();

			Assert.AreEqual(c_DefaultUserCount + 1, users.Length);
			Assert.AreEqual("username1", users[c_DefaultUserCount].Username);
			Assert.AreEqual(HashUtil.GetHash("password1", HashUtil.HashType.MD5), users[c_DefaultUserCount].PasswordMd5Hash);

		}

		/// <summary>
		/// Add 3 users.
		/// Get the users list.
		/// The list should contain 3 items.
		/// </summary>
		[Test]
		public void GetUserListTest2()
		{
			AddUser("username1", "password1");
			AddUser("username2", "password2");
			AddUser("username3", "password3");
			
			UserStorageView[] users;

			users = ManagerStorage.GetUsers();

			Assert.AreEqual(c_DefaultUserCount + 3, users.Length);
		}

		/// <summary>
		/// Add no users.
		/// Get the users list.
		/// The list should be empty but not null.
		/// </summary>
		[Test]
		public void GetUserListTest3()
		{
			UserStorageView[] users;

			users = ManagerStorage.GetUsers();

			Assert.AreEqual(c_DefaultUserCount, users.Length);
		}


		#endregion
	
		#region "AddGroups Tests"

		/// <summary>
		/// Add a new group.
		/// No errors are expected.
		/// </summary>
		[Test]
		public void AddGroupsTest1()
		{
			AddGroup(87, "group0");
		}

		/// <summary>
		/// Add a null array.
		/// No errors are expected.
		/// </summary>
		[Test]
		public void AddGroupsTest2()
		{
			ManagerStorage.AddGroups(null);
		}

		#endregion

		#region "GetGroups Tests"

		/// <summary>
		/// Add a new group.
		/// Get the group list.
		/// The list should only contain the newly added group.
		/// </summary>
		[Test]
		public void GetGroupsTest1()
		{
			AddGroup(78, "group0");
			
			GroupStorageView[] groups = ManagerStorage.GetGroups();

			Assert.AreEqual(c_DefaultGroupCount + 1, groups.Length);
			Assert.AreEqual(78, groups[c_DefaultGroupCount].GroupId);
			Assert.AreEqual("group0", groups[c_DefaultGroupCount].GroupName);

		}

		/// <summary>
		/// Add 3 groups.
		/// Get the group list.
		/// The list should contain 3 items.
		/// </summary>
		[Test]
		public void GetGroupsTest2()
		{
			AddGroup(77, "group0");
			AddGroup(78, "group1");
			AddGroup(79, "group2");
			
			GroupStorageView[] groups = ManagerStorage.GetGroups();

			Assert.AreEqual(c_DefaultGroupCount + 3, groups.Length);
		}

		/// <summary>
		/// Add no groups.
		/// Get the group list.
		/// The list should be empty but not null. No error is expected
		/// </summary>
		[Test]
		public void GetGroupsTest3()
		{
			GroupStorageView[] groups = ManagerStorage.GetGroups();

			Assert.AreEqual(c_DefaultGroupCount, groups.Length);
		}


		#endregion

		#region "GetGroup Tests"

		/// <summary>
		/// Add a new group.
		/// Get the group
		/// </summary>
		[Test]
		public void GetGroupTestSimpleScenario()
		{
			AddGroup(12, "group0");
			
			GroupStorageView group = ManagerStorage.GetGroup(12);

			Assert.AreEqual(12, group.GroupId);
			Assert.AreEqual("group0", group.GroupName);
		}

		[Test]
		public void GetGroupNotFound()
		{			
			AddGroup(12, "group0");

			GroupStorageView group = ManagerStorage.GetGroup(13);

			Assert.IsNull(group);
		}

		[Test]
		public void GetGroupNothingAdded()
		{			
			GroupStorageView group = ManagerStorage.GetGroup(13);

			Assert.IsNull(group);
		}


		#endregion

		#region "AddGroupPermission Tests"
		/// <summary>
		/// Add a permission to a group
		/// Should throw no exceptions
		/// </summary>
		[Test]
		public void AddGroupPermissionTestSimpleScenario()
		{
			Int32 groupId = 1;

			AddGroup(groupId, "test");

			ManagerStorage.AddGroupPermission(groupId, Permission.ExecuteThread);
		}
		#endregion

		#region "GetGroupPermissions Tests"

		/// <summary>
		/// Add a permission to a group
		/// Get the permissions, it should be there
		/// </summary>
		[Test]
		public void GetGroupPermissionsTestSimpleScenario()
		{
			Int32 groupId = 55;

			AddGroup(groupId, "test");

			ManagerStorage.AddGroupPermission(groupId, Permission.ExecuteThread);

			Permission[] result = ManagerStorage.GetGroupPermissions(groupId);

			Assert.AreEqual(1, result.Length);
			Assert.AreEqual(Permission.ExecuteThread, result[0]);
		}

		/// <summary>
		/// Add no permissions
		/// Get the permissions, there should be none
		/// </summary>
		[Test]
		public void GetGroupPermissionsTestNoPermissions()
		{
			Int32 groupId = 55;

			AddGroup(groupId, "test");

			Permission[] result = ManagerStorage.GetGroupPermissions(groupId);

			Assert.AreEqual(0, result.Length);
		}

		/// <summary>
		/// Add the same permission several times
		/// Get the permissions, there should be only one
		/// </summary>
		[Test]
		public void GetGroupPermissionsTestDuplicates()
		{
			Int32 groupId = 55;

			AddGroup(groupId, "test");

			ManagerStorage.AddGroupPermission(groupId, Permission.ExecuteThread);
			ManagerStorage.AddGroupPermission(groupId, Permission.ExecuteThread);
			ManagerStorage.AddGroupPermission(groupId, Permission.ExecuteThread);

			Permission[] result = ManagerStorage.GetGroupPermissions(groupId);

			Assert.AreEqual(1, result.Length);
			Assert.AreEqual(Permission.ExecuteThread, result[0]);
		}

		#endregion

		#region "GetGroupPermissionStorageView Tests"

		/// <summary>
		/// Add a permission to a group
		/// Get the permissions, it should be there
		/// </summary>
		[Test]
		public void GetGroupPermissionStorageViewTestSimpleScenario()
		{
			Int32 groupId = 55;

			AddGroup(groupId, "test");

			ManagerStorage.AddGroupPermission(groupId, Permission.ExecuteThread);

			PermissionStorageView[] result = ManagerStorage.GetGroupPermissionStorageView(groupId);

			Assert.AreEqual(1, result.Length);
			Assert.AreEqual((Int32)Permission.ExecuteThread, result[0].PermissionId);
		}

		/// <summary>
		/// Add no permissions
		/// Get the permissions, there should be none
		/// </summary>
		[Test]
		public void GetGroupPermissionStorageViewTestNoPermissions()
		{
			Int32 groupId = 55;

			AddGroup(groupId, "test");

			PermissionStorageView[] result = ManagerStorage.GetGroupPermissionStorageView(groupId);

			Assert.AreEqual(0, result.Length);
		}

		/// <summary>
		/// Add the same permission several times
		/// Get the permissions, there should be only one
		/// </summary>
		[Test]
		public void GetGroupPermissionStorageViewTestDuplicates()
		{
			Int32 groupId = 55;

			AddGroup(groupId, "test");

			ManagerStorage.AddGroupPermission(groupId, Permission.ExecuteThread);
			ManagerStorage.AddGroupPermission(groupId, Permission.ExecuteThread);
			ManagerStorage.AddGroupPermission(groupId, Permission.ExecuteThread);

			PermissionStorageView[] result = ManagerStorage.GetGroupPermissionStorageView(groupId);

			Assert.AreEqual(1, result.Length);
			Assert.AreEqual((Int32)Permission.ExecuteThread, result[0].PermissionId);
		}

		#endregion

		#region "DeleteGroup Tests"
		
		/// <summary>
		/// Add a new group.
		/// Delete the group.
		/// </summary>
		[Test]
		public void DeleteGroupTest1()
		{
			Int32 groupId = 54;
			AddGroup(groupId, "group1");

			GroupStorageView[] groupsBefore = ManagerStorage.GetGroups();

			ManagerStorage.DeleteGroup(new GroupStorageView(groupId));

			GroupStorageView[] groupsAfter = ManagerStorage.GetGroups();
			
			Assert.AreEqual(c_DefaultGroupCount + 1, groupsBefore.Length);
			Assert.AreEqual(c_DefaultGroupCount, groupsAfter.Length);
		}

		/// <summary>
		/// Add no group
		/// Delete a group
		/// The group list should be empty, no errors are expected.
		/// </summary>
		[Test]
		public void DeleteGroupTest2()
		{
			ManagerStorage.DeleteGroup(new GroupStorageView(55));

			GroupStorageView[] groupsAfter = ManagerStorage.GetGroups();
			
			Assert.AreEqual(c_DefaultGroupCount, groupsAfter.Length);
		}

		/// <summary>
		/// Add a new group
		/// Set the delete group object to null;
		/// The group list should not be modified, no errors are expected.
		/// </summary>
		[Test]
		public void DeleteGroupTest3()
		{
			Int32 groupId = 54;
			AddGroup(groupId, "group1");

			GroupStorageView[] groupsBefore = ManagerStorage.GetGroups();

			ManagerStorage.DeleteGroup(null);

			GroupStorageView[] groupsAfter = ManagerStorage.GetGroups();
			
			Assert.AreEqual(c_DefaultGroupCount + 1, groupsBefore.Length);
			Assert.AreEqual(c_DefaultGroupCount + 1, groupsAfter.Length);
		}

		/// <summary>
		/// The users associated with the group should also be removed.
		/// </summary>
		[Test]
		public void DeleteGroupTestDeleteGroupWithUsers()
		{
			Int32 groupId1 = 54;
			Int32 groupId2 = 55;
			AddGroup(groupId1, "group1");
			AddGroup(groupId2, "group2");
			AddUser("username1", "password1", groupId1);
			AddUser("username2", "password2", groupId1);
			AddUser("username3", "password3", groupId2);
			AddUser("username4", "password4", groupId2);

			GroupStorageView[] groupsBefore = ManagerStorage.GetGroups();

			ManagerStorage.DeleteGroup(new GroupStorageView(groupId2));

			GroupStorageView[] groupsAfter = ManagerStorage.GetGroups();

			UserStorageView[] usersAfter = ManagerStorage.GetUsers();
			
			Assert.AreEqual(c_DefaultGroupCount + 2, groupsBefore.Length);
			Assert.AreEqual(c_DefaultGroupCount + 1, groupsAfter.Length);
			Assert.AreEqual(c_DefaultUserCount + 2, usersAfter.Length);
		}

		#endregion

		#region "GetGroupUsers Tests"
		
		[Test]
		public void GetGroupUsersTestSimpleScenario()
		{
			Int32 groupId1 = 54;
			Int32 groupId2 = 55;
			AddGroup(groupId1, "group1");
			AddGroup(groupId2, "group2");
			AddUser("username1", "password1", groupId1);
			AddUser("username2", "password2", groupId1);
			AddUser("username3", "password3", groupId2);
			AddUser("username4", "password4", groupId2);
			AddUser("username5", "password4", groupId2);

			UserStorageView[] users = ManagerStorage.GetGroupUsers(groupId2);
			
			Assert.AreEqual(3, users.Length);
		}

		[Test]
		public void GetGroupUsersTestNoUsers()
		{
			Int32 groupId1 = 54;
			Int32 groupId2 = 55;

			AddGroup(groupId1, "group1");
			AddGroup(groupId2, "group2");

			UserStorageView[] users = ManagerStorage.GetGroupUsers(groupId2);
			
			Assert.AreEqual(0, users.Length);
		}

		[Test]
		public void GetGroupUsersTestNoGroups()
		{
			UserStorageView[] users = ManagerStorage.GetGroupUsers(55);
			
			Assert.AreEqual(0, users.Length);
		}

		#endregion

		#region "CheckPermission Tests"

		/// <summary>
		/// Add a group
		/// Add a user to the group
		/// Add a permission to a group
		/// Check permission, it should be there
		/// </summary>
		[Test]
		public void CheckPermissionTestSimpleScenario()
		{
			Int32 groupId = 56;

			AddGroup(groupId, "test");

			AddUser("username1", "password1", groupId);

			ManagerStorage.AddGroupPermission(groupId, Permission.ManageUsers);

			SecurityCredentials sc = new SecurityCredentials("username1", HashUtil.GetHash("password1", HashUtil.HashType.MD5));

			bool result = ManagerStorage.CheckPermission(sc, Permission.ManageUsers);

			Assert.IsTrue(result);
		}

		/// <summary>
		/// Add no group or user
		/// Check permission, it should fail
		/// </summary>
		[Test]
		public void CheckPermissionTestNoGroupsOrUsers()
		{
			SecurityCredentials sc = new SecurityCredentials("username1", HashUtil.GetHash("password1", HashUtil.HashType.MD5));

			bool result = ManagerStorage.CheckPermission(sc, Permission.ManageUsers);

			Assert.IsFalse(result);
		}

		/// <summary>
		/// Add a group
		/// Add a user to the group
		/// Add a high level permission: ManageUsers
		/// Check a lower level permission: ExecuteThread, it should be there
		/// </summary>
		[Test]
		public void CheckPermissionTestHigherLevelPermission()
		{
			Int32 groupId = 56;

			AddGroup(groupId, "test");

			AddUser("username1", "password1", groupId);

			ManagerStorage.AddGroupPermission(groupId, Permission.ManageUsers);

			SecurityCredentials sc = new SecurityCredentials("username1", HashUtil.GetHash("password1", HashUtil.HashType.MD5));

			bool result = ManagerStorage.CheckPermission(sc, Permission.ExecuteThread);

			Assert.IsTrue(result);
		}

		#endregion

		#region "AddApplication Tests"

		/// <summary>
		/// Add a new application.
		/// Make sure we get back an ID. 
		/// No errors are expected.
		/// </summary>
		[Test]
		public void AddApplicationTest1()
		{
			String applicationId = AddApplication(ApplicationState.Ready, DateTime.Now, false, "test");

			Assert.IsNotNull(applicationId);
			Assert.AreNotEqual("", applicationId);
		}

		/// <summary>
		/// Add a null application.
		/// No errors are expected, nothing should be added. Return value should be null.
		/// </summary>
		[Test]
		public void AddApplicationTest2()
		{
			Assert.IsNull(ManagerStorage.AddApplication(null));
		}

		/// <summary>
		/// create an application object only from the username.
		/// Check the inserted data to see if the right defaults were applied:
		/// state = 0
		/// primary = true
		/// timeCreated is not set
		/// new application id is generated
		/// </summary>
		[Test]
		public void AddApplicationTestWithUsernameOnly()
		{
			ApplicationStorageView application = new ApplicationStorageView("username3");
            
			String applicationId = ManagerStorage.AddApplication(application);

			Assert.AreEqual(ApplicationState.Stopped, application.State);
			Assert.AreEqual(true, application.Primary);			
			Assert.IsFalse(application.TimeCreatedSet);
			Assert.IsTrue(applicationId != null && applicationId.Length > 0, "Invalid ApplicationID!");
		}

        // testing bug: [ 1482565 ] Application TimeCompleted not persisted
        [Test]
        public void AddApplicationTestIfTimeCompletedIsSaved()
        {
            DateTime now = DateTime.Now;

            DateTime timeCompleted = new DateTime(now.Year + 1, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);

            ApplicationStorageView application = new ApplicationStorageView("username3");

            application.TimeCompleted = timeCompleted;

            String applicationId = ManagerStorage.AddApplication(application);

            ApplicationStorageView resultApplication = ManagerStorage.GetApplication(applicationId);

            Assert.AreEqual(timeCompleted, resultApplication.TimeCompleted);
        }

        // un-logged bug, the application name is not saved in some cases
        [Test]
        public void AddApplicationTestIfApplicationNameIsSaved()
        {
            String applicationName = "some name!";

            ApplicationStorageView application = new ApplicationStorageView("username3");

            application.ApplicationName = applicationName;

            String applicationId = ManagerStorage.AddApplication(application);

            ApplicationStorageView resultApplication = ManagerStorage.GetApplication(applicationId);

            Assert.AreEqual(applicationName, resultApplication.ApplicationName);
        }
		
		#endregion

		#region "UpdateApplication Tests"

		/// <summary>
		/// Add a new application.
		/// Change all values, run update
		/// Get applications, confirm that the update worked.
		/// </summary>
		[Test]
		public void UpdateApplicationTest1()
		{
			// TB: due to rounding errors the milliseconds might be lost in the database storage.
			// TB: I think this is OK so we create a test DateTime without milliseconds
			DateTime now = DateTime.Now;
			DateTime timeCreated1 = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);
			now = now.AddDays(1);
			DateTime timeCreated2 = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);

			String applicationId = AddApplication(ApplicationState.Ready, timeCreated1, false, "test");

			ApplicationStorageView updatedApplication = new ApplicationStorageView(ApplicationState.Stopped, timeCreated2, true, "test2");

			updatedApplication.ApplicationId = applicationId;

			ManagerStorage.UpdateApplication(updatedApplication);
			
			ApplicationStorageView[] applications = ManagerStorage.GetApplications();

			Assert.AreEqual(1, applications.Length);
			Assert.AreEqual(ApplicationState.Stopped, applications[0].State);
			Assert.AreEqual(timeCreated2, applications[0].TimeCreated);
			Assert.AreEqual(true, applications[0].Primary);
			Assert.AreEqual("test2", applications[0].Username);
		}

		/// <summary>
		/// Run update without any values in there.
		/// The application list should stay empty, no errors are expected
		/// </summary>
		[Test]
		public void UpdateApplicationTest2()
		{
			DateTime timeCreated = DateTime.Now.AddDays(1);

			ApplicationStorageView updatedApplication = new ApplicationStorageView(ApplicationState.AwaitingManifest, timeCreated, false, "username2");

			updatedApplication.ApplicationId = "";

			ManagerStorage.UpdateApplication(updatedApplication);
			
			ApplicationStorageView[] applications = ManagerStorage.GetApplications();

			Assert.AreEqual(0, applications.Length);
		}

		/// <summary>
		/// Add a new application
		/// Run update with a null application.
		/// The application list should stay empty, no errors are expected
		/// </summary>
		[Test]
		public void UpdateApplicationTest3()
		{
			DateTime timeCreated = DateTime.Now;

			String applicationId = AddApplication(ApplicationState.Stopped, timeCreated, true, "username1");

			ManagerStorage.UpdateApplication(null);
			
			ApplicationStorageView[] applications = ManagerStorage.GetApplications();

			Assert.AreEqual(1, applications.Length);
		}

        // testing bug: [ 1482565 ] Application TimeCompleted not persisted
        [Test]
        public void UpdateApplicationTestIfTimeCompletedIsSaved()
        {
            // TB: due to rounding errors the milliseconds might be lost in the database storage.
            // TB: I think this is OK so we create a test DateTime without milliseconds
            DateTime now = DateTime.Now;
            DateTime timeCreated = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);
            now = now.AddDays(1);
            DateTime timeCompleted = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);

            String applicationId = AddApplication(ApplicationState.Ready, timeCreated, false, "test");

            ApplicationStorageView updatedApplication = new ApplicationStorageView(ApplicationState.Stopped, timeCreated, true, "test2");

            updatedApplication.ApplicationId = applicationId;
            updatedApplication.TimeCompleted = timeCompleted;

            ManagerStorage.UpdateApplication(updatedApplication);

            ApplicationStorageView[] applications = ManagerStorage.GetApplications();

            Assert.AreEqual(1, applications.Length);
            Assert.AreEqual(timeCompleted, applications[0].TimeCompleted);
        }

        // un-logged bug, the application name is not saved in some cases
        [Test]
        public void UpdateApplicationTestIfApplicationNameIsSaved()
        {
            String applicationName = "another name!";
            String applicationId = AddApplication(ApplicationState.Ready, DateTime.Now, false, "test");

            ApplicationStorageView updatedApplication = new ApplicationStorageView(ApplicationState.Stopped, DateTime.Now, true, "test2");

            updatedApplication.ApplicationId = applicationId;
            updatedApplication.ApplicationName = applicationName;

            ManagerStorage.UpdateApplication(updatedApplication);

            ApplicationStorageView[] applications = ManagerStorage.GetApplications();

            Assert.AreEqual(1, applications.Length);
            Assert.AreEqual(applicationName, applications[0].ApplicationName);
        }

		#endregion

		#region "GetApplications Tests"

		/// <summary>
		/// Add a new application.
		/// Get the application list.
		/// The list should only contain the newly added application.
		/// </summary>
		[Test]
		public void GetApplicationsTest1()
		{
			// TB: due to rounding errors the milliseconds might be lost in the database storage.
			// TB: I think this is OK so we create a test DateTime without milliseconds
			DateTime now = DateTime.Now;
			DateTime timeCreated = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);

			String applicationId = AddApplication(ApplicationState.Stopped, timeCreated, true, "username2");
			
			ApplicationStorageView[] applications = ManagerStorage.GetApplications();

			Assert.AreEqual(1, applications.Length);
			Assert.AreEqual(ApplicationState.Stopped, applications[0].State);
			Assert.AreEqual(timeCreated, applications[0].TimeCreated);
			Assert.AreEqual(true, applications[0].Primary);
			Assert.AreEqual("username2", applications[0].Username);
		}

		/// <summary>
		/// Add 3 applications.
		/// Get the applications list.
		/// The list should contain 3 items.
		/// </summary>
		[Test]
		public void GetApplicationsTest2()
		{
			DateTime timeCreated = DateTime.Now;

			String applicationId1 = AddApplication(ApplicationState.Stopped, timeCreated, true, "username1");
			String applicationId2 = AddApplication(ApplicationState.Ready, timeCreated, true, "username2");
			String applicationId3 = AddApplication(ApplicationState.AwaitingManifest, timeCreated, true, "username3");
			
			ApplicationStorageView[] applications = ManagerStorage.GetApplications();

			Assert.AreEqual(3, applications.Length);
		}

		/// <summary>
		/// Add no applications.
		/// Get the application list.
		/// The list should be empty but not null. No error is expected
		/// </summary>
		[Test]
		public void GetApplicationsTest3()
		{
			ApplicationStorageView[] applications = ManagerStorage.GetApplications();

			Assert.AreEqual(0, applications.Length);
		}

		/// <summary>
		/// Create an application for username1, add 3 threads
		/// Create an application for username2, add 1 thread
		/// Get the username1 applications, it should have 5 threads, of which 3 are unfinished (status 0, 1 or 2).
		/// </summary>
		[Test]
		public void GetApplicationsTestUserApplications()
		{
			String applicationId1 = AddApplication(0, DateTime.Now, true, "username1");
			String executorId = null;

			// Add a few threads to ths application
			AddThread(applicationId1, executorId, 1, ThreadState.Ready, DateTime.Now, DateTime.Now, 0, false);
			AddThread(applicationId1, executorId, 2, ThreadState.Scheduled, DateTime.Now, DateTime.Now, 0, false);
			AddThread(applicationId1, executorId, 3, ThreadState.Started, DateTime.Now, DateTime.Now, 0, false);
			AddThread(applicationId1, executorId, 4, ThreadState.Finished, DateTime.Now, DateTime.Now, 0, false);
			AddThread(applicationId1, executorId, 5, ThreadState.Dead, DateTime.Now, DateTime.Now, 0, false);

			String applicationId2 = AddApplication(0, DateTime.Now, true, "username2");

			AddThread(applicationId2, executorId, 1, 0, DateTime.Now, DateTime.Now, 0, false);

			ApplicationStorageView[] applications = ManagerStorage.GetApplications("username1", true);

			Assert.AreEqual(1, applications.Length);
			Assert.AreEqual(5, applications[0].TotalThreads);
			Assert.AreEqual(3, applications[0].UnfinishedThreads);
		}

        [Test]
        public void GetApplicationsTestApplicationNameDefaultValue()
        {
            String applicationId = AddApplication(ApplicationState.Stopped, DateTime.Now, false, "username1");
            String expectedName = String.Format("Noname: [{0}]", applicationId);

            ApplicationStorageView[] applications = ManagerStorage.GetApplications();

            Assert.AreEqual(1, applications.Length);
            Assert.AreEqual(expectedName, applications[0].ApplicationName);
        }

		#endregion

		#region "GetApplication Tests"

		/// <summary>
		/// Add a new application.
		/// Get the application by application ID.
		/// We should find the new application
		/// </summary>
		[Test]
		public void GetApplicationTest1()
		{
			// TB: due to rounding errors the milliseconds might be lost in the database storage.
			// TB: I think this is OK so we create a test DateTime without milliseconds
			DateTime now = DateTime.Now;
			DateTime timeCreated = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);

			String applicationId = AddApplication(ApplicationState.Ready, timeCreated, true, "username2");
			
			ApplicationStorageView application = ManagerStorage.GetApplication(applicationId);

			Assert.IsNotNull(application);
			Assert.AreEqual(ApplicationState.Ready, application.State);
			Assert.AreEqual(timeCreated, application.TimeCreated);
			Assert.AreEqual(true, application.Primary);
			Assert.AreEqual("username2", application.Username);
		}

		/// <summary>
		/// Add 3 applications.
		/// Get the second application.
		/// </summary>
		[Test]
		public void GetApplicationTest2()
		{
			// TB: due to rounding errors the milliseconds might be lost in the database storage.
			// TB: I think this is OK so we create a test DateTime without milliseconds
			DateTime now = DateTime.Now;
			DateTime timeCreated = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);

			String applicationId1 = AddApplication(ApplicationState.Stopped, timeCreated, false, "username1");
			String applicationId2 = AddApplication(ApplicationState.Ready, timeCreated, true, "username2");
			String applicationId3 = AddApplication(ApplicationState.AwaitingManifest, timeCreated, false, "username3");
			
			ApplicationStorageView application = ManagerStorage.GetApplication(applicationId2);

			Assert.IsNotNull(application);
			Assert.AreEqual(ApplicationState.Ready, application.State);
			Assert.AreEqual(timeCreated, application.TimeCreated);
			Assert.AreEqual(true, application.Primary);
			Assert.AreEqual("username2", application.Username);
		}

		/// <summary>
		/// Add no applications.
		/// Get an application.
		/// The object should be null
		/// </summary>
		[Test]
		public void GetApplicationTest3()
		{
			ApplicationStorageView application = ManagerStorage.GetApplication(Guid.NewGuid().ToString());

			Assert.IsNull(application);
		}

		/// <summary>
		/// Add application
		/// Get another application (non-existent)
		/// The object should be null
		/// </summary>
		[Test]
		public void GetApplicationTest4()
		{
			// TB: due to rounding errors the milliseconds might be lost in the database storage.
			// TB: I think this is OK so we create a test DateTime without milliseconds
			DateTime now = DateTime.Now;
			DateTime timeCreated = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);

			String applicationId = AddApplication(ApplicationState.Stopped, timeCreated, true, "username2");
			
			ApplicationStorageView application = ManagerStorage.GetApplication(Guid.NewGuid().ToString());

			Assert.IsNull(application);
		}

        [Test]
        public void GetApplicationTestApplicationNameDefaultValue()
        {
            String applicationId = AddApplication(ApplicationState.Stopped, DateTime.Now, false, "username1");
            String expectedName = String.Format("Noname: [{0}]", applicationId);

            ApplicationStorageView application = ManagerStorage.GetApplication(applicationId);

            Assert.IsNotNull(application);
            Assert.AreEqual(expectedName, application.ApplicationName);
        }


		#endregion

		#region "DeleteApplication Tests"

		/// <summary>
		/// Add a new application.
		/// Delete the application.
		/// </summary>
		[Test]
		public void DeleteApplicationTestSimpleScenario()
		{
			DateTime now = DateTime.Now;
			DateTime timeCreated = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);

			String applicationId = AddApplication(ApplicationState.Ready, timeCreated, true, "username2");
			
			ApplicationStorageView[] applicationsBefore = ManagerStorage.GetApplications();

			ManagerStorage.DeleteApplication(new ApplicationStorageView(applicationId, ApplicationState.Ready, DateTime.Now, false, "username1"));
			
			ApplicationStorageView[] applicationsAfter = ManagerStorage.GetApplications();

			Assert.AreEqual(1, applicationsBefore.Length);
			Assert.AreEqual(0, applicationsAfter.Length);
		}

		[Test]
		public void DeleteApplicationTestNullApplicationToDelete()
		{
			DateTime now = DateTime.Now;
			DateTime timeCreated = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);

			String applicationId = AddApplication(ApplicationState.Ready, timeCreated, true, "username2");
			
			ApplicationStorageView[] applicationsBefore = ManagerStorage.GetApplications();

			ManagerStorage.DeleteApplication(null);
			
			ApplicationStorageView[] applicationsAfter = ManagerStorage.GetApplications();

			Assert.AreEqual(1, applicationsBefore.Length);
			Assert.AreEqual(1, applicationsAfter.Length);
		}

		[Test]
		public void DeleteApplicationTestNoApplicationAdded()
		{
			ManagerStorage.DeleteApplication(new ApplicationStorageView(Guid.NewGuid().ToString(), ApplicationState.Ready, DateTime.Now, false, "username1"));
			
			ApplicationStorageView[] applicationsAfter = ManagerStorage.GetApplications();

			Assert.AreEqual(0, applicationsAfter.Length);
		}

		/// <summary>
		/// Threads should also be removed
		/// </summary>
		[Test]
		public void DeleteApplicationWithThreads()
		{
			DateTime now = DateTime.Now;
			DateTime timeCreated = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);

			String applicationId1 = AddApplication(ApplicationState.Ready, timeCreated, true, "username1");
			String applicationId2 = AddApplication(ApplicationState.Ready, timeCreated, true, "username2");

			AddThread(applicationId1, null, 1, ThreadState.Ready, DateTime.Now, DateTime.Now, 0, false);
			AddThread(applicationId1, null, 2, ThreadState.Ready, DateTime.Now, DateTime.Now, 0, false);
			AddThread(applicationId2, null, 3, ThreadState.Ready, DateTime.Now, DateTime.Now, 0, false);
			AddThread(applicationId2, null, 4, ThreadState.Ready, DateTime.Now, DateTime.Now, 0, false);
			
			ApplicationStorageView[] applicationsBefore = ManagerStorage.GetApplications();

			ManagerStorage.DeleteApplication(new ApplicationStorageView(applicationId1, ApplicationState.Ready, DateTime.Now, false, "username1"));
			
			ApplicationStorageView[] applicationsAfter = ManagerStorage.GetApplications();
			ThreadStorageView[] threadsAfter = ManagerStorage.GetThreads();

			Assert.AreEqual(2, applicationsBefore.Length);
			Assert.AreEqual(1, applicationsAfter.Length);
			Assert.AreEqual(2, threadsAfter.Length);
		}


		#endregion

		#region "AddExecutor Tests"

		/// <summary>
		/// Add a new executor.
		/// Make sure we get back an ID. 
		/// No errors are expected.
		/// </summary>
		[Test]
		public void AddExecutorTest1()
		{
			String executorId = AddExecutor(false, false, DateTime.Now, "", 9000, "username1", 0, 0, 0, 0);

			Assert.IsNotNull(executorId);
			Assert.AreNotEqual("", executorId);
		}

		/// <summary>
		/// Add a null executor.
		/// No errors are expected, nothing should be added. Return value should be null.
		/// </summary>
		[Test]
		public void AddExecutorTest2()
		{
			Assert.IsNull(ManagerStorage.AddExecutor(null));
		}

		/// <summary>
		/// Add a null executor.
		/// No errors are expected, nothing should be added. Return value should be null.
		/// </summary>
		[Test]
		public void AddExecutorTestLatestConstructor()
		{
			ExecutorStorageView executorStorage = new ExecutorStorageView(
				false,
				false,
				"hostname",
				"username",
				1,
				2,
				3,
				4,
				"Windows",
				"686"
				);

			string executorId = ManagerStorage.AddExecutor(executorStorage);

			Assert.IsNotNull(executorId);
			Assert.AreNotEqual("", executorId);
		}
		
		#endregion

		#region "UpdateExecutor Tests"

		/// <summary>
		/// Add a new executor.
		/// Change all values, run update
		/// Get executors, confirm that the update worked.
		/// </summary>
		[Test]
		public void UpdateExecutorTest1()
		{
			// TB: due to rounding errors the milliseconds might be lost in the database storage.
			// TB: I think this is OK so we create a test DateTime without milliseconds
			DateTime now = DateTime.Now;
			DateTime pingTime1 = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);
			now = now.AddDays(1);
			DateTime pingTime2 = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);

			String executorId = AddExecutor(false, true, pingTime1, "test1", 9999, "username1", 111, 123, 34, (float)3.4);

			ExecutorStorageView updatedExecutor = new ExecutorStorageView(true, false, pingTime2, "test2", 8888, "username2", 222, 456, 56, (float)5.6);

			updatedExecutor.ExecutorId = executorId;

			ManagerStorage.UpdateExecutor(updatedExecutor);
			
			ExecutorStorageView[] executors = ManagerStorage.GetExecutors();

			Assert.AreEqual(1, executors.Length);
			Assert.AreEqual(true, executors[0].Dedicated);
			Assert.AreEqual(false, executors[0].Connected);
			Assert.AreEqual(pingTime2, executors[0].PingTime);
			Assert.AreEqual("test2", executors[0].HostName);
			Assert.AreEqual(8888, executors[0].Port);
			Assert.AreEqual("username2", executors[0].Username);
			Assert.AreEqual(222, executors[0].MaxCpu);
			Assert.AreEqual(456, executors[0].CpuUsage);
			Assert.AreEqual(56, executors[0].AvailableCpu);
			Assert.AreEqual(5.6, executors[0].TotalCpuUsage);
			Assert.AreEqual(executorId, executors[0].ExecutorId);
		}

		/// <summary>
		/// Run update without any values in there.
		/// The executor list should stay empty, no errors are expected
		/// </summary>
		[Test]
		public void UpdateExecutorTest2()
		{
			DateTime pingTime2 = DateTime.Now.AddDays(1);

			ExecutorStorageView updatedExecutor = new ExecutorStorageView(true, false, pingTime2, "test2", 8888, "username2", 222, 456, 56, (float)5.6);

			updatedExecutor.ExecutorId = "";

			ManagerStorage.UpdateExecutor(updatedExecutor);
			
			ExecutorStorageView[] executors = ManagerStorage.GetExecutors();

			Assert.AreEqual(0, executors.Length);
		}

		/// <summary>
		/// Add a new executor
		/// Run update with a null executor.
		/// The executor list should stay empty, no errors are expected
		/// </summary>
		[Test]
		public void UpdateExecutorTest3()
		{
			DateTime pingTime1 = DateTime.Now;

			String executorId = AddExecutor(false, true, pingTime1, "test1", 9999, "username1", 111, 123, 34, (float)3.4);

			ManagerStorage.UpdateExecutor(null);
			
			ExecutorStorageView[] executors = ManagerStorage.GetExecutors();

			Assert.AreEqual(1, executors.Length);
		}

		#endregion

        #region "DeleteExecutor Tests"

        /// <summary>
        /// Add a new executor.
        /// Delete the executor.
        /// </summary>
        [Test]
        public void DeleteExecutorTestSimpleScenario()
        {
            DateTime now = DateTime.Now;
            DateTime pingTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);

            String executorId = AddExecutor(true, false, pingTime, "hostname", 1, "username1", 1, 2, 3, 4);

            ExecutorStorageView[] executorsBefore = ManagerStorage.GetExecutors();

            ManagerStorage.DeleteExecutor(new ExecutorStorageView(executorId, true, false, "hostname", 1, "username1", 1, 2, 3, 4));

            ExecutorStorageView[] executorsAfter = ManagerStorage.GetExecutors();

            Assert.AreEqual(1, executorsBefore.Length);
            Assert.AreEqual(0, executorsAfter.Length);
        }

        [Test]
        public void DeleteExecutorTestNullExecutorToDelete()
        {
            DateTime now = DateTime.Now;
            DateTime pingTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);

            String executorId = AddExecutor(true, false, pingTime, "hostname", 1, "username1", 1, 2, 3, 4);

            ExecutorStorageView[] executorsBefore = ManagerStorage.GetExecutors();

            ManagerStorage.DeleteExecutor(null);

            ExecutorStorageView[] executorsAfter = ManagerStorage.GetExecutors();

            Assert.AreEqual(1, executorsBefore.Length);
            Assert.AreEqual(1, executorsAfter.Length);
        }

        [Test]
        public void DeleteExecutorTestNoExecutorAdded()
        {
            ManagerStorage.DeleteExecutor(new ExecutorStorageView(Guid.NewGuid().ToString(), true, false, "hostname", 1, "username1", 1, 2, 3, 4));

            ExecutorStorageView[] executorsAfter = ManagerStorage.GetExecutors();

            Assert.AreEqual(0, executorsAfter.Length);
        }

        #endregion

		#region "GetExecutors Tests"

		/// <summary>
		/// Add a new executor.
		/// Get the executor list.
		/// The list should only contain the newly added executor.
		/// </summary>
		[Test]
		public void GetExecutorsTest1()
		{
			// TB: due to rounding errors the milliseconds might be lost in the database storage.
			// TB: I think this is OK so we create a test DateTime without milliseconds
			DateTime now = DateTime.Now;
			DateTime pingTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);

			String executorId = AddExecutor(false, true, pingTime, "test", 9999, "username1", 111, 123, 34, (float)3.4);
			
			ExecutorStorageView[] executors = ManagerStorage.GetExecutors();

			Assert.AreEqual(1, executors.Length);
			Assert.AreEqual(false, executors[0].Dedicated);
			Assert.AreEqual(true, executors[0].Connected);
			Assert.AreEqual(pingTime, executors[0].PingTime);
			Assert.AreEqual("test", executors[0].HostName);
			Assert.AreEqual(9999, executors[0].Port);
			Assert.AreEqual("username1", executors[0].Username);
			Assert.AreEqual(111, executors[0].MaxCpu);
			Assert.AreEqual(123, executors[0].CpuUsage);
			Assert.AreEqual(34, executors[0].AvailableCpu);
			Assert.AreEqual(3.4, executors[0].TotalCpuUsage);
			Assert.AreEqual(executorId, executors[0].ExecutorId);
		}

		/// <summary>
		/// Add 3 executors.
		/// Get the executors list.
		/// The list should contain 3 items.
		/// </summary>
		[Test]
		public void GetExecutorsTest2()
		{
			DateTime pingTime = DateTime.Now;

			String executorId1 = AddExecutor(false, true, pingTime, "test1", 9999, "username1", 111, 123, 34, (float)3.4);
			String executorId2 = AddExecutor(false, true, pingTime, "test2", 9999, "username2", 111, 123, 34, (float)3.4);
			String executorId3 = AddExecutor(false, true, pingTime, "test3", 9999, "username3", 111, 123, 34, (float)3.4);
			
			ExecutorStorageView[] executors = ManagerStorage.GetExecutors();

			Assert.AreEqual(3, executors.Length);
		}

		/// <summary>
		/// Add no executors.
		/// Get the executor list.
		/// The list should be empty but not null. No error is expected
		/// </summary>
		[Test]
		public void GetExecutorsTest3()
		{
			ExecutorStorageView[] executors = ManagerStorage.GetExecutors();

			Assert.AreEqual(0, executors.Length);
		}

		/// Add 3 executors.
		/// Get the dedicated executors list.
		/// The list should contain 2 items.
		/// </summary>
		[Test]
		public void GetExecutorsTestDedicatedExecutors()
		{
			DateTime pingTime = DateTime.Now;

			String executorId1 = AddExecutor(true, true, pingTime, "test1", 9999, "username1", 111, 123, 34, (float)3.4);
			String executorId2 = AddExecutor(false, true, pingTime, "test2", 9999, "username2", 111, 123, 34, (float)3.4);
			String executorId3 = AddExecutor(true, true, pingTime, "test3", 9999, "username3", 111, 123, 34, (float)3.4);
			
			ExecutorStorageView[] executors = ManagerStorage.GetExecutors(TriStateBoolean.True);

			Assert.AreEqual(2, executors.Length);
		}

		/// Add 3 executors.
		/// Get the executors list using the dedicated function but without care wether the executors are dedicated or not.
		/// The list should contain 3 items (all executors).
		/// </summary>
		[Test]
		public void GetExecutorsTestDedicatedExecutorsUndefined()
		{
			DateTime pingTime = DateTime.Now;

			String executorId1 = AddExecutor(true, true, pingTime, "test1", 9999, "username1", 111, 123, 34, (float)3.4);
			String executorId2 = AddExecutor(false, true, pingTime, "test2", 9999, "username2", 111, 123, 34, (float)3.4);
			String executorId3 = AddExecutor(true, true, pingTime, "test3", 9999, "username3", 111, 123, 34, (float)3.4);
			
			ExecutorStorageView[] executors = ManagerStorage.GetExecutors(TriStateBoolean.Undefined);

			Assert.AreEqual(3, executors.Length);
		}

		/// Add 4 executors.
		/// Get the dedicated and connected executors list.
		/// The list should contain 1 item.
		/// </summary>
		[Test]
		public void GetExecutorsTestDedicatedConnectedExecutors()
		{
			DateTime pingTime = DateTime.Now;

			String executorId1 = AddExecutor(true, true, pingTime, "test1", 9999, "username1", 111, 123, 34, (float)3.4);
			String executorId2 = AddExecutor(false, true, pingTime, "test2", 9999, "username2", 111, 123, 34, (float)3.4);
			String executorId3 = AddExecutor(true, false, pingTime, "test3", 9999, "username3", 111, 123, 34, (float)3.4);
			String executorId4 = AddExecutor(true, false, pingTime, "test3", 9999, "username3", 111, 123, 34, (float)3.4);
			
			ExecutorStorageView[] dedicatedAndConnectedExecutors = ManagerStorage.GetExecutors(TriStateBoolean.True, TriStateBoolean.True);
			ExecutorStorageView[] dedicatedExecutors = ManagerStorage.GetExecutors(TriStateBoolean.True, TriStateBoolean.Undefined);
			ExecutorStorageView[] connectedExecutors = ManagerStorage.GetExecutors(TriStateBoolean.Undefined, TriStateBoolean.True);
			ExecutorStorageView[] allExecutors = ManagerStorage.GetExecutors(TriStateBoolean.Undefined, TriStateBoolean.Undefined);

			Assert.AreEqual(1, dedicatedAndConnectedExecutors.Length);
			Assert.AreEqual(3, dedicatedExecutors.Length);
			Assert.AreEqual(2, connectedExecutors.Length);
			Assert.AreEqual(4, allExecutors.Length);
		}


		#endregion

		#region "GetExecutor Tests"

		/// <summary>
		/// Add 3 executors.
		/// Get one executor.
		/// </summary>
		[Test]
		public void GetExecutorTestSimpleScenario()
		{
			// TB: due to rounding errors the milliseconds might be lost in the database storage.
			// TB: I think this is OK so we create a test DateTime without milliseconds
			DateTime now = DateTime.Now;
			DateTime pingTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);

			String executorId = AddExecutor(false, true, pingTime, "test", 9999, "username1", 111, 123, 34, (float)3.4);
			String executorId2 = AddExecutor(false, true, pingTime, "test2", 9999, "username2", 111, 123, 34, (float)3.4);
			String executorId3 = AddExecutor(false, true, pingTime, "test3", 9999, "username3", 111, 123, 34, (float)3.4);
			
			ExecutorStorageView executor = ManagerStorage.GetExecutor(executorId);

			Assert.IsNotNull(executor);
			Assert.AreEqual(false, executor.Dedicated);
			Assert.AreEqual(true, executor.Connected);
			Assert.AreEqual(pingTime, executor.PingTime);
			Assert.AreEqual("test", executor.HostName);
			Assert.AreEqual(9999, executor.Port);
			Assert.AreEqual("username1", executor.Username);
			Assert.AreEqual(111, executor.MaxCpu);
			Assert.AreEqual(123, executor.CpuUsage);
			Assert.AreEqual(34, executor.AvailableCpu);
			Assert.AreEqual(3.4, executor.TotalCpuUsage);
			Assert.AreEqual(executorId, executor.ExecutorId);
		}

		/// <summary>
		/// Add no executors.
		/// Get the executor list.
		/// The list should be empty but not null. No error is expected
		/// </summary>
		[Test]
		public void GetExecutorTestNoExecutor()
		{
			ExecutorStorageView executor = ManagerStorage.GetExecutor(Guid.NewGuid().ToString());

			Assert.IsNull(executor);
		}

		/// <summary>
		/// Add 3 executors.
		/// Get one executor.
		/// </summary>
		[Test]
		public void GetExecutorTestNoPingTime()
		{
			// TB: due to rounding errors the milliseconds might be lost in the database storage.
			// TB: I think this is OK so we create a test DateTime without milliseconds
			DateTime now = DateTime.Now;
			DateTime pingTime = DateTime.MinValue; // this gets stored internally is the ping time was not set

			String executorId = AddExecutor(false, true, pingTime, "test", 9999, "username1", 111, 123, 34, (float)3.4);
			String executorId2 = AddExecutor(false, true, pingTime, "test2", 9999, "username2", 111, 123, 34, (float)3.4);
			String executorId3 = AddExecutor(false, true, pingTime, "test3", 9999, "username3", 111, 123, 34, (float)3.4);
			
			ExecutorStorageView executor = ManagerStorage.GetExecutor(executorId);

			Assert.IsNotNull(executor);
			Assert.AreEqual(false, executor.Dedicated);
			Assert.AreEqual(true, executor.Connected);
			Assert.AreEqual(pingTime, executor.PingTime);
			Assert.IsFalse(executor.PingTimeSet);
			Assert.AreEqual("test", executor.HostName);
			Assert.AreEqual(9999, executor.Port);
			Assert.AreEqual("username1", executor.Username);
			Assert.AreEqual(111, executor.MaxCpu);
			Assert.AreEqual(123, executor.CpuUsage);
			Assert.AreEqual(34, executor.AvailableCpu);
			Assert.AreEqual(3.4, executor.TotalCpuUsage);
			Assert.AreEqual(executorId, executor.ExecutorId);
		}

		[Test]
		public void GetExecutorTestAnotherConstructor()
		{
			ExecutorStorageView executorStorage = new ExecutorStorageView(
				false,
				true,
				"hostname",
				"username",
				1,
				2,
				3,
				4,
				"Microsoft Windows NT 5.0.2195.0",
				"x86 Family 6 Model 13 Stepping 6"
				);

			String executorId = ManagerStorage.AddExecutor(executorStorage);

			ExecutorStorageView executor = ManagerStorage.GetExecutor(executorId);

			Assert.IsNotNull(executor);
			Assert.AreEqual(executorId, executor.ExecutorId);
			Assert.AreEqual(false, executor.Dedicated);
			Assert.AreEqual(true, executor.Connected);
			Assert.IsFalse(executor.PingTimeSet);
			Assert.AreEqual("hostname", executor.HostName);
			Assert.AreEqual(0, executor.Port);
			Assert.AreEqual("username", executor.Username);
			Assert.AreEqual(1, executor.MaxCpu);
			Assert.AreEqual(0, executor.CpuUsage);
			Assert.AreEqual(0, executor.AvailableCpu);
			Assert.AreEqual(0, executor.TotalCpuUsage);
			Assert.AreEqual(2, executor.MaxMemory);
			Assert.AreEqual(3, executor.MaxDisk);
			Assert.AreEqual(4, executor.NumberOfCpu);
			Assert.AreEqual("Microsoft Windows NT 5.0.2195.0", executor.Os);
			Assert.AreEqual("x86 Family 6 Model 13 Stepping 6", executor.Architecture);
		}

		[Test]
		public void GetExecutorTestNullId()
		{
			ExecutorStorageView executor = ManagerStorage.GetExecutor(null);

			Assert.IsNull(executor);
		}

		#endregion

		#region "AddThread Tests"

		/// <summary>
		/// Add a new thread.
		/// No errors are expected.
		/// </summary>
		[Test]
		public void AddThreadTest1()
		{
			String applicationId = Guid.NewGuid().ToString();
			String executorId = Guid.NewGuid().ToString();

			AddThread(applicationId, executorId, 1, ThreadState.Started, DateTime.Now, DateTime.Now.AddDays(1), 1, false);
		}

		/// <summary>
		/// Add a null thread.
		/// No errors are expected, nothing should be added.
		/// </summary>
		[Test]
		public void AddThreadTest2()
		{
			ManagerStorage.AddThread(null);
		}
		
		/// <summary>
		/// Add a thread with a null Executor ID.
		/// Note: 
		///		Reproducing a bug on the SQL Server implementation.
		/// </summary>
		[Test]
		public void AddThreadTestNullExecutorId()
		{
			String applicationId = Guid.NewGuid().ToString();
			String executorId = null;

			AddThread(applicationId, executorId, 1, ThreadState.Started, DateTime.Now, DateTime.Now.AddDays(1), 1, false);
		}

		/// <summary>
		/// Add a thread with a null time.
		/// Note: 
		///		Reproducing a bug on the SQL Server implementation.
		/// </summary>
		[Test]
		public void AddThreadTestNullTimesAndExecutor()
		{
			String applicationId = Guid.NewGuid().ToString();
			Int32 threadId = 23;

			ThreadStorageView thread = new ThreadStorageView(applicationId, threadId);

			ManagerStorage.AddThread(thread);
		}

		#endregion

		#region "UpdateThread Tests"

		/// <summary>
		/// Add a new thread.
		/// Change all values, run update
		/// Get threads, confirm that the update worked.
		/// </summary>
		[Test]
		public void UpdateThreadTest1()
		{
			String applicationId = Guid.NewGuid().ToString();
			String executorId1 = Guid.NewGuid().ToString();
			String executorId2 = Guid.NewGuid().ToString();

			Int32 threadId = 122;

			// TB: due to rounding errors the milliseconds might be lost in the database storage.
			// TB: I think this is OK so we create a test DateTime without milliseconds
			DateTime now = DateTime.Now;
			DateTime timeStarted1 = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);
			now = now.AddDays(1);
			DateTime timeFinished1 = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);

			now = now.AddDays(1);
			DateTime timeStarted2 = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);
			now = now.AddDays(1);
			DateTime timeFinished2 = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);

			AddThread(applicationId, executorId1, threadId, ThreadState.Started, timeStarted1, timeFinished1, 4, true);

			// retrieve the newly added thread so we have the new internal thread id
			ThreadStorageView[] newThreads = ManagerStorage.GetThreads();

			ThreadStorageView updatedThread = new ThreadStorageView(newThreads[0].InternalThreadId, applicationId, executorId2, threadId, ThreadState.Dead, timeStarted2, timeFinished2, 7, false);

			ManagerStorage.UpdateThread(updatedThread);
			
			ThreadStorageView[] threads = ManagerStorage.GetThreads();

			Assert.AreEqual(1, threads.Length);
			Assert.AreEqual(applicationId, threads[0].ApplicationId);
			Assert.AreEqual(executorId2, threads[0].ExecutorId);
			Assert.AreEqual(threadId, threads[0].ThreadId);
			Assert.AreEqual(ThreadState.Dead, threads[0].State);
			Assert.AreEqual(timeStarted2, threads[0].TimeStarted);
			Assert.AreEqual(timeFinished2, threads[0].TimeFinished);
			Assert.AreEqual(7, threads[0].Priority);
			Assert.AreEqual(false, threads[0].Failed);
		}

		/// <summary>
		/// Run update without any values in there.
		/// The thread list should stay empty, no errors are expected
		/// </summary>
		[Test]
		public void UpdateThreadTest2()
		{
			String applicationId = Guid.NewGuid().ToString();
			String executorId = Guid.NewGuid().ToString();
			Int32 threadId = 122;

			DateTime timeCreated = DateTime.Now.AddDays(1);

			ThreadStorageView updatedThread = new ThreadStorageView(applicationId, executorId, threadId, ThreadState.Dead, DateTime.Now, DateTime.Now.AddDays(1), 7, false);

			updatedThread.ThreadId = -1;

			ManagerStorage.UpdateThread(updatedThread);
			
			ThreadStorageView[] threads = ManagerStorage.GetThreads();

			Assert.AreEqual(0, threads.Length);
		}

		/// <summary>
		/// Add a new thread
		/// Run update with a null thread.
		/// The thread list should stay empty, no errors are expected
		/// </summary>
		[Test]
		public void UpdateThreadTest3()
		{
			String applicationId = Guid.NewGuid().ToString();
			String executorId = Guid.NewGuid().ToString();
			Int32 threadId = 122;
			DateTime timeStarted = DateTime.Now;
			DateTime timeFinished = DateTime.Now.AddDays(1);

			AddThread(applicationId, executorId, threadId, ThreadState.Started, timeStarted, timeFinished, 1, false);

			ManagerStorage.UpdateThread(null);
			
			ThreadStorageView[] threads = ManagerStorage.GetThreads();

			Assert.AreEqual(1, threads.Length);
		}

		[Test]
		public void UpdateThreadTestNullExecutorIdAndTimes()
		{
			String applicationId = Guid.NewGuid().ToString();
			Int32 threadId = 23;

			ThreadStorageView newThread = new ThreadStorageView(applicationId, threadId);

			ManagerStorage.AddThread(newThread);

			ThreadStorageView foundThread = ManagerStorage.GetThread(applicationId, threadId);

			foundThread.State = ThreadState.Started;

			ManagerStorage.UpdateThread(foundThread);
			
			ThreadStorageView thread = ManagerStorage.GetThread(applicationId, threadId);

			Assert.AreEqual(applicationId, thread.ApplicationId);
			Assert.IsNull(thread.ExecutorId);
			Assert.AreEqual(threadId, thread.ThreadId);
			Assert.AreEqual(ThreadState.Started, thread.State);
			Assert.IsFalse(thread.TimeStartedSet);
			Assert.IsFalse(thread.TimeFinishedSet);
			Assert.AreEqual(0, thread.Priority);
			Assert.AreEqual(false, thread.Failed);
			
		}

		#endregion

		#region "GetThread Tests"

		/// <summary>
		/// Add a new thread.
		/// Get the thread.
		/// The list should only contain the newly added thread.
		/// </summary>
		[Test]
		public void GetThreadsTestSimpleScenario()
		{
			String applicationId = Guid.NewGuid().ToString();
			String executorId = Guid.NewGuid().ToString();
			Int32 threadId = 125;

			// TB: due to rounding errors the milliseconds might be lost in the database storage.
			// TB: I think this is OK so we create a test DateTime without milliseconds
			DateTime now = DateTime.Now;
			DateTime timeStarted = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);
			now.AddDays(1);
			DateTime timeFinished = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);

			AddThread(applicationId, executorId, threadId, ThreadState.Started, timeStarted, timeFinished, 1, true);
			
			ThreadStorageView thread = ManagerStorage.GetThread(applicationId, threadId);

			Assert.AreEqual(applicationId, thread.ApplicationId);
			Assert.AreEqual(executorId, thread.ExecutorId);
			Assert.AreEqual(threadId, thread.ThreadId);
			Assert.AreEqual(ThreadState.Started, thread.State);
			Assert.AreEqual(timeStarted, thread.TimeStarted);
			Assert.AreEqual(timeFinished, thread.TimeFinished);
			Assert.AreEqual(1, thread.Priority);
			Assert.AreEqual(true, thread.Failed);
		}

		[Test]
		public void GetThreadsTestMinimumSetup()
		{
			String applicationId = Guid.NewGuid().ToString();
			Int32 threadId = 125;

			ThreadStorageView newThread = new ThreadStorageView(applicationId, threadId);

			ManagerStorage.AddThread(newThread);
			
			ThreadStorageView thread = ManagerStorage.GetThread(applicationId, threadId);

			Assert.AreEqual(applicationId, thread.ApplicationId);
			Assert.IsNull(thread.ExecutorId);
			Assert.AreEqual(threadId, thread.ThreadId);
			Assert.AreEqual(ThreadState.Unknown, thread.State);
			Assert.IsFalse(thread.TimeStartedSet);
			Assert.IsFalse(thread.TimeFinishedSet);
			Assert.AreEqual(0, thread.Priority);
			Assert.AreEqual(false, thread.Failed);
		}

		[Test]
		public void GetThreadsTestNoThread()
		{
			String applicationId = Guid.NewGuid().ToString();
			Int32 threadId = 125;
			
			ThreadStorageView thread = ManagerStorage.GetThread(applicationId, threadId);

			Assert.IsNull(thread);
		}
		
		#endregion

		#region "GetThreads Tests"

		/// <summary>
		/// Add a new thread.
		/// Get the thread list.
		/// The list should only contain the newly added thread.
		/// </summary>
		[Test]
		public void GetThreadsTest1()
		{
			String applicationId = Guid.NewGuid().ToString();
			String executorId = Guid.NewGuid().ToString();
			Int32 threadId = 125;

			// TB: due to rounding errors the milliseconds might be lost in the database storage.
			// TB: I think this is OK so we create a test DateTime without milliseconds
			DateTime now = DateTime.Now;
			DateTime timeStarted = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);
			now.AddDays(1);
			DateTime timeFinished = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);

			AddThread(applicationId, executorId, threadId, ThreadState.Started, timeStarted, timeFinished, 1, true);
			
			ThreadStorageView[] threads = ManagerStorage.GetThreads();

			Assert.AreEqual(1, threads.Length);
			Assert.AreEqual(applicationId, threads[0].ApplicationId);
			Assert.AreEqual(executorId, threads[0].ExecutorId);
			Assert.AreEqual(threadId, threads[0].ThreadId);
			Assert.AreEqual(ThreadState.Started, threads[0].State);
			Assert.AreEqual(timeStarted, threads[0].TimeStarted);
			Assert.AreEqual(timeFinished, threads[0].TimeFinished);
			Assert.AreEqual(1, threads[0].Priority);
			Assert.AreEqual(true, threads[0].Failed);
		}

		/// <summary>
		/// Add 3 threads.
		/// Get the threads list.
		/// The list should contain 3 items.
		/// </summary>
		[Test]
		public void GetThreadsTest2()
		{
			String applicationId = Guid.NewGuid().ToString();
			String executorId = Guid.NewGuid().ToString();

			AddThread(applicationId, executorId, 1, ThreadState.Dead, DateTime.Now, DateTime.Now.AddDays(1), 7, false);
			AddThread(applicationId, executorId, 2, ThreadState.Dead, DateTime.Now, DateTime.Now.AddDays(1), 7, false);
			AddThread(applicationId, executorId, 3, ThreadState.Dead, DateTime.Now, DateTime.Now.AddDays(1), 7, false);
			
			ThreadStorageView[] threads = ManagerStorage.GetThreads();

			Assert.AreEqual(3, threads.Length);
		}

		/// <summary>
		/// Add 3 threads.
		/// Get the threads list by status.
		/// The list should contain 2 items.
		/// </summary>
		[Test]
		public void GetThreadsTestAllthreadsWithStatus()
		{
			String applicationId = Guid.NewGuid().ToString();
			String executorId = Guid.NewGuid().ToString();

			AddThread(applicationId, executorId, 1, ThreadState.Ready, DateTime.Now, DateTime.Now.AddDays(1), 7, false);
			AddThread(applicationId, executorId, 2, ThreadState.Started, DateTime.Now, DateTime.Now.AddDays(1), 7, false);
			AddThread(applicationId, executorId, 3, ThreadState.Dead, DateTime.Now, DateTime.Now.AddDays(1), 7, false);
			
			ThreadStorageView[] threads = ManagerStorage.GetThreads(ThreadState.Ready, ThreadState.Dead);

			Assert.AreEqual(2, threads.Length);
		}

		/// <summary>
		/// Add no threads.
		/// Get the thread list.
		/// The list should be empty but not null. No error is expected
		/// </summary>
		[Test]
		public void GetThreadsTest3()
		{
			ThreadStorageView[] threads = ManagerStorage.GetThreads();

			Assert.AreEqual(0, threads.Length);
		}

		/// <summary>
		/// Add a new thread.
		/// Get the thread list.
		/// The list should only contain the newly added thread.
		/// </summary>
		[Test]
		public void GetThreadsTestApplicationThreads()
		{
			String applicationId = Guid.NewGuid().ToString();
			String otherApplicationId = Guid.NewGuid().ToString();
			String executorId = Guid.NewGuid().ToString();
			Int32 threadId = 125;

			// TB: due to rounding errors the milliseconds might be lost in the database storage.
			// TB: I think this is OK so we create a test DateTime without milliseconds
			DateTime now = DateTime.Now;
			DateTime timeStarted = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);
			now.AddDays(1);
			DateTime timeFinished = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);

			AddThread(applicationId, executorId, threadId, ThreadState.Started, timeStarted, timeFinished, 1, true);
			
			ThreadStorageView[] threads = ManagerStorage.GetThreads(applicationId);
			ThreadStorageView[] otherThreads = ManagerStorage.GetThreads(otherApplicationId);

			Assert.AreEqual(1, threads.Length);
			Assert.AreEqual(0, otherThreads.Length);
			Assert.AreEqual(applicationId, threads[0].ApplicationId);
			Assert.AreEqual(executorId, threads[0].ExecutorId);
			Assert.AreEqual(threadId, threads[0].ThreadId);
			Assert.AreEqual(ThreadState.Started, threads[0].State);
			Assert.AreEqual(timeStarted, threads[0].TimeStarted);
			Assert.AreEqual(timeFinished, threads[0].TimeFinished);
			Assert.AreEqual(1, threads[0].Priority);
			Assert.AreEqual(true, threads[0].Failed);
		}

		/// <summary>
		/// Add a few threads.
		/// Get the thread list.
		/// The list should only contain the newly added thread.
		/// </summary>
		[Test]
		public void GetThreadsTestApplicationThreadsWithStatus()
		{
			String applicationId = Guid.NewGuid().ToString();
			String executorId = Guid.NewGuid().ToString();
			Int32 threadId = 125;

			// TB: due to rounding errors the milliseconds might be lost in the database storage.
			// TB: I think this is OK so we create a test DateTime without milliseconds
			DateTime now = DateTime.Now;
			DateTime timeStarted = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);
			now.AddDays(1);
			DateTime timeFinished = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);

			AddThread(applicationId, executorId, threadId, ThreadState.Started, timeStarted, timeFinished, 1, true);
			AddThread(applicationId, executorId, threadId, ThreadState.Ready, timeStarted, timeFinished, 1, true);
			AddThread(applicationId, executorId, threadId, ThreadState.Dead, timeStarted, timeFinished, 1, true);
			
			ThreadStorageView[] allThreads = ManagerStorage.GetThreads(applicationId);
			ThreadStorageView[] threads = ManagerStorage.GetThreads(applicationId, ThreadState.Started);
			ThreadStorageView[] threadsReadyOrStarted = ManagerStorage.GetThreads(applicationId, ThreadState.Ready, ThreadState.Started);

			Assert.AreEqual(1, threads.Length);
			Assert.AreEqual(3, allThreads.Length);
			Assert.AreEqual(2, threadsReadyOrStarted.Length);
			Assert.AreEqual(applicationId, threads[0].ApplicationId);
			Assert.AreEqual(executorId, threads[0].ExecutorId);
			Assert.AreEqual(threadId, threads[0].ThreadId);
			Assert.AreEqual(ThreadState.Started, threads[0].State);
			Assert.AreEqual(timeStarted, threads[0].TimeStarted);
			Assert.AreEqual(timeFinished, threads[0].TimeFinished);
			Assert.AreEqual(1, threads[0].Priority);
			Assert.AreEqual(true, threads[0].Failed);
		}

		[Test]
		public void GetThreadsAppStatusThreadStatusTestSimpleScenario()
		{
			String applicationId1 = AddApplication(ApplicationState.Ready, DateTime.Now, true, "username");
			String applicationId2 = AddApplication(ApplicationState.Stopped, DateTime.Now, true, "username");
			String applicationId3 = AddApplication(ApplicationState.Ready, DateTime.Now, true, "username");
			String executorId = Guid.NewGuid().ToString();
			Int32 threadId = 125;
			
			DateTime now = DateTime.Now;
			DateTime timeStarted = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);
			now.AddDays(1);
			DateTime timeFinished = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);

			AddThread(applicationId1, executorId, threadId, ThreadState.Dead, timeStarted, timeFinished, 1, true);
			AddThread(applicationId1, executorId, threadId, ThreadState.Started, timeStarted, timeFinished, 1, true);
			AddThread(applicationId1, executorId, threadId, ThreadState.Ready, timeStarted, timeFinished, 1, true);
			AddThread(applicationId2, executorId, threadId, ThreadState.Ready, timeStarted, timeFinished, 1, true);
			AddThread(applicationId3, executorId, threadId, ThreadState.Ready, timeStarted, timeFinished, 1, true);
			
			ThreadStorageView[] allReadyAppThreads = ManagerStorage.GetThreads(ApplicationState.Ready);
			ThreadStorageView[] readyAppReadyThreads = ManagerStorage.GetThreads(ApplicationState.Ready, ThreadState.Ready);
			ThreadStorageView[] readyAppThreadsReadyOrStarted = ManagerStorage.GetThreads(ApplicationState.Ready, ThreadState.Ready, ThreadState.Started);

			Assert.AreEqual(4, allReadyAppThreads.Length);
			Assert.AreEqual(2, readyAppReadyThreads.Length);
			Assert.AreEqual(3, readyAppThreadsReadyOrStarted.Length);
		}

		[Test]
		public void GetThreadsAppStatusThreadStatusTestNoThreads()
		{			
			ThreadStorageView[] threads = ManagerStorage.GetThreads(ApplicationState.Ready, ThreadState.Started);

			Assert.AreEqual(0, threads.Length);
		}


		#endregion

		#region "GetExecutorThreads Tests"

		/// <summary>
		/// Add a new thread.
		/// Get the thread list.
		/// The list should only contain the newly added thread.
		/// </summary>
		[Test]
		public void GetExecutorThreadsTestSimpleScenario()
		{
			String applicationId = Guid.NewGuid().ToString();
			String executorId = Guid.NewGuid().ToString();
			Int32 threadId = 125;

			// TB: due to rounding errors the milliseconds might be lost in the database storage.
			// TB: I think this is OK so we create a test DateTime without milliseconds
			DateTime now = DateTime.Now;
			DateTime timeStarted = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);
			now.AddDays(1);
			DateTime timeFinished = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);

			AddThread(applicationId, executorId, threadId, ThreadState.Started, timeStarted, timeFinished, 1, true);
			
			ThreadStorageView[] threads = ManagerStorage.GetExecutorThreads(executorId);

			Assert.AreEqual(1, threads.Length);
			Assert.AreEqual(applicationId, threads[0].ApplicationId);
			Assert.AreEqual(executorId, threads[0].ExecutorId);
			Assert.AreEqual(threadId, threads[0].ThreadId);
			Assert.AreEqual(ThreadState.Started, threads[0].State);
			Assert.AreEqual(timeStarted, threads[0].TimeStarted);
			Assert.AreEqual(timeFinished, threads[0].TimeFinished);
			Assert.AreEqual(1, threads[0].Priority);
			Assert.AreEqual(true, threads[0].Failed);
		}

		/// <summary>
		/// Add 3 threads.
		/// Get the threads list.
		/// The list should contain 3 items.
		/// </summary>
		[Test]
		public void GetExecutorThreadsTestMultiple()
		{
			String applicationId = Guid.NewGuid().ToString();
			String executorId = Guid.NewGuid().ToString();

			AddThread(applicationId, executorId, 1, ThreadState.Dead, DateTime.Now, DateTime.Now.AddDays(1), 7, false);
			AddThread(applicationId, executorId, 2, ThreadState.Dead, DateTime.Now, DateTime.Now.AddDays(1), 7, false);
			AddThread(applicationId, executorId, 3, ThreadState.Dead, DateTime.Now, DateTime.Now.AddDays(1), 7, false);
			
			ThreadStorageView[] threads = ManagerStorage.GetExecutorThreads(executorId);

			Assert.AreEqual(3, threads.Length);
		}

		/// <summary>
		/// Add no threads.
		/// Get the thread list.
		/// The list should be empty but not null. No error is expected
		/// </summary>
		[Test]
		public void GetExecutorThreadsTestNoThreads()
		{
			ThreadStorageView[] threads = ManagerStorage.GetExecutorThreads(Guid.NewGuid().ToString());

			Assert.AreEqual(0, threads.Length);
		}

		/// <summary>
		/// Add a few threads.
		/// Get the thread list.
		/// The list should only contain the newly added thread.
		/// </summary>
		[Test]
		public void GetExecutorThreadsTestThreadsWithStatus()
		{
			String applicationId = Guid.NewGuid().ToString();
			String executorId = Guid.NewGuid().ToString();
			Int32 threadId = 125;

			// TB: due to rounding errors the milliseconds might be lost in the database storage.
			// TB: I think this is OK so we create a test DateTime without milliseconds
			DateTime now = DateTime.Now;
			DateTime timeStarted = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);
			now.AddDays(1);
			DateTime timeFinished = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);

			AddThread(applicationId, executorId, threadId, ThreadState.Started, timeStarted, timeFinished, 1, true);
			AddThread(applicationId, executorId, threadId, ThreadState.Ready, timeStarted, timeFinished, 1, true);
			AddThread(applicationId, executorId, threadId, ThreadState.Dead, timeStarted, timeFinished, 1, true);
			
			ThreadStorageView[] allThreads = ManagerStorage.GetExecutorThreads(executorId);
			ThreadStorageView[] threads = ManagerStorage.GetExecutorThreads(executorId, ThreadState.Started);
			ThreadStorageView[] threadsReadyOrStarted = ManagerStorage.GetExecutorThreads(executorId, ThreadState.Ready, ThreadState.Started);

			Assert.AreEqual(1, threads.Length);
			Assert.AreEqual(3, allThreads.Length);
			Assert.AreEqual(2, threadsReadyOrStarted.Length);
			Assert.AreEqual(applicationId, threads[0].ApplicationId);
			Assert.AreEqual(executorId, threads[0].ExecutorId);
			Assert.AreEqual(threadId, threads[0].ThreadId);
			Assert.AreEqual(ThreadState.Started, threads[0].State);
			Assert.AreEqual(timeStarted, threads[0].TimeStarted);
			Assert.AreEqual(timeFinished, threads[0].TimeFinished);
			Assert.AreEqual(1, threads[0].Priority);
			Assert.AreEqual(true, threads[0].Failed);
		}


		/// <summary>
		/// Add a few threads.
		/// Get the thread list.
		/// The list should only contain the newly added thread.
		/// </summary>
		[Test]
		public void GetExecutorThreadsTestDedicatedWithStatus()
		{
			String applicationId = Guid.NewGuid().ToString();
			String executorId1 = AddExecutor(true, true, DateTime.Now, "test", 1, "username1", 0, 0, 0, 0);
			String executorId2 = AddExecutor(false, true, DateTime.Now, "test", 1, "username1", 0, 0, 0, 0);
			Int32 threadId = 125;

			// TB: due to rounding errors the milliseconds might be lost in the database storage.
			// TB: I think this is OK so we create a test DateTime without milliseconds
			DateTime now = DateTime.Now;
			DateTime timeStarted = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);
			now.AddDays(1);
			DateTime timeFinished = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);
			
			AddThread(applicationId, executorId1, threadId, ThreadState.Started, timeStarted, timeFinished, 1, true);
			AddThread(applicationId, executorId2, threadId, ThreadState.Ready, timeStarted, timeFinished, 1, true);
			AddThread(applicationId, executorId1, threadId, ThreadState.Dead, timeStarted, timeFinished, 1, true);
			
			ThreadStorageView[] dedicatedThreads = ManagerStorage.GetExecutorThreads(true);
			ThreadStorageView[] threads = ManagerStorage.GetExecutorThreads(true, ThreadState.Started);

			Assert.AreEqual(1, threads.Length);
			Assert.AreEqual(2, dedicatedThreads.Length);
			Assert.AreEqual(applicationId, threads[0].ApplicationId);
			Assert.AreEqual(executorId1, threads[0].ExecutorId);
			Assert.AreEqual(threadId, threads[0].ThreadId);
			Assert.AreEqual(ThreadState.Started, threads[0].State);
			Assert.AreEqual(timeStarted, threads[0].TimeStarted);
			Assert.AreEqual(timeFinished, threads[0].TimeFinished);
			Assert.AreEqual(1, threads[0].Priority);
			Assert.AreEqual(true, threads[0].Failed);
		}


		/// <summary>
		/// Add a few threads.
		/// Get the thread list.
		/// The list should only contain the newly added thread.
		/// </summary>
		[Test]
		public void GetExecutorThreadsTestConnectedWithStatus()
		{
			String applicationId = Guid.NewGuid().ToString();
			String executorId1 = AddExecutor(true, true, DateTime.Now, "test", 1, "username1", 0, 0, 0, 0);
			String executorId2 = AddExecutor(false, false, DateTime.Now, "test", 1, "username1", 0, 0, 0, 0);
			Int32 threadId = 125;

			// TB: due to rounding errors the milliseconds might be lost in the database storage.
			// TB: I think this is OK so we create a test DateTime without milliseconds
			DateTime now = DateTime.Now;
			DateTime timeStarted = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);
			now.AddDays(1);
			DateTime timeFinished = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);
			
			AddThread(applicationId, executorId1, threadId, ThreadState.Started, timeStarted, timeFinished, 1, true);
			AddThread(applicationId, executorId2, threadId, ThreadState.Ready, timeStarted, timeFinished, 1, true);
			AddThread(applicationId, executorId1, threadId, ThreadState.Dead, timeStarted, timeFinished, 1, true);
			
			ThreadStorageView[] dedicatedThreads = ManagerStorage.GetExecutorThreads(true, true);
			ThreadStorageView[] threads = ManagerStorage.GetExecutorThreads(true, true, ThreadState.Started);

			Assert.AreEqual(1, threads.Length);
			Assert.AreEqual(2, dedicatedThreads.Length);
			Assert.AreEqual(applicationId, threads[0].ApplicationId);
			Assert.AreEqual(executorId1, threads[0].ExecutorId);
			Assert.AreEqual(threadId, threads[0].ThreadId);
			Assert.AreEqual(ThreadState.Started, threads[0].State);
			Assert.AreEqual(timeStarted, threads[0].TimeStarted);
			Assert.AreEqual(timeFinished, threads[0].TimeFinished);
			Assert.AreEqual(1, threads[0].Priority);
			Assert.AreEqual(true, threads[0].Failed);
		}

		#endregion


		#region "GetApplicationThreadCount Tests"

		/// <summary>
		/// Add no application or thread
		/// Attempt to get the threads, it should return 0
		/// </summary>
		[Test]
		public void GetApplicationThreadCountTestNoThreadInformation()
		{
			String applicationId = Guid.NewGuid().ToString();
			Int32 totalThreads;
			Int32 unfinishedThreads;

			ManagerStorage.GetApplicationThreadCount(applicationId, out totalThreads, out unfinishedThreads);

			Assert.AreEqual(0, totalThreads);
			Assert.AreEqual(0, unfinishedThreads);
		}

		/// <summary>
		/// Add a few threads for an application
		/// Attempt to get the threads, the numbers should be good
		/// </summary>
		[Test]
		public void GetApplicationThreadCountTestSimpleScenario()
		{
			String applicationId = Guid.NewGuid().ToString();
			Int32 totalThreads;
			Int32 unfinishedThreads;

			// add 4 threads, 3 are unfinished
			AddThread(applicationId, null, 1, ThreadState.Ready, DateTime.Now, DateTime.Now, 0, false);
			AddThread(applicationId, null, 2, ThreadState.Scheduled, DateTime.Now, DateTime.Now, 0, false);
			AddThread(applicationId, null, 3, ThreadState.Started, DateTime.Now, DateTime.Now, 0, false);
			AddThread(applicationId, null, 4, ThreadState.Finished, DateTime.Now, DateTime.Now, 0, false);

			ManagerStorage.GetApplicationThreadCount(applicationId, out totalThreads, out unfinishedThreads);

			Assert.AreEqual(4, totalThreads);
			Assert.AreEqual(3, unfinishedThreads);
		}

		#endregion

		#region "GetApplicationThreadCount Overloaded Tests"

		/// <summary>
		/// Add no application or thread
		/// Attempt to get the threads, it should return 0
		/// </summary>
		[Test]
		public void GetApplicationThreadCountTestNoThreadInformationForOverload()
		{
			String applicationId = Guid.NewGuid().ToString();

			Int32 result = ManagerStorage.GetApplicationThreadCount(applicationId, ThreadState.Dead);

			Assert.AreEqual(0, result);
		}

		/// <summary>
		/// Add a few threads for an application
		/// Attempt to get the threads, the numbers should be good
		/// </summary>
		[Test]
		public void GetApplicationThreadCountTestSimpleScenarioForOverload()
		{
			String applicationId = Guid.NewGuid().ToString();

			// add 4 threads, 3 are unfinished
			AddThread(applicationId, null, 1, ThreadState.Ready, DateTime.Now, DateTime.Now, 0, false);
			AddThread(applicationId, null, 2, ThreadState.Scheduled, DateTime.Now, DateTime.Now, 0, false);
			AddThread(applicationId, null, 3, ThreadState.Started, DateTime.Now, DateTime.Now, 0, false);
			AddThread(applicationId, null, 4, ThreadState.Finished, DateTime.Now, DateTime.Now, 0, false);

			Int32 ready = ManagerStorage.GetApplicationThreadCount(applicationId, ThreadState.Ready);
			Int32 scheduled = ManagerStorage.GetApplicationThreadCount(applicationId, ThreadState.Scheduled);
			Int32 started = ManagerStorage.GetApplicationThreadCount(applicationId, ThreadState.Started);
			Int32 finished = ManagerStorage.GetApplicationThreadCount(applicationId, ThreadState.Finished);
			Int32 dead = ManagerStorage.GetApplicationThreadCount(applicationId, ThreadState.Dead);

			Assert.AreEqual(1, ready);
			Assert.AreEqual(1, scheduled);
			Assert.AreEqual(1, started);
			Assert.AreEqual(1, finished);
			Assert.AreEqual(0, dead);
		}

		#endregion

		#region "GetExecutorThreadCount Tests"

		/// <summary>
		/// Add no thread
		/// Attempt to get the threads, it should return 0
		/// </summary>
		[Test]
		public void GetExecutorThreadCountTestNoThreadInformation()
		{
			String executorId = Guid.NewGuid().ToString();

			Int32 result = ManagerStorage.GetExecutorThreadCount(executorId, ThreadState.Dead);

			Assert.AreEqual(0, result);
		}

		/// <summary>
		/// Add no thread
		/// Attempt to get the threadsbut with no state, we should get 0
		/// </summary>
		[Test]
		public void GetExecutorThreadCountTestEmptyRequestArray()
		{
			String executorId = Guid.NewGuid().ToString();

			Int32 result = ManagerStorage.GetExecutorThreadCount(executorId);

			Assert.AreEqual(0, result);
		}

		/// <summary>
		/// Add no thread
		/// Attempt to get the threadsbut with no state, we should get 0
		/// </summary>
		[Test]
		public void GetExecutorThreadCountTestNullExecutorId()
		{
			String applicationId = Guid.NewGuid().ToString();
			String executorId = Guid.NewGuid().ToString();

			AddThread(applicationId, executorId, 1, ThreadState.Ready, DateTime.Now, DateTime.Now, 0, false);

			Int32 result = ManagerStorage.GetExecutorThreadCount(null, ThreadState.Started);

			Assert.AreEqual(0, result);
		}

		/// <summary>
		/// Add a few threads for an executor
		/// Attempt to get the threads, the numbers should be good
		/// </summary>
		[Test]
		public void GetExecutorThreadCountTestSimpleScenario()
		{
			String applicationId = Guid.NewGuid().ToString();
			String executorId1 = Guid.NewGuid().ToString();
			String executorId2 = Guid.NewGuid().ToString();

			// add 4 threads, 3 are unfinished
			AddThread(applicationId, executorId1, 1, ThreadState.Ready, DateTime.Now, DateTime.Now, 0, false);
			AddThread(applicationId, executorId1, 2, ThreadState.Scheduled, DateTime.Now, DateTime.Now, 0, false);
			AddThread(applicationId, executorId1, 3, ThreadState.Started, DateTime.Now, DateTime.Now, 0, false);
			AddThread(applicationId, executorId1, 4, ThreadState.Finished, DateTime.Now, DateTime.Now, 0, false);
			
			// and a few more for other executors
			AddThread(applicationId, null, 1, ThreadState.Ready, DateTime.Now, DateTime.Now, 0, false);
			AddThread(applicationId, executorId2, 2, ThreadState.Scheduled, DateTime.Now, DateTime.Now, 0, false);
			AddThread(applicationId, null, 3, ThreadState.Started, DateTime.Now, DateTime.Now, 0, false);
			AddThread(applicationId, executorId2, 4, ThreadState.Finished, DateTime.Now, DateTime.Now, 0, false);

			Int32 ready = ManagerStorage.GetExecutorThreadCount(executorId1, ThreadState.Ready);
			Int32 scheduled = ManagerStorage.GetExecutorThreadCount(executorId1, ThreadState.Scheduled);
			Int32 started = ManagerStorage.GetExecutorThreadCount(executorId1, ThreadState.Started);
			Int32 finished = ManagerStorage.GetExecutorThreadCount(executorId1, ThreadState.Finished);
			Int32 dead = ManagerStorage.GetExecutorThreadCount(executorId1, ThreadState.Dead);
			Int32 notDeadOrFinished = ManagerStorage.GetExecutorThreadCount(
				executorId1, 
				ThreadState.Ready,
				ThreadState.Scheduled,
				ThreadState.Started);

			Assert.AreEqual(1, ready);
			Assert.AreEqual(1, scheduled);
			Assert.AreEqual(1, started);
			Assert.AreEqual(1, finished);
			Assert.AreEqual(0, dead);
			Assert.AreEqual(3, notDeadOrFinished);
		}

		#endregion

		#region "DeleteThread Tests"

		/// <summary>
		/// Add a thread
		/// Delete the thread
		/// </summary>
		[Test]
		public void DeleteThreadTestSimpleDelete()
		{
			String executorId = Guid.NewGuid().ToString();
			String applicationId = Guid.NewGuid().ToString();
			String executorId1 = Guid.NewGuid().ToString();

			AddThread(applicationId, executorId1, 1, ThreadState.Ready, DateTime.Now, DateTime.Now, 0, false);

			ThreadStorageView[] threadsBefore = ManagerStorage.GetThreads();

			ManagerStorage.DeleteThread(new ThreadStorageView(applicationId, 1));

			ThreadStorageView[] threadsAfter = ManagerStorage.GetThreads();

			Assert.AreEqual(1, threadsBefore.Length);
			Assert.AreEqual(0, threadsAfter.Length);
		}

		[Test]
		public void DeleteThreadTestNothingAdded()
		{
			String executorId = Guid.NewGuid().ToString();
			String applicationId = Guid.NewGuid().ToString();

			ManagerStorage.DeleteThread(new ThreadStorageView(applicationId, 1));

			ThreadStorageView[] threadsAfter = ManagerStorage.GetThreads();

			Assert.AreEqual(0, threadsAfter.Length);
		}

		[Test]
		public void DeleteThreadTestNullThreadToDelete()
		{
			String executorId = Guid.NewGuid().ToString();
			String applicationId = Guid.NewGuid().ToString();
			String executorId1 = Guid.NewGuid().ToString();

			AddThread(applicationId, executorId1, 1, ThreadState.Ready, DateTime.Now, DateTime.Now, 0, false);

			ThreadStorageView[] threadsBefore = ManagerStorage.GetThreads();

			ManagerStorage.DeleteThread(null);

			ThreadStorageView[] threadsAfter = ManagerStorage.GetThreads();

			Assert.AreEqual(1, threadsBefore.Length);
			Assert.AreEqual(1, threadsAfter.Length);
		}

		#endregion

		#region "GetSystemSummary Tests"

		[Test]
		public void GetSystemSummaryTestExecutorCount()
		{
			String executorId = AddExecutor(false, true, DateTime.Now, "test", 9999, "username1", 111, 123, 34, (float)3.4);

			SystemSummary result = ManagerStorage.GetSystemSummary();

			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.TotalExecutors);
		}

		[Test]
		public void GetSystemSummaryTestUnfinishedAppCount()
		{
			// add one that is not finished
			AddApplication(ApplicationState.Ready, DateTime.Now, true, "user");

			// add another one that is finished
			AddApplication(ApplicationState.Stopped, DateTime.Now, true, "user");

			SystemSummary result = ManagerStorage.GetSystemSummary();

			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.UnfinishedApps);
		}

		[Test]
		public void GetSystemSummaryTestUnfinishedThreadCount()
		{
			String executorId = AddExecutor(false, true, DateTime.Now, "test", 9999, "username1", 111, 123, 34, (float)3.4);

			string applicationId = AddApplication(ApplicationState.Ready, DateTime.Now, true, "user");
			AddThread(applicationId, executorId, 1, ThreadState.Ready, DateTime.Now, DateTime.Now, 1, false);
			AddThread(applicationId, executorId, 2, ThreadState.Finished, DateTime.Now, DateTime.Now, 1, false);
			AddThread(applicationId, executorId, 3, ThreadState.Scheduled, DateTime.Now, DateTime.Now, 1, false);
			AddThread(applicationId, executorId, 4, ThreadState.Started, DateTime.Now, DateTime.Now, 1, false);
			AddThread(applicationId, executorId, 5, ThreadState.Dead, DateTime.Now, DateTime.Now, 1, false);
			AddThread(applicationId, executorId, 6, ThreadState.Unknown, DateTime.Now, DateTime.Now, 1, false);

			SystemSummary result = ManagerStorage.GetSystemSummary();

			Assert.IsNotNull(result);
			// everything that is not Dead or Finished is counted
			Assert.AreEqual(4, result.UnfinishedThreads);
		}

		[Test]
		public void GetSystemSummaryTestMaxPower()
		{
			AddExecutor(false, true, DateTime.Now, "test", 9999, "username1", 1111, 123, 34, (float)3.4);
			AddExecutor(false, true, DateTime.Now, "test", 9999, "username1", 2222, 123, 34, (float)3.4);

			SystemSummary result = ManagerStorage.GetSystemSummary();

			Assert.IsNotNull(result);

			Assert.AreEqual("3.333 GHz", result.MaxPower);
		}

		[Test]
		public void GetSystemSummaryTestPowerUsage()
		{
			AddExecutor(false, true, DateTime.Now, "test", 9999, "username1", 1111, 23, 34, (float)3.4);
			AddExecutor(false, true, DateTime.Now, "test", 9999, "username1", 1111, 11, 34, (float)3.4);

			SystemSummary result = ManagerStorage.GetSystemSummary();

			Assert.IsNotNull(result);

			Assert.AreEqual(17, result.PowerUsage);
		}

		[Test]
		public void GetSystemSummaryTestPowerAvailable()
		{
			AddExecutor(false, true, DateTime.Now, "test", 9999, "username1", 1111, 23, 94, (float)3.4);
			AddExecutor(false, true, DateTime.Now, "test", 9999, "username1", 1111, 12, 92, (float)3.4);

			SystemSummary result = ManagerStorage.GetSystemSummary();

			Assert.IsNotNull(result);

			Assert.AreEqual(93, result.PowerAvailable);
		}

		[Test]
		public void GetSystemSummaryTestPowerTotalUsage()
		{
			AddExecutor(false, true, DateTime.Now, "test", 9999, "username1", 1594, 23, 94, (float)1.41999);
			AddExecutor(false, true, DateTime.Now, "test", 9999, "username1", 1594, 12, 93, (float)23.7800);

			SystemSummary result = ManagerStorage.GetSystemSummary();

			Assert.IsNotNull(result);

			Assert.AreEqual("0.011158 GHz*Hr", result.PowerTotalUsage);
		}

		#endregion
	}
}
