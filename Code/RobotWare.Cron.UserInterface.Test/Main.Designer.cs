//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace RobotWare.Cron.UserInterface.Test
{
  partial class Main
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.cron1 = new RobotWare.Cron.UserInterface.Cron();
      this.SuspendLayout();
      // 
      // cron1
      // 
      this.cron1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cron1.Location = new System.Drawing.Point(0, 0);
      this.cron1.Name = "cron1";
      this.cron1.Size = new System.Drawing.Size(491, 365);
      this.cron1.TabIndex = 0;
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(491, 365);
      this.Controls.Add(this.cron1);
      this.Name = "Main";
      this.Text = "Cron Builder Tester";
      this.ResumeLayout(false);

    }

    #endregion

    private Cron cron1;
  }
}

