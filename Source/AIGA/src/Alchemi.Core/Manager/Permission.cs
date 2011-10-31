#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	Permission.cs
* Project		:	Alchemi Core
* Created on	:	2003
* Copyright		:	Copyright © 2006 The University of Melbourne
*					This technology has been developed with the support of 
*					the Australian Research Council and the University of Melbourne
*					research grants as part of the Gridbus Project
*					within GRIDS Laboratory at the University of Melbourne, Australia.
* Author         :  Akshay Luther (akshayl@csse.unimelb.edu.au) and Rajkumar Buyya (raj@csse.unimelb.edu.au)
* License        :  GPL
*					This program is free software; you can redistribute it and/or 
*					modify it under the terms of the GNU General Public
*					License as published by the Free Software Foundation;
*					See the GNU General Public License 
*					(http://www.gnu.org/copyleft/gpl.html) for more details.
*
*/ 
#endregion


namespace Alchemi.Core.Manager
{
	/// <summary>
	/// List of various permission values.
	/// Possible values are:
	/// ExecuteThread ,
	/// ManageOwnApp ,
	/// ManageAllApps3,
	/// ManageUsers 
	/// </summary>
    public enum Permission
    {
		/// <summary>
		/// Allowed to execute threads.
		/// </summary>
        ExecuteThread = 1,

		/// <summary>
		/// Allowed to manage own applications.
		/// </summary>
        ManageOwnApp = 2,

		/// <summary>
		/// Allowed to manage all applications.
		/// </summary>
        ManageAllApps = 3,

		/// <summary>
		/// Allowed to manage users.
		/// </summary>
        ManageUsers = 4
    }
}