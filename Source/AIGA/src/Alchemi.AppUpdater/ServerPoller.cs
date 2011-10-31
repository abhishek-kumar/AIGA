using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;

namespace Alchemi.Updater
{
	/// <summary>
	/// Summary description for ServerPoller.
	/// </summary>
	public class ServerPoller
	{
		
		private AppUpdater AppMan;
		private Thread PollerThread;

		//**************************************************************
		// InitalPollInterval Property	
		// - Seconds between the first check for new updates
		//**************************************************************
		private int _InitialPollDelay=15;
		[DefaultValue(15)]
		[Description("Seconds between the first check for new updates.")]
		public int InitialPollInterval
		{
			get { return _InitialPollDelay; }
			set { _InitialPollDelay = value; }
		}

		//**************************************************************
		// PollInterval Property	
		// - Seconds between the first check for new updates
		//**************************************************************
		private int _PollInterval=30;
		[DefaultValue(30)]
		[Description("Seconds between each subsequent check for updates.")]
		public int PollInterval
		{
			get { return _PollInterval; }
			set { _PollInterval = value; }
		}

		//**************************************************************
		// AutoStart Property	
		// - If true, automatically starts checking for updates on 
		//   AppUpdater Initialize()
		//**************************************************************
		private bool _AutoStart=false;
		[DefaultValue(false)]
		[Description("Whether or not to automatically start the poll for for updates on startup.")]
		public bool AutoStart
		{
			get { return _AutoStart; }
			set { _AutoStart = value; }
		}

		//**************************************************************
		// DownloadOnDetection Property	
		// - If true, automatically starts the download when an update is detected
		//**************************************************************
		private bool _DownloadOnDetection=false;
		[DefaultValue(false)]
		[Description("Whether or not to automatically start downloading the update when detected.")]
		public bool DownloadOnDetection
		{
			get { return _DownloadOnDetection; }
			set { _DownloadOnDetection = value; }
		}

		//**************************************************************
		// Constructor()	
		//**************************************************************
		public ServerPoller(AppUpdater appMan)
		{
			AppMan = appMan;
		}

		//**************************************************************
		// Start()	
		// - Starts checking for updates
		//**************************************************************
		public void Start()
		{
			if (PollerThread == null) 
				PollerThread = new Thread(new ThreadStart(RunThread));
			else if (!PollerThread.IsAlive)
				PollerThread = new Thread(new ThreadStart(RunThread));

			if (!PollerThread.IsAlive)
				PollerThread.Start();
		}

		//**************************************************************
		// Stop()	
		// - Kills the poller thread and stops checking for updates
		//**************************************************************
		public void Stop()
		{
			if ((PollerThread != null) && (PollerThread.IsAlive)) 
			{
				PollerThread.Abort();
				PollerThread = null;
			}
		}

		//**************************************************************
		// RunThread()	
		//**************************************************************
		public void RunThread()
		{
			int PollRate = InitialPollInterval;

			try {
				while (true) {
					Thread.Sleep(TimeSpan.FromSeconds(PollRate));
					PollRate = PollInterval;

					bool UpdatesAvailable = false;
					try 
					{
						if (AppMan.Manifest.State.Phase == UpdatePhases.Complete)
							UpdatesAvailable = AppMan.CheckForUpdates();
						else
							UpdatesAvailable = false;
					} 
					catch (Exception e) 
					{
						//For whatever reason (perhaps the client is disconnected), 
						//we couldn't access the app on the server to check if an updated app 
						//version is available.  In this case, we want to do nothing
						//& check to see if we can reach the app later
						Debug.WriteLine(e.ToString());
						UpdatesAvailable = false;
					}
					if (UpdatesAvailable) 
					{
						Debug.WriteLine("APPMANAGER:  New update detected.");
						
						//Download & apply the update
						if (DownloadOnDetection)
							AppMan.Downloader.Start();
						
						//The updater runs on it's own thread, so stop the poller thread.
						Stop();
					} 
					else 
					{
						Debug.WriteLine("APPMANAGER:  New update NOT detected.");
					}
				}
			}
			catch(Exception) {
				Debug.WriteLine("APPMANAGER:  The Server Polling thread has stopped.");
			}
		}
	}
}
