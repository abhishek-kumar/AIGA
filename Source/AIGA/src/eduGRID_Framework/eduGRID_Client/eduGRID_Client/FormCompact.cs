using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Alchemi.Core;
using Alchemi.Core.Owner;
using MSR.LST.ConferenceXP;

namespace eduGRID_Client
{
    public partial class FormCompact : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        // This delegate enables asynchronous calls for setting
        // the text property on a rtf control.
        delegate void SetTextCallback(GThread th);
        delegate void SetTextCallback2(GThread th, Exception e);

        public FormCompact()
        {
            InitializeComponent();
        }

        private void FormCompact_Load(object sender, EventArgs e)
        {
            //event handlers to be set here
            Program.eduGRIDBOT.ga.ThreadFinish += new GThreadFinish(ThreadFinished);
            Program.eduGRIDBOT.ga.ThreadFailed += new GThreadFailed(ThreadFailed);

            //set locations for compact...
            this.Size = new Size(585, 614);
            panel_chat.Location = new Point(28, 145);
            panel_sidebar.Size = new Size(292, 139);
            panel_DateTime.Location = new Point(365, 12);

            tmrTime_Tick(tmrTime, e);
        }

        private void ThreadFinished(GThread th)
        {
            // cast GThread back to eduGRID_Thread
            eduGRID_Thread thread = (eduGRID_Thread)th;
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.rtfDisplay.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(ThreadFinished);
                this.Invoke(d, new object[] { th });
            }
            else
            {
                rtfDisplay.AppendText(Environment.NewLine + ":: Bot: ");
                rtfDisplay.ScrollToCaret();
                rtfDisplay.AppendText(thread.Result + Environment.NewLine + "_________________________" + Environment.NewLine);
            }
        }

        private void ThreadFailed(GThread th, Exception e)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.rtfDisplay.InvokeRequired)
            {
                SetTextCallback2 d = new SetTextCallback2(ThreadFailed);
                this.Invoke(d, new object[] { th, e });
            }
            else
            {
                rtfDisplay.AppendText(Environment.NewLine + ":: eduGRID BotManager: " + "Error while Processing. Please rephrase and ask." + Environment.NewLine + "_________________________" + Environment.NewLine);
                rtfDisplay.ScrollToCaret();
            }
        }

        private void txtChat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btn_Go_Click(sender, e);
                txtChat.Text = "";
                e.KeyChar = '\b';
            }
        }

        private void btn_Go_Click(object sender, EventArgs e)
        {
            //nothing!
            if (txtChat.Text.Trim() == "")
                return;

            //special commands
            string scommand = txtChat.Text.Trim().ToLower();
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
            rtfDisplay.AppendText(Environment.NewLine + ":: Me: " + txtChat.Text.Trim());
            rtfDisplay.ScrollToCaret();
            Program.eduGRIDBOT.ga.StartThread(new eduGRID_Thread(txtChat.Text.Trim()));
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToLongDateString() + Environment.NewLine + DateTime.Now.ToShortTimeString();
        }
    }
}