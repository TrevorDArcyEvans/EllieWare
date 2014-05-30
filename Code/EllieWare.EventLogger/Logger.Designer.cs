//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace EllieWare.EventLogger
{
  partial class Logger
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
      this.mMessage = new EllieWare.Common.ParameterTextBox();
      this.mLevel = new System.Windows.Forms.ComboBox();
      this.lblMessage = new System.Windows.Forms.Label();
      this.lblLevel = new System.Windows.Forms.Label();
      this.lblSource = new System.Windows.Forms.Label();
      this.mSource = new EllieWare.Common.ParameterTextBox();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 2;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.Controls.Add(this.mMessage, 1, 2);
      tableLayoutPanel1.Controls.Add(this.mLevel, 1, 1);
      tableLayoutPanel1.Controls.Add(this.lblMessage, 0, 2);
      tableLayoutPanel1.Controls.Add(this.lblLevel, 0, 1);
      tableLayoutPanel1.Controls.Add(this.lblSource, 0, 0);
      tableLayoutPanel1.Controls.Add(this.mSource, 1, 0);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 3;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(340, 206);
      tableLayoutPanel1.TabIndex = 1;
      // 
      // mMessage
      // 
      this.mMessage.Dock = System.Windows.Forms.DockStyle.Top;
      this.mMessage.Location = new System.Drawing.Point(62, 56);
      this.mMessage.Name = "mMessage";
      this.mMessage.Size = new System.Drawing.Size(275, 20);
      this.mMessage.TabIndex = 5;
      this.mMessage.TextChanged += new System.EventHandler(this.Message_TextChanged);
      // 
      // mLevel
      // 
      this.mLevel.Dock = System.Windows.Forms.DockStyle.Top;
      this.mLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.mLevel.FormattingEnabled = true;
      this.mLevel.Location = new System.Drawing.Point(62, 29);
      this.mLevel.Name = "mLevel";
      this.mLevel.Size = new System.Drawing.Size(275, 21);
      this.mLevel.TabIndex = 3;
      this.mLevel.SelectedIndexChanged += new System.EventHandler(this.Level_SelectedIndexChanged);
      // 
      // lblMessage
      // 
      this.lblMessage.AutoSize = true;
      this.lblMessage.Location = new System.Drawing.Point(3, 59);
      this.lblMessage.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
      this.lblMessage.Name = "lblMessage";
      this.lblMessage.Size = new System.Drawing.Size(53, 13);
      this.lblMessage.TabIndex = 4;
      this.lblMessage.Text = "Message:";
      // 
      // lblLevel
      // 
      this.lblLevel.AutoSize = true;
      this.lblLevel.Location = new System.Drawing.Point(3, 32);
      this.lblLevel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
      this.lblLevel.Name = "lblLevel";
      this.lblLevel.Size = new System.Drawing.Size(36, 13);
      this.lblLevel.TabIndex = 2;
      this.lblLevel.Text = "Level:";
      // 
      // lblSource
      // 
      this.lblSource.AutoSize = true;
      this.lblSource.Location = new System.Drawing.Point(3, 6);
      this.lblSource.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
      this.lblSource.Name = "lblSource";
      this.lblSource.Size = new System.Drawing.Size(44, 13);
      this.lblSource.TabIndex = 0;
      this.lblSource.Text = "Source:";
      // 
      // mSource
      // 
      this.mSource.Dock = System.Windows.Forms.DockStyle.Top;
      this.mSource.Location = new System.Drawing.Point(62, 3);
      this.mSource.Name = "mSource";
      this.mSource.Size = new System.Drawing.Size(275, 20);
      this.mSource.TabIndex = 1;
      this.mSource.TextChanged += new System.EventHandler(this.Message_TextChanged);
      // 
      // Logger
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(tableLayoutPanel1);
      this.Name = "Logger";
      this.Size = new System.Drawing.Size(340, 206);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lblLevel;
    protected System.Windows.Forms.Label lblMessage;
    protected Common.ParameterTextBox mMessage;
    protected System.Windows.Forms.ComboBox mLevel;
    private System.Windows.Forms.Label lblSource;
    protected Common.ParameterTextBox mSource;
  }
}
