namespace eduGRID_ManagerApp
{
    partial class frm_connection
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
            System.Windows.Forms.ListViewItem listViewItem37 = new System.Windows.Forms.ListViewItem("S No");
            System.Windows.Forms.ListViewItem listViewItem38 = new System.Windows.Forms.ListViewItem("Name");
            System.Windows.Forms.ListViewItem listViewItem39 = new System.Windows.Forms.ListViewItem("Port");
            System.Windows.Forms.ListViewItem listViewItem40 = new System.Windows.Forms.ListViewItem("Status");
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.fade_timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connection";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(339, 347);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "&Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView1
            // 
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem37,
            listViewItem38,
            listViewItem39,
            listViewItem40});
            this.listView1.Location = new System.Drawing.Point(16, 40);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(398, 72);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // fade_timer
            // 
            this.fade_timer.Interval = 50;
            this.fade_timer.Tick += new System.EventHandler(this.fade_timer_f);
            // 
            // frm_connection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(446, 402);
            this.ControlBox = false;
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_connection";
            this.Opacity = 0.6;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form_Paint);
            this.Leave += new System.EventHandler(this.Lostfocus);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Timer fade_timer;
    }
}