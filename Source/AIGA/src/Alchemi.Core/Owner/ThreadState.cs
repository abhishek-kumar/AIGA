#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	ThreadState.cs
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

using System;

namespace Alchemi.Core.Owner
{
	/// <summary>
	/// List of possible thread states
	/// Ready = 0, // ready to execute <br />
	/// Scheduled = 1, // executor has id <br/>
	/// Started = 2, // executor has thread and is executing <br />
	/// Finished = 3, // executor has returned the finished thread<br />
	/// Dead = 4, // returned to owner OR aborted
	/// </summary>
	[Serializable]
    public enum ThreadState
    {
		/// <summary>
		/// Unknown or unitialized
		/// </summary>
		Unknown = -1, // added by Tibor Biro (tb@tbiro.com)

		/// <summary>
		/// Ready to execute
		/// </summary>
        Ready = 0,

		/// <summary>
		/// Executor received the Id for the thread.
		/// </summary>
        Scheduled = 1, 

		/// <summary>
		/// Executor has thread and is executing.
		/// </summary>
        Started = 2, 

		/// <summary>
		/// Executor has returned the finished thread.
		/// </summary>
        Finished = 3, 

		/// <summary>
		/// Returned to owner OR aborted
		/// </summary>
        Dead = 4, 
    }
}