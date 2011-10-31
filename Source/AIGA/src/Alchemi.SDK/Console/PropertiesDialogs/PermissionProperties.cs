using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Alchemi.Core.Manager.Storage;

namespace Alchemi.Console.PropertiesDialogs
{
	public class PermissionProperties : Alchemi.Console.PropertiesDialogs.PropertiesForm
	{
		private System.Windows.Forms.Label lbDesc;
		private System.Windows.Forms.TextBox txDesc;
		private System.ComponentModel.IContainer components = null;

		private PermissionStorageView _prm;

		public PermissionProperties()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}

		public void SetData(PermissionStorageView permission)
		{
			this._prm = permission;

			this.Text = this._prm.PermissionName + " Properties";
			this.lbName.Text = _prm.PermissionName;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PermissionProperties));
			this.lbDesc = new System.Windows.Forms.Label();
			this.txDesc = new System.Windows.Forms.TextBox();
			this.tabs.SuspendLayout();
			this.tabGeneral.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabs
			// 
			this.tabs.Name = "tabs";
			// 
			// tabGeneral
			// 
			this.tabGeneral.Controls.Add(this.txDesc);
			this.tabGeneral.Controls.Add(this.lbDesc);
			this.tabGeneral.Name = "tabGeneral";
			this.tabGeneral.Controls.SetChildIndex(this.lbDesc, 0);
			this.tabGeneral.Controls.SetChildIndex(this.txDesc, 0);
			this.tabGeneral.Controls.SetChildIndex(this.iconBox, 0);
			this.tabGeneral.Controls.SetChildIndex(this.lbName, 0);
			this.tabGeneral.Controls.SetChildIndex(this.lineLabel, 0);
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
			// label1
			// 
			this.lbDesc.AutoSize = true;
			this.lbDesc.Location = new System.Drawing.Point(16, 72);
			this.lbDesc.Name = "lbDesc";
			this.lbDesc.Size = new System.Drawing.Size(64, 16);
			this.lbDesc.TabIndex = 4;
			this.lbDesc.Text = "&Description:";
			// 
			// txDesc
			// 
			this.txDesc.Location = new System.Drawing.Point(16, 96);
			this.txDesc.Multiline = true;
			this.txDesc.Name = "txDesc";
			this.txDesc.ReadOnly = true;
			this.txDesc.Size = new System.Drawing.Size(296, 64);
			this.txDesc.TabIndex = 5;
			this.txDesc.Text = "";
			// 
			// PermissionProperties
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(352, 389);
			this.Name = "PermissionProperties";
			this.Text = "Permission Properties";
			this.tabs.ResumeLayout(false);
			this.tabGeneral.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}

