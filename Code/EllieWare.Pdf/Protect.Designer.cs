//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace EllieWare.Pdf
{
  partial class Protect
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
      this.OwnerPasswordLabel = new System.Windows.Forms.Label();
      this.UserPasswordLabel = new System.Windows.Forms.Label();
      this.OptionsLabel = new System.Windows.Forms.Label();
      this.ProtectMain = new System.Windows.Forms.TableLayoutPanel();
      this.Options = new System.Windows.Forms.CheckedListBox();
      this.OwnerPassword = new EllieWare.Common.ParameterTextBox();
      this.UserPassword = new EllieWare.Common.ParameterTextBox();
      this.ProtectMain.SuspendLayout();
      this.SuspendLayout();
      // 
      // OwnerPasswordLabel
      // 
      this.OwnerPasswordLabel.AutoSize = true;
      this.OwnerPasswordLabel.Location = new System.Drawing.Point(3, 6);
      this.OwnerPasswordLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.OwnerPasswordLabel.Name = "OwnerPasswordLabel";
      this.OwnerPasswordLabel.Size = new System.Drawing.Size(90, 13);
      this.OwnerPasswordLabel.TabIndex = 0;
      this.OwnerPasswordLabel.Text = "Owner Password:";
      // 
      // UserPasswordLabel
      // 
      this.UserPasswordLabel.AutoSize = true;
      this.UserPasswordLabel.Location = new System.Drawing.Point(3, 32);
      this.UserPasswordLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.UserPasswordLabel.Name = "UserPasswordLabel";
      this.UserPasswordLabel.Size = new System.Drawing.Size(81, 13);
      this.UserPasswordLabel.TabIndex = 1;
      this.UserPasswordLabel.Text = "User Password:";
      // 
      // OptionsLabel
      // 
      this.OptionsLabel.AutoSize = true;
      this.OptionsLabel.Location = new System.Drawing.Point(3, 58);
      this.OptionsLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.OptionsLabel.Name = "OptionsLabel";
      this.OptionsLabel.Size = new System.Drawing.Size(46, 13);
      this.OptionsLabel.TabIndex = 5;
      this.OptionsLabel.Text = "Options:";
      // 
      // ProtectMain
      // 
      this.ProtectMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ProtectMain.ColumnCount = 2;
      this.ProtectMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.ProtectMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.ProtectMain.Controls.Add(this.OwnerPasswordLabel, 0, 0);
      this.ProtectMain.Controls.Add(this.UserPasswordLabel, 0, 1);
      this.ProtectMain.Controls.Add(this.Options, 1, 2);
      this.ProtectMain.Controls.Add(this.OwnerPassword, 1, 0);
      this.ProtectMain.Controls.Add(this.UserPassword, 1, 1);
      this.ProtectMain.Controls.Add(this.OptionsLabel, 0, 2);
      this.ProtectMain.Location = new System.Drawing.Point(3, 58);
      this.ProtectMain.Name = "ProtectMain";
      this.ProtectMain.RowCount = 3;
      this.ProtectMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.ProtectMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.ProtectMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.ProtectMain.Size = new System.Drawing.Size(443, 196);
      this.ProtectMain.TabIndex = 1;
      // 
      // Options
      // 
      this.Options.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Options.FormattingEnabled = true;
      this.Options.Items.AddRange(new object[] {
            "Permit Accessibility Extract Content",
            "Permit Annotations",
            "Permit Assemble Document",
            "Permit Extract Content",
            "Permit Forms Fill",
            "Permit Full Quality Print",
            "Permit Modify Document",
            "Permit Print"});
      this.Options.Location = new System.Drawing.Point(99, 55);
      this.Options.Name = "Options";
      this.Options.Size = new System.Drawing.Size(341, 138);
      this.Options.TabIndex = 2;
      this.Options.SelectedIndexChanged += new System.EventHandler(this.Options_SelectedIndexChanged);
      // 
      // OwnerPassword
      // 
      this.OwnerPassword.Dock = System.Windows.Forms.DockStyle.Top;
      this.OwnerPassword.Location = new System.Drawing.Point(99, 3);
      this.OwnerPassword.Name = "OwnerPassword";
      this.OwnerPassword.Size = new System.Drawing.Size(341, 20);
      this.OwnerPassword.TabIndex = 3;
      this.OwnerPassword.TextChanged += new System.EventHandler(this.OwnerPassword_TextChanged);
      // 
      // UserPassword
      // 
      this.UserPassword.Dock = System.Windows.Forms.DockStyle.Top;
      this.UserPassword.Location = new System.Drawing.Point(99, 29);
      this.UserPassword.Name = "UserPassword";
      this.UserPassword.Size = new System.Drawing.Size(341, 20);
      this.UserPassword.TabIndex = 4;
      this.UserPassword.TextChanged += new System.EventHandler(this.UserPassword_TextChanged);
      // 
      // Protect
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.ProtectMain);
      this.Name = "Protect";
      this.Size = new System.Drawing.Size(446, 257);
      this.ProtectMain.ResumeLayout(false);
      this.ProtectMain.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    protected System.Windows.Forms.TableLayoutPanel ProtectMain;
    protected System.Windows.Forms.CheckedListBox Options;
    protected Common.ParameterTextBox OwnerPassword;
    protected Common.ParameterTextBox UserPassword;
    protected System.Windows.Forms.Label OwnerPasswordLabel;
    protected System.Windows.Forms.Label OptionsLabel;
    protected System.Windows.Forms.Label UserPasswordLabel;
  }
}
