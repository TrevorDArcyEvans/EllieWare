//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace RobotWare.Runtime.Server.Manager
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
      System.Windows.Forms.ToolStrip toolStrip1;
      System.Windows.Forms.StatusStrip statusStrip1;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
      this.ServerConnectStatus = new System.Windows.Forms.ToolStripStatusLabel();
      this.StripStatusLabel_Job_Groups = new System.Windows.Forms.ToolStripStatusLabel();
      this.StripStatusLabel_Jobs_Refresh_date = new System.Windows.Forms.ToolStripStatusLabel();
      toolStrip1 = new System.Windows.Forms.ToolStrip();
      statusStrip1 = new System.Windows.Forms.StatusStrip();
      statusStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolStrip1
      // 
      toolStrip1.Location = new System.Drawing.Point(0, 0);
      toolStrip1.Name = "toolStrip1";
      toolStrip1.Size = new System.Drawing.Size(547, 25);
      toolStrip1.TabIndex = 0;
      toolStrip1.Text = "toolStrip1";
      // 
      // statusStrip1
      // 
      statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ServerConnectStatus,
            this.StripStatusLabel_Job_Groups,
            this.StripStatusLabel_Jobs_Refresh_date});
      statusStrip1.Location = new System.Drawing.Point(0, 337);
      statusStrip1.Name = "statusStrip1";
      statusStrip1.Size = new System.Drawing.Size(547, 22);
      statusStrip1.TabIndex = 2;
      statusStrip1.Text = "statusStrip1";
      // 
      // ServerConnectStatus
      // 
      this.ServerConnectStatus.Name = "ServerConnectStatus";
      this.ServerConnectStatus.Size = new System.Drawing.Size(86, 17);
      this.ServerConnectStatus.Text = "Not connected";
      // 
      // StripStatusLabel_Job_Groups
      // 
      this.StripStatusLabel_Job_Groups.BackColor = System.Drawing.Color.LightCyan;
      this.StripStatusLabel_Job_Groups.Name = "StripStatusLabel_Job_Groups";
      this.StripStatusLabel_Job_Groups.Size = new System.Drawing.Size(157, 17);
      this.StripStatusLabel_Job_Groups.Text = "StripStatusLabel_Job_Groups";
      this.StripStatusLabel_Job_Groups.ToolTipText = "Last Refresh of Job Groups";
      // 
      // StripStatusLabel_Jobs_Refresh_date
      // 
      this.StripStatusLabel_Jobs_Refresh_date.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.StripStatusLabel_Jobs_Refresh_date.Name = "StripStatusLabel_Jobs_Refresh_date";
      this.StripStatusLabel_Jobs_Refresh_date.Size = new System.Drawing.Size(191, 17);
      this.StripStatusLabel_Jobs_Refresh_date.Text = "StripStatusLabel_Jobs_Refresh_date";
      this.StripStatusLabel_Jobs_Refresh_date.ToolTipText = "Last Refresh Date of Running Jobs";
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(547, 359);
      this.Controls.Add(statusStrip1);
      this.Controls.Add(toolStrip1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Main";
      this.Text = "Form1";
      statusStrip1.ResumeLayout(false);
      statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStripStatusLabel ServerConnectStatus;
    private System.Windows.Forms.ToolStripStatusLabel StripStatusLabel_Job_Groups;
    private System.Windows.Forms.ToolStripStatusLabel StripStatusLabel_Jobs_Refresh_date;
  }
}

