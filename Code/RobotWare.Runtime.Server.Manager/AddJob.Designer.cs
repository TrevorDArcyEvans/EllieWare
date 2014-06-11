//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace RobotWare.Runtime.Server.Manager
{
  partial class AddJob
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddJob));
      this.MainTable = new System.Windows.Forms.TableLayoutPanel();
      this.CmdOK = new System.Windows.Forms.Button();
      this.mSpecs = new EllieWare.Manager.SpecificationCtl();
      this.CmdCancel = new System.Windows.Forms.Button();
      this.MainTable.SuspendLayout();
      this.SuspendLayout();
      // 
      // MainTable
      // 
      this.MainTable.ColumnCount = 3;
      this.MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.MainTable.Controls.Add(this.CmdOK, 1, 1);
      this.MainTable.Controls.Add(this.mSpecs, 0, 0);
      this.MainTable.Controls.Add(this.CmdCancel, 2, 1);
      this.MainTable.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MainTable.Location = new System.Drawing.Point(0, 0);
      this.MainTable.Name = "MainTable";
      this.MainTable.RowCount = 2;
      this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.MainTable.Size = new System.Drawing.Size(552, 428);
      this.MainTable.TabIndex = 1;
      // 
      // CmdOK
      // 
      this.CmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.CmdOK.Enabled = false;
      this.CmdOK.Location = new System.Drawing.Point(393, 398);
      this.CmdOK.Name = "CmdOK";
      this.CmdOK.Size = new System.Drawing.Size(75, 27);
      this.CmdOK.TabIndex = 1;
      this.CmdOK.Text = "OK";
      this.CmdOK.UseVisualStyleBackColor = true;
      // 
      // mSpecs
      // 
      this.MainTable.SetColumnSpan(this.mSpecs, 3);
      this.mSpecs.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mSpecs.Location = new System.Drawing.Point(3, 3);
      this.mSpecs.Name = "mSpecs";
      this.mSpecs.Size = new System.Drawing.Size(546, 389);
      this.mSpecs.TabIndex = 0;
      this.mSpecs.SelectedSpecificationChanged += new System.EventHandler(this.Specs_SelectedSpecificationChanged);
      this.mSpecs.SpecificationDoubleClick += new System.EventHandler(this.Specs_SpecificationDoubleClick);
      // 
      // CmdCancel
      // 
      this.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.CmdCancel.Location = new System.Drawing.Point(474, 398);
      this.CmdCancel.Name = "CmdCancel";
      this.CmdCancel.Size = new System.Drawing.Size(75, 27);
      this.CmdCancel.TabIndex = 2;
      this.CmdCancel.Text = "Cancel";
      this.CmdCancel.UseVisualStyleBackColor = true;
      // 
      // AddJob
      // 
      this.AcceptButton = this.CmdOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.CmdCancel;
      this.ClientSize = new System.Drawing.Size(552, 428);
      this.Controls.Add(this.MainTable);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "AddJob";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Add Job";
      this.MainTable.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private EllieWare.Manager.SpecificationCtl mSpecs;
    private System.Windows.Forms.Button CmdOK;
    private System.Windows.Forms.Button CmdCancel;
    private System.Windows.Forms.TableLayoutPanel MainTable;
  }
}