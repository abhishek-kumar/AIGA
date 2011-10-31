namespace eduGRID_client1
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
            this.Chat_Display = new System.Windows.Forms.WebBrowser();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.txt_Query = new System.Windows.Forms.TextBox();
            this.txt_InitDoc = new System.Windows.Forms.TextBox();
            this.tmr_connect = new System.Windows.Forms.Timer(this.components);
            this.tmr_Scroll = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Chat_Display
            // 
            this.Chat_Display.AllowWebBrowserDrop = false;
            this.Chat_Display.Location = new System.Drawing.Point(44, 125);
            this.Chat_Display.MinimumSize = new System.Drawing.Size(20, 20);
            this.Chat_Display.Name = "Chat_Display";
            this.Chat_Display.ScriptErrorsSuppressed = true;
            this.Chat_Display.Size = new System.Drawing.Size(321, 261);
            this.Chat_Display.TabIndex = 0;
            this.Chat_Display.WebBrowserShortcutsEnabled = false;
            this.Chat_Display.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.navigated);
            this.Chat_Display.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.doccomplete);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Send);
            this.groupBox1.Controls.Add(this.txt_Query);
            this.groupBox1.Location = new System.Drawing.Point(38, 414);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 73);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(256, 17);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(66, 46);
            this.btn_Send.TabIndex = 1;
            this.btn_Send.Text = "&Send >>";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // txt_Query
            // 
            this.txt_Query.Location = new System.Drawing.Point(6, 17);
            this.txt_Query.Multiline = true;
            this.txt_Query.Name = "txt_Query";
            this.txt_Query.Size = new System.Drawing.Size(244, 47);
            this.txt_Query.TabIndex = 0;
            this.txt_Query.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keypress);
            this.txt_Query.TextChanged += new System.EventHandler(this.txt_Query_TextChanged);
            // 
            // txt_InitDoc
            // 
            this.txt_InitDoc.Location = new System.Drawing.Point(38, 323);
            this.txt_InitDoc.Multiline = true;
            this.txt_InitDoc.Name = "txt_InitDoc";
            this.txt_InitDoc.Size = new System.Drawing.Size(321, 62);
            this.txt_InitDoc.TabIndex = 2;
            this.txt_InitDoc.Text = resources.GetString("txt_InitDoc.Text");
            this.txt_InitDoc.Visible = false;
            // 
            // tmr_connect
            // 
            this.tmr_connect.Interval = 500;
            this.tmr_connect.Tick += new System.EventHandler(this.Connect);
            // 
            // tmr_Scroll
            // 
            this.tmr_Scroll.Interval = 500;
            this.tmr_Scroll.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::eduGRID_client1.Properties.Resources.eduGRID;
            this.ClientSize = new System.Drawing.Size(377, 526);
            this.ControlBox = false;
            this.Controls.Add(this.txt_InitDoc);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Chat_Display);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_mouseup);
            this.Click += new System.EventHandler(this.test);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_Mousemove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_Mousedown);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser Chat_Display;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.TextBox txt_Query;
        private System.Windows.Forms.TextBox txt_InitDoc;
        private System.Windows.Forms.Timer tmr_connect;
        private System.Windows.Forms.Timer tmr_Scroll;
    }
}

