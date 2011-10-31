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
	public enum DataFormModeEnum
	{
		Add,
		Edit,
		Properties
	}

	public enum SpecialParentNodeType
	{
		None,
		Users,
		Groups,
		Permissions,
		Auth,
		Executors,
		Applications,
		AllApps
	}

	//a dummy node is there just for having a '+' for its parent. It doesnt have any text.
	public class DummyTreeNode : TreeNode
	{

		public DummyTreeNode(String text) : base("")
		{
		}

		public DummyTreeNode (String text, Int32 imageIndex,  Int32 selectedImageIndex ) : base("", imageIndex, selectedImageIndex)
		{
		}

	}

	public class SpecialParentNode : TreeNode
	{
		private SpecialParentNodeType _NodeType = SpecialParentNodeType.None; 
		private bool _Fillable = false;

		public bool Fillable //if true, will get data from the manager.
		{
			get
			{
				return _Fillable;
			}
		}

		public SpecialParentNodeType NodeType
		{
			get
			{
				return _NodeType;	
			}
			set
			{
				_NodeType = value;
				switch (_NodeType)
				{
					case SpecialParentNodeType.Applications:
					case SpecialParentNodeType.Users :
					case SpecialParentNodeType.Groups :
					case SpecialParentNodeType.Permissions :
					case SpecialParentNodeType.Executors :
						_Fillable = true;
					break;
					default:
						_Fillable = false;
					break;
				}
			}
		}


		public SpecialParentNode(String text) : base(text)
		{
		}

		public SpecialParentNode (String text, Int32 imageIndex,  Int32 selectedImageIndex ) : base(text, imageIndex, selectedImageIndex)
		{
		}

	}

	public class ApplicationTreeNode : SpecialParentNode
	{
		public ApplicationStorageView AlchemiApplication;

		public ApplicationTreeNode(String text) : base(text)
		{
			this.NodeType = SpecialParentNodeType.Applications;
		}

		public ApplicationTreeNode (String text, Int32 imageIndex,  Int32 selectedImageIndex ) : base(text, imageIndex, selectedImageIndex)
		{
			this.NodeType = SpecialParentNodeType.Applications;
		}

	}

}
