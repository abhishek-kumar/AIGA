#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	CustomTreeNodes.cs
* Project		:	Alchemi Console
* Created on	:	Sep 2006
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
using Alchemi.Core.Manager.Storage;

namespace Alchemi.Console
{

	public class ApplicationItem : ListViewItem
	{
		public ApplicationStorageView AlchemiApplication;

		public ApplicationItem(string text): base(text)
		{
		}
	}

	public class ThreadItem : ListViewItem
	{
		public ThreadStorageView AlchemiThread;

		public ThreadItem(string text) : base(text)
		{
		}
	}

	public class ExecutorItem : ListViewItem
	{
		public ExecutorStorageView Executor;

		public ExecutorItem(string text) : base(text)
		{
		}
	}

	public class UserItem : ListViewItem
	{
		public UserStorageView User;

		public UserItem(String text) : base(text)
		{
		}
	}

	public class GroupItem : ListViewItem
	{
		public GroupStorageView GroupView;

		public GroupItem(String text) : base(text)
		{
		}
	}

	public class PermissionItem : ListViewItem
	{
		public PermissionStorageView Permission;

		public PermissionItem(String text) : base(text)
		{
		}
	}
}
