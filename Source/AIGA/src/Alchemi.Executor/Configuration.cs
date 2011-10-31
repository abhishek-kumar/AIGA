#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	Configuration.cs
* Project		:	Alchemi Core
* Created on	:	2003
* Copyright		:	Copyright © 2006 The University of Melbourne
*					This technology has been developed with the support of 
*					the Australian Research Council and the University of Melbourne
*					research grants as part of the Gridbus Project
*					within GRIDS Laboratory at the University of Melbourne, Australia.
* Author         :  Akshay Luther (akshayl@csse.unimelb.edu.au) and Rajkumar Buyya (raj@csse.unimelb.edu.au)
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
using System.IO;
using System.Xml.Serialization;

namespace Alchemi.Executor
{
	/// <summary>
	/// This class stores the configuration information for the Alchemi Executor
	/// This includes information such as the manager host and port to connect to, 
	/// whether this node is dedicated or not. The authentication details to connect
	/// to the manager etc.
	/// </summary>
    public class Configuration
    {
        [NonSerialized] private string ConfigFile = "";
        private const string ConfigFileName = "Alchemi.Executor.config.xml";

		/// <summary>
		/// Executor Id
		/// </summary>
        public string[] Id;
		/// <summary>
		/// Host of the Manager
		/// </summary>
        public string ManagerHost = "localhost";
		/// <summary>
		/// Port of the Manager
		/// </summary>
        public int ManagerPort = 9000;
		/// <summary>
		/// Specifies whether the Eexecutor is dedicated
		/// </summary>
        public bool Dedicated = true;
		/// <summary>
		/// Specifies the port on which the Executor listens for messages.
		/// </summary>
        public int OwnPort = 9001;
		/// <summary>
		/// Specifies if the Executor connected successfully with the current settings for the ManagerHost,ManagerPort
		/// </summary>
        public bool ConnectVerified = false;
		/// <summary>
		/// Username for connection to the Manager
		/// </summary>
        public string Username = "executor";
		/// <summary>
		/// Password for connection to the Manager
		/// </summary>
        public string Password = "executor";

		/// <summary>
		/// Time interval (in seconds) between "heartbeats", ie. pinging the Manager to notify that this Executor is alive.
		/// </summary>
		public int HeartBeatInterval = 5; //seconds
		
		/// <summary>
		/// Number of times to retry connecting, if the connection to the Manager is lost
		/// </summary>
		public bool RetryConnect = true; //retry connecting to manager on disconnection

		/// <summary>
		/// Time interval between successive connection retries
		/// </summary>
		public int RetryInterval = 30; //seconds

		/// <summary>
		/// Maximum number of times to retry connecting
		/// </summary>
		public int RetryMax = 3; //try reconnecting max 3 times

//		/// <summary>
//		/// Specifies whether to revert to non-dedicated executor mode, if the Manager cannot be contacted in dedicatd mode.
//		/// </summary> 
//		public bool RevertToNDE = false; //not needed?
    
        //-----------------------------------------------------------------------------------------------
    
		/// <summary>
		/// Returns the configuration read from the xml file: "Alchemi.Executor.config.xml"
		/// </summary>
		/// <returns>Configuration object</returns>
		public static Configuration GetConfiguration()
        {
            return DeSlz(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigFileName));
        }

		/// <summary>
		/// Returns the configuration read from the xml file ("Alchemi.Executor.config.xml") at the given location
		/// </summary>
		/// <param name="location">Location of the config file</param>
		/// <returns>Configuration object</returns>
        public static Configuration GetConfiguration(string location)
        {
            return DeSlz(Path.Combine(location, ConfigFileName));
        }
    
		/// <summary>
		/// Creates an instance of the Configuration class.
		/// </summary>
        public Configuration()
        {
            ConfigFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigFileName);
        }

		//Code added by Rodrigo Assirati Dias
		/* Log 12/03, 2004
		 * Modifyied by Rodrigo Assirati Dias (rdias@ime.usp.br)
		 * Created additional constructor for Configuration class, to enable a windows service to create
		 * a configuration file in other directory than the running application directory (%WINDOWSDIR%/System32 to services)
		 */
		/// <summary>
		/// Creates an instance of the Configuration class.
		/// </summary>
		/// <param name="location"></param>
		public Configuration(string location)
		{
			ConfigFile = location + ConfigFileName;
		}

        //-----------------------------------------------------------------------------------------------
    
		/// <summary>
		///  Serialises and saves the configuration to the xml file: "Alchemi.Executor.config.xml"
		/// </summary>
		public void Slz()
        {
			XmlSerializer xs = new XmlSerializer(typeof(Configuration));
            StreamWriter sw = new StreamWriter(ConfigFile);
            xs.Serialize(sw, this);
            sw.Close();
        }

        //-----------------------------------------------------------------------------------------------

		/// <summary>
		/// Deserialises and reads the configuration from the given xml file
		/// </summary>
		/// <param name="file">Name of the config file</param>
		/// <returns>Configuration object</returns>
		private static Configuration DeSlz(string file)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Configuration));
            FileStream fs = new FileStream(file, FileMode.Open);
            Configuration temp = (Configuration) xs.Deserialize(fs);
            fs.Close();
            temp.ConfigFile = file;
            return temp;
        }

		/// <summary>
		/// Get the number of Executor IDs.
		/// </summary>
		/// <returns></returns>
		public int GetIdCount()
		{
			if (Id == null)
			{
				return 0;
			}

			return Id.Length;
		}

		/// <summary>
		/// Get the executor Id at a given location in the Id array.
		/// </summary>
		/// <param name="location"></param>
		/// <returns></returns>
		public string GetIdAtLocation(int location)
		{
			if (Id == null || Id.Length < location + 1 || Id[location] == null)
			{
				return String.Empty;
			}

			return Id[location];
		}

		/// <summary>
		/// Set an executor Id at the given location.
		/// </summary>
		/// <param name="location"></param>
		/// <param name="newId"></param>
		public void SetIdAtLocation(int location, string newId)
		{
			// initialize if not already set
			if (Id == null)
			{
				Id = new string[location + 1];
			}

			// resize if needed
			if (Id.Length < location + 1)
			{
				string[] tempIds = new string[location + 1];

				for(int index = 0; index < Id.Length; index++)
				{
					tempIds[index] = Id[index];
				}

				Id = tempIds;
			}

			Id[location] = newId;
		}
    }
}
