#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	CrossPlatformManager.cs
* Project		:	Alchemi CrossPlatform Manager Webservice
* Created on	:	2003
* Copyright		:	Copyright © 2005 The University of Melbourne
*					This technology has been developed with the support of 
*					the Australian Research Council and the University of Melbourne
*					research grants as part of the Gridbus Project
*					within GRIDS Laboratory at the University of Melbourne, Australia.
* Author         :  Akshay Luther (akshayl@cs.mu.oz.au), Rajkumar Buyya (raj@cs.mu.oz.au) and Krishna Nadiminti (kna@cs.mu.oz.au) 
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
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.Web;
using System.Web.Services;

using Alchemi.Core;
using Alchemi.Core.Owner;

using log4net;

namespace Alchemi.CrossPlatformManager
{
    [WebService(Namespace="http://www.alchemi.net")]
    public class CrossPlatformManager : WebService, ICrossPlatformManager
    {
        #region Component Designer generated code
		
        //Required by the Web Services Designer 
        private IContainer components = null;
				
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if(disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);		
        }
		
        #endregion

        private IManager Manager;

		// Create a logger for use in this class
		private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    
        //-----------------------------------------------------------------------------------------------          
    
        public CrossPlatformManager()
        {
            Manager = (IManager) Activator.GetObject(
                typeof(IManager),
                ConfigurationSettings.AppSettings["ManagerUri"]
                );

            InitializeComponent();

			Logger.LogHandler += new LogEventHandler(LogHandler);
        }

        //-----------------------------------------------------------------------------------------------          

        [WebMethod]
        public string CreateTask(string username, string password)
        {
            return CrossPlatformHelper.CreateTask(Manager, new SecurityCredentials(username, password));
        }
        
        //-----------------------------------------------------------------------------------------------                       
        
        [WebMethod]
        public string SubmitTask(string username, string password, string taskXml)
        {
			//decode base64
			//taskXml = Convert.FromBase64String(taskXml).ToString();
			//Html decode the xml
			taskXml = HttpUtility.HtmlDecode(taskXml);

			logger.Debug("Task XML recvd = " + taskXml);
			string temp = null;
			try
			{
				temp = CrossPlatformHelper.CreateTask(Manager, new SecurityCredentials(username, password), taskXml);
			}
			catch (Exception e)
			{
				logger.Error("Error Submitting task...",e);
			}
			return temp;
        }
        
        //-----------------------------------------------------------------------------------------------       
        
        [WebMethod]
        public void AddJob(string username, string password, string taskId, int jobId, int priority, string jobXml)
        {
			//decode base64
			//jobXml = Convert.FromBase64String(jobXml).ToString();
			//Html decode the xml
			jobXml = HttpUtility.HtmlDecode(jobXml);

            CrossPlatformHelper.AddJob(Manager, new SecurityCredentials(username, password), taskId, jobId, priority, jobXml);
        }

        //-----------------------------------------------------------------------------------------------       
    
        [WebMethod]
        public string GetFinishedJobs(string username, string password, string taskId)
        {
            return CrossPlatformHelper.GetFinishedJobs(Manager, new SecurityCredentials(username, password), taskId);
        }
    
        //-----------------------------------------------------------------------------------------------       

        [WebMethod]
        public int GetJobState(string username, string password, string taskId, int jobId)
        {
            return CrossPlatformHelper.GetJobState(Manager, new SecurityCredentials(username, password), taskId, jobId);
        }

        //-----------------------------------------------------------------------------------------------       

        [WebMethod]
        public void Ping()
        {
            Manager.PingManager();
        }
        
        //-----------------------------------------------------------------------------------------------       
        
        /*[WebMethod]
        public DataSet ListLiveApps()
        {
            return null;
        }
		*/

		[WebMethod]
		public int GetApplicationState(string username, string password, string taskId)
		{
			return CrossPlatformHelper.GetApplicationState(Manager, new SecurityCredentials(username,password), taskId);
		}

		[WebMethod]
		public void AbortTask(string username, string password, string taskId)
		{
			CrossPlatformHelper.AbortTask(Manager,new SecurityCredentials(username,password),taskId);
		}

		[WebMethod]
		public void AbortJob(string username, string password, string taskId, int jobId)
		{
			CrossPlatformHelper.AbortJob(Manager,new SecurityCredentials(username,password),new ThreadIdentifier(taskId,jobId));
		}

		[WebMethod]
		public string GetFailedJobException(string username, string password, string taskId, int jobId)
		{
			return CrossPlatformHelper.GetFailedThreadException(Manager,new SecurityCredentials(username,password),new ThreadIdentifier(taskId,jobId));
		}

		//-------------- used for logging and debugging
		private void LogHandler(object sender, LogEventArgs e)
		{
			switch (e.Level)
			{
				case LogLevel.Debug:
					string message = e.Source  + ":" + e.Member + " - " + e.Message;
					logger.Debug(message,e.Exception);
					break;
				case LogLevel.Info:
					logger.Info(e.Message);
					break;
				case LogLevel.Error:
					logger.Error(e.Message,e.Exception);
					break;
				case LogLevel.Warn:
					logger.Warn(e.Message);
					break;
			}
		}

    }
}
