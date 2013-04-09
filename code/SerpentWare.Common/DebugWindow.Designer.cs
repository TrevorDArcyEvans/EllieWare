//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace SerpentWare.Common
{
  partial class DebugWindow
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebugWindow));
      this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuDebug_Run = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuDebug_StepInto = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuDebug_StepOver = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuDebug_StepOut = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuDebug_Reset = new System.Windows.Forms.ToolStripMenuItem();
      menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.DebugContainer.Panel2.SuspendLayout();
      this.DebugContainer.SuspendLayout();
      menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // sBox
      // 
      this.sBox.Size = new System.Drawing.Size(860, 324);
      // 
      // sDoc
      // 
      this.sDoc.Lines = new string[] {
        "abc"};
      // 
      // Status
      // 
      this.Status.Location = new System.Drawing.Point(0, 673);
      this.Status.Size = new System.Drawing.Size(860, 22);
      // 
      // DebugContainer
      // 
      this.DebugContainer.Location = new System.Drawing.Point(0, 24);
      this.DebugContainer.Size = new System.Drawing.Size(860, 649);
      // 
      // Output
      // 
      this.Output.Size = new System.Drawing.Size(860, 321);
      // 
      // menuStrip1
      // 
      menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugToolStripMenuItem});
      menuStrip1.Location = new System.Drawing.Point(0, 0);
      menuStrip1.Name = "menuStrip1";
      menuStrip1.Size = new System.Drawing.Size(860, 24);
      menuStrip1.TabIndex = 6;
      menuStrip1.Text = "menuStrip1";
      // 
      // debugToolStripMenuItem
      // 
      this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDebug_Run,
            this.toolStripSeparator1,
            this.mnuDebug_StepInto,
            this.mnuDebug_StepOver,
            this.mnuDebug_StepOut,
            this.toolStripSeparator2,
            this.mnuDebug_Reset});
      this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
      this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
      this.debugToolStripMenuItem.Text = "Debug";
      // 
      // mnuDebug_Run
      // 
      this.mnuDebug_Run.Image = global::SerpentWare.Common.Properties.Resources.DebugStart;
      this.mnuDebug_Run.Name = "mnuDebug_Run";
      this.mnuDebug_Run.ShortcutKeys = System.Windows.Forms.Keys.F5;
      this.mnuDebug_Run.Size = new System.Drawing.Size(177, 22);
      this.mnuDebug_Run.Text = "Run";
      this.mnuDebug_Run.Click += new System.EventHandler(this.mnuDebug_Run_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(174, 6);
      // 
      // mnuDebug_StepInto
      // 
      this.mnuDebug_StepInto.Image = global::SerpentWare.Common.Properties.Resources.DebugStepInto;
      this.mnuDebug_StepInto.Name = "mnuDebug_StepInto";
      this.mnuDebug_StepInto.ShortcutKeys = System.Windows.Forms.Keys.F11;
      this.mnuDebug_StepInto.Size = new System.Drawing.Size(177, 22);
      this.mnuDebug_StepInto.Text = "Step Into";
      this.mnuDebug_StepInto.Click += new System.EventHandler(this.mnuDebug_StepInto_Click);
      // 
      // mnuDebug_StepOver
      // 
      this.mnuDebug_StepOver.Image = global::SerpentWare.Common.Properties.Resources.DebugStepOver;
      this.mnuDebug_StepOver.Name = "mnuDebug_StepOver";
      this.mnuDebug_StepOver.ShortcutKeys = System.Windows.Forms.Keys.F10;
      this.mnuDebug_StepOver.Size = new System.Drawing.Size(177, 22);
      this.mnuDebug_StepOver.Text = "Step Over";
      this.mnuDebug_StepOver.Click += new System.EventHandler(this.mnuDebug_StepOver_Click);
      // 
      // mnuDebug_StepOut
      // 
      this.mnuDebug_StepOut.Image = global::SerpentWare.Common.Properties.Resources.DebugStepOut;
      this.mnuDebug_StepOut.Name = "mnuDebug_StepOut";
      this.mnuDebug_StepOut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F11)));
      this.mnuDebug_StepOut.Size = new System.Drawing.Size(177, 22);
      this.mnuDebug_StepOut.Text = "Step Out";
      this.mnuDebug_StepOut.Click += new System.EventHandler(this.mnuDebug_StepOut_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(174, 6);
      // 
      // mnuDebug_Reset
      // 
      this.mnuDebug_Reset.Image = global::SerpentWare.Common.Properties.Resources.DebugStop;
      this.mnuDebug_Reset.Name = "mnuDebug_Reset";
      this.mnuDebug_Reset.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F5)));
      this.mnuDebug_Reset.Size = new System.Drawing.Size(177, 22);
      this.mnuDebug_Reset.Text = "Reset";
      this.mnuDebug_Reset.Click += new System.EventHandler(this.mnuDebug_Reset_Click);
      // 
      // DebugWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(860, 695);
      this.Controls.Add(menuStrip1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = menuStrip1;
      this.Name = "DebugWindow";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "DebugWindow";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DebugWindow_FormClosing);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DebugWindow_FormClosed);
      this.Controls.SetChildIndex(this.Status, 0);
      this.Controls.SetChildIndex(menuStrip1, 0);
      this.Controls.SetChildIndex(this.DebugContainer, 0);
      this.DebugContainer.Panel2.ResumeLayout(false);
      this.DebugContainer.ResumeLayout(false);
      menuStrip1.ResumeLayout(false);
      menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem mnuDebug_Run;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem mnuDebug_StepInto;
    private System.Windows.Forms.ToolStripMenuItem mnuDebug_StepOver;
    private System.Windows.Forms.ToolStripMenuItem mnuDebug_StepOut;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem mnuDebug_Reset;
  }
}