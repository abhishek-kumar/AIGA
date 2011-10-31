using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MSR.LST.ConferenceXP
{
    public class frmAVTroubleshooting : System.Windows.Forms.Form
    {
        #region Windows Form Designer generated code

        private System.Windows.Forms.Button btnScrollEnd;
        private System.Windows.Forms.Button btnClearDebug;
        private System.Windows.Forms.TextBox txtDebug;
        private System.Windows.Forms.Button btnClose;

        private System.ComponentModel.Container components = null;

        public frmAVTroubleshooting()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClose = new System.Windows.Forms.Button();
            this.btnScrollEnd = new System.Windows.Forms.Button();
            this.btnClearDebug = new System.Windows.Forms.Button();
            this.txtDebug = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnClose.Location = new System.Drawing.Point(424, 212);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 23);
            this.btnClose.TabIndex = 44;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnScrollEnd
            // 
            this.btnScrollEnd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnScrollEnd.Location = new System.Drawing.Point(112, 8);
            this.btnScrollEnd.Name = "btnScrollEnd";
            this.btnScrollEnd.Size = new System.Drawing.Size(95, 23);
            this.btnScrollEnd.TabIndex = 47;
            this.btnScrollEnd.Text = " Scroll to end";
            this.btnScrollEnd.Click += new System.EventHandler(this.btnScrollEnd_Click);
            // 
            // btnClearDebug
            // 
            this.btnClearDebug.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClearDebug.Location = new System.Drawing.Point(8, 8);
            this.btnClearDebug.Name = "btnClearDebug";
            this.btnClearDebug.Size = new System.Drawing.Size(95, 23);
            this.btnClearDebug.TabIndex = 46;
            this.btnClearDebug.Text = "Clear";
            this.btnClearDebug.Click += new System.EventHandler(this.btnClearDebug_Click);
            // 
            // txtDebug
            // 
            this.txtDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebug.Location = new System.Drawing.Point(8, 38);
            this.txtDebug.Multiline = true;
            this.txtDebug.Name = "txtDebug";
            this.txtDebug.ReadOnly = true;
            this.txtDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDebug.Size = new System.Drawing.Size(512, 162);
            this.txtDebug.TabIndex = 45;
            this.txtDebug.Text = "";
            // 
            // frmAVTroubleshooting
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(530, 248);
            this.ControlBox = false;
            this.Controls.Add(this.btnScrollEnd);
            this.Controls.Add(this.btnClearDebug);
            this.Controls.Add(this.txtDebug);
            this.Controls.Add(this.btnClose);
            this.Name = "frmAVTroubleshooting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Audio/Video Troubleshooting";
            this.ResumeLayout(false);

        }

        
        #endregion

        private void btnClearDebug_Click(object sender, System.EventArgs e)
        {
            txtDebug.Text = null;
        }

        private void btnScrollEnd_Click(object sender, System.EventArgs e)
        {
            txtDebug.SelectionStart = txtDebug.Text.Length;
            txtDebug.ScrollToCaret();        
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Visible = false;
        }


        public void Log(string msg)
        {
            txtDebug.Text += (msg + Environment.NewLine);
        }
    }
}
