using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Alchemi.Core;
using Alchemi.Core.Owner;
using SpeechLib;

namespace eduGRID_SimpleClient
{
    public partial class Form1 : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        static GApplication ga;
        string OP = "";
        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(string text);

        System.Threading.Thread OPFlush;
        bool FlushOP = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            try
            {
                // create grid application
                ga = new GApplication(true);
                ga.GConnection = new GConnection(txtIP.Text, int.Parse(txtPort.Text), "user", "user");
                ga.Connection = new GConnection(txtIP.Text, int.Parse(txtPort.Text), "user", "user");


                ga.ApplicationName = "eduGRID Bot Client";

                // add GridThread module (this executable) as a dependency
                ga.Manifest.Add(new ModuleDependency(typeof(eduGRID_Thread).Module));

                // subscribe to events
                ga.ThreadFinish += new GThreadFinish(ThreadFinished);
                ga.ThreadFailed += new GThreadFailed(ThreadFailed);
                //ga.ApplicationFinish += new GApplicationFinish(ApplicationFinished);

                ga.Start();
                Connect.Visible = false;

                

                chatgrp.Visible = true;
                chatgrp.BringToFront();
                txt_chat.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Connection Failure!");
            }
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            if (txt_chat.Text.Trim() == "")
                return;

            if((txt_chat.Text.Trim().ToLower()=="close")||(txt_chat.Text.Trim().ToLower()=="quit")||(txt_chat.Text.Trim().ToLower()=="exit")||(txt_chat.Text.Trim().ToLower()=="bye"))
            {
                if (MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                    {
                        if (ga != null)
                            ga.Stop();
                        this.Close();
                        Application.Exit();
                        return;
                    }
            }
            

            chat_Display.AppendText(Environment.NewLine + "Me: " + txt_chat.Text + Environment.NewLine);
            chat_Display.ScrollToCaret();
            eduGRID_Thread thread = new eduGRID_Thread(txt_chat.Text);
            ga.StartThread(thread);
        }

        private void ThreadFinished(GThread th)
        {
            // cast GThread back to eduGRID_Thread
            eduGRID_Thread thread = (eduGRID_Thread)th;
            Append_Text("Bot: " + thread.Result);
            //chat_Display.AppendText("Bot: " + thread.Result);

            if (enableSpeechOutputToolStripMenuItem.Checked)
            {
                SpVoice objSpeech = new SpVoice();
                objSpeech.Rate = 1;
                objSpeech.Speak(thread.Result, SpeechVoiceSpeakFlags.SVSFlagsAsync);
                //objSpeech.SynchronousSpeakTimeout = 20;
                
            }
        }

        private void ThreadFailed(GThread th, Exception e)
        {
            Append_Text("Bot: " + "Failed to acquire result.");
        }

        private void txt_chat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btn_Send_Click(txt_chat, e);
                txt_chat.Text = "";
                e.KeyChar = '\b';
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ga != null)
            {
                ga.Stop();
                ga = null;
            }
            FlushOP = false;
            if(OPFlush!=null)
                OPFlush.Join();
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string txt = chat_Display.Text;
            chat_Display.Text = "";
            chat_Display.Rtf = txt;
        }

        void FlushOutput()
        {
            while (FlushOP)
            {
                if(OP != "")
                {
                    txt_chat.AppendText(OP);
                    OP = "";
                }
            }
        }

        private void Append_Text(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.chat_Display.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(Append_Text);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.chat_Display.AppendText(text+Environment.NewLine);
                this.chat_Display.ScrollToCaret();
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void enableSpeechOutputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enableSpeechOutputToolStripMenuItem.Checked = !enableSpeechOutputToolStripMenuItem.Checked;
        }

    }


    [Serializable]
    public class eduGRID_Thread : GThread
    {
        private string _input, _output;

        public string Result
        {
            get { return _output; }
        }

        public eduGRID_Thread(string input)
        {
            _input = input;
        }

        public override void Start()
        {
            //_output = this.queryresponse(_input);
            //stage1: do nothing
            _output = this.queryresponse(_input);
        }
    }
}