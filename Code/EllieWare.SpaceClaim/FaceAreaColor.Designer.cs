//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace EllieWare.SpaceClaim
{
  partial class FaceAreaColor
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
      this.AreaLabel = new System.Windows.Forms.Label();
      this.ColorLabel = new System.Windows.Forms.Label();
      this.AreaUnits = new System.Windows.Forms.Label();
      this.AreaThreshold = new System.Windows.Forms.NumericUpDown();
      this.ColorSwatch = new System.Windows.Forms.PictureBox();
      this.ColorDlg = new System.Windows.Forms.ColorDialog();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.AreaThreshold)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ColorSwatch)).BeginInit();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.Controls.Add(this.AreaLabel, 0, 0);
      tableLayoutPanel1.Controls.Add(this.ColorLabel, 0, 1);
      tableLayoutPanel1.Controls.Add(this.AreaUnits, 2, 0);
      tableLayoutPanel1.Controls.Add(this.AreaThreshold, 1, 0);
      tableLayoutPanel1.Controls.Add(this.ColorSwatch, 1, 1);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 2;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(294, 223);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // AreaLabel
      // 
      this.AreaLabel.AutoSize = true;
      this.AreaLabel.Location = new System.Drawing.Point(3, 6);
      this.AreaLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.AreaLabel.Name = "AreaLabel";
      this.AreaLabel.Size = new System.Drawing.Size(32, 13);
      this.AreaLabel.TabIndex = 0;
      this.AreaLabel.Text = "Area:";
      // 
      // ColorLabel
      // 
      this.ColorLabel.AutoSize = true;
      this.ColorLabel.Location = new System.Drawing.Point(3, 32);
      this.ColorLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.ColorLabel.Name = "ColorLabel";
      this.ColorLabel.Size = new System.Drawing.Size(34, 13);
      this.ColorLabel.TabIndex = 3;
      this.ColorLabel.Text = "Color:";
      // 
      // AreaUnits
      // 
      this.AreaUnits.AutoSize = true;
      this.AreaUnits.Location = new System.Drawing.Point(256, 6);
      this.AreaUnits.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.AreaUnits.Name = "AreaUnits";
      this.AreaUnits.Size = new System.Drawing.Size(35, 13);
      this.AreaUnits.TabIndex = 2;
      this.AreaUnits.Text = "mm^2";
      // 
      // AreaThreshold
      // 
      this.AreaThreshold.DecimalPlaces = 3;
      this.AreaThreshold.Dock = System.Windows.Forms.DockStyle.Top;
      this.AreaThreshold.Location = new System.Drawing.Point(43, 3);
      this.AreaThreshold.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
      this.AreaThreshold.Name = "AreaThreshold";
      this.AreaThreshold.Size = new System.Drawing.Size(207, 20);
      this.AreaThreshold.TabIndex = 1;
      this.AreaThreshold.ValueChanged += new System.EventHandler(this.AreaThreshold_ValueChanged);
      // 
      // ColorSwatch
      // 
      this.ColorSwatch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.ColorSwatch.Location = new System.Drawing.Point(43, 29);
      this.ColorSwatch.Name = "ColorSwatch";
      this.ColorSwatch.Size = new System.Drawing.Size(32, 32);
      this.ColorSwatch.TabIndex = 4;
      this.ColorSwatch.TabStop = false;
      this.ColorSwatch.Click += new System.EventHandler(this.ColorSwatch_Click);
      // 
      // ColorDlg
      // 
      this.ColorDlg.AllowFullOpen = false;
      this.ColorDlg.SolidColorOnly = true;
      // 
      // FaceAreaColor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(tableLayoutPanel1);
      this.Name = "FaceAreaColor";
      this.Size = new System.Drawing.Size(294, 223);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.AreaThreshold)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ColorSwatch)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ColorDialog ColorDlg;
    protected System.Windows.Forms.Label ColorLabel;
    protected System.Windows.Forms.PictureBox ColorSwatch;
    protected System.Windows.Forms.NumericUpDown AreaThreshold;
    protected System.Windows.Forms.Label AreaUnits;
    protected System.Windows.Forms.Label AreaLabel;
  }
}
