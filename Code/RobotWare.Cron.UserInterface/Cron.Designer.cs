//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace RobotWare.Cron.UserInterface
{
  partial class Cron
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
      this.CronTab = new System.Windows.Forms.TabControl();
      this.Minutes = new System.Windows.Forms.TabPage();
      this.MinutesValue = new RobotWare.Cron.UserInterface.MinutesCtrl();
      this.Hourly = new System.Windows.Forms.TabPage();
      this.HourlyValue = new RobotWare.Cron.UserInterface.HourlyCtrl();
      this.Daily = new System.Windows.Forms.TabPage();
      this.DailyValue = new RobotWare.Cron.UserInterface.DailyCtrl();
      this.Weekly = new System.Windows.Forms.TabPage();
      this.WeeklyValue = new RobotWare.Cron.UserInterface.WeeklyCtrl();
      this.Monthly = new System.Windows.Forms.TabPage();
      this.MonthlyValue = new RobotWare.Cron.UserInterface.MonthlyCtrl();
      this.Yearly = new System.Windows.Forms.TabPage();
      this.YearlyValue = new RobotWare.Cron.UserInterface.YearlyCtrl();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.Description = new System.Windows.Forms.TextBox();
      this.CronTab.SuspendLayout();
      this.Minutes.SuspendLayout();
      this.Hourly.SuspendLayout();
      this.Daily.SuspendLayout();
      this.Weekly.SuspendLayout();
      this.Monthly.SuspendLayout();
      this.Yearly.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // CronTab
      // 
      this.CronTab.Controls.Add(this.Minutes);
      this.CronTab.Controls.Add(this.Hourly);
      this.CronTab.Controls.Add(this.Daily);
      this.CronTab.Controls.Add(this.Weekly);
      this.CronTab.Controls.Add(this.Monthly);
      this.CronTab.Controls.Add(this.Yearly);
      this.CronTab.Dock = System.Windows.Forms.DockStyle.Fill;
      this.CronTab.Location = new System.Drawing.Point(3, 3);
      this.CronTab.Name = "CronTab";
      this.CronTab.SelectedIndex = 0;
      this.CronTab.Size = new System.Drawing.Size(491, 208);
      this.CronTab.TabIndex = 0;
      this.CronTab.SelectedIndexChanged += new System.EventHandler(this.FireExpressionChangedInternal);
      // 
      // Minutes
      // 
      this.Minutes.Controls.Add(this.MinutesValue);
      this.Minutes.Location = new System.Drawing.Point(4, 22);
      this.Minutes.Name = "Minutes";
      this.Minutes.Padding = new System.Windows.Forms.Padding(3);
      this.Minutes.Size = new System.Drawing.Size(483, 182);
      this.Minutes.TabIndex = 0;
      this.Minutes.Text = "Minutes";
      this.Minutes.UseVisualStyleBackColor = true;
      // 
      // MinutesValue
      // 
      this.MinutesValue.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MinutesValue.Location = new System.Drawing.Point(3, 3);
      this.MinutesValue.Name = "MinutesValue";
      this.MinutesValue.Size = new System.Drawing.Size(477, 176);
      this.MinutesValue.TabIndex = 0;
      this.MinutesValue.ExpressionChanged += new System.EventHandler(this.FireExpressionChangedInternal);
      // 
      // Hourly
      // 
      this.Hourly.Controls.Add(this.HourlyValue);
      this.Hourly.Location = new System.Drawing.Point(4, 22);
      this.Hourly.Name = "Hourly";
      this.Hourly.Padding = new System.Windows.Forms.Padding(3);
      this.Hourly.Size = new System.Drawing.Size(483, 182);
      this.Hourly.TabIndex = 1;
      this.Hourly.Text = "Hourly";
      this.Hourly.UseVisualStyleBackColor = true;
      // 
      // HourlyValue
      // 
      this.HourlyValue.Dock = System.Windows.Forms.DockStyle.Fill;
      this.HourlyValue.Location = new System.Drawing.Point(3, 3);
      this.HourlyValue.Name = "HourlyValue";
      this.HourlyValue.Size = new System.Drawing.Size(477, 176);
      this.HourlyValue.TabIndex = 0;
      this.HourlyValue.ExpressionChanged += new System.EventHandler(this.FireExpressionChangedInternal);
      // 
      // Daily
      // 
      this.Daily.Controls.Add(this.DailyValue);
      this.Daily.Location = new System.Drawing.Point(4, 22);
      this.Daily.Name = "Daily";
      this.Daily.Padding = new System.Windows.Forms.Padding(3);
      this.Daily.Size = new System.Drawing.Size(483, 182);
      this.Daily.TabIndex = 2;
      this.Daily.Text = "Daily";
      this.Daily.UseVisualStyleBackColor = true;
      // 
      // DailyValue
      // 
      this.DailyValue.Dock = System.Windows.Forms.DockStyle.Fill;
      this.DailyValue.Location = new System.Drawing.Point(3, 3);
      this.DailyValue.Name = "DailyValue";
      this.DailyValue.Size = new System.Drawing.Size(477, 176);
      this.DailyValue.TabIndex = 0;
      this.DailyValue.ExpressionChanged += new System.EventHandler(this.FireExpressionChangedInternal);
      // 
      // Weekly
      // 
      this.Weekly.Controls.Add(this.WeeklyValue);
      this.Weekly.Location = new System.Drawing.Point(4, 22);
      this.Weekly.Name = "Weekly";
      this.Weekly.Padding = new System.Windows.Forms.Padding(3);
      this.Weekly.Size = new System.Drawing.Size(483, 182);
      this.Weekly.TabIndex = 3;
      this.Weekly.Text = "Weekly";
      this.Weekly.UseVisualStyleBackColor = true;
      // 
      // WeeklyValue
      // 
      this.WeeklyValue.Dock = System.Windows.Forms.DockStyle.Fill;
      this.WeeklyValue.Location = new System.Drawing.Point(3, 3);
      this.WeeklyValue.Name = "WeeklyValue";
      this.WeeklyValue.Size = new System.Drawing.Size(477, 176);
      this.WeeklyValue.TabIndex = 0;
      this.WeeklyValue.ExpressionChanged += new System.EventHandler(this.FireExpressionChangedInternal);
      // 
      // Monthly
      // 
      this.Monthly.Controls.Add(this.MonthlyValue);
      this.Monthly.Location = new System.Drawing.Point(4, 22);
      this.Monthly.Name = "Monthly";
      this.Monthly.Padding = new System.Windows.Forms.Padding(3);
      this.Monthly.Size = new System.Drawing.Size(483, 182);
      this.Monthly.TabIndex = 4;
      this.Monthly.Text = "Monthly";
      this.Monthly.UseVisualStyleBackColor = true;
      // 
      // MonthlyValue
      // 
      this.MonthlyValue.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MonthlyValue.Location = new System.Drawing.Point(3, 3);
      this.MonthlyValue.Name = "MonthlyValue";
      this.MonthlyValue.Size = new System.Drawing.Size(477, 176);
      this.MonthlyValue.TabIndex = 0;
      this.MonthlyValue.ExpressionChanged += new System.EventHandler(this.FireExpressionChangedInternal);
      // 
      // Yearly
      // 
      this.Yearly.Controls.Add(this.YearlyValue);
      this.Yearly.Location = new System.Drawing.Point(4, 22);
      this.Yearly.Name = "Yearly";
      this.Yearly.Padding = new System.Windows.Forms.Padding(3);
      this.Yearly.Size = new System.Drawing.Size(483, 182);
      this.Yearly.TabIndex = 5;
      this.Yearly.Text = "Yearly";
      this.Yearly.UseVisualStyleBackColor = true;
      // 
      // YearlyValue
      // 
      this.YearlyValue.Dock = System.Windows.Forms.DockStyle.Fill;
      this.YearlyValue.Location = new System.Drawing.Point(3, 3);
      this.YearlyValue.Name = "YearlyValue";
      this.YearlyValue.Size = new System.Drawing.Size(477, 176);
      this.YearlyValue.TabIndex = 0;
      this.YearlyValue.ExpressionChanged += new System.EventHandler(this.FireExpressionChangedInternal);
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.CronTab, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.Description, 0, 1);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.Size = new System.Drawing.Size(497, 240);
      this.tableLayoutPanel1.TabIndex = 1;
      // 
      // Description
      // 
      this.Description.Dock = System.Windows.Forms.DockStyle.Top;
      this.Description.Location = new System.Drawing.Point(3, 217);
      this.Description.Name = "Description";
      this.Description.ReadOnly = true;
      this.Description.Size = new System.Drawing.Size(491, 20);
      this.Description.TabIndex = 1;
      // 
      // Cron
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "Cron";
      this.Size = new System.Drawing.Size(497, 240);
      this.Load += new System.EventHandler(this.FireExpressionChangedInternal);
      this.CronTab.ResumeLayout(false);
      this.Minutes.ResumeLayout(false);
      this.Hourly.ResumeLayout(false);
      this.Daily.ResumeLayout(false);
      this.Weekly.ResumeLayout(false);
      this.Monthly.ResumeLayout(false);
      this.Yearly.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabPage Minutes;
    private System.Windows.Forms.TabPage Hourly;
    private System.Windows.Forms.TextBox Description;
    private MinutesCtrl MinutesValue;
    private HourlyCtrl HourlyValue;
    private System.Windows.Forms.TabPage Daily;
    private DailyCtrl DailyValue;
    private System.Windows.Forms.TabPage Weekly;
    private System.Windows.Forms.TabPage Monthly;
    private System.Windows.Forms.TabPage Yearly;
    private WeeklyCtrl WeeklyValue;
    private MonthlyCtrl MonthlyValue;
    private YearlyCtrl YearlyValue;
    private System.Windows.Forms.TabControl CronTab;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
  }
}
