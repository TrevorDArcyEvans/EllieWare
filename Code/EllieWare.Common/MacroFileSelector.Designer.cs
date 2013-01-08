//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using wmgCMS;

namespace EllieWare.Common
{
  partial class MacroFileSelector
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
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MacroFileSelector));
      this.mSpecs = new System.Windows.Forms.ListView();
      this.SearchBox = new wmgCMS.WaterMarkTextBox();
      this.CmdCancel = new System.Windows.Forms.Button();
      this.CmdOK = new System.Windows.Forms.Button();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      tableLayoutPanel1.ColumnCount = 2;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      tableLayoutPanel1.Controls.Add(this.mSpecs, 0, 1);
      tableLayoutPanel1.Controls.Add(this.SearchBox, 0, 0);
      tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 2);
      tableLayoutPanel1.Location = new System.Drawing.Point(13, 13);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 3;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(572, 328);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // mSpecs
      // 
      this.mSpecs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader1});
      tableLayoutPanel1.SetColumnSpan(this.mSpecs, 2);
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
      this.mSpecs.Size = new System.Drawing.Size(566, 261);
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
      // SearchBox
      // 
      tableLayoutPanel1.SetColumnSpan(this.SearchBox, 2);
      this.SearchBox.Dock = System.Windows.Forms.DockStyle.Top;
      this.SearchBox.Location = new System.Drawing.Point(3, 3);
      this.SearchBox.Name = "SearchBox";
      this.SearchBox.Size = new System.Drawing.Size(566, 20);
      this.SearchBox.TabIndex = 1;
      this.SearchBox.WaterMarkColor = System.Drawing.Color.Gray;
      this.SearchBox.WaterMarkText = "Search...";
      this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.AutoSize = true;
      tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      tableLayoutPanel2.ColumnCount = 2;
      tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel2.Controls.Add(this.CmdCancel, 1, 0);
      tableLayoutPanel2.Controls.Add(this.CmdOK, 0, 0);
      tableLayoutPanel2.Location = new System.Drawing.Point(407, 296);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 1;
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel2.Size = new System.Drawing.Size(162, 29);
      tableLayoutPanel2.TabIndex = 5;
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
      // MacroFileSelector
      // 
      this.AcceptButton = this.CmdOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.CmdCancel;
      this.ClientSize = new System.Drawing.Size(597, 353);
      this.Controls.Add(tableLayoutPanel1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "MacroFileSelector";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Select File";
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      tableLayoutPanel2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button CmdOK;
    private System.Windows.Forms.Button CmdCancel;
    private WaterMarkTextBox SearchBox;
    private System.Windows.Forms.ListView mSpecs;
  }
}