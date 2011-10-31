#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  ExecutorStorageView.cs
* Project       :  Alchemi.Core.Manager.Storage
* Created on    :  23 September 2005
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

namespace Alchemi.Core.Manager.Storage
{
	/// <summary>
	/// Storage view of an executor object. 
	/// Used to pass executor related data to and from the storage layer.
	/// </summary>
	[Serializable]
	public class ExecutorStorageView
	{
		private static DateTime c_noTimeSet = DateTime.MinValue;

		#region "Private variables"
		
		private String m_executorId;
		private bool m_dedicated;
		private bool m_connected;
		private DateTime m_pingTime;
		private String m_hostname;
		private Int32 m_port;
		private String m_username;
		private Int32 m_maxCpu;
		private Int32 m_cpuUsage;
		private Int32 m_availableCpu;
		private float m_totalCpuUsage;

		private float m_maxMemory;
		private float m_maxDisk;
		private Int32 m_numberOfCpu;
		private String m_os;
		private String m_architecture;

		#endregion

		#region "Properties"

		/// <summary>
		/// Executor architecture.
		/// </summary>
		public String Architecture
		{
			get
			{
				return m_architecture;
			}
			set
			{
				m_architecture = value;
			}
		}

		/// <summary>
		/// Executor Operating System.
		/// </summary>
		public String Os
		{
			get
			{
				return m_os;
			}
			set
			{
				m_os = value;
			}
		}

		/// <summary>
		/// The number of CPUs on this Executor.
		/// </summary>
		public Int32 NumberOfCpu
		{
			get
			{
				return m_numberOfCpu;
			}
			set
			{
				m_numberOfCpu = value;
			}
		}

		/// <summary>
		/// The maximum disk space available on this Executor.
		/// </summary>
		public float MaxDisk
		{
			get
			{
				return m_maxDisk;
			}
			set
			{
				m_maxDisk = value;
			}
		}

		/// <summary>
		/// The maximum memory available on this Executor.
		/// </summary>
		public float MaxMemory
		{
			get
			{
				return m_maxMemory;
			}
			set
			{
				m_maxMemory = value;
			}
		}

		/// <summary>
		/// Executor Id.
		/// </summary>
		public String ExecutorId
		{
			get
			{
				return m_executorId;
			}
			set
			{
				m_executorId = value;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether the Executor is dedicated or not.
		/// </summary>
		public bool Dedicated
		{
			get
			{
				return m_dedicated;
			}
			set
			{
				m_dedicated = value;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether the Executor is connected or not.
		/// </summary>
		public bool Connected
		{
			get
			{
				return m_connected;
			}
			set
			{
				m_connected = value;
			}
		}

		/// <summary>
		/// The last time this Executor was pinged
		/// </summary>
		public DateTime PingTime
		{
			get
			{
				return m_pingTime;
			}
			set
			{
				m_pingTime = value;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the PingTime property is set or not.
		/// </summary>
		public bool PingTimeSet
		{
			get
			{
				return m_pingTime != c_noTimeSet;
			}
		}

		/// <summary>
		/// The Executor's host name.
		/// </summary>
		public String HostName
		{
			get
			{
				return m_hostname;
			}
			set
			{
				m_hostname = value;
			}
		}

		/// <summary>
		/// The Executor's port.
		/// </summary>
		public Int32 Port
		{
			get
			{
				return m_port;
			}
			set
			{
				m_port = value;
			}
		}

		/// <summary>
		/// The Executor's username.
		/// </summary>
		public String Username
		{
			get
			{
				return m_username;
			}
		}

		/// <summary>
		/// The maximum CPU of the Executor.
		/// </summary>
		public Int32 MaxCpu
		{
			get
			{
				return m_maxCpu;
			}
		}

		/// <summary>
		/// The CPU usage for this Executor.
		/// </summary>
		public Int32 CpuUsage
		{
			get
			{
				return m_cpuUsage;
			}
			set
			{
				m_cpuUsage = value;
			}
		}

		/// <summary>
		/// The available CPU power for this Executor.
		/// </summary>
		public Int32 AvailableCpu
		{
			get
			{
				return m_availableCpu;
			}
			set
			{
				m_availableCpu = value;
			}
		}

		/// <summary>
		/// The total CPU usage for this Executor.
		/// </summary>
		public float TotalCpuUsage
		{
			get
			{
				return m_totalCpuUsage;
			}
			set
			{
				m_totalCpuUsage = value;
			}
		}

		#endregion

		/// <summary>
		/// ExecutorStorageView constructor.
		/// </summary>
		/// <param name="dedicated"></param>
		/// <param name="connected"></param>
		/// <param name="pingTime"></param>
		/// <param name="hostname"></param>
		/// <param name="port"></param>
		/// <param name="username"></param>
		/// <param name="maxCpu"></param>
		/// <param name="cpuUsage"></param>
		/// <param name="availableCpu"></param>
		/// <param name="totalCpuUsage"></param>
		public ExecutorStorageView(
				bool dedicated,
				bool connected,
				DateTime pingTime,
				String hostname,
				Int32 port,
				String username,
				Int32 maxCpu,
				Int32 cpuUsage,
				Int32 availableCpu,
				float totalCpuUsage
			) : this(
				null,
				dedicated,
				connected,
				pingTime,
				hostname,
				port,
				username,
				maxCpu,
				cpuUsage,
				availableCpu,
				totalCpuUsage
			)
		{
		}

		/// <summary>
		/// ExecutorStorageView constructor.
		/// </summary>
		/// <param name="executorId"></param>
		/// <param name="dedicated"></param>
		/// <param name="connected"></param>
		/// <param name="hostname"></param>
		/// <param name="port"></param>
		/// <param name="username"></param>
		/// <param name="maxCpu"></param>
		/// <param name="cpuUsage"></param>
		/// <param name="availableCpu"></param>
		/// <param name="totalCpuUsage"></param>
		public ExecutorStorageView(
			String executorId,
			bool dedicated,
			bool connected,
			String hostname,
			Int32 port,
			String username,
			Int32 maxCpu,
			Int32 cpuUsage,
			Int32 availableCpu,
			float totalCpuUsage
			) : this(
			executorId,
			dedicated,
			connected,
			ExecutorStorageView.c_noTimeSet,
			hostname,
			port,
			username,
			maxCpu,
			cpuUsage,
			availableCpu,
			totalCpuUsage
			)
		{
		}

		/// <summary>
		/// ExecutorStorageView constructor.
		/// </summary>
		/// <param name="executorId"></param>
		/// <param name="dedicated"></param>
		/// <param name="connected"></param>
		/// <param name="pingTime"></param>
		/// <param name="hostname"></param>
		/// <param name="port"></param>
		/// <param name="username"></param>
		/// <param name="maxCpu"></param>
		/// <param name="cpuUsage"></param>
		/// <param name="availableCpu"></param>
		/// <param name="totalCpuUsage"></param>
		public ExecutorStorageView(
			String executorId,
			bool dedicated,
			bool connected,
			DateTime pingTime,
			String hostname,
			Int32 port,
			String username,
			Int32 maxCpu,
			Int32 cpuUsage,
			Int32 availableCpu,
			float totalCpuUsage
			) : this(
			executorId,
			dedicated,
			connected,
			pingTime,
			hostname,
			port,
			username,
			maxCpu,
			cpuUsage,
			availableCpu,
			totalCpuUsage,
			0,
			0,
			0,
			"",
			""
			)
		{
		}

		/// <summary>
		/// ExecutorStorageView constructor.
		/// </summary>
		/// <param name="dedicated"></param>
		/// <param name="connected"></param>
		/// <param name="hostname"></param>
		/// <param name="username"></param>
		/// <param name="maxCpu"></param>
		/// <param name="maxMemory"></param>
		/// <param name="maxDisk"></param>
		/// <param name="numberOfCpu"></param>
		/// <param name="os"></param>
		/// <param name="architecture"></param>
		public ExecutorStorageView(
			bool dedicated,
			bool connected,
			String hostname,
			String username,
			Int32 maxCpu,
			float maxMemory,
			float maxDisk,
			Int32 numberOfCpu,
			String os,
			String architecture
			) : this(
			null,
			dedicated,
			connected,
			ExecutorStorageView.c_noTimeSet,
			hostname,
			0,
			username,
			maxCpu,
			0,
			0,
			0,
			maxMemory,
			maxDisk,
			numberOfCpu,
			os,
			architecture
			)
		{
		}

		/// <summary>
		/// ExecutorStorageView constructor.
		/// </summary>
		/// <param name="executorId"></param>
		/// <param name="dedicated"></param>
		/// <param name="connected"></param>
		/// <param name="hostname"></param>
		/// <param name="username"></param>
		/// <param name="maxCpu"></param>
		/// <param name="maxMemory"></param>
		/// <param name="maxDisk"></param>
		/// <param name="numberOfCpu"></param>
		/// <param name="os"></param>
		/// <param name="architecture"></param>
		public ExecutorStorageView(
			string executorId,
			bool dedicated,
			bool connected,
			String hostname,
			String username,
			Int32 maxCpu,
			float maxMemory,
			float maxDisk,
			Int32 numberOfCpu,
			String os,
			String architecture
			) : this(
			executorId,
			dedicated,
			connected,
			ExecutorStorageView.c_noTimeSet,
			hostname,
			0,
			username,
			maxCpu,
			0,
			0,
			0,
			maxMemory,
			maxDisk,
			numberOfCpu,
			os,
			architecture
			)
		{
		}

		/// <summary>
		/// ExecutorStorageView constructor.
		/// </summary>
		/// <param name="executorId"></param>
		/// <param name="dedicated"></param>
		/// <param name="connected"></param>
		/// <param name="pingTime"></param>
		/// <param name="hostname"></param>
		/// <param name="port"></param>
		/// <param name="username"></param>
		/// <param name="maxCpu"></param>
		/// <param name="cpuUsage"></param>
		/// <param name="availableCpu"></param>
		/// <param name="totalCpuUsage"></param>
		/// <param name="maxMemory"></param>
		/// <param name="maxDisk"></param>
		/// <param name="numberOfCpu"></param>
		/// <param name="os"></param>
		/// <param name="architecture"></param>
		public ExecutorStorageView(
			String executorId,
			bool dedicated,
			bool connected,
			DateTime pingTime,
			String hostname,
			Int32 port,
			String username,
			Int32 maxCpu,
			Int32 cpuUsage,
			Int32 availableCpu,
			float totalCpuUsage,
			float maxMemory,
			float maxDisk,
			Int32 numberOfCpu,
			String os,
			String architecture
			)
		{
			m_executorId = executorId;
			m_dedicated = dedicated;
			m_connected = connected;
			m_pingTime = pingTime;
			m_hostname = hostname;
			m_port = port;
			m_username = username;
			m_maxCpu = maxCpu;
			m_cpuUsage = cpuUsage;
			m_availableCpu = availableCpu;
			m_totalCpuUsage = totalCpuUsage;
			MaxMemory =  maxMemory;
			MaxDisk = maxDisk;
			NumberOfCpu = numberOfCpu;
			Os = os;
			Architecture = architecture;
		}
	
	}
}
