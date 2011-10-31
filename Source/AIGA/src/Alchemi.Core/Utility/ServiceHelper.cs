#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	ServiceHelper.cs
* Project		:	Alchemi Core
* Created on	:	August 2005
* Copyright		:	Copyright © 2006 The University of Melbourne
*					This technology has been developed with the support of 
*					the Australian Research Council and the University of Melbourne
*					research grants as part of the Gridbus Project
*					within GRIDS Laboratory at the University of Melbourne, Australia.
* Author         : Krishna Nadiminti (kna@csse.unimelb.edu.au) and Rajkumar Buyya (raj@csse.unimelb.edu.au)
* License        :  GPL
*					This program is free software; you can redistribute it and/or 
*					modify it under the terms of the GNU General Public
*					License as published by the Free Software Foundation;
*					See the GNU General Public License 
*					(http://www.gnu.org/copyleft/gpl.html) for more details.
*
*/ 
#endregion

using System.Collections;
using System.Configuration.Install;
using System.ServiceProcess;

namespace Alchemi.Core.Utility
{
	/// <summary>
	/// Summary description for ServiceHelper.
	/// </summary>
	public class ServiceHelper
	{

		/// <summary>
		/// Verifies if the Window service with the given name is installed.
		/// </summary>
		/// <param name="serviceName"></param>
		/// <returns>true if the service is installed properly. false otherwise</returns>
		public static bool checkServiceInstallation(string serviceName)
		{
			bool exists = false;
			try
			{
				ServiceController sc = new ServiceController(serviceName);
				sc.Refresh(); //just a dummy call to make sure the service exists.
				sc.Close();
				sc = null;
				exists = true;
			}
			catch
			{}
			return exists;
		}

		/// <summary>
		/// Installs the Windows service with the given "installer" object.
		/// </summary>
		/// <param name="pi"></param>
		/// <param name="pathToService"></param>
		public static void installService(Installer pi, string pathToService)
		{
			TransactedInstaller ti = new TransactedInstaller ();
			ti.Installers.Add (pi);
			string[] cmdline = {pathToService};
			InstallContext ctx = new InstallContext ("Install.log", cmdline );
			ti.Context = ctx;
			ti.Install ( new Hashtable ());
		}
		/// <summary>
		/// UnInstalls the Windows service with the given "installer" object.
		/// </summary>
		/// <param name="pi"></param>
		/// <param name="pathToService"></param>
		public static void uninstallService(Installer pi, string pathToService)
		{
			TransactedInstaller ti = new TransactedInstaller ();
			ti.Installers.Add (pi);
			string[] cmdline = {pathToService};
			InstallContext ctx = new InstallContext ("Uninstall.log", cmdline );
			ti.Context = ctx;
			ti.Uninstall ( null );
		}
	}
}
