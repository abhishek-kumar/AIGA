using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using eduGRID_ManagerApp.UI;

namespace eduGRID_ManagerApp
{
    public partial class frm_Bg : Form
    {
        public frm_connection Fconn;
        ItemListView<IItem> someview;

        public frm_Bg()
        {
            InitializeComponent();
            // Use double buffering to improve drawing performance
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            //DoubleBuffered = true;

            List<IItem> L = new List<IItem>();
            L.Add(new IItem("A very long thing " + Environment.NewLine  + "sadf sdaf sdf sdaf sadf ", "some description"));
            
            L.Add(new IItem("someshit", "some description"));
            L.Add(new IItem("someshit", "some description"));
            L.Add(new IItem("someshit", "some description"));
           
            L.Add(new IItem("someshit", "some description"));
            L.Add(new IItem("someshit", "some description"));
            L.Add(new IItem("someshit", "some description"));
            
            L.Add(new IItem("someshit", "some description"));
            L.Add(new IItem("someshit", "some description"));
            L.Add(new IItem("someshit", "some description"));
            L.Add(new IItem("", "some description"));
            L.Add(new IItem("", "some description"));

            
            someview = new ItemListView<IItem>("", L);
            someview.SelectedIndex = 2;

            someview.BackColor = Color.FromArgb(50, 100, 134, 142);
            someview.BorderColor = Color.WhiteSmoke;
            someview.ForeColor = Color.FromArgb(255, 255, 255, 255);
            someview.SelectedBackColor = Color.FromArgb(200, 141, 141, 165);
            someview.SelectedForeColor = Color.FromArgb(255, 63, 084, 104);
            someview.TitleBackColor = Color.Empty;
            someview.TitleForeColor = Color.FromArgb(255, 240, 234, 232);
            someview.MaxItemsToShow = 20;
            someview.MinItemsToShow = 5;
            someview.Location = new Point(188, 180);
            someview.Size = new Size(507, 344);

            //someview.BackColor = Color.FromArgb(120, 240, 234, 232);
            //someview.BorderColor = Color.White;
            //someview.ForeColor = Color.FromArgb(255, 40, 40, 40);
            //someview.SelectedBackColor = Color.FromArgb(200, 105, 61, 76);
            //someview.SelectedForeColor = Color.FromArgb(255, 204, 184, 163);
            //someview.TitleBackColor = Color.Empty;
            //someview.TitleForeColor = Color.FromArgb(255, 240, 234, 232);
            //someview.MaxItemsToShow = 20;
            //someview.MinItemsToShow = 5;
            //someview.Location = new Point(188, 180);
            //someview.Size = new Size(507, 344);


        }

        private void btn_connections_Click(object sender, EventArgs e)
        {
            Fconn.Location = new Point(this.Left+181, this.Top + 125);
            Fconn.Opacity = 0;
            
            Fconn.Show();
            Fconn.Location = new Point(this.Left + 181, this.Top + 125);
            //Fconn.Opacity = 0.5;
            Fconn.Refresh();
            Fconn.Hide();

            Fconn.ZoomIntoFocus();
            //Fconn.Refresh();

            Fconn.ShowDialog();
            //MessageBox.Show("done");
            //Fconn.Hide();
        }

        private void F_Paint(object sender, PaintEventArgs e)
        {
            Font t = someview.TitleFont;
            someview.Paint(e);
        }

        private void B_Mousemove(object sender, MouseEventArgs e)
        {
            if (e.X > 188)
            {
                long hh = (((e.Y - 200) * 12) / (344))+1;
                someview.SelectedIndex = (int)hh;
                pictureBox1.Refresh();
            }
        }

        private void Form_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(pictureBox1.Image, pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Size.Width, pictureBox1.Size.Height );
        }
    }
}