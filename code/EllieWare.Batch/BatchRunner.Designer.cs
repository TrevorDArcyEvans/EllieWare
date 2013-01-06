//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace EllieWare.Batch
{
  partial class BatchRunner
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
      this.Specifications = new System.Windows.Forms.ListBox();
      this.CmdAdd = new System.Windows.Forms.Button();
      this.CmdDelete = new System.Windows.Forms.Button();
      this.CmdEdit = new System.Windows.Forms.Button();
      this.CmdUp = new System.Windows.Forms.Button();
      this.CmdDown = new System.Windows.Forms.Button();
      this.CmdParameters = new System.Windows.Forms.Button();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // Specifications
      // 
      this.Specifications.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Specifications.FormattingEnabled = true;
      this.Specifications.Items.AddRange(new object[] {
            "macro 1",
            "macro 2",
            "macro 3"});
      this.Specifications.Location = new System.Drawing.Point(3, 3);
      this.Specifications.Name = "Specifications";
      this.tableLayoutPanel1.SetRowSpan(this.Specifications, 6);
      this.Specifications.Size = new System.Drawing.Size(411, 303);
      this.Specifications.TabIndex = 0;
      // 
      // CmdAdd
      // 
      this.CmdAdd.Dock = System.Windows.Forms.DockStyle.Top;
      this.CmdAdd.Location = new System.Drawing.Point(420, 3);
      this.CmdAdd.Name = "CmdAdd";
      this.CmdAdd.Size = new System.Drawing.Size(75, 23);
      this.CmdAdd.TabIndex = 1;
      this.CmdAdd.Text = "Add...";
      this.CmdAdd.UseVisualStyleBackColor = true;
      // 
      // CmdDelete
      // 
      this.CmdDelete.Dock = System.Windows.Forms.DockStyle.Top;
      this.CmdDelete.Location = new System.Drawing.Point(420, 32);
      this.CmdDelete.Name = "CmdDelete";
      this.CmdDelete.Size = new System.Drawing.Size(75, 23);
      this.CmdDelete.TabIndex = 2;
      this.CmdDelete.Text = "Delete";
      this.CmdDelete.UseVisualStyleBackColor = true;
      // 
      // CmdEdit
      // 
      this.CmdEdit.Dock = System.Windows.Forms.DockStyle.Top;
      this.CmdEdit.Location = new System.Drawing.Point(420, 61);
      this.CmdEdit.Name = "CmdEdit";
      this.CmdEdit.Size = new System.Drawing.Size(75, 23);
      this.CmdEdit.TabIndex = 3;
      this.CmdEdit.Text = "Edit...";
      this.CmdEdit.UseVisualStyleBackColor = true;
      // 
      // CmdUp
      // 
      this.CmdUp.Dock = System.Windows.Forms.DockStyle.Top;
      this.CmdUp.Location = new System.Drawing.Point(420, 90);
      this.CmdUp.Name = "CmdUp";
      this.CmdUp.Size = new System.Drawing.Size(75, 23);
      this.CmdUp.TabIndex = 4;
      this.CmdUp.Text = "Up";
      this.CmdUp.UseVisualStyleBackColor = true;
      // 
      // CmdDown
      // 
      this.CmdDown.Dock = System.Windows.Forms.DockStyle.Top;
      this.CmdDown.Location = new System.Drawing.Point(420, 119);
      this.CmdDown.Name = "CmdDown";
      this.CmdDown.Size = new System.Drawing.Size(75, 23);
      this.CmdDown.TabIndex = 5;
      this.CmdDown.Text = "Down";
      this.CmdDown.UseVisualStyleBackColor = true;
      // 
      // CmdParameters
      // 
      this.CmdParameters.Dock = System.Windows.Forms.DockStyle.Top;
      this.CmdParameters.Location = new System.Drawing.Point(420, 148);
      this.CmdParameters.Name = "CmdParameters";
      this.CmdParameters.Size = new System.Drawing.Size(75, 23);
      this.CmdParameters.TabIndex = 6;
      this.CmdParameters.Text = "Parameters...";
      this.CmdParameters.UseVisualStyleBackColor = true;
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.Controls.Add(this.CmdAdd, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.Specifications, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.CmdParameters, 1, 5);
      this.tableLayoutPanel1.Controls.Add(this.CmdDelete, 1, 1);
      this.tableLayoutPanel1.Controls.Add(this.CmdDown, 1, 4);
      this.tableLayoutPanel1.Controls.Add(this.CmdEdit, 1, 2);
      this.tableLayoutPanel1.Controls.Add(this.CmdUp, 1, 3);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 6;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.Size = new System.Drawing.Size(498, 309);
      this.tableLayoutPanel1.TabIndex = 7;
      // 
      // BatchRunner
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "BatchRunner";
      this.Size = new System.Drawing.Size(498, 309);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListBox Specifications;
    private System.Windows.Forms.Button CmdAdd;
    private System.Windows.Forms.Button CmdDelete;
    private System.Windows.Forms.Button CmdEdit;
    private System.Windows.Forms.Button CmdUp;
    private System.Windows.Forms.Button CmdDown;
    private System.Windows.Forms.Button CmdParameters;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
  }
}
