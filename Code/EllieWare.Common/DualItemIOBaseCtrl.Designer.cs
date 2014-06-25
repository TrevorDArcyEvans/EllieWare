//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace EllieWare.Common
{
  partial class DualItemIOBaseCtrl
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      this.mExistsLabel = new System.Windows.Forms.Label();
      this.mSourceLabel = new System.Windows.Forms.Label();
      this.mDestinationLabel = new System.Windows.Forms.Label();
      this.mSourceFilePath = new EllieWare.Common.ParameterTextBox();
      this.mDestinationFilePath = new EllieWare.Common.ParameterTextBox();
      this.CmdSourceBrowse = new System.Windows.Forms.Button();
      this.CmdDestinationBrowse = new System.Windows.Forms.Button();
      this.mExists = new System.Windows.Forms.ComboBox();
      this.SourceDirectorySelector = new System.Windows.Forms.FolderBrowserDialog();
      this.SourceFileSelector = new System.Windows.Forms.SaveFileDialog();
      this.DestinationFileSelector = new System.Windows.Forms.SaveFileDialog();
      this.DestinationDirectorySelector = new System.Windows.Forms.FolderBrowserDialog();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.Controls.Add(this.mExistsLabel, 0, 2);
      tableLayoutPanel1.Controls.Add(this.mSourceLabel, 0, 0);
      tableLayoutPanel1.Controls.Add(this.mDestinationLabel, 0, 1);
      tableLayoutPanel1.Controls.Add(this.mSourceFilePath, 1, 0);
      tableLayoutPanel1.Controls.Add(this.mDestinationFilePath, 1, 1);
      tableLayoutPanel1.Controls.Add(this.CmdSourceBrowse, 2, 0);
      tableLayoutPanel1.Controls.Add(this.CmdDestinationBrowse, 2, 1);
      tableLayoutPanel1.Controls.Add(this.mExists, 1, 2);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 3;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      tableLayoutPanel1.Size = new System.Drawing.Size(446, 239);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // mExistsLabel
      // 
      this.mExistsLabel.AutoSize = true;
      this.mExistsLabel.Location = new System.Drawing.Point(3, 64);
      this.mExistsLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.mExistsLabel.Name = "mExistsLabel";
      this.mExistsLabel.Size = new System.Drawing.Size(37, 13);
      this.mExistsLabel.TabIndex = 6;
      this.mExistsLabel.Text = "Exists:";
      this.mExistsLabel.Visible = false;
      // 
      // mSourceLabel
      // 
      this.mSourceLabel.AutoSize = true;
      this.mSourceLabel.Location = new System.Drawing.Point(3, 6);
      this.mSourceLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.mSourceLabel.Name = "mSourceLabel";
      this.mSourceLabel.Size = new System.Drawing.Size(44, 13);
      this.mSourceLabel.TabIndex = 0;
      this.mSourceLabel.Text = "Source:";
      // 
      // mDestinationLabel
      // 
      this.mDestinationLabel.AutoSize = true;
      this.mDestinationLabel.Location = new System.Drawing.Point(3, 35);
      this.mDestinationLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.mDestinationLabel.Name = "mDestinationLabel";
      this.mDestinationLabel.Size = new System.Drawing.Size(63, 13);
      this.mDestinationLabel.TabIndex = 3;
      this.mDestinationLabel.Text = "Destination:";
      // 
      // mSourceFilePath
      // 
      this.mSourceFilePath.Dock = System.Windows.Forms.DockStyle.Top;
      this.mSourceFilePath.Location = new System.Drawing.Point(72, 3);
      this.mSourceFilePath.Name = "mSourceFilePath";
      this.mSourceFilePath.Size = new System.Drawing.Size(339, 20);
      this.mSourceFilePath.TabIndex = 1;
      this.mSourceFilePath.TextChanged += new System.EventHandler(this.SourceFilePath_TextChanged);
      // 
      // mDestinationFilePath
      // 
      this.mDestinationFilePath.Dock = System.Windows.Forms.DockStyle.Top;
      this.mDestinationFilePath.Location = new System.Drawing.Point(72, 32);
      this.mDestinationFilePath.Name = "mDestinationFilePath";
      this.mDestinationFilePath.Size = new System.Drawing.Size(339, 20);
      this.mDestinationFilePath.TabIndex = 4;
      this.mDestinationFilePath.TextChanged += new System.EventHandler(this.DestinationFilePath_TextChanged);
      // 
      // CmdSourceBrowse
      // 
      this.CmdSourceBrowse.AutoSize = true;
      this.CmdSourceBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.CmdSourceBrowse.Location = new System.Drawing.Point(417, 3);
      this.CmdSourceBrowse.Name = "CmdSourceBrowse";
      this.CmdSourceBrowse.Size = new System.Drawing.Size(26, 23);
      this.CmdSourceBrowse.TabIndex = 2;
      this.CmdSourceBrowse.Text = "...";
      this.CmdSourceBrowse.UseVisualStyleBackColor = true;
      this.CmdSourceBrowse.Click += new System.EventHandler(this.CmdSourceBrowse_Click);
      // 
      // CmdDestinationBrowse
      // 
      this.CmdDestinationBrowse.AutoSize = true;
      this.CmdDestinationBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.CmdDestinationBrowse.Location = new System.Drawing.Point(417, 32);
      this.CmdDestinationBrowse.Name = "CmdDestinationBrowse";
      this.CmdDestinationBrowse.Size = new System.Drawing.Size(26, 23);
      this.CmdDestinationBrowse.TabIndex = 5;
      this.CmdDestinationBrowse.Text = "...";
      this.CmdDestinationBrowse.UseVisualStyleBackColor = true;
      this.CmdDestinationBrowse.Click += new System.EventHandler(this.CmdDestinationBrowse_Click);
      // 
      // mExists
      // 
      this.mExists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.mExists.FormattingEnabled = true;
      this.mExists.Items.AddRange(new object[] {
            "No",
            "Yes"});
      this.mExists.Location = new System.Drawing.Point(72, 61);
      this.mExists.Name = "mExists";
      this.mExists.Size = new System.Drawing.Size(95, 21);
      this.mExists.TabIndex = 7;
      this.mExists.Visible = false;
      this.mExists.SelectedIndexChanged += new System.EventHandler(this.Exists_SelectedIndexChanged);
      // 
      // SourceFileSelector
      // 
      this.SourceFileSelector.CheckPathExists = false;
      this.SourceFileSelector.Filter = "All files (*.*)|*.*";
      this.SourceFileSelector.OverwritePrompt = false;
      this.SourceFileSelector.RestoreDirectory = true;
      this.SourceFileSelector.Title = "Select File";
      // 
      // DestinationFileSelector
      // 
      this.DestinationFileSelector.CheckPathExists = false;
      this.DestinationFileSelector.Filter = "All files (*.*)|*.*";
      this.DestinationFileSelector.OverwritePrompt = false;
      this.DestinationFileSelector.RestoreDirectory = true;
      this.DestinationFileSelector.Title = "Select File";
      // 
      // DualItemIOBase
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(tableLayoutPanel1);
      this.Name = "DualItemIOBase";
      this.Size = new System.Drawing.Size(446, 239);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    public ParameterTextBox mSourceFilePath;
    public ParameterTextBox mDestinationFilePath;
    public System.Windows.Forms.FolderBrowserDialog SourceDirectorySelector;
    public System.Windows.Forms.Label mSourceLabel;
    public System.Windows.Forms.SaveFileDialog SourceFileSelector;
    public System.Windows.Forms.Label mExistsLabel;
    public System.Windows.Forms.ComboBox mExists;
    public System.Windows.Forms.Label mDestinationLabel;
    public System.Windows.Forms.Button CmdDestinationBrowse;
    public System.Windows.Forms.Button CmdSourceBrowse;
    public System.Windows.Forms.SaveFileDialog DestinationFileSelector;
    public System.Windows.Forms.FolderBrowserDialog DestinationDirectorySelector;
  }
}
