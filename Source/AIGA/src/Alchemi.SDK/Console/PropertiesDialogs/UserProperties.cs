using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Alchemi.Console.DataForms;
using Alchemi.Core;
using Alchemi.Core.Manager;
using Alchemi.Core.Manager.Storage;

namespace Alchemi.Console.PropertiesDialogs
{
	public class UserProperties : PropertiesForm
	{
		private TabPage tabMemberOf;
		private Label label1;
		private IContainer components = null;
		private ListView lvGrp;

		private ConsoleNode console;
		private Button btnChgPwd;
		private UserStorageView _User = null;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Button btnAdd;

		private bool UpdateNeeded = false;

		public UserProperties(ConsoleNode console)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			this.console = console;
			
		}

		public void SetData(UserStorageView User)
		{
			this._User = User;
			this.Text = User.Username + " Properties";
			this.lbName.Text = User.Username;

			GetGroupMembershipData();

			if (User.IsSystem)
			{
				//we cant change group membership
				btnAdd.Enabled = false;
				btnRemove.Enabled = false;
			}
		}

		private void GetGroupMembershipData()
		{
			try
			{
				lvGrp.Items.Clear();
				//get the group this user belongs to.
				GroupStorageView groupStorageView = console.Manager.Admon_GetGroup(console.Credentials, _User.GroupId);

				if (groupStorageView != null)
				{
					GroupItem grpItem = new GroupItem(groupStorageView.GroupName);
					grpItem.GroupView = groupStorageView;
					grpItem.ImageIndex = 2;
					lvGrp.Items.Add(grpItem);
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
					MessageBox.Show("Could not get user-group membership details. Error: "+ex.Message,"Console Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(UserProperties));
			this.tabMemberOf = new System.Windows.Forms.TabPage();
			this.lvGrp = new System.Windows.Forms.ListView();
			this.label1 = new System.Windows.Forms.Label();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnChgPwd = new System.Windows.Forms.Button();
			this.tabs.SuspendLayout();
			this.tabGeneral.SuspendLayout();
			this.tabMemberOf.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabs
			// 
			this.tabs.Controls.Add(this.tabMemberOf);
			this.tabs.Name = "tabs";
			this.tabs.Controls.SetChildIndex(this.tabMemberOf, 0);
			this.tabs.Controls.SetChildIndex(this.tabGeneral, 0);
			// 
			// tabGeneral
			// 
			this.tabGeneral.Controls.Add(this.btnChgPwd);
			this.tabGeneral.Name = "tabGeneral";
			this.tabGeneral.Controls.SetChildIndex(this.btnChgPwd, 0);
			this.tabGeneral.Controls.SetChildIndex(this.iconBox, 0);
			this.tabGeneral.Controls.SetChildIndex(this.lbName, 0);
			this.tabGeneral.Controls.SetChildIndex(this.lineLabel, 0);
			// 
			// btnApply
			// 
			this.btnApply.Name = "btnApply";
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
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
			// tabMemberOf
			// 
			this.tabMemberOf.Controls.Add(this.lvGrp);
			this.tabMemberOf.Controls.Add(this.label1);
			this.tabMemberOf.Controls.Add(this.btnRemove);
			this.tabMemberOf.Controls.Add(this.btnAdd);
			this.tabMemberOf.Location = new System.Drawing.Point(4, 22);
			this.tabMemberOf.Name = "tabMemberOf";
			this.tabMemberOf.Size = new System.Drawing.Size(328, 318);
			this.tabMemberOf.TabIndex = 1;
			this.tabMemberOf.Text = "Member Of";
			// 
			// lvGrp
			// 
			this.lvGrp.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvGrp.HideSelection = false;
			this.lvGrp.Location = new System.Drawing.Point(16, 40);
			this.lvGrp.MultiSelect = false;
			this.lvGrp.Name = "lvGrp";
			this.lvGrp.Size = new System.Drawing.Size(296, 232);
			this.lvGrp.SmallImageList = this.imgListSmall;
			this.lvGrp.TabIndex = 16;
			this.lvGrp.View = System.Windows.Forms.View.List;
			this.lvGrp.SelectedIndexChanged += new System.EventHandler(this.lvGrp_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 16);
			this.label1.TabIndex = 15;
			this.label1.Text = "&Member of:";
			// 
			// btnRemove
			// 
			this.btnRemove.Enabled = false;
			this.btnRemove.Location = new System.Drawing.Point(96, 282);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(72, 23);
			this.btnRemove.TabIndex = 14;
			this.btnRemove.Text = "&Remove";
			this.btnRemove.Visible = false;
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(16, 282);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(72, 23);
			this.btnAdd.TabIndex = 13;
			this.btnAdd.Text = "&Change...";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnChgPwd
			// 
			this.btnChgPwd.Location = new System.Drawing.Point(200, 72);
			this.btnChgPwd.Name = "btnChgPwd";
			this.btnChgPwd.Size = new System.Drawing.Size(120, 23);
			this.btnChgPwd.TabIndex = 4;
			this.btnChgPwd.Text = "Change Password...";
			this.btnChgPwd.Click += new System.EventHandler(this.btnChgPwd_Click);
			// 
			// UserProperties
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(352, 389);
			this.Name = "UserProperties";
			this.Text = "User Properties";
			this.tabs.ResumeLayout(false);
			this.tabGeneral.ResumeLayout(false);
			this.tabMemberOf.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void UpdateUser()
		{
			int groupId = -1;
			try
			{
				//get the groupId from the listview.
				if (lvGrp.Items != null && lvGrp.Items.Count>0)
				{
					if (lvGrp.Items[0] is GroupItem)
					{
						GroupItem grpItem  = (GroupItem)lvGrp.Items[0];
						groupId = grpItem.GroupView.GroupId; //set the group Id. For now, a user can be part of one group only.
					}
				}

				if ((groupId != _User.GroupId) && (groupId != -1))
				{
					UserStorageView[] users = new UserStorageView[1];
					users[0] = _User;
					console.Manager.Admon_UpdateUsers(console.Credentials, users);
				}
				else
				{
					if (groupId == -1)
					{
						//dont update the user.
						MessageBox.Show("Cannot update user: The User is not assigned to any group!", "Edit User", MessageBoxButtons.OK,  MessageBoxIcon.Warning);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error updating user:"+ex.Message, "Update User", MessageBoxButtons.OK,  MessageBoxIcon.Error);
			}
		}

		private void btnChgPwd_Click(object sender, EventArgs e)
		{
			bool changed = false;
			try
			{
				PasswordForm pwdform = new PasswordForm();
				pwdform.ShowDialog(this);
				//try to change the password for this user.
				if (pwdform.Password != null)
				{
					UserStorageView[] users = new UserStorageView[1];
					users[0] = _User;
					_User.Password = pwdform.Password;
					console.Manager.Admon_UpdateUsers(console.Credentials, users);

					changed = true;

					//update the console credentials if needed
					if (console.Credentials.Username == _User.Username)
					{
						console.Credentials.Password = pwdform.Password;
					}
				}
			}
			catch (Exception ex)
			{
				changed = false;
				MessageBox.Show("Error changing password:"+ex.Message, "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				if (changed)
				{
					MessageBox.Show("Password changed successfully.", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void btnApply_Click(object sender, System.EventArgs e)
		{
			UpdateUser();
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (UpdateNeeded)
				UpdateUser();
			this.Close();
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			try
			{
				SearchForm srch = new SearchForm(this.console, SearchForm.SearchMode.Group);
				srch.ShowDialog(this);

				//get list of groups from the search form.
				ListView.SelectedListViewItemCollection items = srch.lvMembers.SelectedItems;
				
				//first update the database, then get it from there.
				//for now only one item can be included
				if (items!=null && items.Count>0)
				{
					_User.GroupId = ((GroupItem)items[0]).GroupView.GroupId;

					UserStorageView[] users = new UserStorageView[1];
					users[0] = this._User;
					
					console.Manager.Admon_UpdateUsers(console.Credentials, users);	
				}

				GetGroupMembershipData();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error changing membership:"+ex.Message, "User Properties", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		//need to hide this till multiple group-memberships are present.
		private void btnRemove_Click(object sender, System.EventArgs e)
		{
//			bool removed = false;
//			if (lvGrp.SelectedItems!=null)
//			{
//				foreach (ListViewItem li in lvGrp.SelectedItems)
//				{
//					li.Remove();
//					removed = true;
//				}
//			}
//			lvGrp.Refresh();
//
//			if (removed)
//			{
//				UpdateNeeded = true;
//				btnApply.Enabled = UpdateNeeded;
//			}
		}

		private void lvGrp_SelectedIndexChanged(object sender, EventArgs e)
		{
			btnRemove.Enabled = (lvGrp.SelectedItems!=null && lvGrp.SelectedItems.Count>0);
		}
	}
}

