#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  MySqlManagerDatabaseStorage.cs
* Project       :  Alchemi.Core.Manager.Storage
* Created on    :  28 December 2005
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
using System.Collections;

using Alchemi.Core.Manager;
using Alchemi.Core.Manager.Storage;

namespace Alchemi.Manager.Storage
{
	/// <summary>
	/// Functionality common to all storage types. 
	/// </summary>
	public abstract class ManagerStorageBase
	{
		private const Int32 c_AdminsGroupId = 1;
		private const Int32 c_ExecutorsGroupId = 2;
		private const Int32 c_UsersGroupId = 3;

		/// <summary>
		/// Create the default objects to complete initializing the manager storage.
		/// </summary>
		/// <param name="managerStorage"></param>
		protected void CreateDefaultObjects(IManagerStorage managerStorage)
		{
			// create default groups
			ArrayList defaultGroups = new ArrayList();
			GroupStorageView newGroup;
			
			newGroup = new GroupStorageView(c_AdminsGroupId, "Administrators");
			newGroup.Description = "Administrators Group";
			newGroup.IsSystem = true;
			defaultGroups.Add(newGroup);

			newGroup = new GroupStorageView(c_ExecutorsGroupId, "Executors");
			newGroup.Description = "Executors Group";
			newGroup.IsSystem = true;
			defaultGroups.Add(newGroup);

			newGroup = new GroupStorageView(c_UsersGroupId, "Users");
			newGroup.Description = "Users Group";
			newGroup.IsSystem = true;
			defaultGroups.Add(newGroup);

			managerStorage.AddGroups((GroupStorageView[])defaultGroups.ToArray(typeof(GroupStorageView)));

			// set default permissions

			//permissions for admins group
			managerStorage.AddGroupPermission(c_AdminsGroupId, Permission.ExecuteThread);
			managerStorage.AddGroupPermission(c_AdminsGroupId, Permission.ManageOwnApp);
			managerStorage.AddGroupPermission(c_AdminsGroupId, Permission.ManageAllApps);
			managerStorage.AddGroupPermission(c_AdminsGroupId, Permission.ManageUsers);

			//permissions for executors group
			managerStorage.AddGroupPermission(c_ExecutorsGroupId, Permission.ExecuteThread);

			//permissions for users group
			managerStorage.AddGroupPermission(c_UsersGroupId, Permission.ManageOwnApp);

			// create default users
			ArrayList defaultUsers = new ArrayList();
			UserStorageView newUser;

			newUser = new UserStorageView("admin", "admin", c_AdminsGroupId);
			newUser.IsSystem = true;
			defaultUsers.Add(newUser);

			newUser = new UserStorageView("executor", "executor", c_ExecutorsGroupId);
			newUser.IsSystem = true;
			defaultUsers.Add(newUser);

			newUser = new UserStorageView("user", "user", c_UsersGroupId);
			newUser.IsSystem = true;
			defaultUsers.Add(newUser);

			managerStorage.AddUsers((UserStorageView[])defaultUsers.ToArray(typeof(UserStorageView)));
		}
	}
}
