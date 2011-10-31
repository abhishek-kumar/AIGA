namespace eduGRID_ManagerApp
{
    partial class Main_BG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_BG));
            this.btn_connect = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btn_Monitor = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btn_Help = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btn_Conn_1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn_conn_2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn_conn_3 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn_conn_4 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.tmr_fade = new System.Windows.Forms.Timer(this.components);
            this.est_connections = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.buttonSpecHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.lblMain = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.listview_managers = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.btn_est_Return = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.inspect_Manager = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.buttonSpecHeaderGroup2 = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.PBar = new System.Windows.Forms.ProgressBar();
            this.btn_Manager_Reset = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn_Manager_Stop = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn_Manager_Start = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txLog = new System.Windows.Forms.TextBox();
            this.gpBoxNodeConfig = new System.Windows.Forms.GroupBox();
            this.txtInstanceName = new System.Windows.Forms.TextBox();
            this.lblInstanceName = new System.Windows.Forms.Label();
            this.lbOwnPort = new System.Windows.Forms.Label();
            this.txOwnPort = new System.Windows.Forms.TextBox();
            this.gpBoxDB = new System.Windows.Forms.GroupBox();
            this.txDbPassword = new System.Windows.Forms.TextBox();
            this.lbDBPassword = new System.Windows.Forms.Label();
            this.txDbName = new System.Windows.Forms.TextBox();
            this.txDbUsername = new System.Windows.Forms.TextBox();
            this.lbDBName = new System.Windows.Forms.Label();
            this.lbDBServer = new System.Windows.Forms.Label();
            this.lbDBUsername = new System.Windows.Forms.Label();
            this.txDbServer = new System.Windows.Forms.TextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.Mngr_instance_return = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.MaincontextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.controlManagersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.btn_connect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Monitor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Help)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Conn_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_conn_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_conn_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_conn_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.est_connections)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.est_connections.Panel)).BeginInit();
            this.est_connections.Panel.SuspendLayout();
            this.est_connections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_est_Return)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inspect_Manager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inspect_Manager.Panel)).BeginInit();
            this.inspect_Manager.Panel.SuspendLayout();
            this.inspect_Manager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Manager_Reset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Manager_Stop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Manager_Start)).BeginInit();
            this.gpBoxNodeConfig.SuspendLayout();
            this.gpBoxDB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mngr_instance_return)).BeginInit();
            this.MaincontextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_connect
            // 
            this.btn_connect.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Standalone;
            this.btn_connect.Location = new System.Drawing.Point(27, 388);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver;
            this.btn_connect.Size = new System.Drawing.Size(114, 56);
            this.btn_connect.TabIndex = 0;
            this.btn_connect.Values.Text = "&Connections";
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // btn_Monitor
            // 
            this.btn_Monitor.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Standalone;
            this.btn_Monitor.Location = new System.Drawing.Point(27, 450);
            this.btn_Monitor.Name = "btn_Monitor";
            this.btn_Monitor.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver;
            this.btn_Monitor.Size = new System.Drawing.Size(114, 56);
            this.btn_Monitor.TabIndex = 1;
            this.btn_Monitor.Values.Text = "&Monitor";
            // 
            // btn_Help
            // 
            this.btn_Help.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Standalone;
            this.btn_Help.Location = new System.Drawing.Point(27, 512);
            this.btn_Help.Name = "btn_Help";
            this.btn_Help.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver;
            this.btn_Help.Size = new System.Drawing.Size(114, 56);
            this.btn_Help.TabIndex = 2;
            this.btn_Help.Values.Text = "&Help";
            // 
            // btn_Conn_1
            // 
            this.btn_Conn_1.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.btn_Conn_1.Location = new System.Drawing.Point(276, 388);
            this.btn_Conn_1.Name = "btn_Conn_1";
            this.btn_Conn_1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btn_Conn_1.Size = new System.Drawing.Size(280, 23);
            this.btn_Conn_1.StateCommon.Border.Color1 = System.Drawing.Color.Silver;
            this.btn_Conn_1.StateCommon.Border.Color2 = System.Drawing.Color.Silver;
            this.btn_Conn_1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_Conn_1.StateCommon.Border.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_Conn_1.StateCommon.Content.LongText.Color1 = System.Drawing.Color.White;
            this.btn_Conn_1.StateCommon.Content.LongText.Color2 = System.Drawing.Color.White;
            this.btn_Conn_1.StateCommon.Content.LongText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_Conn_1.StateCommon.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_Conn_1.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btn_Conn_1.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btn_Conn_1.StateCommon.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_Conn_1.StateCommon.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_Conn_1.StateDisabled.Content.LongText.Color1 = System.Drawing.Color.White;
            this.btn_Conn_1.StateDisabled.Content.LongText.Color2 = System.Drawing.Color.White;
            this.btn_Conn_1.StateDisabled.Content.LongText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_Conn_1.StateDisabled.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_Conn_1.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btn_Conn_1.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btn_Conn_1.StateDisabled.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_Conn_1.StateDisabled.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_Conn_1.StateNormal.Border.Color1 = System.Drawing.Color.Gray;
            this.btn_Conn_1.StateNormal.Border.Color2 = System.Drawing.Color.Gray;
            this.btn_Conn_1.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_Conn_1.StateNormal.Border.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_Conn_1.StateNormal.Content.LongText.Color1 = System.Drawing.Color.White;
            this.btn_Conn_1.StateNormal.Content.LongText.Color2 = System.Drawing.Color.White;
            this.btn_Conn_1.StateNormal.Content.LongText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_Conn_1.StateNormal.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_Conn_1.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btn_Conn_1.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btn_Conn_1.StateNormal.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_Conn_1.StateNormal.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btn_Conn_1.StateNormal.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_Conn_1.StatePressed.Back.Color1 = System.Drawing.Color.Silver;
            this.btn_Conn_1.StatePressed.Back.Color2 = System.Drawing.Color.Gray;
            this.btn_Conn_1.StatePressed.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_Conn_1.StatePressed.Content.LongText.Color1 = System.Drawing.Color.White;
            this.btn_Conn_1.StatePressed.Content.LongText.Color2 = System.Drawing.Color.White;
            this.btn_Conn_1.StatePressed.Content.LongText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_Conn_1.StatePressed.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_Conn_1.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btn_Conn_1.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btn_Conn_1.StatePressed.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_Conn_1.StatePressed.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btn_Conn_1.StatePressed.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_Conn_1.StateTracking.Back.Color1 = System.Drawing.Color.Gray;
            this.btn_Conn_1.StateTracking.Back.Color2 = System.Drawing.Color.Black;
            this.btn_Conn_1.StateTracking.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_Conn_1.StateTracking.Content.LongText.Color1 = System.Drawing.Color.White;
            this.btn_Conn_1.StateTracking.Content.LongText.Color2 = System.Drawing.Color.White;
            this.btn_Conn_1.StateTracking.Content.LongText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_Conn_1.StateTracking.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_Conn_1.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btn_Conn_1.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btn_Conn_1.StateTracking.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_Conn_1.StateTracking.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btn_Conn_1.StateTracking.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_Conn_1.TabIndex = 3;
            this.btn_Conn_1.Values.Text = "View All Established Connections && Properties";
            this.btn_Conn_1.Visible = false;
            this.btn_Conn_1.Click += new System.EventHandler(this.ShowConnections);
            // 
            // btn_conn_2
            // 
            this.btn_conn_2.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.btn_conn_2.Location = new System.Drawing.Point(276, 431);
            this.btn_conn_2.Name = "btn_conn_2";
            this.btn_conn_2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btn_conn_2.Size = new System.Drawing.Size(280, 23);
            this.btn_conn_2.StateCommon.Border.Color1 = System.Drawing.Color.Silver;
            this.btn_conn_2.StateCommon.Border.Color2 = System.Drawing.Color.Silver;
            this.btn_conn_2.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_conn_2.StateCommon.Border.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_2.StateCommon.Content.LongText.Color1 = System.Drawing.Color.White;
            this.btn_conn_2.StateCommon.Content.LongText.Color2 = System.Drawing.Color.White;
            this.btn_conn_2.StateCommon.Content.LongText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_2.StateCommon.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_conn_2.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btn_conn_2.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btn_conn_2.StateCommon.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_2.StateCommon.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_conn_2.StateDisabled.Content.LongText.Color1 = System.Drawing.Color.White;
            this.btn_conn_2.StateDisabled.Content.LongText.Color2 = System.Drawing.Color.White;
            this.btn_conn_2.StateDisabled.Content.LongText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_2.StateDisabled.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_conn_2.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btn_conn_2.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btn_conn_2.StateDisabled.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_2.StateDisabled.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_conn_2.StateNormal.Border.Color1 = System.Drawing.Color.Gray;
            this.btn_conn_2.StateNormal.Border.Color2 = System.Drawing.Color.Gray;
            this.btn_conn_2.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_conn_2.StateNormal.Border.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_2.StateNormal.Content.LongText.Color1 = System.Drawing.Color.White;
            this.btn_conn_2.StateNormal.Content.LongText.Color2 = System.Drawing.Color.White;
            this.btn_conn_2.StateNormal.Content.LongText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_2.StateNormal.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_conn_2.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btn_conn_2.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btn_conn_2.StateNormal.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_2.StateNormal.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btn_conn_2.StateNormal.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_conn_2.StatePressed.Back.Color1 = System.Drawing.Color.Silver;
            this.btn_conn_2.StatePressed.Back.Color2 = System.Drawing.Color.Gray;
            this.btn_conn_2.StatePressed.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_2.StatePressed.Content.LongText.Color1 = System.Drawing.Color.White;
            this.btn_conn_2.StatePressed.Content.LongText.Color2 = System.Drawing.Color.White;
            this.btn_conn_2.StatePressed.Content.LongText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_2.StatePressed.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_conn_2.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btn_conn_2.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btn_conn_2.StatePressed.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_2.StatePressed.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btn_conn_2.StatePressed.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_conn_2.StateTracking.Back.Color1 = System.Drawing.Color.Gray;
            this.btn_conn_2.StateTracking.Back.Color2 = System.Drawing.Color.Black;
            this.btn_conn_2.StateTracking.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_2.StateTracking.Content.LongText.Color1 = System.Drawing.Color.White;
            this.btn_conn_2.StateTracking.Content.LongText.Color2 = System.Drawing.Color.White;
            this.btn_conn_2.StateTracking.Content.LongText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_2.StateTracking.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_conn_2.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btn_conn_2.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btn_conn_2.StateTracking.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_2.StateTracking.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btn_conn_2.StateTracking.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_conn_2.TabIndex = 4;
            this.btn_conn_2.Values.Text = "Add a Manager Instance";
            this.btn_conn_2.Visible = false;
            this.btn_conn_2.Click += new System.EventHandler(this.Create_MWrapper);
            // 
            // btn_conn_3
            // 
            this.btn_conn_3.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.btn_conn_3.Location = new System.Drawing.Point(276, 475);
            this.btn_conn_3.Name = "btn_conn_3";
            this.btn_conn_3.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btn_conn_3.Size = new System.Drawing.Size(280, 23);
            this.btn_conn_3.StateCommon.Border.Color1 = System.Drawing.Color.Silver;
            this.btn_conn_3.StateCommon.Border.Color2 = System.Drawing.Color.Silver;
            this.btn_conn_3.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_conn_3.StateCommon.Border.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_3.StateCommon.Content.LongText.Color1 = System.Drawing.Color.White;
            this.btn_conn_3.StateCommon.Content.LongText.Color2 = System.Drawing.Color.White;
            this.btn_conn_3.StateCommon.Content.LongText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_3.StateCommon.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_conn_3.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btn_conn_3.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btn_conn_3.StateCommon.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_3.StateCommon.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_conn_3.StateDisabled.Content.LongText.Color1 = System.Drawing.Color.White;
            this.btn_conn_3.StateDisabled.Content.LongText.Color2 = System.Drawing.Color.White;
            this.btn_conn_3.StateDisabled.Content.LongText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_3.StateDisabled.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_conn_3.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btn_conn_3.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btn_conn_3.StateDisabled.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_3.StateDisabled.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_conn_3.StateNormal.Border.Color1 = System.Drawing.Color.Gray;
            this.btn_conn_3.StateNormal.Border.Color2 = System.Drawing.Color.Gray;
            this.btn_conn_3.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_conn_3.StateNormal.Border.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_3.StateNormal.Content.LongText.Color1 = System.Drawing.Color.White;
            this.btn_conn_3.StateNormal.Content.LongText.Color2 = System.Drawing.Color.White;
            this.btn_conn_3.StateNormal.Content.LongText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_3.StateNormal.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_conn_3.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btn_conn_3.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btn_conn_3.StateNormal.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_3.StateNormal.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btn_conn_3.StateNormal.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_conn_3.StatePressed.Back.Color1 = System.Drawing.Color.Silver;
            this.btn_conn_3.StatePressed.Back.Color2 = System.Drawing.Color.Gray;
            this.btn_conn_3.StatePressed.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_3.StatePressed.Content.LongText.Color1 = System.Drawing.Color.White;
            this.btn_conn_3.StatePressed.Content.LongText.Color2 = System.Drawing.Color.White;
            this.btn_conn_3.StatePressed.Content.LongText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_3.StatePressed.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_conn_3.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btn_conn_3.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btn_conn_3.StatePressed.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_3.StatePressed.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btn_conn_3.StatePressed.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_conn_3.StateTracking.Back.Color1 = System.Drawing.Color.Gray;
            this.btn_conn_3.StateTracking.Back.Color2 = System.Drawing.Color.Black;
            this.btn_conn_3.StateTracking.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_3.StateTracking.Content.LongText.Color1 = System.Drawing.Color.White;
            this.btn_conn_3.StateTracking.Content.LongText.Color2 = System.Drawing.Color.White;
            this.btn_conn_3.StateTracking.Content.LongText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_3.StateTracking.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_conn_3.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btn_conn_3.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btn_conn_3.StateTracking.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_3.StateTracking.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btn_conn_3.StateTracking.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_conn_3.TabIndex = 5;
            this.btn_conn_3.Values.Text = "Remove a Manager Instance";
            this.btn_conn_3.Visible = false;
            // 
            // btn_conn_4
            // 
            this.btn_conn_4.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.btn_conn_4.Location = new System.Drawing.Point(276, 522);
            this.btn_conn_4.Name = "btn_conn_4";
            this.btn_conn_4.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btn_conn_4.Size = new System.Drawing.Size(280, 23);
            this.btn_conn_4.StateCommon.Border.Color1 = System.Drawing.Color.Silver;
            this.btn_conn_4.StateCommon.Border.Color2 = System.Drawing.Color.Silver;
            this.btn_conn_4.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_conn_4.StateCommon.Border.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_4.StateCommon.Content.LongText.Color1 = System.Drawing.Color.White;
            this.btn_conn_4.StateCommon.Content.LongText.Color2 = System.Drawing.Color.White;
            this.btn_conn_4.StateCommon.Content.LongText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_4.StateCommon.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_conn_4.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btn_conn_4.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btn_conn_4.StateCommon.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_4.StateCommon.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_conn_4.StateDisabled.Content.LongText.Color1 = System.Drawing.Color.White;
            this.btn_conn_4.StateDisabled.Content.LongText.Color2 = System.Drawing.Color.White;
            this.btn_conn_4.StateDisabled.Content.LongText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_4.StateDisabled.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_conn_4.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btn_conn_4.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btn_conn_4.StateDisabled.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_4.StateDisabled.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_conn_4.StateNormal.Border.Color1 = System.Drawing.Color.Gray;
            this.btn_conn_4.StateNormal.Border.Color2 = System.Drawing.Color.Gray;
            this.btn_conn_4.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_conn_4.StateNormal.Border.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_4.StateNormal.Content.LongText.Color1 = System.Drawing.Color.White;
            this.btn_conn_4.StateNormal.Content.LongText.Color2 = System.Drawing.Color.White;
            this.btn_conn_4.StateNormal.Content.LongText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_4.StateNormal.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_conn_4.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btn_conn_4.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btn_conn_4.StateNormal.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_4.StateNormal.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btn_conn_4.StateNormal.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_conn_4.StatePressed.Back.Color1 = System.Drawing.Color.Silver;
            this.btn_conn_4.StatePressed.Back.Color2 = System.Drawing.Color.Gray;
            this.btn_conn_4.StatePressed.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_4.StatePressed.Content.LongText.Color1 = System.Drawing.Color.White;
            this.btn_conn_4.StatePressed.Content.LongText.Color2 = System.Drawing.Color.White;
            this.btn_conn_4.StatePressed.Content.LongText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_4.StatePressed.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_conn_4.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btn_conn_4.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btn_conn_4.StatePressed.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_4.StatePressed.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btn_conn_4.StatePressed.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_conn_4.StateTracking.Back.Color1 = System.Drawing.Color.Gray;
            this.btn_conn_4.StateTracking.Back.Color2 = System.Drawing.Color.Black;
            this.btn_conn_4.StateTracking.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_4.StateTracking.Content.LongText.Color1 = System.Drawing.Color.White;
            this.btn_conn_4.StateTracking.Content.LongText.Color2 = System.Drawing.Color.White;
            this.btn_conn_4.StateTracking.Content.LongText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_4.StateTracking.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_conn_4.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btn_conn_4.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btn_conn_4.StateTracking.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btn_conn_4.StateTracking.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btn_conn_4.StateTracking.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btn_conn_4.TabIndex = 6;
            this.btn_conn_4.Values.Text = "<<     Return";
            this.btn_conn_4.Visible = false;
            this.btn_conn_4.Click += new System.EventHandler(this.btn_conn_4_Click);
            // 
            // tmr_fade
            // 
            this.tmr_fade.Interval = 50;
            this.tmr_fade.Tick += new System.EventHandler(this.FadeControlls);
            // 
            // est_connections
            // 
            this.est_connections.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.buttonSpecHeaderGroup1});
            this.est_connections.CollapseTarget = ComponentFactory.Krypton.Toolkit.HeaderGroupCollapsedTarget.CollapsedToPrimary;
            this.est_connections.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this.est_connections.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.ControlClient;
            this.est_connections.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Primary;
            this.est_connections.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary;
            this.est_connections.Location = new System.Drawing.Point(216, 161);
            this.est_connections.Name = "est_connections";
            this.est_connections.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            // 
            // est_connections.Panel
            // 
            this.est_connections.Panel.Controls.Add(this.lblMain);
            this.est_connections.Panel.Controls.Add(this.listview_managers);
            this.est_connections.Panel.Controls.Add(this.btn_est_Return);
            this.est_connections.Size = new System.Drawing.Size(437, 421);
            this.est_connections.StateCommon.HeaderPrimary.Content.ShortText.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.est_connections.StateCommon.HeaderPrimary.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.est_connections.StateCommon.HeaderPrimary.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.est_connections.StateCommon.OverlayHeaders = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.est_connections.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.est_connections.StateNormal.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.est_connections.StateNormal.Border.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.est_connections.StateNormal.Border.Rounding = 11;
            this.est_connections.StateNormal.Border.Width = 1;
            this.est_connections.StateNormal.HeaderPrimary.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Sigma;
            this.est_connections.StateNormal.HeaderPrimary.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.est_connections.TabIndex = 7;
            this.est_connections.ValuesPrimary.Heading = "Manager Instances Connection Details";
            this.est_connections.ValuesPrimary.Image = null;
            this.est_connections.Visible = false;
            // 
            // buttonSpecHeaderGroup1
            // 
            this.buttonSpecHeaderGroup1.Orientation = ComponentFactory.Krypton.Toolkit.PaletteButtonOrientation.Inherit;
            this.buttonSpecHeaderGroup1.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Inherit;
            this.buttonSpecHeaderGroup1.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.Close;
            this.buttonSpecHeaderGroup1.UniqueName = "008D5406242F4D6E008D5406242F4D6E";
            this.buttonSpecHeaderGroup1.Click += new System.EventHandler(this.buttonSpecHeaderGroup1_Click);
            // 
            // lblMain
            // 
            this.lblMain.AutoSize = false;
            this.lblMain.ForeColor = System.Drawing.Color.Silver;
            this.lblMain.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.lblMain.Location = new System.Drawing.Point(3, 19);
            this.lblMain.Name = "lblMain";
            this.lblMain.Padding = new System.Windows.Forms.Padding(5);
            this.lblMain.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
            this.lblMain.Size = new System.Drawing.Size(429, 41);
            this.lblMain.StateNormal.Padding = new System.Windows.Forms.Padding(5);
            this.lblMain.StateNormal.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.lblMain.StateNormal.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.lblMain.StateNormal.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.lblMain.TabIndex = 4;
            this.lblMain.Values.Text = "The Manager Instance that have been initiated on this Node of the GRID are\r\nenlis" +
                "ted below.";
            // 
            // listview_managers
            // 
            this.listview_managers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listview_managers.FullRowSelect = true;
            this.listview_managers.Location = new System.Drawing.Point(3, 63);
            this.listview_managers.Name = "listview_managers";
            this.listview_managers.Size = new System.Drawing.Size(429, 178);
            this.listview_managers.TabIndex = 1;
            this.listview_managers.UseCompatibleStateImageBehavior = false;
            this.listview_managers.View = System.Windows.Forms.View.Details;
            this.listview_managers.ItemActivate += new System.EventHandler(this.listview_managers_ItemActivate);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "S No";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Port";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Status";
            // 
            // btn_est_Return
            // 
            this.btn_est_Return.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Standalone;
            this.btn_est_Return.Location = new System.Drawing.Point(336, 347);
            this.btn_est_Return.Name = "btn_est_Return";
            this.btn_est_Return.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btn_est_Return.Size = new System.Drawing.Size(96, 27);
            this.btn_est_Return.TabIndex = 0;
            this.btn_est_Return.Values.Text = "<< Return";
            this.btn_est_Return.Click += new System.EventHandler(this.btn_est_Return_Click);
            // 
            // inspect_Manager
            // 
            this.inspect_Manager.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.buttonSpecHeaderGroup2});
            this.inspect_Manager.CollapseTarget = ComponentFactory.Krypton.Toolkit.HeaderGroupCollapsedTarget.CollapsedToPrimary;
            this.inspect_Manager.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this.inspect_Manager.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.ControlClient;
            this.inspect_Manager.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Primary;
            this.inspect_Manager.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary;
            this.inspect_Manager.Location = new System.Drawing.Point(216, 161);
            this.inspect_Manager.Name = "inspect_Manager";
            this.inspect_Manager.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            // 
            // inspect_Manager.Panel
            // 
            this.inspect_Manager.Panel.Controls.Add(this.PBar);
            this.inspect_Manager.Panel.Controls.Add(this.btn_Manager_Reset);
            this.inspect_Manager.Panel.Controls.Add(this.btn_Manager_Stop);
            this.inspect_Manager.Panel.Controls.Add(this.btn_Manager_Start);
            this.inspect_Manager.Panel.Controls.Add(this.txLog);
            this.inspect_Manager.Panel.Controls.Add(this.gpBoxNodeConfig);
            this.inspect_Manager.Panel.Controls.Add(this.gpBoxDB);
            this.inspect_Manager.Panel.Controls.Add(this.kryptonLabel1);
            this.inspect_Manager.Panel.Controls.Add(this.Mngr_instance_return);
            this.inspect_Manager.Size = new System.Drawing.Size(437, 421);
            this.inspect_Manager.StateCommon.HeaderPrimary.Content.ShortText.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inspect_Manager.StateCommon.HeaderPrimary.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.inspect_Manager.StateCommon.HeaderPrimary.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.inspect_Manager.StateCommon.OverlayHeaders = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.inspect_Manager.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.inspect_Manager.StateNormal.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.inspect_Manager.StateNormal.Border.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.inspect_Manager.StateNormal.Border.Rounding = 11;
            this.inspect_Manager.StateNormal.Border.Width = 1;
            this.inspect_Manager.StateNormal.HeaderPrimary.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Sigma;
            this.inspect_Manager.StateNormal.HeaderPrimary.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.inspect_Manager.TabIndex = 8;
            this.inspect_Manager.ValuesPrimary.Heading = "Manager Instance";
            this.inspect_Manager.ValuesPrimary.Image = null;
            this.inspect_Manager.Visible = false;
            // 
            // buttonSpecHeaderGroup2
            // 
            this.buttonSpecHeaderGroup2.Orientation = ComponentFactory.Krypton.Toolkit.PaletteButtonOrientation.Inherit;
            this.buttonSpecHeaderGroup2.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Inherit;
            this.buttonSpecHeaderGroup2.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.Close;
            this.buttonSpecHeaderGroup2.UniqueName = "008D5406242F4D6E008D5406242F4D6E";
            // 
            // PBar
            // 
            this.PBar.Location = new System.Drawing.Point(9, 347);
            this.PBar.Name = "PBar";
            this.PBar.Size = new System.Drawing.Size(292, 23);
            this.PBar.TabIndex = 19;
            this.PBar.Visible = false;
            // 
            // btn_Manager_Reset
            // 
            this.btn_Manager_Reset.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Standalone;
            this.btn_Manager_Reset.Location = new System.Drawing.Point(336, 309);
            this.btn_Manager_Reset.Name = "btn_Manager_Reset";
            this.btn_Manager_Reset.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Black;
            this.btn_Manager_Reset.Size = new System.Drawing.Size(96, 27);
            this.btn_Manager_Reset.TabIndex = 18;
            this.btn_Manager_Reset.Values.Text = "&Reset";
            // 
            // btn_Manager_Stop
            // 
            this.btn_Manager_Stop.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Standalone;
            this.btn_Manager_Stop.Location = new System.Drawing.Point(336, 276);
            this.btn_Manager_Stop.Name = "btn_Manager_Stop";
            this.btn_Manager_Stop.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Black;
            this.btn_Manager_Stop.Size = new System.Drawing.Size(96, 27);
            this.btn_Manager_Stop.TabIndex = 17;
            this.btn_Manager_Stop.Values.Text = "S&top";
            this.btn_Manager_Stop.Click += new System.EventHandler(this.btn_Manager_Stop_Click);
            // 
            // btn_Manager_Start
            // 
            this.btn_Manager_Start.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Standalone;
            this.btn_Manager_Start.Location = new System.Drawing.Point(336, 243);
            this.btn_Manager_Start.Name = "btn_Manager_Start";
            this.btn_Manager_Start.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Black;
            this.btn_Manager_Start.Size = new System.Drawing.Size(96, 27);
            this.btn_Manager_Start.TabIndex = 16;
            this.btn_Manager_Start.Values.Text = "&Start";
            this.btn_Manager_Start.Click += new System.EventHandler(this.btn_Manager_Start_Click);
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
            // gpBoxNodeConfig
            // 
            this.gpBoxNodeConfig.BackColor = System.Drawing.Color.White;
            this.gpBoxNodeConfig.Controls.Add(this.txtInstanceName);
            this.gpBoxNodeConfig.Controls.Add(this.lblInstanceName);
            this.gpBoxNodeConfig.Controls.Add(this.lbOwnPort);
            this.gpBoxNodeConfig.Controls.Add(this.txOwnPort);
            this.gpBoxNodeConfig.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gpBoxNodeConfig.Location = new System.Drawing.Point(9, 139);
            this.gpBoxNodeConfig.Name = "gpBoxNodeConfig";
            this.gpBoxNodeConfig.Size = new System.Drawing.Size(416, 88);
            this.gpBoxNodeConfig.TabIndex = 10;
            this.gpBoxNodeConfig.TabStop = false;
            this.gpBoxNodeConfig.Text = "Node Configuration";
            // 
            // txtInstanceName
            // 
            this.txtInstanceName.Location = new System.Drawing.Point(90, 29);
            this.txtInstanceName.Name = "txtInstanceName";
            this.txtInstanceName.Size = new System.Drawing.Size(278, 20);
            this.txtInstanceName.TabIndex = 20;
            // 
            // lblInstanceName
            // 
            this.lblInstanceName.Location = new System.Drawing.Point(6, 29);
            this.lblInstanceName.Name = "lblInstanceName";
            this.lblInstanceName.Size = new System.Drawing.Size(86, 16);
            this.lblInstanceName.TabIndex = 21;
            this.lblInstanceName.Text = "Instance Name";
            this.lblInstanceName.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lbOwnPort
            // 
            this.lbOwnPort.Location = new System.Drawing.Point(42, 55);
            this.lbOwnPort.Name = "lbOwnPort";
            this.lbOwnPort.Size = new System.Drawing.Size(48, 16);
            this.lbOwnPort.TabIndex = 2;
            this.lbOwnPort.Text = "Port";
            this.lbOwnPort.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // txOwnPort
            // 
            this.txOwnPort.Location = new System.Drawing.Point(90, 55);
            this.txOwnPort.Name = "txOwnPort";
            this.txOwnPort.Size = new System.Drawing.Size(104, 20);
            this.txOwnPort.TabIndex = 5;
            // 
            // gpBoxDB
            // 
            this.gpBoxDB.BackColor = System.Drawing.Color.White;
            this.gpBoxDB.Controls.Add(this.txDbPassword);
            this.gpBoxDB.Controls.Add(this.lbDBPassword);
            this.gpBoxDB.Controls.Add(this.txDbName);
            this.gpBoxDB.Controls.Add(this.txDbUsername);
            this.gpBoxDB.Controls.Add(this.lbDBName);
            this.gpBoxDB.Controls.Add(this.lbDBServer);
            this.gpBoxDB.Controls.Add(this.lbDBUsername);
            this.gpBoxDB.Controls.Add(this.txDbServer);
            this.gpBoxDB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gpBoxDB.Location = new System.Drawing.Point(9, 45);
            this.gpBoxDB.Name = "gpBoxDB";
            this.gpBoxDB.Size = new System.Drawing.Size(416, 88);
            this.gpBoxDB.TabIndex = 9;
            this.gpBoxDB.TabStop = false;
            this.gpBoxDB.Text = "Database Configuration";
            // 
            // txDbPassword
            // 
            this.txDbPassword.Location = new System.Drawing.Point(264, 56);
            this.txDbPassword.Name = "txDbPassword";
            this.txDbPassword.PasswordChar = '*';
            this.txDbPassword.Size = new System.Drawing.Size(104, 20);
            this.txDbPassword.TabIndex = 4;
            // 
            // lbDBPassword
            // 
            this.lbDBPassword.Location = new System.Drawing.Point(176, 56);
            this.lbDBPassword.Name = "lbDBPassword";
            this.lbDBPassword.Size = new System.Drawing.Size(88, 16);
            this.lbDBPassword.TabIndex = 13;
            this.lbDBPassword.Text = "DbPassword";
            this.lbDBPassword.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // txDbName
            // 
            this.txDbName.Location = new System.Drawing.Point(72, 56);
            this.txDbName.Name = "txDbName";
            this.txDbName.Size = new System.Drawing.Size(104, 20);
            this.txDbName.TabIndex = 2;
            // 
            // txDbUsername
            // 
            this.txDbUsername.Location = new System.Drawing.Point(264, 24);
            this.txDbUsername.Name = "txDbUsername";
            this.txDbUsername.Size = new System.Drawing.Size(104, 20);
            this.txDbUsername.TabIndex = 3;
            // 
            // lbDBName
            // 
            this.lbDBName.Location = new System.Drawing.Point(16, 56);
            this.lbDBName.Name = "lbDBName";
            this.lbDBName.Size = new System.Drawing.Size(56, 16);
            this.lbDBName.TabIndex = 19;
            this.lbDBName.Text = "DbName";
            this.lbDBName.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lbDBServer
            // 
            this.lbDBServer.Location = new System.Drawing.Point(16, 24);
            this.lbDBServer.Name = "lbDBServer";
            this.lbDBServer.Size = new System.Drawing.Size(56, 16);
            this.lbDBServer.TabIndex = 17;
            this.lbDBServer.Text = "DbServer";
            this.lbDBServer.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lbDBUsername
            // 
            this.lbDBUsername.Location = new System.Drawing.Point(192, 24);
            this.lbDBUsername.Name = "lbDBUsername";
            this.lbDBUsername.Size = new System.Drawing.Size(72, 16);
            this.lbDBUsername.TabIndex = 15;
            this.lbDBUsername.Text = "DbUsername";
            this.lbDBUsername.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // txDbServer
            // 
            this.txDbServer.Location = new System.Drawing.Point(72, 24);
            this.txDbServer.Name = "txDbServer";
            this.txDbServer.Size = new System.Drawing.Size(104, 20);
            this.txDbServer.TabIndex = 1;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.AutoSize = false;
            this.kryptonLabel1.ForeColor = System.Drawing.Color.Silver;
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(3, 1);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Padding = new System.Windows.Forms.Padding(5);
            this.kryptonLabel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
            this.kryptonLabel1.Size = new System.Drawing.Size(429, 41);
            this.kryptonLabel1.StateNormal.Padding = new System.Windows.Forms.Padding(5);
            this.kryptonLabel1.StateNormal.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kryptonLabel1.StateNormal.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonLabel1.StateNormal.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kryptonLabel1.TabIndex = 4;
            this.kryptonLabel1.Values.Text = "You can alter this Manager Instance\'s Properties and take actions below...";
            // 
            // Mngr_instance_return
            // 
            this.Mngr_instance_return.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Standalone;
            this.Mngr_instance_return.Location = new System.Drawing.Point(336, 347);
            this.Mngr_instance_return.Name = "Mngr_instance_return";
            this.Mngr_instance_return.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.Mngr_instance_return.Size = new System.Drawing.Size(96, 27);
            this.Mngr_instance_return.TabIndex = 0;
            this.Mngr_instance_return.Values.Text = "<< Return";
            this.Mngr_instance_return.Click += new System.EventHandler(this.Mngr_instance_return_Click);
            // 
            // TrayIcon
            // 
            this.TrayIcon.ContextMenuStrip = this.MaincontextMenuStrip;
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "eduGRID GRIDManager";
            this.TrayIcon.Visible = true;
            this.TrayIcon.Click += new System.EventHandler(this.TrayIconClick);
            // 
            // MaincontextMenuStrip
            // 
            this.MaincontextMenuStrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.MaincontextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlManagersToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.MaincontextMenuStrip.Name = "MaincontextMenuStrip";
            this.MaincontextMenuStrip.Size = new System.Drawing.Size(167, 48);
            // 
            // controlManagersToolStripMenuItem
            // 
            this.controlManagersToolStripMenuItem.Name = "controlManagersToolStripMenuItem";
            this.controlManagersToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.controlManagersToolStripMenuItem.Text = "Control Manager(s)";
            this.controlManagersToolStripMenuItem.Click += new System.EventHandler(this.controlManagersToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Main_BG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::eduGRID_ManagerApp.Properties.Resources.bg1_copy;
            this.ClientSize = new System.Drawing.Size(699, 594);
            this.ContextMenuStrip = this.MaincontextMenuStrip;
            this.Controls.Add(this.inspect_Manager);
            this.Controls.Add(this.est_connections);
            this.Controls.Add(this.btn_conn_4);
            this.Controls.Add(this.btn_conn_3);
            this.Controls.Add(this.btn_conn_2);
            this.Controls.Add(this.btn_Conn_1);
            this.Controls.Add(this.btn_Help);
            this.Controls.Add(this.btn_Monitor);
            this.Controls.Add(this.btn_connect);
            this.Name = "Main_BG";
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Black;
            this.Text = "eduGRID Framework";
            this.WindowActive = true;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form_Paint);
            this.Activated += new System.EventHandler(this.Form_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.btn_connect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Monitor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Help)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Conn_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_conn_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_conn_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_conn_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.est_connections.Panel)).EndInit();
            this.est_connections.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.est_connections)).EndInit();
            this.est_connections.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_est_Return)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inspect_Manager.Panel)).EndInit();
            this.inspect_Manager.Panel.ResumeLayout(false);
            this.inspect_Manager.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inspect_Manager)).EndInit();
            this.inspect_Manager.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_Manager_Reset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Manager_Stop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Manager_Start)).EndInit();
            this.gpBoxNodeConfig.ResumeLayout(false);
            this.gpBoxNodeConfig.PerformLayout();
            this.gpBoxDB.ResumeLayout(false);
            this.gpBoxDB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mngr_instance_return)).EndInit();
            this.MaincontextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btn_connect;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btn_Monitor;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btn_Help;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_Conn_1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_conn_2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_conn_3;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_conn_4;
        private System.Windows.Forms.Timer tmr_fade;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup est_connections;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup buttonSpecHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_est_Return;
        private System.Windows.Forms.ListView listview_managers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblMain;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup inspect_Manager;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup buttonSpecHeaderGroup2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Mngr_instance_return;
        protected System.Windows.Forms.GroupBox gpBoxDB;
        protected System.Windows.Forms.TextBox txDbPassword;
        protected System.Windows.Forms.Label lbDBPassword;
        protected System.Windows.Forms.TextBox txDbName;
        protected System.Windows.Forms.TextBox txDbUsername;
        protected System.Windows.Forms.Label lbDBName;
        protected System.Windows.Forms.Label lbDBServer;
        protected System.Windows.Forms.Label lbDBUsername;
        protected System.Windows.Forms.TextBox txDbServer;
        protected System.Windows.Forms.GroupBox gpBoxNodeConfig;
        protected System.Windows.Forms.Label lbOwnPort;
        protected System.Windows.Forms.TextBox txOwnPort;
        protected System.Windows.Forms.TextBox txLog;
        protected System.Windows.Forms.TextBox txtInstanceName;
        protected System.Windows.Forms.Label lblInstanceName;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_Manager_Reset;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_Manager_Stop;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_Manager_Start;
        private System.Windows.Forms.ProgressBar PBar;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ContextMenuStrip MaincontextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem controlManagersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;


    }
}