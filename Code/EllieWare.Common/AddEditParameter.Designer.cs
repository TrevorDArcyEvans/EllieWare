﻿//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace EllieWare.Common
{
  partial class AddEditParameter
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
      System.Windows.Forms.Label label2;
      System.Windows.Forms.Label label1;
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditParameter));
      this.mParameterValue = new System.Windows.Forms.TextBox();
      this.mDisplayName = new System.Windows.Forms.TextBox();
      this.CmdDirectory = new System.Windows.Forms.Button();
      this.CmdBrowseFile = new System.Windows.Forms.Button();
      this.CmdOK = new System.Windows.Forms.Button();
      this.CmdCancel = new System.Windows.Forms.Button();
      this.DirectorySelector = new System.Windows.Forms.FolderBrowserDialog();
      this.FileSelector = new System.Windows.Forms.SaveFileDialog();
      this.AddEditParameterHelp = new System.Windows.Forms.HelpProvider();
      this.FileMaskLabel = new System.Windows.Forms.Label();
      this.mFileMask = new System.Windows.Forms.TextBox();
      label2 = new System.Windows.Forms.Label();
      label1 = new System.Windows.Forms.Label();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new System.Drawing.Point(3, 32);
      label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(37, 13);
      label2.TabIndex = 2;
      label2.Text = "Value:";
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(3, 6);
      label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(38, 13);
      label1.TabIndex = 0;
      label1.Text = "Name:";
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      tableLayoutPanel1.ColumnCount = 6;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.Controls.Add(label1, 0, 0);
      tableLayoutPanel1.Controls.Add(label2, 0, 1);
      tableLayoutPanel1.Controls.Add(this.mDisplayName, 1, 0);
      tableLayoutPanel1.Controls.Add(this.mParameterValue, 1, 1);
      tableLayoutPanel1.Controls.Add(this.CmdDirectory, 5, 1);
      tableLayoutPanel1.Controls.Add(this.CmdBrowseFile, 4, 1);
      tableLayoutPanel1.Controls.Add(this.CmdOK, 2, 4);
      tableLayoutPanel1.Controls.Add(this.CmdCancel, 3, 4);
      tableLayoutPanel1.Controls.Add(this.FileMaskLabel, 0, 2);
      tableLayoutPanel1.Controls.Add(this.mFileMask, 1, 2);
      tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 5;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(602, 131);
      tableLayoutPanel1.TabIndex = 8;
      // 
      // mParameterValue
      // 
      tableLayoutPanel1.SetColumnSpan(this.mParameterValue, 3);
      this.mParameterValue.Dock = System.Windows.Forms.DockStyle.Top;
      this.mParameterValue.Location = new System.Drawing.Point(64, 29);
      this.mParameterValue.Name = "mParameterValue";
      this.mParameterValue.Size = new System.Drawing.Size(373, 20);
      this.mParameterValue.TabIndex = 3;
      // 
      // mDisplayName
      // 
      tableLayoutPanel1.SetColumnSpan(this.mDisplayName, 3);
      this.mDisplayName.Dock = System.Windows.Forms.DockStyle.Top;
      this.mDisplayName.Location = new System.Drawing.Point(64, 3);
      this.mDisplayName.Name = "mDisplayName";
      this.mDisplayName.Size = new System.Drawing.Size(373, 20);
      this.mDisplayName.TabIndex = 1;
      this.mDisplayName.TextChanged += new System.EventHandler(this.DisplayName_TextChanged);
      // 
      // CmdDirectory
      // 
      this.CmdDirectory.Location = new System.Drawing.Point(524, 29);
      this.CmdDirectory.Name = "CmdDirectory";
      this.CmdDirectory.Size = new System.Drawing.Size(75, 23);
      this.CmdDirectory.TabIndex = 5;
      this.CmdDirectory.Text = "Directory...";
      this.CmdDirectory.UseVisualStyleBackColor = true;
      this.CmdDirectory.Click += new System.EventHandler(this.CmdDirectory_Click);
      // 
      // CmdBrowseFile
      // 
      this.CmdBrowseFile.Location = new System.Drawing.Point(443, 29);
      this.CmdBrowseFile.Name = "CmdBrowseFile";
      this.CmdBrowseFile.Size = new System.Drawing.Size(75, 23);
      this.CmdBrowseFile.TabIndex = 4;
      this.CmdBrowseFile.Text = "File...";
      this.CmdBrowseFile.UseVisualStyleBackColor = true;
      this.CmdBrowseFile.Click += new System.EventHandler(this.CmdBrowseFile_Click);
      // 
      // CmdOK
      // 
      this.CmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.CmdOK.Location = new System.Drawing.Point(281, 104);
      this.CmdOK.Name = "CmdOK";
      this.CmdOK.Size = new System.Drawing.Size(75, 23);
      this.CmdOK.TabIndex = 6;
      this.CmdOK.Text = "OK";
      this.CmdOK.UseVisualStyleBackColor = true;
      // 
      // CmdCancel
      // 
      this.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.CmdCancel.Location = new System.Drawing.Point(362, 104);
      this.CmdCancel.Name = "CmdCancel";
      this.CmdCancel.Size = new System.Drawing.Size(75, 23);
      this.CmdCancel.TabIndex = 7;
      this.CmdCancel.Text = "Cancel";
      this.CmdCancel.UseVisualStyleBackColor = true;
      // 
      // FileSelector
      // 
      this.FileSelector.CheckPathExists = false;
      this.FileSelector.OverwritePrompt = false;
      this.FileSelector.RestoreDirectory = true;
      this.FileSelector.Title = "Select File";
      // 
      // FileMaskLabel
      // 
      this.FileMaskLabel.AutoSize = true;
      this.FileMaskLabel.Location = new System.Drawing.Point(3, 61);
      this.FileMaskLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.FileMaskLabel.Name = "FileMaskLabel";
      this.FileMaskLabel.Size = new System.Drawing.Size(55, 13);
      this.FileMaskLabel.TabIndex = 8;
      this.FileMaskLabel.Text = "File Mask:";
      // 
      // mFileMask
      // 
      tableLayoutPanel1.SetColumnSpan(this.mFileMask, 3);
      this.mFileMask.Dock = System.Windows.Forms.DockStyle.Top;
      this.mFileMask.Location = new System.Drawing.Point(64, 58);
      this.mFileMask.Name = "mFileMask";
      this.mFileMask.Size = new System.Drawing.Size(373, 20);
      this.mFileMask.TabIndex = 9;
      this.mFileMask.Text = "*.*";
      // 
      // AddEditParameter
      // 
      this.AcceptButton = this.CmdOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.CmdCancel;
      this.ClientSize = new System.Drawing.Size(624, 155);
      this.Controls.Add(tableLayoutPanel1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "AddEditParameter";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Add Parameter";
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TextBox mParameterValue;
    private System.Windows.Forms.TextBox mDisplayName;
    private System.Windows.Forms.Button CmdCancel;
    private System.Windows.Forms.Button CmdOK;
    private System.Windows.Forms.Button CmdBrowseFile;
    private System.Windows.Forms.Button CmdDirectory;
    protected System.Windows.Forms.FolderBrowserDialog DirectorySelector;
    protected System.Windows.Forms.SaveFileDialog FileSelector;
    private System.Windows.Forms.HelpProvider AddEditParameterHelp;
    private System.Windows.Forms.Label FileMaskLabel;
    private System.Windows.Forms.TextBox mFileMask;
  }
}