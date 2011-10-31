#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	Global.asax.cs
* Project		:	Alchemi CrossPlatform Manager Webservice
* Created on	:	2003
* Copyright		:	Copyright © 2005 The University of Melbourne
*					This technology has been developed with the support of 
*					the Australian Research Council and the University of Melbourne
*					research grants as part of the Gridbus Project
*					within GRIDS Laboratory at the University of Melbourne, Australia.
* Author         :  Akshay Luther (akshayl@cs.mu.oz.au), Rajkumar Buyya (raj@cs.mu.oz.au) and Krishna Nadiminti (kna@cs.mu.oz.au) 
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
using System.Web;

using log4net;

// Configure log4net using the .config file
[assembly: log4net.Config.XmlConfigurator(Watch=true)]

namespace Alchemi.CrossPlatformManager 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : HttpApplication
	{
		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{
			// Initialise the logging when the application loads
			//log4net.Config.XmlConfigurator.Configure();
		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_Error(Object sender, EventArgs e)
		{

		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}
			
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
		}
		#endregion
	}
}

