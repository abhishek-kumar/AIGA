#region Alchemi copyright notice
/*
	Alchemi [.NET Grid Computing Framework]
	http://www.alchemi.net
  
	Copyright © 2006 The University of Melbourne
	Created by Akshay Luther, Rajkumar Buyya and Krishna Nadiminti.

	This technology has been developed with the support of the Australian Research Council
	and the University of Melbourne research grants as part of the Gridbus Project 
	within GRIDS Laboratory at the University of Melbourne, Australia.
	
*/
#endregion

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Alchemi.Core;
using Alchemi.Core.Owner;

namespace Alchemi.Core.Owner
{
		/// <summary>
		/// Represents the form that is used to connect to the manager
		/// </summary>
		internal class GConnectionDialogForm : System.Windows.Forms.Form
		{
			private System.Windows.Forms.TextBox txHost;
			private System.Windows.Forms.TextBox txPort;
			private System.Windows.Forms.TextBox txUsername;
			private System.Windows.Forms.TextBox txPassword;
			private System.Windows.Forms.Label label1;
			private System.Windows.Forms.Label label2;
			private System.Windows.Forms.Label label3;
			private System.Windows.Forms.Label label4;
			private System.Windows.Forms.Button btOk;
			private System.Windows.Forms.Button btCancel;
			private System.Windows.Forms.GroupBox groupBox1;
			private System.Windows.Forms.GroupBox groupBox2;
			private System.ComponentModel.Container components = null;
			private GConnection connection;
			private Config config;
        
			/// <summary>
			/// Creates an instance of the GConnectionDialogForm class
			/// </summary>
			public GConnectionDialogForm()
			{
				InitializeComponent();
			}

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
				this.txHost = new System.Windows.Forms.TextBox();
				this.txPort = new System.Windows.Forms.TextBox();
				this.txUsername = new System.Windows.Forms.TextBox();
				this.txPassword = new System.Windows.Forms.TextBox();
				this.label1 = new System.Windows.Forms.Label();
				this.label2 = new System.Windows.Forms.Label();
				this.label3 = new System.Windows.Forms.Label();
				this.label4 = new System.Windows.Forms.Label();
				this.btOk = new System.Windows.Forms.Button();
				this.btCancel = new System.Windows.Forms.Button();
				this.groupBox1 = new System.Windows.Forms.GroupBox();
				this.groupBox2 = new System.Windows.Forms.GroupBox();
				this.groupBox1.SuspendLayout();
				this.groupBox2.SuspendLayout();
				this.SuspendLayout();
				// 
				// txHost
				// 
				this.txHost.Location = new System.Drawing.Point(8, 32);
				this.txHost.Name = "txHost";
				this.txHost.Size = new System.Drawing.Size(152, 20);
				this.txHost.TabIndex = 0;
				this.txHost.Text = "";
				// 
				// txPort
				// 
				this.txPort.Location = new System.Drawing.Point(168, 32);
				this.txPort.Name = "txPort";
				this.txPort.Size = new System.Drawing.Size(56, 20);
				this.txPort.TabIndex = 1;
				this.txPort.Text = "";
				// 
				// txUsername
				// 
				this.txUsername.Location = new System.Drawing.Point(8, 32);
				this.txUsername.Name = "txUsername";
				this.txUsername.Size = new System.Drawing.Size(104, 20);
				this.txUsername.TabIndex = 2;
				this.txUsername.Text = "";
				// 
				// txPassword
				// 
				this.txPassword.Location = new System.Drawing.Point(120, 32);
				this.txPassword.Name = "txPassword";
				this.txPassword.PasswordChar = '*';
				this.txPassword.Size = new System.Drawing.Size(104, 20);
				this.txPassword.TabIndex = 3;
				this.txPassword.Text = "";
				// 
				// label1
				// 
				this.label1.Location = new System.Drawing.Point(8, 16);
				this.label1.Name = "label1";
				this.label1.Size = new System.Drawing.Size(104, 16);
				this.label1.TabIndex = 4;
				this.label1.Text = "Host / IP Address";
				this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
				// 
				// label2
				// 
				this.label2.Location = new System.Drawing.Point(168, 16);
				this.label2.Name = "label2";
				this.label2.Size = new System.Drawing.Size(40, 16);
				this.label2.TabIndex = 5;
				this.label2.Text = "Port";
				// 
				// label3
				// 
				this.label3.Location = new System.Drawing.Point(8, 16);
				this.label3.Name = "label3";
				this.label3.Size = new System.Drawing.Size(56, 16);
				this.label3.TabIndex = 6;
				this.label3.Text = "Username";
				this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
				// 
				// label4
				// 
				this.label4.Location = new System.Drawing.Point(120, 16);
				this.label4.Name = "label4";
				this.label4.Size = new System.Drawing.Size(72, 16);
				this.label4.TabIndex = 7;
				this.label4.Text = "Password";
				// 
				// btOk
				// 
				this.btOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
				this.btOk.Location = new System.Drawing.Point(56, 152);
				this.btOk.Name = "btOk";
				this.btOk.Size = new System.Drawing.Size(88, 23);
				this.btOk.TabIndex = 8;
				this.btOk.Text = "OK";
				this.btOk.Click += new System.EventHandler(this.btOk_Click);
				// 
				// btCancel
				// 
				this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
				this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
				this.btCancel.Location = new System.Drawing.Point(152, 152);
				this.btCancel.Name = "btCancel";
				this.btCancel.Size = new System.Drawing.Size(88, 23);
				this.btCancel.TabIndex = 9;
				this.btCancel.Text = "Cancel";
				// 
				// groupBox1
				// 
				this.groupBox1.Controls.Add(this.txHost);
				this.groupBox1.Controls.Add(this.txPort);
				this.groupBox1.Controls.Add(this.label1);
				this.groupBox1.Controls.Add(this.label2);
				this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
				this.groupBox1.Location = new System.Drawing.Point(8, 8);
				this.groupBox1.Name = "groupBox1";
				this.groupBox1.Size = new System.Drawing.Size(232, 64);
				this.groupBox1.TabIndex = 10;
				this.groupBox1.TabStop = false;
				this.groupBox1.Text = "Manager";
				// 
				// groupBox2
				// 
				this.groupBox2.Controls.Add(this.label3);
				this.groupBox2.Controls.Add(this.txUsername);
				this.groupBox2.Controls.Add(this.txPassword);
				this.groupBox2.Controls.Add(this.label4);
				this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
				this.groupBox2.Location = new System.Drawing.Point(8, 80);
				this.groupBox2.Name = "groupBox2";
				this.groupBox2.Size = new System.Drawing.Size(232, 64);
				this.groupBox2.TabIndex = 11;
				this.groupBox2.TabStop = false;
				this.groupBox2.Text = "Credentials";
				// 
				// GConnectionDialogForm
				// 
				this.AcceptButton = this.btOk;
				this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
				this.CancelButton = this.btCancel;
				this.ClientSize = new System.Drawing.Size(250, 184);
				this.Controls.Add(this.groupBox2);
				this.Controls.Add(this.groupBox1);
				this.Controls.Add(this.btCancel);
				this.Controls.Add(this.btOk);
				this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
				this.MaximizeBox = false;
				this.MinimizeBox = false;
				this.Name = "GConnectionDialogForm";
				this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
				this.Text = "Alchemi Grid Connection";
				this.Load += new System.EventHandler(this.GConnectionDialogForm_Load);
				this.groupBox1.ResumeLayout(false);
				this.groupBox2.ResumeLayout(false);
				this.ResumeLayout(false);

			}
			#endregion

			/// <summary>
			/// Gets the GConnection object
			/// </summary>
			public GConnection Connection
			{
				get 
				{
					return connection;
				}
			}
        
			private void btOk_Click(object sender, System.EventArgs e)
			{
				int port;
				try
				{
					port = int.Parse(txPort.Text);
				}
				catch (System.FormatException)
				{
					MessageBox.Show("Invalid value for 'Port' field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				connection = new GConnection();
				config.Host = connection.Host = txHost.Text;
				config.Port = connection.Port = port;
				config.Username = connection.Username = txUsername.Text;
				config.Password = connection.Password = txPassword.Text;
				config.Write();

				IManager mgr;

				try
				{
					mgr = GNode.GetRemoteManagerRef(new RemoteEndPoint(connection.Host, connection.Port, RemotingMechanism.TcpBinary));
				}
				catch (RemotingException)
				{
					MessageBox.Show("Could not connect to grid at " + connection.Host + ":" + connection.Port + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				try
				{
					mgr.AuthenticateUser(new SecurityCredentials(config.Username, config.Password));
				}
				catch (AuthenticationException)
				{
					MessageBox.Show("Access denied.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				DialogResult = DialogResult.OK;
			}

			private void GConnectionDialogForm_Load(object sender, System.EventArgs e)
			{
				ReadConfig();
			}

			public void ReadConfig()
			{
				config = Config.Read("GConnectionDialogForm.dat");
				txHost.Text = config.Host;
				txPort.Text = config.Port.ToString();
				txUsername.Text = config.Username;
				txPassword.Text = config.Password;
			}

		}
	}

	/// <summary>
	/// Represents the login configuration information, to connect to a manager.
	/// Used for GConnection Dialog
	/// </summary>
    [Serializable]
    class Config
    {
		// Create a logger for use in this class
		private static readonly Logger logger = new Logger();

        public string Host = "localhost";
        public int Port = 9000;
        public string Username = "user";
        public string Password = "user";

        private string _file;

		/// <summary>
		/// Reads the config from a file
		/// </summary>
		/// <param name="filename">file to read from</param>
		/// <returns>Config object read</returns>
        public static Config Read(string filename)
        {
            string file = Path.Combine(System.Windows.Forms.Application.StartupPath, filename);
            Config c;
			//handle missing file exception / serialization exception etc... and create a default config.
            try
            {
                using (FileStream fs = new FileStream(file, FileMode.Open))
                {
                    if (fs.Length > 0)
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        c = (Config) bf.Deserialize(fs);
                    }
                    else
                    {
                        c = new Config(file);
                    }
                }
            }
            catch (Exception ex)
            {
				logger.Debug("Error reading config from "+file+", getting default config.", ex);
                c = new Config(file);
            }
            return c;
        }

		/// <summary>
		/// Creates a new instance of the Config class
		/// </summary>
		/// <param name="file">file name to read from / write to</param>
        public Config(string file)
        {
            _file = file;
        }

		/// <summary>
		/// Write the config to file
		/// </summary>
		public void Write()
		{
			string file = Path.Combine(System.Windows.Forms.Application.StartupPath, "GConnectionDialogForm.dat");

			try
			{
				using (Stream s = new FileStream(_file, FileMode.Create))
				{
					BinaryFormatter bf = new BinaryFormatter();
					bf.Serialize(s, this);
					s.Close();
				}
			}
			catch (Exception ex)
			{
				_file = file;
				logger.Debug("Error trying to write file. Re-trying to Write with default config: "+_file, ex);
				Write();
			}
        }
}
