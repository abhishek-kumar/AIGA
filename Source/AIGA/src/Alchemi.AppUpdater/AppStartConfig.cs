using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace Alchemi.AppStart
{
	public class AppStartConfig
	{
		public enum LaunchModes {AppDomain=0,Process=1};

		private string ConfigPath = "AppStart.config";

		private string _AppFolderName;
		public string AppFolderName 
		{ get { return _AppFolderName; } set { _AppFolderName = value; } }

		private string _AppExeName;
		public string AppExeName 
		{ get { return _AppExeName; } set { _AppExeName = value; } }
		
		private LaunchModes _AppLaunchMode;
		public LaunchModes AppLaunchMode 
		{ get { return _AppLaunchMode; } set { _AppLaunchMode = value; } }
		
		/// <summary>
		/// Application exe location and name.
		/// </summary>
		public string AppExePath
		{
			get 
			{
				string temp = null;
				if (AppFolderName!=null && !AppFolderName.Equals(""))
				{
					temp = Path.Combine(Path.GetDirectoryName(ConfigPath),AppFolderName);
					if (AppExeName!=null && !AppExeName.Equals(""))
					{
						temp = Path.Combine(temp,AppExeName);
					}
				}
				else
				{
					temp = Path.GetDirectoryName(ConfigPath);
					if (AppExeName!=null && !AppExeName.Equals(""))
					{
						temp = Path.Combine(temp,AppExeName);
					}
				}
				return temp;
			}
			set {}
		}

		/// <summary>
		/// Application path
		/// </summary>
		public string AppPath
		{
			get 
			{
				string temp = null;
				if (AppFolderName!=null && !AppFolderName.Equals(""))
				{
					temp = Path.Combine(Path.GetDirectoryName(ConfigPath),AppFolderName);
				}
				else
				{
					temp = Path.GetDirectoryName(ConfigPath);
				}

				return temp + @"\";
			}
			set {}
		}

		//**************************************************************
		// Load()	
		//**************************************************************
		/// <summary>
		/// Gets an AppStart object deserialized from the file.
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		public static AppStartConfig Load(string filePath)
		{
			AppStartConfig temp = null;
			try
			{
				XmlSerializer xs = new XmlSerializer(typeof(AppStartConfig));
				FileStream fs = new FileStream(filePath, FileMode.Open);
				temp = (AppStartConfig) xs.Deserialize(fs);
				fs.Close();				
			}
			catch (Exception e)
			{
				Debug.WriteLine("Error deserializing Appstart");
				throw new ConfigFileMissingException("Error loading config file :"+filePath,e);
			}
			return temp;
		}

		//**************************************************************
		// Update()	
		//**************************************************************
		public void Update()
		{
			try 
			{
				XmlSerializer xs = new XmlSerializer(typeof(AppStartConfig));
				StreamWriter sw = new StreamWriter(this.ConfigPath);
				xs.Serialize(sw, this);
				sw.Close();			
			} 
			catch (Exception e)
			{
				Debug.WriteLine("Failed to update appstart config file, make sure" 
					+ "that the config file is not locked");
				throw e;
			}
		}
	}

	[Serializable()]
	public class ConfigFileMissingException : ApplicationException {
		public ConfigFileMissingException(string message, Exception innerException) : base(message, innerException){
		}
	}

}
