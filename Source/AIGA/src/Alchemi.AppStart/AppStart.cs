using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Alchemi.AppStart
{
	//**************************************************************
	// AppStart Class	
	// This is the main class for appstart.exe
	//**************************************************************
	public class AppStart
	{
		public AppStart() {}
		
		static string AppExePath;
		static Process AppProcess;
		static string[] CommandLineArgs;
		static string[] RestartCommandLineArgs;

		static string CommandLineString;
		static string RestartCommandLineString;


		//**************************************************************
		// Main()	
		//**************************************************************
		[STAThread]
		static void Main(string[] args) 
		{
			//Retrive cmdline to pass to new process
			CommandLineString = "";
			for (int i = 0; i < args.Length; i++) 
			{
				CommandLineString = string.Format ("{0} {1}", CommandLineString, args[i]);
			}

			CommandLineString += " /appstartversion " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
			RestartCommandLineString = CommandLineString + " /restart ";

			CommandLineArgs = new String[args.Length+2];
			CommandLineArgs[CommandLineArgs.Length-2] = "/appstartversion";
			CommandLineArgs[CommandLineArgs.Length-1] = Assembly.GetExecutingAssembly().GetName().Version.ToString();
			RestartCommandLineArgs = new String[CommandLineArgs.Length+1];
			RestartCommandLineArgs[RestartCommandLineArgs.Length-1] = "/restart";

			AppStartConfig Config = LoadConfig();
			if (Config.AppLaunchMode == AppStartConfig.LaunchModes.Process)
				StartAndWait_Process();
			else
				StartAndWait_Domain();

		}

		/*********************************************************************
		 * StartAndWait_Domain()
		**********************************************************************/ 
		private static void StartAndWait_Domain()
		{
			bool restartApp = true;
			int returnCode = 0;

			while (restartApp)
			{	
				try 
				{
					returnCode = StartApp_Domain(false);
					Debug.WriteLine(returnCode.ToString());
				} 
				catch (Exception e)
				{
					Debug.WriteLine("APPLICATION STARTER:  Process.WaitForExit() failed, it's possible the process is not running");
					HandleTerminalError(e);
				}

				if (returnCode == 2)
				{
					restartApp = true;
				}
				else
					restartApp = false;	
			}
		}

		/*********************************************************************
		 * StartAndWait_Process()
		**********************************************************************/ 
		private static void StartAndWait_Process()
		{
			bool restartApp = true;

			StartApp_Process(false);

			while (restartApp)
			{	
				try 
				{
					AppProcess.WaitForExit();
				} 
				catch (Exception e)
				{
					Debug.WriteLine("APPLICATION STARTER:  Process.WaitForExit() failed, it's possible the process is not running");
					Debug.WriteLine("APPLICATION STARTER:  " + e.ToString());
					return;
				}

				if (AppProcess.ExitCode == 2)
				{
					restartApp = true;
					AppProcess = null;
					StartApp_Process(true);
				}
				else
					restartApp = false;	
			}
		}

		/*********************************************************************
		 * StartApp_Domain()
		**********************************************************************/ 
		public static int StartApp_Domain(bool restartApp) 
		{
			Debug.WriteLine("APPLICATION STARTER:  Starting the app in a seperate domain");

			//Load the config file
			AppStartConfig Config;
			Config = LoadConfig();
			AppExePath = Config.AppExePath;

			//Load the app
			int retValue=0;
			try 
			{
				//Create the new app domain
				AppDomain NewDomain = AppDomain.CreateDomain (
					"New App Domain",
					AppDomain.CurrentDomain.Evidence,
					Path.GetDirectoryName(AppExePath)+@"\",
					"",
					false);

				//Execute the app in the new appdomain
				string[] cmdLineArgs;
				if(restartApp)
					cmdLineArgs = RestartCommandLineArgs;
				else
					cmdLineArgs = CommandLineArgs;		
				retValue = NewDomain.ExecuteAssembly(AppExePath,AppDomain.CurrentDomain.Evidence,cmdLineArgs);
		
				//Unload the app domain
				AppDomain.Unload(NewDomain);

			}
			catch (Exception e)
			{
				Debug.WriteLine("APPLICATION STARTER:  Failed to start app at:  " + AppExePath);
				HandleTerminalError(e);
			}

			return (retValue);		
		}
		
		/*********************************************************************
		 * StartApp_Process()
		**********************************************************************/ 
		public static void StartApp_Process(bool restartApp) 
		{
			Debug.WriteLine("APPLICATION STARTER:  Starting the app in a seperate process");

			//Load the config file
			AppStartConfig Config;
			Config = LoadConfig();
			AppExePath = Config.AppExePath;

			//If the app has been started by this process before
			if (AppProcess != null)
			{
				//& the app is still running, no need to start the app
				if (!AppProcess.HasExited)
					return;
			}

			//Start the app
			try 
			{
				ProcessStartInfo p = new ProcessStartInfo (AppExePath);
				p.WorkingDirectory = Path.GetDirectoryName(AppExePath);

				// Notify the app if we are restarting in case there's something they want to do differently
				if(restartApp)
					p.Arguments = RestartCommandLineString;
				else
					p.Arguments = CommandLineString;
				AppProcess = Process.Start (p);
				Debug.WriteLine("APPLICATION STARTER:  Started app:  " + AppExePath);
			} 
			catch (Exception e)
			{
				Debug.WriteLine("APPLICATION STARTER:  Failed to start process at:  " + AppExePath);
				HandleTerminalError(e);
			}
		}	

		/*********************************************************************
		 * LoadConfig()
		**********************************************************************/ 
		private static AppStartConfig LoadConfig()
		{

			AppStartConfig Config;

			//Load the config file which knows where the app lives
			try 
			{
				//Try app specific config file name
				Config = AppStartConfig.Load(CalcConfigFileLocation());
				return Config;
			} 
			catch (Exception e)
			{
				try 
				{
					//Try default config file name
					Debug.WriteLine("APPLICATION STARTER: Falling back to try to read appstart.config."); 
					Config = AppStartConfig.Load(AppDomain.CurrentDomain.BaseDirectory + @"AppStart.Config");
					return Config;
				} 
				catch
				{
					HandleTerminalError(e);
				}
			}

			return null;
		}

		/*********************************************************************
		 * GetAppExePath()
		**********************************************************************/ 
		private static string CalcConfigFileLocation()
		{
			//The config file name should be appstart.config if the exe name is appstart.exe
			
			string ConfigFileName;
			
			try
			{
				ConfigFileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
				ConfigFileName = Path.Combine(ConfigFileName,Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location));
				ConfigFileName += @".config";
				return ConfigFileName;
			} 
			catch (Exception e)
			{
				Debug.WriteLine("APPLICATION STARTER:  Failed to properly calculate config file name");
				HandleTerminalError(e);
				return null;
			}
		}

		/*********************************************************************
		 * HandleTerminalError()
		 * Prints out the terminal exception & shuts down the app
		**********************************************************************/ 
		private static void HandleTerminalError(Exception e)
		{
			Debug.WriteLine("APPLICATION STARTER: Terminal error encountered.");
			Debug.WriteLine("APPLICATION STARTER: The following exception was encoutered:");
			Debug.WriteLine(e.ToString());
			Debug.WriteLine("APPLICATION STARTER: Shutting down");

			MessageBox.Show("The auto-update feature of this application has encountered a configuration error.\r\n"
				+"Please uninstall and reinstall the application.");			Environment.Exit(0);
		}
	}
}
