using System.Windows.Forms;

namespace Alchemi.Console.PropertiesDialogs
{
	/// <summary>
	/// Summary description for PropertiesForm.
	/// </summary>
	public class PropertiesForm : System.Windows.Forms.Form
	{
		protected System.Windows.Forms.TabControl tabs;
		protected System.Windows.Forms.TabPage tabGeneral;
		protected System.Windows.Forms.Button btnApply;
		protected System.Windows.Forms.Button btnCancel;
		protected System.Windows.Forms.Button btnOK;
		protected System.Windows.Forms.PictureBox iconBox;
		protected System.Windows.Forms.Label lbName;
		protected System.Windows.Forms.Label lineLabel;
		protected System.Windows.Forms.ImageList imgListSmall;
		private System.ComponentModel.IContainer components;

		public PropertiesForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PropertiesForm));
			this.tabs = new System.Windows.Forms.TabControl();
			this.tabGeneral = new System.Windows.Forms.TabPage();
			this.lineLabel = new System.Windows.Forms.Label();
			this.lbName = new System.Windows.Forms.Label();
			this.iconBox = new System.Windows.Forms.PictureBox();
			this.btnApply = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.imgListSmall = new System.Windows.Forms.ImageList(this.components);
			this.tabs.SuspendLayout();
			this.tabGeneral.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabs
			// 
			this.tabs.Controls.Add(this.tabGeneral);
			this.tabs.Location = new System.Drawing.Point(8, 8);
			this.tabs.Name = "tabs";
			this.tabs.SelectedIndex = 0;
			this.tabs.Size = new System.Drawing.Size(336, 344);
			this.tabs.TabIndex = 0;
			// 
			// tabGeneral
			// 
			this.tabGeneral.Controls.Add(this.lineLabel);
			this.tabGeneral.Controls.Add(this.lbName);
			this.tabGeneral.Controls.Add(this.iconBox);
			this.tabGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabGeneral.Name = "tabGeneral";
			this.tabGeneral.Size = new System.Drawing.Size(328, 318);
			this.tabGeneral.TabIndex = 0;
			this.tabGeneral.Text = "General";
			// 
			// lineLabel
			// 
			this.lineLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lineLabel.Location = new System.Drawing.Point(8, 56);
			this.lineLabel.Name = "lineLabel";
			this.lineLabel.Size = new System.Drawing.Size(312, 2);
			this.lineLabel.TabIndex = 3;
			// 
			// lbName
			// 
			this.lbName.AutoSize = true;
			this.lbName.Location = new System.Drawing.Point(64, 24);
			this.lbName.Name = "lbName";
			this.lbName.Size = new System.Drawing.Size(80, 16);
			this.lbName.TabIndex = 1;
			this.lbName.Text = "Name Property";
			// 
			// iconBox
			// 
			this.iconBox.Image = ((System.Drawing.Image)(resources.GetObject("iconBox.Image")));
			this.iconBox.Location = new System.Drawing.Point(16, 16);
			this.iconBox.Name = "iconBox";
			this.iconBox.Size = new System.Drawing.Size(32, 32);
			this.iconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.iconBox.TabIndex = 0;
			this.iconBox.TabStop = false;
			// 
			// btnApply
			// 
			this.btnApply.Enabled = false;
			this.btnApply.Location = new System.Drawing.Point(268, 360);
			this.btnApply.Name = "btnApply";
			this.btnApply.TabIndex = 1;
			this.btnApply.Text = "&Apply";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(182, 360);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(96, 360);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "OK";
			// 
			// imgListSmall
			// 
			this.imgListSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
			this.imgListSmall.ImageSize = new System.Drawing.Size(16, 16);
			this.imgListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListSmall.ImageStream")));
			this.imgListSmall.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// PropertiesForm
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(352, 389);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnApply);
			this.Controls.Add(this.tabs);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PropertiesForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "PropertiesForm";
			this.tabs.ResumeLayout(false);
			this.tabGeneral.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
