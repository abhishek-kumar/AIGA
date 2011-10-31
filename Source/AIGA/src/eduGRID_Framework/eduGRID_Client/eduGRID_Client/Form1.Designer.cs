namespace eduGRID_Client
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkRemName = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.txtUName = new System.Windows.Forms.TextBox();
            this.txtPsswd = new System.Windows.Forms.TextBox();
            this.btn_Login = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panel_Help = new System.Windows.Forms.Panel();
            this.HelpGo = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtHelp = new ZBobb.AlphaBlendTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_Login = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Login)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonButton2)).BeginInit();
            this.panel_Help.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGo)).BeginInit();
            this.panel_Login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // chkRemName
            // 
            this.chkRemName.AutoSize = true;
            this.chkRemName.BackColor = System.Drawing.Color.Transparent;
            this.chkRemName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chkRemName.Location = new System.Drawing.Point(70, 322);
            this.chkRemName.Name = "chkRemName";
            this.chkRemName.Size = new System.Drawing.Size(95, 17);
            this.chkRemName.TabIndex = 2;
            this.chkRemName.Text = "Remember Me";
            this.chkRemName.UseVisualStyleBackColor = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.checkBox1.Location = new System.Drawing.Point(70, 345);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(126, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Remember Password";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = System.Drawing.Color.Transparent;
            this.checkBox2.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.checkBox2.Location = new System.Drawing.Point(70, 426);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(124, 17);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Text = "Automatically Sign In";
            this.checkBox2.UseVisualStyleBackColor = false;
            // 
            // txtUName
            // 
            this.txtUName.Location = new System.Drawing.Point(38, 227);
            this.txtUName.Multiline = true;
            this.txtUName.Name = "txtUName";
            this.txtUName.Size = new System.Drawing.Size(222, 18);
            this.txtUName.TabIndex = 0;
            this.txtUName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPsswd
            // 
            this.txtPsswd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPsswd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPsswd.Location = new System.Drawing.Point(38, 269);
            this.txtPsswd.Name = "txtPsswd";
            this.txtPsswd.PasswordChar = '*';
            this.txtPsswd.Size = new System.Drawing.Size(222, 20);
            this.txtPsswd.TabIndex = 1;
            this.txtPsswd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_Login
            // 
            this.btn_Login.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Alternate;
            this.btn_Login.DirtyPaletteCounter = 16;
            this.btn_Login.Location = new System.Drawing.Point(70, 393);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btn_Login.Size = new System.Drawing.Size(110, 25);
            this.btn_Login.TabIndex = 4;
            this.btn_Login.Text = "&Log In";
            this.btn_Login.Values.ExtraText = "";
            this.btn_Login.Values.Image = null;
            this.btn_Login.Values.ImageStates.ImageCheckedNormal = null;
            this.btn_Login.Values.ImageStates.ImageCheckedPressed = null;
            this.btn_Login.Values.ImageStates.ImageCheckedTracking = null;
            this.btn_Login.Values.Text = "&Log In";
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.DirtyPaletteCounter = 8;
            this.kryptonButton2.Location = new System.Drawing.Point(186, 393);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(32, 25);
            this.kryptonButton2.TabIndex = 6;
            this.kryptonButton2.Text = "?";
            this.kryptonButton2.Values.ExtraText = "";
            this.kryptonButton2.Values.Image = null;
            this.kryptonButton2.Values.ImageStates.ImageCheckedNormal = null;
            this.kryptonButton2.Values.ImageStates.ImageCheckedPressed = null;
            this.kryptonButton2.Values.ImageStates.ImageCheckedTracking = null;
            this.kryptonButton2.Values.Text = "?";
            // 
            // panel_Help
            // 
            this.panel_Help.BackgroundImage = global::eduGRID_Client.Properties.Resources.panebg_copy;
            this.panel_Help.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_Help.Controls.Add(this.HelpGo);
            this.panel_Help.Controls.Add(this.textBox2);
            this.panel_Help.Controls.Add(this.txtHelp);
            this.panel_Help.Location = new System.Drawing.Point(3, 449);
            this.panel_Help.Name = "panel_Help";
            this.panel_Help.Size = new System.Drawing.Size(292, 117);
            this.panel_Help.TabIndex = 9;
            this.panel_Help.Visible = false;
            // 
            // HelpGo
            // 
            this.HelpGo.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.HelpGo.DirtyPaletteCounter = 5;
            this.HelpGo.Location = new System.Drawing.Point(249, 94);
            this.HelpGo.Name = "HelpGo";
            this.HelpGo.Size = new System.Drawing.Size(37, 20);
            this.HelpGo.TabIndex = 11;
            this.HelpGo.Text = "Go";
            this.HelpGo.Values.ExtraText = "";
            this.HelpGo.Values.Image = null;
            this.HelpGo.Values.ImageStates.ImageCheckedNormal = null;
            this.HelpGo.Values.ImageStates.ImageCheckedPressed = null;
            this.HelpGo.Values.ImageStates.ImageCheckedTracking = null;
            this.HelpGo.Values.Text = "Go";
            this.HelpGo.Click += new System.EventHandler(this.HelpGo_Click);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Black;
            this.textBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(5, 94);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(238, 20);
            this.textBox2.TabIndex = 10;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // txtHelp
            // 
            this.txtHelp.BackAlpha = 0;
            this.txtHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtHelp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHelp.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHelp.ForeColor = System.Drawing.Color.Gray;
            this.txtHelp.Location = new System.Drawing.Point(5, 4);
            this.txtHelp.Multiline = true;
            this.txtHelp.Name = "txtHelp";
            this.txtHelp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHelp.Size = new System.Drawing.Size(282, 84);
            this.txtHelp.TabIndex = 9;
            this.txtHelp.Text = "::  Welcome to the eduGRID Framework";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(35, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "Please Enter Username && Password to Login...";
            // 
            // panel_Login
            // 
            this.panel_Login.BackgroundImage = global::eduGRID_Client.Properties.Resources.panebg_copy;
            this.panel_Login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_Login.Controls.Add(this.lblStatus);
            this.panel_Login.Controls.Add(this.label3);
            this.panel_Login.Controls.Add(this.label2);
            this.panel_Login.Controls.Add(this.pictureBox1);
            this.panel_Login.Location = new System.Drawing.Point(3, 189);
            this.panel_Login.Name = "panel_Login";
            this.panel_Login.Size = new System.Drawing.Size(292, 254);
            this.panel_Login.TabIndex = 11;
            this.panel_Login.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lblStatus.Location = new System.Drawing.Point(48, 204);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(195, 30);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(48, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Logging into the eduGRID Framework...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(103, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Please Wait...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::eduGRID_Client.Properties.Resources.loginuseraccess_small;
            this.pictureBox1.Location = new System.Drawing.Point(91, 62);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 76);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::eduGRID_Client.Properties.Resources.login_copy;
            this.ClientSize = new System.Drawing.Size(300, 588);
            this.Controls.Add(this.panel_Login);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel_Help);
            this.Controls.Add(this.kryptonButton2);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.txtPsswd);
            this.Controls.Add(this.txtUName);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.chkRemName);
            this.Name = "Form1";
            this.Opacity = 0.9;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Black;
            this.Text = "eduGRID Framework";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.Activated += new System.EventHandler(this.Form1_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.btn_Login)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonButton2)).EndInit();
            this.panel_Help.ResumeLayout(false);
            this.panel_Help.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGo)).EndInit();
            this.panel_Login.ResumeLayout(false);
            this.panel_Login.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkRemName;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TextBox txtUName;
        private System.Windows.Forms.TextBox txtPsswd;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_Login;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton2;
        private System.Windows.Forms.Panel panel_Help;
        private ComponentFactory.Krypton.Toolkit.KryptonButton HelpGo;
        private System.Windows.Forms.TextBox textBox2;
        private ZBobb.AlphaBlendTextBox txtHelp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_Login;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStatus;
    }
}

