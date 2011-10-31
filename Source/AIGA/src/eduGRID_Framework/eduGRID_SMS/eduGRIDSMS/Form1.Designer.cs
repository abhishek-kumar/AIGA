namespace eduGRIDSMS
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
            this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.kryptonPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.smsInbound1 = new BT.Sdk.Components.SmsInbound(this.components);
            this.smsOneWay1 = new BT.Sdk.Components.SmsOneWay(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonManager
            // 
            this.kryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Black;
            // 
            // kryptonPanel
            // 
            this.kryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel.Name = "kryptonPanel";
            this.kryptonPanel.Size = new System.Drawing.Size(292, 266);
            this.kryptonPanel.TabIndex = 0;
            // 
            // smsInbound1
            // 
            this.smsInbound1.UserId = new System.Guid("00000000-0000-0000-0000-000000000000");
            // 
            // smsOneWay1
            // 
            this.smsOneWay1.UserId = new System.Guid("00000000-0000-0000-0000-000000000000");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.kryptonPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel;
        private BT.Sdk.Components.SmsInbound smsInbound1;
        private BT.Sdk.Components.SmsOneWay smsOneWay1;
    }
}

