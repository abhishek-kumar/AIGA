namespace eduTutor
{
    partial class ScreenSaverForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                rssDescriptionView.Dispose();
                rssView.Dispose();
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
            this.backgroundChangeTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundChangeTimer
            // 
            this.backgroundChangeTimer.Enabled = true;
            this.backgroundChangeTimer.Interval = 10000;
            this.backgroundChangeTimer.Tick += new System.EventHandler(this.backgroundChangeTimerTick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(58, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "This Form is drawn in the OnPaint() and OnPaintBackground() methods.";
            this.label1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(472, 24);
            this.panel1.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.btnClose.DirtyPaletteCounter = 6;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Location = new System.Drawing.Point(448, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Orientation = ComponentFactory.Krypton.Toolkit.VisualOrientation.Right;
            this.btnClose.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnClose.Size = new System.Drawing.Size(24, 24);
            this.btnClose.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnClose.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnClose.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnClose.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "x";
            this.btnClose.Values.ExtraText = "";
            this.btnClose.Values.Image = null;
            this.btnClose.Values.ImageStates.ImageCheckedNormal = null;
            this.btnClose.Values.ImageStates.ImageCheckedPressed = null;
            this.btnClose.Values.ImageStates.ImageCheckedTracking = null;
            this.btnClose.Values.Text = "x";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(289, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "The eduGRID Intelligent Tutor: The Intelligent way to learn...";
            // 
            // ScreenSaverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(472, 459);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScreenSaverForm";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScreenSaverForm_MouseMove);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ScreenSaverForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ScreenSaverForm_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer backgroundChangeTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClose;
        private System.Windows.Forms.Label label2;


    }
}