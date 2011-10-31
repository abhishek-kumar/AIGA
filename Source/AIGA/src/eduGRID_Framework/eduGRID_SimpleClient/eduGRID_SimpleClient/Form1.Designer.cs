namespace eduGRID_SimpleClient
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Connect = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btn_Stop = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn_Start = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btn_Exit = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.chatgrp = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.txt_chat = new System.Windows.Forms.TextBox();
            this.chat_Display = new System.Windows.Forms.RichTextBox();
            this.btn_Send = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.enableSpeechOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Connect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Connect.Panel)).BeginInit();
            this.Connect.Panel.SuspendLayout();
            this.Connect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Stop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Start)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chatgrp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chatgrp.Panel)).BeginInit();
            this.chatgrp.Panel.SuspendLayout();
            this.chatgrp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Send)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(8, 0);
            this.Connect.Name = "Connect";
            this.Connect.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver;
            // 
            // Connect.Panel
            // 
            this.Connect.Panel.Controls.Add(this.label3);
            this.Connect.Panel.Controls.Add(this.label2);
            this.Connect.Panel.Controls.Add(this.txtPort);
            this.Connect.Panel.Controls.Add(this.txtIP);
            this.Connect.Panel.Controls.Add(this.btn_Stop);
            this.Connect.Panel.Controls.Add(this.btn_Start);
            this.Connect.Panel.Controls.Add(this.label1);
            this.Connect.Panel.Controls.Add(this.btn_Exit);
            this.Connect.Size = new System.Drawing.Size(493, 439);
            this.Connect.StateCommon.HeaderPrimary.Content.ShortText.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Connect.StateCommon.OverlayHeaders = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.Connect.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.Connect.StateNormal.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.Connect.StateNormal.Border.Rounding = 11;
            this.Connect.StateNormal.Border.Width = 1;
            this.Connect.StateNormal.HeaderPrimary.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Sigma;
            this.Connect.TabIndex = 9;
            this.Connect.ValuesPrimary.Heading = "Connection Details";
            this.Connect.ValuesPrimary.Image = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(112, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(112, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "IP Address:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(115, 180);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(198, 20);
            this.txtPort.TabIndex = 19;
            this.txtPort.Text = "81";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(115, 132);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(198, 20);
            this.txtIP.TabIndex = 18;
            this.txtIP.Text = "10.1.3.161";
            // 
            // btn_Stop
            // 
            this.btn_Stop.Enabled = false;
            this.btn_Stop.Location = new System.Drawing.Point(217, 250);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Black;
            this.btn_Stop.Size = new System.Drawing.Size(96, 27);
            this.btn_Stop.TabIndex = 17;
            this.btn_Stop.Values.Text = "S&top";
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(115, 250);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Black;
            this.btn_Start.Size = new System.Drawing.Size(96, 27);
            this.btn_Start.TabIndex = 16;
            this.btn_Start.Values.Text = "&Start";
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = false;
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(28, 16);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5);
            this.label1.Size = new System.Drawing.Size(404, 56);
            this.label1.StateNormal.Padding = new System.Windows.Forms.Padding(5);
            this.label1.StateNormal.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.label1.TabIndex = 4;
            this.label1.Values.Text = "Welcome to the eduGRID Initiative. \r\nPlease Enter the connection details to conti" +
                "nue.\r\nIf you are unsure of what it is, please click Help.";
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(170, 347);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btn_Exit.Size = new System.Drawing.Size(96, 27);
            this.btn_Exit.TabIndex = 0;
            this.btn_Exit.Values.Text = "E&xit";
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // chatgrp
            // 
            this.chatgrp.Location = new System.Drawing.Point(8, 1);
            this.chatgrp.Name = "chatgrp";
            this.chatgrp.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver;
            // 
            // chatgrp.Panel
            // 
            this.chatgrp.Panel.Controls.Add(this.txt_chat);
            this.chatgrp.Panel.Controls.Add(this.chat_Display);
            this.chatgrp.Panel.Controls.Add(this.btn_Send);
            this.chatgrp.Size = new System.Drawing.Size(493, 438);
            this.chatgrp.StateCommon.HeaderPrimary.Content.ShortText.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatgrp.StateCommon.OverlayHeaders = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.chatgrp.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.chatgrp.StateNormal.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.chatgrp.StateNormal.Border.Rounding = 0;
            this.chatgrp.StateNormal.Border.Width = 1;
            this.chatgrp.StateNormal.HeaderPrimary.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Sigma;
            this.chatgrp.TabIndex = 10;
            this.chatgrp.ValuesPrimary.Heading = "eduGRID Framework : Logged In";
            this.chatgrp.ValuesPrimary.Image = null;
            this.chatgrp.Visible = false;
            // 
            // txt_chat
            // 
            this.txt_chat.BackColor = System.Drawing.Color.CornflowerBlue;
            this.txt_chat.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_chat.ForeColor = System.Drawing.Color.White;
            this.txt_chat.Location = new System.Drawing.Point(6, 350);
            this.txt_chat.Name = "txt_chat";
            this.txt_chat.Size = new System.Drawing.Size(378, 20);
            this.txt_chat.TabIndex = 23;
            this.txt_chat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_chat_KeyPress);
            // 
            // chat_Display
            // 
            this.chat_Display.Location = new System.Drawing.Point(4, 16);
            this.chat_Display.Name = "chat_Display";
            this.chat_Display.Size = new System.Drawing.Size(482, 325);
            this.chat_Display.TabIndex = 22;
            this.chat_Display.Text = resources.GetString("chat_Display.Text");
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(390, 347);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btn_Send.Size = new System.Drawing.Size(96, 27);
            this.btn_Send.TabIndex = 0;
            this.btn_Send.Values.Text = "&Send";
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableSpeechOutputToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(186, 26);
            // 
            // enableSpeechOutputToolStripMenuItem
            // 
            this.enableSpeechOutputToolStripMenuItem.Checked = true;
            this.enableSpeechOutputToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableSpeechOutputToolStripMenuItem.Name = "enableSpeechOutputToolStripMenuItem";
            this.enableSpeechOutputToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.enableSpeechOutputToolStripMenuItem.Text = "Enable Speech Output";
            this.enableSpeechOutputToolStripMenuItem.Click += new System.EventHandler(this.enableSpeechOutputToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(524, 451);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.chatgrp);
            this.Controls.Add(this.Connect);
            this.Name = "Form1";
            this.Text = "eduGRID Framework: Simple Client";
            this.WindowActive = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Connect.Panel)).EndInit();
            this.Connect.Panel.ResumeLayout(false);
            this.Connect.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Connect)).EndInit();
            this.Connect.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_Stop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Start)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chatgrp.Panel)).EndInit();
            this.chatgrp.Panel.ResumeLayout(false);
            this.chatgrp.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chatgrp)).EndInit();
            this.chatgrp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_Send)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup Connect;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_Stop;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_Start;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_Exit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIP;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup chatgrp;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_Send;
        private System.Windows.Forms.RichTextBox chat_Display;
        private System.Windows.Forms.TextBox txt_chat;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem enableSpeechOutputToolStripMenuItem;
    }
}

