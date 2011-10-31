using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace eduGRID_ManagerApp
{
    public partial class Msgbox : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        
        public string ReturnValue = "";//by default it is ""
        public Msgbox()
        {
            InitializeComponent();
            
        }

        private void Firstshow(object sender, EventArgs e)
        {
            //tmr_fade.Enabled = true;
        }

        private void tmr_fade_tick(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity + 0.2;
            if (this.Opacity >= 1)
                tmr_fade.Enabled = false;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            ReturnValue = button1.Text;
            this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ReturnValue = Button2.Text;
            this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            ReturnValue = Button3.Text;
            this.Hide();
        }

        public static string ShowMsgbox(string Title, string Description, String Btn1, String Btn2, String Btn3)
        {
            
            Msgbox MBox = new Msgbox();
            MBox.ReturnValue = "";
            //MBox.Opacity = 0.4;

            MBox.Text = Title;
            MBox.lblMain.Text = Description;
            if (Btn1 != "")
                MBox.button1.Text = Btn1;
            else
                MBox.button1.Visible = false;

            if (Btn2 != "")
                MBox.Button2.Text = Btn2;
            else
                MBox.Button2.Visible = false;

            if (Btn3 != "")
                MBox.Button3.Text = Btn3;
            else
                MBox.Button3.Visible = false;
            MBox.ShowDialog();
            string retval = MBox.ReturnValue;
            MBox.Dispose();

            return retval;

        }

        private void Msgbox_Load(object sender, EventArgs e)
        {
            
        }

    }

}