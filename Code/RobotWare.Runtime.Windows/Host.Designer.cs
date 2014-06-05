//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace RobotWare.Runtime.Windows
{
  sealed partial class Host
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
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Host));
      this.mLogWindow = new EllieWare.Common.LogWindow();
      this.CmdRun = new System.Windows.Forms.Button();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      tableLayoutPanel1.Controls.Add(this.mLogWindow, 0, 0);
      tableLayoutPanel1.Controls.Add(this.CmdRun, 1, 1);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 2;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(484, 347);
      tableLayoutPanel1.TabIndex = 6;
      // 
      // mLogWindow
      // 
      tableLayoutPanel1.SetColumnSpan(this.mLogWindow, 3);
      this.mLogWindow.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mLogWindow.Location = new System.Drawing.Point(3, 3);
      this.mLogWindow.Name = "mLogWindow";
      this.mLogWindow.Size = new System.Drawing.Size(478, 295);
      this.mLogWindow.TabIndex = 0;
      // 
      // CmdRun
      // 
      this.CmdRun.Enabled = false;
      this.CmdRun.Image = global::RobotWare.Runtime.Windows.Properties.Resources.gear_run_32x32;
      this.CmdRun.Location = new System.Drawing.Point(222, 304);
      this.CmdRun.Name = "CmdRun";
      this.CmdRun.Size = new System.Drawing.Size(40, 40);
      this.CmdRun.TabIndex = 5;
      this.CmdRun.UseVisualStyleBackColor = true;
      this.CmdRun.Click += new System.EventHandler(this.CmdRun_Click);
      // 
      // Host
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(484, 347);
      this.Controls.Add(tableLayoutPanel1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Host";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.Load += new System.EventHandler(this.Host_Load);
      tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private EllieWare.Common.LogWindow mLogWindow;
    private System.Windows.Forms.Button CmdRun;
  }
}

