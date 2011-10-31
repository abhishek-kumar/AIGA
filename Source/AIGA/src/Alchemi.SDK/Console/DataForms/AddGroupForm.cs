using System;
using System.Windows.Forms;
using Alchemi.Core.Manager.Storage;
using Alchemi.Core.Utility;

namespace Alchemi.Console.PropertiesDialogs
{
	/// <summary>
	/// Summary description for GroupForm.
	/// </summary>
	public class AddGroupForm : System.Windows.Forms.Form
	{
		private ConsoleNode console;
		public bool AddedGroup = false;

		private System.Windows.Forms.TextBox txGroupname;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lbGroupname;
		protected System.Windows.Forms.Label lineLabel;
		private System.Windows.Forms.ListView lvMembers;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Button btnAdd;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AddGroupForm(ConsoleNode console)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.console = console;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AddGroupForm));
			this.lbGroupname = new System.Windows.Forms.Label();
			this.txGroupname = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lineLabel = new System.Windows.Forms.Label();
			this.lvMembers = new System.Windows.Forms.ListView();
			this.label2 = new System.Windows.Forms.Label();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lbGroupname
			// 
			this.lbGroupname.AutoSize = true;
			this.lbGroupname.Location = new System.Drawing.Point(16, 24);
			this.lbGroupname.Name = "lbGroupname";
			this.lbGroupname.Size = new System.Drawing.Size(67, 16);
			this.lbGroupname.TabIndex = 0;
			this.lbGroupname.Text = "&Group name";
			// 
			// txGroupname
			// 
			this.txGroupname.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.txGroupname.Location = new System.Drawing.Point(120, 22);
			this.txGroupname.Name = "txGroupname";
			this.txGroupname.Size = new System.Drawing.Size(248, 20);
			this.txGroupname.TabIndex = 0;
			this.txGroupname.Text = "";
			this.txGroupname.TextChanged += new System.EventHandler(this.txGroupname_TextChanged);
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
			this.lineLabel.Location = new System.Drawing.Point(8, 56);
			this.lineLabel.Name = "lineLabel";
			this.lineLabel.Size = new System.Drawing.Size(362, 2);
			this.lineLabel.TabIndex = 7;
			// 
			// lvMembers
			// 
			this.lvMembers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvMembers.HideSelection = false;
			this.lvMembers.Location = new System.Drawing.Point(16, 96);
			this.lvMembers.MultiSelect = false;
			this.lvMembers.Name = "lvMembers";
			this.lvMembers.Size = new System.Drawing.Size(352, 176);
			this.lvMembers.TabIndex = 24;
			this.lvMembers.View = System.Windows.Forms.View.List;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 16);
			this.label2.TabIndex = 23;
			this.label2.Text = "&Members:";
			// 
			// btnRemove
			// 
			this.btnRemove.Enabled = false;
			this.btnRemove.Location = new System.Drawing.Point(96, 280);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(72, 23);
			this.btnRemove.TabIndex = 22;
			this.btnRemove.Text = "&Remove";
			this.btnRemove.Visible = false;
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(16, 280);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(72, 23);
			this.btnAdd.TabIndex = 21;
			this.btnAdd.Tag = "";
			this.btnAdd.Text = "&Add...";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// AddGroupForm
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(378, 354);
			this.ControlBox = false;
			this.Controls.Add(this.lvMembers);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.lineLabel);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txGroupname);
			this.Controls.Add(this.lbGroupname);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddGroupForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Group";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (ValidateGroup())
				AddGroup();
			this.Close();
		}

		private bool ValidateGroup()
		{
			bool valid = true;

			string reason = "";

			if (txGroupname.Text == null || txGroupname.Text.Trim() == "" || Utils.IsSqlSafe(txGroupname.Text.Trim())==false)
			{
				reason = "Groupname is empty or contains invalid characters.";
				valid = false;
			}

			if (!valid)
			{
				MessageBox.Show("Cannot add group:\n"+reason, "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

			return valid;
		}

		private void AddGroup()
		{
			try
			{
				//console.Manager.
				AddedGroup = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error adding Group:"+ex.Message, "Add Group", MessageBoxButtons.OK,  MessageBoxIcon.Error);
			}
		}

		private void txGroupname_TextChanged(object sender, System.EventArgs e)
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
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
		
		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
