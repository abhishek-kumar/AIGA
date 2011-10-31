#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  StorageMaintenanceForm.Designer.cs
* Project       :  Alchemi.Console.DataForms
* Created on    :  05 May 2006
* Copyright     :  Copyright © 2006 Tibor Biro (tb@tbiro.com)
* Author        :  Tibor Biro (tb@tbiro.com)
* License       :  GPL
*                    This program is free software; you can redistribute it and/or
*                    modify it under the terms of the GNU General Public
*                    License as published by the Free Software Foundation;
*                    See the GNU General Public License
*                    (http://www.gnu.org/copyleft/gpl.html) for more details.
*
*/
#endregion

namespace Alchemi.Console.DataForms
{
    partial class StorageMaintenanceForm
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
            this.btnPerformMaintenance = new System.Windows.Forms.Button();
            this.chkRemoveAllExecutors = new System.Windows.Forms.CheckBox();
            this.chkRemoveAllApplications = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkRemoveApplicationsByState = new System.Windows.Forms.CheckBox();
            this.lstApplicationStatesToRemove = new System.Windows.Forms.ListBox();
            this.maintenanceOptions = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkRemoveExecutorsByTimePinged = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.chkRemoveApplicationsByTimeCompleted = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkRemoveApplicationsByTimeCreated = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.numTimeApplicationCreatedCutOffInMinutes = new System.Windows.Forms.NumericUpDown();
            this.numTimeApplicationCompletedCutOffInMinutes = new System.Windows.Forms.NumericUpDown();
            this.numTimeExecutorPingedCutOffInMinutes = new System.Windows.Forms.NumericUpDown();
            this.maintenanceOptions.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeApplicationCreatedCutOffInMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeApplicationCompletedCutOffInMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeExecutorPingedCutOffInMinutes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPerformMaintenance
            // 
            this.btnPerformMaintenance.Location = new System.Drawing.Point(225, 359);
            this.btnPerformMaintenance.Name = "btnPerformMaintenance";
            this.btnPerformMaintenance.Size = new System.Drawing.Size(164, 23);
            this.btnPerformMaintenance.TabIndex = 0;
            this.btnPerformMaintenance.Text = "Perform Maintenance";
            this.btnPerformMaintenance.UseVisualStyleBackColor = true;
            this.btnPerformMaintenance.Click += new System.EventHandler(this.btnPerformMaintenance_Click);
            // 
            // chkRemoveAllExecutors
            // 
            this.chkRemoveAllExecutors.AutoSize = true;
            this.chkRemoveAllExecutors.Location = new System.Drawing.Point(19, 15);
            this.chkRemoveAllExecutors.Name = "chkRemoveAllExecutors";
            this.chkRemoveAllExecutors.Size = new System.Drawing.Size(130, 17);
            this.chkRemoveAllExecutors.TabIndex = 1;
            this.chkRemoveAllExecutors.Text = "Remove All Executors";
            this.chkRemoveAllExecutors.UseVisualStyleBackColor = true;
            this.chkRemoveAllExecutors.CheckedChanged += new System.EventHandler(this.chkRemoveAllExecutors_CheckedChanged);
            // 
            // chkRemoveAllApplications
            // 
            this.chkRemoveAllApplications.AutoSize = true;
            this.chkRemoveAllApplications.Location = new System.Drawing.Point(28, 20);
            this.chkRemoveAllApplications.Name = "chkRemoveAllApplications";
            this.chkRemoveAllApplications.Size = new System.Drawing.Size(140, 17);
            this.chkRemoveAllApplications.TabIndex = 2;
            this.chkRemoveAllApplications.Text = "Remove All Applications";
            this.chkRemoveAllApplications.UseVisualStyleBackColor = true;
            this.chkRemoveAllApplications.CheckedChanged += new System.EventHandler(this.chkRemoveAllApplications_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Remove only applications that have the following characteristics:";
            // 
            // chkRemoveApplicationsByState
            // 
            this.chkRemoveApplicationsByState.AutoSize = true;
            this.chkRemoveApplicationsByState.Location = new System.Drawing.Point(28, 91);
            this.chkRemoveApplicationsByState.Name = "chkRemoveApplicationsByState";
            this.chkRemoveApplicationsByState.Size = new System.Drawing.Size(217, 17);
            this.chkRemoveApplicationsByState.TabIndex = 4;
            this.chkRemoveApplicationsByState.Text = "Application status is one of the following:";
            this.chkRemoveApplicationsByState.UseVisualStyleBackColor = true;
            // 
            // lstApplicationStatesToRemove
            // 
            this.lstApplicationStatesToRemove.FormattingEnabled = true;
            this.lstApplicationStatesToRemove.Location = new System.Drawing.Point(288, 91);
            this.lstApplicationStatesToRemove.Name = "lstApplicationStatesToRemove";
            this.lstApplicationStatesToRemove.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstApplicationStatesToRemove.Size = new System.Drawing.Size(120, 95);
            this.lstApplicationStatesToRemove.TabIndex = 5;
            // 
            // maintenanceOptions
            // 
            this.maintenanceOptions.Controls.Add(this.tabPage1);
            this.maintenanceOptions.Controls.Add(this.tabPage2);
            this.maintenanceOptions.Location = new System.Drawing.Point(12, 0);
            this.maintenanceOptions.Name = "maintenanceOptions";
            this.maintenanceOptions.SelectedIndex = 0;
            this.maintenanceOptions.Size = new System.Drawing.Size(601, 325);
            this.maintenanceOptions.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.numTimeExecutorPingedCutOffInMinutes);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.chkRemoveExecutorsByTimePinged);
            this.tabPage1.Controls.Add(this.chkRemoveAllExecutors);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(593, 299);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Executor maintenance";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(302, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Remove only executors that have the following characteristics:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(481, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "minutes.";
            // 
            // chkRemoveExecutorsByTimePinged
            // 
            this.chkRemoveExecutorsByTimePinged.AutoSize = true;
            this.chkRemoveExecutorsByTimePinged.Location = new System.Drawing.Point(19, 110);
            this.chkRemoveExecutorsByTimePinged.Name = "chkRemoveExecutorsByTimePinged";
            this.chkRemoveExecutorsByTimePinged.Size = new System.Drawing.Size(375, 17);
            this.chkRemoveExecutorsByTimePinged.TabIndex = 9;
            this.chkRemoveExecutorsByTimePinged.Text = "The time elapsed since the executor was successfuly pinged is larger than";
            this.chkRemoveExecutorsByTimePinged.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.numTimeApplicationCompletedCutOffInMinutes);
            this.tabPage2.Controls.Add(this.numTimeApplicationCreatedCutOffInMinutes);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.chkRemoveApplicationsByTimeCompleted);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.chkRemoveApplicationsByTimeCreated);
            this.tabPage2.Controls.Add(this.lstApplicationStatesToRemove);
            this.tabPage2.Controls.Add(this.chkRemoveApplicationsByState);
            this.tabPage2.Controls.Add(this.chkRemoveAllApplications);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(593, 299);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Application maintenance";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(456, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "minutes.";
            // 
            // chkRemoveApplicationsByTimeCompleted
            // 
            this.chkRemoveApplicationsByTimeCompleted.AutoSize = true;
            this.chkRemoveApplicationsByTimeCompleted.Location = new System.Drawing.Point(28, 239);
            this.chkRemoveApplicationsByTimeCompleted.Name = "chkRemoveApplicationsByTimeCompleted";
            this.chkRemoveApplicationsByTimeCompleted.Size = new System.Drawing.Size(322, 17);
            this.chkRemoveApplicationsByTimeCompleted.TabIndex = 9;
            this.chkRemoveApplicationsByTimeCompleted.Text = "The time elapsed since the application completed is larger than";
            this.chkRemoveApplicationsByTimeCompleted.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(456, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "minutes.";
            // 
            // chkRemoveApplicationsByTimeCreated
            // 
            this.chkRemoveApplicationsByTimeCreated.AutoSize = true;
            this.chkRemoveApplicationsByTimeCreated.Location = new System.Drawing.Point(28, 201);
            this.chkRemoveApplicationsByTimeCreated.Name = "chkRemoveApplicationsByTimeCreated";
            this.chkRemoveApplicationsByTimeCreated.Size = new System.Drawing.Size(331, 17);
            this.chkRemoveApplicationsByTimeCreated.TabIndex = 6;
            this.chkRemoveApplicationsByTimeCreated.Text = "The time elapsed since the application was created is larger than";
            this.chkRemoveApplicationsByTimeCreated.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(365, 239);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(75, 20);
            this.textBox3.TabIndex = 10;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(28, 239);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(322, 17);
            this.checkBox4.TabIndex = 9;
            this.checkBox4.Text = "The time elapsed since the application completed is larger than";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(456, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "minutes.";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(365, 201);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(75, 20);
            this.textBox4.TabIndex = 7;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(28, 201);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(331, 17);
            this.checkBox5.TabIndex = 6;
            this.checkBox5.Text = "The time elapsed since the application was created is larger than";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(312, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Remove only applications that have the following characteristics:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(456, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "minutes.";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(288, 91);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(120, 95);
            this.listBox2.TabIndex = 5;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(28, 91);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(217, 17);
            this.checkBox6.TabIndex = 4;
            this.checkBox6.Text = "Application status is one of the following:";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(28, 20);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(140, 17);
            this.checkBox7.TabIndex = 2;
            this.checkBox7.Text = "Remove All Applications";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // numTimeApplicationCreatedCutOffInMinutes
            // 
            this.numTimeApplicationCreatedCutOffInMinutes.Location = new System.Drawing.Point(365, 198);
            this.numTimeApplicationCreatedCutOffInMinutes.Name = "numTimeApplicationCreatedCutOffInMinutes";
            this.numTimeApplicationCreatedCutOffInMinutes.Size = new System.Drawing.Size(75, 20);
            this.numTimeApplicationCreatedCutOffInMinutes.TabIndex = 13;
            // 
            // numTimeApplicationCompletedCutOffInMinutes
            // 
            this.numTimeApplicationCompletedCutOffInMinutes.Location = new System.Drawing.Point(365, 236);
            this.numTimeApplicationCompletedCutOffInMinutes.Name = "numTimeApplicationCompletedCutOffInMinutes";
            this.numTimeApplicationCompletedCutOffInMinutes.Size = new System.Drawing.Size(75, 20);
            this.numTimeApplicationCompletedCutOffInMinutes.TabIndex = 14;
            // 
            // numTimeExecutorPingedCutOffInMinutes
            // 
            this.numTimeExecutorPingedCutOffInMinutes.Location = new System.Drawing.Point(400, 106);
            this.numTimeExecutorPingedCutOffInMinutes.Name = "numTimeExecutorPingedCutOffInMinutes";
            this.numTimeExecutorPingedCutOffInMinutes.Size = new System.Drawing.Size(75, 20);
            this.numTimeExecutorPingedCutOffInMinutes.TabIndex = 13;
            // 
            // StorageMaintenanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 401);
            this.Controls.Add(this.maintenanceOptions);
            this.Controls.Add(this.btnPerformMaintenance);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StorageMaintenanceForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Storage Maintenance Form";
            this.maintenanceOptions.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeApplicationCreatedCutOffInMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeApplicationCompletedCutOffInMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeExecutorPingedCutOffInMinutes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPerformMaintenance;
        private System.Windows.Forms.CheckBox chkRemoveAllExecutors;
        private System.Windows.Forms.CheckBox chkRemoveAllApplications;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstApplicationStatesToRemove;
        private System.Windows.Forms.CheckBox chkRemoveApplicationsByState;
        private System.Windows.Forms.TabControl maintenanceOptions;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox chkRemoveApplicationsByTimeCreated;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkRemoveApplicationsByTimeCompleted;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkRemoveExecutorsByTimePinged;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.NumericUpDown numTimeApplicationCompletedCutOffInMinutes;
        private System.Windows.Forms.NumericUpDown numTimeApplicationCreatedCutOffInMinutes;
        private System.Windows.Forms.NumericUpDown numTimeExecutorPingedCutOffInMinutes;
    }
}