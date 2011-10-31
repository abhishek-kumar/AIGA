using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Alchemi.Core.Manager;
using Alchemi.Core.Manager.Storage;

namespace Alchemi.Console.DataForms
{
	/// <summary>
	/// Summary description for SearchForm.
	/// </summary>
	public class SearchForm : System.Windows.Forms.Form
	{
		public enum SearchMode
		{
			User,
			Group,
			Permission
		}

		public System.Windows.Forms.ListView lvMembers;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ImageList imgListSmall;
		private System.Windows.Forms.Label lbMembers;
		private System.ComponentModel.IContainer components;

		public SearchForm(ConsoleNode console, SearchMode mode)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//fill the data
			SetData(console, mode);
		}

		private void SetData(ConsoleNode console, SearchMode mode)
		{
			try
			{
				lvMembers.Items.Clear();
				if (mode == SearchMode.User)
				{
					lbMembers.Text = "&Users:";
					this.Text = "Users";
					UserStorageView[] users = console.Manager.Admon_GetUserList(console.Credentials);
					foreach (UserStorageView user in users)
					{
						UserItem ui = new UserItem(user.Username);
						ui.ImageIndex = 3;
						ui.User = user;
						lvMembers.Items.Add(ui);
					}
				}
				else if (mode == SearchMode.Group)
				{
					lbMembers.Text = "&Groups:";
					this.Text = "Groups";
					GroupStorageView[] groups = console.Manager.Admon_GetGroups(console.Credentials);
					foreach (GroupStorageView group in groups)
					{
						GroupItem gi = new GroupItem(group.GroupName);
						gi.ImageIndex = 2;
						gi.GroupView = group;
						lvMembers.Items.Add(gi);
					}
				}
				else if (mode == SearchMode.Permission)
				{
					lbMembers.Text = "&Permissions:";
					this.Text = "Permissions";
					PermissionStorageView[] permissions = console.Manager.Admon_GetPermissions(console.Credentials);
					foreach (PermissionStorageView permission in permissions)
					{
						PermissionItem prm = new PermissionItem(permission.PermissionName);
						prm.ImageIndex = 12;
						prm.Permission = new PermissionStorageView(permission.PermissionId, permission.PermissionName);
						lvMembers.Items.Add(prm);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error filling search list:" + ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SearchForm));
			this.lvMembers = new System.Windows.Forms.ListView();
			this.lbMembers = new System.Windows.Forms.Label();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.imgListSmall = new System.Windows.Forms.ImageList(this.components);
			this.SuspendLayout();
			// 
			// lvMembers
			// 
			this.lvMembers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvMembers.HideSelection = false;
			this.lvMembers.Location = new System.Drawing.Point(16, 40);
			this.lvMembers.MultiSelect = false;
			this.lvMembers.Name = "lvMembers";
			this.lvMembers.Size = new System.Drawing.Size(336, 176);
			this.lvMembers.SmallImageList = this.imgListSmall;
			this.lvMembers.TabIndex = 25;
			this.lvMembers.View = System.Windows.Forms.View.List;
			// 
			// lbMembers
			// 
			this.lbMembers.AutoSize = true;
			this.lbMembers.Location = new System.Drawing.Point(24, 16);
			this.lbMembers.Name = "lbMembers";
			this.lbMembers.Size = new System.Drawing.Size(55, 16);
			this.lbMembers.TabIndex = 26;
			this.lbMembers.Text = "&Members:";
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(192, 232);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 27;
			this.btnOk.Text = "OK";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(280, 232);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 28;
			this.btnCancel.Text = "Cancel";
			// 
			// imgListSmall
			// 
			this.imgListSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
			this.imgListSmall.ImageSize = new System.Drawing.Size(16, 16);
			this.imgListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListSmall.ImageStream")));
			this.imgListSmall.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// SearchForm
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(370, 271);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.lbMembers);
			this.Controls.Add(this.lvMembers);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SearchForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "SearchForm";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOk_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
