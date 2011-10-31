using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Alchemi.Console.DataForms;
using Alchemi.Core;
using Alchemi.Core.Manager;
using Alchemi.Core.Manager.Storage;
using Alchemi.Core.Utility;

namespace Alchemi.Console.PropertiesDialogs
{
	public class GroupProperties : PropertiesForm
	{
		private ListView lvMembers;
		private Label label1;
		private IContainer components = null;

		private bool UpdateNeeded = false;
		private ConsoleNode console;
		private Button btnRemove;
		private Button btnAdd;
		private TabPage tabPermissions;
		private ListView lvPrm;
		private Label label2;
		private Button btnRemovePrm;
		private Button btnAddPrm;

		private GroupStorageView _Group;

		public GroupProperties(ConsoleNode console)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			this.console = console;
		}

		public void SetData(GroupStorageView group)
		{
			this._Group = group;
			this.Text = _Group.GroupName + " Properties";
			this.lbName.Text = _Group.GroupName;

			GetMemberData();
			GetPermissionData();

			if (group.IsSystem)
			{
				btnAdd.Enabled = false;
				btnRemove.Enabled = false;

				btnAddPrm.Enabled = false;
				btnRemovePrm.Enabled = false;
			}
		}

		private void GetMemberData()
		{
			lvMembers.Items.Clear();
			try
			{
				UserStorageView[] users = console.Manager.GetGroupUsers(console.Credentials, _Group.GroupId);
				//get the group this user belongs to.

				foreach (UserStorageView user in users)
				{
					UserItem usrItem = new UserItem(user.Username);
					usrItem.User = user;
					usrItem.ImageIndex = 3;
					lvMembers.Items.Add(usrItem);
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
					MessageBox.Show("Could not get group membership details. Error: "+ex.Message,"Console Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			
		}	

		private void GetPermissionData()
		{
			lvPrm.Items.Clear();
			try
			{
				//get the group this user belongs to.
				PermissionStorageView[] permissions = console.Manager.Admon_GetGroupPermissions(console.Credentials, _Group);

				foreach (PermissionStorageView permission in permissions)
				{					
					PermissionItem prmItem = new PermissionItem(permission.PermissionName);
					prmItem.Permission = new PermissionStorageView(permission.PermissionId, permission.PermissionName);
					prmItem.ImageIndex = 12;
					lvPrm.Items.Add(prmItem);
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
					MessageBox.Show("Could not get group permissions. Error: "+ex.Message,"Console Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}			
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(GroupProperties));
			this.lvMembers = new System.Windows.Forms.ListView();
			this.label1 = new System.Windows.Forms.Label();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.tabPermissions = new System.Windows.Forms.TabPage();
			this.lvPrm = new System.Windows.Forms.ListView();
			this.label2 = new System.Windows.Forms.Label();
			this.btnRemovePrm = new System.Windows.Forms.Button();
			this.btnAddPrm = new System.Windows.Forms.Button();
			this.tabs.SuspendLayout();
			this.tabGeneral.SuspendLayout();
			this.tabPermissions.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabs
			// 
			this.tabs.Controls.Add(this.tabPermissions);
			this.tabs.Name = "tabs";
			this.tabs.Controls.SetChildIndex(this.tabPermissions, 0);
			this.tabs.Controls.SetChildIndex(this.tabGeneral, 0);
			// 
			// tabGeneral
			// 
			this.tabGeneral.Controls.Add(this.lvMembers);
			this.tabGeneral.Controls.Add(this.label1);
			this.tabGeneral.Controls.Add(this.btnRemove);
			this.tabGeneral.Controls.Add(this.btnAdd);
			this.tabGeneral.Name = "tabGeneral";
			this.tabGeneral.Controls.SetChildIndex(this.iconBox, 0);
			this.tabGeneral.Controls.SetChildIndex(this.lbName, 0);
			this.tabGeneral.Controls.SetChildIndex(this.lineLabel, 0);
			this.tabGeneral.Controls.SetChildIndex(this.btnAdd, 0);
			this.tabGeneral.Controls.SetChildIndex(this.btnRemove, 0);
			this.tabGeneral.Controls.SetChildIndex(this.label1, 0);
			this.tabGeneral.Controls.SetChildIndex(this.lvMembers, 0);
			// 
			// btnApply
			// 
			this.btnApply.Name = "btnApply";
			// 
			// btnCancel
			// 
			this.btnCancel.Name = "btnCancel";
			// 
			// btnOK
			// 
			this.btnOK.Name = "btnOK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// iconBox
			// 
			this.iconBox.Image = ((System.Drawing.Image)(resources.GetObject("iconBox.Image")));
			this.iconBox.Name = "iconBox";
			// 
			// lbName
			// 
			this.lbName.Name = "lbName";
			// 
			// lineLabel
			// 
			this.lineLabel.Name = "lineLabel";
			// 
			// imgListSmall
			// 
			this.imgListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListSmall.ImageStream")));
			// 
			// lvMembers
			// 
			this.lvMembers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvMembers.HideSelection = false;
			this.lvMembers.Location = new System.Drawing.Point(16, 96);
			this.lvMembers.MultiSelect = false;
			this.lvMembers.Name = "lvMembers";
			this.lvMembers.Size = new System.Drawing.Size(296, 176);
			this.lvMembers.SmallImageList = this.imgListSmall;
			this.lvMembers.TabIndex = 20;
			this.lvMembers.View = System.Windows.Forms.View.List;
			this.lvMembers.SelectedIndexChanged += new System.EventHandler(this.lvMembers_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 72);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 16);
			this.label1.TabIndex = 19;
			this.label1.Text = "&Members:";
			// 
			// btnRemove
			// 
			this.btnRemove.Enabled = false;
			this.btnRemove.Location = new System.Drawing.Point(96, 280);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(72, 23);
			this.btnRemove.TabIndex = 18;
			this.btnRemove.Text = "&Remove";
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(16, 280);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(72, 23);
			this.btnAdd.TabIndex = 17;
			this.btnAdd.Tag = "";
			this.btnAdd.Text = "&Add...";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// tabPermissions
			// 
			this.tabPermissions.Controls.Add(this.lvPrm);
			this.tabPermissions.Controls.Add(this.label2);
			this.tabPermissions.Controls.Add(this.btnRemovePrm);
			this.tabPermissions.Controls.Add(this.btnAddPrm);
			this.tabPermissions.Location = new System.Drawing.Point(4, 22);
			this.tabPermissions.Name = "tabPermissions";
			this.tabPermissions.Size = new System.Drawing.Size(328, 318);
			this.tabPermissions.TabIndex = 1;
			this.tabPermissions.Text = "Permissions";
			// 
			// lvPrm
			// 
			this.lvPrm.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvPrm.HideSelection = false;
			this.lvPrm.Location = new System.Drawing.Point(16, 40);
			this.lvPrm.MultiSelect = false;
			this.lvPrm.Name = "lvPrm";
			this.lvPrm.Size = new System.Drawing.Size(296, 224);
			this.lvPrm.SmallImageList = this.imgListSmall;
			this.lvPrm.TabIndex = 24;
			this.lvPrm.View = System.Windows.Forms.View.List;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(183, 16);
			this.label2.TabIndex = 23;
			this.label2.Text = "Permissions assigned to this group:";
			// 
			// btnRemovePrm
			// 
			this.btnRemovePrm.Enabled = false;
			this.btnRemovePrm.Location = new System.Drawing.Point(96, 280);
			this.btnRemovePrm.Name = "btnRemovePrm";
			this.btnRemovePrm.Size = new System.Drawing.Size(72, 23);
			this.btnRemovePrm.TabIndex = 22;
			this.btnRemovePrm.Text = "&Remove";
			this.btnRemovePrm.Click += new System.EventHandler(this.btnRemovePrm_Click);
			// 
			// btnAddPrm
			// 
			this.btnAddPrm.Location = new System.Drawing.Point(16, 280);
			this.btnAddPrm.Name = "btnAddPrm";
			this.btnAddPrm.Size = new System.Drawing.Size(72, 23);
			this.btnAddPrm.TabIndex = 21;
			this.btnAddPrm.Tag = "";
			this.btnAddPrm.Text = "&Add...";
			this.btnAddPrm.Click += new System.EventHandler(this.btnAddPrm_Click);
			// 
			// GroupProperties
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(352, 389);
			this.Name = "GroupProperties";
			this.Text = "Group Properties";
			this.tabs.ResumeLayout(false);
			this.tabGeneral.ResumeLayout(false);
			this.tabPermissions.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		//add group members
		private void btnAdd_Click(object sender, EventArgs e)
		{
			SearchForm srch = new SearchForm(this.console, SearchForm.SearchMode.User);
			srch.ShowDialog(this);

			//get list of users from the search form.
			ListView.SelectedListViewItemCollection items = srch.lvMembers.SelectedItems;
			
			//for now only one item can be included
			if (items!=null && items.Count>0)
				lvMembers.Items.Clear();

			foreach (ListViewItem li in items)
			{
				UserItem user = new UserItem(li.Text);
				user.ImageIndex = li.ImageIndex;
				user.User = ((UserItem)li).User;
				//this loop should go only once: since only one item can be selected.
				lvMembers.Items.Add(user);
			}

			UpdateNeeded = UpdateNeeded || (lvMembers.Items!=null && lvMembers.Items.Count>0);
			btnApply.Enabled = UpdateNeeded;
		}

		//need to hide this till multiple group-memberships are implemented.
		private void btnRemove_Click(object sender, EventArgs e)
		{
//			bool removed = false;
//			if (lvMembers.SelectedItems!=null)
//			{
//				foreach (ListViewItem li in lvMembers.SelectedItems)
//				{
//					if (console.Credentials.Username != li.Text)
//					{
//						li.Remove();
//					}
//					else
//					{
//						//for now, we can have only one group-membership, so we should enforce this.
//						MessageBox.Show("Cannot remove self, from group-membership.", "Remove User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//					}
//					removed = true;
//				}
//			}
//			lvMembers.Refresh();
//
//			if (removed)
//			{
//				UpdateNeeded = true;
//				btnApply.Enabled = UpdateNeeded;
//			}		
		}

		private void lvMembers_SelectedIndexChanged(object sender, EventArgs e)
		{
			btnRemove.Enabled = (lvMembers.SelectedItems!=null && lvMembers.SelectedItems.Count>0);
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnAddPrm_Click(object sender, EventArgs e)
		{
			SearchForm srch = new SearchForm(this.console, SearchForm.SearchMode.Permission);
			srch.ShowDialog(this);

			//get list of users from the search form.
			ListView.SelectedListViewItemCollection items = srch.lvMembers.SelectedItems;
			
			//for now only one item can be included
			if (items!=null && items.Count>0)
				lvPrm.Items.Clear();

			foreach (ListViewItem li in items)
			{
				PermissionItem prm = new PermissionItem(li.Text);
				prm.ImageIndex = li.ImageIndex;
				prm.Permission = ((PermissionItem)li).Permission;

				//this loop should go only once: since only one item can be selected.
				lvPrm.Items.Add(prm);
			}

			UpdateNeeded = UpdateNeeded || (lvPrm.Items!=null && lvPrm.Items.Count>0);
			btnApply.Enabled = UpdateNeeded;
		}

		private void btnRemovePrm_Click(object sender, EventArgs e)
		{
			//TODO remove permission from group
		}
	}
}

