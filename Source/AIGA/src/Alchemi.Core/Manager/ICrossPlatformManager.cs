#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	ICrossPlatformManager.cs
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

namespace Alchemi.Core
{
	/// <summary>
	/// Defines the functions to be provided by a cross-platform webservices manager
	/// </summary>
    public interface ICrossPlatformManager
    {
		/// <summary>
		/// 
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <returns></returns>
        string /* taskId */ CreateTask(string username, string password);
        
		/// <summary>
		/// 
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <param name="taskXml"></param>
		/// <returns></returns>
		string /* taskId */ SubmitTask(string username, string password, string taskXml);
        
		/// <summary>
		/// Add a job to the manager with the given credentials, task and jobID, priority and XML description
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <param name="taskId"></param>
		/// <param name="jobId"></param>
		/// <param name="priority"></param>
		/// <param name="jobXml"></param>
		void AddJob(string username, string password, string taskId, int jobId, int priority, string jobXml);
        
		/// <summary>
		/// Gets the XML description of the finished jobs for the given application/task id
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <param name="taskId">task / application id</param>
		/// <returns></returns>
		string /* taskXml */ GetFinishedJobs(string username, string password, string taskId);
        
		/// <summary>
		/// Gets the status of the job with the given id and task/application id.
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <param name="taskId">application / task id</param>
		/// <param name="jobId"></param>
		/// <returns></returns>
		int GetJobState(string username, string password, string taskId, int jobId);
    }
}
