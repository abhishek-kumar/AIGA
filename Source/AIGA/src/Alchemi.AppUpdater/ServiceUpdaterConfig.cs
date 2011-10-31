using System.IO;
using System.Xml.Serialization;
using Alchemi.AppStart;

namespace Alchemi.Updater
{
	/// <summary>
	/// Summary description for UpdaterConfig.
	/// </summary>
	public class ServiceUpdaterConfig : AppStartConfig
	{
		public bool AutoUpdate = true;
		public string UpdateURL = "http://www.alchemi.net/updates"; //default 
		public int UpdateInterval = 300; //seconds
		public UpdaterClientMode ClientMode = UpdaterClientMode.Service; //default
		public UpdaterClientType ClientType = UpdaterClientType.Executor; //default

		public ServiceUpdaterConfig()
		{
			this.AppExeName = "";
			this.AppFolderName = "";
			this.AppExePath = "";
		}

		public static ServiceUpdaterConfig getUpdaterConfig(string configFile)
		{
			ServiceUpdaterConfig temp;
			try
			{
				XmlSerializer xs = new XmlSerializer(typeof(ServiceUpdaterConfig));
				FileStream fs = new FileStream(configFile, FileMode.Open);
				temp = (ServiceUpdaterConfig) xs.Deserialize(fs);
				fs.Close();
			}
			catch
			{
				temp = new ServiceUpdaterConfig();
			}
			return temp;
		}

		public void SaveConfig(string configFile)
		{
			XmlSerializer xs = new XmlSerializer(typeof(ServiceUpdaterConfig));
			StreamWriter sw = new StreamWriter(configFile);
			xs.Serialize(sw, this);
			sw.Close();
		}
	}

	public enum UpdaterClientType
	{
		Manager,
		Executor
	}

	public enum UpdaterClientMode
	{
		Exec,
		Service
	}
}
