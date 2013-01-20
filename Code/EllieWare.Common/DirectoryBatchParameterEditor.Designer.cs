//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace EllieWare.Common
{
  partial class DirectoryBatchParameterEditor
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
      System.Windows.Forms.Label label1;
      System.Windows.Forms.Label label2;
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      System.Windows.Forms.Button CmdOK;
      System.Windows.Forms.Button CmdCancel;
      System.Windows.Forms.Label label3;
      System.Windows.Forms.Label label4;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectoryBatchParameterEditor));
      this.mDirectoryPath = new System.Windows.Forms.TextBox();
      this.CmdBrowse = new System.Windows.Forms.Button();
      this.mPreview = new System.Windows.Forms.TextBox();
      this.mFileMask = new System.Windows.Forms.ComboBox();
      this.mDisplayName = new System.Windows.Forms.TextBox();
      this.SourceDirectorySelector = new System.Windows.Forms.FolderBrowserDialog();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      label1 = new System.Windows.Forms.Label();
      label2 = new System.Windows.Forms.Label();
      tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      CmdOK = new System.Windows.Forms.Button();
      CmdCancel = new System.Windows.Forms.Button();
      label3 = new System.Windows.Forms.Label();
      label4 = new System.Windows.Forms.Label();
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      tableLayoutPanel1.AutoSize = true;
      tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      tableLayoutPanel1.ColumnCount = 4;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.Controls.Add(label1, 0, 1);
      tableLayoutPanel1.Controls.Add(this.mDirectoryPath, 1, 1);
      tableLayoutPanel1.Controls.Add(this.CmdBrowse, 3, 1);
      tableLayoutPanel1.Controls.Add(this.mPreview, 1, 3);
      tableLayoutPanel1.Controls.Add(label2, 0, 3);
      tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 2, 4);
      tableLayoutPanel1.Controls.Add(label3, 0, 2);
      tableLayoutPanel1.Controls.Add(this.mFileMask, 1, 2);
      tableLayoutPanel1.Controls.Add(this.mDisplayName, 1, 0);
      tableLayoutPanel1.Controls.Add(label4, 0, 0);
      tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 5;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(515, 351);
      tableLayoutPanel1.TabIndex = 1;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(3, 32);
      label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(52, 13);
      label1.TabIndex = 2;
      label1.Text = "Directory:";
      // 
      // mDirectoryPath
      // 
      tableLayoutPanel1.SetColumnSpan(this.mDirectoryPath, 2);
      this.mDirectoryPath.Dock = System.Windows.Forms.DockStyle.Top;
      this.mDirectoryPath.Location = new System.Drawing.Point(84, 29);
      this.mDirectoryPath.Name = "mDirectoryPath";
      this.mDirectoryPath.Size = new System.Drawing.Size(396, 20);
      this.mDirectoryPath.TabIndex = 3;
      this.mDirectoryPath.TextChanged += new System.EventHandler(this.DirectoryPath_TextChanged);
      // 
      // CmdBrowse
      // 
      this.CmdBrowse.AutoSize = true;
      this.CmdBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.CmdBrowse.Location = new System.Drawing.Point(486, 29);
      this.CmdBrowse.Name = "CmdBrowse";
      this.CmdBrowse.Size = new System.Drawing.Size(26, 23);
      this.CmdBrowse.TabIndex = 4;
      this.CmdBrowse.Text = "...";
      this.CmdBrowse.UseVisualStyleBackColor = true;
      this.CmdBrowse.Click += new System.EventHandler(this.CmdBrowse_Click);
      // 
      // mPreview
      // 
      tableLayoutPanel1.SetColumnSpan(this.mPreview, 3);
      this.mPreview.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mPreview.Location = new System.Drawing.Point(84, 85);
      this.mPreview.Multiline = true;
      this.mPreview.Name = "mPreview";
      this.mPreview.ReadOnly = true;
      this.mPreview.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.mPreview.Size = new System.Drawing.Size(428, 228);
      this.mPreview.TabIndex = 6;
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new System.Drawing.Point(3, 88);
      label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(45, 13);
      label2.TabIndex = 5;
      label2.Text = "Preview";
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.AutoSize = true;
      tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      tableLayoutPanel2.ColumnCount = 2;
      tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      tableLayoutPanel2.Controls.Add(CmdOK, 0, 0);
      tableLayoutPanel2.Controls.Add(CmdCancel, 1, 0);
      tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
      tableLayoutPanel2.Location = new System.Drawing.Point(318, 319);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 1;
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      tableLayoutPanel2.Size = new System.Drawing.Size(162, 29);
      tableLayoutPanel2.TabIndex = 3;
      // 
      // CmdOK
      // 
      CmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      CmdOK.Location = new System.Drawing.Point(3, 3);
      CmdOK.Name = "CmdOK";
      CmdOK.Size = new System.Drawing.Size(75, 23);
      CmdOK.TabIndex = 0;
      CmdOK.Text = "OK";
      CmdOK.UseVisualStyleBackColor = true;
      // 
      // CmdCancel
      // 
      CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      CmdCancel.Location = new System.Drawing.Point(84, 3);
      CmdCancel.Name = "CmdCancel";
      CmdCancel.Size = new System.Drawing.Size(75, 23);
      CmdCancel.TabIndex = 1;
      CmdCancel.Text = "Cancel";
      CmdCancel.UseVisualStyleBackColor = true;
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new System.Drawing.Point(3, 61);
      label3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(55, 13);
      label3.TabIndex = 6;
      label3.Text = "File Mask:";
      // 
      // mFileMask
      // 
      tableLayoutPanel1.SetColumnSpan(this.mFileMask, 2);
      this.mFileMask.Dock = System.Windows.Forms.DockStyle.Top;
      this.mFileMask.FormattingEnabled = true;
      this.mFileMask.Items.AddRange(new object[] {
            "*.*",
            "*.txt"});
      this.mFileMask.Location = new System.Drawing.Point(84, 58);
      this.mFileMask.Name = "mFileMask";
      this.mFileMask.Size = new System.Drawing.Size(396, 21);
      this.mFileMask.TabIndex = 7;
      this.mFileMask.TextChanged += new System.EventHandler(this.FileMask_TextChanged);
      // 
      // mDisplayName
      // 
      tableLayoutPanel1.SetColumnSpan(this.mDisplayName, 2);
      this.mDisplayName.Dock = System.Windows.Forms.DockStyle.Top;
      this.mDisplayName.Location = new System.Drawing.Point(84, 3);
      this.mDisplayName.Name = "mDisplayName";
      this.mDisplayName.Size = new System.Drawing.Size(396, 20);
      this.mDisplayName.TabIndex = 1;
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new System.Drawing.Point(3, 6);
      label4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label4.Name = "label4";
      label4.Size = new System.Drawing.Size(75, 13);
      label4.TabIndex = 0;
      label4.Text = "Display Name:";
      // 
      // DirectoryBatchParameterEditor
      // 
      this.AcceptButton = CmdOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = CmdCancel;
      this.ClientSize = new System.Drawing.Size(539, 375);
      this.Controls.Add(tableLayoutPanel1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "DirectoryBatchParameterEditor";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Edit";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DirectoryBatchParameterEditor_FormClosed);
      this.Load += new System.EventHandler(this.DirectoryBatchParameterEditor_Load);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      tableLayoutPanel2.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.FolderBrowserDialog SourceDirectorySelector;
    private System.Windows.Forms.TextBox mDirectoryPath;
    private System.Windows.Forms.Button CmdBrowse;
    private System.Windows.Forms.TextBox mPreview;
    private System.Windows.Forms.ComboBox mFileMask;
    private System.Windows.Forms.TextBox mDisplayName;
  }
}