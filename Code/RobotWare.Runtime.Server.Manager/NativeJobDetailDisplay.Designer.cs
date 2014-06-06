//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace RobotWare.Runtime.Server.Manager
{
    partial class NativeJobDetailDisplay
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
      this.lblName = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.lblGroup = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.lblDescription = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.jobDataListView = new System.Windows.Forms.ListView();
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // lblName
      // 
      this.lblName.AutoSize = true;
      this.lblName.Location = new System.Drawing.Point(72, 3);
      this.lblName.Margin = new System.Windows.Forms.Padding(3);
      this.lblName.Name = "lblName";
      this.lblName.Size = new System.Drawing.Size(35, 13);
      this.lblName.TabIndex = 5;
      this.lblName.Text = "label2";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(3, 3);
      this.label3.Margin = new System.Windows.Forms.Padding(3);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(38, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "Name:";
      // 
      // lblGroup
      // 
      this.lblGroup.AutoSize = true;
      this.lblGroup.Location = new System.Drawing.Point(72, 22);
      this.lblGroup.Margin = new System.Windows.Forms.Padding(3);
      this.lblGroup.Name = "lblGroup";
      this.lblGroup.Size = new System.Drawing.Size(35, 13);
      this.lblGroup.TabIndex = 7;
      this.lblGroup.Text = "label2";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(3, 22);
      this.label2.Margin = new System.Windows.Forms.Padding(3);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(39, 13);
      this.label2.TabIndex = 6;
      this.label2.Text = "Group:";
      // 
      // lblDescription
      // 
      this.lblDescription.AutoSize = true;
      this.lblDescription.Location = new System.Drawing.Point(72, 41);
      this.lblDescription.Margin = new System.Windows.Forms.Padding(3);
      this.lblDescription.Name = "lblDescription";
      this.lblDescription.Size = new System.Drawing.Size(35, 13);
      this.lblDescription.TabIndex = 9;
      this.lblDescription.Text = "label2";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(3, 41);
      this.label5.Margin = new System.Windows.Forms.Padding(3);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(63, 13);
      this.label5.TabIndex = 8;
      this.label5.Text = "Description:";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(3, 60);
      this.label10.Margin = new System.Windows.Forms.Padding(3);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(53, 13);
      this.label10.TabIndex = 23;
      this.label10.Text = "Job Data:";
      // 
      // jobDataListView
      // 
      this.jobDataListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
      tableLayoutPanel1.SetColumnSpan(this.jobDataListView, 2);
      this.jobDataListView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.jobDataListView.FullRowSelect = true;
      this.jobDataListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.jobDataListView.Location = new System.Drawing.Point(3, 79);
      this.jobDataListView.MultiSelect = false;
      this.jobDataListView.Name = "jobDataListView";
      this.jobDataListView.Size = new System.Drawing.Size(336, 191);
      this.jobDataListView.TabIndex = 22;
      this.jobDataListView.UseCompatibleStateImageBehavior = false;
      this.jobDataListView.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Key";
      this.columnHeader1.Width = 82;
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "Value";
      this.columnHeader2.Width = 145;
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.AutoSize = true;
      tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      tableLayoutPanel1.ColumnCount = 2;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
      tableLayoutPanel1.Controls.Add(this.jobDataListView, 0, 4);
      tableLayoutPanel1.Controls.Add(this.label10, 0, 3);
      tableLayoutPanel1.Controls.Add(this.lblName, 1, 0);
      tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
      tableLayoutPanel1.Controls.Add(this.lblDescription, 1, 2);
      tableLayoutPanel1.Controls.Add(this.lblGroup, 1, 1);
      tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 5;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.Size = new System.Drawing.Size(342, 273);
      tableLayoutPanel1.TabIndex = 24;
      // 
      // NativeJobDetailDisplay
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(tableLayoutPanel1);
      this.Name = "NativeJobDetailDisplay";
      this.Size = new System.Drawing.Size(342, 273);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListView jobDataListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}
