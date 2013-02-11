//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace EllieWare.LicenseGenerator
{
  partial class LicenseGenerator
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
      System.Windows.Forms.Button CmdGenerate;
      System.Windows.Forms.Label label4;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LicenseGenerator));
      this.Product = new System.Windows.Forms.ComboBox();
      this.UserName = new System.Windows.Forms.TextBox();
      this.LicenseCode = new System.Windows.Forms.TextBox();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.CmdRegister = new System.Windows.Forms.Button();
      this.CmdUnregister = new System.Windows.Forms.Button();
      this.CmdIsRegistered = new System.Windows.Forms.Button();
      this.Version = new System.Windows.Forms.ComboBox();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      label1 = new System.Windows.Forms.Label();
      label2 = new System.Windows.Forms.Label();
      label3 = new System.Windows.Forms.Label();
      CmdGenerate = new System.Windows.Forms.Button();
      label4 = new System.Windows.Forms.Label();
      tableLayoutPanel1.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      this.SuspendLayout();
      //
      // tableLayoutPanel1
      //
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.Controls.Add(label1, 0, 0);
      tableLayoutPanel1.Controls.Add(label2, 0, 2);
      tableLayoutPanel1.Controls.Add(this.Product, 1, 0);
      tableLayoutPanel1.Controls.Add(this.UserName, 1, 2);
      tableLayoutPanel1.Controls.Add(this.LicenseCode, 1, 3);
      tableLayoutPanel1.Controls.Add(label3, 0, 3);
      tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 4);
      tableLayoutPanel1.Controls.Add(label4, 0, 1);
      tableLayoutPanel1.Controls.Add(this.Version, 1, 1);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 5;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(450, 142);
      tableLayoutPanel1.TabIndex = 0;
      //
      // label1
      //
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(3, 6);
      label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(47, 13);
      label1.TabIndex = 0;
      label1.Text = "Product:";
      //
      // label2
      //
      label2.AutoSize = true;
      label2.Location = new System.Drawing.Point(3, 60);
      label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(63, 13);
      label2.TabIndex = 1;
      label2.Text = "User Name:";
      //
      // Product
      //
      tableLayoutPanel1.SetColumnSpan(this.Product, 2);
      this.Product.Dock = System.Windows.Forms.DockStyle.Top;
      this.Product.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.Product.FormattingEnabled = true;
      this.Product.Items.AddRange(new object[] {
            "RobotWare for Windows",
            "RobotWare for SpaceClaim"});
      this.Product.Location = new System.Drawing.Point(72, 3);
      this.Product.Name = "Product";
      this.Product.Size = new System.Drawing.Size(375, 21);
      this.Product.TabIndex = 2;
      this.Product.SelectedIndexChanged += new System.EventHandler(this.Product_SelectedIndexChanged);
      //
      // UserName
      //
      tableLayoutPanel1.SetColumnSpan(this.UserName, 2);
      this.UserName.Dock = System.Windows.Forms.DockStyle.Top;
      this.UserName.Location = new System.Drawing.Point(72, 57);
      this.UserName.Name = "UserName";
      this.UserName.Size = new System.Drawing.Size(375, 20);
      this.UserName.TabIndex = 3;
      this.UserName.TextChanged += new System.EventHandler(this.UserName_TextChanged);
      //
      // LicenseCode
      //
      tableLayoutPanel1.SetColumnSpan(this.LicenseCode, 2);
      this.LicenseCode.Dock = System.Windows.Forms.DockStyle.Top;
      this.LicenseCode.Location = new System.Drawing.Point(72, 83);
      this.LicenseCode.Name = "LicenseCode";
      this.LicenseCode.ReadOnly = true;
      this.LicenseCode.Size = new System.Drawing.Size(375, 20);
      this.LicenseCode.TabIndex = 4;
      //
      // label3
      //
      label3.AutoSize = true;
      label3.Location = new System.Drawing.Point(3, 86);
      label3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(35, 13);
      label3.TabIndex = 6;
      label3.Text = "Code:";
      //
      // tableLayoutPanel2
      //
      this.tableLayoutPanel2.AutoSize = true;
      this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.tableLayoutPanel2.ColumnCount = 4;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel2.Controls.Add(CmdGenerate, 3, 0);
      this.tableLayoutPanel2.Controls.Add(this.CmdRegister, 2, 0);
      this.tableLayoutPanel2.Controls.Add(this.CmdUnregister, 1, 0);
      this.tableLayoutPanel2.Controls.Add(this.CmdIsRegistered, 0, 0);
      this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel2.Location = new System.Drawing.Point(123, 109);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 1;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(324, 30);
      this.tableLayoutPanel2.TabIndex = 7;
      //
      // CmdGenerate
      //
      CmdGenerate.Location = new System.Drawing.Point(246, 3);
      CmdGenerate.Name = "CmdGenerate";
      CmdGenerate.Size = new System.Drawing.Size(75, 23);
      CmdGenerate.TabIndex = 5;
      CmdGenerate.Text = "Generate";
      CmdGenerate.UseVisualStyleBackColor = true;
      CmdGenerate.Click += new System.EventHandler(this.CmdGenerate_Click);
      //
      // CmdRegister
      //
      this.CmdRegister.Location = new System.Drawing.Point(165, 3);
      this.CmdRegister.Name = "CmdRegister";
      this.CmdRegister.Size = new System.Drawing.Size(75, 23);
      this.CmdRegister.TabIndex = 6;
      this.CmdRegister.Text = "Register";
      this.CmdRegister.UseVisualStyleBackColor = true;
      this.CmdRegister.Click += new System.EventHandler(this.CmdRegister_Click);
      //
      // CmdUnregister
      //
      this.CmdUnregister.Location = new System.Drawing.Point(84, 3);
      this.CmdUnregister.Name = "CmdUnregister";
      this.CmdUnregister.Size = new System.Drawing.Size(75, 23);
      this.CmdUnregister.TabIndex = 7;
      this.CmdUnregister.Text = "Unregister";
      this.CmdUnregister.UseVisualStyleBackColor = true;
      this.CmdUnregister.Click += new System.EventHandler(this.CmdUnregister_Click);
      //
      // CmdIsRegistered
      //
      this.CmdIsRegistered.Location = new System.Drawing.Point(3, 3);
      this.CmdIsRegistered.Name = "CmdIsRegistered";
      this.CmdIsRegistered.Size = new System.Drawing.Size(75, 23);
      this.CmdIsRegistered.TabIndex = 8;
      this.CmdIsRegistered.Text = "Check";
      this.CmdIsRegistered.UseVisualStyleBackColor = true;
      this.CmdIsRegistered.Click += new System.EventHandler(this.CmdIsRegistered_Click);
      //
      // label4
      //
      label4.AutoSize = true;
      label4.Location = new System.Drawing.Point(3, 33);
      label4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label4.Name = "label4";
      label4.Size = new System.Drawing.Size(45, 13);
      label4.TabIndex = 8;
      label4.Text = "Version:";
      //
      // Version
      //
      tableLayoutPanel1.SetColumnSpan(this.Version, 2);
      this.Version.Dock = System.Windows.Forms.DockStyle.Top;
      this.Version.FormattingEnabled = true;
      this.Version.Items.AddRange(new object[] {
            "1.0.0",
            "2.0.0"});
      this.Version.Location = new System.Drawing.Point(72, 30);
      this.Version.Name = "Version";
      this.Version.Size = new System.Drawing.Size(375, 21);
      this.Version.TabIndex = 9;
      //
      // LicenseGenerator
      //
      this.AcceptButton = CmdGenerate;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(450, 142);
      this.Controls.Add(tableLayoutPanel1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MaximumSize = new System.Drawing.Size(2000, 180);
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(466, 180);
      this.Name = "LicenseGenerator";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.Text = "EllieWare License Generator";
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      this.tableLayoutPanel2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ComboBox Product;
    private System.Windows.Forms.TextBox UserName;
    private System.Windows.Forms.TextBox LicenseCode;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.Button CmdRegister;
    private System.Windows.Forms.Button CmdUnregister;
    private System.Windows.Forms.Button CmdIsRegistered;
    private System.Windows.Forms.ComboBox Version;
  }
}


