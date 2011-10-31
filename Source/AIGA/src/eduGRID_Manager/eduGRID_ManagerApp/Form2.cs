using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace eduGRID_ManagerApp
{
    public partial class frm_connection : Form
    {
        public frm_connection()
        {
            InitializeComponent();
        }

        public void ZoomIntoFocus()
        {

            fade_timer.Enabled = true;

        }

        

        private void fade_timer_f(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity + 0.06;
            if (this.Opacity >= 0.6)
                fade_timer.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Lostfocus(object sender, EventArgs e)
        {
            this.Focus();
        }

        

        private void Form_Paint(object sender, PaintEventArgs e)
        {
            this.Left = Location.X;
            this.Height = Location.Y;
        }
    }
}