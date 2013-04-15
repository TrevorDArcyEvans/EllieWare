//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace SerpentWare.Common
{
  partial class EditForm
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
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.StatusBarPanel statusBarPanel1;
      System.Windows.Forms.SplitContainer splitContainer1;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditForm));
      this.sBox = new Alsing.Windows.Forms.SyntaxBoxControl();
      this.sDoc = new Alsing.SourceCode.SyntaxDocument(this.components);
      this.Output = new System.Windows.Forms.TextBox();
      this.Status = new System.Windows.Forms.StatusBar();
      this.DebugContainer = new System.Windows.Forms.SplitContainer();
      this.PyGrid = new System.Windows.Forms.PropertyGrid();
      statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
      splitContainer1 = new System.Windows.Forms.SplitContainer();
      ((System.ComponentModel.ISupportInitialize)(statusBarPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(splitContainer1)).BeginInit();
      splitContainer1.Panel1.SuspendLayout();
      splitContainer1.Panel2.SuspendLayout();
      splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.DebugContainer)).BeginInit();
      this.DebugContainer.Panel1.SuspendLayout();
      this.DebugContainer.Panel2.SuspendLayout();
      this.DebugContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // statusBarPanel1
      // 
      statusBarPanel1.Name = "statusBarPanel1";
      statusBarPanel1.Width = 200;
      // 
      // splitContainer1
      // 
      splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      splitContainer1.Location = new System.Drawing.Point(0, 0);
      splitContainer1.Name = "splitContainer1";
      splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      splitContainer1.Panel1.Controls.Add(this.sBox);
      // 
      // splitContainer1.Panel2
      // 
      splitContainer1.Panel2.Controls.Add(this.Output);
      splitContainer1.Size = new System.Drawing.Size(850, 562);
      splitContainer1.SplitterDistance = 281;
      splitContainer1.TabIndex = 5;
      // 
      // sBox
      // 
      this.sBox.ActiveView = Alsing.Windows.Forms.ActiveView.BottomRight;
      this.sBox.AutoListPosition = null;
      this.sBox.AutoListSelectedText = "a123";
      this.sBox.AutoListVisible = false;
      this.sBox.BackColor = System.Drawing.Color.White;
      this.sBox.BorderStyle = Alsing.Windows.Forms.BorderStyle.None;
      this.sBox.ChildBorderColor = System.Drawing.Color.White;
      this.sBox.ChildBorderStyle = Alsing.Windows.Forms.BorderStyle.None;
      this.sBox.CopyAsRTF = false;
      this.sBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.sBox.Document = this.sDoc;
      this.sBox.FontName = "Courier new";
      this.sBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.sBox.InfoTipCount = 1;
      this.sBox.InfoTipPosition = null;
      this.sBox.InfoTipSelectedIndex = 1;
      this.sBox.InfoTipVisible = false;
      this.sBox.Location = new System.Drawing.Point(0, 0);
      this.sBox.LockCursorUpdate = false;
      this.sBox.Name = "sBox";
      this.sBox.ScopeIndicatorColor = System.Drawing.Color.Black;
      this.sBox.ShowScopeIndicator = false;
      this.sBox.Size = new System.Drawing.Size(850, 281);
      this.sBox.SmoothScroll = false;
      this.sBox.SplitviewH = -4;
      this.sBox.SplitviewV = -4;
      this.sBox.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(219)))), ((int)(((byte)(214)))));
      this.sBox.TabIndex = 4;
      this.sBox.Text = "syntaxBoxControl1";
      this.sBox.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
      // 
      // sDoc
      // 
      this.sDoc.Lines = new string[] {
        "abc"};
      this.sDoc.MaxUndoBufferSize = 1000;
      this.sDoc.Modified = false;
      this.sDoc.UndoStep = 0;
      this.sDoc.Change += new System.EventHandler(this.sDoc_Change);
      this.sDoc.ModifiedChanged += new System.EventHandler(this.sDoc_ModifiedChanged);
      // 
      // Output
      // 
      this.Output.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Output.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Output.Location = new System.Drawing.Point(0, 0);
      this.Output.Multiline = true;
      this.Output.Name = "Output";
      this.Output.ReadOnly = true;
      this.Output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.Output.Size = new System.Drawing.Size(850, 277);
      this.Output.TabIndex = 0;
      this.Output.WordWrap = false;
      // 
      // Status
      // 
      this.Status.Location = new System.Drawing.Point(0, 562);
      this.Status.Name = "Status";
      this.Status.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            statusBarPanel1});
      this.Status.ShowPanels = true;
      this.Status.Size = new System.Drawing.Size(850, 22);
      this.Status.TabIndex = 5;
      // 
      // DebugContainer
      // 
      this.DebugContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.DebugContainer.Location = new System.Drawing.Point(0, 0);
      this.DebugContainer.Name = "DebugContainer";
      // 
      // DebugContainer.Panel1
      // 
      this.DebugContainer.Panel1.Controls.Add(splitContainer1);
      // 
      // DebugContainer.Panel2
      // 
      this.DebugContainer.Panel2.Controls.Add(this.PyGrid);
      this.DebugContainer.Panel2Collapsed = true;
      this.DebugContainer.Size = new System.Drawing.Size(850, 562);
      this.DebugContainer.SplitterDistance = 445;
      this.DebugContainer.TabIndex = 6;
      // 
      // PyGrid
      // 
      this.PyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PyGrid.Location = new System.Drawing.Point(0, 0);
      this.PyGrid.Name = "PyGrid";
      this.PyGrid.Size = new System.Drawing.Size(96, 100);
      this.PyGrid.TabIndex = 0;
      // 
      // EditForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(850, 584);
      this.Controls.Add(this.DebugContainer);
      this.Controls.Add(this.Status);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "EditForm";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.Text = "EditForm";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditForm_FormClosing);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditForm_FormClosed);
      this.Load += new System.EventHandler(this.EditForm_Load);
      ((System.ComponentModel.ISupportInitialize)(statusBarPanel1)).EndInit();
      splitContainer1.Panel1.ResumeLayout(false);
      splitContainer1.Panel2.ResumeLayout(false);
      splitContainer1.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(splitContainer1)).EndInit();
      splitContainer1.ResumeLayout(false);
      this.DebugContainer.Panel1.ResumeLayout(false);
      this.DebugContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.DebugContainer)).EndInit();
      this.DebugContainer.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    public Alsing.Windows.Forms.SyntaxBoxControl sBox;
    public Alsing.SourceCode.SyntaxDocument sDoc;
    protected System.Windows.Forms.StatusBar Status;
    protected System.Windows.Forms.PropertyGrid PyGrid;
    protected System.Windows.Forms.SplitContainer DebugContainer;
    public System.Windows.Forms.TextBox Output;
  }
}