#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  ManagerStorageTypeDropdownItem.cs
* Project       :  Alchemi.ManagerUtils.DbSetup
* Created on    :  19 January 2005
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

using Alchemi.Manager.Storage;

namespace Alchemi.ManagerUtils.DbSetup
{
	/// <summary>
	/// Data stored in the manager storage type dropdown.
	/// </summary>
	public class ManagerStorageTypeDropdownItem
	{
		public String Description;

		public ManagerStorageEnum StorageType;

		public ManagerStorageTypeDropdownItem(String description, ManagerStorageEnum storageType)
		{
			Description = description;
			StorageType = storageType;
		}

		public override string ToString()
		{
			return Description;
		}
	}
}
