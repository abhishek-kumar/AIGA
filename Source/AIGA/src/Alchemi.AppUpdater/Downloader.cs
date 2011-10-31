using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using Alchemi.AppStart;

namespace Alchemi.Updater
{
	//**************************************************************
	// AppDownloader class
	// - Responsible for downloading & applying updates.
	//**************************************************************
	public class AppDownloader
	{
		private AppUpdater AppMan;
		private Thread UpdaterThread;
		private AppStartConfig Config;
		private UpdateLog Log;
		private UpdateCompleteEventArgs UpdateEventArgs;
		private DownloadProgressEventArgs DownloadEventArgs;
		private AppKeys Keys;

		//Enable checking of downloaded assemblies
		private bool _ValidateAssemblies = false;
		[DefaultValue(false)]
		[Description("Specifies whether or not downloaded assemblies must be signed with valid public keys inorder to be downloaded.")]		 
		public bool ValidateAssemblies
		{
			get {return _ValidateAssemblies;}
			set {_ValidateAssemblies = value;}
		}

		//Delay between download retries when a network problem is encountered
		private int _SecondsBetweenDownloadRetry = 60;
		[DefaultValue(60)]
		[Description("Seconds between download retry attempts.")]
		public int SecondsBetweenDownloadRetry
		{
			get { return _SecondsBetweenDownloadRetry; }
			set { _SecondsBetweenDownloadRetry = value; }
		}

		//Number of times to retry when a download error is encountered
		private int _DownloadRetryAttempts = 1;
		[DefaultValue(3)]
		[Description("Number of times to retry downloads when an error is encountered.")]
		public int DownloadRetryAttempts
		{
			get { return _DownloadRetryAttempts; }
			set { _DownloadRetryAttempts = value; }
		}

		//Number of times to retry the overall update
		private int _UpdateRetryAttempts = 2;
		[DefaultValue(2)]
		[Description("Number of times times to retry the app update.")]
		public int UpdateRetryAttempts
		{
			get { return _UpdateRetryAttempts; }
			set { _UpdateRetryAttempts = value; }
		}

		[Browsable(false)]
		public UpdateState State
		{
			get
			{
				return AppMan.Manifest.State;
			}
		}

		//**************************************************************
		// OnUpdateComplete Event	
		//**************************************************************
		internal delegate void UpdateCompleteEventHandler(object sender, UpdateCompleteEventArgs e);
		internal delegate void DownloadProgressEventHandler(object sender, DownloadProgressEventArgs e);

		internal event DownloadProgressEventHandler OnDownloadProgress;
		internal event UpdateCompleteEventHandler OnUpdateComplete;

		//**************************************************************
		// AppUpdater Constructor	
		//**************************************************************
		public AppDownloader(AppUpdater appMan)
		{
			AppMan = appMan;
			Log = new UpdateLog();
			UpdateEventArgs = new UpdateCompleteEventArgs();
			DownloadEventArgs = new DownloadProgressEventArgs();
		}

		//**************************************************************
		// Start()	
		//**************************************************************
		public void Start()
		{
			if ((UpdaterThread == null) || (!UpdaterThread.IsAlive))
			{ 
				UpdaterThread = new Thread(new ThreadStart(RunThread));
				UpdaterThread.Name="Updater Thread";
			}

			if (!UpdaterThread.IsAlive)
				UpdaterThread.Start();
		}

		//**************************************************************
		// Stop()	
		//**************************************************************
		public void Stop()
		{
			if (UpdaterThread != null && UpdaterThread.IsAlive) 
			{
				UpdaterThread.Abort();
				UpdaterThread = null;
			}
		}

		//**************************************************************
		// RunThread()	
		//**************************************************************
		public void RunThread()
		{
			Debug.WriteLine("APPMANAGER:  Starting Update");

			//Load the AppStart config File
			string ConfigFilePath =Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
			ConfigFilePath = Path.Combine(Directory.GetParent(ConfigFilePath).FullName,"AppStart.config");
			Config = AppStartConfig.Load(ConfigFilePath);

			try 
			{
				//Mark in the manifest that a download is in progress.  Persisted in 
				//manifest in case the app is stop & restarted during the download.
				if (AppMan.Manifest.State.Phase == UpdatePhases.Complete) 
				{
					AppMan.Manifest.State.Phase = UpdatePhases.Scavenging;
					AppMan.Manifest.State.UpdateFailureCount=0;
					AppMan.Manifest.State.UpdateFailureEncoutered = false;
					AppMan.Manifest.State.DownloadDestination = CreateTempDirectory();

					if (AppMan.ChangeDetectionMode == ChangeDetectionModes.ServerManifestCheck)
					{	
						ServerManifest SM = new ServerManifest();
						SM.Load(AppMan.UpdateUrl);
						//download from the web and desserialise it into the object
						AppMan.Manifest.State.DownloadSource = SM.ApplicationUrl;

						//new: krishna added this to enable specifying files explicitly instead of deep copying
						//a directory using HTTP-DAV.
						AppMan.Manifest.State.FilesToDownload = SM.FilesToDownload;
					}
					else 
					{
						AppMan.Manifest.State.DownloadSource = AppMan.UpdateUrl;
					}

					AppMan.Manifest.Update();
				}

				//Scavenge Existing Directories
				if (AppMan.Manifest.State.Phase == UpdatePhases.Scavenging)
				{
					Debug.WriteLine("APPMANAGER:  Scavaging older versions");
					Scavenge();
					AppMan.Manifest.State.Phase=UpdatePhases.Downloading;
					AppMan.Manifest.Update();
				}

				//Download the New Version
				if (AppMan.Manifest.State.Phase == UpdatePhases.Downloading)
				{
					Debug.WriteLine("APPMANAGER:  Downloading new version");
					Download();
					AppMan.Manifest.State.Phase = UpdatePhases.Validating;
					AppMan.Manifest.Update();
				}

				//Validate the downloaded bits
				if (AppMan.Manifest.State.Phase == UpdatePhases.Validating)
				{
					Debug.WriteLine("APPMANAGER:  Downloading new version");
					Validate();
					AppMan.Manifest.State.Phase = UpdatePhases.Merging;
					AppMan.Manifest.Update();
				}

				//Merge the existing version into the new version
				if (AppMan.Manifest.State.Phase == UpdatePhases.Merging)
				{
					Debug.WriteLine("APPMANAGER:  Merging current & new versions");
					MergeDirectory(AppDomain.CurrentDomain.BaseDirectory,AppMan.Manifest.State.DownloadDestination);
					AppMan.Manifest.State.Phase = UpdatePhases.Finalizing;
					AppMan.Manifest.Update();
				}

				//Finalize the update.  Rename the new version directory, etc...
				if (AppMan.Manifest.State.Phase == UpdatePhases.Finalizing)
				{
					Debug.WriteLine("APPMANAGER:  Finalizing update");
					FinalizeUpdate();				
				}

				//Reset Update State
				AppMan.Manifest.State.Phase = UpdatePhases.Complete;
				AppMan.Manifest.State.UpdateFailureCount=0;
				AppMan.Manifest.State.UpdateFailureEncoutered = false;
				AppMan.Manifest.State.DownloadSource = "";
				AppMan.Manifest.State.DownloadDestination = "";
				AppMan.Manifest.State.NewVersionDirectory = "";
				AppMan.Manifest.Update();	
			} 
			catch (ThreadAbortException)
			{
				Thread.ResetAbort();
				Debug.WriteLine("APPMANAGER:  ThreadAborted: Updater Thread stopped, stopping download.");
				return;
			}
			catch (Exception e)
			{
				UpdateEventArgs.FailureException = e;
			}

			if (AppMan.Manifest.State.Phase != UpdatePhases.Complete)
				HandleUpdateFailure();
			else
				HandleUpdateSuccess();
		}

		//**************************************************************
		// HandleUpdateSuccess()	
		//**************************************************************
		private void HandleUpdateSuccess()
		{
			Debug.WriteLine("APPMANAGER:  Update Succeeded");

			try 
			{
				Log.AddSuccess(GetFileVersion(Config.AppExePath));
			} 
			catch (Exception e)
			{
				Debug.WriteLine("APPMANAGER:  Failed to log update success");
				Debug.WriteLine("APPMANAGER:  " + e.ToString());
			}

			//Fire Update Event
			if (OnUpdateComplete != null)
			{
				UpdateEventArgs.UpdateSucceeded = true;
				UpdateEventArgs.NewVersion = new Version(GetFileVersion(Config.AppExePath));
				if (UpdateEventArgs.ErrorMessage == "")
					UpdateEventArgs.ErrorMessage = "Unknown Error";
				OnUpdateComplete(this, UpdateEventArgs);
			}
		}

		//**************************************************************
		// HandleUpdateFailure()	
		//**************************************************************
		private void HandleUpdateFailure()
		{
			Debug.WriteLine("APPMANAGER:  Update Failed");

			try 
			{
				Log.AddError(UpdateEventArgs.FailureException.ToString());
			} 
			catch (Exception e)
			{
				Debug.WriteLine("APPMANAGER:  Failed to log update failure");
				Debug.WriteLine("APPMANAGER:  " + e.ToString());
			}

			AppMan.Manifest.State.UpdateFailureEncoutered = true;
			AppMan.Manifest.State.UpdateFailureCount++;
			AppMan.Manifest.Update();

			//If the update has failed too many times
			if (AppMan.Manifest.State.UpdateFailureCount >= UpdateRetryAttempts)
			{
				Debug.WriteLine("APPMANAGER:  Updated Failed 2 times.  Reseting Manifest");
				AppMan.Manifest.State.Phase = UpdatePhases.Complete;
				AppMan.Manifest.State.UpdateFailureEncoutered = false;
				AppMan.Manifest.State.UpdateFailureCount = 0;
				AppMan.Manifest.State.DownloadSource = "";
				AppMan.Manifest.State.DownloadDestination = "";				
				AppMan.Manifest.Update();
			}

			if (OnUpdateComplete != null)
			{
				UpdateEventArgs.UpdateSucceeded = false;
				if (UpdateEventArgs.ErrorMessage == "")
					UpdateEventArgs.ErrorMessage = "Unknown Error";
				OnUpdateComplete(this, UpdateEventArgs);
			}
		}

		//**************************************************************
		// Download()	
		//**************************************************************
		private void Download()
		{
			bool DownloadInProgress = true;
			int DownloadAttemptCount = 0;
			int SecondsToSleep = 0;

			while (DownloadInProgress)
			{
				Thread.Sleep(TimeSpan.FromSeconds(SecondsToSleep));
				SecondsToSleep = SecondsBetweenDownloadRetry;

				DownloadAttemptCount++;

				Trace.WriteLine("APPMANAGER:  Attempting to download update from:  " + AppMan.Manifest.State.DownloadSource);

				try
				{
					int UpdateCount = 0;

					//if we have a known set of files-to-download, get it from that. otherwise, deep copy the directory - krishna - jun05
					if (AppMan.Manifest.State.FilesToDownload != null && AppMan.Manifest.State.FilesToDownload.Length != 0) //
					{
						//raise the progress event before starting first download.
						if (OnDownloadProgress != null)
						{
							//currentState represents the percent done.
							DownloadEventArgs.CurrentState = 0;
							DownloadEventArgs.CurrentFile = 1;
							DownloadEventArgs.TotalFiles = AppMan.Manifest.State.FilesToDownload.Length;
							OnDownloadProgress(this, DownloadEventArgs);
						}

						for (int i = 0; i < AppMan.Manifest.State.FilesToDownload.Length ; i++)
						{
							string file = AppMan.Manifest.State.FilesToDownload[i];
							string url = AppMan.Manifest.State.DownloadSource;
							string destinationtempDir = AppMan.Manifest.State.DownloadDestination;
							Debug.WriteLine("URL = "+url);
							if (!url.EndsWith("/"))
								url += "/";
							url += file;
							Debug.WriteLine("URL after = "+url);

							//make sure the path has a \ at the end
							MakeValidPath(destinationtempDir);

							//If the directory doesn't exist, create it first
							if (!Directory.Exists(destinationtempDir))
								Directory.CreateDirectory(destinationtempDir);

							//copy file to temp location, not to the main place.
							file = destinationtempDir + file;
							Debug.WriteLine("File temp path= "+file);

							WebFileLoader.UpdateFile(url,file);
							//raise the event
							UpdateCount++;
							if (OnDownloadProgress != null)
							{
								//currentState represents the percent done.
								if (i < AppMan.Manifest.State.FilesToDownload.Length)
								{
									DownloadEventArgs.CurrentFile = i+1;
								}
								else
								{
									DownloadEventArgs.CurrentFile = i;
								}
								//total files is already set in the code above.
								//set the percentage done,below.
								DownloadEventArgs.CurrentState = (100 * UpdateCount / AppMan.Manifest.State.FilesToDownload.Length);
								OnDownloadProgress(this, DownloadEventArgs);
							}
						}
					}
					else
					{
						UpdateCount = WebFileLoader.CopyDirectory(AppMan.Manifest.State.DownloadSource,AppMan.Manifest.State.DownloadDestination); 
					}

					Debug.WriteLine("APPMANAGER:  Number of files updated from the server:  " + UpdateCount);

					Debug.WriteLine("APPMANAGER:  App update downloaded successfully");

					DownloadInProgress = false;
				} 
					//Things that could go wrong while downloading are pretty much any kind of 
					//network problem, like the client just going offline.  However, this can cause
					//itself to manifest in any number of ways... like exceptions on the stream
					//objects used to copy the file to disk.
				catch (WebException e)
				{
					Debug.WriteLine("APPMANAGER:  Update download failed due to network exception:");
					Debug.WriteLine("APPMANAGER:  " + e.ToString());
					
					if (DownloadAttemptCount >= DownloadRetryAttempts)
					{
						Debug.WriteLine("APPMANAGER:  Download attempt has failed 3 times.  Aborting Update");
						UpdateEventArgs.ErrorMessage = "Download of a new update from '"+ AppMan.Manifest.State.DownloadSource 
							+"' failed with the network error:  " + e.Message;
						throw e;
					}
				}
				catch (IOException e)
				{
					Debug.WriteLine("APPMANAGER:  Update download failed due to file I/O exception:");
					Debug.WriteLine("APPMANAGER:  " + e.ToString());
					
					if (DownloadAttemptCount >= DownloadRetryAttempts)
					{
						Debug.WriteLine("APPMANAGER:  Download attempt has failed 3 times.  Aborting Update");
						UpdateEventArgs.ErrorMessage = "Saving the new update to disk at '" + AppMan.Manifest.State.DownloadDestination 
							+"' failed with the following error:  " + e.Message;
						throw e;
					}
				}
				catch (Exception e)
				{
					Debug.WriteLine("APPMANAGER:  Update download failed due to the following error:  " + e.Message);
					Debug.WriteLine("APPMANAGER:  " + e.ToString());
					
					if (DownloadAttemptCount >= DownloadRetryAttempts)
					{
						Debug.WriteLine("APPMANAGER:  Download attempt has failed 3 times.  Aborting Update");
						UpdateEventArgs.ErrorMessage = "Update failed with the following error:  '"+ e.Message + "'";
						throw e;
					}
				}
			}
		}

		//**************************************************************
		// Validate()	
		//**************************************************************
		private void Validate()
		{
			if (!ValidateAssemblies)
				return;

			//Initialize the Keys Object
			Keys = new AppKeys(AppMan.Manifest.State.DownloadSource);
			Keys.InitializeKeyCheck();

			try 
			{
				ValidateDirectory(AppMan.Manifest.State.DownloadDestination);
			} 
			catch (Exception)
			{
				Keys.UnInitializeKeyCheck();

				//Remove the downloaded files if any error occurs in validation.
				HardDirectoryDelete(AppMan.Manifest.State.DownloadDestination);

				//Set the update failure count to max.
				//Don't retry the update another time.  This will cause the update
				//to reset.
				AppMan.Manifest.State.UpdateFailureCount = UpdateRetryAttempts;
				AppMan.Manifest.Update();  
				throw;
			}

			Keys.UnInitializeKeyCheck();
		}


		//**************************************************************
		// ValidateDirectory()	
		//**************************************************************
		private void ValidateDirectory(string source)
		{
			try 
			{
				//Get a reference to the source directory
				DirectoryInfo Source = new DirectoryInfo(source);
			
				//Walk files
				FileInfo[] Files = Source.GetFiles();
				foreach (FileInfo pFile in Files)
				{
					//File check here
					if (!Keys.ValidateAssembly(pFile.FullName))
					{
						throw new Exception("Invalid assembly:  " + pFile.FullName); 
					}
				}

				//Recurse into subdirectories
				DirectoryInfo[] Directories = Source.GetDirectories();
				foreach (DirectoryInfo pDirectory in Directories)
				{
					ValidateDirectory(Path.Combine(source,pDirectory.Name));
				}
			} 
			catch (Exception e)
			{
				Debug.WriteLine("APPMANAGER: Failed to validate new version.");
				Debug.WriteLine("APPMANAGER:  " + e.ToString());

				UpdateEventArgs.ErrorMessage = e.Message;

				throw;
			}	
		}

		//**************************************************************
		// Scavenge()	
		//**************************************************************
		private void Scavenge()
		{
			DirectoryInfo Root = new DirectoryInfo(GetParentFolder(AppDomain.CurrentDomain.BaseDirectory));
			DirectoryInfo[] Directories = Root.GetDirectories();

			foreach (DirectoryInfo Directory in Directories)
			{
				if (((MakeValidPath(Directory.FullName)).ToLower(new CultureInfo("en-US")) 
					  != AppDomain.CurrentDomain.BaseDirectory.ToLower(new CultureInfo("en-US")))
					&& ((MakeValidPath(Directory.FullName)).ToLower(new CultureInfo("en-US"))
					  != Config.AppPath.ToLower(new CultureInfo("en-US"))) &&
					Directory.Name.ToLower(new CultureInfo("en-US")) != "bin")
				{
					try 
					{
						HardDirectoryDelete(MakeValidPath(Directory.FullName));
					} 
					catch (Exception)
					{
						//If we can't delete it, just leave it.
					}
				}
			}
		}


		//**************************************************************
		// Merge()	
		//**************************************************************
		private void MergeDirectory(string source, string destination)
		{
			try 
			{
				//Get a reference to the source directory
				DirectoryInfo Source = new DirectoryInfo(source);
			
				//Create this directory if it doesn't exist
				if (!Directory.Exists(destination)) 
				{
					Directory.CreateDirectory(destination);
					//copy the attributes
					DirectoryInfo Destination = new DirectoryInfo(destination);
					Destination.Attributes = Source.Attributes;
				}

				//Copy files
				FileInfo[] Files = Source.GetFiles();
				foreach (FileInfo pFile in Files)
				{
					if (!File.Exists(Path.Combine(destination,pFile.Name))
						&& (!isManifestFile(pFile.Name)))
						pFile.CopyTo(Path.Combine(destination,pFile.Name),true);
				}

				//Recurse into subdirectories
				DirectoryInfo[] Directories = Source.GetDirectories();
				foreach (DirectoryInfo pDirectory in Directories)
				{
					MergeDirectory(Path.Combine(source,pDirectory.Name),Path.Combine(destination,pDirectory.Name));
				}
			} 
			catch (Exception e)
			{
				Debug.WriteLine("APPMANAGER:  FAILED to copy:  " + source + " to " + destination);
				Debug.WriteLine("APPMANAGER:  " + e.ToString());

				UpdateEventArgs.ErrorMessage = "Copy of user files from the current app directory '" + source 
					   + "' to the new app directory'" + destination + "' failed with the following error:  " + e.Message;

				throw;
			}	
		}

		//**************************************************************
		// FinalizeUpdate()	
		//**************************************************************
		private void FinalizeUpdate()
		{
			//Create & reserve the properly named new version directory based on the 
			//assembly version of the downloaded version
			try 
			{
				if (AppMan.Manifest.State.NewVersionDirectory =="")
				{
					AppMan.Manifest.State.NewVersionDirectory = CreateNewVersionDirectory();
					AppMan.Manifest.Update();
				}
			} 
			catch (Exception)
			{
				UpdateEventArgs.ErrorMessage = "Failed to create the New Version Directory, using temp download directory as final destination.";
				AppMan.Manifest.State.NewVersionDirectory = AppMan.Manifest.State.DownloadDestination;
				AppMan.Manifest.Update();
			}

			//Copy the downloaded version into the new directory
			try 
			{
				if (AppMan.Manifest.State.NewVersionDirectory.ToLower(new CultureInfo("en-US")) != AppMan.Manifest.State.DownloadDestination.ToLower(new CultureInfo("en-US")))
					CopyDirectory(AppMan.Manifest.State.DownloadDestination,AppMan.Manifest.State.NewVersionDirectory);
			} 
			catch (Exception e)
			{
				UpdateEventArgs.ErrorMessage = "Failed to copy the downloaded update at: '"+AppMan.Manifest.State.DownloadDestination
					+"' to the new version directory at: '" + AppMan.Manifest.State.NewVersionDirectory + "'" ;
				throw e;
			}

			//Write the new version location into the AppConfig file.
			//This is the act that makes the update officially complete
			try 
			{
				char[] MyChar={'\\'};
				Config.AppFolderName = Path.GetFileName(AppMan.Manifest.State.NewVersionDirectory.TrimEnd(MyChar));
				Config.Update();
			} 
			catch (Exception e)
			{
				UpdateEventArgs.ErrorMessage = "Failed to write to 'AppStart.config'";
				throw e;
			}

			try 
			{
				if (AppMan.Manifest.State.NewVersionDirectory.ToLower(new CultureInfo("en-US")) != AppMan.Manifest.State.DownloadDestination.ToLower(new CultureInfo("en-US")))
					HardDirectoryDelete(AppMan.Manifest.State.DownloadDestination);
			} 
			catch (Exception)
			{
				//Don't fail the update just because the download copy can't be deleted.
				//It will be scavenged later.
			}

		}

		//**************************************************************
		// CreateTempDirectory()	
		//**************************************************************
		private string CreateTempDirectory()
		{
			const int DirectoryCreateRetryAttempts = 50;
			int counter = 0;
			Random Rand = new Random();
			string RandomAddition = "";

			string RootDirectory = GetParentFolder(AppDomain.CurrentDomain.BaseDirectory);
			string TempDirectory;

			do 
			{
				TempDirectory = RootDirectory + "AppUpdate" + RandomAddition + "\\";
				RandomAddition = "_"+Rand.Next(10000).ToString();
				counter++;
			} while (counter <= DirectoryCreateRetryAttempts && Directory.Exists(TempDirectory));

			if (counter >= DirectoryCreateRetryAttempts)
			{
				Debug.WriteLine("APPMANAGER:  Failed to create temporary download Directory after 1000 attempts");
				UpdateEventArgs.ErrorMessage = "Failed to created temporary download directory in: '"+RootDirectory+"'";
				throw (new Exception("Failed to create temporary download Directory after 1000 attempts"));
			}
			else
			{
				try 
				{
					Directory.CreateDirectory(TempDirectory);
				} 
				catch (Exception e)
				{
					Debug.WriteLine("APPMANAGER:  Failed to create temporary download Directory");
					Debug.WriteLine("APPMANAGER:  " + e.ToString());
					throw e;
				}
			}

			return TempDirectory;
		}

		//**************************************************************
		// CreateNewVersionDirectory()	
		//**************************************************************
		private string CreateNewVersionDirectory()
		{
			string NewExePath;
			NewExePath = AppMan.Manifest.State.DownloadDestination;
			NewExePath += Config.AppExeName;

			string NewDirectoryName;		
			NewDirectoryName = GetFileVersion(NewExePath);
 
			string NewDirectoryRoot = GetParentFolder(AppMan.Manifest.State.DownloadDestination);
			string NewDirectoryFullPath = "";

			const int DirectoryCreateRetryAttempts = 999;
			int counter = 1;
			bool FileOpSucceeded = false;
			string RandomAddition = "";

			do 
			{
				NewDirectoryFullPath = NewDirectoryRoot + NewDirectoryName + RandomAddition + "\\";
				RandomAddition = "_"+counter.ToString();
				counter++;

				try 
				{
					if (!Directory.Exists(NewDirectoryFullPath))
					{
						Directory.CreateDirectory(NewDirectoryFullPath);
						FileOpSucceeded = true;
					}
				} 
				catch (Exception)
				{
					FileOpSucceeded = false;
					Debug.WriteLine("APPMANAGER:  Failed to rename download Directory to: " + NewDirectoryFullPath);
					Debug.WriteLine("APPMANAGER:  Trying to rename again.");
				}
			
			} while (counter <= DirectoryCreateRetryAttempts && !FileOpSucceeded);

			if (counter >= DirectoryCreateRetryAttempts)
			{
				Debug.WriteLine("APPMANAGER:  Failed to rename temporary download Directory after 1000 tries");
				Debug.WriteLine("APPMANAGER:  Leaving in temporary directory");
				NewDirectoryFullPath = AppMan.Manifest.State.DownloadDestination;
			}

			return NewDirectoryFullPath;
		}

		//**************************************************************
		// MakeValidPath()	
		//**************************************************************
		private string MakeValidPath(string source)
		{
			if (source.EndsWith(@"\"))
				return source;
			else
				return (source + @"\");
		}

		//**************************************************************
		// CopyDirectory()	
		//**************************************************************
		private void CopyDirectory(string source, string destination)
		{
			try 
			{
				//Get a reference to the source directory
				DirectoryInfo Source = new DirectoryInfo(source);
			
				//Create this directory if it doesn't exist
				if (!Directory.Exists(destination)) 
				{
					Directory.CreateDirectory(destination);
					//copy the attributes
					DirectoryInfo Destination = new DirectoryInfo(destination);
					Destination.Attributes = Source.Attributes;
				}

				//Copy files
				FileInfo[] Files = Source.GetFiles();
				foreach (FileInfo pFile in Files)
				{
					if (!File.Exists(Path.Combine(destination,pFile.Name)))
						pFile.CopyTo(Path.Combine(destination,pFile.Name),true);
				}

				//Recurse into subdirectories
				DirectoryInfo[] Directories = Source.GetDirectories();
				foreach (DirectoryInfo pDirectory in Directories)
				{
					CopyDirectory(Path.Combine(source,pDirectory.Name),Path.Combine(destination,pDirectory.Name));
				}
			} 
			catch (Exception e)
			{
				Debug.WriteLine("UPDATER:  FAILED to copy:  " + source + " to " + destination);
				Debug.WriteLine("UPDATER:  " + e.ToString());
				throw e; 
			}		
		}

		//**************************************************************
		// HardDirectoryDelete()	
		//**************************************************************
		private void HardDirectoryDelete(string source)
		{
			try 
			{
				if (!Directory.Exists(source))
					return;

				//Get a reference to the source directory
				DirectoryInfo Source = new DirectoryInfo(source);
				Source.Attributes = FileAttributes.Normal;
		
				//Clear the attributes on the files
				FileInfo[] Files = Source.GetFiles();
				foreach (FileInfo pFile in Files)
				{
					pFile.Attributes = FileAttributes.Normal;
				}

				//Recurse into subdirectories
				DirectoryInfo[] Directories = Source.GetDirectories();
				foreach (DirectoryInfo pDirectory in Directories)
				{
					HardDirectoryDelete(Path.Combine(source,pDirectory.Name));
				}

				Source.Delete(true);
			} 
			catch (Exception e)
			{
				Debug.WriteLine("APPMANAGER:  FAILED to delete:  " + source);
				Debug.WriteLine("APPMANAGER:  " + e.ToString());
				throw e;
			}
		}

		//**************************************************************
		// GetFileVersion()	
		//**************************************************************
		private string GetFileVersion(string filePath)
		{
			AssemblyName AN = AssemblyName.GetAssemblyName(filePath);
			return AN.Version.ToString();
		}


		//**************************************************************
		// GetParentFolder()	
		//**************************************************************
		private string GetParentFolder(string filePath)
		{
			DirectoryInfo DI = new DirectoryInfo(filePath.Trim(new char[] { '\\' }));
			return (DI.Parent.FullName + @"\");
		}

		//**************************************************************
		// isManifestFile()	
		//**************************************************************
		private bool isManifestFile(string name)
		{
			string ManifestName = Path.GetFileName(AppMan.Manifest.FilePath);
			if (ManifestName.ToLower(new CultureInfo("en-US")) == name.ToLower(new CultureInfo("en-US")))
				return true;
			else
				return false;
		}
	}

	//**************************************************************
	// UpdateCompleteEventArgs Class
	//**************************************************************
	public class UpdateCompleteEventArgs:EventArgs
	{
		private bool _UpdateSucceeded;
		public bool UpdateSucceeded 
		{ get { return _UpdateSucceeded; } set { _UpdateSucceeded = value; } }

		private Exception _FailureException;
		public Exception FailureException 
		{ get { return _FailureException; } set { _FailureException = value; } }

		private string _ErrorMessage;
		public string ErrorMessage 
		{ get { return _ErrorMessage; } set { _ErrorMessage = value; } }

		private Version _NewVersion;
		public Version NewVersion 
		{ get { return _NewVersion; } set { _NewVersion = value; } }
	}

	public class DownloadProgressEventArgs:EventArgs
	{
		private long currentState;
		private long totFiles;
		private long currentFile;

		public long CurrentState
		{
			get
			{
				return currentState;
			}
			set
			{
				currentState = value;
			}
		}

		public long CurrentFile
		{
			get { return currentFile; }
			set { currentFile = value; }
		}

		public long TotalFiles
		{
			get { return totFiles; }
			set { totFiles = value; }
		}


	}
}
