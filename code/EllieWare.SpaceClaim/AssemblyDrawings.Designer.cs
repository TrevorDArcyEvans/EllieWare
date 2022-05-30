//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace EllieWare.SpaceClaim
{
  partial class AssemblyDrawings
  {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      mControl.Dispose();
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.Windows.Forms.Label label1;
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      System.Windows.Forms.Label label2;
      this.DrawingStyle = new System.Windows.Forms.ComboBox();
      this.Template = new System.Windows.Forms.ComboBox();
      label1 = new System.Windows.Forms.Label();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      label2 = new System.Windows.Forms.Label();
      tableLayoutPanel1.SuspendLayout();
      this.mControl.SuspendLayout();
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(3, 6);
      label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(54, 13);
      label1.TabIndex = 0;
      label1.Text = "Template:";
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 2;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.Controls.Add(this.DrawingStyle, 0, 1);
      tableLayoutPanel1.Controls.Add(this.Template, 1, 0);
      tableLayoutPanel1.Controls.Add(label1, 0, 0);
      tableLayoutPanel1.Controls.Add(label2, 0, 1);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 2;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(302, 207);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // DrawingStyle
      // 
      this.DrawingStyle.Dock = System.Windows.Forms.DockStyle.Top;
      this.DrawingStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.DrawingStyle.FormattingEnabled = true;
      this.DrawingStyle.Location = new System.Drawing.Point(63, 30);
      this.DrawingStyle.Name = "DrawingStyle";
      this.DrawingStyle.Size = new System.Drawing.Size(236, 21);
      this.DrawingStyle.TabIndex = 3;
      this.DrawingStyle.SelectedIndexChanged += new System.EventHandler(this.DrawingStyle_SelectedIndexChanged);
      // 
      // Template
      // 
      this.Template.Dock = System.Windows.Forms.DockStyle.Top;
      this.Template.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.Template.FormattingEnabled = true;
      this.Template.Location = new System.Drawing.Point(63, 3);
      this.Template.Name = "Template";
      this.Template.Size = new System.Drawing.Size(236, 21);
      this.Template.TabIndex = 1;
      this.Template.SelectedIndexChanged += new System.EventHandler(this.Template_SelectedIndexChanged);
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new System.Drawing.Point(3, 33);
      label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(33, 13);
      label2.TabIndex = 2;
      label2.Text = "Style:";
      // 
      // AssemblyDrawings
      // 
      this.mControl.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.mControl.Controls.Add(tableLayoutPanel1);
      this.mControl.Name = "AssemblyDrawings";
      this.mControl.Size = new System.Drawing.Size(302, 207);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      this.mControl.ResumeLayout(false);

    }


    #endregion

    private System.Windows.Forms.ComboBox Template;
    private System.Windows.Forms.ComboBox DrawingStyle;
  }
}
