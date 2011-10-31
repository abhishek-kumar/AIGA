using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using eduGRID_Manager.UI;

namespace eduGRID_Manager
{
    public partial class frm_Bg : Form
    {
        
        int radius = 8;
        Point[] Bound = new Point[12];

        public frm_Bg()
        {
            InitializeComponent();
        }

        private void BG_Render(object sender, PaintEventArgs e)
        {
            //User interface Inspired by vista and desire to create something new!
            // -- 07 April 2007, Abhishek Kumar
            //primary task is to created a rounded window
            SolidBrush brush = new SolidBrush(Color.FromArgb(180, 180, 220));

            e.Graphics.FillRectangle(brush, new Rectangle(radius,0,this.Size.Width-(2*radius), radius));
            e.Graphics.FillRectangle(brush, new Rectangle(0, radius, this.Size.Width, this.Size.Height-(2*radius)));
            e.Graphics.FillRectangle(brush, new Rectangle(radius, this.Size.Height-radius, this.Size.Width - (2*radius), radius));

            e.Graphics.FillEllipse(brush, 0, 0, (2*radius), (2*radius));
            e.Graphics.FillEllipse(brush, this.Size.Width-(2*radius), 0, (2*radius), (2*radius));
            e.Graphics.FillEllipse(brush, 0, this.Size.Height-(2*radius), (2*radius), (2*radius));
            e.Graphics.FillEllipse(brush, this.Size.Width-(2*radius), this.Size.Height-(2*radius), (2*radius), (2*radius));

            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(1,1,1), 1), new Rectangle(radius,radius,this.Size.Width-(2*radius), this.Size.Height-(2*radius)));


            
        }

    }
}