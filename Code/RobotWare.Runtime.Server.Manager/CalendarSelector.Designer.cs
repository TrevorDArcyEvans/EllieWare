//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace RobotWare.Runtime.Server.Manager
{
  partial class CalendarSelector
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalendarSelector));
      this.CmdOK = new System.Windows.Forms.Button();
      this.CmdCancel = new System.Windows.Forms.Button();
      this.Calendar = new System.Windows.Forms.ComboBox();
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
      MainTable.Controls.Add(this.CmdCancel, 2, 1);
      MainTable.Controls.Add(this.Calendar, 0, 0);
      MainTable.Dock = System.Windows.Forms.DockStyle.Fill;
      MainTable.Location = new System.Drawing.Point(0, 0);
      MainTable.Name = "MainTable";
      MainTable.RowCount = 2;
      MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
      MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
      MainTable.Size = new System.Drawing.Size(454, 65);
      MainTable.TabIndex = 3;
      // 
      // CmdOK
      // 
      this.CmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.CmdOK.Location = new System.Drawing.Point(295, 33);
      this.CmdOK.Name = "CmdOK";
      this.CmdOK.Size = new System.Drawing.Size(75, 27);
      this.CmdOK.TabIndex = 1;
      this.CmdOK.Text = "OK";
      this.CmdOK.UseVisualStyleBackColor = true;
      // 
      // CmdCancel
      // 
      this.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.CmdCancel.Location = new System.Drawing.Point(376, 33);
      this.CmdCancel.Name = "CmdCancel";
      this.CmdCancel.Size = new System.Drawing.Size(75, 27);
      this.CmdCancel.TabIndex = 2;
      this.CmdCancel.Text = "Cancel";
      this.CmdCancel.UseVisualStyleBackColor = true;
      // 
      // Calendar
      // 
      MainTable.SetColumnSpan(this.Calendar, 3);
      this.Calendar.Dock = System.Windows.Forms.DockStyle.Top;
      this.Calendar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.Calendar.FormattingEnabled = true;
      this.Calendar.Location = new System.Drawing.Point(3, 3);
      this.Calendar.Name = "Calendar";
      this.Calendar.Size = new System.Drawing.Size(448, 24);
      this.Calendar.TabIndex = 3;
      // 
      // CalendarSelector
      // 
      this.AcceptButton = this.CmdOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.CmdCancel;
      this.ClientSize = new System.Drawing.Size(454, 65);
      this.Controls.Add(MainTable);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximumSize = new System.Drawing.Size(1200, 110);
      this.MinimumSize = new System.Drawing.Size(472, 110);
      this.Name = "CalendarSelector";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Select Calendar";
      MainTable.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button CmdOK;
    private System.Windows.Forms.Button CmdCancel;
    private System.Windows.Forms.ComboBox Calendar;

  }
}