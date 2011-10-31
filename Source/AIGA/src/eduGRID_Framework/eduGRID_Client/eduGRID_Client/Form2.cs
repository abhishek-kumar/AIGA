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
    public partial class Form2 : ComponentFactory.Krypton.Toolkit.KryptonForm
    {

        // This delegate enables asynchronous calls for setting
        // the text property on a rtf control.
        delegate void SetTextCallback(GThread th);
        delegate void SetTextCallback2(GThread th, Exception e);


        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //event handlers to be set here
            Program.eduGRIDBOT.ga.ThreadFinish += new GThreadFinish(ThreadFinished);
            Program.eduGRIDBOT.ga.ThreadFailed += new GThreadFailed(ThreadFailed);
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
                btn_Go_Click(btn_Go, e);
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

        private void subpanels_MouseEnter(object sender, EventArgs e)
        {
            Panel This = (Panel)sender;
            This.Tag = "Entered";
            This.Refresh();
        }

        private void subpanels_MouseLeave(object sender, EventArgs e)
        {
            Panel This = (Panel)sender;
            This.Tag = "";
            This.Refresh();
        }

        private void subPanels_Paint(object sender, PaintEventArgs e)
        {
            Panel This = (Panel)sender;

            if (This.Tag == "Entered")
            {
                Brush B = new SolidBrush(Color.FromArgb(40,0,230,255));
                e.Graphics.FillRectangle(B, new Rectangle(0,0,This.Size.Width, This.Size.Height));
            }
            else if (This.Tag == "Down")
            {
                Brush B = new SolidBrush(Color.FromArgb(40, 0, 0, 0));
                e.Graphics.FillRectangle(B, new Rectangle(0, 0, This.Size.Width, This.Size.Height));
            }
        }

        private void subpanels_MouseDown(object sender, MouseEventArgs e)
        {
            Panel This = (Panel)sender;
            This.Tag = "Down";
            This.Refresh();
        }

        private void subpanels_MouseUp(object sender, MouseEventArgs e)
        {
            Panel This = (Panel)sender;
            if ((e.X < 0) || (e.X > This.Width) || (e.Y < 0) || (e.Y > This.Height))
            {
                This.Tag = "";
                This.Refresh();
            }
            else
            {
                This.Tag = "Entered";
                This.Refresh();
                //Take Some Action now
                if (This.Name == "subPanel1")
                {
                    System.Threading.Thread.CurrentThread.Name = "CXPClient UI";

                    //MSR.LST.ConferenceXP.FMain.arguments = "";
                    FMain frmVirtualClassroom = new FMain();

                    FMain.InvokeSettingsArguments();

                    frmVirtualClassroom.Show();
                }
            }
            
        }
    }
}