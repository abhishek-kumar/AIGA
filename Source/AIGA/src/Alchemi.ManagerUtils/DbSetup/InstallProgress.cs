#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  InstallerProgress.cs
* Project       :  Alchemi.ManagerUtils.DbSetup
* Created on    :  18 January 2005
* Copyright     :  Copyright © 2005 The University of Melbourne
*                    This technology has been developed with the support of
*                    the Australian Research Council and the University of Melbourne
*                    research grants as part of the Gridbus Project
*                    within GRIDS Laboratory at the University of Melbourne, Australia.
* Author        :  Tibor Biro (tb@tbiro.com)
* License       :  GPL
*                    This program is free software; you can redistribute it and/or
*                    modify it under the terms of the GNU General Public
*                    License as published by the Free Software Foundation;
*                    See the GNU General Public License
*                    (http://www.gnu.org/copyleft/gpl.html) for more 
details.
*
*/
#endregion

using System;
using System.ComponentModel;
using System.Windows.Forms;
using Alchemi.Core.Manager.Storage;
using Alchemi.Manager.Storage;

namespace Alchemi.ManagerUtils.DbSetup
{
	/// <summary>
	/// Display the installation progress.
	/// 
	/// The actual installation is done in another thread: WorkerThread.
	/// </summary>
	public class InstallProgress : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox logTextBox;
		private System.Windows.Forms.Button cancelButton;
		private Installer m_parent;
		private System.Windows.Forms.ProgressBar installProgressBar;
		private System.Windows.Forms.Button closeButton;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public InstallProgress(Installer parent)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.Closing += new CancelEventHandler(InstallProgress_Closing);

			m_parent = parent;

			Size = m_parent.Size;
			Location = m_parent.Location;

			closeButton.Size = cancelButton.Size;
			closeButton.Location = cancelButton.Location;

			cancelButton.Visible = true;
			closeButton.Visible = false;

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(InstallProgress));
			this.logTextBox = new System.Windows.Forms.TextBox();
			this.cancelButton = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label7 = new System.Windows.Forms.Label();
			this.installProgressBar = new System.Windows.Forms.ProgressBar();
			this.closeButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// logTextBox
			// 
			this.logTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.logTextBox.Location = new System.Drawing.Point(8, 80);
			this.logTextBox.Multiline = true;
			this.logTextBox.Name = "logTextBox";
			this.logTextBox.ReadOnly = true;
			this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.logTextBox.Size = new System.Drawing.Size(480, 208);
			this.logTextBox.TabIndex = 1;
			this.logTextBox.Text = "";
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cancelButton.Location = new System.Drawing.Point(211, 336);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.TabIndex = 2;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(500, 70);
			this.pictureBox1.TabIndex = 10;
			this.pictureBox1.TabStop = false;
			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.Color.White;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label7.Location = new System.Drawing.Point(8, 8);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(392, 23);
			this.label7.TabIndex = 11;
			this.label7.Text = "Setting up database - please wait";
			// 
			// installProgressBar
			// 
			this.installProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.installProgressBar.Location = new System.Drawing.Point(8, 296);
			this.installProgressBar.Name = "installProgressBar";
			this.installProgressBar.Size = new System.Drawing.Size(480, 23);
			this.installProgressBar.TabIndex = 12;
			// 
			// closeButton
			// 
			this.closeButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.closeButton.Location = new System.Drawing.Point(208, 360);
			this.closeButton.Name = "closeButton";
			this.closeButton.TabIndex = 13;
			this.closeButton.Text = "Close";
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// InstallProgress
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(496, 397);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.installProgressBar);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.logTextBox);
			this.Name = "InstallProgress";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Install Progress";
			this.Load += new System.EventHandler(this.InstallProgress_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void InstallProgress_Load(object sender, System.EventArgs e)
		{
			m_parent.Visible = false;

			// start the installer on its own thread so we get proper feedback
			MethodInvoker mi = new MethodInvoker(
				WorkerThread);
			mi.BeginInvoke(null, null); 
		}

		private void InstallProgress_Closing(object sender, CancelEventArgs e)
		{
			m_parent.Size = Size;
			m_parent.Location = Location;

			m_parent.Visible = true;
		}
 
		private delegate void MyProgressEventsHandler(
			object sender, InstallerProgressEvent e);
 
		private void UpdateUI(object sender, InstallerProgressEvent e) 
		{
			if (e.Message.Length > 0)
			{
				logTextBox.AppendText(e.Message + Environment.NewLine);

				logTextBox.SelectionStart = logTextBox.Text.Length;
				logTextBox.SelectionLength = 0;
			}

			installProgressBar.Value = e.PercentDone;

			if (e.PercentDone == installProgressBar.Maximum)
			{
				cancelButton.Visible = false;
				closeButton.Visible = true;
			}
		}

		public void ShowProgress(string message, int percentDone) 
		{
			if (InvokeRequired) 
			{
				// Wrap the parameters in some EventArgs-derived custom class:
				System.EventArgs e = new InstallerProgressEvent(message, percentDone);
				object[] pList = { this, e };
 
				// Invoke the method. This class is derived
				// from Form, so we can just call BeginInvoke
				// to get to the UI thread.
				BeginInvoke(new MyProgressEventsHandler(UpdateUI), pList);
			} 
			else 
			{
				// We're already on the UI thread just
				// call straight through.
				UpdateUI(this, new InstallerProgressEvent(message,
					percentDone));
			}
		}
		/// <summary>
		/// Thread doing the actual installation
		/// </summary>
		private void WorkerThread()
		{
			ShowProgress("Installer thread starting...", 
				0);

			ShowProgress(String.Format("Database type: {0}", m_parent.managerConfiguration.DbType), 
				0);

			try
			{
				/// Create a storage object with the initial catalogue left to the default one.
				/// This is usually master for SQL Server or nothing for mySQL
				IManagerStorage storage = ManagerStorageFactory.CreateManagerStorage(m_parent.managerConfiguration, false);

				// this storage object is also a storage setup object so it is safe to cast
				IManagerStorageSetup setup = (IManagerStorageSetup)storage;

				ShowProgress("Creating the database.",
					1);

				setup.CreateStorage(m_parent.managerConfiguration.DbName);

				ShowProgress("Database created.",
					20);
			}
			catch (Exception ex1)
			{
				ShowProgress("Unable to create the database. Error message:" + ex1.Message,
					100);
#if DEBUG
				ShowProgress("Debug information:",
					100);
				ShowProgress(ex1.ToString(),
					100);
#endif
				return;
			}

			try
			{
				IManagerStorage storage = ManagerStorageFactory.CreateManagerStorage(m_parent.managerConfiguration);

				// this storage object is also a storage setup object so it is safe to cast
				IManagerStorageSetup setup = (IManagerStorageSetup)storage;

				ShowProgress("Creating the database structure.",
					40);

				// create storage structures
				setup.SetUpStorage();

				ShowProgress("Database structure created.",
					60);

				ShowProgress("Creating default users, groups and permissions.",
					80);

				// insert the default values
				setup.InitializeStorageData();

				ShowProgress("All default objects created.",
					90);
			}
			catch (Exception ex2)
			{
				ShowProgress("Unable to initialize the database data. Error message:" + ex2.Message,
					100);
#if DEBUG
				ShowProgress("Debug information:",
					100);
				ShowProgress(ex2.ToString(),
					100);
#endif
				return;
			}

			ShowProgress("Done!",
				100);
			
		}

		private void cancelButton_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		private void closeButton_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}
	}
}
