//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace EllieWare.Manager
{
  partial class FileSaveDialog
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
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      System.Windows.Forms.Button CmdCancel;
      System.Windows.Forms.Button CmdOK;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileSaveDialog));
      this.mFileNames = new System.Windows.Forms.ComboBox();
      this.FileSaveHelp = new System.Windows.Forms.HelpProvider();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      CmdCancel = new System.Windows.Forms.Button();
      CmdOK = new System.Windows.Forms.Button();
      tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.Controls.Add(this.mFileNames, 0, 0);
      tableLayoutPanel1.Controls.Add(CmdCancel, 2, 1);
      tableLayoutPanel1.Controls.Add(CmdOK, 1, 1);
      tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 2;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(399, 59);
      tableLayoutPanel1.TabIndex = 3;
      // 
      // mFileNames
      // 
      this.mFileNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      tableLayoutPanel1.SetColumnSpan(this.mFileNames, 3);
      this.mFileNames.FormattingEnabled = true;
      this.mFileNames.Location = new System.Drawing.Point(3, 3);
      this.mFileNames.Name = "mFileNames";
      this.mFileNames.Size = new System.Drawing.Size(393, 21);
      this.mFileNames.TabIndex = 0;
      // 
      // CmdCancel
      // 
      CmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      CmdCancel.Location = new System.Drawing.Point(321, 33);
      CmdCancel.Name = "CmdCancel";
      CmdCancel.Size = new System.Drawing.Size(75, 23);
      CmdCancel.TabIndex = 2;
      CmdCancel.Text = "Cancel";
      CmdCancel.UseVisualStyleBackColor = true;
      // 
      // CmdOK
      // 
      CmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      CmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      CmdOK.Location = new System.Drawing.Point(240, 33);
      CmdOK.Name = "CmdOK";
      CmdOK.Size = new System.Drawing.Size(75, 23);
      CmdOK.TabIndex = 1;
      CmdOK.Text = "OK";
      CmdOK.UseVisualStyleBackColor = true;
      // 
      // FileSaveDialog
      // 
      this.AcceptButton = CmdOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = CmdCancel;
      this.ClientSize = new System.Drawing.Size(423, 83);
      this.Controls.Add(tableLayoutPanel1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MaximumSize = new System.Drawing.Size(5000, 121);
      this.Name = "FileSaveDialog";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Save";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FileSaveDialog_FormClosing);
      this.Shown += new System.EventHandler(this.FileSaveDialog_Shown);
      tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ComboBox mFileNames;
    private System.Windows.Forms.HelpProvider FileSaveHelp;
  }
}