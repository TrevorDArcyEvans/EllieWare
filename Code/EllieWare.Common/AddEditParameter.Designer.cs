//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace EllieWare.Common
{
  partial class AddEditParameter
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
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.Label label2;
      System.Windows.Forms.Label label1;
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      wyDay.Controls.SplitButton splitButton1;
      System.Windows.Forms.ContextMenuStrip AddEditParameterStrip;
      System.Windows.Forms.ToolStripMenuItem BrowseFile;
      System.Windows.Forms.ToolStripMenuItem BrowseDirectory;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditParameter));
      this.mDisplayName = new System.Windows.Forms.TextBox();
      this.mParameterValue = new System.Windows.Forms.TextBox();
      this.CmdOK = new System.Windows.Forms.Button();
      this.CmdCancel = new System.Windows.Forms.Button();
      this.DirectorySelector = new System.Windows.Forms.FolderBrowserDialog();
      this.FileSelector = new System.Windows.Forms.SaveFileDialog();
      label2 = new System.Windows.Forms.Label();
      label1 = new System.Windows.Forms.Label();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      splitButton1 = new wyDay.Controls.SplitButton();
      AddEditParameterStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
      BrowseFile = new System.Windows.Forms.ToolStripMenuItem();
      BrowseDirectory = new System.Windows.Forms.ToolStripMenuItem();
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
      AddEditParameterStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new System.Drawing.Point(3, 32);
      label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(37, 13);
      label2.TabIndex = 2;
      label2.Text = "Value:";
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(3, 6);
      label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(38, 13);
      label1.TabIndex = 0;
      label1.Text = "Name:";
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      tableLayoutPanel1.ColumnCount = 5;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.Controls.Add(label1, 0, 0);
      tableLayoutPanel1.Controls.Add(label2, 0, 1);
      tableLayoutPanel1.Controls.Add(this.mDisplayName, 1, 0);
      tableLayoutPanel1.Controls.Add(this.mParameterValue, 1, 1);
      tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 3, 3);
      tableLayoutPanel1.Controls.Add(splitButton1, 4, 1);
      tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 4;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(522, 110);
      tableLayoutPanel1.TabIndex = 8;
      // 
      // mDisplayName
      // 
      tableLayoutPanel1.SetColumnSpan(this.mDisplayName, 3);
      this.mDisplayName.Dock = System.Windows.Forms.DockStyle.Top;
      this.mDisplayName.Location = new System.Drawing.Point(47, 3);
      this.mDisplayName.Name = "mDisplayName";
      this.mDisplayName.Size = new System.Drawing.Size(422, 20);
      this.mDisplayName.TabIndex = 1;
      this.mDisplayName.TextChanged += new System.EventHandler(this.DisplayName_TextChanged);
      // 
      // mParameterValue
      // 
      tableLayoutPanel1.SetColumnSpan(this.mParameterValue, 3);
      this.mParameterValue.Dock = System.Windows.Forms.DockStyle.Top;
      this.mParameterValue.Location = new System.Drawing.Point(47, 29);
      this.mParameterValue.Name = "mParameterValue";
      this.mParameterValue.Size = new System.Drawing.Size(422, 20);
      this.mParameterValue.TabIndex = 3;
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.AutoSize = true;
      tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      tableLayoutPanel2.ColumnCount = 2;
      tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      tableLayoutPanel2.Controls.Add(this.CmdOK, 0, 0);
      tableLayoutPanel2.Controls.Add(this.CmdCancel, 1, 0);
      tableLayoutPanel2.Location = new System.Drawing.Point(307, 78);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 1;
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      tableLayoutPanel2.Size = new System.Drawing.Size(162, 29);
      tableLayoutPanel2.TabIndex = 8;
      // 
      // CmdOK
      // 
      this.CmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.CmdOK.Enabled = false;
      this.CmdOK.Location = new System.Drawing.Point(3, 3);
      this.CmdOK.Name = "CmdOK";
      this.CmdOK.Size = new System.Drawing.Size(75, 23);
      this.CmdOK.TabIndex = 0;
      this.CmdOK.Text = "OK";
      this.CmdOK.UseVisualStyleBackColor = true;
      // 
      // CmdCancel
      // 
      this.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.CmdCancel.Location = new System.Drawing.Point(84, 3);
      this.CmdCancel.Name = "CmdCancel";
      this.CmdCancel.Size = new System.Drawing.Size(75, 23);
      this.CmdCancel.TabIndex = 1;
      this.CmdCancel.Text = "Cancel";
      this.CmdCancel.UseVisualStyleBackColor = true;
      // 
      // splitButton1
      // 
      splitButton1.AutoSize = true;
      splitButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      splitButton1.ContextMenuStrip = AddEditParameterStrip;
      splitButton1.Location = new System.Drawing.Point(475, 29);
      splitButton1.Name = "splitButton1";
      splitButton1.Size = new System.Drawing.Size(44, 23);
      splitButton1.SplitMenuStrip = AddEditParameterStrip;
      splitButton1.TabIndex = 10;
      splitButton1.Text = "...";
      splitButton1.UseVisualStyleBackColor = true;
      splitButton1.Click += new System.EventHandler(this.CmdBrowseFile_Click);
      // 
      // AddEditParameterStrip
      // 
      AddEditParameterStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            BrowseFile,
            BrowseDirectory});
      AddEditParameterStrip.Name = "contextMenuStrip1";
      AddEditParameterStrip.Size = new System.Drawing.Size(153, 70);
      // 
      // BrowseFile
      // 
      BrowseFile.Name = "BrowseFile";
      BrowseFile.Size = new System.Drawing.Size(152, 22);
      BrowseFile.Text = "File...";
      BrowseFile.Click += new System.EventHandler(this.CmdBrowseFile_Click);
      // 
      // BrowseDirectory
      // 
      BrowseDirectory.Name = "BrowseDirectory";
      BrowseDirectory.Size = new System.Drawing.Size(152, 22);
      BrowseDirectory.Text = "Directory...";
      BrowseDirectory.Click += new System.EventHandler(this.CmdDirectory_Click);
      // 
      // FileSelector
      // 
      this.FileSelector.CheckPathExists = false;
      this.FileSelector.OverwritePrompt = false;
      this.FileSelector.RestoreDirectory = true;
      this.FileSelector.Title = "Select File";
      // 
      // AddEditParameter
      // 
      this.AcceptButton = this.CmdOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.CmdCancel;
      this.ClientSize = new System.Drawing.Size(544, 134);
      this.Controls.Add(tableLayoutPanel1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximumSize = new System.Drawing.Size(2000, 172);
      this.MinimumSize = new System.Drawing.Size(480, 172);
      this.Name = "AddEditParameter";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Add Parameter";
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      tableLayoutPanel2.ResumeLayout(false);
      AddEditParameterStrip.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TextBox mParameterValue;
    private System.Windows.Forms.TextBox mDisplayName;
    private System.Windows.Forms.Button CmdCancel;
    private System.Windows.Forms.Button CmdOK;
    protected System.Windows.Forms.FolderBrowserDialog DirectorySelector;
    protected System.Windows.Forms.SaveFileDialog FileSelector;
  }
}