#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	ManagerServiceController.cs
* Project		:	Alchemi Manager Service Controller
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


using System;
using System.Windows.Forms;
using Alchemi.ManagerExec;

namespace Alchemi.ManagerService
{
	/// <summary>
	/// Summary description for ManagerServiceController.
	/// This class uses the ManagerMainForm which acts as the service controller for the ManagerService.
	/// </summary>
	public class ManagerServiceController
	{

		public ManagerServiceController()
		{
		}

		[STAThread]
		static void Main() 
		{
			Application.Run(new ManagerMainForm());
		}
	}
}
