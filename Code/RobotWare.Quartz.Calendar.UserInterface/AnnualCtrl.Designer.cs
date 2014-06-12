//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace RobotWare.Quartz.Calendar.UserInterface
{
  partial class AnnualCtrl
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
      this.DaysExcluded = new System.Windows.Forms.ListBox();
      this.CmdAdd = new System.Windows.Forms.Button();
      this.ExcludeDay = new System.Windows.Forms.DateTimePicker();
      this.CmdDelete = new System.Windows.Forms.Button();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.Controls.Add(this.DaysExcluded, 0, 0);
      tableLayoutPanel1.Controls.Add(this.CmdAdd, 1, 1);
      tableLayoutPanel1.Controls.Add(this.ExcludeDay, 0, 1);
      tableLayoutPanel1.Controls.Add(this.CmdDelete, 2, 0);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 2;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(393, 352);
      tableLayoutPanel1.TabIndex = 1;
      // 
      // DaysExcluded
      // 
      tableLayoutPanel1.SetColumnSpan(this.DaysExcluded, 2);
      this.DaysExcluded.Dock = System.Windows.Forms.DockStyle.Fill;
      this.DaysExcluded.FormattingEnabled = true;
      this.DaysExcluded.ItemHeight = 16;
      this.DaysExcluded.Location = new System.Drawing.Point(3, 3);
      this.DaysExcluded.Name = "DaysExcluded";
      this.DaysExcluded.Size = new System.Drawing.Size(306, 313);
      this.DaysExcluded.Sorted = true;
      this.DaysExcluded.TabIndex = 0;
      this.DaysExcluded.SelectedIndexChanged += new System.EventHandler(this.FireCalendarChangedInternal);
      this.DaysExcluded.SelectedValueChanged += new System.EventHandler(this.FireCalendarChangedInternal);
      // 
      // CmdAdd
      // 
      this.CmdAdd.Location = new System.Drawing.Point(209, 322);
      this.CmdAdd.Name = "CmdAdd";
      this.CmdAdd.Size = new System.Drawing.Size(75, 27);
      this.CmdAdd.TabIndex = 3;
      this.CmdAdd.Text = "Add";
      this.CmdAdd.UseVisualStyleBackColor = true;
      this.CmdAdd.Click += new System.EventHandler(this.CmdAdd_Click);
      // 
      // ExcludeDay
      // 
      this.ExcludeDay.Dock = System.Windows.Forms.DockStyle.Top;
      this.ExcludeDay.Location = new System.Drawing.Point(3, 322);
      this.ExcludeDay.Name = "ExcludeDay";
      this.ExcludeDay.Size = new System.Drawing.Size(200, 22);
      this.ExcludeDay.TabIndex = 2;
      // 
      // CmdDelete
      // 
      this.CmdDelete.Enabled = false;
      this.CmdDelete.Location = new System.Drawing.Point(315, 3);
      this.CmdDelete.Name = "CmdDelete";
      this.CmdDelete.Size = new System.Drawing.Size(75, 27);
      this.CmdDelete.TabIndex = 1;
      this.CmdDelete.Text = "Delete";
      this.CmdDelete.UseVisualStyleBackColor = true;
      this.CmdDelete.Click += new System.EventHandler(this.CmdDelete_Click);
      // 
      // AnnualCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(tableLayoutPanel1);
      this.Name = "AnnualCtrl";
      this.Size = new System.Drawing.Size(393, 352);
      tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListBox DaysExcluded;
    private System.Windows.Forms.Button CmdAdd;
    private System.Windows.Forms.DateTimePicker ExcludeDay;
    private System.Windows.Forms.Button CmdDelete;
  }
}
