#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	IExecutor.cs
* Project		:	Alchemi Core
* Created on	:	2003
* Copyright		:	Copyright © 2006 The University of Melbourne
*					This technology has been developed with the support of 
*					the Australian Research Council and the University of Melbourne
*					research grants as part of the Gridbus Project
*					within GRIDS Laboratory at the University of Melbourne, Australia.
* Author         :  Akshay Luther (akshayl@csse.unimelb.edu.au), Rajkumar Buyya (raj@csse.unimelb.edu.au), and Krishna Nadiminti (kna@csse.unimelb.edu.au)
* License        :  GPL
*					This program is free software; you can redistribute it and/or 
*					modify it under the terms of the GNU General Public
*					License as published by the Free Software Foundation;
*					See the GNU General Public License 
*					(http://www.gnu.org/copyleft/gpl.html) for more details.
*
*/ 
#endregion

using Alchemi.Core.Owner;

namespace Alchemi.Core
{
	/// <summary>
	/// Defines the functions / services that should be provided by an executor implementation
	/// </summary>
    public interface IExecutor
    {
		/// <summary>
		/// Ping the executor to check if it is alive
		/// </summary>
        void PingExecutor();
        
		/// <summary>
		/// Executes the thread with the given identifier. 
		/// <br/>(Generally meant to be called by a Manager)
		/// </summary>
		/// <param name="ti"></param>
        void Manager_ExecuteThread(ThreadIdentifier ti);
        
		/// <summary>
		/// Aborts the thread with the given identifier
		/// <br/>(Generally meant to be called by a Manager)
		/// </summary>
		/// <param name="ti"></param>
		void Manager_AbortThread(ThreadIdentifier ti);

		/// <summary>
		/// Cleans up the files related to the application with the given id.
		/// <br/>(Generally meant to be called by a Manager)
		/// </summary>
		/// <param name="appid"></param>
		void Manager_CleanupApplication(string appid);
    }
}
