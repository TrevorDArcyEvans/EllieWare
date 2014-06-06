//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace RobotWare.Runtime.Server.Manager
{
    partial class CronTriggerDisplay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      this.label1 = new System.Windows.Forms.Label();
      this.lblPreviousFireTime = new System.Windows.Forms.Label();
      this.lblNextFireTime = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.txtCronExpression = new System.Windows.Forms.TextBox();
      this.label11 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.lblName = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.lblDescription = new System.Windows.Forms.Label();
      this.lblGroup = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.lblCronDescription = new System.Windows.Forms.Label();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.AutoSize = true;
      tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      tableLayoutPanel1.ColumnCount = 2;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.Controls.Add(this.label1, 0, 3);
      tableLayoutPanel1.Controls.Add(this.lblPreviousFireTime, 1, 6);
      tableLayoutPanel1.Controls.Add(this.lblNextFireTime, 1, 5);
      tableLayoutPanel1.Controls.Add(this.label9, 0, 6);
      tableLayoutPanel1.Controls.Add(this.txtCronExpression, 1, 4);
      tableLayoutPanel1.Controls.Add(this.label11, 0, 5);
      tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
      tableLayoutPanel1.Controls.Add(this.lblName, 1, 0);
      tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
      tableLayoutPanel1.Controls.Add(this.lblDescription, 1, 2);
      tableLayoutPanel1.Controls.Add(this.lblGroup, 1, 1);
      tableLayoutPanel1.Controls.Add(this.label7, 0, 2);
      tableLayoutPanel1.Controls.Add(this.lblCronDescription, 1, 3);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 7;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(324, 168);
      tableLayoutPanel1.TabIndex = 13;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Dock = System.Windows.Forms.DockStyle.Top;
      this.label1.Location = new System.Drawing.Point(3, 60);
      this.label1.Margin = new System.Windows.Forms.Padding(3);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(97, 13);
      this.label1.TabIndex = 6;
      this.label1.Text = "Cron Expression:";
      // 
      // lblPreviousFireTime
      // 
      this.lblPreviousFireTime.AutoSize = true;
      this.lblPreviousFireTime.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblPreviousFireTime.Location = new System.Drawing.Point(106, 124);
      this.lblPreviousFireTime.Margin = new System.Windows.Forms.Padding(3);
      this.lblPreviousFireTime.Name = "lblPreviousFireTime";
      this.lblPreviousFireTime.Size = new System.Drawing.Size(215, 13);
      this.lblPreviousFireTime.TabIndex = 12;
      this.lblPreviousFireTime.Text = "label8";
      // 
      // lblNextFireTime
      // 
      this.lblNextFireTime.AutoSize = true;
      this.lblNextFireTime.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblNextFireTime.Location = new System.Drawing.Point(106, 105);
      this.lblNextFireTime.Margin = new System.Windows.Forms.Padding(3);
      this.lblNextFireTime.Name = "lblNextFireTime";
      this.lblNextFireTime.Size = new System.Drawing.Size(215, 13);
      this.lblNextFireTime.TabIndex = 10;
      this.lblNextFireTime.Text = "label10";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Dock = System.Windows.Forms.DockStyle.Top;
      this.label9.Location = new System.Drawing.Point(3, 124);
      this.label9.Margin = new System.Windows.Forms.Padding(3);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(97, 13);
      this.label9.TabIndex = 11;
      this.label9.Text = "Previous Fire Time:";
      // 
      // txtCronExpression
      // 
      this.txtCronExpression.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtCronExpression.Location = new System.Drawing.Point(106, 79);
      this.txtCronExpression.Name = "txtCronExpression";
      this.txtCronExpression.ReadOnly = true;
      this.txtCronExpression.Size = new System.Drawing.Size(215, 20);
      this.txtCronExpression.TabIndex = 8;
      this.txtCronExpression.Text = "txtCronExpression";
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Dock = System.Windows.Forms.DockStyle.Top;
      this.label11.Location = new System.Drawing.Point(3, 105);
      this.label11.Margin = new System.Windows.Forms.Padding(3);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(97, 13);
      this.label11.TabIndex = 9;
      this.label11.Text = "Next Fire Time:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Dock = System.Windows.Forms.DockStyle.Top;
      this.label3.Location = new System.Drawing.Point(3, 3);
      this.label3.Margin = new System.Windows.Forms.Padding(3);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(97, 13);
      this.label3.TabIndex = 0;
      this.label3.Text = "Name:";
      // 
      // lblName
      // 
      this.lblName.AutoSize = true;
      this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblName.Location = new System.Drawing.Point(106, 3);
      this.lblName.Margin = new System.Windows.Forms.Padding(3);
      this.lblName.Name = "lblName";
      this.lblName.Size = new System.Drawing.Size(215, 13);
      this.lblName.TabIndex = 1;
      this.lblName.Text = "label2";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Dock = System.Windows.Forms.DockStyle.Top;
      this.label5.Location = new System.Drawing.Point(3, 22);
      this.label5.Margin = new System.Windows.Forms.Padding(3);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(97, 13);
      this.label5.TabIndex = 2;
      this.label5.Text = "Group:";
      // 
      // lblDescription
      // 
      this.lblDescription.AutoSize = true;
      this.lblDescription.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblDescription.Location = new System.Drawing.Point(106, 41);
      this.lblDescription.Margin = new System.Windows.Forms.Padding(3);
      this.lblDescription.Name = "lblDescription";
      this.lblDescription.Size = new System.Drawing.Size(215, 13);
      this.lblDescription.TabIndex = 5;
      this.lblDescription.Text = "label6";
      // 
      // lblGroup
      // 
      this.lblGroup.AutoSize = true;
      this.lblGroup.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblGroup.Location = new System.Drawing.Point(106, 22);
      this.lblGroup.Margin = new System.Windows.Forms.Padding(3);
      this.lblGroup.Name = "lblGroup";
      this.lblGroup.Size = new System.Drawing.Size(215, 13);
      this.lblGroup.TabIndex = 3;
      this.lblGroup.Text = "label4";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Dock = System.Windows.Forms.DockStyle.Top;
      this.label7.Location = new System.Drawing.Point(3, 41);
      this.label7.Margin = new System.Windows.Forms.Padding(3);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(97, 13);
      this.label7.TabIndex = 4;
      this.label7.Text = "Description:";
      // 
      // lblCronDescription
      // 
      this.lblCronDescription.AutoSize = true;
      this.lblCronDescription.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblCronDescription.Location = new System.Drawing.Point(106, 60);
      this.lblCronDescription.Margin = new System.Windows.Forms.Padding(3);
      this.lblCronDescription.Name = "lblCronDescription";
      this.lblCronDescription.Size = new System.Drawing.Size(215, 13);
      this.lblCronDescription.TabIndex = 7;
      this.lblCronDescription.Text = "label6";
      // 
      // CronTriggerDisplay
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(tableLayoutPanel1);
      this.Name = "CronTriggerDisplay";
      this.Size = new System.Drawing.Size(324, 168);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPreviousFireTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblNextFireTime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCronExpression;
        private System.Windows.Forms.Label lblCronDescription;
    }
}
