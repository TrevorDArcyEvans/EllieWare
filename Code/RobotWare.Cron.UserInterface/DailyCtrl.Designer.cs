//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace RobotWare.Cron.UserInterface
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
      System.Windows.Forms.Label label3;
      this.HourTimeValue = new System.Windows.Forms.DateTimePicker();
      this.OptDay = new System.Windows.Forms.RadioButton();
      this.OptWeekDay = new System.Windows.Forms.RadioButton();
      this.DailyValue = new System.Windows.Forms.NumericUpDown();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      label1 = new System.Windows.Forms.Label();
      label3 = new System.Windows.Forms.Label();
      tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.DailyValue)).BeginInit();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.Controls.Add(this.HourTimeValue, 1, 2);
      tableLayoutPanel1.Controls.Add(this.OptDay, 0, 0);
      tableLayoutPanel1.Controls.Add(this.OptWeekDay, 0, 1);
      tableLayoutPanel1.Controls.Add(this.DailyValue, 1, 0);
      tableLayoutPanel1.Controls.Add(label1, 2, 0);
      tableLayoutPanel1.Controls.Add(label3, 0, 2);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 3;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(357, 275);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // HourTimeValue
      // 
      this.HourTimeValue.CustomFormat = "HH:mm";
      this.HourTimeValue.Dock = System.Windows.Forms.DockStyle.Top;
      this.HourTimeValue.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.HourTimeValue.Location = new System.Drawing.Point(115, 52);
      this.HourTimeValue.Name = "HourTimeValue";
      this.HourTimeValue.ShowUpDown = true;
      this.HourTimeValue.Size = new System.Drawing.Size(198, 20);
      this.HourTimeValue.TabIndex = 5;
      this.HourTimeValue.ValueChanged += new System.EventHandler(this.FireExpressionChangedInternal);
      // 
      // OptDay
      // 
      this.OptDay.AutoSize = true;
      this.OptDay.Checked = true;
      this.OptDay.Location = new System.Drawing.Point(3, 3);
      this.OptDay.Name = "OptDay";
      this.OptDay.Size = new System.Drawing.Size(52, 17);
      this.OptDay.TabIndex = 0;
      this.OptDay.TabStop = true;
      this.OptDay.Text = "Every";
      this.OptDay.UseVisualStyleBackColor = true;
      // 
      // OptWeekDay
      // 
      this.OptWeekDay.AutoSize = true;
      this.OptWeekDay.Location = new System.Drawing.Point(3, 29);
      this.OptWeekDay.Name = "OptWeekDay";
      this.OptWeekDay.Size = new System.Drawing.Size(106, 17);
      this.OptWeekDay.TabIndex = 3;
      this.OptWeekDay.Text = "Every Week Day";
      this.OptWeekDay.UseVisualStyleBackColor = true;
      this.OptWeekDay.CheckedChanged += new System.EventHandler(this.FireExpressionChangedInternal);
      // 
      // DailyValue
      // 
      this.DailyValue.Dock = System.Windows.Forms.DockStyle.Top;
      this.DailyValue.Location = new System.Drawing.Point(115, 3);
      this.DailyValue.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
      this.DailyValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.DailyValue.Name = "DailyValue";
      this.DailyValue.Size = new System.Drawing.Size(198, 20);
      this.DailyValue.TabIndex = 1;
      this.DailyValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.DailyValue.ValueChanged += new System.EventHandler(this.FireExpressionChangedInternal);
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(319, 3);
      label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(35, 13);
      label1.TabIndex = 2;
      label1.Text = "day(s)";
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new System.Drawing.Point(3, 52);
      label3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(51, 13);
      label3.TabIndex = 4;
      label3.Text = "Start time";
      // 
      // DailyCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(tableLayoutPanel1);
      this.Name = "DailyCtrl";
      this.Size = new System.Drawing.Size(357, 275);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.DailyValue)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.RadioButton OptDay;
    private System.Windows.Forms.RadioButton OptWeekDay;
    private System.Windows.Forms.NumericUpDown DailyValue;
    private System.Windows.Forms.DateTimePicker HourTimeValue;
  }
}
