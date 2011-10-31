#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	ManagerService.cs
* Project		:	Alchemi Manager Service
* Created on	:	August 2005
* Copyright		:	Copyright © 2006 The University of Melbourne
*					This technology has been developed with the support of 
*					the Australian Research Council and the University of Melbourne
*					research grants as part of the Gridbus Project
*					within GRIDS Laboratory at the University of Melbourne, Australia.
* Author         :  Krishna Nadiminti (kna@csse.unimelb.edu.au) and Rajkumar Buyya (raj@csse.unimelb.edu.au)
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
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.ServiceProcess;
using System.Threading;
using Alchemi.Core;
using Alchemi.Core.Manager;
using Alchemi.Core.Utility;
using Alchemi.Manager;
using log4net;
using log4net.Config;

namespace Alchemi.ManagerService
{
	public class ManagerService : ServiceBase
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		private ManagerContainer _container = null;

		// Create a logger for use in this class
		private static ILog logger;

		public ManagerService()
		{
			// This call is required by the Windows.Forms Component Designer.
			InitializeComponent();
			try
			{
				_container = new  ManagerContainer();
				_container.RemotingConfigFile = "Alchemi.ManagerService.exe.config";

				Logger.LogHandler += new LogEventHandler(this.Log);
			}
			catch (Exception ex)
			{
				HandleAllUnknownErrors(null,ex);
			}
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
				string configFilePath = string.Format("{0}.config",Assembly.GetExecutingAssembly ().Location);

				logger = LogManager.GetLogger(typeof(ManagerService));
				XmlConfigurator.Configure(new FileInfo(configFilePath));
				Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;

				//create directory and set permissions for dat directory...for logging.
				string datDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"dat");
				Alchemi.Core.Utility.ServiceUtil.CreateDir(datDir,"SYSTEM");

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

					ManagerService ms = new ManagerService();
					if (!ServiceHelper.checkServiceInstallation(ms.ServiceName))
					{
						installService();
					}

					ServicesToRun = new ServiceBase[] { ms };
					ServiceBase.Run(ServicesToRun);
					ms = null;
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
			this.ServiceName = "Alchemi Manager Service";
			this.AutoLog = true;
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
				logger.Info("Starting Alchemi Manager Service: v."+Utils.AssemblyVersion);
				ThreadStart ts = new ThreadStart(StartContainer);
				Thread t = new Thread(ts);
				t.Start();
			}
			catch (Exception e)
			{
				logger.Error("Error Starting Service: ",e);
			}
		}

		private static void DefaultErrorHandler(object sender, UnhandledExceptionEventArgs args)
		{
			Exception e = (Exception) args.ExceptionObject;
			HandleAllUnknownErrors(sender.ToString(),e);
		}

		//just to follow the same model as the manager windows forms app
		private static void HandleAllUnknownErrors(string sender, Exception e)
		{
			if (logger!=null)
			{
				logger.Error("Unhandled Exception in Alchemi Manager Service: sender = "+sender,e);
			}
			else
			{
				try
				{
					TextWriter tw = File.CreateText("alchemiManagerError.txt");
					tw.WriteLine("Unhandled Error in Alchemi Manager Service. Logger is null. Sender ="+sender);
					tw.WriteLine(e.ToString());
					tw.Flush();
					tw.Close();
					tw = null;
				}
				catch
				{
					//can't do much more. perhaps throw it? so that atleast the user knows something is wrong?
					//throw new Exception("Unhandled Error in Alchemi Manager Service. Logger is null. Sender ="+sender,e);
				}
			}
		}

		/// <summary>
		/// Stop this service.
		/// </summary>
		protected override void OnStop()
		{
			try
			{
				ThreadStart ts = new ThreadStart(StopContainer);
				Thread t = new Thread(ts);
				t.Start();
			}
			catch (Exception e)
			{
				logger.Error("Error Stopping Alchemi Manager Service " , e);
			}
		}

		private void StartContainer()
		{
			try
			{
				_container.Start();
			}
			catch (Exception ex)
			{
				logger.Error("Error starting manager container",ex);
				StopContainer();
			}
		}

		private void StopContainer()
		{
			try
			{
				if (_container!=null)
					_container.Stop();	

				logger.Info("Stopped Alchemi Manager Service.");
			}
			catch (Exception ex)
			{
				logger.Error("Error stopping manager container",ex);
			}
			finally 
			{
				_container = null;
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
					logger.Warn(e.Message, e.Exception);
					break;
			}
		}
	}
}
