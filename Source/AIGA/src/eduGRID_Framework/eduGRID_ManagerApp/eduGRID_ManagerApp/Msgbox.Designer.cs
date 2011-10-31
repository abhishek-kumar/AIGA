namespace eduGRID_ManagerApp
{
    partial class Msgbox
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
            this.button1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.Button2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.Button3 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.tmr_fade = new System.Windows.Forms.Timer(this.components);
            this.lblMain = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.button1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button3)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(267, 158);
            this.button1.Name = "button1";
            this.button1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Black;
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Values.Text = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(348, 158);
            this.Button2.Name = "Button2";
            this.Button2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Black;
            this.Button2.Size = new System.Drawing.Size(75, 23);
            this.Button2.TabIndex = 1;
            this.Button2.Values.Text = "Button2";
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Button3
            // 
            this.Button3.Location = new System.Drawing.Point(429, 158);
            this.Button3.Name = "Button3";
            this.Button3.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Black;
            this.Button3.Size = new System.Drawing.Size(75, 23);
            this.Button3.TabIndex = 2;
            this.Button3.Values.Text = "Button3";
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // tmr_fade
            // 
            this.tmr_fade.Interval = 50;
            this.tmr_fade.Tick += new System.EventHandler(this.tmr_fade_tick);
            // 
            // lblMain
            // 
            this.lblMain.ForeColor = System.Drawing.Color.Silver;
            this.lblMain.Location = new System.Drawing.Point(12, 9);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(492, 122);
            this.lblMain.TabIndex = 3;
            this.lblMain.Text = "label1";
            this.lblMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Msgbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(516, 193);
            this.Controls.Add(this.lblMain);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Msgbox";
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Black;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Msgbox";
            this.WindowActive = true;
            this.Shown += new System.EventHandler(this.Firstshow);
            this.Load += new System.EventHandler(this.Msgbox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.button1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton button1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Button2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Button3;
        private System.Windows.Forms.Timer tmr_fade;
        private System.Windows.Forms.Label lblMain;

    }
}