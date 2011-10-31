using System;
using System.Net;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.ComponentModel;
using Alchemi.AppStart;

namespace Alchemi.Updater
{
	public enum ChangeDetectionModes:int {DirectFileCheck=1, ServerManifestCheck=2};

	//**************************************************************
	// AppUpdater Class
	// - This is the main AppUpdater object
	//**************************************************************
	public class AppUpdater: Component, ISupportInitialize
	{	
		public const int RestartAppReturnValue = 2; 

		private System.ComponentModel.Container components = null;

		//Used to prevent event recursion in OnAssemblyResolve
		private bool LoadingAssembly; 
		private Control EventControl;
		
		internal AppManifest Manifest;

		//Handles downloading & applying the update
		private AppDownloader _Downloader;
		[TypeConverter(typeof(ExpandableObjectConverter))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("The object that downloads and installs new updates."), 
		Category("AppUpdate Configuration")]
		public AppDownloader Downloader		
		{
			get	{return _Downloader;}
			set {_Downloader=value;}
		}
	
		//Triggers update checks
		private ServerPoller _Poller;
		[TypeConverter(typeof(ExpandableObjectConverter))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("The object that periodically polls for new updates."), 
		Category("AppUpdate Configuration")]
		public ServerPoller Poller
		{
			get	{return _Poller;}
			set {_Poller=value;}
		}

		//Instructs the updater where to check & subsequently download updates
		private string _UpdateUrl = "http://localhost/";
		[DefaultValue(@"http://localhost/")]
		[Description("The Url to download updates from."), 
		Category("AppUpdate Configuration")]
		public string UpdateUrl
		{
			get {return _UpdateUrl;}
			set {_UpdateUrl = value;}
		}

		public string NewVersionDirectory()
		{
			return Manifest.State.NewVersionDirectory;
		}

		//Indicates the mechanism to check for updates
		private ChangeDetectionModes _ChangeDetectionMode = ChangeDetectionModes.DirectFileCheck;
		[DefaultValue(ChangeDetectionModes.DirectFileCheck)]
		[Description("The way to detect new updates."), 
		Category("AppUpdate Configuration")]
		public ChangeDetectionModes ChangeDetectionMode
		{
			get {return _ChangeDetectionMode;}
			set {_ChangeDetectionMode = value;}
		}

		//Indicates whether the udpater should put up it's default UI
		private bool _ShowDefaultUI = false;
		[DefaultValue(false)]
		[Description("Determines whether the default UI is shown or supressed."), 
		Category("AppUpdate Configuration")]
		public bool ShowDefaultUI
		{
			get {return _ShowDefaultUI;}
			set {_ShowDefaultUI = value;}
		}

		//Whether the updater should try to automatically download missing files
		private bool _AutoFileLoad = false;
		[DefaultValue(false)]
		[Description("Enables auto-download of missing assemblies."), 
		Category("AppUpdate Configuration")]
		public bool AutoFileLoad
		{
			get {return _AutoFileLoad;}
			set {_AutoFileLoad = value;}
		}

		//**************************************************************
		// OnCheckForUpdate Event
		// This event is called everytime the appupdater attempts to check for 
		// an update.  You can hook this event and perform your own update check.
		// Return a boolean value indicating whether an update was found.  
		// Notes:  
		//   * This event fires on the poller thread, so you can make network requests 
		//     to check for updates & it will be done asyncronously.
		//   * Because this event has a non void return value, it can only
		//     be handled by one event handler.  It can not be multi-cast.
		//**************************************************************
		public delegate bool CheckForUpdateEventHandler(object sender, EventArgs e);
		public event CheckForUpdateEventHandler OnCheckForUpdate;

		//**************************************************************
		// UpdateDetected Event
		// - Fired when a new udpate is detected.
		// - Fired on the UI thread.
		//**************************************************************
		public delegate void UpdateDetectedEventHandler(object sender, UpdateDetectedEventArgs e);
		public event UpdateDetectedEventHandler OnUpdateDetected;

		//**************************************************************
		// UpdateComplete Event
		// - Fired when an update is complete.  
		// - Fired on the UI thread.
		//**************************************************************
		public delegate void UpdateCompleteEventHandler(object sender, UpdateCompleteEventArgs e);
		public event UpdateCompleteEventHandler OnUpdateComplete;

		//**************************************************************
		// DownloadProgress Event
		// - Fired when an download progress changes.  
		// - Fired on the UI thread.
		//**************************************************************
		public delegate void DownloadProgressEventHandler(object sender, DownloadProgressEventArgs e);
		public event DownloadProgressEventHandler OnDownloadProgress;

		//**************************************************************
		// Constructor()
		// If you use this contrusctor, be sure to call Initialize() after
		// you set all of the properties.  
		//**************************************************************
		public AppUpdater()
		{ 
			Poller = new ServerPoller(this);
			Downloader = new AppDownloader(this);
		}

		//**************************************************************
		// Constructor()
		// - Design time constructor
		//**************************************************************
		public AppUpdater(System.ComponentModel.IContainer container)
		{
			Poller = new ServerPoller(this);
			Downloader = new AppDownloader(this);

			container.Add(this);
			InitializeComponent();
		}

		//**************************************************************
		// Constructor()
		// - If you use this contructor, no need to call initialize
		//**************************************************************
		public AppUpdater(string updateUrl,
						ChangeDetectionModes changeDetectionMode,
						bool showDefaultUI,
						bool autoFileLoad,
						bool validateAssemblies)
		{	
			//Load the Poller & Updater 
			Poller = new ServerPoller(this);
			Downloader = new AppDownloader(this);

			UpdateUrl = updateUrl;
			ChangeDetectionMode = changeDetectionMode;
			ShowDefaultUI = showDefaultUI;
			AutoFileLoad = autoFileLoad;
			Downloader.ValidateAssemblies = validateAssemblies;

			Initialize();
		}

		//**************************************************************
		// BeginInit()
		//**************************************************************
		public void BeginInit()
		{
		}

		//**************************************************************
		// EndInit()
		// - Called by designer generated code, after designer generated 
		//   code has set all properites
		//**************************************************************
		public void EndInit()
		{
			if (!this.DesignMode)
				Initialize();
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		//**************************************************************
		// Initialize()	
		// - Sets up the updater, generates the default manifest, 
		//   starts the threads, etc...
		//**************************************************************
		public void Initialize()
		{
			//Load the Manifest Config File
			string AppManifestPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\"; 
			string AppManifestName = Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location);
			AppManifestName += ".xml";
			AppManifestPath = Path.Combine(AppManifestPath,AppManifestName);
			Manifest = AppManifest.Load(AppManifestPath);

			if (ChangeDetectionMode == ChangeDetectionModes.DirectFileCheck)
				EnableManifestGeneration();

			if (AutoFileLoad == true)
				EnableFileAutoLoad();

			if (Poller.AutoStart == true)
				Poller.Start();

			Downloader.OnDownloadProgress += new Alchemi.Updater.AppDownloader.DownloadProgressEventHandler(Downloader_OnDownloadProgress);
			Downloader.OnUpdateComplete += new Alchemi.Updater.AppDownloader.UpdateCompleteEventHandler(Downloader_OnUpdateComplete);
			Application.ApplicationExit += new EventHandler(OnApplicationExit);

			EventControl = new Control();
			//Access the control handle to make sure it's bound to this thread
			IntPtr h = EventControl.Handle;

			//If an update was in progress when the app was shut down, 
			//continue the download now that the app has restarted.
			if (Manifest.State.Phase != UpdatePhases.Complete)
			{
				Debug.WriteLine("APPMANAGER:  Continuing update already in progress");
				Downloader.Start();
			}
		}

		//**************************************************************
		// DownloadUpdate()	
		// - Starts downloading an update from the location specified at
		//   UpdateUrl.  The udpate itself is done async.
		//**************************************************************
		public void DownloadUpdate()
		{
			Downloader.Start();
		}

		public void StartUpdateChecking()
		{
			if (Poller != null)
				Poller.Start();
		}
		
		//**************************************************************
		// CheckForUpdates()	
		// - Checks for an update 
		// - This is a sync call... normally called by the poller object
		//   on the poller thread.
		//**************************************************************
		public bool CheckForUpdates()
		{
			Debug.WriteLine("APPMANAGER:  Checking for updates.");

			bool retValue = false;

			//If the OnCheckForUpdate event the caller is doing the check
			if (OnCheckForUpdate != null)
			{ 
				retValue = OnCheckForUpdate(this, new EventArgs());
			}
			else //otherwise do the check ourselves
			{
				//If versioning is enabled check to see if the version file has changed.
				if (ChangeDetectionMode == ChangeDetectionModes.ServerManifestCheck)
				{
					ServerManifest vm = new ServerManifest();
					vm.Load(UpdateUrl);
					retValue = vm.IsServerVersionNewer(GetLatestInstalledVersion());
				} 
				else //If versioning is not enabled, check the files themselves
				{
					Resource currentResource;
					foreach(Object r in Manifest.Resources.ResourceList) 
					{			
						currentResource = (Resource)(((DictionaryEntry)r).Value);
						string url = UpdateUrl + currentResource.Name;
						string FilePath = currentResource.FilePath;
						if( WebFileLoader.CheckForFileUpdate(url, FilePath))
							retValue =  true;	
					}
				}
			}

			//Fire the OnUpdateDetected Event on the UI thread
			if (OnUpdateDetected != null)
			{
				foreach ( UpdateDetectedEventHandler UC in  OnUpdateDetected.GetInvocationList())
				{
					UpdateDetectedEventArgs ud = new UpdateDetectedEventArgs();
					ud.UpdateDetected = retValue;
					EventControl.BeginInvoke(UC,new object[] {this,ud});
				}
			}

			return retValue;
		}

		//**************************************************************
		// GetLatestInstalledVersion()	
		//**************************************************************
		public static Version GetLatestInstalledVersion()
		{
			//Load the AppStart config File
			string ConfigFilePath =Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
			ConfigFilePath = Path.Combine(Directory.GetParent(ConfigFilePath).FullName,"AppStart.config");
			AppStartConfig Config = AppStartConfig.Load(ConfigFilePath);

			AssemblyName AN = AssemblyName.GetAssemblyName(Config.AppExePath);
			return AN.Version;
		}

		//**************************************************************
		// RestartApp()	
		// - Shuts down the app, returns the AppStart restart return code
		// - May not work for all apps.  Application.Exit() is a soft shutdown
		// - if your app has threads hanging around, the shutdown won't work
		// - Use the ApplicationExit() event
		//**************************************************************
		public void RestartApp()
		{
			Environment.ExitCode = RestartAppReturnValue;
			Application.Exit();
			Poller.Stop();
			Downloader.Stop();
		}

		//**************************************************************
		// UpdateCompleteOps()	
		//**************************************************************
		private void UpdateCompleteOps(object sender, UpdateCompleteEventArgs args)
		{
			if (ShowDefaultUI)
			{
				if (args.UpdateSucceeded)
				{
					UpdateForm F = new UpdateForm();
					
					if (F.ShowDialog()==DialogResult.Yes)
						RestartApp();
				} 
				else
				{
					string ErrorMessage;
					ErrorMessage = "The auto-update of this application failed with the following error message:  \r\n\r\n"
						+ args.ErrorMessage + "\r\n\r\n" 
						+ "To correct this problem, try rebooting the computer & re-launching this application.";
					MessageBox.Show(ErrorMessage,"Application Update Failed",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				}
			}
		}

		//**************************************************************
		// OnAssemblyLoad()	
		// - Generates a manifest of files when doing DirectFile check style
		//   update checks
		//**************************************************************
		private void OnAssemblyLoad(Object sender, AssemblyLoadEventArgs args)
		{
			string[] AssemblyNames = args.LoadedAssembly.Location.Split(new Char[] {'\\'});
			int index = AssemblyNames.Length-1;
			string AssemblyName= AssemblyNames[index];

			if (!Manifest.Resources.ResourceExists(AssemblyName) && IsLocalAssembly(args.LoadedAssembly))
			{
				Resource newResource = new Resource();
				newResource.FilePath = args.LoadedAssembly.Location;
				newResource.Name = AssemblyName;
				newResource.AddedAtRuntime = true;
				Manifest.Resources.AddResource(newResource);
				Manifest.Update();
			}
		}

		//**************************************************************
		// OnAssemblyResolve()	
		// - This code is what does the auto-download of missing files
		//**************************************************************
		private Assembly OnAssemblyResolve(Object sender,ResolveEventArgs args)
		{

			//Check to see if the AssemblyLoad in this event is what caused the
			//event to fire again.  If so, the load failed.
			if (LoadingAssembly==true)
				return null;

			LoadingAssembly=true;
			
			string[] AssemblyNameParts = args.Name.Split(new Char[] {','}, 2);
			string AssemblyName = AssemblyNameParts[0] + ".dll";
			string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AssemblyName);

			string url;
			if (ChangeDetectionMode == ChangeDetectionModes.DirectFileCheck)
				url = UpdateUrl + AssemblyName;
			else
			{
				ServerManifest SM = new ServerManifest();
				SM.Load(UpdateUrl);
				url = Path.Combine(SM.ApplicationUrl,AssemblyName);
			}

			Debug.WriteLine("APPMANAGER:  Auto-downloading assembly:  " + AssemblyName + ".  From:  " + url);

			try 
			{
				WebFileLoader.UpdateFile(url, FilePath);
			} 
			catch (Exception e)
			{
				Debug.WriteLine("APPMANAGER:  Failed to download the missing assembly from the web server.");
				Debug.WriteLine("APPMANAGER:  " + e.ToString());
				if (ShowDefaultUI)
					MessageBox.Show("Unable to auto-download the missing parts of the application from:\r\n"
						+ url + "\r\n\r\n" 
						+ "Make sure your connected to the network.  If the problem persists re-install the application.");
				return null;
			}

			Assembly assembly;
			try 
			{
				assembly = Assembly.Load(args.Name);
			} 
			catch (Exception e)
			{
				Debug.WriteLine("APPMANAGER:  Failed to load the auto-downloaded assembly.");
				Debug.WriteLine("APPMANAGER:  " + e.ToString());
				return null; 
			}
			finally
			{
				LoadingAssembly=false;
			}

			return assembly;
		}


		//**************************************************************
		// IsLocalAssembly()	
		//**************************************************************
		private bool IsLocalAssembly(Assembly assembly)
		{
			string AssemblyLocation  = assembly.Location.Replace("/","\\").ToLower(new CultureInfo("en-US"));
			string AppPath = AppDomain.CurrentDomain.BaseDirectory.ToLower(new CultureInfo("en-US"));

			//Only log & replicate assemblies in the default app path
			if ((AssemblyLocation.StartsWith(AppPath.ToLower(new CultureInfo("en-US")))) && 
				(!assembly.FullName.StartsWith("AppManager")))
				return true;
			else 
				return false;
		}

		//**************************************************************
		// OnThreadExit()	
		//**************************************************************
		private void OnApplicationExit(Object sender, EventArgs args)
		{
			if (Poller!=null)
			{
				//stop the poller thread if it isn't already.
				Poller.Stop();
			}
			if (Downloader!=null)
			{
				Downloader.Stop();
			}
		}

		//**************************************************************
		// EnableFileAutoLoad()	
		//**************************************************************
		private void EnableFileAutoLoad()
		{
			AppDomain App = AppDomain.CurrentDomain;
			App.AssemblyResolve += new ResolveEventHandler(OnAssemblyResolve);
		}

		//**************************************************************
		// DisableFileAutoLoad()	
		//**************************************************************
		private void DisableFileAutoLoad()
		{
			AppDomain App = AppDomain.CurrentDomain;
			App.AssemblyResolve -= new ResolveEventHandler(OnAssemblyResolve);
		}
	
		//**************************************************************
		// EnableManifestGeneration()	
		//**************************************************************
		private void EnableManifestGeneration()
		{	
			//Register for Assembly Load events
			AppDomain App = AppDomain.CurrentDomain;
			App.AssemblyLoad += new AssemblyLoadEventHandler(OnAssemblyLoad);

			//Make sure the currently loaded assemblies are in the manifest
			//The assembly load event will catch any assemblies loaded later
			Assembly[] loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
			for (int i=0; i<loadedAssemblies.Length;i++)
			{
				if (IsLocalAssembly(loadedAssemblies[i]))
				{
					Resource newResource = new Resource();
					string[] AssemblyName = loadedAssemblies[i].Location.Split(new Char[] {'\\'});
					int index = AssemblyName.Length-1;

					newResource.FilePath = loadedAssemblies[i].Location;
					newResource.Name = AssemblyName[index];
					newResource.AddedAtRuntime = true;
					Manifest.Resources.AddResource(newResource);
					Manifest.Update();
				}
			}
		}

		//**************************************************************
		// DisableManifestGeneration()	
		//**************************************************************
		private void DisableManifestGeneration()
		{	
			//Register for Assembly Load events
			AppDomain App = AppDomain.CurrentDomain;
			App.AssemblyLoad -= new AssemblyLoadEventHandler(OnAssemblyLoad);
		}

		//*************************************************************
		// Download progress event
		//*************************************************************
		private void Downloader_OnDownloadProgress(object sender, DownloadProgressEventArgs e)
		{
			if (OnDownloadProgress != null)
			{
				foreach ( DownloadProgressEventHandler d in OnDownloadProgress.GetInvocationList())
				{
					EventControl.BeginInvoke(d,new object[] {sender, e});
				}
			}
		}

		//**************************************************************
		// OnDownloaderComplete()
		//**************************************************************
		private void Downloader_OnUpdateComplete(object sender, UpdateCompleteEventArgs e)
		{
			if (OnUpdateComplete != null)
			{
				foreach ( UpdateCompleteEventHandler UC in  OnUpdateComplete.GetInvocationList())
				{
					EventControl.BeginInvoke(UC,new object[] {sender, e});
				}
			}

			//EventControl.BeginInvoke(new UpdateCompleteEventHandler(UpdateCompleteOps),new object[] {sender, e});
		}

		public void StopUpdating()
		{
			if (Poller!=null)
				Poller.Stop();

			if (Downloader!=null)
				Downloader.Stop();

			Poller = null;
			Downloader = null;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public class UpdateDetectedEventArgs:EventArgs
	{
		private bool updateDetected = false;

		public bool UpdateDetected
		{
			get { return updateDetected; }
			set { updateDetected = value; }
		}

	}

}
