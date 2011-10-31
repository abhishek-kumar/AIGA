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

namespace Alchemi.Manager.Storage
{
	/// <summary>
	/// Summary description for ManagerStorageEnum.
	/// </summary>
	public enum ManagerStorageEnum
	{
		InMemory,
		SqlServer,
		MySql
	}
}
