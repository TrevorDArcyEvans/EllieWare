//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace RobotWare.Quartz.Calendar.UserInterface
{
  partial class DailyCtrl
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
      System.Windows.Forms.Label label1;
      System.Windows.Forms.Label label2;
      this.InvertRange = new System.Windows.Forms.CheckBox();
      this.TimeFrom = new System.Windows.Forms.DateTimePicker();
      this.TimeTo = new System.Windows.Forms.DateTimePicker();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      label1 = new System.Windows.Forms.Label();
      label2 = new System.Windows.Forms.Label();
      tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 2;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.Controls.Add(label1, 0, 0);
      tableLayoutPanel1.Controls.Add(label2, 0, 1);
      tableLayoutPanel1.Controls.Add(this.InvertRange, 0, 2);
      tableLayoutPanel1.Controls.Add(this.TimeFrom, 1, 0);
      tableLayoutPanel1.Controls.Add(this.TimeTo, 1, 1);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 3;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(381, 138);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(3, 3);
      label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(44, 17);
      label1.TabIndex = 0;
      label1.Text = "From:";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new System.Drawing.Point(3, 31);
      label2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(29, 17);
      label2.TabIndex = 2;
      label2.Text = "To:";
      // 
      // InvertRange
      // 
      this.InvertRange.AutoSize = true;
      this.InvertRange.Location = new System.Drawing.Point(3, 59);
      this.InvertRange.Name = "InvertRange";
      this.InvertRange.Size = new System.Drawing.Size(111, 21);
      this.InvertRange.TabIndex = 4;
      this.InvertRange.Text = "Invert Range";
      this.InvertRange.UseVisualStyleBackColor = true;
      this.InvertRange.CheckedChanged += new System.EventHandler(this.FireCalendarChangedInternal);
      // 
      // TimeFrom
      // 
      this.TimeFrom.CustomFormat = "HH:mm:ss";
      this.TimeFrom.Dock = System.Windows.Forms.DockStyle.Top;
      this.TimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.TimeFrom.Location = new System.Drawing.Point(120, 3);
      this.TimeFrom.Name = "TimeFrom";
      this.TimeFrom.Size = new System.Drawing.Size(258, 22);
      this.TimeFrom.TabIndex = 1;
      this.TimeFrom.ValueChanged += new System.EventHandler(this.FireCalendarChangedInternal);
      // 
      // TimeTo
      // 
      this.TimeTo.CustomFormat = "HH:mm:ss";
      this.TimeTo.Dock = System.Windows.Forms.DockStyle.Top;
      this.TimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.TimeTo.Location = new System.Drawing.Point(120, 31);
      this.TimeTo.Name = "TimeTo";
      this.TimeTo.Size = new System.Drawing.Size(258, 22);
      this.TimeTo.TabIndex = 3;
      this.TimeTo.ValueChanged += new System.EventHandler(this.FireCalendarChangedInternal);
      // 
      // DailyCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(tableLayoutPanel1);
      this.Name = "DailyCtrl";
      this.Size = new System.Drawing.Size(381, 138);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.CheckBox InvertRange;
    private System.Windows.Forms.DateTimePicker TimeFrom;
    private System.Windows.Forms.DateTimePicker TimeTo;
  }
}
