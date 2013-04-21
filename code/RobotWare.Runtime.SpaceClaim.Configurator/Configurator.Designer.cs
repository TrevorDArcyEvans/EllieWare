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
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      System.Windows.Forms.Label label1;
      System.Windows.Forms.Label label2;
      System.Windows.Forms.Label label3;
      System.Windows.Forms.Label label4;
      System.Windows.Forms.Label label5;
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configurator));
      this.RibbonText = new System.Windows.Forms.TextBox();
      this.TabText = new System.Windows.Forms.TextBox();
      this.PanelText = new System.Windows.Forms.TextBox();
      this.PanelIcon = new System.Windows.Forms.PictureBox();
      this.Macros = new EllieWare.Support.RefreshingListBox();
      this.CmdAdd = new System.Windows.Forms.Button();
      this.CmdDelete = new System.Windows.Forms.Button();
      this.CmdUp = new System.Windows.Forms.Button();
      this.CmdDown = new System.Windows.Forms.Button();
      this.CmdSave = new System.Windows.Forms.Button();
      this.BrowseIcon = new System.Windows.Forms.OpenFileDialog();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      label1 = new System.Windows.Forms.Label();
      label2 = new System.Windows.Forms.Label();
      label3 = new System.Windows.Forms.Label();
      label4 = new System.Windows.Forms.Label();
      label5 = new System.Windows.Forms.Label();
      tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.PanelIcon)).BeginInit();
      tableLayoutPanel3.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.Controls.Add(label1, 0, 0);
      tableLayoutPanel1.Controls.Add(label2, 0, 1);
      tableLayoutPanel1.Controls.Add(label3, 0, 2);
      tableLayoutPanel1.Controls.Add(label4, 0, 3);
      tableLayoutPanel1.Controls.Add(this.RibbonText, 1, 0);
      tableLayoutPanel1.Controls.Add(this.TabText, 1, 1);
      tableLayoutPanel1.Controls.Add(this.PanelText, 1, 2);
      tableLayoutPanel1.Controls.Add(this.PanelIcon, 1, 3);
      tableLayoutPanel1.Controls.Add(label5, 0, 4);
      tableLayoutPanel1.Controls.Add(this.Macros, 1, 4);
      tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 2, 4);
      tableLayoutPanel1.Controls.Add(this.CmdSave, 1, 5);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 6;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(488, 362);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(3, 6);
      label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(68, 13);
      label1.TabIndex = 0;
      label1.Text = "Ribbon Text:";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new System.Drawing.Point(3, 32);
      label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(53, 13);
      label2.TabIndex = 2;
      label2.Text = "Tab Text:";
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new System.Drawing.Point(3, 58);
      label3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(61, 13);
      label3.TabIndex = 4;
      label3.Text = "Panel Text:";
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new System.Drawing.Point(3, 84);
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
      this.RibbonText.Location = new System.Drawing.Point(77, 3);
      this.RibbonText.Name = "RibbonText";
      this.RibbonText.Size = new System.Drawing.Size(408, 20);
      this.RibbonText.TabIndex = 1;
      this.RibbonText.TextChanged += new System.EventHandler(this.RibbonText_TextChanged);
      // 
      // TabText
      // 
      tableLayoutPanel1.SetColumnSpan(this.TabText, 2);
      this.TabText.Dock = System.Windows.Forms.DockStyle.Top;
      this.TabText.Location = new System.Drawing.Point(77, 29);
      this.TabText.Name = "TabText";
      this.TabText.Size = new System.Drawing.Size(408, 20);
      this.TabText.TabIndex = 3;
      this.TabText.TextChanged += new System.EventHandler(this.TabText_TextChanged);
      // 
      // PanelText
      // 
      tableLayoutPanel1.SetColumnSpan(this.PanelText, 2);
      this.PanelText.Dock = System.Windows.Forms.DockStyle.Top;
      this.PanelText.Location = new System.Drawing.Point(77, 55);
      this.PanelText.Name = "PanelText";
      this.PanelText.Size = new System.Drawing.Size(408, 20);
      this.PanelText.TabIndex = 5;
      this.PanelText.TextChanged += new System.EventHandler(this.PanelText_TextChanged);
      // 
      // PanelIcon
      // 
      this.PanelIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.PanelIcon.Location = new System.Drawing.Point(77, 81);
      this.PanelIcon.Name = "PanelIcon";
      this.PanelIcon.Size = new System.Drawing.Size(32, 32);
      this.PanelIcon.TabIndex = 7;
      this.PanelIcon.TabStop = false;
      this.PanelIcon.Click += new System.EventHandler(this.PanelIcon_Click);
      // 
      // label5
      // 
      label5.AutoSize = true;
      label5.Location = new System.Drawing.Point(3, 122);
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
      this.Macros.Location = new System.Drawing.Point(77, 119);
      this.Macros.Name = "Macros";
      this.Macros.Size = new System.Drawing.Size(356, 211);
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
      tableLayoutPanel3.Controls.Add(this.CmdAdd, 0, 0);
      tableLayoutPanel3.Controls.Add(this.CmdDelete, 0, 1);
      tableLayoutPanel3.Controls.Add(this.CmdUp, 0, 2);
      tableLayoutPanel3.Controls.Add(this.CmdDown, 0, 3);
      tableLayoutPanel3.Location = new System.Drawing.Point(439, 116);
      tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
      tableLayoutPanel3.Name = "tableLayoutPanel3";
      tableLayoutPanel3.RowCount = 4;
      tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel3.Size = new System.Drawing.Size(46, 184);
      tableLayoutPanel3.TabIndex = 12;
      // 
      // CmdAdd
      // 
      this.CmdAdd.Image = global::RobotWare.Runtime.SpaceClaim.Configurator.Properties.Resources.add_32x32;
      this.CmdAdd.Location = new System.Drawing.Point(3, 3);
      this.CmdAdd.Name = "CmdAdd";
      this.CmdAdd.Size = new System.Drawing.Size(40, 40);
      this.CmdAdd.TabIndex = 0;
      this.CmdAdd.UseVisualStyleBackColor = true;
      this.CmdAdd.Click += new System.EventHandler(this.CmdAdd_Click);
      // 
      // CmdDelete
      // 
      this.CmdDelete.Image = global::RobotWare.Runtime.SpaceClaim.Configurator.Properties.Resources.delete_32x32;
      this.CmdDelete.Location = new System.Drawing.Point(3, 49);
      this.CmdDelete.Name = "CmdDelete";
      this.CmdDelete.Size = new System.Drawing.Size(40, 40);
      this.CmdDelete.TabIndex = 1;
      this.CmdDelete.UseVisualStyleBackColor = true;
      this.CmdDelete.Click += new System.EventHandler(this.CmdDelete_Click);
      // 
      // CmdUp
      // 
      this.CmdUp.Image = global::RobotWare.Runtime.SpaceClaim.Configurator.Properties.Resources.arrow_up_green_32x32;
      this.CmdUp.Location = new System.Drawing.Point(3, 95);
      this.CmdUp.Name = "CmdUp";
      this.CmdUp.Size = new System.Drawing.Size(40, 40);
      this.CmdUp.TabIndex = 2;
      this.CmdUp.UseVisualStyleBackColor = true;
      this.CmdUp.Click += new System.EventHandler(this.CmdUp_Click);
      // 
      // CmdDown
      // 
      this.CmdDown.Image = global::RobotWare.Runtime.SpaceClaim.Configurator.Properties.Resources.arrow_down_green_32x32;
      this.CmdDown.Location = new System.Drawing.Point(3, 141);
      this.CmdDown.Name = "CmdDown";
      this.CmdDown.Size = new System.Drawing.Size(40, 40);
      this.CmdDown.TabIndex = 3;
      this.CmdDown.UseVisualStyleBackColor = true;
      this.CmdDown.Click += new System.EventHandler(this.CmdDown_Click);
      // 
      // CmdSave
      // 
      this.CmdSave.Dock = System.Windows.Forms.DockStyle.Right;
      this.CmdSave.Location = new System.Drawing.Point(358, 336);
      this.CmdSave.Name = "CmdSave";
      this.CmdSave.Size = new System.Drawing.Size(75, 23);
      this.CmdSave.TabIndex = 9;
      this.CmdSave.Text = "Save";
      this.CmdSave.UseVisualStyleBackColor = true;
      this.CmdSave.Click += new System.EventHandler(this.CmdSave_Click);
      // 
      // Configurator
      // 
      this.AcceptButton = this.CmdSave;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(488, 362);
      this.Controls.Add(tableLayoutPanel1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Configurator";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.PanelIcon)).EndInit();
      tableLayoutPanel3.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TextBox RibbonText;
    private System.Windows.Forms.TextBox TabText;
    private System.Windows.Forms.TextBox PanelText;
    private System.Windows.Forms.OpenFileDialog BrowseIcon;
    private System.Windows.Forms.PictureBox PanelIcon;
    private System.Windows.Forms.Button CmdSave;
    private RefreshingListBox Macros;
    private System.Windows.Forms.Button CmdAdd;
    private System.Windows.Forms.Button CmdDelete;
    private System.Windows.Forms.Button CmdUp;
    private System.Windows.Forms.Button CmdDown;
  }
}

