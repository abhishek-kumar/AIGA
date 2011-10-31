#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	GThread.cs
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
using Alchemi.Core.Owner;

namespace Alchemi.Core.Owner
{
	/// <summary>
	/// Represents a "thread" that can be run on a remote grid node
	/// </summary>
    [Serializable]
    public abstract class GThread : MarshalByRefObject
    {
        //----------------------------------------------------------------------------------------------- 
        // member variables
        //----------------------------------------------------------------------------------------------- 
        
        int _Id = -1;
        bool _Failed = false;

        //eduGRID Addition
        AIMLBot.iBOT _iBot;

        [NonSerialized] GApplication _Application = null; // local
        [NonSerialized] int _Priority = 5; // local
        [NonSerialized] string _WorkingDirectory = ""; // remote

        //----------------------------------------------------------------------------------------------- 
        // properties
        //----------------------------------------------------------------------------------------------- 

		/// <summary>
		/// Gets the id of the grid thread
		/// </summary>
        public int Id
        {
            get { return _Id; }
        }

		/// <summary>
		/// Sets the id of the grid thread
		/// </summary>
		/// <param name="id"></param>
        public void SetId (int id)
        {
            _Id = id;
        }
        public AIMLBot.iBOT getiBOT
        {
            get { return _iBot; }
        }
        public void SetiBOT(AIMLBot.iBOT intelligentBOT)
        {
            _iBot = intelligentBOT;
        }
		/// <summary>
		/// Gets the working directory of the grid thread
		/// </summary>
        protected string WorkingDirectory
        {
            get { return _WorkingDirectory; }
        }

		/// <summary>
		/// Sets the working directory of the grid thread
		/// </summary>
		/// <param name="workingDirectory">the directory name to set as the working directory</param>
        public void SetWorkingDirectory(string workingDirectory)
        {
            _WorkingDirectory = workingDirectory;
        }

		/// <summary>
		/// Sets the thread state to failed
		/// </summary>
		/// <param name="failed">value indicating whether to set the thread to failed</param>
        public void SetFailed(bool failed)
        {
            _Failed = failed;
        }

		/// <summary>
		/// Gets the application to which this grid thread belongs
		/// </summary>
        public GApplication Application
        {
            get { return _Application; }
        }

		/// <summary>
		/// Sets the application to which this grid thread belongs
		/// </summary>
		/// <param name="application"></param>
        public void SetApplication(GApplication application)
        {
            _Application = application;
        }

		/// <summary>
		/// Gets or sets the grid thread priority
		/// </summary>
        public int Priority
        {
            get { return _Priority; }
            set { _Priority = value; }
        }

		/// <summary>
		/// Gets the state of the grid thread
		/// </summary>
        public virtual ThreadState State
        {
            get { return _Application.GetThreadState(this); }
        }

        /*
        public Exception RemoteExecutionException
        {
            get { return _RemoteExecutionException; }
            set { _RemoteExecutionException = value; }
        }
        */

        //----------------------------------------------------------------------------------------------- 
        // public methods
        //----------------------------------------------------------------------------------------------- 

		/// <summary>
		/// Starts the execution of the thread on the remote node.
		/// This method is to be implemented by subclasses to include code 
		/// which is actually executed on the executor.
		/// </summary>
        public abstract void Start();
        
        //-----------------------------------------------------------------------------------------------    

		/// <summary>
		/// Aborts this grid thread
		/// </summary>
        public void Abort()
        {
            _Application.AbortThread(this);
        }

        public string queryresponse(string input)
        {
            return _iBot.Query(input);
        }
    }
}

