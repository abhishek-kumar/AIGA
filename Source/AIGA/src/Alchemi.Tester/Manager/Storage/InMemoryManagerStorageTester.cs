#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  InMemoryManagerStorageTester.cs
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

using Alchemi.Core.Manager.Storage;
using Alchemi.Manager.Storage;

using NUnit.Framework;

namespace Alchemi.Tester.Manager.Storage
{
	/// <summary>
	/// Summary description for InMemoryManagerStorage.
	/// </summary>
	[TestFixture]
	public class InMemoryManagerStorageTester : ManagerStorageTester
	{
		private InMemoryManagerStorage m_managerStorage;

		public override IManagerStorage ManagerStorage
		{
			get
			{
				return m_managerStorage;
			}
		}

		[SetUp]
		public void TestStartUp()
		{
			m_managerStorage = new InMemoryManagerStorage();

			m_managerStorage.SetUpStorage();
			m_managerStorage.InitializeStorageData();
		}

		public InMemoryManagerStorageTester()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
