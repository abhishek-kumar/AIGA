#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	IScheduler.cs
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
using Alchemi.Core;
using Alchemi.Core.Owner;

namespace Alchemi.Manager
{
	/// <summary>
	/// Represents scheduler.
	/// This interface defines the basic members that need to exist in any scheduler implementation.
	/// </summary>
    public interface IScheduler
    {
		/// <summary>
		/// Sets the collection Applications
		/// </summary>
        MApplicationCollection Applications { set; }

		/// <summary>
		/// Sets the collection of Executors.
		/// </summary>
        MExecutorCollection Executors { set; }

		/// <summary>
		/// Returns a thread-identifier representing the next thread scheduled to the given executor.
		/// This represents a non-dedicated schedule, since the Executor would ask for this  thread-identifier.
		/// </summary>
		/// <param name="executorId"></param>
		/// <returns></returns>
		ThreadIdentifier ScheduleNonDedicated(string executorId);

		/// <summary>
		/// Returns the next available dedicated-schedule: containing the application,thread and executor id.
		/// </summary>
		/// <returns></returns>
        DedicatedSchedule ScheduleDedicated();
    }
}
