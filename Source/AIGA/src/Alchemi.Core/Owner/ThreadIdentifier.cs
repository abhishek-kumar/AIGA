#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	ThreadIdentifier.cs
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
	/// Represents a identifier to uniquely identify a thread across applications
	/// </summary>
    [Serializable]
    public class ThreadIdentifier
    {
        private string _ApplicationId;
        private int _ThreadId;
        private int _Priority;

        public const Int32 DefaultPriority = -1;

        //-----------------------------------------------------------------------------------------------        
    
		/// <summary>
		/// Gets the id of the application to which this thread belongs
		/// </summary>
        public string ApplicationId
        {
            get { return _ApplicationId; }
        }
    
		/// <summary>
		/// Gets the thread id
		/// </summary>
        public int ThreadId
        {
            get { return _ThreadId; }
        }

		/// <summary>
		/// Gets the priority of the thread
		/// </summary>
        public int Priority
        {
            get { return _Priority; }
        }
    
        //-----------------------------------------------------------------------------------------------    

		/// <summary>
		/// Creates an instance of the ThreadIdentifier
		/// </summary>
		/// <param name="applicationId"></param>
		/// <param name="threadId"></param>
        public ThreadIdentifier(string applicationId, int threadId)
        {
            _ApplicationId = applicationId;
            _ThreadId = threadId;
            _Priority = DefaultPriority;
        }

		/// <summary>
		/// Creates an instance of the ThreadIdentifier
		/// </summary>
		/// <param name="applicationId"></param>
		/// <param name="threadId"></param>
		/// <param name="priority"></param>
        public ThreadIdentifier(string applicationId, int threadId, int priority)
        {
            _ApplicationId = applicationId;
            _ThreadId = threadId;
            _Priority = priority;
        }
    }
}