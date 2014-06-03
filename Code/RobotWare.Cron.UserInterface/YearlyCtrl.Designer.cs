//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace RobotWare.Cron.UserInterface
{
  partial class YearlyCtrl
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
      System.Windows.Forms.Label label4;
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      System.Windows.Forms.Label label3;
      this.DayMonth = new System.Windows.Forms.ComboBox();
      this.YearlyTimeValue = new System.Windows.Forms.DateTimePicker();
      this.OptDay = new System.Windows.Forms.RadioButton();
      this.OptPeriodic = new System.Windows.Forms.RadioButton();
      this.PeriodicInterval = new System.Windows.Forms.ComboBox();
      this.PeriodicDay = new System.Windows.Forms.ComboBox();
      this.DayValue = new System.Windows.Forms.NumericUpDown();
      this.PeriodicMonth = new System.Windows.Forms.ComboBox();
      label4 = new System.Windows.Forms.Label();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      label3 = new System.Windows.Forms.Label();
      tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.DayValue)).BeginInit();
      this.SuspendLayout();
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new System.Drawing.Point(263, 30);
      label4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
      label4.Name = "label4";
      label4.Size = new System.Drawing.Size(16, 13);
      label4.TabIndex = 6;
      label4.Text = "of";
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 5;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.Controls.Add(this.DayMonth, 1, 0);
      tableLayoutPanel1.Controls.Add(label3, 0, 2);
      tableLayoutPanel1.Controls.Add(this.YearlyTimeValue, 1, 2);
      tableLayoutPanel1.Controls.Add(this.OptDay, 0, 0);
      tableLayoutPanel1.Controls.Add(this.OptPeriodic, 0, 1);
      tableLayoutPanel1.Controls.Add(this.PeriodicInterval, 1, 1);
      tableLayoutPanel1.Controls.Add(this.PeriodicDay, 2, 1);
      tableLayoutPanel1.Controls.Add(label4, 3, 1);
      tableLayoutPanel1.Controls.Add(this.DayValue, 2, 0);
      tableLayoutPanel1.Controls.Add(this.PeriodicMonth, 4, 1);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 3;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(426, 175);
      tableLayoutPanel1.TabIndex = 6;
      // 
      // DayMonth
      // 
      this.DayMonth.Dock = System.Windows.Forms.DockStyle.Top;
      this.DayMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.DayMonth.FormattingEnabled = true;
      this.DayMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
      this.DayMonth.Location = new System.Drawing.Point(61, 3);
      this.DayMonth.Name = "DayMonth";
      this.DayMonth.Size = new System.Drawing.Size(100, 21);
      this.DayMonth.TabIndex = 1;
      this.DayMonth.SelectedIndexChanged += new System.EventHandler(this.FireExpressionChangedInternal);
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new System.Drawing.Point(3, 57);
      label3.Margin = new System.Windows.Forms.Padding(3);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(51, 13);
      label3.TabIndex = 8;
      label3.Text = "Start time";
      // 
      // YearlyTimeValue
      // 
      this.YearlyTimeValue.CustomFormat = "HH:mm";
      this.YearlyTimeValue.Dock = System.Windows.Forms.DockStyle.Top;
      this.YearlyTimeValue.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.YearlyTimeValue.Location = new System.Drawing.Point(61, 57);
      this.YearlyTimeValue.Name = "YearlyTimeValue";
      this.YearlyTimeValue.ShowUpDown = true;
      this.YearlyTimeValue.Size = new System.Drawing.Size(100, 20);
      this.YearlyTimeValue.TabIndex = 9;
      this.YearlyTimeValue.ValueChanged += new System.EventHandler(this.FireExpressionChangedInternal);
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
      this.OptDay.CheckedChanged += new System.EventHandler(this.FireExpressionChangedInternal);
      // 
      // OptPeriodic
      // 
      this.OptPeriodic.AutoSize = true;
      this.OptPeriodic.Location = new System.Drawing.Point(3, 30);
      this.OptPeriodic.Name = "OptPeriodic";
      this.OptPeriodic.Size = new System.Drawing.Size(44, 17);
      this.OptPeriodic.TabIndex = 3;
      this.OptPeriodic.Text = "The";
      this.OptPeriodic.UseVisualStyleBackColor = true;
      this.OptPeriodic.CheckedChanged += new System.EventHandler(this.FireExpressionChangedInternal);
      // 
      // PeriodicInterval
      // 
      this.PeriodicInterval.Dock = System.Windows.Forms.DockStyle.Top;
      this.PeriodicInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.PeriodicInterval.Enabled = false;
      this.PeriodicInterval.FormattingEnabled = true;
      this.PeriodicInterval.Items.AddRange(new object[] {
            "First",
            "Second",
            "Third",
            "Fourth"});
      this.PeriodicInterval.Location = new System.Drawing.Point(61, 30);
      this.PeriodicInterval.Name = "PeriodicInterval";
      this.PeriodicInterval.Size = new System.Drawing.Size(100, 21);
      this.PeriodicInterval.TabIndex = 4;
      this.PeriodicInterval.SelectedIndexChanged += new System.EventHandler(this.FireExpressionChangedInternal);
      // 
      // PeriodicDay
      // 
      this.PeriodicDay.Dock = System.Windows.Forms.DockStyle.Top;
      this.PeriodicDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.PeriodicDay.Enabled = false;
      this.PeriodicDay.FormattingEnabled = true;
      this.PeriodicDay.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
      this.PeriodicDay.Location = new System.Drawing.Point(167, 30);
      this.PeriodicDay.Name = "PeriodicDay";
      this.PeriodicDay.Size = new System.Drawing.Size(90, 21);
      this.PeriodicDay.TabIndex = 5;
      this.PeriodicDay.SelectedIndexChanged += new System.EventHandler(this.FireExpressionChangedInternal);
      // 
      // DayValue
      // 
      this.DayValue.AutoSize = true;
      this.DayValue.Dock = System.Windows.Forms.DockStyle.Top;
      this.DayValue.Location = new System.Drawing.Point(167, 3);
      this.DayValue.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
      this.DayValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.DayValue.Name = "DayValue";
      this.DayValue.Size = new System.Drawing.Size(90, 20);
      this.DayValue.TabIndex = 2;
      this.DayValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.DayValue.ValueChanged += new System.EventHandler(this.FireExpressionChangedInternal);
      // 
      // PeriodicMonth
      // 
      this.PeriodicMonth.Dock = System.Windows.Forms.DockStyle.Top;
      this.PeriodicMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.PeriodicMonth.Enabled = false;
      this.PeriodicMonth.FormattingEnabled = true;
      this.PeriodicMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
      this.PeriodicMonth.Location = new System.Drawing.Point(285, 30);
      this.PeriodicMonth.Name = "PeriodicMonth";
      this.PeriodicMonth.Size = new System.Drawing.Size(138, 21);
      this.PeriodicMonth.TabIndex = 7;
      this.PeriodicMonth.SelectedIndexChanged += new System.EventHandler(this.FireExpressionChangedInternal);
      // 
      // YearlyCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(tableLayoutPanel1);
      this.Name = "YearlyCtrl";
      this.Size = new System.Drawing.Size(426, 175);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.DayValue)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ComboBox PeriodicInterval;
    private System.Windows.Forms.ComboBox PeriodicDay;
    private System.Windows.Forms.NumericUpDown DayValue;
    private System.Windows.Forms.ComboBox DayMonth;
    private System.Windows.Forms.DateTimePicker YearlyTimeValue;
    private System.Windows.Forms.RadioButton OptDay;
    private System.Windows.Forms.RadioButton OptPeriodic;
    private System.Windows.Forms.ComboBox PeriodicMonth;
  }
}
