//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using wmgCMS;

namespace EllieWare.Common
{
  partial class Adder
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
      System.Windows.Forms.Label label1;
      System.Windows.Forms.Label label2;
      System.Windows.Forms.Label label3;
      System.Windows.Forms.Label label4;
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Adder));
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.CmdOK = new System.Windows.Forms.Button();
      this.CmdCancel = new System.Windows.Forms.Button();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.txtDescription = new System.Windows.Forms.TextBox();
      this.SearchBox = new wmgCMS.WaterMarkTextBox();
      this.lbSteps = new System.Windows.Forms.ListBox();
      this.ddlCategories = new System.Windows.Forms.ComboBox();
      label1 = new System.Windows.Forms.Label();
      label2 = new System.Windows.Forms.Label();
      label3 = new System.Windows.Forms.Label();
      label4 = new System.Windows.Forms.Label();
      tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel3.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
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
      label1.Text = "Search:";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new System.Drawing.Point(3, 32);
      label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(52, 13);
      label2.TabIndex = 2;
      label2.Text = "Category:";
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new System.Drawing.Point(3, 59);
      label3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(32, 13);
      label3.TabIndex = 4;
      label3.Text = "Step:";
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new System.Drawing.Point(3, 270);
      label4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label4.Name = "label4";
      label4.Size = new System.Drawing.Size(63, 13);
      label4.TabIndex = 6;
      label4.Text = "Description:";
      // 
      // tableLayoutPanel3
      // 
      tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      tableLayoutPanel3.ColumnCount = 2;
      tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 1, 1);
      tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 0);
      tableLayoutPanel3.Location = new System.Drawing.Point(12, 12);
      tableLayoutPanel3.Name = "tableLayoutPanel3";
      tableLayoutPanel3.RowCount = 2;
      tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel3.Size = new System.Drawing.Size(440, 396);
      tableLayoutPanel3.TabIndex = 10;
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.AutoSize = true;
      this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.tableLayoutPanel2.ColumnCount = 2;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel2.Controls.Add(this.CmdOK, 0, 0);
      this.tableLayoutPanel2.Controls.Add(this.CmdCancel, 1, 0);
      this.tableLayoutPanel2.Location = new System.Drawing.Point(275, 364);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 1;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel2.Size = new System.Drawing.Size(162, 29);
      this.tableLayoutPanel2.TabIndex = 9;
      // 
      // CmdOK
      // 
      this.CmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
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
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.tableLayoutPanel1.ColumnCount = 2;
      tableLayoutPanel3.SetColumnSpan(this.tableLayoutPanel1, 2);
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.Controls.Add(label1, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.txtDescription, 1, 3);
      this.tableLayoutPanel1.Controls.Add(label4, 0, 3);
      this.tableLayoutPanel1.Controls.Add(this.SearchBox, 1, 0);
      this.tableLayoutPanel1.Controls.Add(label3, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.lbSteps, 1, 2);
      this.tableLayoutPanel1.Controls.Add(label2, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.ddlCategories, 1, 1);
      this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 4;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(434, 355);
      this.tableLayoutPanel1.TabIndex = 8;
      // 
      // txtDescription
      // 
      this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtDescription.Location = new System.Drawing.Point(72, 267);
      this.txtDescription.Multiline = true;
      this.txtDescription.Name = "txtDescription";
      this.txtDescription.ReadOnly = true;
      this.txtDescription.Size = new System.Drawing.Size(359, 85);
      this.txtDescription.TabIndex = 7;
      // 
      // SearchBox
      // 
      this.SearchBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SearchBox.Location = new System.Drawing.Point(72, 3);
      this.SearchBox.Name = "SearchBox";
      this.SearchBox.Size = new System.Drawing.Size(359, 20);
      this.SearchBox.TabIndex = 1;
      this.SearchBox.WaterMarkColor = System.Drawing.Color.Gray;
      this.SearchBox.WaterMarkText = "Search...";
      this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
      // 
      // lbSteps
      // 
      this.lbSteps.DisplayMember = "Title";
      this.lbSteps.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lbSteps.FormattingEnabled = true;
      this.lbSteps.Location = new System.Drawing.Point(72, 56);
      this.lbSteps.Name = "lbSteps";
      this.lbSteps.Size = new System.Drawing.Size(359, 205);
      this.lbSteps.Sorted = true;
      this.lbSteps.TabIndex = 5;
      this.lbSteps.SelectedIndexChanged += new System.EventHandler(this.Steps_SelectedIndexChanged);
      this.lbSteps.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Steps_MouseDoubleClick);
      // 
      // ddlCategories
      // 
      this.ddlCategories.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ddlCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.ddlCategories.FormattingEnabled = true;
      this.ddlCategories.Location = new System.Drawing.Point(72, 29);
      this.ddlCategories.Name = "ddlCategories";
      this.ddlCategories.Size = new System.Drawing.Size(359, 21);
      this.ddlCategories.Sorted = true;
      this.ddlCategories.TabIndex = 3;
      this.ddlCategories.SelectedIndexChanged += new System.EventHandler(this.Categories_SelectedIndexChanged);
      // 
      // Adder
      // 
      this.AcceptButton = this.CmdOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.CmdCancel;
      this.ClientSize = new System.Drawing.Size(464, 420);
      this.Controls.Add(tableLayoutPanel3);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Adder";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Add Step";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Adder_FormClosed);
      this.Load += new System.EventHandler(this.Adder_Load);
      this.Shown += new System.EventHandler(this.Adder_Shown);
      tableLayoutPanel3.ResumeLayout(false);
      tableLayoutPanel3.PerformLayout();
      this.tableLayoutPanel2.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button CmdCancel;
    private System.Windows.Forms.Button CmdOK;
    private WaterMarkTextBox SearchBox;
    private System.Windows.Forms.ComboBox ddlCategories;
    private System.Windows.Forms.ListBox lbSteps;
    private System.Windows.Forms.TextBox txtDescription;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
  }
}