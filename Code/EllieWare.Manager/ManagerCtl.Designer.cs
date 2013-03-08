//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace EllieWare.Manager
{
  partial class ManagerCtl
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
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagerCtl));
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      System.Windows.Forms.ToolTip ManagerTips;
      this.mSpecs = new System.Windows.Forms.ListView();
      this.FileOperations = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.FileOpCopy = new System.Windows.Forms.ToolStripMenuItem();
      this.FileOpRename = new System.Windows.Forms.ToolStripMenuItem();
      this.FileOpDelete = new System.Windows.Forms.ToolStripMenuItem();
      this.FileOpShow = new System.Windows.Forms.ToolStripMenuItem();
      this.mImages = new System.Windows.Forms.ImageList(this.components);
      this.SearchBox = new wmgCMS.WaterMarkTextBox();
      this.CmdNew = new System.Windows.Forms.Button();
      this.CmdHelp = new System.Windows.Forms.Button();
      this.CmdEdit = new System.Windows.Forms.Button();
      this.CmdDelete = new System.Windows.Forms.Button();
      this.CmdRun = new System.Windows.Forms.Button();
      this.CmdAbout = new System.Windows.Forms.Button();
      this.CmdFavourites = new System.Windows.Forms.Button();
      this.Favourites = new System.Windows.Forms.ContextMenuStrip(this.components);
      tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      ManagerTips = new System.Windows.Forms.ToolTip(this.components);
      tableLayoutPanel2.SuspendLayout();
      this.FileOperations.SuspendLayout();
      tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.ColumnCount = 2;
      tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel2.Controls.Add(this.mSpecs, 0, 1);
      tableLayoutPanel2.Controls.Add(tableLayoutPanel1, 1, 0);
      tableLayoutPanel2.Controls.Add(this.SearchBox, 0, 0);
      tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 2;
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel2.Size = new System.Drawing.Size(617, 482);
      tableLayoutPanel2.TabIndex = 7;
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
      this.mSpecs.Location = new System.Drawing.Point(3, 29);
      this.mSpecs.MultiSelect = false;
      this.mSpecs.Name = "mSpecs";
      this.mSpecs.Size = new System.Drawing.Size(559, 450);
      this.mSpecs.SmallImageList = this.mImages;
      this.mSpecs.Sorting = System.Windows.Forms.SortOrder.Ascending;
      this.mSpecs.TabIndex = 1;
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
      this.FileOperations.Size = new System.Drawing.Size(162, 92);
      this.FileOperations.Opening += new System.ComponentModel.CancelEventHandler(this.FileOperations_Opening);
      // 
      // FileOpCopy
      // 
      this.FileOpCopy.Name = "FileOpCopy";
      this.FileOpCopy.Size = new System.Drawing.Size(161, 22);
      this.FileOpCopy.Text = "Copy";
      this.FileOpCopy.Click += new System.EventHandler(this.FileOpCopy_Click);
      // 
      // FileOpRename
      // 
      this.FileOpRename.Name = "FileOpRename";
      this.FileOpRename.Size = new System.Drawing.Size(161, 22);
      this.FileOpRename.Text = "Rename...";
      this.FileOpRename.Click += new System.EventHandler(this.FileOpRename_Click);
      // 
      // FileOpDelete
      // 
      this.FileOpDelete.Name = "FileOpDelete";
      this.FileOpDelete.Size = new System.Drawing.Size(161, 22);
      this.FileOpDelete.Text = "Delete";
      this.FileOpDelete.Click += new System.EventHandler(this.FileOpDelete_Click);
      // 
      // FileOpShow
      // 
      this.FileOpShow.Name = "FileOpShow";
      this.FileOpShow.Size = new System.Drawing.Size(161, 22);
      this.FileOpShow.Text = "Show in Explorer";
      this.FileOpShow.Click += new System.EventHandler(this.FileOpShow_Click);
      // 
      // mImages
      // 
      this.mImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("mImages.ImageStream")));
      this.mImages.TransparentColor = System.Drawing.Color.Transparent;
      this.mImages.Images.SetKeyName(0, "house_16x16.png");
      this.mImages.Images.SetKeyName(1, "clients_16x16.png");
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.AutoSize = true;
      tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      tableLayoutPanel1.ColumnCount = 1;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.Controls.Add(this.CmdNew, 0, 1);
      tableLayoutPanel1.Controls.Add(this.CmdHelp, 0, 7);
      tableLayoutPanel1.Controls.Add(this.CmdEdit, 0, 2);
      tableLayoutPanel1.Controls.Add(this.CmdFavourites, 0, 0);
      tableLayoutPanel1.Controls.Add(this.CmdDelete, 0, 3);
      tableLayoutPanel1.Controls.Add(this.CmdRun, 0, 5);
      tableLayoutPanel1.Controls.Add(this.CmdAbout, 0, 8);
      tableLayoutPanel1.Location = new System.Drawing.Point(568, 3);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 9;
      tableLayoutPanel2.SetRowSpan(tableLayoutPanel1, 2);
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(46, 362);
      tableLayoutPanel1.TabIndex = 5;
      // 
      // SearchBox
      // 
      this.SearchBox.Dock = System.Windows.Forms.DockStyle.Top;
      this.SearchBox.Location = new System.Drawing.Point(3, 3);
      this.SearchBox.Name = "SearchBox";
      this.SearchBox.Size = new System.Drawing.Size(559, 20);
      this.SearchBox.TabIndex = 0;
      this.SearchBox.WaterMarkColor = System.Drawing.Color.Gray;
      this.SearchBox.WaterMarkText = "Search...";
      this.SearchBox.TextChanged += new System.EventHandler(this.Search_TextChanged);
      // 
      // CmdNew
      // 
      this.CmdNew.Image = global::EllieWare.Manager.Properties.Resources.gear_new_32x32;
      this.CmdNew.Location = new System.Drawing.Point(3, 49);
      this.CmdNew.Name = "CmdNew";
      this.CmdNew.Size = new System.Drawing.Size(40, 40);
      this.CmdNew.TabIndex = 1;
      ManagerTips.SetToolTip(this.CmdNew, "New...");
      this.CmdNew.UseVisualStyleBackColor = true;
      this.CmdNew.Click += new System.EventHandler(this.CmdNew_Click);
      // 
      // CmdHelp
      // 
      this.CmdHelp.Image = global::EllieWare.Manager.Properties.Resources.lifebelt_32x32;
      this.CmdHelp.Location = new System.Drawing.Point(3, 273);
      this.CmdHelp.Name = "CmdHelp";
      this.CmdHelp.Size = new System.Drawing.Size(40, 40);
      this.CmdHelp.TabIndex = 5;
      ManagerTips.SetToolTip(this.CmdHelp, "Help...");
      this.CmdHelp.UseVisualStyleBackColor = true;
      this.CmdHelp.Click += new System.EventHandler(this.CmdHelp_Click);
      // 
      // CmdEdit
      // 
      this.CmdEdit.Image = global::EllieWare.Manager.Properties.Resources.gear_edit_32x32;
      this.CmdEdit.Location = new System.Drawing.Point(3, 95);
      this.CmdEdit.Name = "CmdEdit";
      this.CmdEdit.Size = new System.Drawing.Size(40, 40);
      this.CmdEdit.TabIndex = 2;
      ManagerTips.SetToolTip(this.CmdEdit, "Edit...");
      this.CmdEdit.UseVisualStyleBackColor = true;
      this.CmdEdit.Click += new System.EventHandler(this.CmdEdit_Click);
      // 
      // CmdDelete
      // 
      this.CmdDelete.Image = global::EllieWare.Manager.Properties.Resources.gear_delete_32x32;
      this.CmdDelete.Location = new System.Drawing.Point(3, 141);
      this.CmdDelete.Name = "CmdDelete";
      this.CmdDelete.Size = new System.Drawing.Size(40, 40);
      this.CmdDelete.TabIndex = 3;
      ManagerTips.SetToolTip(this.CmdDelete, "Delete");
      this.CmdDelete.UseVisualStyleBackColor = true;
      this.CmdDelete.Click += new System.EventHandler(this.CmdDelete_Click);
      // 
      // CmdRun
      // 
      this.CmdRun.Image = global::EllieWare.Manager.Properties.Resources.gear_run_32x32;
      this.CmdRun.Location = new System.Drawing.Point(3, 207);
      this.CmdRun.Name = "CmdRun";
      this.CmdRun.Size = new System.Drawing.Size(40, 40);
      this.CmdRun.TabIndex = 4;
      ManagerTips.SetToolTip(this.CmdRun, "Run");
      this.CmdRun.UseVisualStyleBackColor = true;
      this.CmdRun.Click += new System.EventHandler(this.CmdRun_Click);
      // 
      // CmdAbout
      // 
      this.CmdAbout.Image = global::EllieWare.Manager.Properties.Resources.robot_32x32;
      this.CmdAbout.Location = new System.Drawing.Point(3, 319);
      this.CmdAbout.Name = "CmdAbout";
      this.CmdAbout.Size = new System.Drawing.Size(40, 40);
      this.CmdAbout.TabIndex = 6;
      ManagerTips.SetToolTip(this.CmdAbout, "About...");
      this.CmdAbout.UseVisualStyleBackColor = true;
      this.CmdAbout.Click += new System.EventHandler(this.CmdAbout_Click);
      // 
      // CmdFavourites
      // 
      this.CmdFavourites.Image = global::EllieWare.Manager.Properties.Resources.star_yellow_32x32;
      this.CmdFavourites.Location = new System.Drawing.Point(3, 3);
      this.CmdFavourites.Name = "CmdFavourites";
      this.CmdFavourites.Size = new System.Drawing.Size(40, 40);
      this.CmdFavourites.TabIndex = 0;
      this.CmdFavourites.UseVisualStyleBackColor = true;
      this.CmdFavourites.Click += new System.EventHandler(this.CmdFavourites_Click);
      // 
      // Favourites
      // 
      this.Favourites.Name = "Favourites";
      this.Favourites.Size = new System.Drawing.Size(61, 4);
      this.Favourites.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Favourites_ItemClicked);
      // 
      // ManagerCtl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(tableLayoutPanel2);
      this.Name = "ManagerCtl";
      this.Size = new System.Drawing.Size(617, 482);
      tableLayoutPanel2.ResumeLayout(false);
      tableLayoutPanel2.PerformLayout();
      this.FileOperations.ResumeLayout(false);
      tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListView mSpecs;
    private System.Windows.Forms.Button CmdNew;
    private System.Windows.Forms.Button CmdHelp;
    private System.Windows.Forms.Button CmdEdit;
    private System.Windows.Forms.Button CmdDelete;
    private System.Windows.Forms.Button CmdRun;
    private System.Windows.Forms.Button CmdAbout;
    private wmgCMS.WaterMarkTextBox SearchBox;
    private System.Windows.Forms.ContextMenuStrip FileOperations;
    private System.Windows.Forms.ToolStripMenuItem FileOpCopy;
    private System.Windows.Forms.ToolStripMenuItem FileOpRename;
    private System.Windows.Forms.ToolStripMenuItem FileOpDelete;
    private System.Windows.Forms.ToolStripMenuItem FileOpShow;
    private System.Windows.Forms.Button CmdFavourites;
    private System.Windows.Forms.ContextMenuStrip Favourites;
    private System.Windows.Forms.ImageList mImages;
  }
}
