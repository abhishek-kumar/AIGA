#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  Installer.cs
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
using System.Collections;
using System.IO;
using System.Windows.Forms;

using Alchemi.Manager;
using Alchemi.Manager.Storage;

namespace Alchemi.ManagerUtils.DbSetup
{
	/// <summary>
	/// Summary description for Installer.
	/// </summary>
	public class Installer : System.Windows.Forms.Form
	{
		#region Controls

		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private Label label6;
		private Label label7;
		
		private TabControl tabs;
		private TabPage configurationFileTab;
		private TabPage storageTypeTab;
		private TabPage databaseLocationTab;
		private TabPage databaseUserTab;

		private Button storageTypePrevious;
		private Button storageTypeNext;
		private Button databaseLocationPrevious;
		private Button databaseLocationNext;
		private Button databaseUserPrevious;
		private Button configurationFileNext;
		private Button browseForManagerLocation;
		private Button installButton;
		private Button saveButton;

		private TextBox managerLocation;
		private TextBox databaseServer;
		private TextBox databaseName;
		private TextBox databasePassword;
		private TextBox databaseUsername;

		private ComboBox managerStorageTypes;

		private PictureBox pictureBox1;

		private FolderBrowserDialog folderBrowser;

		#endregion

		private String initialManagerLocation;
		private TabPage[] allTabs;
		public Configuration managerConfiguration;
		private TabPage visibleTab;

		private bool firstInstall;
		private bool configurationFileChanged;
		private bool databaseInstalled;
		private System.Windows.Forms.Button closeButton;


		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Installer(String startingManagerLocation)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			configurationFileChanged = false;
			databaseInstalled = false;

			if (startingManagerLocation != null && startingManagerLocation.Length != 0)
			{
				initialManagerLocation = startingManagerLocation;
			}
			else
			{
				initialManagerLocation = AppDomain.CurrentDomain.BaseDirectory;
			}

			this.Closing += new System.ComponentModel.CancelEventHandler(Installer_Closing);

			closeButton.Visible = false;

			managerLocation.ReadOnly = true;

			managerLocation.DoubleClick += new EventHandler(managerLocation_DoubleClick);

			// put handlers on the data changed events
			databaseName.TextChanged += new EventHandler(DataChanged);
			databaseServer.TextChanged += new EventHandler(DataChanged);
			databaseName.TextChanged += new EventHandler(DataChanged);
			databasePassword.TextChanged += new EventHandler(DataChanged);
			databaseUsername.TextChanged += new EventHandler(DataChanged);
			managerStorageTypes.SelectedIndexChanged += new EventHandler(DataChanged);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Installer));
			this.tabs = new System.Windows.Forms.TabControl();
			this.configurationFileTab = new System.Windows.Forms.TabPage();
			this.configurationFileNext = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.browseForManagerLocation = new System.Windows.Forms.Button();
			this.managerLocation = new System.Windows.Forms.TextBox();
			this.storageTypeTab = new System.Windows.Forms.TabPage();
			this.storageTypePrevious = new System.Windows.Forms.Button();
			this.managerStorageTypes = new System.Windows.Forms.ComboBox();
			this.storageTypeNext = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.databaseLocationTab = new System.Windows.Forms.TabPage();
			this.databaseLocationPrevious = new System.Windows.Forms.Button();
			this.databaseName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.databaseLocationNext = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.databaseServer = new System.Windows.Forms.TextBox();
			this.databaseUserTab = new System.Windows.Forms.TabPage();
			this.databaseUserPrevious = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.databasePassword = new System.Windows.Forms.TextBox();
			this.databaseUsername = new System.Windows.Forms.TextBox();
			this.saveButton = new System.Windows.Forms.Button();
			this.installButton = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label7 = new System.Windows.Forms.Label();
			this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
			this.closeButton = new System.Windows.Forms.Button();
			this.tabs.SuspendLayout();
			this.configurationFileTab.SuspendLayout();
			this.storageTypeTab.SuspendLayout();
			this.databaseLocationTab.SuspendLayout();
			this.databaseUserTab.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabs
			// 
			this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabs.Controls.Add(this.configurationFileTab);
			this.tabs.Controls.Add(this.storageTypeTab);
			this.tabs.Controls.Add(this.databaseLocationTab);
			this.tabs.Controls.Add(this.databaseUserTab);
			this.tabs.Location = new System.Drawing.Point(16, 88);
			this.tabs.Name = "tabs";
			this.tabs.SelectedIndex = 0;
			this.tabs.Size = new System.Drawing.Size(464, 224);
			this.tabs.TabIndex = 0;
			this.tabs.SelectedIndexChanged += new System.EventHandler(this.tabs_SelectedIndexChanged);
			// 
			// configurationFileTab
			// 
			this.configurationFileTab.Controls.Add(this.configurationFileNext);
			this.configurationFileTab.Controls.Add(this.label1);
			this.configurationFileTab.Controls.Add(this.browseForManagerLocation);
			this.configurationFileTab.Controls.Add(this.managerLocation);
			this.configurationFileTab.Location = new System.Drawing.Point(4, 22);
			this.configurationFileTab.Name = "configurationFileTab";
			this.configurationFileTab.Size = new System.Drawing.Size(456, 198);
			this.configurationFileTab.TabIndex = 0;
			this.configurationFileTab.Text = "Configuration File";
			// 
			// configurationFileNext
			// 
			this.configurationFileNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.configurationFileNext.Location = new System.Drawing.Point(360, 160);
			this.configurationFileNext.Name = "configurationFileNext";
			this.configurationFileNext.TabIndex = 3;
			this.configurationFileNext.Text = "Next";
			this.configurationFileNext.Click += new System.EventHandler(this.configurationFileNext_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Manager location";
			// 
			// browseForManagerLocation
			// 
			this.browseForManagerLocation.Location = new System.Drawing.Point(320, 80);
			this.browseForManagerLocation.Name = "browseForManagerLocation";
			this.browseForManagerLocation.TabIndex = 1;
			this.browseForManagerLocation.Text = "Browse";
			this.browseForManagerLocation.Click += new System.EventHandler(this.browseForManagerLocation_Click);
			// 
			// managerLocation
			// 
			this.managerLocation.Location = new System.Drawing.Point(32, 80);
			this.managerLocation.Name = "managerLocation";
			this.managerLocation.Size = new System.Drawing.Size(240, 20);
			this.managerLocation.TabIndex = 0;
			this.managerLocation.Text = "";
			// 
			// storageTypeTab
			// 
			this.storageTypeTab.Controls.Add(this.storageTypePrevious);
			this.storageTypeTab.Controls.Add(this.managerStorageTypes);
			this.storageTypeTab.Controls.Add(this.storageTypeNext);
			this.storageTypeTab.Controls.Add(this.label2);
			this.storageTypeTab.Location = new System.Drawing.Point(4, 22);
			this.storageTypeTab.Name = "storageTypeTab";
			this.storageTypeTab.Size = new System.Drawing.Size(456, 198);
			this.storageTypeTab.TabIndex = 1;
			this.storageTypeTab.Text = "Storage Type";
			// 
			// storageTypePrevious
			// 
			this.storageTypePrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.storageTypePrevious.Location = new System.Drawing.Point(16, 160);
			this.storageTypePrevious.Name = "storageTypePrevious";
			this.storageTypePrevious.TabIndex = 3;
			this.storageTypePrevious.Text = "Previous";
			this.storageTypePrevious.Click += new System.EventHandler(this.storageTypePrevious_Click);
			// 
			// managerStorageTypes
			// 
			this.managerStorageTypes.Location = new System.Drawing.Point(24, 80);
			this.managerStorageTypes.Name = "managerStorageTypes";
			this.managerStorageTypes.Size = new System.Drawing.Size(200, 21);
			this.managerStorageTypes.TabIndex = 2;
			this.managerStorageTypes.SelectedIndexChanged += new System.EventHandler(this.managerStorageTypes_SelectedIndexChanged);
			// 
			// storageTypeNext
			// 
			this.storageTypeNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.storageTypeNext.Location = new System.Drawing.Point(360, 160);
			this.storageTypeNext.Name = "storageTypeNext";
			this.storageTypeNext.TabIndex = 1;
			this.storageTypeNext.Text = "Next";
			this.storageTypeNext.Click += new System.EventHandler(this.storageTypeNext_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(168, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "Select your storage type";
			// 
			// databaseLocationTab
			// 
			this.databaseLocationTab.Controls.Add(this.databaseLocationPrevious);
			this.databaseLocationTab.Controls.Add(this.databaseName);
			this.databaseLocationTab.Controls.Add(this.label4);
			this.databaseLocationTab.Controls.Add(this.databaseLocationNext);
			this.databaseLocationTab.Controls.Add(this.label3);
			this.databaseLocationTab.Controls.Add(this.databaseServer);
			this.databaseLocationTab.Location = new System.Drawing.Point(4, 22);
			this.databaseLocationTab.Name = "databaseLocationTab";
			this.databaseLocationTab.Size = new System.Drawing.Size(456, 198);
			this.databaseLocationTab.TabIndex = 2;
			this.databaseLocationTab.Text = "Database location";
			// 
			// databaseLocationPrevious
			// 
			this.databaseLocationPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.databaseLocationPrevious.Location = new System.Drawing.Point(16, 160);
			this.databaseLocationPrevious.Name = "databaseLocationPrevious";
			this.databaseLocationPrevious.TabIndex = 5;
			this.databaseLocationPrevious.Text = "Previous";
			this.databaseLocationPrevious.Click += new System.EventHandler(this.databaseLocationPrevious_Click);
			// 
			// databaseName
			// 
			this.databaseName.Location = new System.Drawing.Point(144, 96);
			this.databaseName.Name = "databaseName";
			this.databaseName.TabIndex = 4;
			this.databaseName.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 96);
			this.label4.Name = "label4";
			this.label4.TabIndex = 3;
			this.label4.Text = "Database name";
			// 
			// databaseLocationNext
			// 
			this.databaseLocationNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.databaseLocationNext.Location = new System.Drawing.Point(360, 160);
			this.databaseLocationNext.Name = "databaseLocationNext";
			this.databaseLocationNext.TabIndex = 2;
			this.databaseLocationNext.Text = "Next";
			this.databaseLocationNext.Click += new System.EventHandler(this.databaseLocationNext_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 48);
			this.label3.Name = "label3";
			this.label3.TabIndex = 1;
			this.label3.Text = "Database server";
			// 
			// databaseServer
			// 
			this.databaseServer.Location = new System.Drawing.Point(144, 48);
			this.databaseServer.Name = "databaseServer";
			this.databaseServer.TabIndex = 0;
			this.databaseServer.Text = "";
			// 
			// databaseUserTab
			// 
			this.databaseUserTab.Controls.Add(this.databaseUserPrevious);
			this.databaseUserTab.Controls.Add(this.label6);
			this.databaseUserTab.Controls.Add(this.label5);
			this.databaseUserTab.Controls.Add(this.databasePassword);
			this.databaseUserTab.Controls.Add(this.databaseUsername);
			this.databaseUserTab.Location = new System.Drawing.Point(4, 22);
			this.databaseUserTab.Name = "databaseUserTab";
			this.databaseUserTab.Size = new System.Drawing.Size(456, 198);
			this.databaseUserTab.TabIndex = 3;
			this.databaseUserTab.Text = "Database user";
			// 
			// databaseUserPrevious
			// 
			this.databaseUserPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.databaseUserPrevious.Location = new System.Drawing.Point(16, 160);
			this.databaseUserPrevious.Name = "databaseUserPrevious";
			this.databaseUserPrevious.TabIndex = 5;
			this.databaseUserPrevious.Text = "Previous";
			this.databaseUserPrevious.Click += new System.EventHandler(this.databaseUserPrevious_Click);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(32, 32);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(120, 23);
			this.label6.TabIndex = 4;
			this.label6.Text = "Database username";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(32, 72);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(104, 23);
			this.label5.TabIndex = 3;
			this.label5.Text = "Database password";
			// 
			// databasePassword
			// 
			this.databasePassword.Location = new System.Drawing.Point(168, 72);
			this.databasePassword.Name = "databasePassword";
			this.databasePassword.TabIndex = 2;
			this.databasePassword.Text = "";
			// 
			// databaseUsername
			// 
			this.databaseUsername.Location = new System.Drawing.Point(168, 32);
			this.databaseUsername.Name = "databaseUsername";
			this.databaseUsername.TabIndex = 0;
			this.databaseUsername.Text = "";
			// 
			// saveButton
			// 
			this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.saveButton.Location = new System.Drawing.Point(32, 344);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(144, 23);
			this.saveButton.TabIndex = 1;
			this.saveButton.Text = "Save Configuration File";
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// installButton
			// 
			this.installButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.installButton.Location = new System.Drawing.Point(344, 344);
			this.installButton.Name = "installButton";
			this.installButton.Size = new System.Drawing.Size(104, 23);
			this.installButton.TabIndex = 2;
			this.installButton.Text = "Install Database";
			this.installButton.Click += new System.EventHandler(this.installButton_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(500, 70);
			this.pictureBox1.TabIndex = 9;
			this.pictureBox1.TabStop = false;
			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.Color.White;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label7.Location = new System.Drawing.Point(8, 8);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(392, 23);
			this.label7.TabIndex = 10;
			this.label7.Text = "Install Database";
			// 
			// closeButton
			// 
			this.closeButton.Location = new System.Drawing.Point(360, 344);
			this.closeButton.Name = "closeButton";
			this.closeButton.TabIndex = 11;
			this.closeButton.Text = "Close";
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// Installer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(496, 397);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.installButton);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.tabs);
			this.Name = "Installer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Alchemi Database Setup";
			this.Load += new System.EventHandler(this.Installer_Load);
			this.tabs.ResumeLayout(false);
			this.configurationFileTab.ResumeLayout(false);
			this.storageTypeTab.ResumeLayout(false);
			this.databaseLocationTab.ResumeLayout(false);
			this.databaseUserTab.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region "Event Handlers"
		private void Installer_Load(object sender, System.EventArgs e)
		{
			firstInstall = false;
			try
			{
				// stupid hack to see if the configuration file exists
				Configuration.GetConfiguration(initialManagerLocation);
			}
			catch (FileNotFoundException)
			{
				firstInstall = true;
				
				// force the changed to be marked as true
				configurationFileChanged = true;
			}			

			InitializeFormDataAndControls();

			LoadConfigurationFileFromManagerLocation();

			if (firstInstall)
			{
				InitializeFirstInstallControlStatus();
			}

			SetControlStatus();
		}

		#region Navigation - Hiding and showing the tabs

		private void configurationFileNext_Click(object sender, EventArgs e)
		{
			MakeTabVisible(storageTypeTab);

			SetControlStatus();
		}

		private void storageTypeNext_Click(object sender, EventArgs e)
		{
			MakeTabVisible(databaseLocationTab);

			SetControlStatus();
		}

		private void databaseLocationNext_Click(object sender, EventArgs e)
		{
			MakeTabVisible(databaseUserTab);

			SetControlStatus();
		}

		private void storageTypePrevious_Click(object sender, EventArgs e)
		{
			MakeTabVisible(configurationFileTab);

			SetControlStatus();
		}

		private void databaseLocationPrevious_Click(object sender, EventArgs e)
		{
			MakeTabVisible(storageTypeTab);

			SetControlStatus();
		}

		private void databaseUserPrevious_Click(object sender, EventArgs e)
		{
			MakeTabVisible(databaseLocationTab);

			SetControlStatus();
		}

		#endregion

		private void installButton_Click(object sender, System.EventArgs e)
		{
			UpdateConfigurationFromForm(managerConfiguration);

			InstallProgress progress = new InstallProgress(this);

			DialogResult dialogResult = progress.ShowDialog();

			if (dialogResult == DialogResult.OK)
			{
				databaseInstalled = true;

				if (firstInstall)
				{
					installButton.Visible = false;
					closeButton.Visible = true;
				}
			}
		}

		private void browseForManagerLocation_Click(object sender, System.EventArgs e)
		{
			BrowseForManagerLocation();
		}

		private void managerStorageTypes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ManagerStorageTypeDropdownItem item = (ManagerStorageTypeDropdownItem)managerStorageTypes.SelectedItem;

			if(item.StorageType == ManagerStorageEnum.InMemory)
			{
				// remove the last two tabs if there
				databaseLocationTab.Visible = false;
				if (tabs.TabPages.IndexOf(databaseLocationTab) != -1)
				{
					tabs.TabPages.RemoveAt(tabs.TabPages.IndexOf(databaseLocationTab));
				}

				databaseUserTab.Visible = false;
				if (tabs.TabPages.IndexOf(databaseUserTab) != -1)
				{
					tabs.TabPages.RemoveAt(tabs.TabPages.IndexOf(databaseUserTab));
				}

				storageTypeNext.Visible = false;
			}
			else
			{
				databaseLocationTab.Visible = true;
				databaseUserTab.Visible = true;

				storageTypeNext.Visible = true;
			}

			SetControlStatus();
		}

		private void tabs_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			visibleTab = tabs.SelectedTab;
		}

		private void saveButton_Click(object sender, System.EventArgs e)
		{
			SaveConfigurationData(managerConfiguration);
		}

		private void DataChanged(object sender, EventArgs e)
		{
			DataChanged();
		}

		private void managerLocation_DoubleClick(object sender, EventArgs e)
		{
			BrowseForManagerLocation();
		}

		private void Installer_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (configurationFileChanged)
			{
				// configuration data changed but not saved
				DialogResult dialogResult = MessageBox.Show(
					String.Format("The configuration in {0} has changed.{1}{1}Do you want to save the changes?", 
					managerLocation.Text,
					Environment.NewLine
					),
					"DbSetup",
					MessageBoxButtons.YesNoCancel,
					MessageBoxIcon.Exclamation,
					MessageBoxDefaultButton.Button1);

				switch (dialogResult)
				{
					case DialogResult.Cancel:
						// Cancel the exit
						e.Cancel = true;
						break;
					case DialogResult.Yes:
						// Save the changes and exit
						e.Cancel = false;
						SaveConfigurationData(managerConfiguration);
						break;
					case DialogResult.No:
						// Do not save the changes and exit
						e.Cancel = false;
						break;
					default:
#if DEBUG
						throw new Exception(String.Format("Unknown dialog result selected: {0}", dialogResult));
#endif
						break;
				}
			}

			if (e.Cancel)
			{
				return;
			}

			if (firstInstall && !databaseInstalled)
			{
				// database ntot installed
				DialogResult dialogResult = MessageBox.Show(
					String.Format("You did not install the database. Are you sure you want to exit?", 
					managerLocation.Text,
					Environment.NewLine
					),
					"DbSetup",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Exclamation,
					MessageBoxDefaultButton.Button1);

				switch (dialogResult)
				{
					case DialogResult.Yes:
						e.Cancel = false;
						SaveConfigurationData(managerConfiguration);
						break;
					case DialogResult.No:
						e.Cancel = true;
						break;
					default:
#if DEBUG
						throw new Exception(String.Format("Unknown dialog result selected: {0}", dialogResult));
#endif
						break;
				}
			}
		}

		private void closeButton_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		#endregion


		private void LoadConfigurationFileFromManagerLocation()
		{
			bool dataChanged;

			try
			{
				managerConfiguration = Configuration.GetConfiguration(managerLocation.Text);

				dataChanged = false;
			}
			catch (FileNotFoundException)
			{
				// manager file not found, load the defaults
				managerConfiguration = new Configuration(managerLocation.Text);
			
				dataChanged = true;			
			}			

			ReadConfigurationData(managerConfiguration);

			configurationFileChanged = dataChanged;
		}

		/// <summary>
		/// Read the configuration data from the configuration file into the controls
		/// </summary>
		/// <param name="configuration"></param>
		private void ReadConfigurationData(Configuration configuration)
		{
			if (configuration == null)
			{
				return;
			}
							
			IEnumerator enumerator = managerStorageTypes.Items.GetEnumerator();
			while (enumerator.MoveNext())
			{
				ManagerStorageTypeDropdownItem item = (ManagerStorageTypeDropdownItem)enumerator.Current;

				if (item.StorageType == configuration.DbType)
				{
					managerStorageTypes.SelectedItem = item;
				}
			}

			databaseServer.Text = configuration.DbServer;
			databaseName.Text = configuration.DbName;
			databaseUsername.Text = configuration.DbUsername;
			databasePassword.Text = configuration.DbPassword;
		}

		/// <summary>
		/// Update the configuration object from the form data.
		/// </summary>
		/// <param name="configuration"></param>
		private void UpdateConfigurationFromForm(Configuration configuration)
		{
			ManagerStorageTypeDropdownItem item = (ManagerStorageTypeDropdownItem)managerStorageTypes.SelectedItem;

			configuration.DbType = item.StorageType;
			configuration.DbServer = databaseServer.Text;
			configuration.DbName = databaseName.Text;
			configuration.DbUsername = databaseUsername.Text;
			configuration.DbPassword = databasePassword.Text;
		}

		private void SaveConfigurationData(Configuration configuration)
		{
			UpdateConfigurationFromForm(configuration);

			configuration.Slz();

			configurationFileChanged = false;

			saveButton.Enabled = configurationFileChanged;
		}

		/// <summary>
		/// Initialize the controls and other data structures
		/// </summary>
		private void InitializeFormDataAndControls()
		{
			visibleTab = configurationFileTab;

			// copy the tabs from the original location into our own array

			allTabs = new TabPage[tabs.TabPages.Count];
			for(int index=0; index < tabs.TabPages.Count; index++)
			{
				allTabs[index] = tabs.TabPages[index];
			}

			// initialize the storage types dropdown
			managerStorageTypes.DropDownStyle = ComboBoxStyle.DropDownList;

			managerStorageTypes.Items.Clear();

			foreach(ManagerStorageEnum storageType in Enum.GetValues(typeof(ManagerStorageEnum)))
			{
				
				switch(storageType)
				{
					case ManagerStorageEnum.InMemory:
						managerStorageTypes.Items.Add(new ManagerStorageTypeDropdownItem("In Memory", storageType));
						break;
					case ManagerStorageEnum.SqlServer:
						managerStorageTypes.Items.Add(new ManagerStorageTypeDropdownItem("Microsoft SQL Server", storageType));
						break;
					case ManagerStorageEnum.MySql:
						managerStorageTypes.Items.Add(new ManagerStorageTypeDropdownItem("mySQL", storageType));
						break;
					default:
#if DEBUG
						throw new Exception(String.Format("Undefined storage format found in installer: {0}", storageType));
#endif
						managerStorageTypes.Items.Add(new ManagerStorageTypeDropdownItem(storageType.ToString(), storageType));
						break;
				}
				
			}

			// set initial manager location
			managerLocation.Text = initialManagerLocation;
		}

		/// <summary>
		/// During the first install some controls should be hidden
		/// </summary>
		private void InitializeFirstInstallControlStatus()
		{
			// hide tabs
			storageTypeTab.Visible = false;
			storageTypeTab.Enabled = false;
			tabs.TabPages.Remove(storageTypeTab);

			databaseLocationTab.Visible = false;
			databaseLocationTab.Enabled = false;
			tabs.TabPages.Remove(databaseLocationTab);
			
			databaseUserTab.Visible = false;
			databaseUserTab.Enabled = false;
			tabs.TabPages.Remove(databaseUserTab);

		}

		/// <summary>
		/// Enable/Disable controls based on the type of execution
		/// </summary>
		private void SetControlStatus()
		{
			foreach (TabPage tab in allTabs)
			{
				ShowOrHideTabs(tab);
			}

			tabs.SelectedTab = visibleTab;

			//installButton.Visible = firstInstall;

			if (((ManagerStorageTypeDropdownItem)managerStorageTypes.SelectedItem).StorageType == ManagerStorageEnum.InMemory)
			{
				// only 2 tabs are needed
				installButton.Enabled = (configurationFileTab.Enabled && storageTypeTab.Enabled);
			}
			else
			{
				// enable it once all tabs are displayed
				installButton.Enabled = (tabs.TabPages.Count == allTabs.Length);
			}

			saveButton.Enabled = configurationFileChanged;
		}

		private void ShowOrHideTabs(TabPage tab)
		{
			if (tab.Enabled && tab.Visible)
			{
				// if not already in the tabs list add it now
				if (tabs.TabPages.IndexOf(tab) == -1)
				{
					// visible status changes when added so we have to save it
					bool oldVisible = tab.Visible;
					
					tabs.TabPages.Add(tab);
					
					tab.Visible = oldVisible;
				}
			}
		}

		private void MakeTabVisible(TabPage tabToMakeVisible)
		{
			tabToMakeVisible.Enabled = true;
			tabToMakeVisible.Visible = true;

			visibleTab = tabToMakeVisible;
		}


		private void DataChanged()
		{
			configurationFileChanged = true;
			saveButton.Enabled = true;
		}

		private void BrowseForManagerLocation()
		{
			folderBrowser.SelectedPath = managerLocation.Text;
			DialogResult diagResult = folderBrowser.ShowDialog();

			if(diagResult == DialogResult.OK)
			{
				// load the new folder information
				managerLocation.Text = folderBrowser.SelectedPath;

				LoadConfigurationFileFromManagerLocation();
			}
		}

	}
}
