//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Common;

namespace EllieWare.Logging
{
  partial class Logging
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
      this.label1 = new System.Windows.Forms.Label();
      this.lblMessage = new System.Windows.Forms.Label();
      this.mMessage = new EllieWare.Common.ParameterTextBox();
      this.mLevel = new System.Windows.Forms.ComboBox();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 2;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
      tableLayoutPanel1.Controls.Add(this.lblMessage, 0, 1);
      tableLayoutPanel1.Controls.Add(this.mMessage, 1, 1);
      tableLayoutPanel1.Controls.Add(this.mLevel, 1, 0);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 2;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(328, 123);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 6);
      this.label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(36, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Level:";
      // 
      // lblMessage
      // 
      this.lblMessage.AutoSize = true;
      this.lblMessage.Location = new System.Drawing.Point(3, 33);
      this.lblMessage.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
      this.lblMessage.Name = "lblMessage";
      this.lblMessage.Size = new System.Drawing.Size(53, 13);
      this.lblMessage.TabIndex = 2;
      this.lblMessage.Text = "Message:";
      // 
      // mMessage
      // 
      this.mMessage.Dock = System.Windows.Forms.DockStyle.Top;
      this.mMessage.Location = new System.Drawing.Point(62, 30);
      this.mMessage.Name = "mMessage";
      this.mMessage.Size = new System.Drawing.Size(263, 20);
      this.mMessage.TabIndex = 3;
      this.mMessage.TextChanged += new System.EventHandler(this.Message_TextChanged);
      // 
      // mLevel
      // 
      this.mLevel.Dock = System.Windows.Forms.DockStyle.Top;
      this.mLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.mLevel.FormattingEnabled = true;
      this.mLevel.Items.AddRange(new object[] {
            "Debug",
            "Information",
            "Warning",
            "Severe",
            "Critical"});
      this.mLevel.Location = new System.Drawing.Point(62, 3);
      this.mLevel.Name = "mLevel";
      this.mLevel.Size = new System.Drawing.Size(263, 21);
      this.mLevel.TabIndex = 1;
      this.mLevel.SelectedIndexChanged += new System.EventHandler(this.Level_SelectedIndexChanged);
      // 
      // Logging
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(tableLayoutPanel1);
      this.Name = "Logging";
      this.Size = new System.Drawing.Size(328, 123);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label1;
    protected System.Windows.Forms.Label lblMessage;
    protected ParameterTextBox mMessage;
    protected System.Windows.Forms.ComboBox mLevel;

  }
}
