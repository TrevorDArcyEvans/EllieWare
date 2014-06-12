//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace RobotWare.Runtime.Server.Manager
{
  partial class AddCalendar
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCalendar));
      this.CmdOK = new System.Windows.Forms.Button();
      this.CmdCancel = new System.Windows.Forms.Button();
      this.Description = new System.Windows.Forms.TextBox();
      this.mCalendar = new RobotWare.Quartz.Calendar.UserInterface.CalendarCtrl();
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
      MainTable.Controls.Add(this.CmdOK, 1, 2);
      MainTable.Controls.Add(this.CmdCancel, 2, 2);
      MainTable.Controls.Add(this.Description, 0, 1);
      MainTable.Controls.Add(this.mCalendar, 0, 0);
      MainTable.Dock = System.Windows.Forms.DockStyle.Fill;
      MainTable.Location = new System.Drawing.Point(0, 0);
      MainTable.Name = "MainTable";
      MainTable.RowCount = 3;
      MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
      MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
      MainTable.Size = new System.Drawing.Size(690, 374);
      MainTable.TabIndex = 3;
      // 
      // CmdOK
      // 
      this.CmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.CmdOK.Location = new System.Drawing.Point(531, 344);
      this.CmdOK.Name = "CmdOK";
      this.CmdOK.Size = new System.Drawing.Size(75, 27);
      this.CmdOK.TabIndex = 2;
      this.CmdOK.Text = "OK";
      this.CmdOK.UseVisualStyleBackColor = true;
      // 
      // CmdCancel
      // 
      this.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.CmdCancel.Location = new System.Drawing.Point(612, 344);
      this.CmdCancel.Name = "CmdCancel";
      this.CmdCancel.Size = new System.Drawing.Size(75, 27);
      this.CmdCancel.TabIndex = 3;
      this.CmdCancel.Text = "Cancel";
      this.CmdCancel.UseVisualStyleBackColor = true;
      // 
      // Description
      // 
      MainTable.SetColumnSpan(this.Description, 3);
      this.Description.Dock = System.Windows.Forms.DockStyle.Top;
      this.Description.Location = new System.Drawing.Point(3, 316);
      this.Description.Name = "Description";
      this.Description.ReadOnly = true;
      this.Description.Size = new System.Drawing.Size(684, 22);
      this.Description.TabIndex = 1;
      // 
      // mCalendar
      // 
      MainTable.SetColumnSpan(this.mCalendar, 3);
      this.mCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mCalendar.Location = new System.Drawing.Point(3, 3);
      this.mCalendar.Name = "mCalendar";
      this.mCalendar.Size = new System.Drawing.Size(684, 307);
      this.mCalendar.TabIndex = 0;
      this.mCalendar.CalendarChanged += new System.EventHandler(this.Calendar_CalendarChanged);
      // 
      // AddCalendar
      // 
      this.AcceptButton = this.CmdOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.CmdCancel;
      this.ClientSize = new System.Drawing.Size(690, 374);
      this.Controls.Add(MainTable);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "AddCalendar";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Add Calendar";
      MainTable.ResumeLayout(false);
      MainTable.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button CmdOK;
    private System.Windows.Forms.Button CmdCancel;
    private System.Windows.Forms.TextBox Description;
    private Quartz.Calendar.UserInterface.CalendarCtrl mCalendar;
  }
}