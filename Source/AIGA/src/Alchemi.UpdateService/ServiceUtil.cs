#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* 
* Title			:	ServiceUtil.cs
* Project		:	Alchemi Updater Service
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
using System.IO;
using Microsoft.Win32.Security;


//even though this class belongs to the Core namespace, we dont put it in the Manager/Executor-Service project,
//and link it in the Manager/Executor-Service since we dont want a dependency on the Win32.Security dll in the core dll.
//this is so far used only in the Service projects.
//with .Net 2.0 this will be in the base-class-lib.
namespace Alchemi.Core.Utility
{
	/// <summary>
	/// Summary description for Util.
	/// </summary>
	public class ServiceUtil
	{
		public static Boolean CreateDir(String strSitePath, String strUserName) 
		{
			Boolean bOk;
			try 
			{
				Directory.CreateDirectory(strSitePath);
				SecurityDescriptor secDesc = SecurityDescriptor.GetFileSecurity(strSitePath, SECURITY_INFORMATION.DACL_SECURITY_INFORMATION);
				Dacl dacl = secDesc.Dacl;
				Sid sidUser = new Sid (strUserName);
 
				// allow: folder, subfolder and files
				// modify
				dacl.AddAce (new AceAccessAllowed (sidUser, AccessType.GENERIC_WRITE | AccessType.GENERIC_READ | AccessType.DELETE | AccessType.GENERIC_EXECUTE , AceFlags.OBJECT_INHERIT_ACE | AceFlags.CONTAINER_INHERIT_ACE));          

				// deny: this folder
				// write attribs
				// write extended attribs
				// delete
				// change permissions
				// take ownership
				DirectoryAccessType DAType = DirectoryAccessType.FILE_WRITE_ATTRIBUTES | DirectoryAccessType.FILE_WRITE_EA | DirectoryAccessType.DELETE | DirectoryAccessType.WRITE_OWNER | DirectoryAccessType.WRITE_DAC;
				AccessType AType = (AccessType)DAType;
				dacl.AddAce (new AceAccessDenied (sidUser, AType));
				secDesc.SetDacl(dacl);
				secDesc.SetFileSecurity(strSitePath, SECURITY_INFORMATION.DACL_SECURITY_INFORMATION);
				bOk = true;
			} 
			catch 
			{
				bOk = false;
			}
			return bOk;
		} /* CreateDir */

	}
}
