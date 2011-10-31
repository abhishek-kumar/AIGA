namespace eduGRID_ExecutorApp
{
    partial class MainBG
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
            this.Connections = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.inspect_Executor = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.buttonSpecHeaderGroup2 = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txPassword = new System.Windows.Forms.TextBox();
            this.txUsername = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txMgrPort = new System.Windows.Forms.TextBox();
            this.txMgrHost = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txOwnPort = new System.Windows.Forms.TextBox();
            this.cbDedicated = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbId = new System.Windows.Forms.ComboBox();
            this.PBar = new System.Windows.Forms.ProgressBar();
            this.btn_Executor_Reset = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn_Executor_Stop = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn_Executor_Start = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txLog = new System.Windows.Forms.TextBox();
            this.Label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.Exctr_instance_return = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.Connections)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inspect_Executor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inspect_Executor.Panel)).BeginInit();
            this.inspect_Executor.Panel.SuspendLayout();
            this.inspect_Executor.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Executor_Reset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Executor_Stop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Executor_Start)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exctr_instance_return)).BeginInit();
            this.SuspendLayout();
            // 
            // Connections
            // 
            this.Connections.Location = new System.Drawing.Point(24, 454);
            this.Connections.Name = "Connections";
            this.Connections.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.Connections.Size = new System.Drawing.Size(110, 50);
            this.Connections.TabIndex = 1;
            this.Connections.Values.Text = "&Connections";
            this.Connections.Click += new System.EventHandler(this.Connections_Click);
            // 
            // inspect_Executor
            // 
            this.inspect_Executor.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.buttonSpecHeaderGroup2});
            this.inspect_Executor.Location = new System.Drawing.Point(151, 83);
            this.inspect_Executor.Name = "inspect_Executor";
            this.inspect_Executor.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            // 
            // inspect_Executor.Panel
            // 
            this.inspect_Executor.Panel.Controls.Add(this.groupBox3);
            this.inspect_Executor.Panel.Controls.Add(this.groupBox1);
            this.inspect_Executor.Panel.Controls.Add(this.groupBox2);
            this.inspect_Executor.Panel.Controls.Add(this.PBar);
            this.inspect_Executor.Panel.Controls.Add(this.btn_Executor_Reset);
            this.inspect_Executor.Panel.Controls.Add(this.btn_Executor_Stop);
            this.inspect_Executor.Panel.Controls.Add(this.btn_Executor_Start);
            this.inspect_Executor.Panel.Controls.Add(this.txLog);
            this.inspect_Executor.Panel.Controls.Add(this.Label1);
            this.inspect_Executor.Panel.Controls.Add(this.Exctr_instance_return);
            this.inspect_Executor.Size = new System.Drawing.Size(437, 421);
            this.inspect_Executor.StateCommon.HeaderPrimary.Content.ShortText.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inspect_Executor.StateCommon.OverlayHeaders = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.inspect_Executor.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.inspect_Executor.StateNormal.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.inspect_Executor.StateNormal.Border.Rounding = 11;
            this.inspect_Executor.StateNormal.Border.Width = 1;
            this.inspect_Executor.StateNormal.HeaderPrimary.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Sigma;
            this.inspect_Executor.TabIndex = 9;
            this.inspect_Executor.ValuesPrimary.Heading = "Executor Instance";
            this.inspect_Executor.ValuesPrimary.Image = null;
            this.inspect_Executor.Visible = false;
            // 
            // buttonSpecHeaderGroup2
            // 
            this.buttonSpecHeaderGroup2.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.Close;
            this.buttonSpecHeaderGroup2.UniqueName = "008D5406242F4D6E008D5406242F4D6E";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txPassword);
            this.groupBox3.Controls.Add(this.txUsername);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(18, 95);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(399, 51);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Credentials";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(219, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Password";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(13, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "Username";
            // 
            // txPassword
            // 
            this.txPassword.Location = new System.Drawing.Point(289, 19);
            this.txPassword.Name = "txPassword";
            this.txPassword.PasswordChar = '*';
            this.txPassword.Size = new System.Drawing.Size(88, 20);
            this.txPassword.TabIndex = 4;
            // 
            // txUsername
            // 
            this.txUsername.Location = new System.Drawing.Point(108, 18);
            this.txUsername.Name = "txUsername";
            this.txUsername.Size = new System.Drawing.Size(100, 20);
            this.txUsername.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txMgrPort);
            this.groupBox1.Controls.Add(this.txMgrHost);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(18, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 56);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manager Node";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(251, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Host / IP Address";
            // 
            // txMgrPort
            // 
            this.txMgrPort.Location = new System.Drawing.Point(289, 25);
            this.txMgrPort.Name = "txMgrPort";
            this.txMgrPort.Size = new System.Drawing.Size(64, 20);
            this.txMgrPort.TabIndex = 2;
            // 
            // txMgrHost
            // 
            this.txMgrHost.Location = new System.Drawing.Point(108, 24);
            this.txMgrHost.Name = "txMgrHost";
            this.txMgrHost.Size = new System.Drawing.Size(100, 20);
            this.txMgrHost.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txOwnPort);
            this.groupBox2.Controls.Add(this.cbDedicated);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cmbId);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Location = new System.Drawing.Point(18, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(399, 53);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Own Node";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(251, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Port";
            // 
            // txOwnPort
            // 
            this.txOwnPort.Location = new System.Drawing.Point(289, 24);
            this.txOwnPort.Name = "txOwnPort";
            this.txOwnPort.Size = new System.Drawing.Size(64, 20);
            this.txOwnPort.TabIndex = 7;
            // 
            // cbDedicated
            // 
            this.cbDedicated.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbDedicated.Location = new System.Drawing.Point(16, 72);
            this.cbDedicated.Name = "cbDedicated";
            this.cbDedicated.Size = new System.Drawing.Size(88, 32);
            this.cbDedicated.TabIndex = 6;
            this.cbDedicated.Text = "Dedicated?";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Id";
            // 
            // cmbId
            // 
            this.cmbId.Location = new System.Drawing.Point(42, 21);
            this.cmbId.Name = "cmbId";
            this.cmbId.Size = new System.Drawing.Size(192, 21);
            this.cmbId.TabIndex = 11;
            // 
            // PBar
            // 
            this.PBar.Location = new System.Drawing.Point(9, 347);
            this.PBar.Name = "PBar";
            this.PBar.Size = new System.Drawing.Size(292, 23);
            this.PBar.TabIndex = 19;
            this.PBar.Visible = false;
            // 
            // btn_Executor_Reset
            // 
            this.btn_Executor_Reset.Location = new System.Drawing.Point(336, 309);
            this.btn_Executor_Reset.Name = "btn_Executor_Reset";
            this.btn_Executor_Reset.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Black;
            this.btn_Executor_Reset.Size = new System.Drawing.Size(96, 27);
            this.btn_Executor_Reset.TabIndex = 18;
            this.btn_Executor_Reset.Values.Text = "&Reset";
            this.btn_Executor_Reset.Click += new System.EventHandler(this.btn_Executor_Reset_Click);
            // 
            // btn_Executor_Stop
            // 
            this.btn_Executor_Stop.Location = new System.Drawing.Point(336, 276);
            this.btn_Executor_Stop.Name = "btn_Executor_Stop";
            this.btn_Executor_Stop.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Black;
            this.btn_Executor_Stop.Size = new System.Drawing.Size(96, 27);
            this.btn_Executor_Stop.TabIndex = 17;
            this.btn_Executor_Stop.Values.Text = "&Disconnect";
            this.btn_Executor_Stop.Click += new System.EventHandler(this.btn_Executor_Stop_Click);
            // 
            // btn_Executor_Start
            // 
            this.btn_Executor_Start.Location = new System.Drawing.Point(336, 243);
            this.btn_Executor_Start.Name = "btn_Executor_Start";
            this.btn_Executor_Start.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Black;
            this.btn_Executor_Start.Size = new System.Drawing.Size(96, 27);
            this.btn_Executor_Start.TabIndex = 16;
            this.btn_Executor_Start.Values.Text = "&Initialize";
            this.btn_Executor_Start.Click += new System.EventHandler(this.btn_Executor_Start_Click);
            // 
            // txLog
            // 
            this.txLog.BackColor = System.Drawing.Color.White;
            this.txLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txLog.ForeColor = System.Drawing.Color.Blue;
            this.txLog.Location = new System.Drawing.Point(9, 241);
            this.txLog.Multiline = true;
            this.txLog.Name = "txLog";
            this.txLog.ReadOnly = true;
            this.txLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txLog.Size = new System.Drawing.Size(292, 95);
            this.txLog.TabIndex = 15;
            this.txLog.TabStop = false;
            this.txLog.Text = "Log Messages>>\r\n";
            // 
            // Label1
            // 
            this.Label1.AutoSize = false;
            this.Label1.ForeColor = System.Drawing.Color.Silver;
            this.Label1.Location = new System.Drawing.Point(3, 0);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new System.Windows.Forms.Padding(5);
            this.Label1.Size = new System.Drawing.Size(429, 41);
            this.Label1.StateNormal.Padding = new System.Windows.Forms.Padding(5);
            this.Label1.StateNormal.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.Label1.TabIndex = 4;
            this.Label1.Values.Text = "You can alter thisExecutor Instance\'s Properties and take actions below...";
            // 
            // Exctr_instance_return
            // 
            this.Exctr_instance_return.Location = new System.Drawing.Point(336, 347);
            this.Exctr_instance_return.Name = "Exctr_instance_return";
            this.Exctr_instance_return.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.Exctr_instance_return.Size = new System.Drawing.Size(96, 27);
            this.Exctr_instance_return.TabIndex = 0;
            this.Exctr_instance_return.Values.Text = "<< Return";
            this.Exctr_instance_return.Click += new System.EventHandler(this.Exctr_instance_return_Click);
            // 
            // MainBG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(180)))), ((int)(((byte)(190)))));
            this.ClientSize = new System.Drawing.Size(600, 521);
            this.Controls.Add(this.inspect_Executor);
            this.Controls.Add(this.Connections);
            this.Name = "MainBG";
            this.Text = "eduGRID Framework";
            this.WindowActive = true;
            ((System.ComponentModel.ISupportInitialize)(this.Connections)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inspect_Executor.Panel)).EndInit();
            this.inspect_Executor.Panel.ResumeLayout(false);
            this.inspect_Executor.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inspect_Executor)).EndInit();
            this.inspect_Executor.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Executor_Reset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Executor_Stop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Executor_Start)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exctr_instance_return)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton Connections;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup inspect_Executor;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup buttonSpecHeaderGroup2;
        private System.Windows.Forms.ProgressBar PBar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_Executor_Reset;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_Executor_Stop;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_Executor_Start;
        protected System.Windows.Forms.TextBox txLog;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel Label1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Exctr_instance_return;
        protected System.Windows.Forms.GroupBox groupBox3;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.Label label6;
        protected System.Windows.Forms.TextBox txPassword;
        protected System.Windows.Forms.TextBox txUsername;
        protected System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.TextBox txMgrPort;
        protected System.Windows.Forms.TextBox txMgrHost;
        protected System.Windows.Forms.GroupBox groupBox2;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.TextBox txOwnPort;
        protected System.Windows.Forms.CheckBox cbDedicated;
        protected System.Windows.Forms.Label label7;
        protected System.Windows.Forms.ComboBox cmbId;
    }
}

