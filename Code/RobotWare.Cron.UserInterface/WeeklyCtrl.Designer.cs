//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace RobotWare.Cron.UserInterface
{
  partial class WeeklyCtrl
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
      System.Windows.Forms.Label label3;
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      this.WeeklyDays = new System.Windows.Forms.CheckedListBox();
      this.WeeklyTimeValue = new System.Windows.Forms.DateTimePicker();
      label3 = new System.Windows.Forms.Label();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // WeeklyDays
      // 
      tableLayoutPanel1.SetColumnSpan(this.WeeklyDays, 2);
      this.WeeklyDays.Dock = System.Windows.Forms.DockStyle.Fill;
      this.WeeklyDays.FormattingEnabled = true;
      this.WeeklyDays.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
      this.WeeklyDays.Location = new System.Drawing.Point(3, 3);
      this.WeeklyDays.Name = "WeeklyDays";
      this.WeeklyDays.Size = new System.Drawing.Size(431, 139);
      this.WeeklyDays.TabIndex = 0;
      this.WeeklyDays.SelectedIndexChanged += new System.EventHandler(this.FireExpressionChangedInternal);
      // 
      // WeeklyTimeValue
      // 
      this.WeeklyTimeValue.CustomFormat = "HH:mm";
      this.WeeklyTimeValue.Dock = System.Windows.Forms.DockStyle.Top;
      this.WeeklyTimeValue.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.WeeklyTimeValue.Location = new System.Drawing.Point(60, 148);
      this.WeeklyTimeValue.Name = "WeeklyTimeValue";
      this.WeeklyTimeValue.ShowUpDown = true;
      this.WeeklyTimeValue.Size = new System.Drawing.Size(374, 20);
      this.WeeklyTimeValue.TabIndex = 2;
      this.WeeklyTimeValue.ValueChanged += new System.EventHandler(this.FireExpressionChangedInternal);
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new System.Drawing.Point(3, 148);
      label3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(51, 13);
      label3.TabIndex = 1;
      label3.Text = "Start time";
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 2;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.Controls.Add(this.WeeklyTimeValue, 1, 1);
      tableLayoutPanel1.Controls.Add(this.WeeklyDays, 0, 0);
      tableLayoutPanel1.Controls.Add(label3, 0, 1);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 2;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(437, 346);
      tableLayoutPanel1.TabIndex = 8;
      // 
      // WeeklyCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(tableLayoutPanel1);
      this.Name = "WeeklyCtrl";
      this.Size = new System.Drawing.Size(437, 346);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.CheckedListBox WeeklyDays;
    private System.Windows.Forms.DateTimePicker WeeklyTimeValue;
  }
}
