//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace EllieWare.Common
{
  partial class FileBatchParameterEditor
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileBatchParameterEditor));
      this.mFilePath = new System.Windows.Forms.TextBox();
      this.CmdBrowse = new System.Windows.Forms.Button();
      this.mPreview = new System.Windows.Forms.TextBox();
      this.mDisplayName = new System.Windows.Forms.TextBox();
      this.SourceFileSelector = new System.Windows.Forms.SaveFileDialog();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      label1 = new System.Windows.Forms.Label();
      label2 = new System.Windows.Forms.Label();
      tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      CmdOK = new System.Windows.Forms.Button();
      CmdCancel = new System.Windows.Forms.Button();
      label3 = new System.Windows.Forms.Label();
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
      tableLayoutPanel1.ColumnCount = 5;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.Controls.Add(label1, 0, 1);
      tableLayoutPanel1.Controls.Add(this.mFilePath, 1, 1);
      tableLayoutPanel1.Controls.Add(this.CmdBrowse, 4, 1);
      tableLayoutPanel1.Controls.Add(this.mPreview, 1, 2);
      tableLayoutPanel1.Controls.Add(label2, 0, 2);
      tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 3, 3);
      tableLayoutPanel1.Controls.Add(label3, 0, 0);
      tableLayoutPanel1.Controls.Add(this.mDisplayName, 1, 0);
      tableLayoutPanel1.Location = new System.Drawing.Point(13, 13);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 4;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(447, 278);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(3, 32);
      label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(26, 13);
      label1.TabIndex = 2;
      label1.Text = "File:";
      // 
      // mFilePath
      // 
      tableLayoutPanel1.SetColumnSpan(this.mFilePath, 3);
      this.mFilePath.Dock = System.Windows.Forms.DockStyle.Top;
      this.mFilePath.Location = new System.Drawing.Point(54, 29);
      this.mFilePath.Name = "mFilePath";
      this.mFilePath.Size = new System.Drawing.Size(358, 20);
      this.mFilePath.TabIndex = 3;
      this.mFilePath.TextChanged += new System.EventHandler(this.FilePath_TextChanged);
      // 
      // CmdBrowse
      // 
      this.CmdBrowse.AutoSize = true;
      this.CmdBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.CmdBrowse.Location = new System.Drawing.Point(418, 29);
      this.CmdBrowse.Name = "CmdBrowse";
      this.CmdBrowse.Size = new System.Drawing.Size(26, 23);
      this.CmdBrowse.TabIndex = 4;
      this.CmdBrowse.Text = "...";
      this.CmdBrowse.UseVisualStyleBackColor = true;
      this.CmdBrowse.Click += new System.EventHandler(this.CmdBrowse_Click);
      // 
      // mPreview
      // 
      tableLayoutPanel1.SetColumnSpan(this.mPreview, 4);
      this.mPreview.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mPreview.Location = new System.Drawing.Point(54, 58);
      this.mPreview.Multiline = true;
      this.mPreview.Name = "mPreview";
      this.mPreview.ReadOnly = true;
      this.mPreview.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.mPreview.Size = new System.Drawing.Size(390, 182);
      this.mPreview.TabIndex = 7;
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new System.Drawing.Point(3, 61);
      label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(45, 13);
      label2.TabIndex = 6;
      label2.Text = "Preview";
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.AutoSize = true;
      tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      tableLayoutPanel2.ColumnCount = 2;
      tableLayoutPanel1.SetColumnSpan(tableLayoutPanel2, 2);
      tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      tableLayoutPanel2.Controls.Add(CmdOK, 0, 0);
      tableLayoutPanel2.Controls.Add(CmdCancel, 1, 0);
      tableLayoutPanel2.Location = new System.Drawing.Point(282, 246);
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
      label3.Location = new System.Drawing.Point(3, 6);
      label3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(38, 13);
      label3.TabIndex = 0;
      label3.Text = "Name:";
      // 
      // mDisplayName
      // 
      tableLayoutPanel1.SetColumnSpan(this.mDisplayName, 4);
      this.mDisplayName.Dock = System.Windows.Forms.DockStyle.Top;
      this.mDisplayName.Location = new System.Drawing.Point(54, 3);
      this.mDisplayName.Name = "mDisplayName";
      this.mDisplayName.Size = new System.Drawing.Size(390, 20);
      this.mDisplayName.TabIndex = 1;
      // 
      // SourceFileSelector
      // 
      this.SourceFileSelector.CheckPathExists = false;
      this.SourceFileSelector.Filter = "All files (*.*)|*.*";
      this.SourceFileSelector.OverwritePrompt = false;
      this.SourceFileSelector.RestoreDirectory = true;
      this.SourceFileSelector.Title = "Select File";
      // 
      // FileBatchParameterEditor
      // 
      this.AcceptButton = CmdOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = CmdCancel;
      this.ClientSize = new System.Drawing.Size(472, 303);
      this.Controls.Add(tableLayoutPanel1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "FileBatchParameterEditor";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Edit";
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      tableLayoutPanel2.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.SaveFileDialog SourceFileSelector;
    private System.Windows.Forms.TextBox mFilePath;
    private System.Windows.Forms.Button CmdBrowse;
    private System.Windows.Forms.TextBox mPreview;
    private System.Windows.Forms.TextBox mDisplayName;
  }
}