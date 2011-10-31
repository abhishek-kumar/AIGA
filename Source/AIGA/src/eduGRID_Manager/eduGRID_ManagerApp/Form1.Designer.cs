namespace eduGRID_ManagerApp
{
    partial class frm_Bg
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
            this.btn_connections = new System.Windows.Forms.Button();
            this.btn_Inspect = new System.Windows.Forms.Button();
            this.btn_Tools = new System.Windows.Forms.Button();
            this.btn_Help = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.fade_timer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_connections
            // 
            this.btn_connections.Location = new System.Drawing.Point(30, 414);
            this.btn_connections.Name = "btn_connections";
            this.btn_connections.Size = new System.Drawing.Size(109, 23);
            this.btn_connections.TabIndex = 1;
            this.btn_connections.Text = "Connections";
            this.btn_connections.UseVisualStyleBackColor = true;
            this.btn_connections.Click += new System.EventHandler(this.btn_connections_Click);
            // 
            // btn_Inspect
            // 
            this.btn_Inspect.Location = new System.Drawing.Point(30, 443);
            this.btn_Inspect.Name = "btn_Inspect";
            this.btn_Inspect.Size = new System.Drawing.Size(109, 23);
            this.btn_Inspect.TabIndex = 2;
            this.btn_Inspect.Text = "Inspect...";
            this.btn_Inspect.UseVisualStyleBackColor = true;
            // 
            // btn_Tools
            // 
            this.btn_Tools.Location = new System.Drawing.Point(30, 472);
            this.btn_Tools.Name = "btn_Tools";
            this.btn_Tools.Size = new System.Drawing.Size(109, 23);
            this.btn_Tools.TabIndex = 3;
            this.btn_Tools.Text = "Framework Tools";
            this.btn_Tools.UseVisualStyleBackColor = true;
            // 
            // btn_Help
            // 
            this.btn_Help.Location = new System.Drawing.Point(30, 501);
            this.btn_Help.Name = "btn_Help";
            this.btn_Help.Size = new System.Drawing.Size(109, 23);
            this.btn_Help.TabIndex = 4;
            this.btn_Help.Text = "Help";
            this.btn_Help.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::eduGRID_ManagerApp.Properties.Resources.bg1_copy2;
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(702, 605);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.B_Mousemove);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.F_Paint);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(181, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(514, 457);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // frm_Bg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(707, 601);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Help);
            this.Controls.Add(this.btn_Tools);
            this.Controls.Add(this.btn_Inspect);
            this.Controls.Add(this.btn_connections);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frm_Bg";
            this.Text = "eduGRID Manager";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_connections;
        private System.Windows.Forms.Button btn_Inspect;
        private System.Windows.Forms.Button btn_Tools;
        private System.Windows.Forms.Button btn_Help;
        private System.Windows.Forms.Timer fade_timer;
        private System.Windows.Forms.Label label1;
    }
}

