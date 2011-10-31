#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  Starter.cs
* Project       :  Alchemi.ManagerUtils.DbSetup
* Created on    :  18 January 2005
* Copyright     :  Copyright © 2005 The University of Melbourne
*                    This technology has been developed with the support of
*                    the Australian Research Council and the University of Melbourne
*                    research grants as part of the Gridbus Project
*                    within GRIDS Laboratory at the University of Melbourne, Australia.
* Author        :  Tibor Biro (tb@tbiro.com)
* License       :  GPL
*                    This program is free software; you can redistribute it and/or
*                    modify it under the terms of the GNU General Public
*                    License as published by the Free Software Foundation;
*                    See the GNU General Public License
*                    (http://www.gnu.org/copyleft/gpl.html) for more 
details.
*
*/
#endregion

using System;
using System.Windows.Forms;

namespace Alchemi.ManagerUtils.DbSetup
{
	/// <summary>
	/// Starting up the application and parsing out the command line parameters.
	/// </summary>
	public class Starter
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args) 
		{
			string installLocation = null;

			if (args.Length >= 1)
			{
				installLocation = args[0];  
			}

			Application.EnableVisualStyles();

			Application.Run(new Installer(installLocation));
		}

	}
}
