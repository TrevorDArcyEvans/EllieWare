//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace EllieWare.Common
{
  partial class RequestLicense
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
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      System.Windows.Forms.Button CmdCancel;
      System.Windows.Forms.Button CmdOK;
      System.Windows.Forms.Label label4;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequestLicense));
      this.Product = new System.Windows.Forms.TextBox();
      this.UserName = new System.Windows.Forms.TextBox();
      this.LicenseCode = new System.Windows.Forms.TextBox();
      this.Version = new System.Windows.Forms.TextBox();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      label1 = new System.Windows.Forms.Label();
      label2 = new System.Windows.Forms.Label();
      label3 = new System.Windows.Forms.Label();
      tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      CmdCancel = new System.Windows.Forms.Button();
      CmdOK = new System.Windows.Forms.Button();
      label4 = new System.Windows.Forms.Label();
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.Controls.Add(label1, 0, 0);
      tableLayoutPanel1.Controls.Add(label2, 0, 2);
      tableLayoutPanel1.Controls.Add(label3, 0, 3);
      tableLayoutPanel1.Controls.Add(this.Product, 1, 0);
      tableLayoutPanel1.Controls.Add(this.UserName, 1, 2);
      tableLayoutPanel1.Controls.Add(this.LicenseCode, 1, 3);
      tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 2, 4);
      tableLayoutPanel1.Controls.Add(label4, 0, 1);
      tableLayoutPanel1.Controls.Add(this.Version, 1, 1);
      tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 5;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(505, 141);
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
      label2.Location = new System.Drawing.Point(3, 58);
      label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(63, 13);
      label2.TabIndex = 2;
      label2.Text = "User Name:";
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new System.Drawing.Point(3, 84);
      label3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(75, 13);
      label3.TabIndex = 4;
      label3.Text = "License Code:";
      // 
      // Product
      // 
      tableLayoutPanel1.SetColumnSpan(this.Product, 2);
      this.Product.Dock = System.Windows.Forms.DockStyle.Top;
      this.Product.Location = new System.Drawing.Point(84, 3);
      this.Product.Name = "Product";
      this.Product.ReadOnly = true;
      this.Product.Size = new System.Drawing.Size(418, 20);
      this.Product.TabIndex = 1;
      // 
      // UserName
      // 
      tableLayoutPanel1.SetColumnSpan(this.UserName, 2);
      this.UserName.Dock = System.Windows.Forms.DockStyle.Top;
      this.UserName.Location = new System.Drawing.Point(84, 55);
      this.UserName.Name = "UserName";
      this.UserName.ReadOnly = true;
      this.UserName.Size = new System.Drawing.Size(418, 20);
      this.UserName.TabIndex = 3;
      // 
      // LicenseCode
      // 
      tableLayoutPanel1.SetColumnSpan(this.LicenseCode, 2);
      this.LicenseCode.Dock = System.Windows.Forms.DockStyle.Top;
      this.LicenseCode.Location = new System.Drawing.Point(84, 81);
      this.LicenseCode.Name = "LicenseCode";
      this.LicenseCode.Size = new System.Drawing.Size(418, 20);
      this.LicenseCode.TabIndex = 5;
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.AutoSize = true;
      tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      tableLayoutPanel2.ColumnCount = 2;
      tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel2.Controls.Add(CmdCancel, 1, 0);
      tableLayoutPanel2.Controls.Add(CmdOK, 0, 0);
      tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel2.Location = new System.Drawing.Point(340, 107);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 1;
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel2.Size = new System.Drawing.Size(162, 31);
      tableLayoutPanel2.TabIndex = 6;
      // 
      // CmdCancel
      // 
      CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      CmdCancel.Location = new System.Drawing.Point(84, 3);
      CmdCancel.Name = "CmdCancel";
      CmdCancel.Size = new System.Drawing.Size(75, 23);
      CmdCancel.TabIndex = 1;
      CmdCancel.Text = "Cancel";
      CmdCancel.UseVisualStyleBackColor = true;
      // 
      // CmdOK
      // 
      CmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      CmdOK.Location = new System.Drawing.Point(3, 3);
      CmdOK.Name = "CmdOK";
      CmdOK.Size = new System.Drawing.Size(75, 23);
      CmdOK.TabIndex = 0;
      CmdOK.Text = "OK";
      CmdOK.UseVisualStyleBackColor = true;
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new System.Drawing.Point(3, 32);
      label4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label4.Name = "label4";
      label4.Size = new System.Drawing.Size(45, 13);
      label4.TabIndex = 0;
      label4.Text = "Version:";
      // 
      // Version
      // 
      tableLayoutPanel1.SetColumnSpan(this.Version, 2);
      this.Version.Dock = System.Windows.Forms.DockStyle.Top;
      this.Version.Location = new System.Drawing.Point(84, 29);
      this.Version.Name = "Version";
      this.Version.ReadOnly = true;
      this.Version.Size = new System.Drawing.Size(418, 20);
      this.Version.TabIndex = 1;
      // 
      // RequestLicense
      // 
      this.AcceptButton = CmdOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = CmdCancel;
      this.ClientSize = new System.Drawing.Size(528, 162);
      this.Controls.Add(tableLayoutPanel1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MaximumSize = new System.Drawing.Size(2000, 200);
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(400, 200);
      this.Name = "RequestLicense";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Enter License Code";
      this.Shown += new System.EventHandler(this.RequestLicense_Shown);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      tableLayoutPanel2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    public System.Windows.Forms.TextBox Product;
    public System.Windows.Forms.TextBox UserName;
    public System.Windows.Forms.TextBox LicenseCode;
    public System.Windows.Forms.TextBox Version;
  }
}