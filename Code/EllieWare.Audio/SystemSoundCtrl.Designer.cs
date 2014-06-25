//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace EllieWare.Audio
{
  partial class SystemSoundCtrl
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
      this.SelSystemSound = new System.Windows.Forms.ComboBox();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      label1 = new System.Windows.Forms.Label();
      tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 2;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.Controls.Add(label1, 0, 0);
      tableLayoutPanel1.Controls.Add(this.SelSystemSound, 1, 0);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 1;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.Size = new System.Drawing.Size(681, 308);
      tableLayoutPanel1.TabIndex = 1;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(3, 6);
      label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(30, 13);
      label1.TabIndex = 0;
      label1.Text = "Play:";
      // 
      // SelSystemSound
      // 
      this.SelSystemSound.Dock = System.Windows.Forms.DockStyle.Top;
      this.SelSystemSound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.SelSystemSound.FormattingEnabled = true;
      this.SelSystemSound.Location = new System.Drawing.Point(39, 3);
      this.SelSystemSound.Name = "SelSystemSound";
      this.SelSystemSound.Size = new System.Drawing.Size(639, 21);
      this.SelSystemSound.TabIndex = 1;
      // 
      // SystemSoundCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(tableLayoutPanel1);
      this.Name = "SystemSoundCtrl";
      this.Size = new System.Drawing.Size(681, 308);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    public System.Windows.Forms.ComboBox SelSystemSound;
  }
}
