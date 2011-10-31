#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  IManagerStorageSetup.cs
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

namespace Alchemi.Core.Manager.Storage
{
	/// <summary>
	/// Sets up a specific storage structure.
	/// 
	/// A storage should know how to set itself up. In the event that the 
	/// storage detects that it is not setup it might decide to initialize
	/// the required data structures automatically.
	/// </summary>
	public interface IManagerStorageSetup
	{
		/// <summary>
		/// Create the physical storage.
		/// For databases this means creating the actual database files.
		/// </summary>
		void CreateStorage(String databaseName);

		/// <summary>
		/// Create the basic storage structures such as tables.
		/// </summary>
		void SetUpStorage();

		/// <summary>
		/// Add default storage data.
		/// </summary>
		void InitializeStorageData();

		/// <summary>
		/// Remove the structures initialized by this storage.
		/// </summary>
		void TearDownStorage();
	}
}
