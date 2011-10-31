#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	GJob.cs
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
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Alchemi.Core.Owner
{
	/// <summary>
	/// Represents a coarse unit of work on the grid. This class extends the GThread to enable legacy applications to 
	/// run on the grid. A GJob is associated with file dependencies which are the inputs and outputs of the job
	/// and a compiled binary (the legacy application) which is the work unit of the job.
	/// </summary>
    [Serializable]
    public class GJob : GThread
    {
		private static readonly Logger logger = new Logger();

		private FileDependencyCollection _InputFiles = new FileDependencyCollection();
        private FileDependencyCollection _OutputFiles = new FileDependencyCollection();
        private string _RunCommand;

		//TODO let the user specify what the stdout and stderr are to be called.
		//by default we can call them stdout.txt and stderr.txt

        //-----------------------------------------------------------------------------------------------    

		/// <summary>
		/// Gets the collection of input files for this job
		/// </summary>
        public FileDependencyCollection InputFiles
        {
            get { return _InputFiles; }
        }

		/// <summary>
		/// Gets the collection of output files for this job
		/// </summary>
        public FileDependencyCollection OutputFiles
        {
            get { return _OutputFiles; }
        }

		/// <summary>
		/// Gets or sets the work unit, or the command that is to be executed when this job runs on the executor
		/// </summary>
        public string RunCommand
        {
            get { return _RunCommand; }
            set { _RunCommand = value; }
        }

        //-----------------------------------------------------------------------------------------------    

		/// <summary>
		/// Runs the executable specified in the RunCommand of the GJob. This happens on the executor node.
		/// </summary>
        public override void Start()
        {
            foreach (FileDependency dep in _InputFiles)
            {
                dep.UnPackToFolder(WorkingDirectory);
				logger.Debug("Unpacking input file: " + dep.FileName);
            }
      
			Process process = new Process();
            process.StartInfo.WorkingDirectory = WorkingDirectory;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;

			logger.Debug("Starting a new process...");
            process.StartInfo.FileName = "cmd"; //_RunCommand; //
            process.StartInfo.Arguments = "/C " + _RunCommand;
 
            process.Start();
            process.WaitForExit();
      
            foreach (EmbeddedFileDependency dep in _OutputFiles)
            {
				//handle errors connected to missing output files.
                try
                {
                    dep.Pack(string.Format("{0}\\{1}", WorkingDirectory, dep.FileName));
                    // cleanup
                	File.Delete(string.Format("{0}\\{1}", WorkingDirectory, dep.FileName));
					logger.Debug("Packing output file: "+dep.FileName);
                }
                catch (Exception ex)
                {
                    dep.Base64EncodedContents = "";
					logger.Debug("Error packing outputfile " + dep.FileName + ". Continuing with other files...",ex);
                }
            }

            foreach (FileDependency dep in _InputFiles)
            {
                // cleanup
				try
				{
					File.Delete(string.Format("{0}\\{1}", WorkingDirectory, dep.FileName));
				}
				catch (Exception ex)
				{
					logger.Debug("Error deleting file " + dep.FileName + ". Continuing with other files...",ex);
				}
            }

            AddStandardFile(process.StandardError, "stderr.txt");
            AddStandardFile(process.StandardOutput, "stdout.txt");
			
			logger.Debug("GJob Process complete: "+Id);
        }

        //-----------------------------------------------------------------------------------------------    
    
        private void AddStandardFile(StreamReader reader, string name)
        {
            EmbeddedFileDependency fileDep = new EmbeddedFileDependency(name);
        	UTF8Encoding encoding = new UTF8Encoding();
			fileDep.Base64EncodedContents = Convert.ToBase64String(
                encoding.GetBytes(reader.ReadToEnd())
                );
            _OutputFiles.Add(fileDep);
			logger.Debug("Added/packed output file: " + name);
        }
    }
}
