namespace eduGRID_Client
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.mainPanel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.subPanel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.speechDisabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speechEnabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.btn_Go = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.rtfDisplay = new System.Windows.Forms.RichTextBox();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserDesg = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.lblRes = new System.Windows.Forms.Label();
            this.lblResDesc = new System.Windows.Forms.Label();
            this.lblVUDesc = new System.Windows.Forms.Label();
            this.lblVU = new System.Windows.Forms.Label();
            this.lblProjDesc = new System.Windows.Forms.Label();
            this.lblProj = new System.Windows.Forms.Label();
            this.lblSpaceDesc = new System.Windows.Forms.Label();
            this.lblSpace = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.subPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Go)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonManager
            // 
            this.kryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Black;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.mainPanel.Controls.Add(this.panel4);
            this.mainPanel.Controls.Add(this.panel3);
            this.mainPanel.Controls.Add(this.panel2);
            this.mainPanel.Controls.Add(this.subPanel1);
            this.mainPanel.Location = new System.Drawing.Point(0, 152);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(295, 283);
            this.mainPanel.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = global::eduGRID_Client.Properties.Resources.panebg_copy;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Controls.Add(this.lblSpaceDesc);
            this.panel4.Controls.Add(this.lblSpace);
            this.panel4.Controls.Add(this.pictureBox5);
            this.panel4.Location = new System.Drawing.Point(5, 213);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(285, 70);
            this.panel4.TabIndex = 4;
            this.panel4.MouseLeave += new System.EventHandler(this.subpanels_MouseLeave);
            this.panel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.subpanels_MouseDown);
            this.panel4.MouseEnter += new System.EventHandler(this.subpanels_MouseEnter);
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.subPanels_Paint);
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::eduGRID_Client.Properties.Resources.panebg_copy;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.lblProjDesc);
            this.panel3.Controls.Add(this.lblProj);
            this.panel3.Controls.Add(this.pictureBox4);
            this.panel3.Location = new System.Drawing.Point(5, 142);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(285, 70);
            this.panel3.TabIndex = 3;
            this.panel3.MouseLeave += new System.EventHandler(this.subpanels_MouseLeave);
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.subpanels_MouseDown);
            this.panel3.MouseEnter += new System.EventHandler(this.subpanels_MouseEnter);
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.subPanels_Paint);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::eduGRID_Client.Properties.Resources.panebg_copy;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.lblVUDesc);
            this.panel2.Controls.Add(this.lblVU);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Location = new System.Drawing.Point(5, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(285, 70);
            this.panel2.TabIndex = 2;
            this.panel2.MouseLeave += new System.EventHandler(this.subpanels_MouseLeave);
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.subpanels_MouseDown);
            this.panel2.MouseEnter += new System.EventHandler(this.subpanels_MouseEnter);
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.subPanels_Paint);
            // 
            // subPanel1
            // 
            this.subPanel1.BackgroundImage = global::eduGRID_Client.Properties.Resources.panebg_copy;
            this.subPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.subPanel1.Controls.Add(this.lblResDesc);
            this.subPanel1.Controls.Add(this.lblRes);
            this.subPanel1.Controls.Add(this.pictureBox2);
            this.subPanel1.Location = new System.Drawing.Point(5, 0);
            this.subPanel1.Name = "subPanel1";
            this.subPanel1.Size = new System.Drawing.Size(285, 70);
            this.subPanel1.TabIndex = 1;
            this.subPanel1.MouseLeave += new System.EventHandler(this.subpanels_MouseLeave);
            this.subPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.subpanels_MouseDown);
            this.subPanel1.MouseEnter += new System.EventHandler(this.subpanels_MouseEnter);
            this.subPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.subPanels_Paint);
            this.subPanel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.subpanels_MouseUp);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.toolStrip1);
            this.panel5.Controls.Add(this.toolStripContainer1);
            this.panel5.Controls.Add(this.btn_Go);
            this.panel5.Controls.Add(this.rtfDisplay);
            this.panel5.Controls.Add(this.txtChat);
            this.panel5.Location = new System.Drawing.Point(0, 152);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(295, 409);
            this.panel5.TabIndex = 12;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.toolStripButton2,
            this.toolStripDropDownButton1,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(22, 286);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(269, 25);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.toolStripTextBox1.ForeColor = System.Drawing.Color.Silver;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            this.toolStripTextBox1.Text = "Online";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(75, 22);
            this.toolStripButton2.Text = "Check Status";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.speechDisabledToolStripMenuItem,
            this.speechEnabledToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(57, 22);
            this.toolStripDropDownButton1.Text = "Speech";
            // 
            // speechDisabledToolStripMenuItem
            // 
            this.speechDisabledToolStripMenuItem.Name = "speechDisabledToolStripMenuItem";
            this.speechDisabledToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.speechDisabledToolStripMenuItem.Text = "Speech Disabled";
            // 
            // speechEnabledToolStripMenuItem
            // 
            this.speechEnabledToolStripMenuItem.Name = "speechEnabledToolStripMenuItem";
            this.speechEnabledToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.speechEnabledToolStripMenuItem.Text = "Speech Enabled";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.BackColor = System.Drawing.Color.Transparent;
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(150, 150);
            this.toolStripContainer1.Location = new System.Drawing.Point(63, 76);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(150, 175);
            this.toolStripContainer1.TabIndex = 15;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.BackColor = System.Drawing.Color.Transparent;
            // 
            // btn_Go
            // 
            this.btn_Go.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.btn_Go.DirtyPaletteCounter = 11;
            this.btn_Go.Location = new System.Drawing.Point(259, 387);
            this.btn_Go.Name = "btn_Go";
            this.btn_Go.Size = new System.Drawing.Size(29, 20);
            this.btn_Go.TabIndex = 14;
            this.btn_Go.Text = "Go";
            this.btn_Go.Values.ExtraText = "";
            this.btn_Go.Values.Image = null;
            this.btn_Go.Values.ImageStates.ImageCheckedNormal = null;
            this.btn_Go.Values.ImageStates.ImageCheckedPressed = null;
            this.btn_Go.Values.ImageStates.ImageCheckedTracking = null;
            this.btn_Go.Values.Text = "Go";
            this.btn_Go.Click += new System.EventHandler(this.btn_Go_Click);
            // 
            // rtfDisplay
            // 
            this.rtfDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.rtfDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtfDisplay.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtfDisplay.ForeColor = System.Drawing.Color.Silver;
            this.rtfDisplay.Location = new System.Drawing.Point(7, 314);
            this.rtfDisplay.Name = "rtfDisplay";
            this.rtfDisplay.ReadOnly = true;
            this.rtfDisplay.Size = new System.Drawing.Size(278, 67);
            this.rtfDisplay.TabIndex = 13;
            this.rtfDisplay.Text = "";
            // 
            // txtChat
            // 
            this.txtChat.BackColor = System.Drawing.Color.Black;
            this.txtChat.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChat.ForeColor = System.Drawing.Color.White;
            this.txtChat.Location = new System.Drawing.Point(3, 387);
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(250, 20);
            this.txtChat.TabIndex = 12;
            this.txtChat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChat_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(276, 50);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // lblUserName
            // 
            this.lblUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(81)))), ((int)(((byte)(93)))));
            this.lblUserName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblUserName.Location = new System.Drawing.Point(19, 16);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(194, 19);
            this.lblUserName.TabIndex = 14;
            this.lblUserName.Text = "Abhishek Kumar";
            // 
            // lblUserDesg
            // 
            this.lblUserDesg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(81)))), ((int)(((byte)(93)))));
            this.lblUserDesg.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserDesg.ForeColor = System.Drawing.Color.Silver;
            this.lblUserDesg.Location = new System.Drawing.Point(20, 32);
            this.lblUserDesg.Name = "lblUserDesg";
            this.lblUserDesg.Size = new System.Drawing.Size(203, 17);
            this.lblUserDesg.TabIndex = 15;
            this.lblUserDesg.Text = "Student, BITS Pilani - Goa Campus";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(7, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(53, 53);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(8, 9);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(53, 53);
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(8, 7);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(53, 53);
            this.pictureBox4.TabIndex = 1;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.BackgroundImage")));
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(8, 9);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(53, 53);
            this.pictureBox5.TabIndex = 2;
            this.pictureBox5.TabStop = false;
            // 
            // lblRes
            // 
            this.lblRes.AutoSize = true;
            this.lblRes.BackColor = System.Drawing.Color.Transparent;
            this.lblRes.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblRes.Location = new System.Drawing.Point(78, 18);
            this.lblRes.Name = "lblRes";
            this.lblRes.Size = new System.Drawing.Size(127, 14);
            this.lblRes.TabIndex = 1;
            this.lblRes.Text = "eduGRID Resources";
            // 
            // lblResDesc
            // 
            this.lblResDesc.BackColor = System.Drawing.Color.Transparent;
            this.lblResDesc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblResDesc.Location = new System.Drawing.Point(77, 34);
            this.lblResDesc.Name = "lblResDesc";
            this.lblResDesc.Size = new System.Drawing.Size(202, 31);
            this.lblResDesc.TabIndex = 2;
            this.lblResDesc.Text = "Manage Your educational Resources and Learn through collaboration...";
            // 
            // lblVUDesc
            // 
            this.lblVUDesc.BackColor = System.Drawing.Color.Transparent;
            this.lblVUDesc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVUDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblVUDesc.Location = new System.Drawing.Point(76, 28);
            this.lblVUDesc.Name = "lblVUDesc";
            this.lblVUDesc.Size = new System.Drawing.Size(202, 31);
            this.lblVUDesc.TabIndex = 4;
            this.lblVUDesc.Text = "Get connected to students and faculty for discussions and learning sessions...";
            // 
            // lblVU
            // 
            this.lblVU.AutoSize = true;
            this.lblVU.BackColor = System.Drawing.Color.Transparent;
            this.lblVU.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVU.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblVU.Location = new System.Drawing.Point(77, 12);
            this.lblVU.Name = "lblVU";
            this.lblVU.Size = new System.Drawing.Size(169, 14);
            this.lblVU.TabIndex = 3;
            this.lblVU.Text = "eduGRID Virtual University";
            // 
            // lblProjDesc
            // 
            this.lblProjDesc.BackColor = System.Drawing.Color.Transparent;
            this.lblProjDesc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblProjDesc.Location = new System.Drawing.Point(74, 28);
            this.lblProjDesc.Name = "lblProjDesc";
            this.lblProjDesc.Size = new System.Drawing.Size(202, 31);
            this.lblProjDesc.TabIndex = 4;
            this.lblProjDesc.Text = "Execute various Applications that utilize the power of GRID Computing...";
            // 
            // lblProj
            // 
            this.lblProj.AutoSize = true;
            this.lblProj.BackColor = System.Drawing.Color.Transparent;
            this.lblProj.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblProj.Location = new System.Drawing.Point(75, 12);
            this.lblProj.Name = "lblProj";
            this.lblProj.Size = new System.Drawing.Size(137, 14);
            this.lblProj.TabIndex = 3;
            this.lblProj.Text = "My eduGRID Projects";
            // 
            // lblSpaceDesc
            // 
            this.lblSpaceDesc.BackColor = System.Drawing.Color.Transparent;
            this.lblSpaceDesc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpaceDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblSpaceDesc.Location = new System.Drawing.Point(74, 28);
            this.lblSpaceDesc.Name = "lblSpaceDesc";
            this.lblSpaceDesc.Size = new System.Drawing.Size(202, 31);
            this.lblSpaceDesc.TabIndex = 4;
            this.lblSpaceDesc.Text = "Manage Your educational Storage Space provided be eduGRID";
            // 
            // lblSpace
            // 
            this.lblSpace.AutoSize = true;
            this.lblSpace.BackColor = System.Drawing.Color.Transparent;
            this.lblSpace.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblSpace.Location = new System.Drawing.Point(75, 12);
            this.lblSpace.Name = "lblSpace";
            this.lblSpace.Size = new System.Drawing.Size(123, 14);
            this.lblSpace.TabIndex = 3;
            this.lblSpace.Text = "My eduGRID Space";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImage = global::eduGRID_Client.Properties.Resources.bg_copy;
            this.ClientSize = new System.Drawing.Size(296, 582);
            this.Controls.Add(this.lblUserDesg);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "eduGRID Framework: Logged In";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.mainPanel.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.subPanel1.ResumeLayout(false);
            this.subPanel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Go)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel subPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.RichTextBox rtfDisplay;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_Go;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem speechDisabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speechEnabledToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserDesg;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label lblResDesc;
        private System.Windows.Forms.Label lblRes;
        private System.Windows.Forms.Label lblSpaceDesc;
        private System.Windows.Forms.Label lblSpace;
        private System.Windows.Forms.Label lblProjDesc;
        private System.Windows.Forms.Label lblProj;
        private System.Windows.Forms.Label lblVUDesc;
        private System.Windows.Forms.Label lblVU;
    }
}

