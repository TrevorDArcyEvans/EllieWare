namespace EllieWare.Manager
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
      this.label2 = new System.Windows.Forms.Label();
      this.mParameterValue = new System.Windows.Forms.TextBox();
      this.mDisplayName = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.CmdCancel = new System.Windows.Forms.Button();
      this.CmdOK = new System.Windows.Forms.Button();
      this.CmdBrowseFile = new System.Windows.Forms.Button();
      this.CmdDirectory = new System.Windows.Forms.Button();
      this.DirectorySelector = new System.Windows.Forms.FolderBrowserDialog();
      this.FileSelector = new System.Windows.Forms.SaveFileDialog();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(3, 32);
      this.label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(37, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "Value:";
      // 
      // mParameterValue
      // 
      this.tableLayoutPanel1.SetColumnSpan(this.mParameterValue, 3);
      this.mParameterValue.Dock = System.Windows.Forms.DockStyle.Top;
      this.mParameterValue.Location = new System.Drawing.Point(47, 29);
      this.mParameterValue.Name = "mParameterValue";
      this.mParameterValue.Size = new System.Drawing.Size(390, 20);
      this.mParameterValue.TabIndex = 3;
      // 
      // mDisplayName
      // 
      this.tableLayoutPanel1.SetColumnSpan(this.mDisplayName, 3);
      this.mDisplayName.Dock = System.Windows.Forms.DockStyle.Top;
      this.mDisplayName.Location = new System.Drawing.Point(47, 3);
      this.mDisplayName.Name = "mDisplayName";
      this.mDisplayName.Size = new System.Drawing.Size(390, 20);
      this.mDisplayName.TabIndex = 1;
      this.mDisplayName.TextChanged += new System.EventHandler(this.DisplayName_TextChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 6);
      this.label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(38, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Name:";
      // 
      // CmdCancel
      // 
      this.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.CmdCancel.Location = new System.Drawing.Point(362, 78);
      this.CmdCancel.Name = "CmdCancel";
      this.CmdCancel.Size = new System.Drawing.Size(75, 23);
      this.CmdCancel.TabIndex = 4;
      this.CmdCancel.Text = "Cancel";
      this.CmdCancel.UseVisualStyleBackColor = true;
      // 
      // CmdOK
      // 
      this.CmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.CmdOK.Location = new System.Drawing.Point(281, 78);
      this.CmdOK.Name = "CmdOK";
      this.CmdOK.Size = new System.Drawing.Size(75, 23);
      this.CmdOK.TabIndex = 5;
      this.CmdOK.Text = "OK";
      this.CmdOK.UseVisualStyleBackColor = true;
      // 
      // CmdBrowseFile
      // 
      this.CmdBrowseFile.Location = new System.Drawing.Point(443, 29);
      this.CmdBrowseFile.Name = "CmdBrowseFile";
      this.CmdBrowseFile.Size = new System.Drawing.Size(75, 23);
      this.CmdBrowseFile.TabIndex = 6;
      this.CmdBrowseFile.Text = "File...";
      this.CmdBrowseFile.UseVisualStyleBackColor = true;
      this.CmdBrowseFile.Click += new System.EventHandler(this.CmdBrowseFile_Click);
      // 
      // CmdDirectory
      // 
      this.CmdDirectory.Location = new System.Drawing.Point(524, 29);
      this.CmdDirectory.Name = "CmdDirectory";
      this.CmdDirectory.Size = new System.Drawing.Size(75, 23);
      this.CmdDirectory.TabIndex = 7;
      this.CmdDirectory.Text = "Directory...";
      this.CmdDirectory.UseVisualStyleBackColor = true;
      this.CmdDirectory.Click += new System.EventHandler(this.CmdDirectory_Click);
      // 
      // FileSelector
      // 
      this.FileSelector.CheckPathExists = false;
      this.FileSelector.OverwritePrompt = false;
      this.FileSelector.RestoreDirectory = true;
      this.FileSelector.Title = "Select File";
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.tableLayoutPanel1.ColumnCount = 6;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.mDisplayName, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.mParameterValue, 1, 1);
      this.tableLayoutPanel1.Controls.Add(this.CmdDirectory, 5, 1);
      this.tableLayoutPanel1.Controls.Add(this.CmdBrowseFile, 4, 1);
      this.tableLayoutPanel1.Controls.Add(this.CmdOK, 2, 3);
      this.tableLayoutPanel1.Controls.Add(this.CmdCancel, 3, 3);
      this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 4;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(602, 105);
      this.tableLayoutPanel1.TabIndex = 8;
      // 
      // AddEditParameter
      // 
      this.AcceptButton = this.CmdOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.CmdCancel;
      this.ClientSize = new System.Drawing.Size(624, 129);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "AddEditParameter";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Add Parameter";
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox mParameterValue;
    private System.Windows.Forms.TextBox mDisplayName;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button CmdCancel;
    private System.Windows.Forms.Button CmdOK;
    private System.Windows.Forms.Button CmdBrowseFile;
    private System.Windows.Forms.Button CmdDirectory;
    protected System.Windows.Forms.FolderBrowserDialog DirectorySelector;
    protected System.Windows.Forms.SaveFileDialog FileSelector;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
  }
}