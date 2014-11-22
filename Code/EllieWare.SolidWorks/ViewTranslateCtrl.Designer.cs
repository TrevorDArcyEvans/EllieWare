//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//

namespace EllieWare.SolidWorks
{
  partial class ViewTranslateCtrl
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
      this.mTranslateType = new System.Windows.Forms.ComboBox();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // mTranslateType
      // 
      this.mTranslateType.Dock = System.Windows.Forms.DockStyle.Top;
      this.mTranslateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.mTranslateType.FormattingEnabled = true;
      this.mTranslateType.Items.AddRange(new object[] {
            "Minus X (-X)",
            "Plus X (+X)",
            "Minus Y (-Y)",
            "Plus Y (+Y)"});
      this.mTranslateType.Location = new System.Drawing.Point(3, 3);
      this.mTranslateType.Name = "mTranslateType";
      this.mTranslateType.Size = new System.Drawing.Size(144, 21);
      this.mTranslateType.TabIndex = 0;
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 1;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      tableLayoutPanel1.Controls.Add(this.mTranslateType, 0, 0);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 1;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      tableLayoutPanel1.Size = new System.Drawing.Size(150, 150);
      tableLayoutPanel1.TabIndex = 2;
      // 
      // ViewTranslateCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(tableLayoutPanel1);
      this.Name = "ViewTranslateCtrl";
      tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ComboBox mTranslateType;
  }
}
