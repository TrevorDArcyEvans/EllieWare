//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace EllieWare.Manager
{
  partial class SpecificationCtl
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
      this.mSpecs = new System.Windows.Forms.ListView();
      this.FileOperations = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.FileOpCopy = new System.Windows.Forms.ToolStripMenuItem();
      this.FileOpRename = new System.Windows.Forms.ToolStripMenuItem();
      this.FileOpDelete = new System.Windows.Forms.ToolStripMenuItem();
      this.FileOpShow = new System.Windows.Forms.ToolStripMenuItem();
      this.SearchBox = new wmgCMS.WaterMarkTextBox();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      tableLayoutPanel1.SuspendLayout();
      this.FileOperations.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 1;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.Controls.Add(this.mSpecs, 0, 1);
      tableLayoutPanel1.Controls.Add(this.SearchBox, 0, 0);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 2;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.Size = new System.Drawing.Size(648, 448);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // mSpecs
      // 
      this.mSpecs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader1});
      this.mSpecs.ContextMenuStrip = this.FileOperations;
      this.mSpecs.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mSpecs.FullRowSelect = true;
      this.mSpecs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.mSpecs.HideSelection = false;
      this.mSpecs.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
      this.mSpecs.Location = new System.Drawing.Point(4, 34);
      this.mSpecs.Margin = new System.Windows.Forms.Padding(4);
      this.mSpecs.MultiSelect = false;
      this.mSpecs.Name = "mSpecs";
      this.mSpecs.Size = new System.Drawing.Size(640, 410);
      this.mSpecs.Sorting = System.Windows.Forms.SortOrder.Ascending;
      this.mSpecs.TabIndex = 2;
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
      // FileOperations
      // 
      this.FileOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileOpCopy,
            this.FileOpRename,
            this.FileOpDelete,
            this.FileOpShow});
      this.FileOperations.Name = "FileOperations";
      this.FileOperations.Size = new System.Drawing.Size(190, 100);
      this.FileOperations.Opening += new System.ComponentModel.CancelEventHandler(this.FileOperations_Opening);
      // 
      // FileOpCopy
      // 
      this.FileOpCopy.Name = "FileOpCopy";
      this.FileOpCopy.Size = new System.Drawing.Size(189, 24);
      this.FileOpCopy.Text = "Copy";
      this.FileOpCopy.Click += new System.EventHandler(this.FileOpCopy_Click);
      // 
      // FileOpRename
      // 
      this.FileOpRename.Name = "FileOpRename";
      this.FileOpRename.Size = new System.Drawing.Size(189, 24);
      this.FileOpRename.Text = "Rename...";
      this.FileOpRename.Click += new System.EventHandler(this.FileOpRename_Click);
      // 
      // FileOpDelete
      // 
      this.FileOpDelete.Name = "FileOpDelete";
      this.FileOpDelete.Size = new System.Drawing.Size(189, 24);
      this.FileOpDelete.Text = "Delete";
      this.FileOpDelete.Click += new System.EventHandler(this.FileOpDelete_Click);
      // 
      // FileOpShow
      // 
      this.FileOpShow.Name = "FileOpShow";
      this.FileOpShow.Size = new System.Drawing.Size(189, 24);
      this.FileOpShow.Text = "Show in Explorer";
      this.FileOpShow.Click += new System.EventHandler(this.FileOpShow_Click);
      // 
      // SearchBox
      // 
      this.SearchBox.Dock = System.Windows.Forms.DockStyle.Top;
      this.SearchBox.Location = new System.Drawing.Point(4, 4);
      this.SearchBox.Margin = new System.Windows.Forms.Padding(4);
      this.SearchBox.Name = "SearchBox";
      this.SearchBox.Size = new System.Drawing.Size(640, 22);
      this.SearchBox.TabIndex = 1;
      this.SearchBox.WaterMarkColor = System.Drawing.Color.Gray;
      this.SearchBox.WaterMarkText = "Search...";
      this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
      // 
      // SpecificationCtl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(tableLayoutPanel1);
      this.Name = "SpecificationCtl";
      this.Size = new System.Drawing.Size(648, 448);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      this.FileOperations.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private wmgCMS.WaterMarkTextBox SearchBox;
    private System.Windows.Forms.ListView mSpecs;
    private System.Windows.Forms.ContextMenuStrip FileOperations;
    private System.Windows.Forms.ToolStripMenuItem FileOpCopy;
    private System.Windows.Forms.ToolStripMenuItem FileOpRename;
    private System.Windows.Forms.ToolStripMenuItem FileOpDelete;
    private System.Windows.Forms.ToolStripMenuItem FileOpShow;

  }
}
