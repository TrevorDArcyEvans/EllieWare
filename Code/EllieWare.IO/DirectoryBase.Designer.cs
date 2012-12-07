namespace EllieWare.IO
{
  partial class DirectoryBase
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
      this.DirectorySelector = new System.Windows.Forms.FolderBrowserDialog();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.CmdBrowse = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.mDirectory = new System.Windows.Forms.TextBox();
      this.lblExists = new System.Windows.Forms.Label();
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
      this.tableLayoutPanel1.Controls.Add(this.CmdBrowse, 2, 0);
      this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.mDirectory, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.lblExists, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.mExists, 1, 1);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.Size = new System.Drawing.Size(324, 150);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // CmdBrowse
      // 
      this.CmdBrowse.AutoSize = true;
      this.CmdBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.CmdBrowse.Location = new System.Drawing.Point(295, 3);
      this.CmdBrowse.Name = "CmdBrowse";
      this.CmdBrowse.Size = new System.Drawing.Size(26, 23);
      this.CmdBrowse.TabIndex = 0;
      this.CmdBrowse.Text = "...";
      this.CmdBrowse.UseVisualStyleBackColor = true;
      this.CmdBrowse.Click += new System.EventHandler(this.CmdBrowse_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 6);
      this.label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(52, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Directory:";
      // 
      // mDirectory
      // 
      this.mDirectory.Dock = System.Windows.Forms.DockStyle.Top;
      this.mDirectory.Location = new System.Drawing.Point(61, 3);
      this.mDirectory.Name = "mDirectory";
      this.mDirectory.Size = new System.Drawing.Size(228, 20);
      this.mDirectory.TabIndex = 2;
      this.mDirectory.TextChanged += new System.EventHandler(this.Directory_TextChanged);
      // 
      // lblExists
      // 
      this.lblExists.AutoSize = true;
      this.lblExists.Location = new System.Drawing.Point(3, 35);
      this.lblExists.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.lblExists.Name = "lblExists";
      this.lblExists.Size = new System.Drawing.Size(37, 13);
      this.lblExists.TabIndex = 4;
      this.lblExists.Text = "Exists:";
      // 
      // mExists
      // 
      this.mExists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.mExists.FormattingEnabled = true;
      this.mExists.Items.AddRange(new object[] {
            "No",
            "Yes"});
      this.mExists.Location = new System.Drawing.Point(61, 32);
      this.mExists.Name = "mExists";
      this.mExists.Size = new System.Drawing.Size(95, 21);
      this.mExists.TabIndex = 5;
      this.mExists.SelectedIndexChanged += new System.EventHandler(this.Exists_SelectedIndexChanged);
      // 
      // DirectoryBase
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "DirectoryBase";
      this.Size = new System.Drawing.Size(324, 150);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Button CmdBrowse;
    private System.Windows.Forms.Label label1;
    protected System.Windows.Forms.FolderBrowserDialog DirectorySelector;
    protected System.Windows.Forms.Label lblExists;
    protected System.Windows.Forms.ComboBox mExists;
    protected System.Windows.Forms.TextBox mDirectory;
  }
}
