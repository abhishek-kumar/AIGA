#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	HeartbeatInfo.cs
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

namespace Alchemi.Core.Executor
{
	/// <summary>
	/// This structure is a container for all the information sent in a heartbeat update.
	/// This primarily consists of dynamic information about an Executor, such as current load conditions etc...
	/// </summary>
    [Serializable]
    public struct HeartbeatInfo
    {
		/// <summary>
		/// Heartbeat interval
		/// </summary>
        public int Interval;
		/// <summary>
		/// PercentUsedCpuPower
		/// </summary>
        public int PercentUsedCpuPower;
		/// <summary>
		/// PercentAvailCpuPower
		/// </summary>
        public int PercentAvailCpuPower;

		/// <summary>
		/// Creates an instance of the HeartBeat object with the given interval, used, and available CPU power.
		/// </summary>
		/// <param name="interval"></param>
		/// <param name="used"></param>
		/// <param name="avail"></param>
        public HeartbeatInfo(int interval, int used, int avail)
        {
            this.Interval = interval;
            this.PercentUsedCpuPower = used;
            this.PercentAvailCpuPower = avail;
        }
    }
}
