using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Alchemi.Core;
using Alchemi.Core.Manager;
using Alchemi.Core.Manager.Storage;
using Alchemi.Core.Owner;

namespace Alchemi.Console.PropertiesDialogs
{
	public class ThreadProperties : Alchemi.Console.PropertiesDialogs.PropertiesForm
	{
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox txState;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txCompleted;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txCreated;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txApplication;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txExecutor;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txPriority;
		private System.Windows.Forms.Label label6;

		private ThreadStorageView _thread;
		private System.Windows.Forms.Button btnStop;
		private ConsoleNode console;

		// Create a logger for use in this class
		private static readonly Logger logger = new Logger();

		public ThreadProperties(ConsoleNode console)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			
			this.console = console;
		}

		public void SetData(ThreadStorageView thread)
		{
			try
			{
				this._thread = thread;
				
				btnStop.Enabled = (_thread.State != ThreadState.Dead && _thread.State!=ThreadState.Finished );

				this.lbName.Text = _thread.ThreadId.ToString();
				txApplication.Text = _thread.ApplicationId;

				txExecutor.Text = _thread.ExecutorId;

				if (_thread.TimeStarted!=DateTime.MinValue)
					txCreated.Text = _thread.TimeStarted.ToString();

				if (_thread.TimeFinished!=DateTime.MinValue)
					txCompleted.Text = _thread.TimeFinished.ToString();

				txState.Text = _thread.StateString;
				txPriority.Text = _thread.Priority.ToString();

				ExecutorStorageView executor = console.Manager.Admon_GetExecutor(console.Credentials, _thread.ExecutorId);
				if (executor != null && executor.HostName != null)
				{
						txExecutor.Text = executor.HostName;			
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error getting thread properties:"+ex.Message, "Thread properties", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ThreadProperties));
			this.txState = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txCompleted = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txCreated = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txApplication = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txExecutor = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txPriority = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
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
			this.tabGeneral.Controls.Add(this.txPriority);
			this.tabGeneral.Controls.Add(this.label6);
			this.tabGeneral.Controls.Add(this.txExecutor);
			this.tabGeneral.Controls.Add(this.label2);
			this.tabGeneral.Controls.Add(this.txState);
			this.tabGeneral.Controls.Add(this.label5);
			this.tabGeneral.Controls.Add(this.txCompleted);
			this.tabGeneral.Controls.Add(this.label4);
			this.tabGeneral.Controls.Add(this.txCreated);
			this.tabGeneral.Controls.Add(this.label3);
			this.tabGeneral.Controls.Add(this.txApplication);
			this.tabGeneral.Controls.Add(this.label1);
			this.tabGeneral.Name = "tabGeneral";
			this.tabGeneral.Controls.SetChildIndex(this.iconBox, 0);
			this.tabGeneral.Controls.SetChildIndex(this.lbName, 0);
			this.tabGeneral.Controls.SetChildIndex(this.lineLabel, 0);
			this.tabGeneral.Controls.SetChildIndex(this.label1, 0);
			this.tabGeneral.Controls.SetChildIndex(this.txApplication, 0);
			this.tabGeneral.Controls.SetChildIndex(this.label3, 0);
			this.tabGeneral.Controls.SetChildIndex(this.txCreated, 0);
			this.tabGeneral.Controls.SetChildIndex(this.label4, 0);
			this.tabGeneral.Controls.SetChildIndex(this.txCompleted, 0);
			this.tabGeneral.Controls.SetChildIndex(this.label5, 0);
			this.tabGeneral.Controls.SetChildIndex(this.txState, 0);
			this.tabGeneral.Controls.SetChildIndex(this.label2, 0);
			this.tabGeneral.Controls.SetChildIndex(this.txExecutor, 0);
			this.tabGeneral.Controls.SetChildIndex(this.label6, 0);
			this.tabGeneral.Controls.SetChildIndex(this.txPriority, 0);
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
			// txState
			// 
			this.txState.BackColor = System.Drawing.Color.White;
			this.txState.Location = new System.Drawing.Point(88, 200);
			this.txState.Name = "txState";
			this.txState.ReadOnly = true;
			this.txState.Size = new System.Drawing.Size(120, 20);
			this.txState.TabIndex = 25;
			this.txState.Text = "";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(16, 200);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(34, 16);
			this.label5.TabIndex = 24;
			this.label5.Text = "State:";
			// 
			// txCompleted
			// 
			this.txCompleted.BackColor = System.Drawing.Color.White;
			this.txCompleted.Location = new System.Drawing.Point(88, 168);
			this.txCompleted.Name = "txCompleted";
			this.txCompleted.ReadOnly = true;
			this.txCompleted.Size = new System.Drawing.Size(224, 20);
			this.txCompleted.TabIndex = 23;
			this.txCompleted.Text = "";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 168);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(62, 16);
			this.label4.TabIndex = 22;
			this.label4.Text = "Completed:";
			// 
			// txCreated
			// 
			this.txCreated.BackColor = System.Drawing.Color.White;
			this.txCreated.Location = new System.Drawing.Point(88, 136);
			this.txCreated.Name = "txCreated";
			this.txCreated.ReadOnly = true;
			this.txCreated.Size = new System.Drawing.Size(224, 20);
			this.txCreated.TabIndex = 21;
			this.txCreated.Text = "";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 136);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 16);
			this.label3.TabIndex = 20;
			this.label3.Text = "Created:";
			// 
			// txApplication
			// 
			this.txApplication.BackColor = System.Drawing.Color.White;
			this.txApplication.Location = new System.Drawing.Point(88, 72);
			this.txApplication.Name = "txApplication";
			this.txApplication.ReadOnly = true;
			this.txApplication.Size = new System.Drawing.Size(224, 20);
			this.txApplication.TabIndex = 19;
			this.txApplication.Text = "";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 72);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 16);
			this.label1.TabIndex = 18;
			this.label1.Text = "Application:";
			// 
			// txExecutor
			// 
			this.txExecutor.BackColor = System.Drawing.Color.White;
			this.txExecutor.Location = new System.Drawing.Point(88, 104);
			this.txExecutor.Name = "txExecutor";
			this.txExecutor.ReadOnly = true;
			this.txExecutor.Size = new System.Drawing.Size(224, 20);
			this.txExecutor.TabIndex = 27;
			this.txExecutor.Text = "";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 16);
			this.label2.TabIndex = 26;
			this.label2.Text = "Executor:";
			// 
			// txPriority
			// 
			this.txPriority.BackColor = System.Drawing.Color.White;
			this.txPriority.Location = new System.Drawing.Point(88, 232);
			this.txPriority.Name = "txPriority";
			this.txPriority.ReadOnly = true;
			this.txPriority.Size = new System.Drawing.Size(120, 20);
			this.txPriority.TabIndex = 29;
			this.txPriority.Text = "";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(16, 232);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(43, 16);
			this.label6.TabIndex = 28;
			this.label6.Text = "Priority:";
			// 
			// btnStop
			// 
			this.btnStop.Location = new System.Drawing.Point(248, 288);
			this.btnStop.Name = "btnStop";
			this.btnStop.TabIndex = 30;
			this.btnStop.Text = "Abort";
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// ThreadProperties
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(352, 389);
			this.Name = "ThreadProperties";
			this.Text = "Thread Properties";
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
				ThreadIdentifier ti = new ThreadIdentifier(_thread.ApplicationId, _thread.ThreadId);
				console.Manager.Owner_AbortThread(console.Credentials, ti);
				MessageBox.Show("Thread Aborted.","Applcation Properties",MessageBoxButtons.OK,  MessageBoxIcon.Information);
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

