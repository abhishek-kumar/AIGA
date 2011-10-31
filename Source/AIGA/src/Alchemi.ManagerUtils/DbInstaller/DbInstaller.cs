#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	DBInstaller.cs
* Project		:	Alchemi DB Installer
* Created on	:	2003
* Copyright		:	Copyright © 2006 The University of Melbourne
*					This technology has been developed with the support of 
*					the Australian Research Council and the University of Melbourne
*					research grants as part of the Gridbus Project
*					within GRIDS Laboratory at the University of Melbourne, Australia.
* Author         :  Akshay Luther (akshayl@cs.mu.oz.au), Rajkumar Buyya (raj@cs.mu.oz.au) and Krishna Nadiminti (kna@cs.mu.oz.au)
* License        :  GPL
*					This program is free software; you can redistribute it and/or 
*					modify it under the terms of the GNU General Public
*					License as published by the Free Software Foundation;
*					See the GNU General Public License 
*					(http://www.gnu.org/copyleft/gpl.html) for more details.
*
*/ 
#endregion

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

using Alchemi.Core.Manager.Storage;
using Alchemi.Manager;
using Alchemi.Manager.Storage;

using System.Resources;

namespace Alchemi.ManagerUtils.DbInstaller
{
    public class DbInstaller : Form
    {
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private TextBox txServer;
        private TextBox txAdminPwd;
        private Button btInstall;
        private Button btFinish;
        private Label label3;
        private TextBox txUsername;
        private GroupBox groupBox2;
        private TextBox txLog;
        private Label label4;
        private PictureBox pictureBox1;
        private Button btSkip;
		private System.Windows.Forms.ComboBox cboServerType;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.FolderBrowserDialog dirBox;
        private Container components = null;

        private string InstallLocation = "";
		private string scriptLocation = "sql";

        public DbInstaller(string installLocation)
        {
            InitializeComponent();

			cboServerType.SelectedIndex = 0;

            btFinish.Enabled = false;
            txServer.Text = Dns.GetHostName();
            if (installLocation == "")
            {
                InstallLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\";
            }
            else
            {
				//remove invalid characters from the path
				char[] invalidchars = Path.InvalidPathChars;
				foreach (char c in invalidchars)
				{
					int index = installLocation.IndexOf(c);
					if (index>=0)
					{
						installLocation = installLocation.Remove(index,1);
					}
				}
                InstallLocation = installLocation;
            }

			scriptLocation = Path.Combine(InstallLocation, scriptLocation);

        }

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

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DbInstaller));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cboServerType = new System.Windows.Forms.ComboBox();
			this.txUsername = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txServer = new System.Windows.Forms.TextBox();
			this.txAdminPwd = new System.Windows.Forms.TextBox();
			this.btInstall = new System.Windows.Forms.Button();
			this.btFinish = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txLog = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btSkip = new System.Windows.Forms.Button();
			this.dirBox = new System.Windows.Forms.FolderBrowserDialog();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Database Server";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.ImageAlign = System.Drawing.ContentAlignment.TopRight;
			this.label2.Location = new System.Drawing.Point(204, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Password";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.cboServerType);
			this.groupBox1.Controls.Add(this.txUsername);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txServer);
			this.groupBox1.Controls.Add(this.txAdminPwd);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(8, 80);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(488, 80);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Specify Database Server";
			// 
			// label5
			// 
			this.label5.ImageAlign = System.Drawing.ContentAlignment.TopRight;
			this.label5.Location = new System.Drawing.Point(312, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 16);
			this.label5.TabIndex = 8;
			this.label5.Text = "Server-type";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboServerType
			// 
			this.cboServerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboServerType.Items.AddRange(new object[] {
															   "Microsoft SQL Server"});
			this.cboServerType.Location = new System.Drawing.Point(312, 40);
			this.cboServerType.Name = "cboServerType";
			this.cboServerType.Size = new System.Drawing.Size(168, 21);
			this.cboServerType.TabIndex = 7;
			// 
			// txUsername
			// 
			this.txUsername.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txUsername.Location = new System.Drawing.Point(116, 40);
			this.txUsername.Name = "txUsername";
			this.txUsername.Size = new System.Drawing.Size(80, 21);
			this.txUsername.TabIndex = 6;
			this.txUsername.TabStop = false;
			this.txUsername.Text = "sa";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(116, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Username";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txServer
			// 
			this.txServer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txServer.Location = new System.Drawing.Point(8, 40);
			this.txServer.Name = "txServer";
			this.txServer.TabIndex = 2;
			this.txServer.Text = "";
			// 
			// txAdminPwd
			// 
			this.txAdminPwd.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txAdminPwd.Location = new System.Drawing.Point(204, 40);
			this.txAdminPwd.Name = "txAdminPwd";
			this.txAdminPwd.PasswordChar = '*';
			this.txAdminPwd.TabIndex = 3;
			this.txAdminPwd.Text = "";
			// 
			// btInstall
			// 
			this.btInstall.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btInstall.Location = new System.Drawing.Point(256, 352);
			this.btInstall.Name = "btInstall";
			this.btInstall.Size = new System.Drawing.Size(112, 23);
			this.btInstall.TabIndex = 0;
			this.btInstall.Text = "Install";
			this.btInstall.Click += new System.EventHandler(this.btInstall_Click);
			// 
			// btFinish
			// 
			this.btFinish.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btFinish.Location = new System.Drawing.Point(376, 352);
			this.btFinish.Name = "btFinish";
			this.btFinish.Size = new System.Drawing.Size(112, 23);
			this.btFinish.TabIndex = 1;
			this.btFinish.Text = "Close";
			this.btFinish.Click += new System.EventHandler(this.btFinish_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txLog);
			this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox2.Location = new System.Drawing.Point(8, 168);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(488, 168);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Activity Log";
			// 
			// txLog
			// 
			this.txLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txLog.Location = new System.Drawing.Point(8, 16);
			this.txLog.Multiline = true;
			this.txLog.Name = "txLog";
			this.txLog.ReadOnly = true;
			this.txLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txLog.Size = new System.Drawing.Size(472, 144);
			this.txLog.TabIndex = 4;
			this.txLog.TabStop = false;
			this.txLog.Text = "";
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.White;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(8, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(392, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "Install Database";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(500, 70);
			this.pictureBox1.TabIndex = 8;
			this.pictureBox1.TabStop = false;
			// 
			// btSkip
			// 
			this.btSkip.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btSkip.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btSkip.Location = new System.Drawing.Point(8, 352);
			this.btSkip.Name = "btSkip";
			this.btSkip.Size = new System.Drawing.Size(112, 23);
			this.btSkip.TabIndex = 9;
			this.btSkip.Text = "Skip";
			this.btSkip.Click += new System.EventHandler(this.btSkip_Click);
			// 
			// dirBox
			// 
			this.dirBox.RootFolder = System.Environment.SpecialFolder.MyComputer;
			// 
			// DbInstaller
			// 
			this.AcceptButton = this.btInstall;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btSkip;
			this.ClientSize = new System.Drawing.Size(500, 387);
			this.Controls.Add(this.btSkip);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btInstall);
			this.Controls.Add(this.btFinish);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "DbInstaller";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Alchemi Database Installer";
			this.TopMost = true;
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
        #endregion

        [STAThread]
        static void Main(string[] args) 
        {
            string installLocation = "";
            if (args.Length >= 1)
            {
                installLocation = args[0];  
            }
            Application.EnableVisualStyles();
            Application.Run(new DbInstaller(installLocation));
        }

		private void btInstall_Click(object sender, EventArgs e)
		{
			//instead of the old method, just use the ManagerStorageSetup members now.
			Alchemi.Manager.Configuration config = null;

			try
			{
				// serialize configuration
				Log("[ Creating Configuration File ] ... ");

				config = new Alchemi.Manager.Configuration(InstallLocation);
				config.DbServer = txServer.Text;
				config.DbUsername = txUsername.Text;
				config.DbPassword = txAdminPwd.Text;
				config.DbName = "master"; //we need this to initially create the alchemi database.
				config.Slz();
				Log("[ Done ].");

				//for now just use RunSQL method.
				ManagerStorageFactory.CreateManagerStorage(config);
				IManagerStorage store = ManagerStorageFactory.ManagerStorage();

				// (re)create database
				Log("[ Setting up storage ] ... ");

				string scriptPath = Path.Combine(scriptLocation, "Alchemi_database.sql");

				while (!File.Exists(scriptPath))
				{
					MessageBox.Show("Alchemi SQL files not found in folder: " + scriptLocation + ". Please select the folder where the sql scripts are located!", "Locate Script Files", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					DialogResult result = dirBox.ShowDialog(this);
					if (result == DialogResult.Cancel)
						break;
					scriptLocation = dirBox.SelectedPath;
					scriptPath = Path.Combine(scriptLocation, "Alchemi_database.sql");
				}
				
				if (!File.Exists(scriptPath))
				{
					return; //cannot continue.
				}

				// create structure
				Log("[ Creating Database Structure ] ... ");

				//load it from sql files for now. later make use of resources.
				using (FileStream fs = File.OpenRead(scriptPath))
				{
					StreamReader sr = new StreamReader(fs);
					String sql = sr.ReadToEnd();
					sr.Close();
					fs.Close();
					store.RunSql(sql);
				}
				Log("[ Done ].");

				Log("[ Creating tables ] ... ");
				scriptPath = Path.Combine(scriptLocation, "Alchemi_structure.sql");
				//load it from sql files for now. later make use of resources.
				using (FileStream fs = File.OpenRead(scriptPath))
				{
					StreamReader sr = new StreamReader(fs);
					String sql = sr.ReadToEnd();
					sr.Close();
					fs.Close();
					store.RunSql(sql);
				}
				Log("[ Done ].");

				Log("[ Inserting initialization data ] ... ");
				scriptPath = Path.Combine(scriptLocation, "Alchemi_data.sql");
				//load it from sql files for now. later make use of resources.
				using (FileStream fs = File.OpenRead(scriptPath))
				{
					StreamReader sr = new StreamReader(fs);
					String sql = sr.ReadToEnd();
					sr.Close();
					fs.Close();
					store.RunSql(sql);
				}

				Log("[ Done ].");

				// serialize configuration
				Log("[ Updating Configuration File ] ... ");
				config.DbServer = txServer.Text;
				config.DbUsername = txUsername.Text;
				config.DbPassword = txAdminPwd.Text;
				config.DbName = "Alchemi";
				config.Slz();
				Log("[ Done ].");

				Log("Wrote configuration file to " + InstallLocation);
				Log("[ Installation Complete! ]");

				btInstall.Enabled = false;
				btFinish.Enabled = true;
			
			}
			catch (Exception ex)
			{
				Log("[ Error ]");
				Log(ex.Message);
				return;
			}

		}

        private void btInstall_Click1(object sender, EventArgs e) //OLD not used anymore.
        {
        	Process process = new Process();
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.FileName = "osql";
            string outputText = "";

            // (re)create database
            txLog.AppendText("[ Creating Database ] ... ");
            try
            {
				string scriptPath = Path.Combine(InstallLocation,"Alchemi_database.sql");
                process.StartInfo.Arguments = string.Format("-S {0} -U {1} -P {2} -i \"{3}\" -n", txUsername.Text, txServer.Text, txAdminPwd.Text, scriptPath);
				process.Start();
                process.WaitForExit();
                outputText = process.StandardOutput.ReadToEnd();
            }
            catch (Exception ex)
            {
                txLog.AppendText("[ Error ]" + Environment.NewLine);
                if (ex.Message == "The system cannot find the file specified")
                {
                    Log("'osql' could not be found. Check that SQL Server 2000 or MSDE is installed and 'osql' is in the path..");
                }
                else
                {
                    Log(ex.Message);
                }
                return;
            }
      
            if (process.ExitCode == 0)
            {
                txLog.AppendText("[ Done ]" + Environment.NewLine);
                Log(outputText);
            }
            else
            {
                txLog.AppendText("[ Error ]" + Environment.NewLine);
                Log(outputText);
                return;
            }

            // create structure
            txLog.AppendText("[ Creating Database Structure ] ... ");
            try
            {
				string scriptPath = Path.Combine(InstallLocation,"Alchemi_structure.sql");
                process.StartInfo.Arguments = string.Format("-S {0} -U {1} -P {2} -d Alchemi -i \"{3}\" -n", txUsername.Text, txServer.Text, txAdminPwd.Text, scriptPath);
                process.Start();
                process.WaitForExit();
                outputText = process.StandardOutput.ReadToEnd();
            }
            catch (Exception ex)
            {
                txLog.AppendText("[ Error ]" + Environment.NewLine);
                Log(ex.Message);
                return;
            }
      
            if (process.ExitCode == 0)
            {
                txLog.AppendText("[ Done ]" + Environment.NewLine);
                Log(outputText);
            }
            else
            {
                txLog.AppendText("[ Error ]" + Environment.NewLine);
                Log(outputText);
                return;
            }

            // insert data
            txLog.AppendText("[ Inserting Default Data ] ... ");
            try
            {
				string scriptPath = Path.Combine(InstallLocation,"Alchemi_data.sql");
                process.StartInfo.Arguments = string.Format("-S {0} -U {1} -P {2} -d Alchemi -i \"{3}\" -n", txUsername.Text, txServer.Text, txAdminPwd.Text, scriptPath);
                process.Start();
                process.WaitForExit();
                outputText = process.StandardOutput.ReadToEnd();
            }
            catch (Exception ex)
            {
                txLog.AppendText("[ Error ]" + Environment.NewLine);
                Log(ex.Message);
                return;
            }
      
            if (process.ExitCode == 0)
            {
                txLog.AppendText("[ Done ]" + Environment.NewLine);
                Log(outputText);
            }
            else
            {
                txLog.AppendText("[ Error ]" + Environment.NewLine);
                Log(outputText);
                return;
            }

            // serialize configuration
            txLog.AppendText("[ Creating Configuration File ] ... ");
            try
            {
				//get the manager install location. it is ../v.v.v
				//string mgrInstallDir = Path.Combine(Directory.GetParent(InstallLocation).FullName,Alchemi.Core.Utility.Utils.AssemblyVersion);
				txLog.AppendText(" Writing Configuration to " + InstallLocation + Environment.NewLine);
            	Configuration config = new Configuration(InstallLocation);
                config.DbServer = txServer.Text;
                config.DbUsername = txUsername.Text;
                config.DbPassword = txAdminPwd.Text;
                config.Slz();
                txLog.AppendText("[ Done ]" + Environment.NewLine);
                Log("wrote configuration file to " + InstallLocation);
            }
            catch (Exception ex)
            {
                txLog.AppendText("[ Error ]" + Environment.NewLine);
                Log(ex.ToString());
            }

            Log("");
            Log("[ Installation Complete! ]");

            btInstall.Enabled = false;
            btFinish.Enabled = true;
        }

        private void Log(string s)
        {
            txLog.AppendText(s + Environment.NewLine);
        }

        private void btFinish_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btSkip_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
