#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title			:	ConsoleForm.cs
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
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Alchemi.Console.PropertiesDialogs;
using Alchemi.Core;
using Alchemi.Core.Manager;
using Alchemi.Core.Manager.Storage;
using Alchemi.Core.Owner;

namespace Alchemi.Console
{
	/// <summary>
	/// Summary description for ConsoleForm.
	/// </summary>
	public class ConsoleForm : Form
	{
		private enum ViewState
		{
			User,
			Group,
			Permission,
			Executor,
			Application,
			Thread,
			None
		}

		private const int MAGIC_ITEM_NUMBER = 699;

		private bool connected = false;
		private ConsoleNode console = null;
		private SysPerfForm sysForm = null;

		//we need to keep a reference to these nodes, since they are special and 
		//need to be access across functions
		private SpecialParentNode authParentNode;
		private SpecialParentNode userParentNode;
		private SpecialParentNode grpParentNode;
		private SpecialParentNode prmParentNode;

		private SpecialParentNode execParentNode;
		private SpecialParentNode appParentNode;

		private bool filling = false; //filling property - specifies if filling is currently happening
		private bool stopFillingRequest = false; //specifies if the stopFilling command has been called.

		// Create a logger for use in this class
		private static readonly Logger logger = new Logger();

		private IContainer components;

		private ImageList imgListSmall;
		private ImageList imgListBig;

		//menus
		private MainMenu mainMenu1;
		private MenuItem mnuView;
		private MenuItem mnuAction;
		//context-menu
		private ContextMenu rightClickMenu;
		private MenuItem mnuContextView;
		private StatusBar sbar;
		private MenuItem mnuLargeIcons;
		private MenuItem mnuSmallIcons;
		private MenuItem mnuList;
		private MenuItem mnuDetails;
		private MenuItem mnuContextNew;
		private MenuItem mnuContextLargeIcons;
		private MenuItem mnuContextSmallIcons;
		private MenuItem mnuContextList;
		private MenuItem mnuContextDetails;
		private MenuItem mnuContextProperties;
		private MenuItem mnuNew;
		private MenuItem mnuDelete;
		private MenuItem mnuProperties;
		private MenuItem mnuContextDelete;
		private TreeView tv;
		private Splitter split;
		private ListView lv;
		private ToolBarButton tbtnProperties;
		private ToolBarButton tbtnRefresh;
		private ToolBarButton tbtnNew;
		private ToolBarButton tbtnDelete;
		private ToolBarButton tbtnSep1;
		private ToolBar tbar;
		private ToolBarButton tbtnSep2;
		private ImageList imgLstTbar;
		private ColumnHeader ch1;
		private ColumnHeader ch2;
		private ToolBarButton tbtnConnect;
		private ToolBarButton tbtnSep3;
		private ToolBarButton tbtnSysSummaryGraph;
        private ToolBarButton tbtnStop;
        private MenuItem mnuStorageMaintenance;
        private MenuItem mnuTools;
		private MenuItem mnuContextAction;

		public ConsoleForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			InitTreeView();

            ShowMenuItems();
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

				if (sysForm!=null)
				{
					sysForm.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsoleForm));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.mnuAction = new System.Windows.Forms.MenuItem();
            this.mnuNew = new System.Windows.Forms.MenuItem();
            this.mnuDelete = new System.Windows.Forms.MenuItem();
            this.mnuProperties = new System.Windows.Forms.MenuItem();
            this.mnuTools = new System.Windows.Forms.MenuItem();
            this.mnuStorageMaintenance = new System.Windows.Forms.MenuItem();
            this.mnuView = new System.Windows.Forms.MenuItem();
            this.mnuLargeIcons = new System.Windows.Forms.MenuItem();
            this.mnuSmallIcons = new System.Windows.Forms.MenuItem();
            this.mnuList = new System.Windows.Forms.MenuItem();
            this.mnuDetails = new System.Windows.Forms.MenuItem();
            this.mnuContextNew = new System.Windows.Forms.MenuItem();
            this.mnuContextDelete = new System.Windows.Forms.MenuItem();
            this.mnuContextLargeIcons = new System.Windows.Forms.MenuItem();
            this.mnuContextSmallIcons = new System.Windows.Forms.MenuItem();
            this.mnuContextList = new System.Windows.Forms.MenuItem();
            this.mnuContextDetails = new System.Windows.Forms.MenuItem();
            this.rightClickMenu = new System.Windows.Forms.ContextMenu();
            this.mnuContextView = new System.Windows.Forms.MenuItem();
            this.mnuContextAction = new System.Windows.Forms.MenuItem();
            this.mnuContextProperties = new System.Windows.Forms.MenuItem();
            this.imgListBig = new System.Windows.Forms.ImageList(this.components);
            this.imgListSmall = new System.Windows.Forms.ImageList(this.components);
            this.sbar = new System.Windows.Forms.StatusBar();
            this.tbar = new System.Windows.Forms.ToolBar();
            this.tbtnConnect = new System.Windows.Forms.ToolBarButton();
            this.tbtnRefresh = new System.Windows.Forms.ToolBarButton();
            this.tbtnSep1 = new System.Windows.Forms.ToolBarButton();
            this.tbtnNew = new System.Windows.Forms.ToolBarButton();
            this.tbtnDelete = new System.Windows.Forms.ToolBarButton();
            this.tbtnSep2 = new System.Windows.Forms.ToolBarButton();
            this.tbtnProperties = new System.Windows.Forms.ToolBarButton();
            this.tbtnSep3 = new System.Windows.Forms.ToolBarButton();
            this.tbtnSysSummaryGraph = new System.Windows.Forms.ToolBarButton();
            this.tbtnStop = new System.Windows.Forms.ToolBarButton();
            this.imgLstTbar = new System.Windows.Forms.ImageList(this.components);
            this.tv = new System.Windows.Forms.TreeView();
            this.split = new System.Windows.Forms.Splitter();
            this.lv = new System.Windows.Forms.ListView();
            this.ch1 = new System.Windows.Forms.ColumnHeader();
            this.ch2 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuAction,
            this.mnuTools,
            this.mnuView});
            // 
            // mnuAction
            // 
            this.mnuAction.Index = 0;
            this.mnuAction.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuNew,
            this.mnuDelete,
            this.mnuProperties});
            this.mnuAction.Text = "Action";
            // 
            // mnuNew
            // 
            this.mnuNew.Index = 0;
            this.mnuNew.Text = "New...";
            this.mnuNew.Click += new System.EventHandler(this.mnuAction_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Index = 1;
            this.mnuDelete.Text = "Delete";
            this.mnuDelete.Click += new System.EventHandler(this.mnuAction_Click);
            // 
            // mnuProperties
            // 
            this.mnuProperties.Index = 2;
            this.mnuProperties.Text = "Properties";
            this.mnuProperties.Click += new System.EventHandler(this.mnuAction_Click);
            // 
            // mnuTools
            // 
            this.mnuTools.Index = 1;
            this.mnuTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuStorageMaintenance});
            this.mnuTools.Text = "Tools";
            // 
            // mnuStorageMaintenance
            // 
            this.mnuStorageMaintenance.Index = 0;
            this.mnuStorageMaintenance.Text = "Storage Maintenance";
            this.mnuStorageMaintenance.Click += new System.EventHandler(this.mnuStorageMaintenance_Click);
            // 
            // mnuView
            // 
            this.mnuView.Index = 2;
            this.mnuView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuLargeIcons,
            this.mnuSmallIcons,
            this.mnuList,
            this.mnuDetails});
            this.mnuView.Text = "View";
            // 
            // mnuLargeIcons
            // 
            this.mnuLargeIcons.Index = 0;
            this.mnuLargeIcons.Text = "Large Icons";
            this.mnuLargeIcons.Click += new System.EventHandler(this.mnuView_Click);
            // 
            // mnuSmallIcons
            // 
            this.mnuSmallIcons.Index = 1;
            this.mnuSmallIcons.Text = "Small Icons";
            this.mnuSmallIcons.Click += new System.EventHandler(this.mnuView_Click);
            // 
            // mnuList
            // 
            this.mnuList.Index = 2;
            this.mnuList.Text = "List";
            this.mnuList.Click += new System.EventHandler(this.mnuView_Click);
            // 
            // mnuDetails
            // 
            this.mnuDetails.Index = 3;
            this.mnuDetails.Text = "Details";
            this.mnuDetails.Click += new System.EventHandler(this.mnuView_Click);
            // 
            // mnuContextNew
            // 
            this.mnuContextNew.Index = 0;
            this.mnuContextNew.Text = "New...";
            this.mnuContextNew.Click += new System.EventHandler(this.mnuAction_Click);
            // 
            // mnuContextDelete
            // 
            this.mnuContextDelete.Index = 1;
            this.mnuContextDelete.Text = "Delete";
            this.mnuContextDelete.Click += new System.EventHandler(this.mnuAction_Click);
            // 
            // mnuContextLargeIcons
            // 
            this.mnuContextLargeIcons.Index = 0;
            this.mnuContextLargeIcons.Text = "Large Icons";
            this.mnuContextLargeIcons.Click += new System.EventHandler(this.mnuView_Click);
            // 
            // mnuContextSmallIcons
            // 
            this.mnuContextSmallIcons.Index = 1;
            this.mnuContextSmallIcons.Text = "Small Icons";
            this.mnuContextSmallIcons.Click += new System.EventHandler(this.mnuView_Click);
            // 
            // mnuContextList
            // 
            this.mnuContextList.Index = 2;
            this.mnuContextList.Text = "List";
            this.mnuContextList.Click += new System.EventHandler(this.mnuView_Click);
            // 
            // mnuContextDetails
            // 
            this.mnuContextDetails.Index = 3;
            this.mnuContextDetails.Text = "Details";
            this.mnuContextDetails.Click += new System.EventHandler(this.mnuView_Click);
            // 
            // rightClickMenu
            // 
            this.rightClickMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuContextView,
            this.mnuContextAction,
            this.mnuContextProperties});
            // 
            // mnuContextView
            // 
            this.mnuContextView.Index = 0;
            this.mnuContextView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuContextLargeIcons,
            this.mnuContextSmallIcons,
            this.mnuContextList,
            this.mnuContextDetails});
            this.mnuContextView.Text = "View";
            // 
            // mnuContextAction
            // 
            this.mnuContextAction.Index = 1;
            this.mnuContextAction.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuContextNew,
            this.mnuContextDelete});
            this.mnuContextAction.Text = "Action";
            // 
            // mnuContextProperties
            // 
            this.mnuContextProperties.Index = 2;
            this.mnuContextProperties.Text = "Properties";
            this.mnuContextProperties.Click += new System.EventHandler(this.mnuAction_Click);
            // 
            // imgListBig
            // 
            this.imgListBig.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListBig.ImageStream")));
            this.imgListBig.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListBig.Images.SetKeyName(0, "");
            this.imgListBig.Images.SetKeyName(1, "");
            this.imgListBig.Images.SetKeyName(2, "");
            this.imgListBig.Images.SetKeyName(3, "");
            this.imgListBig.Images.SetKeyName(4, "");
            this.imgListBig.Images.SetKeyName(5, "");
            this.imgListBig.Images.SetKeyName(6, "");
            this.imgListBig.Images.SetKeyName(7, "");
            this.imgListBig.Images.SetKeyName(8, "");
            this.imgListBig.Images.SetKeyName(9, "");
            this.imgListBig.Images.SetKeyName(10, "");
            this.imgListBig.Images.SetKeyName(11, "");
            this.imgListBig.Images.SetKeyName(12, "");
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListSmall.Images.SetKeyName(0, "");
            this.imgListSmall.Images.SetKeyName(1, "");
            this.imgListSmall.Images.SetKeyName(2, "");
            this.imgListSmall.Images.SetKeyName(3, "");
            this.imgListSmall.Images.SetKeyName(4, "");
            this.imgListSmall.Images.SetKeyName(5, "");
            this.imgListSmall.Images.SetKeyName(6, "");
            this.imgListSmall.Images.SetKeyName(7, "");
            this.imgListSmall.Images.SetKeyName(8, "");
            this.imgListSmall.Images.SetKeyName(9, "");
            this.imgListSmall.Images.SetKeyName(10, "");
            this.imgListSmall.Images.SetKeyName(11, "");
            this.imgListSmall.Images.SetKeyName(12, "");
            // 
            // sbar
            // 
            this.sbar.Location = new System.Drawing.Point(0, 559);
            this.sbar.Name = "sbar";
            this.sbar.Size = new System.Drawing.Size(864, 22);
            this.sbar.TabIndex = 0;
            // 
            // tbar
            // 
            this.tbar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.tbar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tbtnConnect,
            this.tbtnRefresh,
            this.tbtnSep1,
            this.tbtnNew,
            this.tbtnDelete,
            this.tbtnSep2,
            this.tbtnProperties,
            this.tbtnSep3,
            this.tbtnSysSummaryGraph,
            this.tbtnStop});
            this.tbar.DropDownArrows = true;
            this.tbar.ImageList = this.imgLstTbar;
            this.tbar.Location = new System.Drawing.Point(0, 0);
            this.tbar.Name = "tbar";
            this.tbar.ShowToolTips = true;
            this.tbar.Size = new System.Drawing.Size(864, 28);
            this.tbar.TabIndex = 4;
            this.tbar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbar_ButtonClick);
            // 
            // tbtnConnect
            // 
            this.tbtnConnect.ImageIndex = 4;
            this.tbtnConnect.Name = "tbtnConnect";
            this.tbtnConnect.ToolTipText = "Connect...";
            // 
            // tbtnRefresh
            // 
            this.tbtnRefresh.ImageIndex = 1;
            this.tbtnRefresh.Name = "tbtnRefresh";
            this.tbtnRefresh.ToolTipText = "Refresh";
            // 
            // tbtnSep1
            // 
            this.tbtnSep1.Name = "tbtnSep1";
            this.tbtnSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbtnNew
            // 
            this.tbtnNew.ImageIndex = 0;
            this.tbtnNew.Name = "tbtnNew";
            this.tbtnNew.ToolTipText = "New...";
            // 
            // tbtnDelete
            // 
            this.tbtnDelete.ImageIndex = 2;
            this.tbtnDelete.Name = "tbtnDelete";
            this.tbtnDelete.ToolTipText = "Delete...";
            // 
            // tbtnSep2
            // 
            this.tbtnSep2.Name = "tbtnSep2";
            this.tbtnSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbtnProperties
            // 
            this.tbtnProperties.ImageIndex = 3;
            this.tbtnProperties.Name = "tbtnProperties";
            this.tbtnProperties.ToolTipText = "Properties";
            // 
            // tbtnSep3
            // 
            this.tbtnSep3.Name = "tbtnSep3";
            this.tbtnSep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbtnSysSummaryGraph
            // 
            this.tbtnSysSummaryGraph.ImageIndex = 6;
            this.tbtnSysSummaryGraph.Name = "tbtnSysSummaryGraph";
            this.tbtnSysSummaryGraph.ToolTipText = "System Performance Summary";
            // 
            // tbtnStop
            // 
            this.tbtnStop.ImageIndex = 7;
            this.tbtnStop.Name = "tbtnStop";
            this.tbtnStop.ToolTipText = "Stop";
            this.tbtnStop.Visible = false;
            // 
            // imgLstTbar
            // 
            this.imgLstTbar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLstTbar.ImageStream")));
            this.imgLstTbar.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLstTbar.Images.SetKeyName(0, "");
            this.imgLstTbar.Images.SetKeyName(1, "");
            this.imgLstTbar.Images.SetKeyName(2, "");
            this.imgLstTbar.Images.SetKeyName(3, "");
            this.imgLstTbar.Images.SetKeyName(4, "");
            this.imgLstTbar.Images.SetKeyName(5, "");
            this.imgLstTbar.Images.SetKeyName(6, "");
            this.imgLstTbar.Images.SetKeyName(7, "");
            // 
            // tv
            // 
            this.tv.Dock = System.Windows.Forms.DockStyle.Left;
            this.tv.HideSelection = false;
            this.tv.ImageIndex = 0;
            this.tv.ImageList = this.imgListSmall;
            this.tv.Location = new System.Drawing.Point(0, 28);
            this.tv.Name = "tv";
            this.tv.SelectedImageIndex = 0;
            this.tv.Size = new System.Drawing.Size(224, 531);
            this.tv.TabIndex = 5;
            this.tv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterSelect);
            this.tv.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterExpand);
            // 
            // split
            // 
            this.split.Location = new System.Drawing.Point(224, 28);
            this.split.Name = "split";
            this.split.Size = new System.Drawing.Size(3, 531);
            this.split.TabIndex = 6;
            this.split.TabStop = false;
            // 
            // lv
            // 
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch1,
            this.ch2});
            this.lv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv.FullRowSelect = true;
            this.lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv.HideSelection = false;
            this.lv.LargeImageList = this.imgListBig;
            this.lv.Location = new System.Drawing.Point(227, 28);
            this.lv.MultiSelect = false;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(637, 531);
            this.lv.SmallImageList = this.imgListSmall;
            this.lv.TabIndex = 7;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.DoubleClick += new System.EventHandler(this.lv_DoubleClick);
            this.lv.SelectedIndexChanged += new System.EventHandler(this.lv_SelectedIndexChanged);
            // 
            // ch1
            // 
            this.ch1.Text = "Name";
            this.ch1.Width = 250;
            // 
            // ch2
            // 
            this.ch2.Text = "";
            this.ch2.Width = 150;
            // 
            // ConsoleForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(864, 581);
            this.Controls.Add(this.lv);
            this.Controls.Add(this.split);
            this.Controls.Add(this.tv);
            this.Controls.Add(this.tbar);
            this.Controls.Add(this.sbar);
            this.Menu = this.mainMenu1;
            this.Name = "ConsoleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alchemi Console";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.ConsoleForm_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
	
		private void RefreshUI()
		{
			if (connected)
			{
				sbar.Text = string.Format("Connected to grid as {0}@{1}:{2}.", console.Credentials.Username, console.Connection.Host, console.Connection.Port);
			}
			else
			{
				sbar.Text = "Not connected.";
				if (sysForm!=null)
				{
					sysForm.Dispose();
				}
				sysForm = null;
			}

			SetColumnHeaders();
			SetMenuState();
			SetToolbarState();

			this.Refresh();
		}

		private ViewState GetViewState()
		{
			ViewState view = ViewState.None;
			
			//set the state based on the listview selected item.
			if (lv.SelectedItems != null && lv.SelectedItems.Count>0)
			{
				ListViewItem li = lv.SelectedItems[0];
				if (li is UserItem)
					view = ViewState.User;
				else if (li is GroupItem)
					view = ViewState.Group;
				else if (li is PermissionItem)
					view = ViewState.Permission;
				else if (li is ExecutorItem)
					view = ViewState.Executor;
				else if (li is ApplicationItem)
					view = ViewState.Application;
				else if (li is ThreadItem)
					view = ViewState.Thread;
			}
			else
			{
				//nothing in the list is selected OR there are no list items
				TreeNode node = tv.SelectedNode;
				if (node!=null && node is SpecialParentNode)
				{
					SpecialParentNode spn = (SpecialParentNode)node;
					if (spn.NodeType == SpecialParentNodeType.Users)
						view = ViewState.User;
					else if (spn.NodeType == SpecialParentNodeType.Groups)
						view = ViewState.Group;
					else if (spn.NodeType == SpecialParentNodeType.Applications)
						view = ViewState.Application;
					else if (spn.NodeType == SpecialParentNodeType.Executors)
						view = ViewState.Executor;
				}
			}

			return view;
		}

		private void SetMenuState()
		{

			ViewState view = GetViewState();
			
			if (view == ViewState.None)
			{
				//enable the add/edit/delete menus.
				mnuNew.Enabled = false;
				mnuDelete.Enabled = false;
				mnuProperties.Enabled = false;

				mnuContextNew.Enabled = false;
				mnuContextDelete.Enabled = false;
				mnuContextProperties.Enabled = false;

				mnuNew.Text = "New ...";
				mnuDelete.Text = "Delete ...";
			}
			else 
			{
				if (view==ViewState.User || view==ViewState.Group)
				{
					mnuNew.Enabled = true;	
					mnuContextNew.Enabled = true;

				}

				//we can delete users, groups, threads and appications.
				if (lv.SelectedItems.Count>0 && 
					(view==ViewState.User || view==ViewState.Group || view==ViewState.Application || view==ViewState.Thread))
				{
					mnuDelete.Enabled = true;
					mnuContextDelete.Enabled = true;
				}

				if (view==ViewState.User)
				{
					mnuNew.Text = "New User...";
					mnuDelete.Text = "Delete User...";
				}
				else if (view==ViewState.Group)
				{
					mnuNew.Text = "New Group...";
					mnuDelete.Text = "Delete Group...";										
				}

				mnuProperties.Enabled = true;
				mnuContextProperties.Enabled = true;
			}

			//todo also right click menus events
		}

		private void SetToolbarState()
		{
			if (connected)
			{
				tbtnConnect.ImageIndex = 5;
				tbtnConnect.ToolTipText = "Disconnect";
			}
			else
			{
				tbtnConnect.ImageIndex = 4;
				tbtnConnect.ToolTipText = "Connect...";
			}

			//assuming SetMenuState() has already been called.
			tbtnNew.Enabled = mnuNew.Enabled;
			tbtnDelete.Enabled = mnuDelete.Enabled;
			tbtnProperties.Enabled = mnuProperties.Enabled;

			tbtnNew.ToolTipText = mnuNew.Text;
			tbtnDelete.ToolTipText = mnuDelete.Text;
			tbtnProperties.ToolTipText = mnuProperties.Text;
		}

		private void SetColumnHeaders()
		{
			TreeNode node=null;
			//set the state based on the listview selected item.
			if (lv.SelectedItems != null && lv.SelectedItems.Count>0 && lv.SelectedItems[0]!=null)
			{
				node = (TreeNode)lv.SelectedItems[0].Tag;
			}

			if (node!=null)
			{
				lv.Columns[1].Width=200;
				if (node is SpecialParentNode)
				{
					SpecialParentNode spn = (SpecialParentNode)node;
					if (spn.NodeType == SpecialParentNodeType.Auth) 
					{
						lv.Columns[1].Text = "# of items";
					}
					else if (spn.NodeType == SpecialParentNodeType.Executors) 
					{
						lv.Columns[1].Text = "Host : Port";
					}
					else if (spn.NodeType == SpecialParentNodeType.Applications) 
					{
						lv.Columns[1].Text = "Application";
					}
					else
					{
						lv.Columns[1].Text = "";
						lv.Columns[1].Width=0;
					}
				}
				else 
				{
					lv.Columns[1].Text = "";
					lv.Columns[1].Width=0;
				}
			}
		}

		private void Connect()
		{
			try
			{
				GConnectionDialog gcd = new GConnectionDialog();
				if (gcd.ShowDialog() == DialogResult.OK)
				{
					console = new ConsoleNode(gcd.Connection);
					connected = true;
					InitTreeView();
				}

                ShowMenuItems();
			}
			catch (Exception ex)
			{
				logger.Error("Error trying to connect...", ex);
				MessageBox.Show("Error trying to connect..." + ex.Message);
			}
		}
		
		private void Disconnect()
		{
			if (filling)
			{
				StopFilling();
				WaitFilling();
			}
			console = null;
			connected = false;
			ShowDisconnectedMessage();
			RefreshUI();
		}

		private void WaitFilling()
		{
			while (filling)
			{
				Application.DoEvents();
			}
			SetFilling(false);
		}

		private void SetFilling(bool filling)
		{
			this.filling = filling;
			stopFillingRequest = false; //reset it, so that the current filling sequence wont stop
			//show the stop button, if it is filling
			tbtnStop.Visible = filling;
		}

		private void StopFilling()
		{
			//request to stop filling
			stopFillingRequest = true;
		}

		private void ShowDisconnectedMessage()
		{
			tv.Nodes.Clear();
			TreeNode node = new TreeNode();
			node.Text = "No connection available.";
			node.ImageIndex = 0;
			tv.Nodes.Add(node);
			
			lv.Items.Clear();
			ListViewItem li = new ListViewItem();
			li.Text = "No connection available.";
			li.ImageIndex = 0;
			lv.Items.Add(li);
			sbar.Text = "No connection available.";
		}

		private void InitTreeView()
		{
			tv.Nodes.Clear();
			if (connected)
			{
				//Add Console Root
				TreeNode root = new TreeNode("Console Root", 4, 4);

				userParentNode = new SpecialParentNode("Users", 1, 1);
				userParentNode.NodeType = SpecialParentNodeType.Users;

				grpParentNode = new SpecialParentNode("Groups", 1, 1);
				grpParentNode.NodeType = SpecialParentNodeType.Groups;

				prmParentNode = new SpecialParentNode("Permissions", 1, 1);
				prmParentNode.NodeType = SpecialParentNodeType.Permissions;

				authParentNode = new SpecialParentNode("Users and Groups", 8, 8);
				authParentNode.NodeType = SpecialParentNodeType.Auth;
				authParentNode.Nodes.Add(userParentNode);
				authParentNode.Nodes.Add(grpParentNode);
				authParentNode.Nodes.Add(prmParentNode);
				root.Nodes.Add(authParentNode);

				execParentNode = new SpecialParentNode("Executors", 9, 9);
				execParentNode.NodeType = SpecialParentNodeType.Executors;
				root.Nodes.Add(execParentNode);

				appParentNode = new SpecialParentNode("Applications", 10, 10);
				appParentNode.NodeType = SpecialParentNodeType.AllApps;
				appParentNode.Nodes.Add(new DummyTreeNode("", 999, 999));
				root.Nodes.Add(appParentNode);

				tv.Nodes.Add(root);
				tv.Refresh();

				lv.Items.Clear();
				lv.Refresh();
			}
			else
			{
				ShowDisconnectedMessage();
			}
			RefreshUI();
		}

		private void RefreshTreeNode(TreeNode node, bool refreshList)
		{
			//if the node is a special parent node do stuff here to fill its child nodes.
			if (node is SpecialParentNode)
			{
				SpecialParentNode spn = (SpecialParentNode) node;
				if (spn.NodeType == SpecialParentNodeType.AllApps)
				{
					FillApplicationsTree();
				}
			}

			if (refreshList)
				RefreshListItems(node);

		}

		private void RefreshListItems(TreeNode tnode)
		{
			if (!connected || filling || tnode==null)
				return;



			if (tnode.GetNodeCount(false)==0)
			{
				if (tnode is SpecialParentNode)
				{
					FillListItems(tnode as SpecialParentNode); //to fill final leaf items
				}
			}
			else
			{
				SetFilling(true);
				lv.Items.Clear();
				int itemCount = 0;
				//selected node has children
				foreach (TreeNode node in tnode.Nodes)
				{
					//add the node to the listview.
					ListViewItem li;
					
					//special cases.
					if (node is ApplicationTreeNode)
					{
						ApplicationTreeNode appNode = (ApplicationTreeNode)node;
						li = new ApplicationItem(node.Text);
						((ApplicationItem)li).AlchemiApplication = appNode.AlchemiApplication;
					}
					else
					{
						li = new ListViewItem(node.Text);
					}

					li.ImageIndex = node.ImageIndex;

					//store a reference to the tree-view node in the listview item's tag
					li.Tag = node;

					lv.Items.Add(li);

					itemCount++;
					if (itemCount >= MAGIC_ITEM_NUMBER)
					{
						itemCount = 0;
						Application.DoEvents(); //to make sure the GUI is responsive
					}
					//here just make sure the stop has not been called.
					if (stopFillingRequest)
					{
						break;
					}
				}				
				SetFilling(false);
			}
		}

		private void FillListItems(SpecialParentNode spn)
		{
			//fill the list with child items based on what type of node was passed in
			if (spn.NodeType == SpecialParentNodeType.Users)
			{
				FillUsersList();
			}
			else if (spn.NodeType == SpecialParentNodeType.Groups)
			{
				FillGroupsList();
			}
			else if (spn.NodeType == SpecialParentNodeType.Permissions)
			{
				FillPermissionsList();
			}
			else if (spn.NodeType == SpecialParentNodeType.Applications)
			{
				FillThreadsList(spn);
			}
			else if (spn.NodeType == SpecialParentNodeType.Executors)
			{
				FillExecutorsList();
			}
			else
			{
				//dunno what kind of node this is.
				//no nodes are meant to be shown here.
				//so just clear the list
				lv.Items.Clear();
			}
		}

		#region "Users, Groups and Permissions" 

		private void FillPermissionsList()
		{
			if (connected && !filling)
			{
				try
				{
					SetFilling(true);
					//get permissions.
					PermissionStorageView[] permissions = console.Manager.Admon_GetPermissions(console.Credentials);

					int iterations = 0;
					lv.Items.Clear();
					foreach (PermissionStorageView permission in permissions)
					{
						PermissionItem prm = new PermissionItem(permission.PermissionName);
						prm.ImageIndex = 12;
						prm.Permission = permission;
						lv.Items.Add(prm);

						iterations++;
						if (iterations > MAGIC_ITEM_NUMBER)
						{
							iterations = 0;
							Application.DoEvents();
						}

						if (stopFillingRequest)
						{
							break; //To make sure we dont get stuck in this loop when asked to stop.
						}
					}					
				}
				catch (Exception ex)
				{
					if (ex is AuthorizationException)
					{
						MessageBox.Show("Access denied. You do not have adequate permissions for this operation.","Authorization Error",MessageBoxButtons.OK,  MessageBoxIcon.Error);
					}
					else
					{
						logger.Error("Could not get list of permissions. Error: "+ex.Message, ex);
						MessageBox.Show("Could not get list of permissions. Error: "+ex.Message,"Console Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
						sbar.Text = "Couldnot get list of permissions. Error: " + ex.Message;
					}
				}
				finally
				{
					SetFilling(false);
				}
			}
			else
			{
				ShowDisconnectedMessage();
			}
			RefreshUI();
		}

		private void FillGroupsList()
		{
			if (connected && !filling)
			{
				try
				{
					SetFilling(true);
					//get groups.
					GroupStorageView[] groups = console.Manager.Admon_GetGroups(console.Credentials);

					int iterations = 0;
					lv.Items.Clear();
					foreach (GroupStorageView group in groups)
					{
						if (group.GroupName != null)
						{
							GroupItem grp = new GroupItem(group.GroupName);
							grp.ImageIndex = 2;
							grp.GroupView = group;
							lv.Items.Add(grp);
						}

						iterations++;
						if (iterations > MAGIC_ITEM_NUMBER)
						{
							iterations = 0;
							Application.DoEvents();
						}

						if (stopFillingRequest)
						{
							break; //To make sure we dont get stuck in this loop when asked to stop.
						}
					}					
				}			
				catch (Exception ex)
				{
					if (ex is AuthorizationException)
					{
						MessageBox.Show("Access denied. You do not have adequate permissions for this operation.","Authorization Error",MessageBoxButtons.OK,  MessageBoxIcon.Error);
					}
					else
					{
						logger.Error("Could not get list of groups. Error: "+ex.Message, ex);
						MessageBox.Show("Could not get list of groups. Error: "+ex.Message,"Console Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
						sbar.Text = "Couldnot get list of groups. Error: " + ex.Message;
					}
				}
				finally
				{
					SetFilling(false);
				}
			}
			else
			{
				ShowDisconnectedMessage();
			}
			RefreshUI();
		}

		private void FillUsersList()
		{
			if (connected && !filling)
			{
				try
				{
					SetFilling(true);
					//get users.
					UserStorageView[] users = console.Manager.Admon_GetUserList(console.Credentials);
					int iterations = 0;
					lv.Items.Clear();
					foreach (UserStorageView user in users)
					{
						if (user.Username != null)
						{
							UserItem usr = new UserItem(user.Username);
							usr.ImageIndex = 3;
							usr.User = user;
							logger.Debug("User "+user.Username+" is system ? "+ user.IsSystem);
							lv.Items.Add(usr);
						}

						iterations++;
						if (iterations > MAGIC_ITEM_NUMBER)
						{
							iterations = 0;
							Application.DoEvents();
						}

						if (stopFillingRequest)
						{
							break; //To make sure we dont get stuck in this loop when asked to stop.
						}
					}			
				}			
				catch (Exception ex)
				{
					if (ex is AuthorizationException)
					{
						MessageBox.Show("Access denied. You do not have adequate permissions for this operation.","Authorization Error",MessageBoxButtons.OK,  MessageBoxIcon.Error);
					}
					else
					{
						logger.Error("Could not get list of users. Error: "+ex.Message, ex);
						MessageBox.Show("Could not get list of users. Error: "+ex.Message,"Console Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
						sbar.Text = "Couldnot get list of users. Error: " + ex.Message;
					}
				}
				finally
				{
					SetFilling(false);
				}
			}
			else
			{
				ShowDisconnectedMessage();
			}
			RefreshUI();
		}

		
		#endregion

		#region "Executors" 
		
		private void FillExecutorsList()
		{
			if (connected && !filling)
			{
				try
				{
					SetFilling(true);
					ExecutorStorageView[] executors = console.Manager.Admon_GetExecutors(console.Credentials);
					int iterations = 0;
					lv.Items.Clear();
					foreach (ExecutorStorageView executor in executors)
					{
						if (executor.HostName != null)
						{
							ExecutorItem exi = new ExecutorItem(executor.HostName);
							exi.Executor = executor;

							if (exi.Executor.Connected)
							{
								exi.ImageIndex = 5;
							}
							else
							{
								exi.ImageIndex = 6;
							}
							lv.Items.Add(exi);
						}

						iterations++;

						if (iterations > MAGIC_ITEM_NUMBER)
						{
							iterations = 0;
							Application.DoEvents();
						}

						if (stopFillingRequest)
						{
							break; //To make sure we dont get stuck in this loop when asked to stop.
						}
					}

					
				}			
				catch (Exception ex)
				{
					if (ex is AuthorizationException)
					{
						MessageBox.Show("Access denied. You do not have adequate permissions for this operation.","Authorization Error",MessageBoxButtons.OK,  MessageBoxIcon.Error);
					}
					else
					{
						logger.Error("Could not get list of executors. Error: "+ex.Message, ex);
						MessageBox.Show("Could not get list of executors. Error: "+ex.Message,"Console Error",MessageBoxButtons.OK,MessageBoxIcon.Error );
						sbar.Text = "Couldnot get list of executors. Error: " + ex.Message;
					}
				}
				finally
				{
					SetFilling(false);
				}
			}
			else
			{
				ShowDisconnectedMessage();
			}
			RefreshUI();
		}

		
		#endregion

		#region "Applications and Threads" 
		private void FillApplicationsTree()
		{
			if (connected && !filling)
			{
				try
				{
					SetFilling(true);
					
					TreeNode rootNode = appParentNode;
					rootNode.Nodes.Clear();

					//get apps
					ApplicationStorageView[] apps = console.Manager.Admon_GetLiveApplicationList(console.Credentials);

					int iterations = 0;
					foreach (ApplicationStorageView app in apps)
					{
						string nodeText = app.ApplicationName;
						
						ApplicationTreeNode appNode = new ApplicationTreeNode(nodeText, 7, 7);
						appNode.AlchemiApplication = app;
						rootNode.Nodes.Add(appNode);

						iterations++;

						//this is there to make the app more responsive as a GUI to the user,
						//in case there are lots and lots of threads.
						if (iterations >= MAGIC_ITEM_NUMBER)
						{
							iterations = 0;
							Application.DoEvents();
						}

						if (stopFillingRequest)
						{
							break; //To make sure we dont get stuck in this loop when asked to stop.
						}
					}
					
				}			
				catch (Exception ex)
				{
					if (ex is AuthorizationException)
					{
						MessageBox.Show("Access denied. You do not have adequate permissions for this operation.","Authorization Error",MessageBoxButtons.OK,  MessageBoxIcon.Error);
					}
					else
					{
						logger.Error("Could not get list of applications. Error: "+ex.Message, ex);
						MessageBox.Show("Couldnot get list of applications. Error: "+ex.StackTrace,"Console Error",MessageBoxButtons.OK,MessageBoxIcon.Error );
						sbar.Text = "Couldnot get list of applications. Error: " + ex.Message;
					}
				}
				finally
				{
					SetFilling(false);
				}
			}
			else
			{
				ShowDisconnectedMessage();
			}
			RefreshUI();
		}
		
		private void FillThreadsList(SpecialParentNode appNode)
		{
			if (connected && !filling)
			{
				try
				{
					SetFilling(true);
					ApplicationTreeNode appTreeNode = (ApplicationTreeNode)appNode;
					string appId = (appTreeNode).AlchemiApplication.ApplicationId;
					//get jobs
					ThreadStorageView[] threads = console.Manager.Admon_GetThreadList(console.Credentials, appId);
					int iterations = 0;
					lv.Items.Clear();

					foreach (ThreadStorageView thread in threads)
					{
						ThreadItem thrItem = new ThreadItem(thread.ThreadId.ToString());
						thrItem.ImageIndex = 11;
						thrItem.AlchemiThread =  thread;

						lv.Items.Add(thrItem);
						iterations++;

						//this is there to make the app more responsive as a GUI to the user,
						//in case there are lots and lots of threads.
						if (iterations >= MAGIC_ITEM_NUMBER)
						{
							iterations = 0;
							Application.DoEvents();
						}

						if (stopFillingRequest)
						{
							break; //To make sure we dont get stuck in this loop when asked to stop.
						}
					}
				}			
				catch (Exception ex)
				{
					if (ex is AuthorizationException)
					{
						MessageBox.Show("Access denied. You do not have adequate permissions for this operation.","Authorization Error",MessageBoxButtons.OK,  MessageBoxIcon.Error);
					}
					else
					{
						logger.Error("Could not get list of applications. Error: "+ex.Message, ex);
						MessageBox.Show("Couldnot get list of applications. Error: "+ex.StackTrace,"Console Error",MessageBoxButtons.OK,MessageBoxIcon.Error );
						sbar.Text = "Couldnot get list of applications. Error: " + ex.Message;
					}
				}
				finally
				{
					SetFilling(false);
				}
			}
			else
			{
				ShowDisconnectedMessage();
			}
			RefreshUI();
		}

		#endregion

		#region "Show System Form"
		
		private void ShowSystem()
		{
			if (!connected || filling)
			{
				//MessageBox.Show("No connection available.");
				return;
			}

			//first check if the system form is already showing.
			//if not show it.
			if (sysForm == null || !sysForm.Created)
			{
				sysForm = new SysPerfForm(console);
				sysForm.Closing += new CancelEventHandler(SysForm_Closing);
				sysForm.MdiParent = this.MdiParent;
				sysForm.Text = "System Performance Monitor:  "+console.ManagerEP.Host+":"+console.ManagerEP.Port;
				sysForm.WindowState = this.WindowState;
			}

			sysForm.Show();
			sysForm.ShowSystem();
			sysForm.Activate();
		}

		#endregion

		#region GUI Events

		private void lv_SelectedIndexChanged(object sender, EventArgs e)
		{
			RefreshUI();
		}
		private void lv_DoubleClick(object sender, EventArgs e)
		{
			//this event is raised only when an item is double-clicked
			try
			{
				ListViewItem li = null;
				TreeNode node = null;
				if (lv.SelectedItems != null && lv.SelectedItems.Count>0 && lv.SelectedItems[0]!=null)
				{
					li = lv.SelectedItems[0];
				}

				if (li!=null && li.Tag!=null && li.Tag is TreeNode)
				{
					node = (TreeNode)li.Tag; //when the node is SPN, we store the node in the tag
				}
				
				if (node!=null)
				{
					//expand it and then select it.
					//selecting the node will fire the tv_selected event, which will fill in the SPN children if needed.
					node.Expand();
					node.EnsureVisible();
					tv.SelectedNode = node;
					RefreshUI();
				}
				else
				{
					//for the selected list item.
					DoProperties();
				}
			}
			catch (Exception ex)
			{
				logger.Debug("Error lv_Double_Click:"+ex.ToString());
			} //ignore
		}

		private void tv_AfterExpand(object sender, TreeViewEventArgs e)
		{
			RefreshTreeNode(e.Node, false);
			RefreshUI();
		}

		private void tv_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Node is SpecialParentNode)
			{
				SpecialParentNode spn = (SpecialParentNode)e.Node;
				if (spn.Fillable)
				{
					FillListItems(spn);
				}
				else
				{
					RefreshListItems(e.Node);
				}
			}
			else
			{
				RefreshListItems(e.Node);
			}
			RefreshUI();
		}

		private void mnuView_Click(object sender, EventArgs e)
		{
			if (filling)
				return;

			if (sender == mnuLargeIcons || sender == mnuContextLargeIcons)
			{
				lv.View = View.LargeIcon;
			}
			else if (sender == mnuSmallIcons || sender == mnuContextSmallIcons)
			{
				lv.View = View.SmallIcon;
			}
			else if (sender == mnuList || sender == mnuContextList)
			{
				lv.View = View.List;
			}
			else if (sender == mnuDetails || sender == mnuContextDetails)
			{
				lv.View = View.Details;
			}

			RefreshUI();
		}

		private void mnuAction_Click(object sender, EventArgs e)
		{
			if (filling)
				return;

			if (sender == mnuNew || sender == mnuContextNew)
			{
				DoAdd();
			}
			else if (sender == mnuDelete || sender == mnuContextDelete)
			{
				DoDelete();
			}
			else if (sender == mnuProperties || sender == mnuContextProperties)
			{
				DoProperties();
			}
			RefreshUI();
		}

		private void tbar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
		{
			if (e.Button == tbtnStop)
			{
				//make the filling stop.
				StopFilling();
				return;	
			}

			if (filling)
				return;

			if (e.Button == tbtnRefresh)
			{
				//if any of the SpecialParentNodes are selected, we better refresh their contents here again.
				RefreshTreeNode(tv.SelectedNode, true);
				RefreshUI();
			}
			else if (e.Button == tbtnConnect)
			{
				if (connected)
				{
					Disconnect();
				}
				else //not connected
				{
					Connect();
				}
				RefreshUI();
			}
			else if (e.Button == tbtnNew)
			{
				DoAdd();
			}
			else if (e.Button == tbtnDelete)
			{
				DoDelete();
			}
			else if (e.Button == tbtnProperties)
			{
				DoProperties();
			}
			else if (e.Button == tbtnSysSummaryGraph)
			{
				ShowSystem();
			}
		}

		private void ConsoleForm_Closing(object sender, CancelEventArgs e)
		{
			//just make sure the grid is disconnected.
			Disconnect();
		}

		private void SysForm_Closing(object sender, CancelEventArgs e)
		{
			this.Activate();
		}
		#endregion

		#region actions
		private void DoProperties()
		{
			if (!connected || filling)
				return;

			//li is the selected list view item for which we show properties.
			ListViewItem li = null;
			if (lv.SelectedItems!=null && lv.SelectedItems.Count > 0)
				li = lv.SelectedItems[0];

			if (li != null)
			{
				if (li is UserItem)
				{
					//show user dialog.
					UserItem uitem = (UserItem)li;

					UserProperties userProps = new UserProperties(console);
					userProps.SetData(uitem.User);
					userProps.ShowDialog(this);
				}
				else if (li is GroupItem)
				{
					//show the group dialog
					GroupItem gitem = (GroupItem)li;

					GroupProperties groupProps = new GroupProperties(console);
					groupProps.SetData(gitem.GroupView);
					groupProps.ShowDialog(this);	
				}
				else if (li is PermissionItem)
				{
					//show the permission dialog
					PermissionItem pitem = (PermissionItem)li;

					PermissionProperties prmProps = new PermissionProperties();
					prmProps.SetData(pitem.Permission);
					prmProps.ShowDialog(this);	
				}
				else if (li is ExecutorItem)
				{
					//show executor props.
					ExecutorItem eItem = (ExecutorItem)li;

					ExecutorProperties exProps = new ExecutorProperties(console);
					exProps.SetData(eItem.Executor);
					exProps.ShowDialog(this);
				}
				else if (li is ApplicationItem)
				{
					//show the apps dialog
					ApplicationItem appItem = (ApplicationItem)li;

					ApplicationProperties appProps = new ApplicationProperties(this.console);
					appProps.SetData(appItem.AlchemiApplication);
					appProps.ShowDialog(this);
				}
				else if (li is ThreadItem)
				{
					//show thread props. 	
					ThreadItem threadItem = (ThreadItem)li;

					ThreadProperties threadProps = new ThreadProperties(console);
					threadProps.SetData(threadItem.AlchemiThread);
					threadProps.ShowDialog(this);
				}
			}
			
		}

		private void DoAdd()
		{
			ViewState view = GetViewState();
			
			try
			{
				//add can be done only for users / groups
					if (view==ViewState.User)
					{
						AddUserForm addUserForm = new AddUserForm(console);
						addUserForm.ShowDialog(this);
						if (addUserForm.AddedUser)
							FillUsersList();
					}
					else if (view==ViewState.Group)
					{
						AddGroupForm addGroupForm = new AddGroupForm(console);
						addGroupForm.ShowDialog(this);
						if (addGroupForm.AddedGroup)
							FillGroupsList();
					}
					//Doesnt make sense to add Executors / Apps / Threads /Permissions manually.
					//permissions cant be added yet. they can only be assigned to groups
			}
			catch (AuthorizationException)
			{
				MessageBox.Show("Access denied. You do not have adequate permissions for this operation.","Authorization Error",MessageBoxButtons.OK,  MessageBoxIcon.Error);
			}
		}

		private void DoDelete()
		{
			//delete can be done only for users / groups.
			//cannot delete self-user / group
			try
			{
				ListViewItem item = null;
				if (lv.SelectedItems != null && lv.SelectedItems.Count>0 && lv.SelectedItems[0]!=null)
				{
					item = lv.SelectedItems[0];
				}

				if (item!=null)
				{
					if (item is UserItem)
					{
						//first check the user is trying to delete himself
						UserItem uitem = (UserItem)item;
						if (console.Credentials.Username != uitem.User.Username)
						{
							DialogResult result = 
								MessageBox.Show("Are you sure you want to delete this user? ", "Delete User", 
														MessageBoxButtons.YesNo, MessageBoxIcon.Question);
							if (result == DialogResult.Yes)
							{
								console.Manager.Admon_DeleteUser(console.Credentials, uitem.User);

								//refresh users list
								FillUsersList();
							}
						}
						else
						{
							MessageBox.Show("Cannot delete self!","Delete User", MessageBoxButtons.OK, MessageBoxIcon.Warning);	
						}
					}
					else if (item is GroupItem)
					{
						GroupItem gitem = (GroupItem)item;
						DialogResult result = 
							MessageBox.Show("This group and all the users who are part of it will be deleted. Are you sure you want to delete this group? ", 
													"Delete Group", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						if (result == DialogResult.Yes)
						{
							console.Manager.Admon_DeleteGroup(console.Credentials, gitem.GroupView);
							
							//refresh groups list
							FillGroupsList();
						}
					}
					else if (item is ApplicationItem)
					{
						ApplicationItem appItem = (ApplicationItem)item;
						if (appItem.AlchemiApplication.State!=ApplicationState.Stopped)
						{
							MessageBox.Show("This application is still running. Only stopped applications can be deleted.", "Delete Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
							
						}
						else
						{
							DialogResult result = 
								MessageBox.Show("This application and all the threads within it, will be deleted. Are you sure you want to delete this application? ", 
								"Delete Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
							if (result == DialogResult.Yes)
							{
								console.Manager.Admon_DeleteApplication(console.Credentials, appItem.AlchemiApplication);

								//refresh apps
								FillApplicationsTree();
								RefreshListItems(appParentNode);
							}	
						}						
					}
					else if (item is ThreadItem)
					{
						ThreadItem appItem = (ThreadItem)item;
						if (appItem.AlchemiThread.State!=ThreadState.Dead && appItem.AlchemiThread.State!=ThreadState.Finished)
						{
							MessageBox.Show("This thread is still running. Only stopped threads can be deleted.", 
												"Delete Thread", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						else
						{
							DialogResult result = 
								MessageBox.Show("Are you sure you want to delete this thread? ", 
								"Delete Thread", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
							if (result == DialogResult.Yes)
							{
								console.Manager.Admon_DeleteThread(console.Credentials, appItem.AlchemiThread);

								//refresh threads
								//check if there is an application tree node that is selected
								if(tv.SelectedNode != null && tv.SelectedNode is ApplicationTreeNode)
								{
									FillThreadsList(tv.SelectedNode as SpecialParentNode);
								}
								else
								{
									FillApplicationsTree();	
								}
								
							}	
						}						
					}
				}		
			}
			catch (AuthorizationException)
			{
				MessageBox.Show("Access denied. You do not have adequate permissions for this operation.","Authorization Error",MessageBoxButtons.OK,  MessageBoxIcon.Error);
			}		
		}

		#endregion

        private void mnuStorageMaintenance_Click(object sender, EventArgs e)
        {
            DataForms.StorageMaintenanceForm maintenanceForm = new DataForms.StorageMaintenanceForm(console);

            maintenanceForm.ShowDialog();
        }

        /// <summary>
        /// Show or hide menu items depending on wether the console is connected to a Manager or not
        /// </summary>
        private void ShowMenuItems()
        {
            if (console == null)
            {
                mnuTools.Visible = false;
            }
            else
            {
                // TODO: make sure the right permissions are set
                mnuTools.Visible = true;
            }

        }
	}
}
