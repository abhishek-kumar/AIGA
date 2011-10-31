using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Alchemi.Updater
{
	/// <summary>
	/// Summary description for UpdateForm.
	/// </summary>
	public class UpdateForm : Form
	{
		private Label label1;
		private Button button1;
		private Button button2;
		private Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public UpdateForm()
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
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(42, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(287, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = " An update to this application is available.";
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.button1.Location = new System.Drawing.Point(70, 90);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(84, 25);
			this.button1.TabIndex = 1;
			this.button1.Text = "Yes";
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.No;
			this.button2.Location = new System.Drawing.Point(196, 90);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(84, 25);
			this.button2.TabIndex = 2;
			this.button2.Text = "No";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(28, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(315, 18);
			this.label2.TabIndex = 3;
			this.label2.Text = "Would you like to start using the update now?";
			// 
			// UpdateForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(357, 130);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Name = "UpdateForm";
			this.Text = "Update Available";
			this.ResumeLayout(false);

		}
		#endregion

	}
}
