//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace RobotWare.Quartz.Calendar.UserInterface
{
  partial class CalendarCtrl
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
      this.Calendars = new System.Windows.Forms.TabControl();
      this.DailyTab = new System.Windows.Forms.TabPage();
      this.Daily = new RobotWare.Quartz.Calendar.UserInterface.DailyCtrl();
      this.WeeklyTab = new System.Windows.Forms.TabPage();
      this.Weekly = new RobotWare.Quartz.Calendar.UserInterface.WeeklyCtrl();
      this.MonthlyTab = new System.Windows.Forms.TabPage();
      this.Monthly = new RobotWare.Quartz.Calendar.UserInterface.MonthlyCtrl();
      this.AnnualTab = new System.Windows.Forms.TabPage();
      this.Annual = new RobotWare.Quartz.Calendar.UserInterface.AnnualCtrl();
      this.Calendars.SuspendLayout();
      this.DailyTab.SuspendLayout();
      this.WeeklyTab.SuspendLayout();
      this.MonthlyTab.SuspendLayout();
      this.AnnualTab.SuspendLayout();
      this.SuspendLayout();
      // 
      // Calendars
      // 
      this.Calendars.Controls.Add(this.DailyTab);
      this.Calendars.Controls.Add(this.WeeklyTab);
      this.Calendars.Controls.Add(this.MonthlyTab);
      this.Calendars.Controls.Add(this.AnnualTab);
      this.Calendars.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Calendars.Location = new System.Drawing.Point(0, 0);
      this.Calendars.Name = "Calendars";
      this.Calendars.SelectedIndex = 0;
      this.Calendars.Size = new System.Drawing.Size(568, 367);
      this.Calendars.TabIndex = 0;
      this.Calendars.SelectedIndexChanged += new System.EventHandler(this.FireCalendarChangedInternal);
      // 
      // DailyTab
      // 
      this.DailyTab.Controls.Add(this.Daily);
      this.DailyTab.Location = new System.Drawing.Point(4, 25);
      this.DailyTab.Name = "DailyTab";
      this.DailyTab.Padding = new System.Windows.Forms.Padding(3);
      this.DailyTab.Size = new System.Drawing.Size(560, 338);
      this.DailyTab.TabIndex = 0;
      this.DailyTab.Text = "Daily";
      this.DailyTab.UseVisualStyleBackColor = true;
      // 
      // Daily
      // 
      this.Daily.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Daily.Location = new System.Drawing.Point(3, 3);
      this.Daily.Name = "Daily";
      this.Daily.Size = new System.Drawing.Size(554, 332);
      this.Daily.TabIndex = 0;
      this.Daily.CalendarChanged += new System.EventHandler(this.FireCalendarChangedInternal);
      // 
      // WeeklyTab
      // 
      this.WeeklyTab.Controls.Add(this.Weekly);
      this.WeeklyTab.Location = new System.Drawing.Point(4, 25);
      this.WeeklyTab.Name = "WeeklyTab";
      this.WeeklyTab.Padding = new System.Windows.Forms.Padding(3);
      this.WeeklyTab.Size = new System.Drawing.Size(560, 338);
      this.WeeklyTab.TabIndex = 1;
      this.WeeklyTab.Text = "Weekly";
      this.WeeklyTab.UseVisualStyleBackColor = true;
      // 
      // Weekly
      // 
      this.Weekly.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Weekly.Location = new System.Drawing.Point(3, 3);
      this.Weekly.Name = "Weekly";
      this.Weekly.Size = new System.Drawing.Size(554, 332);
      this.Weekly.TabIndex = 0;
      this.Weekly.CalendarChanged += new System.EventHandler(this.FireCalendarChangedInternal);
      // 
      // MonthlyTab
      // 
      this.MonthlyTab.Controls.Add(this.Monthly);
      this.MonthlyTab.Location = new System.Drawing.Point(4, 25);
      this.MonthlyTab.Name = "MonthlyTab";
      this.MonthlyTab.Padding = new System.Windows.Forms.Padding(3);
      this.MonthlyTab.Size = new System.Drawing.Size(560, 338);
      this.MonthlyTab.TabIndex = 2;
      this.MonthlyTab.Text = "Monthly";
      this.MonthlyTab.UseVisualStyleBackColor = true;
      // 
      // Monthly
      // 
      this.Monthly.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Monthly.Location = new System.Drawing.Point(3, 3);
      this.Monthly.Name = "Monthly";
      this.Monthly.Size = new System.Drawing.Size(554, 332);
      this.Monthly.TabIndex = 0;
      this.Monthly.CalendarChanged += new System.EventHandler(this.FireCalendarChangedInternal);
      // 
      // AnnualTab
      // 
      this.AnnualTab.Controls.Add(this.Annual);
      this.AnnualTab.Location = new System.Drawing.Point(4, 25);
      this.AnnualTab.Name = "AnnualTab";
      this.AnnualTab.Padding = new System.Windows.Forms.Padding(3);
      this.AnnualTab.Size = new System.Drawing.Size(560, 338);
      this.AnnualTab.TabIndex = 3;
      this.AnnualTab.Text = "Annual";
      this.AnnualTab.UseVisualStyleBackColor = true;
      // 
      // Annual
      // 
      this.Annual.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Annual.Location = new System.Drawing.Point(3, 3);
      this.Annual.Name = "Annual";
      this.Annual.Size = new System.Drawing.Size(554, 332);
      this.Annual.TabIndex = 0;
      this.Annual.CalendarChanged += new System.EventHandler(this.FireCalendarChangedInternal);
      // 
      // CalendarCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.Calendars);
      this.Name = "CalendarCtrl";
      this.Size = new System.Drawing.Size(568, 367);
      this.Calendars.ResumeLayout(false);
      this.DailyTab.ResumeLayout(false);
      this.WeeklyTab.ResumeLayout(false);
      this.MonthlyTab.ResumeLayout(false);
      this.AnnualTab.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl Calendars;
    private System.Windows.Forms.TabPage DailyTab;
    private DailyCtrl Daily;
    private System.Windows.Forms.TabPage WeeklyTab;
    private WeeklyCtrl Weekly;
    private System.Windows.Forms.TabPage MonthlyTab;
    private MonthlyCtrl Monthly;
    private System.Windows.Forms.TabPage AnnualTab;
    private AnnualCtrl Annual;
  }
}
