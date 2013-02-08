//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace BottleSlicer
{
  partial class BottleSlicerPlugin
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
      System.Windows.Forms.Label label2;
      this.OutputDirectory = new System.Windows.Forms.TextBox();
      this.CmdDirectorySelect = new System.Windows.Forms.Button();
      this.Sections = new System.Windows.Forms.NumericUpDown();
      this.OutputDirectorySelectDialog = new System.Windows.Forms.FolderBrowserDialog();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      label1 = new System.Windows.Forms.Label();
      label2 = new System.Windows.Forms.Label();
      tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.Sections)).BeginInit();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.Controls.Add(label1, 0, 0);
      tableLayoutPanel1.Controls.Add(label2, 0, 1);
      tableLayoutPanel1.Controls.Add(this.OutputDirectory, 1, 0);
      tableLayoutPanel1.Controls.Add(this.CmdDirectorySelect, 2, 0);
      tableLayoutPanel1.Controls.Add(this.Sections, 1, 1);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 2;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(386, 290);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(3, 6);
      label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(87, 13);
      label1.TabIndex = 0;
      label1.Text = "Output Directory:";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new System.Drawing.Point(3, 35);
      label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(51, 13);
      label2.TabIndex = 3;
      label2.Text = "Sections:";
      // 
      // OutputDirectory
      // 
      this.OutputDirectory.Dock = System.Windows.Forms.DockStyle.Top;
      this.OutputDirectory.Location = new System.Drawing.Point(96, 3);
      this.OutputDirectory.Name = "OutputDirectory";
      this.OutputDirectory.Size = new System.Drawing.Size(255, 20);
      this.OutputDirectory.TabIndex = 1;
      this.OutputDirectory.TextChanged += new System.EventHandler(this.OutputDirectory_TextChanged);
      // 
      // CmdDirectorySelect
      // 
      this.CmdDirectorySelect.AutoSize = true;
      this.CmdDirectorySelect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.CmdDirectorySelect.Location = new System.Drawing.Point(357, 3);
      this.CmdDirectorySelect.Name = "CmdDirectorySelect";
      this.CmdDirectorySelect.Size = new System.Drawing.Size(26, 23);
      this.CmdDirectorySelect.TabIndex = 2;
      this.CmdDirectorySelect.Text = "...";
      this.CmdDirectorySelect.UseVisualStyleBackColor = true;
      this.CmdDirectorySelect.Click += new System.EventHandler(this.CmdDirectorySelect_Click);
      // 
      // Sections
      // 
      this.Sections.Dock = System.Windows.Forms.DockStyle.Top;
      this.Sections.Location = new System.Drawing.Point(96, 32);
      this.Sections.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
      this.Sections.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
      this.Sections.Name = "Sections";
      this.Sections.Size = new System.Drawing.Size(255, 20);
      this.Sections.TabIndex = 4;
      this.Sections.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.Sections.ValueChanged += new System.EventHandler(this.Sections_ValueChanged);
      // 
      // BottleSlicerPlugin
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(tableLayoutPanel1);
      this.Name = "BottleSlicerPlugin";
      this.Size = new System.Drawing.Size(386, 290);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.Sections)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TextBox OutputDirectory;
    private System.Windows.Forms.Button CmdDirectorySelect;
    private System.Windows.Forms.NumericUpDown Sections;
    private System.Windows.Forms.FolderBrowserDialog OutputDirectorySelectDialog;
  }
}
