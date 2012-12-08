namespace EllieWare.Common
{
  partial class DualItemIOBase
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
      System.Windows.Forms.Button CmdSourceBrowse;
      this.DirectorySelector = new System.Windows.Forms.FolderBrowserDialog();
      this.FileSelector = new System.Windows.Forms.SaveFileDialog();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.mExistsLabel = new System.Windows.Forms.Label();
      this.mSourceLabel = new System.Windows.Forms.Label();
      this.mDestinationLabel = new System.Windows.Forms.Label();
      this.mSourceFilePath = new System.Windows.Forms.TextBox();
      this.mDestinationFilePath = new System.Windows.Forms.TextBox();
      this.CmdDestinationBrowse = new System.Windows.Forms.Button();
      this.mExists = new System.Windows.Forms.ComboBox();
      CmdSourceBrowse = new System.Windows.Forms.Button();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // FileSelector
      // 
      this.FileSelector.CheckPathExists = false;
      this.FileSelector.OverwritePrompt = false;
      this.FileSelector.RestoreDirectory = true;
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 3;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.Controls.Add(this.mExistsLabel, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.mSourceLabel, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.mDestinationLabel, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.mSourceFilePath, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.mDestinationFilePath, 1, 1);
      this.tableLayoutPanel1.Controls.Add(CmdSourceBrowse, 2, 0);
      this.tableLayoutPanel1.Controls.Add(this.CmdDestinationBrowse, 2, 1);
      this.tableLayoutPanel1.Controls.Add(this.mExists, 1, 2);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 3;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(446, 239);
      this.tableLayoutPanel1.TabIndex = 2;
      // 
      // mExistsLabel
      // 
      this.mExistsLabel.AutoSize = true;
      this.mExistsLabel.Location = new System.Drawing.Point(3, 64);
      this.mExistsLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.mExistsLabel.Name = "mExistsLabel";
      this.mExistsLabel.Size = new System.Drawing.Size(37, 13);
      this.mExistsLabel.TabIndex = 6;
      this.mExistsLabel.Text = "Exists:";
      this.mExistsLabel.Visible = false;
      // 
      // mSourceLabel
      // 
      this.mSourceLabel.AutoSize = true;
      this.mSourceLabel.Location = new System.Drawing.Point(3, 6);
      this.mSourceLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.mSourceLabel.Name = "mSourceLabel";
      this.mSourceLabel.Size = new System.Drawing.Size(44, 13);
      this.mSourceLabel.TabIndex = 0;
      this.mSourceLabel.Text = "Source:";
      // 
      // mDestinationLabel
      // 
      this.mDestinationLabel.AutoSize = true;
      this.mDestinationLabel.Location = new System.Drawing.Point(3, 35);
      this.mDestinationLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.mDestinationLabel.Name = "mDestinationLabel";
      this.mDestinationLabel.Size = new System.Drawing.Size(63, 13);
      this.mDestinationLabel.TabIndex = 1;
      this.mDestinationLabel.Text = "Destination:";
      // 
      // mSourceFilePath
      // 
      this.mSourceFilePath.Dock = System.Windows.Forms.DockStyle.Top;
      this.mSourceFilePath.Location = new System.Drawing.Point(72, 3);
      this.mSourceFilePath.Name = "mSourceFilePath";
      this.mSourceFilePath.Size = new System.Drawing.Size(339, 20);
      this.mSourceFilePath.TabIndex = 2;
      this.mSourceFilePath.TextChanged += new System.EventHandler(this.SourceFilePath_TextChanged);
      // 
      // mDestinationFilePath
      // 
      this.mDestinationFilePath.Dock = System.Windows.Forms.DockStyle.Top;
      this.mDestinationFilePath.Location = new System.Drawing.Point(72, 32);
      this.mDestinationFilePath.Name = "mDestinationFilePath";
      this.mDestinationFilePath.Size = new System.Drawing.Size(339, 20);
      this.mDestinationFilePath.TabIndex = 3;
      this.mDestinationFilePath.TextChanged += new System.EventHandler(this.DestinationFilePath_TextChanged);
      // 
      // CmdSourceBrowse
      // 
      CmdSourceBrowse.AutoSize = true;
      CmdSourceBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      CmdSourceBrowse.Location = new System.Drawing.Point(417, 3);
      CmdSourceBrowse.Name = "CmdSourceBrowse";
      CmdSourceBrowse.Size = new System.Drawing.Size(26, 23);
      CmdSourceBrowse.TabIndex = 4;
      CmdSourceBrowse.Text = "...";
      CmdSourceBrowse.UseVisualStyleBackColor = true;
      CmdSourceBrowse.Click += new System.EventHandler(this.CmdSourceBrowse_Click);
      // 
      // CmdDestinationBrowse
      // 
      this.CmdDestinationBrowse.AutoSize = true;
      this.CmdDestinationBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.CmdDestinationBrowse.Location = new System.Drawing.Point(417, 32);
      this.CmdDestinationBrowse.Name = "CmdDestinationBrowse";
      this.CmdDestinationBrowse.Size = new System.Drawing.Size(26, 23);
      this.CmdDestinationBrowse.TabIndex = 5;
      this.CmdDestinationBrowse.Text = "...";
      this.CmdDestinationBrowse.UseVisualStyleBackColor = true;
      this.CmdDestinationBrowse.Click += new System.EventHandler(this.CmdDestinationBrowse_Click);
      // 
      // mExists
      // 
      this.mExists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.mExists.FormattingEnabled = true;
      this.mExists.Items.AddRange(new object[] {
            "No",
            "Yes"});
      this.mExists.Location = new System.Drawing.Point(72, 61);
      this.mExists.Name = "mExists";
      this.mExists.Size = new System.Drawing.Size(95, 21);
      this.mExists.TabIndex = 7;
      this.mExists.Visible = false;
      this.mExists.SelectedIndexChanged += new System.EventHandler(this.Exists_SelectedIndexChanged);
      // 
      // DualItemIOBase
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "DualItemIOBase";
      this.Size = new System.Drawing.Size(446, 239);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    protected System.Windows.Forms.TextBox mSourceFilePath;
    protected System.Windows.Forms.TextBox mDestinationFilePath;
    protected System.Windows.Forms.FolderBrowserDialog DirectorySelector;
    protected System.Windows.Forms.Label mSourceLabel;
    protected System.Windows.Forms.SaveFileDialog FileSelector;
    protected System.Windows.Forms.Label mExistsLabel;
    protected System.Windows.Forms.ComboBox mExists;
    protected System.Windows.Forms.Label mDestinationLabel;
    protected System.Windows.Forms.Button CmdDestinationBrowse;
  }
}
