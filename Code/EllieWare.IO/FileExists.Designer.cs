﻿namespace EllieWare.IO
{
  partial class FileExists
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
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.label1 = new System.Windows.Forms.Label();
      this.mFilePath = new System.Windows.Forms.TextBox();
      this.CmdBrowse = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.mExists = new System.Windows.Forms.ComboBox();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 3;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.mFilePath, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.CmdBrowse, 2, 0);
      this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.mExists, 1, 1);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.Size = new System.Drawing.Size(406, 130);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 6);
      this.label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(26, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "File:";
      // 
      // mFilePath
      // 
      this.mFilePath.Dock = System.Windows.Forms.DockStyle.Top;
      this.mFilePath.Location = new System.Drawing.Point(46, 3);
      this.mFilePath.Name = "mFilePath";
      this.mFilePath.Size = new System.Drawing.Size(325, 20);
      this.mFilePath.TabIndex = 1;
      this.mFilePath.TextChanged += new System.EventHandler(this.FilePath_TextChanged);
      // 
      // CmdBrowse
      // 
      this.CmdBrowse.AutoSize = true;
      this.CmdBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.CmdBrowse.Location = new System.Drawing.Point(377, 3);
      this.CmdBrowse.Name = "CmdBrowse";
      this.CmdBrowse.Size = new System.Drawing.Size(26, 23);
      this.CmdBrowse.TabIndex = 2;
      this.CmdBrowse.Text = "...";
      this.CmdBrowse.UseVisualStyleBackColor = true;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(3, 35);
      this.label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(37, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "Exists:";
      // 
      // mExists
      // 
      this.mExists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.mExists.FormattingEnabled = true;
      this.mExists.Items.AddRange(new object[] {
            "No",
            "Yes"});
      this.mExists.Location = new System.Drawing.Point(46, 32);
      this.mExists.Name = "mExists";
      this.mExists.Size = new System.Drawing.Size(95, 21);
      this.mExists.TabIndex = 5;
      this.mExists.SelectedIndexChanged += new System.EventHandler(this.Exists_SelectedIndexChanged);
      // 
      // FileExists
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "FileExists";
      this.Size = new System.Drawing.Size(406, 130);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox mFilePath;
    private System.Windows.Forms.Button CmdBrowse;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox mExists;

  }
}