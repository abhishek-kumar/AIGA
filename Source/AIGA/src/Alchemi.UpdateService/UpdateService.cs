using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.ServiceProcess;
using Alchemi.Core.Utility;
using log4net;
using log4net.Config;

namespace Alchemi.Updater
{
	public class UpdateService : ServiceBase
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		// Create a logger for use in this class
		private static ILog logger;

		//updater stuff
		private AppUpdater updater = null;
		private ServiceUpdaterConfig config = null;
		string configFile = null;

		//this is the full name and path of the service exe that is using this updater.
		private string currentServiceExePath = null;

		/* This service should handle automatic updates and restart of application(s) in both application, service modes.
		 * It should be able to detect all the installed Alchemi apps, and update them all.
		 * It should be able to handle manual update mode, and by default do auto-update.
		 * 
		 * In service mode, just restart the service(s) once the update download is done.
		 * In app mode, 
		 *		it should list the Alchemi processes, and restart them if they are just updated.
		 *		it should wait for process exit and restart it.
		 * 
		 */

		public UpdateService()
		{
			// This call is required by the Windows.Forms Component Designer.
			InitializeComponent();

			configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"AppStart.config");
			config = ServiceUpdaterConfig.getUpdaterConfig(configFile);
			logger.Debug("Config file="+configFile+", AppFolderName="+config.AppFolderName);
			//config.SaveConfig(configFile+".1");
			currentServiceExePath = config.AppExePath;
			// 
			// updater
			// 
			updater = new AppUpdater();
			updater.ShowDefaultUI = false;
			updater.UpdateUrl = config.UpdateURL;
			updater.ChangeDetectionMode = ChangeDetectionModes.ServerManifestCheck;
			updater.AutoFileLoad = false;

			if (updater.Downloader!=null)
			{
				updater.Downloader.ValidateAssemblies = false;
			}
				
			if (updater.Poller!=null)
			{
				updater.Poller.AutoStart = config.AutoUpdate;
				updater.Poller.DownloadOnDetection = true;
				updater.Poller.InitialPollInterval = config.UpdateInterval;
				updater.Poller.PollInterval = config.UpdateInterval;
			}
			else
			{
				logger.Debug("Poller is null");
			}

			updater.OnUpdateDetected += new AppUpdater.UpdateDetectedEventHandler(this.updater_OnUpdateDetected);
			updater.OnUpdateComplete += new AppUpdater.UpdateCompleteEventHandler(this.updater_OnUpdateComplete);

			updater.Initialize();

			config.SaveConfig(configFile);
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
				logger = LogManager.GetLogger(typeof(UpdateService));
				XmlConfigurator.Configure(new FileInfo(string.Format("{0}.config",Assembly.GetExecutingAssembly ().Location)));

				//create directory and set permissions for dat directory...for logging.
				string datDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"dat");
				ServiceUtil.CreateDir(datDir,"SYSTEM");

				string opt = null ;
				if (args.Length > 0)
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

					UpdateService us = new UpdateService();
					if (!ServiceHelper.checkServiceInstallation(us.ServiceName))
					{
						installService();
					}

					ServicesToRun = new ServiceBase[] { us };
					ServiceBase.Run(ServicesToRun);
					us = null;
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
			this.ServiceName = "Alchemi Updater Service";
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
			//start the updater thread.to check for updates of the specified app/service 
			updater.StartUpdateChecking();
		}
 
		/// <summary>
		/// Stop this service.
		/// </summary>
		protected override void OnStop()
		{
			updater.StopUpdating();
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

		private static void DefaultErrorHandler(object sender, UnhandledExceptionEventArgs args)
		{
			Exception e = (Exception) args.ExceptionObject;
			HandleAllUnknownErrors(sender.ToString(),e);
		}

		//just to follow the same model as the windows forms app
		private static void HandleAllUnknownErrors(string sender, Exception e)
		{
			if (logger!=null)
			{
				logger.Error("Unhandled Exception in Alchemi Updater Service: sender = "+sender,e);
			}
			else
			{
				try
				{
					TextWriter tw = File.CreateText("alchemiUpdaterError.txt");
					tw.WriteLine("Unhandled Error in Alchemi Updater Service. Logger is null. Sender ="+sender);
					tw.WriteLine(e.ToString());
					tw.Flush();
					tw.Close();
					tw = null;
				}
				catch
				{
					//can't do much more. perhaps throw it? so that atleast the user knows something is wrong?
					//throw new Exception("Unhandled Error in Alchemi Updater Service. Logger is null. Sender ="+sender,e);
				}
			}		
		}

		private void handleUpdaterError(string msg, Exception ex)
		{
			logger.Error("Error Updating application: " + msg,ex) ;	
		}

		#region "Updater Events"

		//**************************************************************
		// This event if fired whenever a new update is detected.
		// The default behavior is to start the update download immediately.
		//**************************************************************
		public void updater_OnUpdateDetected(object sender, UpdateDetectedEventArgs e)
		{
			if (e.UpdateDetected)
			{
				logger.Info("Alchemi updater: Found new updates. Downloading...");
			}
			else
			{
				logger.Info("Alchemi updater: No new updates.");
			}
		}

		//**************************************************************
		// This event if fired whenever a new update is complete.
		// shutdown the app
		//**************************************************************		
		public void updater_OnUpdateComplete(object sender, UpdateCompleteEventArgs e)
		{
			string serviceName = null;
			//If the udpate succeeded...
			if (e.UpdateSucceeded)
			{
				logger.Info("Update succeeded.");
				//need to restart the service.
				//for now, this works only for ONE service.

				//refresh the config.
				config = ServiceUpdaterConfig.getUpdaterConfig(configFile);

				if (config.ClientMode == UpdaterClientMode.Service)
				{
					if (config.ClientType == UpdaterClientType.Executor)
					{
						serviceName = "Alchemi Executor Service";
					}
					else if (config.ClientType == UpdaterClientType.Manager)
					{
						serviceName = "Alchemi Manager Service";
					}
					if (serviceName!=null)
					{
						try
						{
							ServiceController sc = new ServiceController(serviceName);
							sc.Refresh();
							if (sc.CanStop)
							{
								sc.Stop();
								sc.WaitForStatus(ServiceControllerStatus.Stopped);
								
							}
							sc = null;
							logger.Info("Stopped service: "+serviceName);

							//need to uninstall the old one, install-&-start the new one. 
							//uninstall here can only be done using the cmd-line since we dont have the ProjectInstaller object with us.
							
							//first uninstall the old one.
							Process pOld = new Process();
							pOld.StartInfo = new ProcessStartInfo(currentServiceExePath ," /uninstall"); //using old service exe path
							pOld.Start();
							logger.Info("Uninstall Process started : "+pOld.StartInfo.ToString());
							pOld.WaitForExit();
							pOld = null;

							Process pNew = new Process();
							pNew.StartInfo = new ProcessStartInfo(config.AppExePath ," /install"); //using new service exe path
							pNew.Start();
							logger.Info("Re-install Process started : "+pNew.StartInfo.ToString());
							pNew.WaitForExit();
							pNew = null;

							//now get the service controller again and try to start the service.
							sc = new ServiceController(serviceName);
							sc.Refresh();
							sc.Start();
							sc.WaitForStatus(ServiceControllerStatus.Running);
							sc = null;
						}
						catch (Exception ex)
						{
							handleUpdaterError("Error updating/restarting: "+ serviceName,ex);
						}
						
					}
				}
				else
				{
					//currently we dont support updating an exec mode client.
					logger.Info("Updater service currently doesnt support App mode. It can update services only.");
				}
			} 
			else //If the update failed....
			{
				handleUpdaterError(e.ErrorMessage,e.FailureException);
			}
		}

		#endregion

	}
}
