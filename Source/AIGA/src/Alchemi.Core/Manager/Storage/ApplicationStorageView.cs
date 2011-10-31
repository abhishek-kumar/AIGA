#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  ApplicationStorageView.cs
* Project       :  Alchemi.Core.Manager.Storage
* Created on    :  19 October 2005
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

using Alchemi.Core.Owner;

namespace Alchemi.Core.Manager.Storage
{
	/// <summary>
	/// Storage view of an application object. 
	/// Used to pass application related data to and from the storage layer.
	/// </summary>
	[Serializable]
	public class ApplicationStorageView
	{
		private const Int32 c_valueNotSet = Int32.MaxValue;
		private static DateTime c_noDateTime = DateTime.MinValue;

		#region "Private variables"
		
		private String m_applicationId;
		private ApplicationState m_state;
		private DateTime m_timeCreated;
		private bool m_primary;
		private String m_username;
		private String m_appName;
		private DateTime m_timeCompleted;

		// these values are set by calculating the number of threads in various states
		private Int32 m_totalThreads = c_valueNotSet;
		private Int32 m_unfinishedThreads = c_valueNotSet;

		#endregion

		#region "Properties"

		/// <summary>
		/// The application name.
		/// </summary>
		public String ApplicationName
		{
			get
			{
                if (m_appName != null && m_appName.Length > 0)
                {
                    return m_appName;
                }
                else
                {
                    return String.Format("Noname: [{0}]", ApplicationId);
                }
			}
			set
			{
				m_appName = value;
			}
		}

		/// <summary>
		/// The Application Id.
		/// </summary>
		public String ApplicationId
		{
			get
			{
				return m_applicationId;
			}
			set
			{
				m_applicationId = value;
			}
		}

		/// <summary>
		/// The Application state.
		/// <seealso cref="ApplicationState"/>
		/// </summary>
		public ApplicationState State
		{
			get
			{
				return m_state;
			}
			set
			{
				m_state = value;
			}
		}

		/// <summary>
		/// The time the application was created.
		/// </summary>
		public DateTime TimeCreated
		{
			get
			{
				return m_timeCreated;
			}
		}

		/// <summary>
		/// The time the application was completed.
		/// </summary>
		public DateTime TimeCompleted
		{
			get
			{
				return m_timeCompleted;
			}
			set
			{
				m_timeCompleted = value;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the TimeCreated property is set or not.
		/// <seealso cref="TimeCreated"/>
		/// </summary>
		public bool TimeCreatedSet
		{
			get
			{
				return m_timeCreated != c_noDateTime;
			}
		}

        /// <summary>
        /// Gets a value indicating whether the TimeCompleted property is set or not.
        /// <seealso cref="TimeCompleted"/>
        /// </summary>
        public bool TimeCompletedSet
        {
            get 
            {
                return m_timeCompleted != c_noDateTime;
            }
        }

		/// <summary>
		/// Gets a value indicating whether this is the primary application.
		/// </summary>
		public bool Primary
		{
			get
			{
				return m_primary;
			}
		}

		/// <summary>
		/// The user that created this application.
		/// </summary>
		public String Username
		{
			get
			{
				return m_username;
			}
		}

		/// <summary>
		/// The total thread count for this application.
		/// </summary>
		public Int32 TotalThreads
		{
			get
			{
				if (m_totalThreads == c_valueNotSet)
				{
					throw new Exception("The total thread value is not set for this application object.");
				}

				return m_totalThreads;
			}
			set
			{
				m_totalThreads = value;
			}
		}

		/// <summary>
		/// The unfinished thread count for this application.
		/// </summary>
		public Int32 UnfinishedThreads
		{
			get
			{
				if (m_unfinishedThreads == c_valueNotSet)
				{
					throw new Exception("The unfinished thread value is not set for this application object.");
				}

				return m_unfinishedThreads;
			}
			set
			{
				m_unfinishedThreads = value;
			}
		}

		#endregion

		/// <summary>
		/// ApplicationStorageView constructor.
		/// </summary>
		/// <param name="state"></param>
		/// <param name="timeCreated"></param>
		/// <param name="primary"></param>
		/// <param name="username"></param>
		public ApplicationStorageView(
				ApplicationState state,
				DateTime timeCreated,
				bool primary,
				String username
			) : this (
				null,
				state,
				timeCreated,
				primary,
				username
			)
		{
		
		}

		/// <summary>
		/// ApplicationStorageView constructor.
		/// </summary>
		/// <param name="applicationId"></param>
		/// <param name="state"></param>
		/// <param name="timeCreated"></param>
		/// <param name="primary"></param>
		/// <param name="username"></param>
		public ApplicationStorageView(
				String applicationId,
				ApplicationState state,
				DateTime timeCreated,
				bool primary,
				String username
		)
		{
			m_applicationId = applicationId;
			m_state = state;
			m_timeCreated = timeCreated;
			m_primary = primary;
			m_username = username;
		}

		/// <summary>
		/// ApplicationStorageView constructor.
		/// Initialize an application with only a username supplied.
		/// </summary>
		/// <param name="username"></param>
		public ApplicationStorageView(
				String username
			) : this (
				null,
				ApplicationState.Stopped,
                c_noDateTime,
				true,
				username
			)
		{
		
		}

		/// <summary>
		/// Gets a human readable description of the ApplicationState property.
		/// <seealso cref="ApplicationState"/>
		/// </summary>
		public string StateString
		{
			get
			{
				string state = "";
				switch (this.State)
				{
					case ApplicationState.AwaitingManifest:
						state = "Awaiting Manifest";
						break;
					case ApplicationState.Ready:
						state = "Running";
						break;
					case ApplicationState.Stopped:
						state = "Finished";
						break;
				}
				return state;
			}
		}

	}
}
