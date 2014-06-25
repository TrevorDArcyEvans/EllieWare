//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace EllieWare.Pdf
{
  partial class PrintCtrl
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
      this.PrintMain = new System.Windows.Forms.TableLayoutPanel();
      this.Printers = new System.Windows.Forms.ComboBox();
      label1 = new System.Windows.Forms.Label();
      this.PrintMain.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(3, 6);
      label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(40, 13);
      label1.TabIndex = 0;
      label1.Text = "Printer:";
      // 
      // PrintMain
      // 
      this.PrintMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.PrintMain.ColumnCount = 2;
      this.PrintMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.PrintMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.PrintMain.Controls.Add(label1, 0, 0);
      this.PrintMain.Controls.Add(this.Printers, 1, 0);
      this.PrintMain.Location = new System.Drawing.Point(0, 29);
      this.PrintMain.Name = "PrintMain";
      this.PrintMain.RowCount = 2;
      this.PrintMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.PrintMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.PrintMain.Size = new System.Drawing.Size(443, 210);
      this.PrintMain.TabIndex = 1;
      // 
      // Printers
      // 
      this.Printers.Dock = System.Windows.Forms.DockStyle.Top;
      this.Printers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.Printers.FormattingEnabled = true;
      this.Printers.Location = new System.Drawing.Point(49, 3);
      this.Printers.Name = "Printers";
      this.Printers.Size = new System.Drawing.Size(391, 21);
      this.Printers.TabIndex = 1;
      this.Printers.SelectedIndexChanged += new System.EventHandler(this.Printers_SelectedIndexChanged);
      // 
      // Print
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.Controls.Add(this.PrintMain);
      this.Name = "Print";
      this.PrintMain.ResumeLayout(false);
      this.PrintMain.PerformLayout();
      this.ResumeLayout(false);

    }

    private System.Windows.Forms.TableLayoutPanel PrintMain;
    public System.Windows.Forms.ComboBox Printers;
  
    #endregion
  }
}
