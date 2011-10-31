#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	CrossPlatformHelper.cs
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
using System.Xml;
using Alchemi.Core.Owner;
using Alchemi.Core.Utility;

namespace Alchemi.Core
{
	//TODO: include advanced functions here, like reading the xml and giving a list of inputs, outputs and tasks that the job will do.

    /// <summary>
    /// Provides helper methods for working with tasks and jobs on a Manager. This class is used by the X-Platform Manager
    /// and should be used by any client tools providing task/job support.
    /// </summary>
    public class CrossPlatformHelper
    {
		// Create a logger for use in this class
		private static readonly Logger logger = new Logger();

		/// <summary>
		/// Creates an empty task on a Manager and returns its Id.
		/// </summary>
		/// <param name="manager"></param>
		/// <param name="sc">Security Credentials</param>
		/// <returns>application id</returns>
        public static string CreateTask(IManager manager, SecurityCredentials sc)
        {
            return manager.Owner_CreateApplication(sc);
        }
        
        //-----------------------------------------------------------------------------------------------            
        
        /// <summary>
        /// Creates a task on the Manager from the provided XML task representation and returns its Id. 
        /// </summary>
        /// <param name="manager"></param>
		/// <param name="sc">Security Credentials</param>
		/// <param name="taskXml"></param>
        /// <returns>application id</returns>
        public static string CreateTask(IManager manager, SecurityCredentials sc, string taskXml)
        {
            // TODO: validate against schema
            string taskId = manager.Owner_CreateApplication(sc);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(taskXml);
			
            FileDependencyCollection manifest = new FileDependencyCollection();
            foreach (XmlNode manifestFile in doc.SelectNodes("task/manifest/embedded_file"))
            {
            	EmbeddedFileDependency dep = new EmbeddedFileDependency(manifestFile.Attributes["name"].Value);
                dep.Base64EncodedContents = manifestFile.InnerText;
                manifest.Add(dep);
				logger.Debug("Added dependency to manifest: "+dep.FileName);
            }
            manager.Owner_SetApplicationManifest(sc, taskId, manifest);

            foreach (XmlNode jobXml in doc.SelectNodes("task/job"))
            {
                int jobId = int.Parse(jobXml.Attributes["id"].Value);
                jobXml.Attributes.Remove(jobXml.Attributes["id"]);
                
                // TODO: allow setting of priority in xml file
                AddJob(manager, sc, taskId, jobId, 0, jobXml.OuterXml);
				logger.Debug("Added job to manager: "+jobId);
            }

            return taskId;
        }

        //-----------------------------------------------------------------------------------------------            

		/// <summary>
		/// Adds a job to the manager
		/// </summary>
		/// <param name="manager"></param>
		/// <param name="sc">security credentials used to perform this operation</param>
		/// <param name="taskId"></param>
		/// <param name="jobId"></param>
		/// <param name="priority"></param>
		/// <param name="jobXml"></param>
        public static void AddJob(IManager manager, SecurityCredentials sc, string taskId, int jobId, int priority, string jobXml)
        {
            manager.Owner_SetThread(
                sc,
                new ThreadIdentifier(taskId, jobId, priority),
                Utils.SerializeToByteArray(JobFromXml(jobId, jobXml))
                );
        }

        //-----------------------------------------------------------------------------------------------            

		/// <summary>
		/// Gets the status of the given job
		/// </summary>
		/// <param name="manager"></param>
		/// <param name="sc">security credentials used to perform this operation</param>
		/// <param name="taskId"></param>
		/// <param name="jobId"></param>
		/// <returns>job status</returns>
        public static int GetJobState(IManager manager, SecurityCredentials sc, string taskId, int jobId)
        {
            return Convert.ToInt32(manager.Owner_GetThreadState(sc, new ThreadIdentifier(taskId, jobId)));
        }

        //-----------------------------------------------------------------------------------------------            

		/// <summary>
		/// Gets the finished jobs as an xml string
		/// </summary>
		/// <param name="manager"></param>
		/// <param name="sc">security credentials used to perform this operation</param>
		/// <param name="taskId"></param>
		/// <returns>XML string representing the job</returns>
        public static string GetFinishedJobs(IManager manager, SecurityCredentials sc, string taskId)
        {
            byte[][] FinishedThreads = manager.Owner_GetFinishedThreads(sc, taskId);

            XmlStringWriter xsw = new XmlStringWriter();
            xsw.Writer.WriteStartElement("task");
            xsw.Writer.WriteAttributeString("id", taskId);
      
            for (int i=0; i<FinishedThreads.Length; i++)
            {
                GJob job = (GJob) Utils.DeserializeFromByteArray(FinishedThreads[i]);
                xsw.Writer.WriteRaw("\n" + CrossPlatformHelper.XmlFromJob(job) + "\n");
				logger.Debug("Writing thread:"+job.Id);
            }
            xsw.Writer.WriteEndElement(); // close job
      
            return xsw.GetXmlString();
        }

		
		public static int GetApplicationState(IManager manager, SecurityCredentials sc, string taskId)
		{
			return Convert.ToInt32(manager.Owner_GetApplicationState(sc,taskId));
		}

		
		public static void AbortTask(IManager manager, SecurityCredentials sc, string taskId)
		{
			manager.Owner_StopApplication(sc,taskId);
		}

		
		public static void AbortJob(IManager manager, SecurityCredentials sc, ThreadIdentifier ti)
		{
			manager.Owner_AbortThread(sc,ti);
		}

        //-----------------------------------------------------------------------------------------------

		//Gets the GJob object from the given xml
        private static GJob JobFromXml(int jobId, string jobXml)
        {
            // TODO: validate against schema
            GJob job = new GJob();

            job.SetId(jobId);
            
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(jobXml);

			logger.Debug("Getting JobFromXML...");
            foreach (XmlNode inputFile in doc.SelectNodes("job/input/embedded_file"))
            {
                EmbeddedFileDependency dep = new EmbeddedFileDependency(inputFile.Attributes["name"].Value);
                dep.Base64EncodedContents = inputFile.InnerText;
                job.InputFiles.Add(dep);			
				logger.Debug("adding input filedep:"+dep.FileName);
            }

            job.RunCommand = doc.SelectSingleNode("job/work").Attributes["run_command"].Value;

			logger.Debug("Job run command="+job.RunCommand);

            foreach (XmlNode outputFile in doc.SelectNodes("job/output/embedded_file"))
            {
                EmbeddedFileDependency dep = new EmbeddedFileDependency(outputFile.Attributes["name"].Value);
                job.OutputFiles.Add(dep);
				logger.Debug("adding output filedep:"+dep.FileName);
            }

			return job;
        }

     	public static string GetFailedThreadException(IManager manager, SecurityCredentials sc, ThreadIdentifier ti)
    	{
    		return manager.Owner_GetFailedThreadException(sc, ti).ToString();
    	}
		
		//-----------------------------------------------------------------------------------------------    

		//Gets the XML representing a job
        private static string XmlFromJob(GJob job)
        {
            XmlStringWriter xsw = new XmlStringWriter();

            xsw.Writer.WriteStartElement("job");
            xsw.Writer.WriteAttributeString("id", job.Id.ToString());
            xsw.Writer.WriteStartElement("input");
            xsw.Writer.WriteFullEndElement(); // close input
            xsw.Writer.WriteStartElement("work");
            xsw.Writer.WriteFullEndElement(); // close work
            xsw.Writer.WriteStartElement("output");

            foreach (EmbeddedFileDependency fileDep in job.OutputFiles)
            {
                xsw.Writer.WriteStartElement("embedded_file");
                xsw.Writer.WriteAttributeString("name", fileDep.FileName);
                xsw.Writer.WriteString(fileDep.Base64EncodedContents);
                xsw.Writer.WriteFullEndElement(); // close embedded_file element
            }
      
            xsw.Writer.WriteEndElement(); // close output
            xsw.Writer.WriteEndElement(); // close task
      
            return xsw.GetXmlString();
        }

    }
}

