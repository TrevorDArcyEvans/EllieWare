namespace EllieWare.Manager
{
  partial class Manager
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
      System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Spec1",
            "aaa"}, -1);
      System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Spec2",
            "bbb"}, -1);
      System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "Spec3",
            "ccc"}, -1);
      System.Windows.Forms.ColumnHeader columnHeader1;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manager));
      this.CmdNew = new System.Windows.Forms.Button();
      this.CmdEdit = new System.Windows.Forms.Button();
      this.CmdRun = new System.Windows.Forms.Button();
      this.CmdDebug = new System.Windows.Forms.Button();
      this.mSpecs = new System.Windows.Forms.ListView();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.CmdDelete = new System.Windows.Forms.Button();
      this.CmdHelp = new System.Windows.Forms.Button();
      columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.tableLayoutPanel1.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // CmdNew
      // 
      this.CmdNew.Location = new System.Drawing.Point(3, 3);
      this.CmdNew.Name = "CmdNew";
      this.CmdNew.Size = new System.Drawing.Size(75, 23);
      this.CmdNew.TabIndex = 0;
      this.CmdNew.Text = "New...";
      this.CmdNew.UseVisualStyleBackColor = true;
      this.CmdNew.Click += new System.EventHandler(this.CmdNew_Click);
      // 
      // CmdEdit
      // 
      this.CmdEdit.Location = new System.Drawing.Point(3, 32);
      this.CmdEdit.Name = "CmdEdit";
      this.CmdEdit.Size = new System.Drawing.Size(75, 23);
      this.CmdEdit.TabIndex = 1;
      this.CmdEdit.Text = "Edit...";
      this.CmdEdit.UseVisualStyleBackColor = true;
      this.CmdEdit.Click += new System.EventHandler(this.CmdEdit_Click);
      // 
      // CmdRun
      // 
      this.CmdRun.Location = new System.Drawing.Point(3, 110);
      this.CmdRun.Name = "CmdRun";
      this.CmdRun.Size = new System.Drawing.Size(75, 23);
      this.CmdRun.TabIndex = 2;
      this.CmdRun.Text = "Run...";
      this.CmdRun.UseVisualStyleBackColor = true;
      this.CmdRun.Click += new System.EventHandler(this.CmdRun_Click);
      // 
      // CmdDebug
      // 
      this.CmdDebug.Location = new System.Drawing.Point(3, 139);
      this.CmdDebug.Name = "CmdDebug";
      this.CmdDebug.Size = new System.Drawing.Size(75, 23);
      this.CmdDebug.TabIndex = 2;
      this.CmdDebug.Text = "Debug...";
      this.CmdDebug.UseVisualStyleBackColor = true;
      this.CmdDebug.Click += new System.EventHandler(this.CmdDebug_Click);
      // 
      // mSpecs
      // 
      this.mSpecs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.mSpecs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader1});
      this.mSpecs.FullRowSelect = true;
      this.mSpecs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.mSpecs.HideSelection = false;
      this.mSpecs.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
      this.mSpecs.Location = new System.Drawing.Point(3, 3);
      this.mSpecs.MultiSelect = false;
      this.mSpecs.Name = "mSpecs";
      this.mSpecs.Size = new System.Drawing.Size(552, 384);
      this.mSpecs.Sorting = System.Windows.Forms.SortOrder.Ascending;
      this.mSpecs.TabIndex = 4;
      this.mSpecs.UseCompatibleStateImageBehavior = false;
      this.mSpecs.View = System.Windows.Forms.View.Details;
      this.mSpecs.SelectedIndexChanged += new System.EventHandler(this.Specs_SelectedIndexChanged);
      this.mSpecs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Specs_MouseDoubleClick);
      // 
      // columnHeader1
      // 
      columnHeader1.Text = "Title";
      columnHeader1.Width = 500;
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.AutoSize = true;
      this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.Controls.Add(this.CmdNew, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.CmdEdit, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.CmdDelete, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.CmdDebug, 0, 5);
      this.tableLayoutPanel1.Controls.Add(this.CmdRun, 0, 4);
      this.tableLayoutPanel1.Controls.Add(this.CmdHelp, 0, 7);
      this.tableLayoutPanel1.Location = new System.Drawing.Point(561, 3);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 8;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.Size = new System.Drawing.Size(81, 214);
      this.tableLayoutPanel1.TabIndex = 5;
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tableLayoutPanel2.ColumnCount = 2;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 1, 0);
      this.tableLayoutPanel2.Controls.Add(this.mSpecs, 0, 0);
      this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 12);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 1;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(645, 390);
      this.tableLayoutPanel2.TabIndex = 6;
      // 
      // CmdDelete
      // 
      this.CmdDelete.Location = new System.Drawing.Point(3, 61);
      this.CmdDelete.Name = "CmdDelete";
      this.CmdDelete.Size = new System.Drawing.Size(75, 23);
      this.CmdDelete.TabIndex = 3;
      this.CmdDelete.Text = "Delete";
      this.CmdDelete.UseVisualStyleBackColor = true;
      this.CmdDelete.Click += new System.EventHandler(this.CmdDelete_Click);
      // 
      // CmdHelp
      // 
      this.CmdHelp.Location = new System.Drawing.Point(3, 188);
      this.CmdHelp.Name = "CmdHelp";
      this.CmdHelp.Size = new System.Drawing.Size(75, 23);
      this.CmdHelp.TabIndex = 2;
      this.CmdHelp.Text = "Help";
      this.CmdHelp.UseVisualStyleBackColor = true;
      this.CmdHelp.Click += new System.EventHandler(this.CmdHelp_Click);
      // 
      // Manager
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(669, 414);
      this.Controls.Add(this.tableLayoutPanel2);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Manager";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Manager";
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel2.ResumeLayout(false);
      this.tableLayoutPanel2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button CmdNew;
    private System.Windows.Forms.Button CmdEdit;
    private System.Windows.Forms.Button CmdRun;
    private System.Windows.Forms.Button CmdDebug;
    private System.Windows.Forms.ListView mSpecs;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.Button CmdDelete;
    private System.Windows.Forms.Button CmdHelp;
  }
}