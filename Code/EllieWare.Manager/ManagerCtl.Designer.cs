//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//

using System.Security.AccessControl;

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
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      System.Windows.Forms.ToolTip ManagerTips;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagerCtl));
      this.CmdNew = new System.Windows.Forms.Button();
      this.CmdHelp = new System.Windows.Forms.Button();
      this.CmdEdit = new System.Windows.Forms.Button();
      this.CmdFavourites = new System.Windows.Forms.Button();
      this.CmdDelete = new System.Windows.Forms.Button();
      this.CmdRun = new System.Windows.Forms.Button();
      this.CmdAbout = new System.Windows.Forms.Button();
      this.MainTable = new System.Windows.Forms.TableLayoutPanel();
      this.mSpecs = new EllieWare.Manager.SpecificationCtl();
      this.mImages = new System.Windows.Forms.ImageList(this.components);
      this.Favourites = new System.Windows.Forms.ContextMenuStrip(this.components);
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      ManagerTips = new System.Windows.Forms.ToolTip(this.components);
      tableLayoutPanel1.SuspendLayout();
      this.MainTable.SuspendLayout();
      this.SuspendLayout();
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
      tableLayoutPanel1.Location = new System.Drawing.Point(758, 4);
      tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 9;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(61, 449);
      tableLayoutPanel1.TabIndex = 5;
      // 
      // CmdNew
      // 
      this.CmdNew.Image = global::EllieWare.Manager.Properties.Resources.gear_new_32x32;
      this.CmdNew.Location = new System.Drawing.Point(4, 61);
      this.CmdNew.Margin = new System.Windows.Forms.Padding(4);
      this.CmdNew.Name = "CmdNew";
      this.CmdNew.Size = new System.Drawing.Size(53, 49);
      this.CmdNew.TabIndex = 1;
      ManagerTips.SetToolTip(this.CmdNew, "New...");
      this.CmdNew.UseVisualStyleBackColor = true;
      this.CmdNew.Click += new System.EventHandler(this.CmdNew_Click);
      // 
      // CmdHelp
      // 
      this.CmdHelp.Image = global::EllieWare.Manager.Properties.Resources.lifebelt_32x32;
      this.CmdHelp.Location = new System.Drawing.Point(4, 339);
      this.CmdHelp.Margin = new System.Windows.Forms.Padding(4);
      this.CmdHelp.Name = "CmdHelp";
      this.CmdHelp.Size = new System.Drawing.Size(53, 49);
      this.CmdHelp.TabIndex = 5;
      ManagerTips.SetToolTip(this.CmdHelp, "Help...");
      this.CmdHelp.UseVisualStyleBackColor = true;
      this.CmdHelp.Click += new System.EventHandler(this.CmdHelp_Click);
      // 
      // CmdEdit
      // 
      this.CmdEdit.Image = global::EllieWare.Manager.Properties.Resources.gear_edit_32x32;
      this.CmdEdit.Location = new System.Drawing.Point(4, 118);
      this.CmdEdit.Margin = new System.Windows.Forms.Padding(4);
      this.CmdEdit.Name = "CmdEdit";
      this.CmdEdit.Size = new System.Drawing.Size(53, 49);
      this.CmdEdit.TabIndex = 2;
      ManagerTips.SetToolTip(this.CmdEdit, "Edit...");
      this.CmdEdit.UseVisualStyleBackColor = true;
      this.CmdEdit.Click += new System.EventHandler(this.CmdEdit_Click);
      // 
      // CmdFavourites
      // 
      this.CmdFavourites.Image = global::EllieWare.Manager.Properties.Resources.star_yellow_32x32;
      this.CmdFavourites.Location = new System.Drawing.Point(4, 4);
      this.CmdFavourites.Margin = new System.Windows.Forms.Padding(4);
      this.CmdFavourites.Name = "CmdFavourites";
      this.CmdFavourites.Size = new System.Drawing.Size(53, 49);
      this.CmdFavourites.TabIndex = 0;
      this.CmdFavourites.UseVisualStyleBackColor = true;
      this.CmdFavourites.Click += new System.EventHandler(this.CmdFavourites_Click);
      // 
      // CmdDelete
      // 
      this.CmdDelete.Image = global::EllieWare.Manager.Properties.Resources.gear_delete_32x32;
      this.CmdDelete.Location = new System.Drawing.Point(4, 175);
      this.CmdDelete.Margin = new System.Windows.Forms.Padding(4);
      this.CmdDelete.Name = "CmdDelete";
      this.CmdDelete.Size = new System.Drawing.Size(53, 49);
      this.CmdDelete.TabIndex = 3;
      ManagerTips.SetToolTip(this.CmdDelete, "Delete");
      this.CmdDelete.UseVisualStyleBackColor = true;
      this.CmdDelete.Click += new System.EventHandler(this.CmdDelete_Click);
      // 
      // CmdRun
      // 
      this.CmdRun.Image = global::EllieWare.Manager.Properties.Resources.gear_run_32x32;
      this.CmdRun.Location = new System.Drawing.Point(4, 257);
      this.CmdRun.Margin = new System.Windows.Forms.Padding(4);
      this.CmdRun.Name = "CmdRun";
      this.CmdRun.Size = new System.Drawing.Size(53, 49);
      this.CmdRun.TabIndex = 4;
      ManagerTips.SetToolTip(this.CmdRun, "Run");
      this.CmdRun.UseVisualStyleBackColor = true;
      this.CmdRun.Click += new System.EventHandler(this.CmdRun_Click);
      // 
      // CmdAbout
      // 
      this.CmdAbout.Image = global::EllieWare.Manager.Properties.Resources.robot_32x32;
      this.CmdAbout.Location = new System.Drawing.Point(4, 396);
      this.CmdAbout.Margin = new System.Windows.Forms.Padding(4);
      this.CmdAbout.Name = "CmdAbout";
      this.CmdAbout.Size = new System.Drawing.Size(53, 49);
      this.CmdAbout.TabIndex = 6;
      ManagerTips.SetToolTip(this.CmdAbout, "About...");
      this.CmdAbout.UseVisualStyleBackColor = true;
      this.CmdAbout.Click += new System.EventHandler(this.CmdAbout_Click);
      // 
      // MainTable
      // 
      this.MainTable.ColumnCount = 2;
      this.MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.MainTable.Controls.Add(tableLayoutPanel1, 1, 0);
      this.MainTable.Controls.Add(this.mSpecs, 0, 0);
      this.MainTable.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MainTable.Location = new System.Drawing.Point(0, 0);
      this.MainTable.Margin = new System.Windows.Forms.Padding(4);
      this.MainTable.Name = "MainTable";
      this.MainTable.RowCount = 1;
      this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.MainTable.Size = new System.Drawing.Size(823, 593);
      this.MainTable.TabIndex = 7;
      // 
      // mSpecs
      // 
      this.mSpecs.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mSpecs.Location = new System.Drawing.Point(3, 3);
      this.mSpecs.Name = "mSpecs";
      this.mSpecs.Size = new System.Drawing.Size(748, 587);
      this.mSpecs.TabIndex = 6;
      this.mSpecs.SelectedSpecificationChanged += new System.EventHandler(this.Specs_SelectedSpecificationChanged);
      this.mSpecs.SpecificationDoubleClick += new System.EventHandler(this.Specs_SpecificationDoubleClick);
      // 
      // mImages
      // 
      this.mImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("mImages.ImageStream")));
      this.mImages.TransparentColor = System.Drawing.Color.Transparent;
      this.mImages.Images.SetKeyName(0, "house_16x16.png");
      this.mImages.Images.SetKeyName(1, "clients_16x16.png");
      // 
      // Favourites
      // 
      this.Favourites.Name = "Favourites";
      this.Favourites.Size = new System.Drawing.Size(61, 4);
      this.Favourites.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Favourites_ItemClicked);
      // 
      // ManagerCtl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.MainTable);
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "ManagerCtl";
      this.Size = new System.Drawing.Size(823, 593);
      tableLayoutPanel1.ResumeLayout(false);
      this.MainTable.ResumeLayout(false);
      this.MainTable.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button CmdNew;
    private System.Windows.Forms.Button CmdHelp;
    private System.Windows.Forms.Button CmdEdit;
    private System.Windows.Forms.Button CmdDelete;
    private System.Windows.Forms.Button CmdRun;
    private System.Windows.Forms.Button CmdAbout;
    private System.Windows.Forms.Button CmdFavourites;
    private System.Windows.Forms.ContextMenuStrip Favourites;
    private System.Windows.Forms.ImageList mImages;
    private SpecificationCtl mSpecs;
    private System.Windows.Forms.TableLayoutPanel MainTable;
  }
}
