//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace EllieWare.SpaceClaim
{
  partial class ComponentOperationBase
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
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      this.ChkRecursive = new System.Windows.Forms.CheckBox();
      this.ChkSave = new System.Windows.Forms.CheckBox();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel1.SuspendLayout();
      this.mControl.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 1;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.Controls.Add(this.ChkRecursive, 0, 0);
      tableLayoutPanel1.Controls.Add(this.ChkSave, 0, 1);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 2;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(293, 229);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // ChkRecursive
      // 
      this.ChkRecursive.AutoSize = true;
      this.ChkRecursive.Location = new System.Drawing.Point(3, 3);
      this.ChkRecursive.Name = "ChkRecursive";
      this.ChkRecursive.Size = new System.Drawing.Size(74, 17);
      this.ChkRecursive.TabIndex = 0;
      this.ChkRecursive.Text = "Recursive";
      this.ChkRecursive.UseVisualStyleBackColor = true;
      this.ChkRecursive.CheckedChanged += new System.EventHandler(this.ChkRecursive_CheckedChanged);
      // 
      // ChkSave
      // 
      this.ChkSave.AutoSize = true;
      this.ChkSave.Location = new System.Drawing.Point(3, 26);
      this.ChkSave.Name = "ChkSave";
      this.ChkSave.Size = new System.Drawing.Size(51, 17);
      this.ChkSave.TabIndex = 1;
      this.ChkSave.Text = "Save";
      this.ChkSave.UseVisualStyleBackColor = true;
      this.ChkSave.CheckedChanged += new System.EventHandler(this.ChkSave_CheckedChanged);
      // 
      // ComponentOperationBase
      // 
      this.mControl.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.mControl.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.mControl.Controls.Add(tableLayoutPanel1);
      this.mControl.Name = "ComponentOperationBase";
      this.mControl.Size = new System.Drawing.Size(293, 229);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      this.mControl.ResumeLayout(false);

    }

    #endregion

    protected System.Windows.Forms.CheckBox ChkRecursive;
    protected System.Windows.Forms.CheckBox ChkSave;
  }
}
