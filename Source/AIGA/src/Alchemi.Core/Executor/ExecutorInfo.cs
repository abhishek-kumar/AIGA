#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	ExecutorInfo.cs
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


using System;

namespace Alchemi.Core.Executor
{
	/// <summary>
	/// Represents the static attributes of an executor.
	/// 
	/// </summary>
    [Serializable]
    public struct ExecutorInfo
    {
		/// <summary>
		/// Gets or sets the Hostname of the Executor.
		/// </summary>
		public string Hostname;
		/// <summary>
		/// Gets or sets the maximum CPU power in the Executor hardware. (in Mhz)?Ghz
		/// </summary>
        public int MaxCpuPower;
		/// <summary>
		/// Gets or sets the maximum memory (RAM) in the Executor hardware. (in MB)
		/// </summary>
		public float MaxMemory; //in MB
		/// <summary>
		/// Gets or sets the maximum disk space in the Executor hardware. (in MB)
		/// </summary>
		public float MaxDiskSpace; // in MB
		/// <summary>
		/// Gets or sets the total number of CPUs in the Executor hardware.
		/// </summary>
		public int Number_of_CPUs;
		/// <summary>
		/// Gets or sets the name of Operating system running on the Executor
		/// </summary>
		public string OS;
		/// <summary>
		/// Gets or sets the architecture of the processor/machine of the Executor (eg: x86, RISC etc)
		/// </summary>
		public string Architecture;

		//these attributes are the limits set by the owner/administrator of the Executor node
		/// <summary>
		/// 
		/// </summary>
		public int CPULimit; //in Ghz * hr
		/// <summary>
		/// 
		/// </summary>
		public float memLimit; //in MB
		/// <summary>
		/// 
		/// </summary>
		public float diskLimit; //in MB

		//Qos stuff
		/// <summary>
		/// 
		/// </summary>
		public float CostPerCPUSec;
		/// <summary>
		/// 
		/// </summary>
		public float CostPerThread;
		/// <summary>
		/// 
		/// </summary>
		public float CostPerDiskMB;
    }
}


