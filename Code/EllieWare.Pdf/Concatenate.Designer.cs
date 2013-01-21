//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace EllieWare.Pdf
{
  partial class Concatenate
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
      System.Windows.Forms.Label label1;
      this.ConcatenateMain = new System.Windows.Forms.TableLayoutPanel();
      this.mOutputFilePath = new EllieWare.Common.ParameterTextBox();
      this.CmdOutputBrowse = new System.Windows.Forms.Button();
      this.OutputFileSelector = new System.Windows.Forms.SaveFileDialog();
      label1 = new System.Windows.Forms.Label();
      this.ConcatenateMain.SuspendLayout();
      this.SuspendLayout();
      // 
      // ConcatenateMain
      // 
      this.ConcatenateMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ConcatenateMain.ColumnCount = 3;
      this.ConcatenateMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.ConcatenateMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.ConcatenateMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.ConcatenateMain.Controls.Add(this.mOutputFilePath, 1, 0);
      this.ConcatenateMain.Controls.Add(label1, 0, 0);
      this.ConcatenateMain.Controls.Add(this.CmdOutputBrowse, 2, 0);
      this.ConcatenateMain.Location = new System.Drawing.Point(0, 58);
      this.ConcatenateMain.Name = "ConcatenateMain";
      this.ConcatenateMain.RowCount = 1;
      this.ConcatenateMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.ConcatenateMain.Size = new System.Drawing.Size(446, 181);
      this.ConcatenateMain.TabIndex = 1;
      // 
      // mOutputFilePath
      // 
      this.mOutputFilePath.Dock = System.Windows.Forms.DockStyle.Top;
      this.mOutputFilePath.Location = new System.Drawing.Point(51, 3);
      this.mOutputFilePath.Name = "mOutputFilePath";
      this.mOutputFilePath.Size = new System.Drawing.Size(360, 20);
      this.mOutputFilePath.TabIndex = 1;
      this.mOutputFilePath.TextChanged += new System.EventHandler(this.OutputFilePath_TextChanged);
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(3, 6);
      label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(42, 13);
      label1.TabIndex = 0;
      label1.Text = "Output:";
      // 
      // CmdOutputBrowse
      // 
      this.CmdOutputBrowse.AutoSize = true;
      this.CmdOutputBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.CmdOutputBrowse.Location = new System.Drawing.Point(417, 3);
      this.CmdOutputBrowse.Name = "CmdOutputBrowse";
      this.CmdOutputBrowse.Size = new System.Drawing.Size(26, 23);
      this.CmdOutputBrowse.TabIndex = 2;
      this.CmdOutputBrowse.Text = "...";
      this.CmdOutputBrowse.UseVisualStyleBackColor = true;
      this.CmdOutputBrowse.Click += new System.EventHandler(this.CmdOutputBrowse_Click);
      // 
      // OutputFileSelector
      // 
      this.OutputFileSelector.CheckPathExists = false;
      this.OutputFileSelector.Filter = "All files (*.*)|*.*";
      this.OutputFileSelector.OverwritePrompt = false;
      this.OutputFileSelector.RestoreDirectory = true;
      this.OutputFileSelector.Title = "Select File";
      // 
      // Concatenate
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.ConcatenateMain);
      this.Name = "Concatenate";
      this.ConcatenateMain.ResumeLayout(false);
      this.ConcatenateMain.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel ConcatenateMain;
    private System.Windows.Forms.Button CmdOutputBrowse;
    private Common.ParameterTextBox mOutputFilePath;
    private System.Windows.Forms.SaveFileDialog OutputFileSelector;
  }
}
