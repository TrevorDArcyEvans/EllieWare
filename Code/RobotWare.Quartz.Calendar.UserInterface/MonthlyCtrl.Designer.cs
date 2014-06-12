//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace RobotWare.Quartz.Calendar.UserInterface
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
      this.DaysExcluded = new System.Windows.Forms.CheckedListBox();
      this.SuspendLayout();
      // 
      // DaysExcluded
      // 
      this.DaysExcluded.Dock = System.Windows.Forms.DockStyle.Fill;
      this.DaysExcluded.FormattingEnabled = true;
      this.DaysExcluded.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
      this.DaysExcluded.Location = new System.Drawing.Point(0, 0);
      this.DaysExcluded.Name = "DaysExcluded";
      this.DaysExcluded.Size = new System.Drawing.Size(547, 405);
      this.DaysExcluded.TabIndex = 0;
      this.DaysExcluded.SelectedIndexChanged += new System.EventHandler(this.FireCalendarChangedInternal);
      this.DaysExcluded.SelectedValueChanged += new System.EventHandler(this.FireCalendarChangedInternal);
      // 
      // MonthlyCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.DaysExcluded);
      this.Name = "MonthlyCtrl";
      this.Size = new System.Drawing.Size(547, 405);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.CheckedListBox DaysExcluded;
  }
}
