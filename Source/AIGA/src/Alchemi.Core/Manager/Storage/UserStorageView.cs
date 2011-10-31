#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  UserStorageView.cs
* Project       :  Alchemi.Core.Manager.Storage
* Created on    :  21 September 2005
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

using Alchemi.Core.Utility;

namespace Alchemi.Core.Manager.Storage
{
	/// <summary>
	/// Storage view of a user object. 
	/// Used to pass user related data to and from the storage layer.
	/// </summary>
	[Serializable]
	public class UserStorageView
	{
		#region "Private variables"
		
		//private Int32 m_userId; 
		private String m_username;

		private String m_password = null;

		/// <summary>
		/// use this sto store a hash if the plain password is unknown
		/// </summary>
		private String m_passwordMd5Hash = null;

		private Int32 m_groupId; 

		private bool m_is_system;

		#endregion

		#region "Properties"

		/// <summary>
		/// Gets or sets a value indicating whether this user is a system user.
		/// </summary>
		public bool IsSystem
		{
			get
			{
				return m_is_system;
			}
			set
			{
				m_is_system = value;
			}
		}

		/// <summary>
		/// The username.
		/// </summary>
		public String Username
		{
			get
			{
				return m_username;
			}
			set
			{
				m_username = value;
			}
		}
		
		/// <summary>
		/// The password. This value is never stored in the database.
		/// This is used to calculate the MD5 hash stored in the database. 
		/// <seealso cref="PasswordMd5Hash"/>
		/// </summary>
		public String Password
		{
			get
			{
				return m_password;
			}
			set
			{
				m_password = value;

				// clean the password hash once the clear-text password was set
				m_passwordMd5Hash = null;
			}
		}

		/// <summary>
		/// The password's MD5 hash. When validating the user's password only this hash is required.
		/// <seealso cref="Password"/>
		/// </summary>
		public String PasswordMd5Hash
		{
			get
			{
				if (m_passwordMd5Hash != null)
				{
					return m_passwordMd5Hash;
				}
				else
				{
					return HashUtil.GetHash(m_password, HashUtil.HashType.MD5);
				}
			}
			set
			{
				m_passwordMd5Hash = value;

				// remove the clear-text password
				m_password = null;
			}
		}

		/// <summary>
		/// The group id this user belongs to.
		/// </summary>
		public Int32 GroupId
		{
			get
			{
				return m_groupId;
			}
			set
			{
				m_groupId = value;
			}
		}

		#endregion

		/// <summary>
		/// UserStorageView constructor.
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <param name="groupId"></param>
		public UserStorageView(String username, String password, Int32 groupId)
		{
			m_username = username;
			m_password = password;
			m_groupId = groupId; 
		}

		/// <summary>
		/// UserStorageView constructor.
		/// </summary>
		/// <param name="username"></param>
		public UserStorageView(String username) : this(username, "", -1)
		{
		}

	}
}
