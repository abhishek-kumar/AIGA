#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	SplashScreen.cs
* Project		:	Alchemi Core
* Created on	:	2003
* Copyright		:	Copyright © 2006 The University of Melbourne
*					This technology has been developed with the support of 
*					the Australian Research Council and the University of Melbourne
*					research grants as part of the Gridbus Project
*					within GRIDS Laboratory at the University of Melbourne, Australia.
* Author         :  Akshay Luther (akshayl@csse.unimelb.edu.au), and Rajkumar Buyya (raj@csse.unimelb.edu.au)
* License        :  GPL
*					This program is free software; you can redistribute it and/or 
*					modify it under the terms of the GNU General Public
*					License as published by the Free Software Foundation;
*					See the GNU General Public License 
*					(http://www.gnu.org/copyleft/gpl.html) for more details.
*
*/ 
#endregion

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;

namespace Alchemi.ExecutorExec
{
    public class SplashScreen : System.Windows.Forms.Form
    {
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label lbVersion;
		private System.Windows.Forms.Label lbCopyright;
        private System.ComponentModel.Container components = null;

        public SplashScreen()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SplashScreen));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lbVersion = new System.Windows.Forms.Label();
			this.lbCopyright = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(480, 320);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// lbVersion
			// 
			this.lbVersion.BackColor = System.Drawing.Color.OrangeRed;
			this.lbVersion.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbVersion.ForeColor = System.Drawing.Color.White;
			this.lbVersion.Location = new System.Drawing.Point(168, 192);
			this.lbVersion.Name = "lbVersion";
			this.lbVersion.Size = new System.Drawing.Size(136, 16);
			this.lbVersion.TabIndex = 1;
			this.lbVersion.Text = "Executor Version";
			this.lbVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbCopyright
			// 
			this.lbCopyright.BackColor = System.Drawing.Color.OrangeRed;
			this.lbCopyright.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbCopyright.ForeColor = System.Drawing.Color.White;
			this.lbCopyright.Location = new System.Drawing.Point(16, 296);
			this.lbCopyright.Name = "lbCopyright";
			this.lbCopyright.Size = new System.Drawing.Size(456, 16);
			this.lbCopyright.TabIndex = 2;
			this.lbCopyright.Text = "Copyright notice";
			this.lbCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// linkLabel1
			// 
			this.linkLabel1.ActiveLinkColor = System.Drawing.Color.White;
			this.linkLabel1.BackColor = System.Drawing.Color.OrangeRed;
			this.linkLabel1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.linkLabel1.LinkColor = System.Drawing.Color.White;
			this.linkLabel1.Location = new System.Drawing.Point(136, 280);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(224, 16);
			this.linkLabel1.TabIndex = 4;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "http://www.alchemi.net";
			this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.linkLabel1.VisitedLinkColor = System.Drawing.Color.White;
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// SplashScreen
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(480, 320);
			this.Controls.Add(this.lbCopyright);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.lbVersion);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "SplashScreen";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "SplashScreen";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.SplashScreen_Load);
			this.ResumeLayout(false);

		}
        #endregion

        private void pictureBox1_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.alchemi.net");
        }

        private void SplashScreen_Load(object sender, System.EventArgs e)
        {
			Version mgrVersion = Assembly.GetExecutingAssembly().GetName().Version;
			this.lbVersion.Text = "version v." + mgrVersion.Major + "." + mgrVersion.Minor + "." + mgrVersion.Build + Environment.NewLine;
			//this.lbVersion.Text += "Core Version " + Core.Utility.Utils.AssemblyVersion;

			string copyright =	((AssemblyCopyrightAttribute) Assembly.GetExecutingAssembly().GetCustomAttributes( 
				typeof(AssemblyCopyrightAttribute), false)[0]).Copyright;

			this.lbCopyright.Text = copyright;
		}

    }
}
