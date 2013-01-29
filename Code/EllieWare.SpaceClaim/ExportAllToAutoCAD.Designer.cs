//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace EllieWare.SpaceClaim
{
  partial class ExportAllToAutoCAD
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
      this.ExportMain = new System.Windows.Forms.TableLayoutPanel();
      this.FileFormat = new System.Windows.Forms.ComboBox();
      label1 = new System.Windows.Forms.Label();
      this.ExportMain.SuspendLayout();
      this.SuspendLayout();
      // 
      // ExportMain
      // 
      this.ExportMain.ColumnCount = 2;
      this.ExportMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.ExportMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.ExportMain.Controls.Add(label1, 0, 0);
      this.ExportMain.Controls.Add(this.FileFormat, 1, 0);
      this.ExportMain.Location = new System.Drawing.Point(0, 29);
      this.ExportMain.Name = "ExportMain";
      this.ExportMain.RowCount = 1;
      this.ExportMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.ExportMain.Size = new System.Drawing.Size(443, 210);
      this.ExportMain.TabIndex = 1;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(3, 6);
      label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(42, 13);
      label1.TabIndex = 0;
      label1.Text = "Format:";
      // 
      // FileFormat
      // 
      this.FileFormat.Dock = System.Windows.Forms.DockStyle.Top;
      this.FileFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.FileFormat.FormattingEnabled = true;
      this.FileFormat.Location = new System.Drawing.Point(51, 3);
      this.FileFormat.Name = "FileFormat";
      this.FileFormat.Size = new System.Drawing.Size(389, 21);
      this.FileFormat.TabIndex = 1;
      // 
      // ExportAllToAutoCAD
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.ExportMain);
      this.Name = "ExportAllToAutoCAD";
      this.ExportMain.ResumeLayout(false);
      this.ExportMain.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel ExportMain;
    private System.Windows.Forms.ComboBox FileFormat;
  }
}
