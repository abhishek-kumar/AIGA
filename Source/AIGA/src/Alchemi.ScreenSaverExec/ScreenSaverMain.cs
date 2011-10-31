#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	AssemblyInfo.cs
* Project		:	Alchemi ScreenSaver Executor
* Created on	:	2003
* Copyright		:	Copyright © 2006 The University of Melbourne
*					This technology has been developed with the support of 
*					the Australian Research Council and the University of Melbourne
*					research grants as part of the Gridbus Project
*					within GRIDS Laboratory at the University of Melbourne, Australia.
* Author         :  Akshay Luther (akshayl@cs.mu.oz.au) and Rajkumar Buyya (raj@cs.mu.oz.au)
* License        :  GPL
*					This program is free software; you can redistribute it and/or 
*					modify it under the terms of the GNU General Public
*					License as published by the Free Software Foundation;
*					See the GNU General Public License 
*					(http://www.gnu.org/copyleft/gpl.html) for more details.
*
*/ 
#endregion


// http://www.codeproject.com/csharp/scrframework.asp

using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Alchemi.ScreenSaverExec
{
    public class ScreenSaverMain
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0].ToLower().Trim().Substring(0,2) == "/c")
                {
                    MessageBox.Show("This screen saver has no options you can set.", "Alchemi Screen Saver", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (args[0].ToLower() == "/s")
                {
                    for (int i = Screen.AllScreens.GetLowerBound(0); i <= Screen.AllScreens.GetUpperBound(0); i++) 
                        System.Windows.Forms.Application.Run(new ScreenSaverForm(i));				
                }
            }
            else
            {
                for (int i = Screen.AllScreens.GetLowerBound(0); i <= Screen.AllScreens.GetUpperBound(0); i++)
                {
                    System.Windows.Forms.Application.Run(new ScreenSaverForm(i));				
                }
            }
        }
    }
}
