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
      System.Windows.Forms.MenuStrip menuStrip1;
      System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
      System.Windows.Forms.ToolStripMenuItem CmdOpen;
      System.Windows.Forms.ToolStripMenuItem CmdSave;
      this.CronTab = new RobotWare.Cron.UserInterface.Cron();
      this.DlgSave = new System.Windows.Forms.SaveFileDialog();
      this.DlgOpen = new System.Windows.Forms.OpenFileDialog();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.Expression = new System.Windows.Forms.TextBox();
      menuStrip1 = new System.Windows.Forms.MenuStrip();
      fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      CmdOpen = new System.Windows.Forms.ToolStripMenuItem();
      CmdSave = new System.Windows.Forms.ToolStripMenuItem();
      menuStrip1.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            fileToolStripMenuItem});
      menuStrip1.Location = new System.Drawing.Point(0, 0);
      menuStrip1.Name = "menuStrip1";
      menuStrip1.Size = new System.Drawing.Size(491, 24);
      menuStrip1.TabIndex = 1;
      menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            CmdOpen,
            CmdSave});
      fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      fileToolStripMenuItem.Text = "&File";
      // 
      // CmdOpen
      // 
      CmdOpen.Name = "CmdOpen";
      CmdOpen.Size = new System.Drawing.Size(112, 22);
      CmdOpen.Text = "&Open...";
      CmdOpen.Click += new System.EventHandler(this.CmdOpen_Click);
      // 
      // CmdSave
      // 
      CmdSave.Name = "CmdSave";
      CmdSave.Size = new System.Drawing.Size(112, 22);
      CmdSave.Text = "&Save...";
      CmdSave.Click += new System.EventHandler(this.CmdSave_Click);
      // 
      // CronTab
      // 
      this.CronTab.Dock = System.Windows.Forms.DockStyle.Fill;
      this.CronTab.Location = new System.Drawing.Point(3, 3);
      this.CronTab.Name = "CronTab";
      this.CronTab.Size = new System.Drawing.Size(485, 309);
      this.CronTab.TabIndex = 0;
      this.CronTab.ExpressionChanged += new System.EventHandler(this.CronTab_ExpressionChanged);
      // 
      // DlgSave
      // 
      this.DlgSave.FileName = "Test01.xml";
      this.DlgSave.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
      // 
      // DlgOpen
      // 
      this.DlgOpen.FileName = "Test01.xml";
      this.DlgOpen.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.CronTab, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.Expression, 0, 1);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.Size = new System.Drawing.Size(491, 341);
      this.tableLayoutPanel1.TabIndex = 2;
      // 
      // Expression
      // 
      this.Expression.Dock = System.Windows.Forms.DockStyle.Top;
      this.Expression.Location = new System.Drawing.Point(3, 318);
      this.Expression.Name = "Expression";
      this.Expression.ReadOnly = true;
      this.Expression.Size = new System.Drawing.Size(485, 20);
      this.Expression.TabIndex = 1;
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(491, 365);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Controls.Add(menuStrip1);
      this.MainMenuStrip = menuStrip1;
      this.Name = "Main";
      this.Text = "Cron Builder Tester";
      menuStrip1.ResumeLayout(false);
      menuStrip1.PerformLayout();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Cron CronTab;
    private System.Windows.Forms.SaveFileDialog DlgSave;
    private System.Windows.Forms.OpenFileDialog DlgOpen;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.TextBox Expression;
  }
}

