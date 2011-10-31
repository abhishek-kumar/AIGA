using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Alchemi.Core;
using Alchemi.Core.Owner;
using System.Web;
using System.IO;

namespace eduGRID_client1
{
   

    public partial class Form1 : Form
    {
        bool mousedown = false;
        Point Form_Start=new Point();

        bool connected = false;
        bool lookingforManagerIP = true;
        string ManagerIP = "";
        int Port = 0;
        static GApplication ga;
        string action = "";

        struct eduGRID_Query
        {
            public string Qs;
            public string Q;
            public string As;
            public string A;
        }

        eduGRID_Query[] Queryset;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            if (txt_Query.Text.Trim() == "")
                return;

            switch (txt_Query.Text.Trim().ToLower())
            {
                case "close":
                    if (MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                    {
                        if(ga!=null)
                            ga.Stop();
                        this.Close();
                        Application.Exit();
                        return;
                    }
                    break;
                case "quit":
                    if (MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                    {
                        if (ga != null)
                            ga.Stop();
                        this.Close();
                        Application.Exit();
                        return;
                    }
                    break;
                case "exit":
                    if (MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                    {
                        if (ga != null)
                            ga.Stop();
                        this.Close();
                        Application.Exit();
                        return;
                    }
                    break;
            }
            if (!connected)
            {
                if (lookingforManagerIP)
                {
                    ManagerIP = txt_Query.Text;
                    Queryset[0].As = "Me";
                    Queryset[0].A = txt_Query.Text;
                    System.Array.Resize(ref Queryset, 2);
                    Queryset[1].Qs = "Bot";
                    Queryset[1].Q = "Roger. Also tell me the Port to connect to..";
                    Queryset[1].As = "";
                    Queryset[1].A = "";
                    Refresh_Display();
                    lookingforManagerIP = false;
                }
                else
                {
                    Add_new_Queryset("Bot", "Roger that. Connecting...", "", "");
                    Refresh_Display();
                    this.Refresh();
                    //Chat_Display.Refresh();
                    tmr_Scroll.Enabled = true;

                    Port = System.Convert.ToInt32(txt_Query.Text.ToString());
                    tmr_connect.Enabled = true;

                }

            }
            else
            {
                eduGRID_Thread thread = new eduGRID_Thread(txt_Query.Text.ToString());
                //ga.Threads.Clear();
                //ga.Threads.Add(thread);
                Add_new_Queryset("Me", txt_Query.Text.ToString(), "", "");
                Refresh_Display();
                //ga.Stop();
                //ga.Start();
                ga.StartThread(thread);
                tmr_Scroll.Enabled = true;

                

            }
            txt_Query.Text = "";
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            Queryset = new eduGRID_Query[1];
            Queryset[0].Qs = "Bot";
            Queryset[0].Q = "Please tell me the IP to connect to...";
            Queryset[0].As = "";
            Queryset[0].A = "";
            Refresh_Display();
        }

        private void Add_new_Queryset(string Qs, string Q, string As, string A)
        {
            System.Array.Resize(ref Queryset, Queryset.Length + 1);
            int i = Queryset.GetUpperBound(0);
            Queryset[i].Qs = Qs;
            Queryset[i].Q = Q;
            Queryset[i].As = As;
            Queryset[i].A = A;

        }
        private void Append_Queryset(int index, string Qs, string Q, string As, string A)
        {
            
            Queryset[index].Qs += Qs;
            Queryset[index].Q += Q;
            Queryset[index].As += As;
            Queryset[index].A += A;

        }
        private void Refresh_Display()
        {
            string HTMLContent = txt_InitDoc.Text;
            int i;
            for (i = 0; i <= Queryset.GetUpperBound(0); i++)
            {
                HTMLContent += "<tr>    <td>&nbsp;</td>  </tr>  <tr>    <td><div align=\"center\">      <table width=\"95%\" border=\"1\" cellspacing=\"0\" cellpadding=\"0\">          <tr>            <td bgcolor=\"cadeff\"><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
                if (Queryset[i].Qs.Trim() != "")
                    HTMLContent += "<tr>                <td width=\"3\">&nbsp;</td>                <td width=\"99%\" Align=\"Left\"><span class=\"style2\"><span class=\"style5\">" + Queryset[i].Qs + ":</span> <span class=\"style3\">" + Queryset[i].Q + "</span> </span></td>              </tr>";
                if (Queryset[i].As.Trim() != "")
                    HTMLContent += "<tr>                <td width=\"3\">&nbsp;</td>                <td class=\"style2\" Align=\"Left\"><span class=\"style4\">" + Queryset[i].As + ":</span> <span class=\"style6\">" + Queryset[i].A + "</span> </td>              </tr>";
                HTMLContent += "<tr>                <td width=\"3\">&nbsp;</td>                <td>&nbsp;</td>              </tr></table></td>          </tr>          </table>    </div></td>  </tr>";
            }
            HTMLContent += "<tr>    <td>&nbsp;</td>  </tr></table><a name=\"abc\" id=\"abc\"></a></body></html>";
            Chat_Display.DocumentText = HTMLContent;
            
            //Chat_Display.Document.Focus();
            
            //System.Windows.Forms.SendKeys.Send("^{END}");
            
            //txt_Query.Focus();
        }

        private void doccomplete(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            tmr_Scroll.Enabled = true;
        }

       

        private void navigated(object sender, WebBrowserNavigatedEventArgs e)
        {

        }

        private void Connect(object sender, EventArgs e)
        {
            //start the process of connecting...
            try
            {
                // create grid application
                ga = new GApplication(true);
                ga.GConnection = new GConnection(ManagerIP, Port, "user", "user");
                ga.Connection = new GConnection(ManagerIP, Port, "user", "user");
                

                ga.ApplicationName = "eduGRID Bot Client";

                // add GridThread module (this executable) as a dependency
                ga.Manifest.Add(new ModuleDependency(typeof(eduGRID_Thread).Module));

                // subscribe to events
                ga.ThreadFinish += new GThreadFinish(ThreadFinished);
                ga.ThreadFailed += new GThreadFailed(ThreadFailed);
                ga.ApplicationFinish += new GApplicationFinish(ApplicationFinished);

                ga.Start();
                connected = true;
                Append_Queryset(Queryset.GetUpperBound(0), "Bot", "Connected. Done!", "", "");
                Refresh_Display();
            }
            catch (Exception ex)
            {
                Append_Queryset(Queryset.GetUpperBound(0), "Bot", "Attempt failed! Disconnected", "Error", (ex.ToString()));
                Refresh_Display();
            }
            finally
            {
                tmr_connect.Enabled = false;
            }
        }

        private void ThreadFinished(GThread th)
        {
            // cast GThread back to eduGRID_Thread
            eduGRID_Thread thread = (eduGRID_Thread)th;
            this.Append_Queryset(this.Queryset.GetUpperBound(0), "", "", "Bot", thread.Result);
            this.Refresh_Display();
            //tmr_Scroll.Enabled = true;
            //ga.Threads.Clear();
            //ga.Stop();
        }

        private void ThreadFailed(GThread th, Exception e)
        {
            this.Append_Queryset(this.Queryset.GetUpperBound(0), "", "", "Bot", "Failed to acquire result.");
            this.Refresh_Display();
        }

        private void ApplicationFinished()
        {
            Add_new_Queryset("Bot", "Closed connection with eduGRID Framework. It was nice talking to you!","","");
            //this.Append_Queryset(this.Queryset.GetUpperBound(0), "", "", "", "(end of reply)");
            this.Refresh_Display();
        }
        private void txt_Query_TextChanged(object sender, EventArgs e)
        {

        }

        private void keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btn_Send_Click(txt_Query, e);
                txt_Query.Text = "";
                e.KeyChar = '\b';
            }
        }

        private void Form_Mousedown(object sender, MouseEventArgs e)
        {
            mousedown = true;
            Form_Start.X = e.X;
            Form_Start.Y = e.Y;

        }

        private void Form_mouseup(object sender, MouseEventArgs e)
        {
            mousedown = false;
        }

        private void Form_Mousemove(object sender, MouseEventArgs e)
        {
            if (mousedown)
            {
                Point Displacement=new Point();
                //calculate displacement
                Displacement.X = e.X - Form_Start.X;
                Displacement.Y = e.Y - Form_Start.Y;

                //move!
                this.Left += Displacement.X;
                this.Top += Displacement.Y;

            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ga != null)
                ga.Stop();
        }

        private void test(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tmr_Scroll.Enabled = false;
            //MessageBox.Show("gonna scroll");
            Chat_Display.Document.Focus();
            System.Windows.Forms.SendKeys.Send("^{END}");
            System.Windows.Forms.SendKeys.Send("{TAB}");
            //txt_Query.Focus();
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