namespace EllieWare.IO
{
  partial class DirectoryCopy
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
      System.Windows.Forms.Label label1;
      System.Windows.Forms.Label label2;
      System.Windows.Forms.Button CmdSourceBrowse;
      System.Windows.Forms.Button CmdDestinationBrowse;
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.mSourceFilePath = new System.Windows.Forms.TextBox();
      this.mDestinationFilePath = new System.Windows.Forms.TextBox();
      this.DirectorySelector = new System.Windows.Forms.FolderBrowserDialog();
      label1 = new System.Windows.Forms.Label();
      label2 = new System.Windows.Forms.Label();
      CmdSourceBrowse = new System.Windows.Forms.Button();
      CmdDestinationBrowse = new System.Windows.Forms.Button();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(3, 6);
      label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(44, 13);
      label1.TabIndex = 0;
      label1.Text = "Source:";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new System.Drawing.Point(3, 35);
      label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(63, 13);
      label2.TabIndex = 1;
      label2.Text = "Destination:";
      // 
      // CmdSourceBrowse
      // 
      CmdSourceBrowse.AutoSize = true;
      CmdSourceBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      CmdSourceBrowse.Location = new System.Drawing.Point(355, 3);
      CmdSourceBrowse.Name = "CmdSourceBrowse";
      CmdSourceBrowse.Size = new System.Drawing.Size(26, 23);
      CmdSourceBrowse.TabIndex = 4;
      CmdSourceBrowse.Text = "...";
      CmdSourceBrowse.UseVisualStyleBackColor = true;
      CmdSourceBrowse.Click += new System.EventHandler(this.CmdSourceBrowse_Click);
      // 
      // CmdDestinationBrowse
      // 
      CmdDestinationBrowse.AutoSize = true;
      CmdDestinationBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      CmdDestinationBrowse.Location = new System.Drawing.Point(355, 32);
      CmdDestinationBrowse.Name = "CmdDestinationBrowse";
      CmdDestinationBrowse.Size = new System.Drawing.Size(26, 23);
      CmdDestinationBrowse.TabIndex = 5;
      CmdDestinationBrowse.Text = "...";
      CmdDestinationBrowse.UseVisualStyleBackColor = true;
      CmdDestinationBrowse.Click += new System.EventHandler(this.CmdDestinationBrowse_Click);
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 3;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.Controls.Add(label1, 0, 0);
      this.tableLayoutPanel1.Controls.Add(label2, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.mSourceFilePath, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.mDestinationFilePath, 1, 1);
      this.tableLayoutPanel1.Controls.Add(CmdSourceBrowse, 2, 0);
      this.tableLayoutPanel1.Controls.Add(CmdDestinationBrowse, 2, 1);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.Size = new System.Drawing.Size(384, 224);
      this.tableLayoutPanel1.TabIndex = 1;
      // 
      // mSourceFilePath
      // 
      this.mSourceFilePath.Dock = System.Windows.Forms.DockStyle.Top;
      this.mSourceFilePath.Location = new System.Drawing.Point(72, 3);
      this.mSourceFilePath.Name = "mSourceFilePath";
      this.mSourceFilePath.Size = new System.Drawing.Size(277, 20);
      this.mSourceFilePath.TabIndex = 2;
      this.mSourceFilePath.TextChanged += new System.EventHandler(this.SourceFilePath_TextChanged);
      // 
      // mDestinationFilePath
      // 
      this.mDestinationFilePath.Dock = System.Windows.Forms.DockStyle.Top;
      this.mDestinationFilePath.Location = new System.Drawing.Point(72, 32);
      this.mDestinationFilePath.Name = "mDestinationFilePath";
      this.mDestinationFilePath.Size = new System.Drawing.Size(277, 20);
      this.mDestinationFilePath.TabIndex = 3;
      this.mDestinationFilePath.TextChanged += new System.EventHandler(this.DestinationFilePath_TextChanged);
      // 
      // DirectoryCopy
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "DirectoryCopy";
      this.Size = new System.Drawing.Size(384, 224);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    protected System.Windows.Forms.TextBox mSourceFilePath;
    protected System.Windows.Forms.TextBox mDestinationFilePath;
    protected System.Windows.Forms.FolderBrowserDialog DirectorySelector;
  }
}
