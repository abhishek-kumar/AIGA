using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Alchemi.Core.Utility;

namespace Alchemi.Console.PropertiesDialogs
{
	/// <summary>
	/// Summary description for PasswordForm.
	/// </summary>
	public class PasswordForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.TextBox txPwd2;
		private System.Windows.Forms.Label lbPwd2;
		private System.Windows.Forms.TextBox txPwd;
		private System.Windows.Forms.Label lbPwd1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public string Password = null;

		public PasswordForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.txPwd2 = new System.Windows.Forms.TextBox();
			this.lbPwd2 = new System.Windows.Forms.Label();
			this.txPwd = new System.Windows.Forms.TextBox();
			this.lbPwd1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(136, 72);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(48, 72);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 9;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// txPwd2
			// 
			this.txPwd2.Location = new System.Drawing.Point(120, 40);
			this.txPwd2.Name = "txPwd2";
			this.txPwd2.PasswordChar = '*';
			this.txPwd2.Size = new System.Drawing.Size(120, 20);
			this.txPwd2.TabIndex = 8;
			this.txPwd2.Text = "";
			// 
			// lbPwd2
			// 
			this.lbPwd2.AutoSize = true;
			this.lbPwd2.Location = new System.Drawing.Point(16, 42);
			this.lbPwd2.Name = "lbPwd2";
			this.lbPwd2.Size = new System.Drawing.Size(95, 16);
			this.lbPwd2.TabIndex = 10;
			this.lbPwd2.Text = "Confirm password";
			// 
			// txPwd
			// 
			this.txPwd.Location = new System.Drawing.Point(120, 16);
			this.txPwd.Name = "txPwd";
			this.txPwd.PasswordChar = '*';
			this.txPwd.Size = new System.Drawing.Size(120, 20);
			this.txPwd.TabIndex = 6;
			this.txPwd.Text = "";
			// 
			// lbPwd1
			// 
			this.lbPwd1.AutoSize = true;
			this.lbPwd1.Location = new System.Drawing.Point(16, 16);
			this.lbPwd1.Name = "lbPwd1";
			this.lbPwd1.Size = new System.Drawing.Size(54, 16);
			this.lbPwd1.TabIndex = 7;
			this.lbPwd1.Text = "Password";
			// 
			// PasswordForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(258, 103);
			this.ControlBox = false;
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txPwd2);
			this.Controls.Add(this.lbPwd2);
			this.Controls.Add(this.txPwd);
			this.Controls.Add(this.lbPwd1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PasswordForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Change Password";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (txPwd.Text != txPwd2.Text)
			{
				MessageBox.Show("The two passwords entered are not the same. Please confirm the password.", "Change password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else if (Utils.IsSqlSafe(txPwd.Text)==false)
			{
				MessageBox.Show("The password entered has invalid characters ' or \" .", "Change password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				Password = Utils.MakeSqlSafe(txPwd.Text);
				this.Close();
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Password = null;
			this.Close();
		}
	}
}
