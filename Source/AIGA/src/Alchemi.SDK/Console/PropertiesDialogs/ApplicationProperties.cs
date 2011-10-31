using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Alchemi.Core;
using Alchemi.Core.Manager.Storage;
using Alchemi.Core.Owner;

namespace Alchemi.Console.PropertiesDialogs
{
	public class ApplicationProperties : Alchemi.Console.PropertiesDialogs.PropertiesForm
	{
		private System.Windows.Forms.Label lbId;
		private System.Windows.Forms.TextBox txId;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txUsername;
		private System.Windows.Forms.TextBox txCreated;
		private System.Windows.Forms.TextBox txCompleted;
		private System.Windows.Forms.TextBox txState;
		private System.Windows.Forms.TextBox txNumThreads;
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.CheckBox chkPrimary;
		private System.Windows.Forms.Button btnStop;

		private ApplicationStorageView _app;
		private ConsoleNode console;
		// Create a logger for use in this class
		private static readonly Logger logger = new Logger();

		public ApplicationProperties(ConsoleNode console)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			this.console = console;
		}

		public void SetData(ApplicationStorageView application)
		{
			this._app = application;

			this.lbName.Text = _app.ApplicationName;

			txId.Text = _app.ApplicationId;
			txUsername.Text = _app.Username;

            if (_app.TimeCreatedSet)
            {
                txCreated.Text = _app.TimeCreated.ToString();
            }

            if (_app.TimeCompletedSet)
            {
                txCompleted.Text = _app.TimeCompleted.ToString();
            }

			txState.Text = _app.StateString;
			chkPrimary.Checked = _app.Primary;
			txNumThreads.Text =_app.TotalThreads.ToString();

			btnStop.Enabled = (_app.State != ApplicationState.Stopped );
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ApplicationProperties));
			this.lbId = new System.Windows.Forms.Label();
			this.txId = new System.Windows.Forms.TextBox();
			this.txUsername = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txCreated = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txCompleted = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txState = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txNumThreads = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.chkPrimary = new System.Windows.Forms.CheckBox();
			this.btnStop = new System.Windows.Forms.Button();
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
			this.tabGeneral.Controls.Add(this.btnStop);
			this.tabGeneral.Controls.Add(this.chkPrimary);
			this.tabGeneral.Controls.Add(this.txNumThreads);
			this.tabGeneral.Controls.Add(this.label6);
			this.tabGeneral.Controls.Add(this.txState);
			this.tabGeneral.Controls.Add(this.label5);
			this.tabGeneral.Controls.Add(this.txCompleted);
			this.tabGeneral.Controls.Add(this.label4);
			this.tabGeneral.Controls.Add(this.txCreated);
			this.tabGeneral.Controls.Add(this.label3);
			this.tabGeneral.Controls.Add(this.txUsername);
			this.tabGeneral.Controls.Add(this.label2);
			this.tabGeneral.Controls.Add(this.txId);
			this.tabGeneral.Controls.Add(this.lbId);
			this.tabGeneral.Name = "tabGeneral";
			this.tabGeneral.Controls.SetChildIndex(this.lbId, 0);
			this.tabGeneral.Controls.SetChildIndex(this.txId, 0);
			this.tabGeneral.Controls.SetChildIndex(this.iconBox, 0);
			this.tabGeneral.Controls.SetChildIndex(this.lbName, 0);
			this.tabGeneral.Controls.SetChildIndex(this.lineLabel, 0);
			this.tabGeneral.Controls.SetChildIndex(this.label2, 0);
			this.tabGeneral.Controls.SetChildIndex(this.txUsername, 0);
			this.tabGeneral.Controls.SetChildIndex(this.label3, 0);
			this.tabGeneral.Controls.SetChildIndex(this.txCreated, 0);
			this.tabGeneral.Controls.SetChildIndex(this.label4, 0);
			this.tabGeneral.Controls.SetChildIndex(this.txCompleted, 0);
			this.tabGeneral.Controls.SetChildIndex(this.label5, 0);
			this.tabGeneral.Controls.SetChildIndex(this.txState, 0);
			this.tabGeneral.Controls.SetChildIndex(this.label6, 0);
			this.tabGeneral.Controls.SetChildIndex(this.txNumThreads, 0);
			this.tabGeneral.Controls.SetChildIndex(this.chkPrimary, 0);
			this.tabGeneral.Controls.SetChildIndex(this.btnStop, 0);
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
			// lbId
			// 
			this.lbId.AutoSize = true;
			this.lbId.Location = new System.Drawing.Point(16, 72);
			this.lbId.Name = "lbId";
			this.lbId.Size = new System.Drawing.Size(17, 16);
			this.lbId.TabIndex = 4;
			this.lbId.Text = "Id:";
			// 
			// txId
			// 
			this.txId.BackColor = System.Drawing.Color.White;
			this.txId.Location = new System.Drawing.Point(88, 72);
			this.txId.Name = "txId";
			this.txId.ReadOnly = true;
			this.txId.Size = new System.Drawing.Size(224, 20);
			this.txId.TabIndex = 5;
			this.txId.Text = "";
			// 
			// txUsername
			// 
			this.txUsername.BackColor = System.Drawing.Color.White;
			this.txUsername.Location = new System.Drawing.Point(88, 104);
			this.txUsername.Name = "txUsername";
			this.txUsername.ReadOnly = true;
			this.txUsername.Size = new System.Drawing.Size(224, 20);
			this.txUsername.TabIndex = 9;
			this.txUsername.Text = "";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 16);
			this.label2.TabIndex = 8;
			this.label2.Text = "User name:";
			// 
			// txCreated
			// 
			this.txCreated.BackColor = System.Drawing.Color.White;
			this.txCreated.Location = new System.Drawing.Point(88, 136);
			this.txCreated.Name = "txCreated";
			this.txCreated.ReadOnly = true;
			this.txCreated.Size = new System.Drawing.Size(224, 20);
			this.txCreated.TabIndex = 11;
			this.txCreated.Text = "";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 136);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 16);
			this.label3.TabIndex = 10;
			this.label3.Text = "Created:";
			// 
			// txCompleted
			// 
			this.txCompleted.BackColor = System.Drawing.Color.White;
			this.txCompleted.Location = new System.Drawing.Point(88, 168);
			this.txCompleted.Name = "txCompleted";
			this.txCompleted.ReadOnly = true;
			this.txCompleted.Size = new System.Drawing.Size(224, 20);
			this.txCompleted.TabIndex = 13;
			this.txCompleted.Text = "";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 168);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(62, 16);
			this.label4.TabIndex = 12;
			this.label4.Text = "Completed:";
			// 
			// txState
			// 
			this.txState.BackColor = System.Drawing.Color.White;
			this.txState.Location = new System.Drawing.Point(88, 200);
			this.txState.Name = "txState";
			this.txState.ReadOnly = true;
			this.txState.Size = new System.Drawing.Size(120, 20);
			this.txState.TabIndex = 15;
			this.txState.Text = "";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(16, 200);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(34, 16);
			this.label5.TabIndex = 14;
			this.label5.Text = "State:";
			// 
			// txNumThreads
			// 
			this.txNumThreads.BackColor = System.Drawing.Color.White;
			this.txNumThreads.Location = new System.Drawing.Point(88, 232);
			this.txNumThreads.Name = "txNumThreads";
			this.txNumThreads.ReadOnly = true;
			this.txNumThreads.Size = new System.Drawing.Size(120, 20);
			this.txNumThreads.TabIndex = 17;
			this.txNumThreads.Text = "";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(16, 232);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(67, 16);
			this.label6.TabIndex = 16;
			this.label6.Text = "# of threads:";
			// 
			// chkPrimary
			// 
			this.chkPrimary.AutoCheck = false;
			this.chkPrimary.Location = new System.Drawing.Point(16, 256);
			this.chkPrimary.Name = "chkPrimary";
			this.chkPrimary.TabIndex = 18;
			this.chkPrimary.Text = "Primary";
			// 
			// btnStop
			// 
			this.btnStop.Location = new System.Drawing.Point(248, 288);
			this.btnStop.Name = "btnStop";
			this.btnStop.TabIndex = 19;
			this.btnStop.Text = "Stop";
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// ApplicationProperties
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(352, 389);
			this.Name = "ApplicationProperties";
			this.Text = "Application Properties";
			this.tabs.ResumeLayout(false);
			this.tabGeneral.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnStop_Click(object sender, System.EventArgs e)
		{
			try
			{
				//try to stop the application.
				console.Manager.Owner_StopApplication(console.Credentials, this._app.ApplicationId) ;
				MessageBox.Show("Application Stopped.","Applcation Properties",MessageBoxButtons.OK,  MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				if (ex is AuthorizationException)
				{
					MessageBox.Show("Access denied. You do not have adequate permissions for this operation.","Authorization Error",MessageBoxButtons.OK,  MessageBoxIcon.Error);
				}
				else
				{
					logger.Error("Could not stop application. Error: "+ex.Message, ex);
					MessageBox.Show("Could not stop application. Error: "+ex.Message,"Console Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
				}			
			}
		}
	}
}

