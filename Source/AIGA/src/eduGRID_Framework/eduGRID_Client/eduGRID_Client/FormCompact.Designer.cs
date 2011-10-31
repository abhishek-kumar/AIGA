namespace eduGRID_Client
{
    partial class FormCompact
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCompact));
            this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.kryptonPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.panel_sidebar = new System.Windows.Forms.Panel();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.lblUserDesg = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel_chat = new System.Windows.Forms.Panel();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtfDisplay = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.b1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panel_DateTime = new System.Windows.Forms.Panel();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.tmrTime = new System.Windows.Forms.Timer(this.components);
            this.mainPanel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblSpaceDesc = new System.Windows.Forms.Label();
            this.lblSpace = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblProjDesc = new System.Windows.Forms.Label();
            this.lblProj = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblVUDesc = new System.Windows.Forms.Label();
            this.lblVU = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.subPanel1 = new System.Windows.Forms.Panel();
            this.lblResDesc = new System.Windows.Forms.Label();
            this.lblRes = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.b2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.chkMode = new ComponentFactory.Krypton.Toolkit.KryptonCheckSet(this.components);
            this.chkmodeskin = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.chkmodecompact = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.chkmodefull = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).BeginInit();
            this.kryptonPanel.SuspendLayout();
            this.panel_sidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel_chat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.b1)).BeginInit();
            this.panel_DateTime.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.subPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.b2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkmodeskin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkmodecompact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkmodefull)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonManager
            // 
            this.kryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Black;
            // 
            // kryptonPanel
            // 
            this.kryptonPanel.Controls.Add(this.panel_sidebar);
            this.kryptonPanel.Controls.Add(this.panel_DateTime);
            this.kryptonPanel.Controls.Add(this.panel_chat);
            this.kryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel.Name = "kryptonPanel";
            this.kryptonPanel.Size = new System.Drawing.Size(1030, 748);
            this.kryptonPanel.StateCommon.Color1 = System.Drawing.Color.Black;
            this.kryptonPanel.StateCommon.Color2 = System.Drawing.Color.Black;
            this.kryptonPanel.StateCommon.Image = ((System.Drawing.Image)(resources.GetObject("kryptonPanel.StateCommon.Image")));
            this.kryptonPanel.StateCommon.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.TileFlipY;
            this.kryptonPanel.StateNormal.Color1 = System.Drawing.Color.Black;
            this.kryptonPanel.StateNormal.Color2 = System.Drawing.Color.Black;
            this.kryptonPanel.TabIndex = 0;
            // 
            // panel_sidebar
            // 
            this.panel_sidebar.BackColor = System.Drawing.Color.Transparent;
            this.panel_sidebar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_sidebar.BackgroundImage")));
            this.panel_sidebar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel_sidebar.Controls.Add(this.chkmodefull);
            this.panel_sidebar.Controls.Add(this.chkmodecompact);
            this.panel_sidebar.Controls.Add(this.chkmodeskin);
            this.panel_sidebar.Controls.Add(this.mainPanel);
            this.panel_sidebar.Controls.Add(this.lblUserDesg);
            this.panel_sidebar.Controls.Add(this.lblUserName);
            this.panel_sidebar.Controls.Add(this.pictureBox1);
            this.panel_sidebar.Controls.Add(this.monthCalendar1);
            this.panel_sidebar.Location = new System.Drawing.Point(0, 0);
            this.panel_sidebar.Name = "panel_sidebar";
            this.panel_sidebar.Size = new System.Drawing.Size(292, 745);
            this.panel_sidebar.TabIndex = 1;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(17, 200);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            // 
            // lblUserDesg
            // 
            this.lblUserDesg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(81)))), ((int)(((byte)(93)))));
            this.lblUserDesg.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserDesg.ForeColor = System.Drawing.Color.Silver;
            this.lblUserDesg.Location = new System.Drawing.Point(18, 32);
            this.lblUserDesg.Name = "lblUserDesg";
            this.lblUserDesg.Size = new System.Drawing.Size(203, 17);
            this.lblUserDesg.TabIndex = 18;
            this.lblUserDesg.Text = "Student, BITS Pilani - Goa Campus";
            // 
            // lblUserName
            // 
            this.lblUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(81)))), ((int)(((byte)(93)))));
            this.lblUserName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblUserName.Location = new System.Drawing.Point(17, 16);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(194, 19);
            this.lblUserName.TabIndex = 17;
            this.lblUserName.Text = "Abhishek Kumar";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(276, 50);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // panel_chat
            // 
            this.panel_chat.BackColor = System.Drawing.Color.Black;
            this.panel_chat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_chat.BackgroundImage")));
            this.panel_chat.Controls.Add(this.kryptonButton1);
            this.panel_chat.Controls.Add(this.b2);
            this.panel_chat.Controls.Add(this.b1);
            this.panel_chat.Controls.Add(this.label2);
            this.panel_chat.Controls.Add(this.rtfDisplay);
            this.panel_chat.Controls.Add(this.txtChat);
            this.panel_chat.Controls.Add(this.label1);
            this.panel_chat.Location = new System.Drawing.Point(498, 238);
            this.panel_chat.Name = "panel_chat";
            this.panel_chat.Size = new System.Drawing.Size(520, 429);
            this.panel_chat.TabIndex = 2;
            // 
            // txtChat
            // 
            this.txtChat.BackColor = System.Drawing.Color.Black;
            this.txtChat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChat.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChat.ForeColor = System.Drawing.Color.White;
            this.txtChat.Location = new System.Drawing.Point(139, 397);
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(335, 22);
            this.txtChat.TabIndex = 11;
            this.txtChat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChat_KeyPress);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(111, 401);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = ">>";
            // 
            // rtfDisplay
            // 
            this.rtfDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.rtfDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtfDisplay.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtfDisplay.ForeColor = System.Drawing.Color.Silver;
            this.rtfDisplay.Location = new System.Drawing.Point(122, 61);
            this.rtfDisplay.Name = "rtfDisplay";
            this.rtfDisplay.ReadOnly = true;
            this.rtfDisplay.Size = new System.Drawing.Size(351, 318);
            this.rtfDisplay.TabIndex = 20;
            this.rtfDisplay.Text = "";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(8, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(465, 19);
            this.label2.TabIndex = 21;
            this.label2.Text = "eduGRID: Teaching Assistant";
            // 
            // b1
            // 
            this.b1.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.b1.DirtyPaletteCounter = 1;
            this.b1.Location = new System.Drawing.Point(29, 101);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(45, 41);
            this.b1.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(88)))), ((int)(((byte)(0)))));
            this.b1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b1.StateCommon.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.b1.TabIndex = 22;
            this.b1.Text = "X";
            this.b1.Values.ExtraText = "";
            this.b1.Values.Image = null;
            this.b1.Values.ImageStates.ImageCheckedNormal = null;
            this.b1.Values.ImageStates.ImageCheckedPressed = null;
            this.b1.Values.ImageStates.ImageCheckedTracking = null;
            this.b1.Values.Text = "X";
            // 
            // panel_DateTime
            // 
            this.panel_DateTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(64)))), ((int)(((byte)(74)))));
            this.panel_DateTime.Controls.Add(this.lblDateTime);
            this.panel_DateTime.Location = new System.Drawing.Point(818, 12);
            this.panel_DateTime.Name = "panel_DateTime";
            this.panel_DateTime.Size = new System.Drawing.Size(200, 46);
            this.panel_DateTime.TabIndex = 3;
            // 
            // lblDateTime
            // 
            this.lblDateTime.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblDateTime.Location = new System.Drawing.Point(23, 7);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(170, 30);
            this.lblDateTime.TabIndex = 0;
            this.lblDateTime.Text = "label3";
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tmrTime
            // 
            this.tmrTime.Enabled = true;
            this.tmrTime.Interval = 1000;
            this.tmrTime.Tick += new System.EventHandler(this.tmrTime_Tick);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.mainPanel.Controls.Add(this.panel4);
            this.mainPanel.Controls.Add(this.panel5);
            this.mainPanel.Controls.Add(this.panel6);
            this.mainPanel.Controls.Add(this.subPanel1);
            this.mainPanel.Location = new System.Drawing.Point(-1, 384);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(295, 283);
            this.mainPanel.TabIndex = 19;
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
            // panel5
            // 
            this.panel5.BackgroundImage = global::eduGRID_Client.Properties.Resources.panebg_copy;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Controls.Add(this.lblProjDesc);
            this.panel5.Controls.Add(this.lblProj);
            this.panel5.Controls.Add(this.pictureBox4);
            this.panel5.Location = new System.Drawing.Point(5, 142);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(285, 70);
            this.panel5.TabIndex = 3;
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
            // panel6
            // 
            this.panel6.BackgroundImage = global::eduGRID_Client.Properties.Resources.panebg_copy;
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Controls.Add(this.lblVUDesc);
            this.panel6.Controls.Add(this.lblVU);
            this.panel6.Controls.Add(this.pictureBox3);
            this.panel6.Location = new System.Drawing.Point(5, 71);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(285, 70);
            this.panel6.TabIndex = 2;
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
            this.lblVU.Size = new System.Drawing.Size(103, 14);
            this.lblVU.TabIndex = 3;
            this.lblVU.Text = "Stay connected";
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
            // b2
            // 
            this.b2.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.b2.DirtyPaletteCounter = 3;
            this.b2.Location = new System.Drawing.Point(28, 160);
            this.b2.Name = "b2";
            this.b2.Size = new System.Drawing.Size(45, 41);
            this.b2.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(88)))), ((int)(((byte)(0)))));
            this.b2.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b2.StateCommon.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.b2.TabIndex = 24;
            this.b2.Values.ExtraText = "";
            this.b2.Values.Image = ((System.Drawing.Image)(resources.GetObject("b2.Values.Image")));
            this.b2.Values.ImageStates.ImageCheckedNormal = null;
            this.b2.Values.ImageStates.ImageCheckedPressed = null;
            this.b2.Values.ImageStates.ImageCheckedTracking = null;
            this.b2.Values.Text = "";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.kryptonButton1.DirtyPaletteCounter = 4;
            this.kryptonButton1.Location = new System.Drawing.Point(29, 219);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(45, 41);
            this.kryptonButton1.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(88)))), ((int)(((byte)(0)))));
            this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton1.StateCommon.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.kryptonButton1.TabIndex = 25;
            this.kryptonButton1.Values.ExtraText = "";
            this.kryptonButton1.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonButton1.Values.Image")));
            this.kryptonButton1.Values.ImageStates.ImageCheckedNormal = null;
            this.kryptonButton1.Values.ImageStates.ImageCheckedPressed = null;
            this.kryptonButton1.Values.ImageStates.ImageCheckedTracking = null;
            this.kryptonButton1.Values.Text = "";
            // 
            // chkMode
            // 
            this.chkMode.CheckButtons.Add(this.chkmodeskin);
            this.chkMode.CheckButtons.Add(this.chkmodecompact);
            this.chkMode.CheckButtons.Add(this.chkmodefull);
            this.chkMode.CheckedButton = this.chkmodecompact;
            // 
            // chkmodeskin
            // 
            this.chkmodeskin.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.ButtonSpec;
            this.chkmodeskin.DirtyPaletteCounter = 1;
            this.chkmodeskin.Location = new System.Drawing.Point(66, 91);
            this.chkmodeskin.Name = "chkmodeskin";
            this.chkmodeskin.Size = new System.Drawing.Size(52, 19);
            this.chkmodeskin.TabIndex = 20;
            this.chkmodeskin.Text = "Skin";
            this.chkmodeskin.Values.ExtraText = "";
            this.chkmodeskin.Values.Image = null;
            this.chkmodeskin.Values.Text = "Skin";
            // 
            // chkmodecompact
            // 
            this.chkmodecompact.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.ButtonSpec;
            this.chkmodecompact.Checked = true;
            this.chkmodecompact.DirtyPaletteCounter = 2;
            this.chkmodecompact.Location = new System.Drawing.Point(118, 91);
            this.chkmodecompact.Name = "chkmodecompact";
            this.chkmodecompact.Size = new System.Drawing.Size(70, 19);
            this.chkmodecompact.TabIndex = 21;
            this.chkmodecompact.Text = "Compact";
            this.chkmodecompact.Values.ExtraText = "";
            this.chkmodecompact.Values.Image = null;
            this.chkmodecompact.Values.Text = "Compact";
            // 
            // chkmodefull
            // 
            this.chkmodefull.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.ButtonSpec;
            this.chkmodefull.DirtyPaletteCounter = 2;
            this.chkmodefull.Location = new System.Drawing.Point(189, 91);
            this.chkmodefull.Name = "chkmodefull";
            this.chkmodefull.Size = new System.Drawing.Size(52, 19);
            this.chkmodefull.TabIndex = 22;
            this.chkmodefull.Text = "Full";
            this.chkmodefull.Values.ExtraText = "";
            this.chkmodefull.Values.Image = null;
            this.chkmodefull.Values.Text = "Full";
            // 
            // FormCompact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 748);
            this.Controls.Add(this.kryptonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormCompact";
            this.Text = "eduGRID: Logged in";
            this.Load += new System.EventHandler(this.FormCompact_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).EndInit();
            this.kryptonPanel.ResumeLayout(false);
            this.panel_sidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel_chat.ResumeLayout(false);
            this.panel_chat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.b1)).EndInit();
            this.panel_DateTime.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.subPanel1.ResumeLayout(false);
            this.subPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.b2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkmodeskin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkmodecompact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkmodefull)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel;
        private System.Windows.Forms.Panel panel_sidebar;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label lblUserDesg;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel_chat;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtfDisplay;
        private System.Windows.Forms.Label label2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton b1;
        private System.Windows.Forms.Panel panel_DateTime;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Timer tmrTime;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblSpaceDesc;
        private System.Windows.Forms.Label lblSpace;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblProjDesc;
        private System.Windows.Forms.Label lblProj;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblVUDesc;
        private System.Windows.Forms.Label lblVU;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel subPanel1;
        private System.Windows.Forms.Label lblResDesc;
        private System.Windows.Forms.Label lblRes;
        private System.Windows.Forms.PictureBox pictureBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton b2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckSet chkMode;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton chkmodefull;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton chkmodecompact;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton chkmodeskin;
    }
}

