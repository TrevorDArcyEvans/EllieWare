//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace RobotWare.Quartz.Calendar.UserInterface
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
      this.DaysExcluded = new System.Windows.Forms.CheckedListBox();
      this.SuspendLayout();
      // 
      // DaysOfWeek
      // 
      this.DaysExcluded.Dock = System.Windows.Forms.DockStyle.Fill;
      this.DaysExcluded.FormattingEnabled = true;
      this.DaysExcluded.Location = new System.Drawing.Point(0, 0);
      this.DaysExcluded.Name = "DaysOfWeek";
      this.DaysExcluded.Size = new System.Drawing.Size(345, 293);
      this.DaysExcluded.TabIndex = 0;
      this.DaysExcluded.SelectedIndexChanged += new System.EventHandler(this.FireCalendarChangedInternal);
      this.DaysExcluded.SelectedValueChanged += new System.EventHandler(this.FireCalendarChangedInternal);
      // 
      // WeeklyCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.DaysExcluded);
      this.Name = "WeeklyCtrl";
      this.Size = new System.Drawing.Size(345, 293);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.CheckedListBox DaysExcluded;
  }
}
