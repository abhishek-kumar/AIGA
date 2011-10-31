using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AIMLBot;

namespace eduGRID_Client
{
    public partial class Form1 : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        AIMLBot.iBOT Helperbot;

        public Form1()
        {
            InitializeComponent();
        }

        

        

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            this.Opacity = 0.85;
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            this.Opacity = 0.98;
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            //pre - start
            lblStatus.Text = "Initializing...";
            panel_Login.Visible = true;
            panel_Login.Refresh();

            //start login process

            lblStatus.Text = "Connecting to bot manager...";
            panel_Login.Refresh();
            //currently proceeding with ip and port as uname and pwd
            //TODO: add ref to webservice, connect and get info of ip and port

            #region connect to bot manager
            string ManagerIP = "localhost";
            long ManagerPort = 81;
            if (txtUName.Text.Trim() != "")
                ManagerIP = txtUName.Text.Trim();
            if (txtPsswd.Text.Trim() != "")
                ManagerPort = int.Parse(txtPsswd.Text.Trim());
            try
            {
                if (Program.eduGRIDBOT == null)
                    Program.eduGRIDBOT = new eduGRID_botwrapper(ManagerIP, (int)ManagerPort);

            }
            catch (Exception ex)
            {
                try
                { 
                    Initialize_HelpBot(); 
                    //show the helperbot
                    panel_Login.Visible = false;
                    txtHelp.AppendText(Environment.NewLine + ":: HelperBot: You seem to be having problems in connecting to the Bot Manager");
                    txtHelp.AppendText(Environment.NewLine + ":: HelperBot: " + Helperbot.Query("I have a Problem connecting to the Bot Manager" + Environment.NewLine));
                    txtHelp.ScrollToCaret();
                    txtHelp.Refresh();
                    panel_Help.Visible = true;
                    txtHelp.Refresh();
                    return;
                
                }
                catch(Exception exx)
                {
                    MessageBox.Show("Error while connecting!");
                    return;
                }
            }


            #endregion

            //TODO: connect to other managers
            lblStatus.Text = "Connecting to other managers...";
            panel_Login.Refresh();

            //Initialize second form
            lblStatus.Text = "Initializing...";
            panel_Login.Refresh();
            FormCompact F = new FormCompact();
            

            //end login process

            //successfull login...transfer to the main form
            panel_Login.Visible = false;
            this.Hide();
            F.Location = new Point(this.Location.X, this.Location.Y);
            F.Show();
            F.Location = new Point(this.Location.X, this.Location.Y);
            F.Refresh();
        }

        private void Initialize_HelpBot()
        {
            if((Helperbot==null)||(!Helperbot.initialized))
            {
                Helperbot = new iBOT(AppDomain.CurrentDomain.BaseDirectory + "Helpaiml");
                Helperbot.initialize_iBOT();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                HelpGo_Click(HelpGo, e);
                textBox2.Text = "";
                e.KeyChar = '\b';
            }
        }

        private void HelpGo_Click(object sender, EventArgs e)
        {
            //nothing!
            if (textBox2.Text.Trim() == "")
                return;

            //special commands
            string scommand = textBox2.Text.Trim().ToLower();
            if ((scommand == "close") || (scommand == "quit") || (scommand == "exit") || (scommand == "bye"))
            {
                if (MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    if (Program.eduGRIDBOT.ga != null)
                        Program.eduGRIDBOT.Disconnect();
                    this.Close();
                    Application.Exit();
                    return;
                }
            }

            //others...
            txtHelp.AppendText(Environment.NewLine + ":: Me: " + textBox2.Text.Trim());
            txtHelp.ScrollToCaret();
            if ((Helperbot == null)||(!Helperbot.initialized))
            {
                txtHelp.AppendText(Environment.NewLine + ":: FrameworkManager: Error reaching HelperBot...cannont answer queries.");
                txtHelp.ScrollToCaret();
            }
            else
            {
                txtHelp.AppendText(Environment.NewLine + ":: HelperBot: " + Helperbot.Query(scommand) + Environment.NewLine);
                txtHelp.ScrollToCaret();
            }
            textBox2.Text = "";


        }
    }
}