//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace EllieWare.Imaging
{
  partial class ResizerBaseCtrl
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
      this.ResizerMain = new System.Windows.Forms.TableLayoutPanel();
      this.Label1 = new System.Windows.Forms.Label();
      this.Label2 = new System.Windows.Forms.Label();
      this.Dimension1 = new System.Windows.Forms.NumericUpDown();
      this.Dimension2 = new System.Windows.Forms.NumericUpDown();
      this.ResizerMain.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.Dimension1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.Dimension2)).BeginInit();
      this.SuspendLayout();
      // 
      // ResizerMain
      // 
      this.ResizerMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ResizerMain.ColumnCount = 2;
      this.ResizerMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.ResizerMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.ResizerMain.Controls.Add(this.Label1, 0, 0);
      this.ResizerMain.Controls.Add(this.Label2, 0, 1);
      this.ResizerMain.Controls.Add(this.Dimension1, 1, 0);
      this.ResizerMain.Controls.Add(this.Dimension2, 1, 1);
      this.ResizerMain.Location = new System.Drawing.Point(0, 58);
      this.ResizerMain.Margin = new System.Windows.Forms.Padding(0);
      this.ResizerMain.Name = "ResizerMain";
      this.ResizerMain.RowCount = 2;
      this.ResizerMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.ResizerMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.ResizerMain.Size = new System.Drawing.Size(396, 201);
      this.ResizerMain.TabIndex = 1;
      // 
      // Label1
      // 
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(3, 6);
      this.Label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.Label1.Name = "Label1";
      this.Label1.Size = new System.Drawing.Size(35, 13);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "label1";
      // 
      // Label2
      // 
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(3, 32);
      this.Label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.Label2.Name = "Label2";
      this.Label2.Size = new System.Drawing.Size(35, 13);
      this.Label2.TabIndex = 1;
      this.Label2.Text = "label2";
      // 
      // Dimension1
      // 
      this.Dimension1.Dock = System.Windows.Forms.DockStyle.Top;
      this.Dimension1.Location = new System.Drawing.Point(44, 3);
      this.Dimension1.Name = "Dimension1";
      this.Dimension1.Size = new System.Drawing.Size(349, 20);
      this.Dimension1.TabIndex = 2;
      this.Dimension1.ValueChanged += new System.EventHandler(this.Dimension1_ValueChanged);
      // 
      // Dimension2
      // 
      this.Dimension2.Dock = System.Windows.Forms.DockStyle.Top;
      this.Dimension2.Location = new System.Drawing.Point(44, 29);
      this.Dimension2.Name = "Dimension2";
      this.Dimension2.Size = new System.Drawing.Size(349, 20);
      this.Dimension2.TabIndex = 3;
      this.Dimension2.ValueChanged += new System.EventHandler(this.Dimension2_ValueChanged);
      // 
      // ResizerBase
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.ResizerMain);
      this.Name = "ResizerBase";
      this.Size = new System.Drawing.Size(396, 259);
      this.ResizerMain.ResumeLayout(false);
      this.ResizerMain.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.Dimension1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.Dimension2)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel ResizerMain;
    public System.Windows.Forms.Label Label1;
    public System.Windows.Forms.Label Label2;
    public System.Windows.Forms.NumericUpDown Dimension1;
    public System.Windows.Forms.NumericUpDown Dimension2;
  }
}
