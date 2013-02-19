//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace SheetMetalEstimator
{
  partial class SheetMetalEstimator
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
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      System.Windows.Forms.Label label1;
      this.OptGenerateDXF = new System.Windows.Forms.CheckBox();
      this.ExcelFilePath = new System.Windows.Forms.TextBox();
      this.BtnBrowse = new System.Windows.Forms.Button();
      this.DlgOpenFile = new System.Windows.Forms.OpenFileDialog();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      label1 = new System.Windows.Forms.Label();
      tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.Controls.Add(this.OptGenerateDXF, 0, 1);
      tableLayoutPanel1.Controls.Add(label1, 0, 0);
      tableLayoutPanel1.Controls.Add(this.ExcelFilePath, 1, 0);
      tableLayoutPanel1.Controls.Add(this.BtnBrowse, 2, 0);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 2;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(301, 239);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // OptGenerateDXF
      // 
      this.OptGenerateDXF.AutoSize = true;
      tableLayoutPanel1.SetColumnSpan(this.OptGenerateDXF, 2);
      this.OptGenerateDXF.Location = new System.Drawing.Point(3, 35);
      this.OptGenerateDXF.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
      this.OptGenerateDXF.Name = "OptGenerateDXF";
      this.OptGenerateDXF.Size = new System.Drawing.Size(138, 17);
      this.OptGenerateDXF.TabIndex = 0;
      this.OptGenerateDXF.Text = "Generate AutoCad DXF";
      this.OptGenerateDXF.UseVisualStyleBackColor = true;
      this.OptGenerateDXF.CheckedChanged += new System.EventHandler(this.OptGenerateDXF_CheckedChanged);
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(3, 6);
      label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(55, 13);
      label1.TabIndex = 1;
      label1.Text = "Excel File:";
      // 
      // ExcelFilePath
      // 
      this.ExcelFilePath.Dock = System.Windows.Forms.DockStyle.Top;
      this.ExcelFilePath.Location = new System.Drawing.Point(64, 3);
      this.ExcelFilePath.Name = "ExcelFilePath";
      this.ExcelFilePath.Size = new System.Drawing.Size(202, 20);
      this.ExcelFilePath.TabIndex = 2;
      this.ExcelFilePath.TextChanged += new System.EventHandler(this.ExcelFilePath_TextChanged);
      // 
      // BtnBrowse
      // 
      this.BtnBrowse.AutoSize = true;
      this.BtnBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.BtnBrowse.Location = new System.Drawing.Point(272, 3);
      this.BtnBrowse.Name = "BtnBrowse";
      this.BtnBrowse.Size = new System.Drawing.Size(26, 23);
      this.BtnBrowse.TabIndex = 3;
      this.BtnBrowse.Text = "...";
      this.BtnBrowse.UseVisualStyleBackColor = true;
      this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
      // 
      // DlgOpenFile
      // 
      this.DlgOpenFile.CheckFileExists = false;
      this.DlgOpenFile.CheckPathExists = false;
      this.DlgOpenFile.DefaultExt = "csv";
      this.DlgOpenFile.Filter = "Comma Separated Value files (*.csv)|*.csv|All files (*.*)|*.*";
      // 
      // SheetMetalEstimator
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(tableLayoutPanel1);
      this.Name = "SheetMetalEstimator";
      this.Size = new System.Drawing.Size(301, 239);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.CheckBox OptGenerateDXF;
    private System.Windows.Forms.TextBox ExcelFilePath;
    private System.Windows.Forms.Button BtnBrowse;
    private System.Windows.Forms.OpenFileDialog DlgOpenFile;

  }
}
