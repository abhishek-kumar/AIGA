#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* 
* Title			:	ExecutorService.cs
* Project		:	Alchemi Executor Service
* Created on	:	July 2005
* Copyright		:	Copyright © 2006 The University of Melbourne
*					This technology has been developed with the support of 
*					the Australian Research Council and the University of Melbourne
*					research grants as part of the Gridbus Project
*					within GRIDS Laboratory at the University of Melbourne, Australia.
* Author         :  Rodrigo Assirati Dias (rdias@ime.usp.br), Paula Akemi Nishimoto (pakemi@gmail.com),
*					Dr. Roberto Hirata Jr. (hirata@ime.usp.br) and Krishna Nadiminti(kna@csse.unimelb.edu.au)
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
using System.IO;
using System.Reflection;
using System.ServiceProcess;
using System.Threading;
using Alchemi.Core;
using Alchemi.Executor;
using Alchemi.Core.Utility;
using log4net;
using log4net.Config;

namespace Alchemi.ExecutorService
{
	public enum ExecutorServiceCustomCommands
	{
		Reload_Config = 1,
		Reconnect = 2,
		Disconnect = 3
	}

	public class ExecutorService : ServiceBase
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		private ExecutorContainer execContainer = null;

		private Thread starterThread = null;

		// Create a logger for use in this class
		private static ILog logger;


		public ExecutorService()
		{
			InitializeComponent();
			execContainer = new ExecutorContainer();
			// subscribe to events
			execContainer.GotDisconnected += new GotDisconnectedEventHandler(this.Executor_GotDisconnected);
		
			Logger.LogHandler += new LogEventHandler(this.Log);
		}

		// The main entry point for the process
		static void Main(string[] args)
		{
			ServiceBase[] ServicesToRun;

			//the unhandled exception handler is set here as opposed to the constructor, since the Main does a lot more things that 
			//can cause errors.
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(DefaultErrorHandler);

			try
			{
				Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
				logger = LogManager.GetLogger(typeof(ExecutorService));
				XmlConfigurator.Configure(new FileInfo(string.Format("{0}.config",Assembly.GetExecutingAssembly ().Location)));

				//create directory and set permissions for dat directory...for logging.
				string datDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"dat");
				ServiceUtil.CreateDir(datDir,"SYSTEM");

				string opt = null ;
				if ( args.Length > 0)
				{
					opt = args [0];
				}

				if (opt != null && opt.ToLower () == "/install")
				{
					installService();
				}
				else if (opt != null && opt.ToLower () == "/uninstall")
				{
					uninstallService();
				}
				else
				{
					// More than one user Service may run within the same process. To add
					// another service to this process, change the following line to
					// create a second service object. For example,
					//
					//   ServicesToRun = new System.ServiceProcess.ServiceBase[] {new Service1(), new MySecondUserService()};
					//

					ExecutorService es = new ExecutorService();
					if (!ServiceHelper.checkServiceInstallation(es.ServiceName))
					{
						installService();
					}

					ServicesToRun = new ServiceBase[] { es };
					ServiceBase.Run(ServicesToRun);
					es = null;
				}
			}
			catch (Exception ex)
			{
				HandleAllUnknownErrors("Error in Main: ",ex);
			}
		}

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new Container();
			this.ServiceName = "Alchemi Executor Service";
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		/// <summary>
		/// Set things in motion so your service can do its work.
		/// </summary>
		protected override void OnStart(string[] args)
		{
			try
			{
				logger.Info("Starting Alchemi Executor Service v."+Utils.AssemblyVersion);
				ThreadStart ts = new ThreadStart(StartContainer);
				starterThread = new Thread(ts);
				starterThread.Start();
				//let the thread continue: for eg: in case the connection is not available, it will keep trying forever.
			}
			catch (Exception e)
			{
				logger.Error("Error Starting Alchemi Executor Service " , e);
			}
		}

		private void StartContainer()
		{
			//the executor service is for dedicated machines only
			try
			{
				//this will cause the ExecutorContainer to read the config from the Alchemi.Executor.config.xml
				execContainer.Start();
				logger.Info("Executor Service Started");
			}
			catch (ThreadAbortException) 
			{
				//abort this thread.
				logger.Info("Aborting starterThread");
			}
			catch (Exception ex1)
			{
				logger.Warn("Exception starting Executor service...Reconnecting...",ex1);
				try
				{
					execContainer.Reconnect();
				}
				catch (ThreadAbortException) 
				{
					//abort this thread.
					logger.Info("Aborting starterThread");
				}
				catch (Exception ex2)
				{
					logger.Error("Error trying to reconnect: ",ex2);
				}
			}
		}

		private void StopContainer()
		{
			try
			{
				if (starterThread!=null && starterThread.IsAlive)
					starterThread.Abort();

				if (execContainer!=null)
					execContainer.Stop();
				else
					logger.Debug("Trying to stop: execContainer was null.");

				logger.Info("Executor Service Stopped");
			}
			catch (Exception ex)
			{
				logger.Error("Error stopping ExecutorService. ", ex);
			}
		}

		private static void DefaultErrorHandler(object sender, UnhandledExceptionEventArgs args)
		{
			Exception ex = (Exception) args.ExceptionObject;
			HandleAllUnknownErrors(sender.ToString(), ex);
		} 

		//just to follow the same model as the windows forms app
		private static void HandleAllUnknownErrors(string sender, Exception ex)
		{
			if (logger!=null)
			{
				logger.Error("Unhandled Exception in Alchemi Executor Service: sender = "+sender, ex);
			}
			else
			{
				try
				{
					TextWriter tw = File.CreateText("alchemiExecutorError.txt");
					tw.WriteLine("Unhandled Error in Alchemi Executor Service. Logger is null. Sender ="+sender);
					tw.WriteLine(ex.ToString());
					tw.Flush();
					tw.Close();
					tw = null;
				}
				catch
				{
					//can't do much more. perhaps throw it? so that atleast the user knows something is wrong?
					//throw new Exception("Unhandled Error in Alchemi Executor Service. Logger is null. Sender ="+sender,e);
				}
			}		
		}

		/// <summary>
		/// This could be used for commands such as "reload config", "(re)connect", "disconnect", any other future use etc.
		/// </summary>
		/// <param name="command"></param>
		protected override void OnCustomCommand(int command)
		{
			base.OnCustomCommand (command);
			try
			{
				switch (command)
				{
					case (int)ExecutorServiceCustomCommands.Reload_Config:
						if (execContainer!=null)
						{
							logger.Debug("Trying to exec custom command : ReadConfig");
							execContainer.ReadConfig(false);
						}
						else
						{
							logger.Debug("Container is null. Not trying to exec custom command : ReadConfig");
						}
						break;
					case (int)ExecutorServiceCustomCommands.Disconnect:
						if (execContainer!=null)
						{
							logger.Debug("Trying to exec custom command : Disconnect");
							execContainer.Disconnect();
						}
						else
						{
							logger.Debug("Container is null. Not trying to exec custom command : Disconnect");
						}
						break;
					case (int)ExecutorServiceCustomCommands.Reconnect:
						if (execContainer!=null)
						{
							logger.Debug("Trying to exec custom command : Reconnect");
							execContainer.Reconnect();
						}
						else
						{
							logger.Debug("Container is null. Not trying to exec custom command : Reconnect");
						}
						break;
				}
			}
			catch (Exception e)
			{
				logger.Debug("Error trying to execute custom command : " + command ,e);
			}
		}

		/// <summary>
		/// Stop this service.
		/// </summary>
		protected override void OnStop()
		{
			try
			{
				logger.Info("Stopping Executor Service...");
				ThreadStart ts = new ThreadStart(StopContainer);
				Thread t = new Thread(ts);
				t.Start();
				t.Join(25000); //in this case we really want things to be stopped within the 25 seconds.
			}
			catch (Exception ex)
			{
				logger.Error("Error Stopping Service " , ex);
			}
		}

		private void Executor_GotDisconnected()
		{
			try
			{
				logger.Info("Got disconnected!");
				if (this.execContainer.Config.Dedicated && this.execContainer.Config.RetryConnect)
				{
					logger.Info("Trying to reconnect.");
					execContainer.Reconnect();					
				}
			}
			catch (Exception ex)
			{
				logger.Error("Error in Executor_GotDisconnected, while reconnecting. ", ex);
			}
		}

		private static void installService()
		{
			string path = string.Format ("/assemblypath={0}",Assembly.GetExecutingAssembly ().Location);
			ServiceHelper.installService(new ProjectInstaller(),path);
		}

		private static void uninstallService()
		{
			string path = string.Format ("/assemblypath={0}", Assembly.GetExecutingAssembly ().Location);
			ServiceHelper.uninstallService(new ProjectInstaller(),path);
		}

		private void Log(object sender, LogEventArgs e)
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
					logger.Warn(e.Message,e.Exception);
					break;
			}
		}
	}
}
