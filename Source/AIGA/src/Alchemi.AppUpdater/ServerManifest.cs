using System;
using System.Collections;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Alchemi.Updater
{
	//**************************************************************
	// ServerManifest Class	
	// - When doing server manifest style update checks, this class
	//   is used to download & inspect the server manifest
	//**************************************************************
	[Serializable]
	public class ServerManifest
	{
		private XmlDocument _manifest; 
		private string _url;
		private string[] _filesToDownload;

		private string _AvailableVersion;
		public string AvailableVersion 
		{ get { return _AvailableVersion; } set { _AvailableVersion = value; } }

		private string _ApplicationUrl;
		public string ApplicationUrl 
		{ get { return _ApplicationUrl; } set { _ApplicationUrl = value; } }

		public DateTime LastModTime
		{
			get
			{
				return WebFileLoader.GetLastModTime(_url);
			}
		}

		//krishna added this property to avoid using HTTP DAV to copy directories.
		public string[] FilesToDownload
		{
			get { return _filesToDownload; }
			set { _filesToDownload = value; }
		}

		//**************************************************************
		// ServerManifest()	
		//**************************************************************
		public ServerManifest()
		{
		}

		//**************************************************************
		// Load()	
		//**************************************************************
		public void Load(string url)
		{
			_url = url;
			String LocalManifestPath = AppDomain.CurrentDomain.BaseDirectory  + 
				Path.GetFileName((new Uri(_url)).LocalPath);

			WebFileLoader.UpdateFile(_url, LocalManifestPath);

			_manifest = new XmlDocument();
			_manifest.Load(LocalManifestPath);

			ApplicationUrl = _manifest.GetElementsByTagName("ApplicationUrl")[0].InnerText;
			AvailableVersion = _manifest.GetElementsByTagName("AvailableVersion")[0].InnerText;

			try
			{
				XmlNode filelist = _manifest.GetElementsByTagName("FilesToDownload")[0];
				XmlNodeList files = null;
				if (filelist != null && filelist.HasChildNodes)
					files = filelist.ChildNodes;

				if (files!=null)
				{
					_filesToDownload = new string[files.Count];
					for (int i = 0; i <= files.Count; i++)
					{
						_filesToDownload[i] = files[i].InnerText;
					}
				}
			}catch {}
			
		}

//		//krishna added this property to avoid using HTTP DAV to copy directories. Just copying files now.
//		//so now the FilesToDownload property will simply return the list of files
//		//this method will enable easy reading of the ServerManifest, even though the class may change.
//		//since we dont need to do XML parsing as in the load method above.
//		public static ServerManifest LoadServerManifest(string url)
//		{
//			String LocalManifestPath = AppDomain.CurrentDomain.BaseDirectory  + 
//				Path.GetFileName((new Uri(url)).LocalPath);
//
//			WebFileLoader.UpdateFile(url, LocalManifestPath);
//
//			XmlSerializer xs = new XmlSerializer(typeof(ServerManifest));
//			FileStream fs = new FileStream(LocalManifestPath, FileMode.Open);
//			ServerManifest tempSM = (ServerManifest) xs.Deserialize(fs);
//			fs.Close();
//			return tempSM;
//		}


		//**************************************************************
		// IsServerVersionNewer()	
		//**************************************************************
		public bool IsServerVersionNewer(Version currentVersion)
		{
			
			Version ServerVersion = new Version(AvailableVersion);

			if (ServerVersion > currentVersion)
				return true;
			else 
				return false;
    	}

	}
}
