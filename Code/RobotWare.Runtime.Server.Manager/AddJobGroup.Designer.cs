//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace RobotWare.Runtime.Server.Manager
{
  partial class AddJobGroup
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
      System.Windows.Forms.TableLayoutPanel MainTable;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddJobGroup));
      this.CmdOK = new System.Windows.Forms.Button();
      this.JobGroup = new System.Windows.Forms.TextBox();
      this.CmdCancel = new System.Windows.Forms.Button();
      MainTable = new System.Windows.Forms.TableLayoutPanel();
      MainTable.SuspendLayout();
      this.SuspendLayout();
      // 
      // MainTable
      // 
      MainTable.AutoSize = true;
      MainTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      MainTable.ColumnCount = 3;
      MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      MainTable.Controls.Add(this.CmdOK, 1, 1);
      MainTable.Controls.Add(this.JobGroup, 0, 0);
      MainTable.Controls.Add(this.CmdCancel, 2, 1);
      MainTable.Dock = System.Windows.Forms.DockStyle.Fill;
      MainTable.Location = new System.Drawing.Point(0, 0);
      MainTable.Name = "MainTable";
      MainTable.RowCount = 2;
      MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
      MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
      MainTable.Size = new System.Drawing.Size(382, 65);
      MainTable.TabIndex = 2;
      // 
      // CmdOK
      // 
      this.CmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.CmdOK.Enabled = false;
      this.CmdOK.Location = new System.Drawing.Point(223, 31);
      this.CmdOK.Name = "CmdOK";
      this.CmdOK.Size = new System.Drawing.Size(75, 27);
      this.CmdOK.TabIndex = 1;
      this.CmdOK.Text = "OK";
      this.CmdOK.UseVisualStyleBackColor = true;
      // 
      // JobGroup
      // 
      MainTable.SetColumnSpan(this.JobGroup, 3);
      this.JobGroup.Dock = System.Windows.Forms.DockStyle.Top;
      this.JobGroup.Location = new System.Drawing.Point(3, 3);
      this.JobGroup.MaximumSize = new System.Drawing.Size(1200, 22);
      this.JobGroup.MinimumSize = new System.Drawing.Size(100, 22);
      this.JobGroup.Name = "JobGroup";
      this.JobGroup.Size = new System.Drawing.Size(376, 22);
      this.JobGroup.TabIndex = 0;
      this.JobGroup.TextChanged += new System.EventHandler(this.JobGroup_TextChanged);
      // 
      // CmdCancel
      // 
      this.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.CmdCancel.Location = new System.Drawing.Point(304, 31);
      this.CmdCancel.Name = "CmdCancel";
      this.CmdCancel.Size = new System.Drawing.Size(75, 27);
      this.CmdCancel.TabIndex = 2;
      this.CmdCancel.Text = "Cancel";
      this.CmdCancel.UseVisualStyleBackColor = true;
      // 
      // AddJobGroup
      // 
      this.AcceptButton = this.CmdOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.CmdCancel;
      this.ClientSize = new System.Drawing.Size(382, 65);
      this.Controls.Add(MainTable);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "AddJobGroup";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Add Job Group";
      MainTable.ResumeLayout(false);
      MainTable.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button CmdOK;
    private System.Windows.Forms.Button CmdCancel;
    private System.Windows.Forms.TextBox JobGroup;
  }
}