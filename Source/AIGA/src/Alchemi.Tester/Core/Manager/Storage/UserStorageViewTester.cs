#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  UserStorageViewTester.cs
* Project       :  Alchemi.Tester.Core.Manager.Storage
* Created on    :  26 February 2006
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

using Alchemi.Core.Manager.Storage;

using NUnit.Framework;

namespace Alchemi.Tester.Core.Manager.Storage
{
	/// <summary>
	/// Test functionality in UserStorageView
	/// </summary>
	[TestFixture]
	public class UserStorageViewTester
	{
		// The MD5 hash of the word "user"
		private const string UserMD5Hash = "9ce4b5879f3fcb5a9842547bebe191e1";

		// The MD5 hash of the word "admin"
		private const string AdminMD5Hash = "19a2854144b63a8f7617a6f225019b12";

		#region "PasswordMd5Hash Tests"

		/// <summary>
		/// Confirm that the password hash is properly computed.
		/// </summary>
		[Test]
		public void PasswordMd5HashTestHasComputing()
		{
			const string password = "user";

			UserStorageView user = new UserStorageView("test", password, 1);

			Assert.AreEqual(UserMD5Hash, user.PasswordMd5Hash);
		}

		/// <summary>
		/// Confirm that the password hash is recomputed after the password is changed.
		/// This is used to reproduce a buggy condition discovered in 1.0.3
		/// </summary>
		[Test]
		public void PasswordMd5HashTestHashRecomputedAfterPasswordChanged()
		{
			UserStorageView user = new UserStorageView("test");

			user.PasswordMd5Hash = UserMD5Hash;

			// confirm that the hash is properly initiated
			Assert.AreEqual(UserMD5Hash, user.PasswordMd5Hash);

			user.Password = "admin";

			// confirm that the hash is computed again if the password was changed
			Assert.AreEqual(AdminMD5Hash, user.PasswordMd5Hash);
		}

		[Test]
		public void PasswordMd5HashTestSettingHashDirectly()
		{
			UserStorageView user = new UserStorageView("test");

			user.PasswordMd5Hash = UserMD5Hash;

			// confirm that the hash is properly set even if the password was not set
			Assert.AreEqual(UserMD5Hash, user.PasswordMd5Hash);
			
			// the clear-text password should be removed if a hash is set directly
			Assert.IsNull(user.Password);
		}

		#endregion

	}
}
