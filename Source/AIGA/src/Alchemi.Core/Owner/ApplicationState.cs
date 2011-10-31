#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	ApplicationState.cs
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

namespace Alchemi.Core.Owner
{
    /// <summary>
    /// The possible states of a grid application.
	/// AwaitingManifest = 0<br/>
	/// Ready = 1<br/>
	/// Stopped = 2
    /// </summary>
    [Serializable]
    public enum ApplicationState
    {
		/// <summary>
		/// Application awaiting manifest.
		/// </summary>
        AwaitingManifest = 0,

		/// <summary>
		/// Application ready to be executed.
		/// </summary>
        Ready = 1,

		/// <summary>
		/// Application stopped.
		/// </summary>
        Stopped = 2
    }
}

