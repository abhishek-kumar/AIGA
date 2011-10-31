#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	ProjectInstaller.cs
* Project		:	Alchemi Manager Service
* Created on	:	August 2005
* Copyright		:	Copyright © 2006 The University of Melbourne
*					This technology has been developed with the support of 
*					the Australian Research Council and the University of Melbourne
*					research grants as part of the Gridbus Project
*					within GRIDS Laboratory at the University of Melbourne, Australia.
* Author         :  Krishna Nadiminti (kna@csse.unimelb.edu.au) and Rajkumar Buyya (raj@csse.unimelb.edu.au)
* License        :  GPL
*					This program is free software; you can redistribute it and/or 
*					modify it under the terms of the GNU General Public
*					License as published by the Free Software Foundation;
*					See the GNU General Public License 
*					(http://www.gnu.org/copyleft/gpl.html) for more details.
*
*/ 
#endregion


using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace Alchemi.ManagerService
{
	/// <summary>
	/// Summary description for ProjectInstaller.
	/// </summary>
	[RunInstaller(true)]
	public class ProjectInstaller : Installer
	{
		private ServiceProcessInstaller serviceProcessInstaller1;
		private ServiceInstaller serviceInstaller1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public ProjectInstaller()
		{
			// This call is required by the Designer.
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.serviceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
			this.serviceInstaller1 = new System.ServiceProcess.ServiceInstaller();
			// 
			// serviceProcessInstaller1
			// 
			this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
			this.serviceProcessInstaller1.Password = null;
			this.serviceProcessInstaller1.Username = null;
			// 
			// serviceInstaller1
			// 
			this.serviceInstaller1.DisplayName = "Alchemi Manager Service";
			this.serviceInstaller1.ServiceName = "Alchemi Manager Service";
			this.serviceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
			// 
			// ProjectInstaller
			// 
			this.Installers.AddRange(new System.Configuration.Install.Installer[] {
																					  this.serviceProcessInstaller1,
																					  this.serviceInstaller1});

		}
		#endregion
	}
}
