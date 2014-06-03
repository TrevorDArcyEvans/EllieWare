//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace RobotWare.Cron.UserInterface
{
  partial class MinutesCtrl
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
      System.Windows.Forms.Label label2;
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.MinutesValue = new System.Windows.Forms.NumericUpDown();
      label1 = new System.Windows.Forms.Label();
      label2 = new System.Windows.Forms.Label();
      this.tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.MinutesValue)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Dock = System.Windows.Forms.DockStyle.Top;
      label1.Location = new System.Drawing.Point(3, 3);
      label1.Margin = new System.Windows.Forms.Padding(3);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(34, 13);
      label1.TabIndex = 0;
      label1.Text = "Every";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Dock = System.Windows.Forms.DockStyle.Top;
      label2.Location = new System.Drawing.Point(260, 3);
      label2.Margin = new System.Windows.Forms.Padding(3);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(49, 13);
      label2.TabIndex = 2;
      label2.Text = "minute(s)";
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 3;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.Controls.Add(label1, 0, 0);
      this.tableLayoutPanel1.Controls.Add(label2, 2, 0);
      this.tableLayoutPanel1.Controls.Add(this.MinutesValue, 1, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(312, 263);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // MinutesValue
      // 
      this.MinutesValue.Dock = System.Windows.Forms.DockStyle.Top;
      this.MinutesValue.Location = new System.Drawing.Point(43, 3);
      this.MinutesValue.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
      this.MinutesValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.MinutesValue.Name = "MinutesValue";
      this.MinutesValue.Size = new System.Drawing.Size(211, 20);
      this.MinutesValue.TabIndex = 1;
      this.MinutesValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.MinutesValue.ValueChanged += new System.EventHandler(this.FireExpressionChangedInternal);
      // 
      // MinutesCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "MinutesCtrl";
      this.Size = new System.Drawing.Size(312, 263);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.MinutesValue)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.NumericUpDown MinutesValue;
  }
}
