//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace RobotWare.Quartz.Calendar.UserInterface.Test
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
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      this.CalCtrl = new RobotWare.Quartz.Calendar.UserInterface.CalendarCtrl();
      this.Description = new System.Windows.Forms.TextBox();
      this.CmdViewOnly = new System.Windows.Forms.Button();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 2;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.Controls.Add(this.CalCtrl, 0, 0);
      tableLayoutPanel1.Controls.Add(this.Description, 0, 1);
      tableLayoutPanel1.Controls.Add(this.CmdViewOnly, 1, 1);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 2;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(493, 346);
      tableLayoutPanel1.TabIndex = 1;
      // 
      // CalCtrl
      // 
      tableLayoutPanel1.SetColumnSpan(this.CalCtrl, 2);
      this.CalCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.CalCtrl.Location = new System.Drawing.Point(3, 3);
      this.CalCtrl.Name = "CalCtrl";
      this.CalCtrl.Size = new System.Drawing.Size(487, 307);
      this.CalCtrl.TabIndex = 0;
      this.CalCtrl.CalendarChanged += new System.EventHandler(this.CalCtrl_CalendarChanged);
      // 
      // Description
      // 
      this.Description.Dock = System.Windows.Forms.DockStyle.Top;
      this.Description.Location = new System.Drawing.Point(3, 316);
      this.Description.Name = "Description";
      this.Description.ReadOnly = true;
      this.Description.Size = new System.Drawing.Size(405, 22);
      this.Description.TabIndex = 1;
      // 
      // CmdViewOnly
      // 
      this.CmdViewOnly.AutoSize = true;
      this.CmdViewOnly.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.CmdViewOnly.Location = new System.Drawing.Point(414, 316);
      this.CmdViewOnly.Name = "CmdViewOnly";
      this.CmdViewOnly.Size = new System.Drawing.Size(76, 27);
      this.CmdViewOnly.TabIndex = 2;
      this.CmdViewOnly.Text = "ViewOnly";
      this.CmdViewOnly.UseVisualStyleBackColor = true;
      this.CmdViewOnly.Click += new System.EventHandler(this.CmdViewOnly_Click);
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(493, 346);
      this.Controls.Add(tableLayoutPanel1);
      this.Name = "Main";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.Text = "Calendar Selector Tester";
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private CalendarCtrl CalCtrl;
    private System.Windows.Forms.TextBox Description;
    private System.Windows.Forms.Button CmdViewOnly;
  }
}

