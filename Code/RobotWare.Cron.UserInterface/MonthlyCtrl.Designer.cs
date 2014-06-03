//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace RobotWare.Cron.UserInterface
{
  partial class MonthlyCtrl
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
      System.Windows.Forms.Label label3;
      System.Windows.Forms.Label label1;
      System.Windows.Forms.Label label2;
      System.Windows.Forms.Label label4;
      System.Windows.Forms.Label label5;
      this.MonthlyTimeValue = new System.Windows.Forms.DateTimePicker();
      this.OptDay = new System.Windows.Forms.RadioButton();
      this.OptPeriodic = new System.Windows.Forms.RadioButton();
      this.DayMonth = new System.Windows.Forms.NumericUpDown();
      this.PeriodicInterval = new System.Windows.Forms.ComboBox();
      this.PeriodicDay = new System.Windows.Forms.ComboBox();
      this.DayValue = new System.Windows.Forms.NumericUpDown();
      this.PeriodicMonth = new System.Windows.Forms.NumericUpDown();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      label3 = new System.Windows.Forms.Label();
      label1 = new System.Windows.Forms.Label();
      label2 = new System.Windows.Forms.Label();
      label4 = new System.Windows.Forms.Label();
      label5 = new System.Windows.Forms.Label();
      tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.DayMonth)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.DayValue)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PeriodicMonth)).BeginInit();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 6;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.Controls.Add(label3, 0, 2);
      tableLayoutPanel1.Controls.Add(this.MonthlyTimeValue, 1, 2);
      tableLayoutPanel1.Controls.Add(this.OptDay, 0, 0);
      tableLayoutPanel1.Controls.Add(this.OptPeriodic, 0, 1);
      tableLayoutPanel1.Controls.Add(this.DayMonth, 3, 0);
      tableLayoutPanel1.Controls.Add(label1, 2, 0);
      tableLayoutPanel1.Controls.Add(label2, 4, 0);
      tableLayoutPanel1.Controls.Add(this.PeriodicInterval, 1, 1);
      tableLayoutPanel1.Controls.Add(this.PeriodicDay, 2, 1);
      tableLayoutPanel1.Controls.Add(label4, 3, 1);
      tableLayoutPanel1.Controls.Add(this.DayValue, 1, 0);
      tableLayoutPanel1.Controls.Add(this.PeriodicMonth, 4, 1);
      tableLayoutPanel1.Controls.Add(label5, 5, 1);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 3;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(464, 316);
      tableLayoutPanel1.TabIndex = 5;
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new System.Drawing.Point(3, 56);
      label3.Margin = new System.Windows.Forms.Padding(3);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(51, 13);
      label3.TabIndex = 11;
      label3.Text = "Start time";
      // 
      // MonthlyTimeValue
      // 
      this.MonthlyTimeValue.CustomFormat = "HH:mm";
      this.MonthlyTimeValue.Dock = System.Windows.Forms.DockStyle.Top;
      this.MonthlyTimeValue.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.MonthlyTimeValue.Location = new System.Drawing.Point(60, 56);
      this.MonthlyTimeValue.Name = "MonthlyTimeValue";
      this.MonthlyTimeValue.ShowUpDown = true;
      this.MonthlyTimeValue.Size = new System.Drawing.Size(65, 20);
      this.MonthlyTimeValue.TabIndex = 12;
      this.MonthlyTimeValue.ValueChanged += new System.EventHandler(this.FireExpressionChangedInternal);
      // 
      // OptDay
      // 
      this.OptDay.AutoSize = true;
      this.OptDay.Checked = true;
      this.OptDay.Location = new System.Drawing.Point(3, 3);
      this.OptDay.Name = "OptDay";
      this.OptDay.Size = new System.Drawing.Size(44, 17);
      this.OptDay.TabIndex = 0;
      this.OptDay.TabStop = true;
      this.OptDay.Text = "Day";
      this.OptDay.UseVisualStyleBackColor = true;
      this.OptDay.CheckedChanged += new System.EventHandler(this.FireExpressionChangedInternal);
      // 
      // OptPeriodic
      // 
      this.OptPeriodic.AutoSize = true;
      this.OptPeriodic.Location = new System.Drawing.Point(3, 29);
      this.OptPeriodic.Name = "OptPeriodic";
      this.OptPeriodic.Size = new System.Drawing.Size(44, 17);
      this.OptPeriodic.TabIndex = 5;
      this.OptPeriodic.Text = "The";
      this.OptPeriodic.UseVisualStyleBackColor = true;
      this.OptPeriodic.CheckedChanged += new System.EventHandler(this.FireExpressionChangedInternal);
      // 
      // DayMonth
      // 
      this.DayMonth.Dock = System.Windows.Forms.DockStyle.Top;
      this.DayMonth.Location = new System.Drawing.Point(227, 3);
      this.DayMonth.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
      this.DayMonth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.DayMonth.Name = "DayMonth";
      this.DayMonth.Size = new System.Drawing.Size(65, 20);
      this.DayMonth.TabIndex = 3;
      this.DayMonth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.DayMonth.ValueChanged += new System.EventHandler(this.FireExpressionChangedInternal);
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(131, 3);
      label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(45, 13);
      label1.TabIndex = 2;
      label1.Text = "of every";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new System.Drawing.Point(298, 3);
      label2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(47, 13);
      label2.TabIndex = 4;
      label2.Text = "month(s)";
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
      this.PeriodicInterval.Location = new System.Drawing.Point(60, 29);
      this.PeriodicInterval.Name = "PeriodicInterval";
      this.PeriodicInterval.Size = new System.Drawing.Size(65, 21);
      this.PeriodicInterval.TabIndex = 6;
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
      this.PeriodicDay.Location = new System.Drawing.Point(131, 29);
      this.PeriodicDay.Name = "PeriodicDay";
      this.PeriodicDay.Size = new System.Drawing.Size(90, 21);
      this.PeriodicDay.TabIndex = 7;
      this.PeriodicDay.SelectedIndexChanged += new System.EventHandler(this.FireExpressionChangedInternal);
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new System.Drawing.Point(227, 29);
      label4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
      label4.Name = "label4";
      label4.Size = new System.Drawing.Size(45, 13);
      label4.TabIndex = 8;
      label4.Text = "of every";
      // 
      // DayValue
      // 
      this.DayValue.AutoSize = true;
      this.DayValue.Dock = System.Windows.Forms.DockStyle.Top;
      this.DayValue.Location = new System.Drawing.Point(60, 3);
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
      this.DayValue.Size = new System.Drawing.Size(65, 20);
      this.DayValue.TabIndex = 1;
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
      this.PeriodicMonth.Enabled = false;
      this.PeriodicMonth.Location = new System.Drawing.Point(298, 29);
      this.PeriodicMonth.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
      this.PeriodicMonth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.PeriodicMonth.Name = "PeriodicMonth";
      this.PeriodicMonth.Size = new System.Drawing.Size(65, 20);
      this.PeriodicMonth.TabIndex = 9;
      this.PeriodicMonth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.PeriodicMonth.ValueChanged += new System.EventHandler(this.FireExpressionChangedInternal);
      // 
      // label5
      // 
      label5.AutoSize = true;
      label5.Location = new System.Drawing.Point(369, 29);
      label5.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
      label5.Name = "label5";
      label5.Size = new System.Drawing.Size(47, 13);
      label5.TabIndex = 10;
      label5.Text = "month(s)";
      // 
      // MonthlyCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(tableLayoutPanel1);
      this.Name = "MonthlyCtrl";
      this.Size = new System.Drawing.Size(464, 316);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.DayMonth)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.DayValue)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PeriodicMonth)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DateTimePicker MonthlyTimeValue;
    private System.Windows.Forms.RadioButton OptDay;
    private System.Windows.Forms.RadioButton OptPeriodic;
    private System.Windows.Forms.NumericUpDown DayValue;
    private System.Windows.Forms.NumericUpDown DayMonth;
    private System.Windows.Forms.ComboBox PeriodicInterval;
    private System.Windows.Forms.ComboBox PeriodicDay;
    private System.Windows.Forms.NumericUpDown PeriodicMonth;
  }
}
