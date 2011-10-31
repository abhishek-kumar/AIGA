using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace Alchemi.Updater
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

			// TODO: Add any initialization after the InitializeComponent call
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
			this.serviceInstaller1.DisplayName = "Alchemi Updater Service";
			this.serviceInstaller1.ServiceName = "Alchemi Updater Service";
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
