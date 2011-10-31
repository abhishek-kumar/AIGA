using System;
using System.Windows.Forms;
using Alchemi.Core.Manager.Storage;
using Alchemi.Core.Utility;

namespace Alchemi.Console.PropertiesDialogs
{
	/// <summary>
	/// Summary description for UserForm.
	/// </summary>
	public class AddUserForm : System.Windows.Forms.Form
	{
		private ConsoleNode console;
		private GroupStorageView[] allGroups;

		public bool AddedUser = false;

		private System.Windows.Forms.TextBox txUsername;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ComboBox cboGroup;
		private System.Windows.Forms.TextBox txPwd;
		private System.Windows.Forms.TextBox txPwd2;
		private System.Windows.Forms.Label lbUsername;
		private System.Windows.Forms.Label lbPwd1;
		private System.Windows.Forms.Label lbPwd2;
		private System.Windows.Forms.Label lbGroup;
		protected System.Windows.Forms.Label lineLabel;
		protected System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AddUserForm(ConsoleNode console)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.console = console;
			GroupStorageView[] allGroups = console.Manager.Admon_GetGroups(console.Credentials);					
			SetData(allGroups);
		}

		private void SetData(GroupStorageView[] allGroups)
		{
			this.allGroups = allGroups;	
			cboGroup.Items.Clear();
			foreach(GroupStorageView group in allGroups)
			{
				cboGroup.Items.Add(group.GroupName);

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AddUserForm));
			this.lbUsername = new System.Windows.Forms.Label();
			this.txUsername = new System.Windows.Forms.TextBox();
			this.txPwd = new System.Windows.Forms.TextBox();
			this.lbPwd1 = new System.Windows.Forms.Label();
			this.txPwd2 = new System.Windows.Forms.TextBox();
			this.lbPwd2 = new System.Windows.Forms.Label();
			this.lbGroup = new System.Windows.Forms.Label();
			this.cboGroup = new System.Windows.Forms.ComboBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lineLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lbUsername
			// 
			this.lbUsername.AutoSize = true;
			this.lbUsername.Location = new System.Drawing.Point(16, 24);
			this.lbUsername.Name = "lbUsername";
			this.lbUsername.Size = new System.Drawing.Size(59, 16);
			this.lbUsername.TabIndex = 0;
			this.lbUsername.Text = "&User name";
			// 
			// txUsername
			// 
			this.txUsername.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.txUsername.Location = new System.Drawing.Point(120, 22);
			this.txUsername.Name = "txUsername";
			this.txUsername.Size = new System.Drawing.Size(248, 20);
			this.txUsername.TabIndex = 0;
			this.txUsername.Text = "";
			this.txUsername.TextChanged += new System.EventHandler(this.txUsername_TextChanged);
			// 
			// txPwd
			// 
			this.txPwd.Location = new System.Drawing.Point(144, 112);
			this.txPwd.Name = "txPwd";
			this.txPwd.PasswordChar = '*';
			this.txPwd.Size = new System.Drawing.Size(224, 20);
			this.txPwd.TabIndex = 2;
			this.txPwd.Text = "";
			// 
			// lbPwd1
			// 
			this.lbPwd1.AutoSize = true;
			this.lbPwd1.Location = new System.Drawing.Point(16, 112);
			this.lbPwd1.Name = "lbPwd1";
			this.lbPwd1.Size = new System.Drawing.Size(54, 16);
			this.lbPwd1.TabIndex = 2;
			this.lbPwd1.Text = "Password";
			// 
			// txPwd2
			// 
			this.txPwd2.Location = new System.Drawing.Point(144, 144);
			this.txPwd2.Name = "txPwd2";
			this.txPwd2.PasswordChar = '*';
			this.txPwd2.Size = new System.Drawing.Size(224, 20);
			this.txPwd2.TabIndex = 3;
			this.txPwd2.Text = "";
			// 
			// lbPwd2
			// 
			this.lbPwd2.AutoSize = true;
			this.lbPwd2.Location = new System.Drawing.Point(16, 144);
			this.lbPwd2.Name = "lbPwd2";
			this.lbPwd2.Size = new System.Drawing.Size(95, 16);
			this.lbPwd2.TabIndex = 4;
			this.lbPwd2.Text = "Confirm password";
			// 
			// lbGroup
			// 
			this.lbGroup.AutoSize = true;
			this.lbGroup.Location = new System.Drawing.Point(16, 56);
			this.lbGroup.Name = "lbGroup";
			this.lbGroup.Size = new System.Drawing.Size(36, 16);
			this.lbGroup.TabIndex = 6;
			this.lbGroup.Text = "Group";
			// 
			// cboGroup
			// 
			this.cboGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboGroup.Location = new System.Drawing.Point(120, 53);
			this.cboGroup.Name = "cboGroup";
			this.cboGroup.Size = new System.Drawing.Size(248, 21);
			this.cboGroup.Sorted = true;
			this.cboGroup.TabIndex = 1;
			this.cboGroup.SelectedIndexChanged += new System.EventHandler(this.cboGroup_SelectedIndexChanged);
			// 
			// btnOK
			// 
			this.btnOK.Enabled = false;
			this.btnOK.Location = new System.Drawing.Point(208, 320);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "&Create";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(296, 320);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "&Close";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// lineLabel
			// 
			this.lineLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lineLabel.Location = new System.Drawing.Point(8, 96);
			this.lineLabel.Name = "lineLabel";
			this.lineLabel.Size = new System.Drawing.Size(362, 2);
			this.lineLabel.TabIndex = 7;
			// 
			// label1
			// 
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label1.Location = new System.Drawing.Point(8, 296);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(362, 2);
			this.label1.TabIndex = 8;
			// 
			// AddUserForm
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(378, 354);
			this.ControlBox = false;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lineLabel);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.cboGroup);
			this.Controls.Add(this.lbGroup);
			this.Controls.Add(this.txPwd2);
			this.Controls.Add(this.lbPwd2);
			this.Controls.Add(this.txPwd);
			this.Controls.Add(this.lbPwd1);
			this.Controls.Add(this.txUsername);
			this.Controls.Add(this.lbUsername);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddUserForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New User";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (ValidateUser())
			{
				AddUser();
				this.Close();
			}
		}

		private bool ValidateUser()
		{
			bool valid = true;
			string reason = "";

			if (txUsername.Text == null || txUsername.Text.Trim() == "" || Utils.IsSqlSafe(txUsername.Text.Trim())==false)
			{
				reason = "Username is empty or contains invalid characters.";
				valid = false;
			}

			if (cboGroup.SelectedIndex == -1)
			{
				reason = reason + "\nNo Group selected.";
				valid = false;
			}

			if (txPwd.Text == null || Utils.IsSqlSafe(txPwd.Text.Trim())==false)
			{
				reason = reason + "\nPassword is empty or contains invalid characters.";
				valid = false;
			}

			if (txPwd.Text != txPwd2.Text)
			{
				reason = reason + "\nPassword and confirm password do not match.";
				valid = false;
			}
	
			if (valid && txPwd.Text == "")
			{
				DialogResult result = 
					MessageBox.Show("Are you sure you want to set an empty password?", "Add User", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (result == DialogResult.No)
				{
					valid = false;
					return valid; //no reason, user will re-enter password.
				}
			}

			if (!valid)
			{
				MessageBox.Show("Cannot add user:\n"+reason, "Add User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

			return valid;
		}

		private UserStorageView[] GetUsers()
		{
			UserStorageView[] users = new UserStorageView[1];
			string username = Utils.MakeSqlSafe(txUsername.Text);
			string password = Utils.MakeSqlSafe(txPwd.Text);
			int groupId = -1;

			foreach (GroupStorageView group in allGroups)
			{
				if (group.GroupName == cboGroup.SelectedItem.ToString())
				{
					groupId = group.GroupId;
					break;
				}
			}
			users[0] = new UserStorageView(username, password, groupId);			

			return users;
		}

		private void AddUser()
		{
			try
			{
				UserStorageView[] users = GetUsers();
				console.Manager.Admon_AddUsers(console.Credentials, users);
				AddedUser = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error adding user:"+ex.Message, "Add User", MessageBoxButtons.OK,  MessageBoxIcon.Error);
			}
		}

		private void txUsername_TextChanged(object sender, System.EventArgs e)
		{
			ControlValue_Changed( sender, e);
		}

		private void cboGroup_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ControlValue_Changed( sender, e);
		}

		protected void ControlValue_Changed(object sender, System.EventArgs e)
		{
			if (sender is TextBox)
			{
				TextBox txt = (TextBox)sender;
				btnOK.Enabled = (txt.Text != "");
			}
			else if (sender is ComboBox)
			{
				ComboBox cbo = (ComboBox)sender;
				btnOK.Enabled = (cbo.SelectedIndex != -1);
			}
		}
	}
}
