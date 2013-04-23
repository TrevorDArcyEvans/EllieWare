//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace RobotWare.Runtime.SpaceClaim.Configurator
{
  partial class CommandConfigEditor
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
      System.Windows.Forms.Label label1;
      System.Windows.Forms.Label label2;
      System.Windows.Forms.Label label3;
      System.Windows.Forms.Label label4;
      System.Windows.Forms.ToolTip EditorTip;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandConfigEditor));
      this.CmdText = new System.Windows.Forms.TextBox();
      this.CmdIco = new System.Windows.Forms.PictureBox();
      this.CmdHint = new System.Windows.Forms.TextBox();
      this.Macros = new System.Windows.Forms.ComboBox();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.CmdOK = new System.Windows.Forms.Button();
      this.CmdCancel = new System.Windows.Forms.Button();
      this.BrowseIcon = new System.Windows.Forms.OpenFileDialog();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      label1 = new System.Windows.Forms.Label();
      label2 = new System.Windows.Forms.Label();
      label3 = new System.Windows.Forms.Label();
      label4 = new System.Windows.Forms.Label();
      EditorTip = new System.Windows.Forms.ToolTip(this.components);
      tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.CmdIco)).BeginInit();
      this.tableLayoutPanel2.SuspendLayout();
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
      tableLayoutPanel1.Controls.Add(label1, 0, 0);
      tableLayoutPanel1.Controls.Add(label2, 0, 1);
      tableLayoutPanel1.Controls.Add(label3, 0, 2);
      tableLayoutPanel1.Controls.Add(label4, 0, 3);
      tableLayoutPanel1.Controls.Add(this.CmdText, 1, 0);
      tableLayoutPanel1.Controls.Add(this.CmdIco, 1, 1);
      tableLayoutPanel1.Controls.Add(this.CmdHint, 1, 2);
      tableLayoutPanel1.Controls.Add(this.Macros, 1, 3);
      tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 4);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 5;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      tableLayoutPanel1.Size = new System.Drawing.Size(497, 154);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(3, 6);
      label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(31, 13);
      label1.TabIndex = 0;
      label1.Text = "Text:";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new System.Drawing.Point(3, 32);
      label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(31, 13);
      label2.TabIndex = 2;
      label2.Text = "Icon:";
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new System.Drawing.Point(3, 70);
      label3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(42, 13);
      label3.TabIndex = 3;
      label3.Text = "Tooltip:";
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new System.Drawing.Point(3, 96);
      label4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label4.Name = "label4";
      label4.Size = new System.Drawing.Size(40, 13);
      label4.TabIndex = 5;
      label4.Text = "Macro:";
      // 
      // CmdText
      // 
      tableLayoutPanel1.SetColumnSpan(this.CmdText, 2);
      this.CmdText.Dock = System.Windows.Forms.DockStyle.Top;
      this.CmdText.Location = new System.Drawing.Point(51, 3);
      this.CmdText.Name = "CmdText";
      this.CmdText.Size = new System.Drawing.Size(443, 20);
      this.CmdText.TabIndex = 1;
      this.CmdText.TextChanged += new System.EventHandler(this.CmdText_TextChanged);
      // 
      // CmdIco
      // 
      this.CmdIco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.CmdIco.Location = new System.Drawing.Point(51, 29);
      this.CmdIco.Name = "CmdIco";
      this.CmdIco.Size = new System.Drawing.Size(32, 32);
      this.CmdIco.TabIndex = 5;
      this.CmdIco.TabStop = false;
      EditorTip.SetToolTip(this.CmdIco, "Select icon...");
      this.CmdIco.Click += new System.EventHandler(this.CmdIco_Click);
      // 
      // CmdHint
      // 
      tableLayoutPanel1.SetColumnSpan(this.CmdHint, 2);
      this.CmdHint.Dock = System.Windows.Forms.DockStyle.Top;
      this.CmdHint.Location = new System.Drawing.Point(51, 67);
      this.CmdHint.Name = "CmdHint";
      this.CmdHint.Size = new System.Drawing.Size(443, 20);
      this.CmdHint.TabIndex = 4;
      this.CmdHint.TextChanged += new System.EventHandler(this.CmdHint_TextChanged);
      // 
      // Macros
      // 
      tableLayoutPanel1.SetColumnSpan(this.Macros, 2);
      this.Macros.Dock = System.Windows.Forms.DockStyle.Top;
      this.Macros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.Macros.FormattingEnabled = true;
      this.Macros.Location = new System.Drawing.Point(51, 93);
      this.Macros.Name = "Macros";
      this.Macros.Size = new System.Drawing.Size(443, 21);
      this.Macros.TabIndex = 6;
      this.Macros.SelectedIndexChanged += new System.EventHandler(this.Macros_SelectedIndexChanged);
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
      this.tableLayoutPanel2.Location = new System.Drawing.Point(332, 120);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 1;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel2.Size = new System.Drawing.Size(162, 29);
      this.tableLayoutPanel2.TabIndex = 8;
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
      // CommandConfigEditor
      // 
      this.AcceptButton = this.CmdOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.CmdCancel;
      this.ClientSize = new System.Drawing.Size(497, 154);
      this.Controls.Add(tableLayoutPanel1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MaximumSize = new System.Drawing.Size(2000, 192);
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(300, 192);
      this.Name = "CommandConfigEditor";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Create new macro";
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.CmdIco)).EndInit();
      this.tableLayoutPanel2.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox CmdIco;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.Button CmdOK;
    private System.Windows.Forms.Button CmdCancel;
    public System.Windows.Forms.TextBox CmdText;
    public System.Windows.Forms.TextBox CmdHint;
    public System.Windows.Forms.ComboBox Macros;
    public System.Windows.Forms.OpenFileDialog BrowseIcon;
  }
}