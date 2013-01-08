//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace EllieWare.Macro
{
  partial class MacroRunner
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
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      System.Windows.Forms.Label label1;
      this.CmdSelectMacro = new System.Windows.Forms.Button();
      this.MacroFileName = new EllieWare.Common.ParameterTextBox();
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
      tableLayoutPanel1.Controls.Add(label1, 0, 0);
      tableLayoutPanel1.Controls.Add(this.CmdSelectMacro, 2, 0);
      tableLayoutPanel1.Controls.Add(this.MacroFileName, 1, 0);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 1;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.Size = new System.Drawing.Size(462, 302);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(3, 6);
      label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(40, 13);
      label1.TabIndex = 0;
      label1.Text = "Macro:";
      // 
      // CmdSelectMacro
      // 
      this.CmdSelectMacro.AutoSize = true;
      this.CmdSelectMacro.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.CmdSelectMacro.Location = new System.Drawing.Point(433, 3);
      this.CmdSelectMacro.Name = "CmdSelectMacro";
      this.CmdSelectMacro.Size = new System.Drawing.Size(26, 23);
      this.CmdSelectMacro.TabIndex = 2;
      this.CmdSelectMacro.Text = "...";
      this.CmdSelectMacro.UseVisualStyleBackColor = true;
      this.CmdSelectMacro.Click += new System.EventHandler(this.CmdSelectMacro_Click);
      // 
      // MacroFileName
      // 
      this.MacroFileName.Dock = System.Windows.Forms.DockStyle.Top;
      this.MacroFileName.Location = new System.Drawing.Point(49, 3);
      this.MacroFileName.Name = "MacroFileName";
      this.MacroFileName.Size = new System.Drawing.Size(378, 20);
      this.MacroFileName.TabIndex = 1;
      this.MacroFileName.TextChanged += new System.EventHandler(this.MacroFileName_TextChanged);
      // 
      // MacroRunner
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(tableLayoutPanel1);
      this.Name = "MacroRunner";
      this.Size = new System.Drawing.Size(462, 302);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button CmdSelectMacro;
    private Common.ParameterTextBox MacroFileName;
  }
}
