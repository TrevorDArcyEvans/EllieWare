//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace RobotWare.Runtime.Windows.Configurator
{
  sealed partial class Configurator
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
      System.Windows.Forms.ToolTip EditorTip;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configurator));
      this.Macros = new System.Windows.Forms.ComboBox();
      this.CmdSave = new System.Windows.Forms.Button();
      this.BrowseIcon = new System.Windows.Forms.OpenFileDialog();
      this.BrowseOutput = new System.Windows.Forms.FolderBrowserDialog();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      label4 = new System.Windows.Forms.Label();
      EditorTip = new System.Windows.Forms.ToolTip(this.components);
      tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.AutoSize = true;
      tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.Controls.Add(label4, 0, 0);
      tableLayoutPanel1.Controls.Add(this.Macros, 1, 0);
      tableLayoutPanel1.Controls.Add(this.CmdSave, 2, 1);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 2;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(484, 58);
      tableLayoutPanel1.TabIndex = 1;
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new System.Drawing.Point(3, 6);
      label4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label4.Name = "label4";
      label4.Size = new System.Drawing.Size(40, 13);
      label4.TabIndex = 5;
      label4.Text = "Macro:";
      // 
      // Macros
      // 
      tableLayoutPanel1.SetColumnSpan(this.Macros, 2);
      this.Macros.Dock = System.Windows.Forms.DockStyle.Top;
      this.Macros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.Macros.FormattingEnabled = true;
      this.Macros.Location = new System.Drawing.Point(49, 3);
      this.Macros.Name = "Macros";
      this.Macros.Size = new System.Drawing.Size(432, 21);
      this.Macros.TabIndex = 6;
      // 
      // CmdSave
      // 
      this.CmdSave.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.CmdSave.Enabled = false;
      this.CmdSave.Location = new System.Drawing.Point(406, 30);
      this.CmdSave.Name = "CmdSave";
      this.CmdSave.Size = new System.Drawing.Size(75, 23);
      this.CmdSave.TabIndex = 0;
      this.CmdSave.Text = "Save";
      this.CmdSave.UseVisualStyleBackColor = true;
      this.CmdSave.Click += new System.EventHandler(this.CmdSave_Click);
      // 
      // BrowseOutput
      // 
      this.BrowseOutput.Description = "Select output folder";
      // 
      // Configurator
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(484, 58);
      this.Controls.Add(tableLayoutPanel1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximumSize = new System.Drawing.Size(2000, 97);
      this.MinimumSize = new System.Drawing.Size(200, 97);
      this.Name = "Configurator";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    public System.Windows.Forms.ComboBox Macros;
    private System.Windows.Forms.Button CmdSave;
    public System.Windows.Forms.OpenFileDialog BrowseIcon;
    private System.Windows.Forms.FolderBrowserDialog BrowseOutput;
  }
}

