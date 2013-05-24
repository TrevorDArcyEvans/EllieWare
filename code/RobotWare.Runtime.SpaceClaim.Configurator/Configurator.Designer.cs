//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Support;

namespace RobotWare.Runtime.SpaceClaim.Configurator
{
  partial class Configurator
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
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      System.Windows.Forms.Label label4;
      System.Windows.Forms.Label label5;
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
      System.Windows.Forms.ToolStrip toolStrip1;
      System.Windows.Forms.ToolStripButton CmdOpen;
      System.Windows.Forms.ToolStripButton CmdAbout;
      System.Windows.Forms.ToolStripButton CmdExit;
      System.Windows.Forms.Label label3;
      System.Windows.Forms.Label label2;
      System.Windows.Forms.Label label1;
      System.Windows.Forms.ToolTip CfgTip;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configurator));
      this.RibbonText = new System.Windows.Forms.TextBox();
      this.TabText = new System.Windows.Forms.TextBox();
      this.PanelText = new System.Windows.Forms.TextBox();
      this.Macros = new EllieWare.Support.RefreshingListBox();
      this.CmdAdd = new System.Windows.Forms.Button();
      this.CmdDelete = new System.Windows.Forms.Button();
      this.CmdUp = new System.Windows.Forms.Button();
      this.CmdDown = new System.Windows.Forms.Button();
      this.CmdEdit = new System.Windows.Forms.Button();
      this.CmdSave = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.CmdCreate = new System.Windows.Forms.Button();
      this.PanelIcon = new System.Windows.Forms.PictureBox();
      this.BrowseIcon = new System.Windows.Forms.OpenFileDialog();
      this.BrowseOutput = new System.Windows.Forms.FolderBrowserDialog();
      this.OpenFileDlg = new System.Windows.Forms.OpenFileDialog();
      this.SaveFileDlg = new System.Windows.Forms.SaveFileDialog();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      label4 = new System.Windows.Forms.Label();
      label5 = new System.Windows.Forms.Label();
      tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
      toolStrip1 = new System.Windows.Forms.ToolStrip();
      CmdOpen = new System.Windows.Forms.ToolStripButton();
      CmdAbout = new System.Windows.Forms.ToolStripButton();
      CmdExit = new System.Windows.Forms.ToolStripButton();
      label3 = new System.Windows.Forms.Label();
      label2 = new System.Windows.Forms.Label();
      label1 = new System.Windows.Forms.Label();
      CfgTip = new System.Windows.Forms.ToolTip(this.components);
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel3.SuspendLayout();
      toolStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.PanelIcon)).BeginInit();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.Controls.Add(label4, 0, 4);
      tableLayoutPanel1.Controls.Add(this.RibbonText, 1, 1);
      tableLayoutPanel1.Controls.Add(this.TabText, 1, 2);
      tableLayoutPanel1.Controls.Add(this.PanelText, 1, 3);
      tableLayoutPanel1.Controls.Add(label5, 0, 5);
      tableLayoutPanel1.Controls.Add(this.Macros, 1, 5);
      tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 2, 5);
      tableLayoutPanel1.Controls.Add(toolStrip1, 0, 0);
      tableLayoutPanel1.Controls.Add(this.CmdCreate, 1, 6);
      tableLayoutPanel1.Controls.Add(label3, 0, 3);
      tableLayoutPanel1.Controls.Add(label2, 0, 2);
      tableLayoutPanel1.Controls.Add(label1, 0, 1);
      tableLayoutPanel1.Controls.Add(this.PanelIcon, 1, 4);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 7;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(488, 453);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new System.Drawing.Point(3, 130);
      label4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label4.Name = "label4";
      label4.Size = new System.Drawing.Size(61, 13);
      label4.TabIndex = 6;
      label4.Text = "Panel Icon:";
      // 
      // RibbonText
      // 
      tableLayoutPanel1.SetColumnSpan(this.RibbonText, 2);
      this.RibbonText.Dock = System.Windows.Forms.DockStyle.Top;
      this.RibbonText.Location = new System.Drawing.Point(77, 49);
      this.RibbonText.Name = "RibbonText";
      this.RibbonText.Size = new System.Drawing.Size(408, 20);
      this.RibbonText.TabIndex = 1;
      this.RibbonText.TextChanged += new System.EventHandler(this.RibbonText_TextChanged);
      // 
      // TabText
      // 
      tableLayoutPanel1.SetColumnSpan(this.TabText, 2);
      this.TabText.Dock = System.Windows.Forms.DockStyle.Top;
      this.TabText.Location = new System.Drawing.Point(77, 75);
      this.TabText.Name = "TabText";
      this.TabText.Size = new System.Drawing.Size(408, 20);
      this.TabText.TabIndex = 3;
      this.TabText.TextChanged += new System.EventHandler(this.TabText_TextChanged);
      // 
      // PanelText
      // 
      tableLayoutPanel1.SetColumnSpan(this.PanelText, 2);
      this.PanelText.Dock = System.Windows.Forms.DockStyle.Top;
      this.PanelText.Location = new System.Drawing.Point(77, 101);
      this.PanelText.Name = "PanelText";
      this.PanelText.Size = new System.Drawing.Size(408, 20);
      this.PanelText.TabIndex = 5;
      this.PanelText.TextChanged += new System.EventHandler(this.PanelText_TextChanged);
      // 
      // label5
      // 
      label5.AutoSize = true;
      label5.Location = new System.Drawing.Point(3, 168);
      label5.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label5.Name = "label5";
      label5.Size = new System.Drawing.Size(45, 13);
      label5.TabIndex = 7;
      label5.Text = "Macros:";
      // 
      // Macros
      // 
      this.Macros.DisplayMember = "Text";
      this.Macros.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Macros.FormattingEnabled = true;
      this.Macros.Location = new System.Drawing.Point(77, 165);
      this.Macros.Name = "Macros";
      this.Macros.Size = new System.Drawing.Size(356, 256);
      this.Macros.TabIndex = 8;
      this.Macros.SelectedIndexChanged += new System.EventHandler(this.Macros_SelectedIndexChanged);
      this.Macros.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Macros_MouseDoubleClick);
      // 
      // tableLayoutPanel3
      // 
      tableLayoutPanel3.AutoSize = true;
      tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      tableLayoutPanel3.ColumnCount = 1;
      tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel3.Controls.Add(this.CmdAdd, 0, 1);
      tableLayoutPanel3.Controls.Add(this.CmdDelete, 0, 2);
      tableLayoutPanel3.Controls.Add(this.CmdUp, 0, 3);
      tableLayoutPanel3.Controls.Add(this.CmdDown, 0, 4);
      tableLayoutPanel3.Controls.Add(this.CmdEdit, 0, 0);
      tableLayoutPanel3.Location = new System.Drawing.Point(439, 162);
      tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
      tableLayoutPanel3.Name = "tableLayoutPanel3";
      tableLayoutPanel3.RowCount = 5;
      tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      tableLayoutPanel3.Size = new System.Drawing.Size(46, 230);
      tableLayoutPanel3.TabIndex = 12;
      // 
      // CmdAdd
      // 
      this.CmdAdd.Image = global::RobotWare.Runtime.SpaceClaim.Configurator.Properties.Resources.add_32x32;
      this.CmdAdd.Location = new System.Drawing.Point(3, 49);
      this.CmdAdd.Name = "CmdAdd";
      this.CmdAdd.Size = new System.Drawing.Size(40, 40);
      this.CmdAdd.TabIndex = 1;
      CfgTip.SetToolTip(this.CmdAdd, "Add...");
      this.CmdAdd.UseVisualStyleBackColor = true;
      this.CmdAdd.Click += new System.EventHandler(this.CmdAdd_Click);
      // 
      // CmdDelete
      // 
      this.CmdDelete.Enabled = false;
      this.CmdDelete.Image = global::RobotWare.Runtime.SpaceClaim.Configurator.Properties.Resources.delete_32x32;
      this.CmdDelete.Location = new System.Drawing.Point(3, 95);
      this.CmdDelete.Name = "CmdDelete";
      this.CmdDelete.Size = new System.Drawing.Size(40, 40);
      this.CmdDelete.TabIndex = 2;
      CfgTip.SetToolTip(this.CmdDelete, "Delete");
      this.CmdDelete.UseVisualStyleBackColor = true;
      this.CmdDelete.Click += new System.EventHandler(this.CmdDelete_Click);
      // 
      // CmdUp
      // 
      this.CmdUp.Enabled = false;
      this.CmdUp.Image = global::RobotWare.Runtime.SpaceClaim.Configurator.Properties.Resources.arrow_up_green_32x32;
      this.CmdUp.Location = new System.Drawing.Point(3, 141);
      this.CmdUp.Name = "CmdUp";
      this.CmdUp.Size = new System.Drawing.Size(40, 40);
      this.CmdUp.TabIndex = 3;
      CfgTip.SetToolTip(this.CmdUp, "Move up");
      this.CmdUp.UseVisualStyleBackColor = true;
      this.CmdUp.Click += new System.EventHandler(this.CmdUp_Click);
      // 
      // CmdDown
      // 
      this.CmdDown.Enabled = false;
      this.CmdDown.Image = global::RobotWare.Runtime.SpaceClaim.Configurator.Properties.Resources.arrow_down_green_32x32;
      this.CmdDown.Location = new System.Drawing.Point(3, 187);
      this.CmdDown.Name = "CmdDown";
      this.CmdDown.Size = new System.Drawing.Size(40, 40);
      this.CmdDown.TabIndex = 4;
      CfgTip.SetToolTip(this.CmdDown, "Move down");
      this.CmdDown.UseVisualStyleBackColor = true;
      this.CmdDown.Click += new System.EventHandler(this.CmdDown_Click);
      // 
      // CmdEdit
      // 
      this.CmdEdit.Enabled = false;
      this.CmdEdit.Image = global::RobotWare.Runtime.SpaceClaim.Configurator.Properties.Resources.edit_32x32;
      this.CmdEdit.Location = new System.Drawing.Point(3, 3);
      this.CmdEdit.Name = "CmdEdit";
      this.CmdEdit.Size = new System.Drawing.Size(40, 40);
      this.CmdEdit.TabIndex = 0;
      CfgTip.SetToolTip(this.CmdEdit, "Edit...");
      this.CmdEdit.UseVisualStyleBackColor = true;
      this.CmdEdit.Click += new System.EventHandler(this.CmdEdit_Click);
      // 
      // toolStrip1
      // 
      tableLayoutPanel1.SetColumnSpan(toolStrip1, 3);
      toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
      toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
      toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmdSave,
            CmdOpen,
            CmdAbout,
            this.toolStripSeparator1,
            CmdExit});
      toolStrip1.Location = new System.Drawing.Point(0, 0);
      toolStrip1.Name = "toolStrip1";
      toolStrip1.Padding = new System.Windows.Forms.Padding(0);
      toolStrip1.Size = new System.Drawing.Size(488, 46);
      toolStrip1.TabIndex = 14;
      toolStrip1.Text = "toolStrip1";
      // 
      // CmdSave
      // 
      this.CmdSave.AutoSize = false;
      this.CmdSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.CmdSave.Enabled = false;
      this.CmdSave.Image = global::RobotWare.Runtime.SpaceClaim.Configurator.Properties.Resources.floppy_disk_32x32;
      this.CmdSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.CmdSave.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.CmdSave.Margin = new System.Windows.Forms.Padding(3);
      this.CmdSave.Name = "CmdSave";
      this.CmdSave.Size = new System.Drawing.Size(40, 40);
      this.CmdSave.ToolTipText = "Save configuration...";
      this.CmdSave.Click += new System.EventHandler(this.CmdSave_Click);
      // 
      // CmdOpen
      // 
      CmdOpen.AutoSize = false;
      CmdOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      CmdOpen.Image = global::RobotWare.Runtime.SpaceClaim.Configurator.Properties.Resources.folder_document_32x32;
      CmdOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      CmdOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
      CmdOpen.Margin = new System.Windows.Forms.Padding(3);
      CmdOpen.Name = "CmdOpen";
      CmdOpen.Size = new System.Drawing.Size(40, 40);
      CmdOpen.ToolTipText = "Open configuration...";
      CmdOpen.Click += new System.EventHandler(this.CmdOpen_Click);
      // 
      // CmdAbout
      // 
      CmdAbout.AutoSize = false;
      CmdAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      CmdAbout.Image = global::RobotWare.Runtime.SpaceClaim.Configurator.Properties.Resources.robot;
      CmdAbout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      CmdAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
      CmdAbout.Margin = new System.Windows.Forms.Padding(3);
      CmdAbout.Name = "CmdAbout";
      CmdAbout.Size = new System.Drawing.Size(40, 40);
      CmdAbout.ToolTipText = "About...";
      CmdAbout.Click += new System.EventHandler(this.CmdAbout_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 46);
      // 
      // CmdExit
      // 
      CmdExit.AutoSize = false;
      CmdExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      CmdExit.Image = global::RobotWare.Runtime.SpaceClaim.Configurator.Properties.Resources.exit_32x32;
      CmdExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      CmdExit.ImageTransparentColor = System.Drawing.Color.Magenta;
      CmdExit.Margin = new System.Windows.Forms.Padding(3);
      CmdExit.Name = "CmdExit";
      CmdExit.Size = new System.Drawing.Size(40, 40);
      CmdExit.ToolTipText = "Exit";
      CmdExit.Click += new System.EventHandler(this.CmdExit_Click);
      // 
      // CmdCreate
      // 
      this.CmdCreate.Dock = System.Windows.Forms.DockStyle.Right;
      this.CmdCreate.Enabled = false;
      this.CmdCreate.Location = new System.Drawing.Point(358, 427);
      this.CmdCreate.Name = "CmdCreate";
      this.CmdCreate.Size = new System.Drawing.Size(75, 23);
      this.CmdCreate.TabIndex = 9;
      this.CmdCreate.Text = "Create...";
      this.CmdCreate.UseVisualStyleBackColor = true;
      this.CmdCreate.Click += new System.EventHandler(this.CmdCreate_Click);
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new System.Drawing.Point(3, 104);
      label3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(61, 13);
      label3.TabIndex = 4;
      label3.Text = "Panel Text:";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new System.Drawing.Point(3, 78);
      label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(53, 13);
      label2.TabIndex = 2;
      label2.Text = "Tab Text:";
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(3, 52);
      label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(68, 13);
      label1.TabIndex = 0;
      label1.Text = "Ribbon Text:";
      // 
      // PanelIcon
      // 
      this.PanelIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.PanelIcon.Location = new System.Drawing.Point(77, 127);
      this.PanelIcon.Name = "PanelIcon";
      this.PanelIcon.Size = new System.Drawing.Size(32, 32);
      this.PanelIcon.TabIndex = 7;
      this.PanelIcon.TabStop = false;
      CfgTip.SetToolTip(this.PanelIcon, "Select icon...");
      this.PanelIcon.Click += new System.EventHandler(this.PanelIcon_Click);
      // 
      // BrowseOutput
      // 
      this.BrowseOutput.Description = "Select output folder";
      // 
      // OpenFileDlg
      // 
      this.OpenFileDlg.DefaultExt = "xml";
      this.OpenFileDlg.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
      // 
      // SaveFileDlg
      // 
      this.SaveFileDlg.DefaultExt = "xml";
      this.SaveFileDlg.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
      // 
      // Configurator
      // 
      this.AcceptButton = this.CmdCreate;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(488, 453);
      this.Controls.Add(tableLayoutPanel1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MinimumSize = new System.Drawing.Size(300, 471);
      this.Name = "Configurator";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Configurator_FormClosing);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      tableLayoutPanel3.ResumeLayout(false);
      toolStrip1.ResumeLayout(false);
      toolStrip1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.PanelIcon)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TextBox RibbonText;
    private System.Windows.Forms.TextBox TabText;
    private System.Windows.Forms.TextBox PanelText;
    private System.Windows.Forms.OpenFileDialog BrowseIcon;
    private System.Windows.Forms.PictureBox PanelIcon;
    private System.Windows.Forms.Button CmdCreate;
    private RefreshingListBox Macros;
    private System.Windows.Forms.Button CmdAdd;
    private System.Windows.Forms.Button CmdDelete;
    private System.Windows.Forms.Button CmdUp;
    private System.Windows.Forms.Button CmdDown;
    private System.Windows.Forms.FolderBrowserDialog BrowseOutput;
    private System.Windows.Forms.Button CmdEdit;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripButton CmdSave;
    private System.Windows.Forms.OpenFileDialog OpenFileDlg;
    private System.Windows.Forms.SaveFileDialog SaveFileDlg;
  }
}

