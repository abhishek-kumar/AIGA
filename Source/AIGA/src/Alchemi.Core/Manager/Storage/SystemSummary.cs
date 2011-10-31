#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  SystemSummary.cs
* Project       :  Alchemi.Core.Manager.Storage
* Created on    :  30 August 2005
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
	/// Returned by GetSystemSummary.
	/// Contains various information about the application status.
	/// </summary>
	[Serializable]
	public class SystemSummary
	{
		#region "Private variables"
		
		private String m_maxPower;
		private Int32 m_totalExecutors;
		private Int32 m_powerUsage;
		private Int32 m_powerAvailable;
		private String m_powerTotalUsage;
		private Int32 m_unfinishedThreads;
		private Int32 m_unfinishedApps;

		#endregion

		#region "Properties"

		/// <summary>
		/// Maximum power.
		/// </summary>
		public String MaxPower
		{
			get
			{
				return m_maxPower;
			}
		}

		/// <summary>
		/// The total number of Executors.
		/// </summary>
		public Int32 TotalExecutors
		{
			get
			{
				return m_totalExecutors;
			}
		}

		/// <summary>
		/// The power usage.
		/// </summary>
		public Int32 PowerUsage
		{
			get
			{
				return m_powerUsage;
			}
		}

		/// <summary>
		/// The available power.
		/// </summary>
		public Int32 PowerAvailable
		{
			get
			{
				return m_powerAvailable;
			}
		}

		/// <summary>
		/// The total power usage.
		/// </summary>
		public String PowerTotalUsage
		{
			get
			{
				return m_powerTotalUsage;
			}
		}

		/// <summary>
		/// The number of unfinished threads.
		/// </summary>
		public Int32 UnfinishedThreads
		{
			get
			{
				return m_unfinishedThreads;
			}
		}

		/// <summary>
		/// The number of unfinished applications.
		/// </summary>
		public Int32 UnfinishedApps
		{
			get
			{
				return m_unfinishedApps;
			}
		}

		#endregion

		/// <summary>
		/// Create the SystemSummary structure
		/// </summary>
		/// <param name="maxPower"></param>
		/// <param name="totalExecutors"></param>
		/// <param name="powerUsage"></param>
		/// <param name="powerAvailable"></param>
		/// <param name="powerTotalUsage"></param>
		/// <param name="unfinishedApps"></param>
		/// <param name="unfinishedThreads"></param>
		public SystemSummary(
			String maxPower, 
			Int32 totalExecutors, 
			Int32 powerUsage,
			Int32 powerAvailable,
			String powerTotalUsage,
			Int32 unfinishedApps,
			Int32 unfinishedThreads)
		{
			m_maxPower = maxPower;
			m_totalExecutors = totalExecutors;
			m_powerUsage = powerUsage;
			m_powerAvailable = powerAvailable;
			m_powerTotalUsage = powerTotalUsage;
			m_unfinishedApps = unfinishedApps;
			m_unfinishedThreads = unfinishedThreads;
		}
	}
}
