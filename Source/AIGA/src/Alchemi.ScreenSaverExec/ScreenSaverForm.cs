#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	ScreenSaverForm.cs
* Project		:	Alchemi ScreenSaver Executor
* Created on	:	2003
* Copyright		:	Copyright © 2006 The University of Melbourne
*					This technology has been developed with the support of 
*					the Australian Research Council and the University of Melbourne
*					research grants as part of the Gridbus Project
*					within GRIDS Laboratory at the University of Melbourne, Australia.
* Author         :  Akshay Luther (akshayl@cs.mu.oz.au) and Rajkumar Buyya (raj@cs.mu.oz.au)
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
using System.Windows.Forms;
using Microsoft.Win32;
using Alchemi.Core;
using Alchemi.Core.Executor;

namespace Alchemi.ScreenSaverExec
{
    public class ScreenSaverForm : System.Windows.Forms.Form
    {
        private System.ComponentModel.IContainer components;
        private Point MouseXY;
        private int ScreenNumber;
        private GExecutor Executor;

        public ScreenSaverForm(int scrn)
        {
            InitializeComponent();
            ScreenNumber = scrn;
        }

        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if (components != null) 
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        private void ScreenSaverForm_Load(object sender, System.EventArgs e)
        {
            this.Bounds = Screen.AllScreens[ScreenNumber].Bounds;
            Cursor.Hide();
            TopMost = true;

            try
            {
                // get executor configuration
                RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\Alchemi\\Executor");
                Configuration config = Configuration.GetConfiguration(key.GetValue("InstallLocation").ToString());

                // get reference to local executor
                Executor = (GExecutor) GNode.GetRemoteRef(new RemoteEndPoint(
                    "localhost",
                    config.OwnPort,
                    RemotingMechanism.TcpBinary
                    ));

                // start non-dedicated executing
                Executor.PingExecutor();
                Executor.StartNonDedicatedExecuting(5000);
            }
            catch {}
        }

        private void OnMouseEvent(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!MouseXY.IsEmpty)
            {
                if (MouseXY != new Point(e.X, e.Y))
                    Close();
                if (e.Clicks > 0)
                    Close();
            }
            MouseXY = new Point(e.X, e.Y);
        }
		
        private void ScreenSaverForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            Close();
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // ScreenSaverForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(480, 273);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScreenSaverForm";
            this.Text = "ScreenSaver";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ScreenSaverForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseEvent);
            this.Load += new System.EventHandler(this.ScreenSaverForm_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseEvent);

        }
        #endregion

    }
}
