//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace EllieWare.Common
{
  partial class AboutBox
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
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
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
      System.Windows.Forms.Button okButton;
      this.AppImage = new System.Windows.Forms.PictureBox();
      this.labelProductName = new System.Windows.Forms.Label();
      this.labelVersion = new System.Windows.Forms.Label();
      this.labelCopyright = new System.Windows.Forms.Label();
      this.labelCompanyName = new System.Windows.Forms.Label();
      this.textBoxDescription = new System.Windows.Forms.TextBox();
      tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
      okButton = new System.Windows.Forms.Button();
      tableLayoutPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.AppImage)).BeginInit();
      this.SuspendLayout();
      // 
      // tableLayoutPanel
      // 
      tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      tableLayoutPanel.ColumnCount = 2;
      tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
      tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel.Controls.Add(this.AppImage, 0, 0);
      tableLayoutPanel.Controls.Add(this.labelProductName, 1, 0);
      tableLayoutPanel.Controls.Add(this.labelVersion, 1, 1);
      tableLayoutPanel.Controls.Add(this.labelCopyright, 1, 2);
      tableLayoutPanel.Controls.Add(this.labelCompanyName, 1, 3);
      tableLayoutPanel.Controls.Add(this.textBoxDescription, 1, 4);
      tableLayoutPanel.Controls.Add(okButton, 1, 5);
      tableLayoutPanel.Location = new System.Drawing.Point(9, 9);
      tableLayoutPanel.Name = "tableLayoutPanel";
      tableLayoutPanel.RowCount = 6;
      tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel.Size = new System.Drawing.Size(566, 278);
      tableLayoutPanel.TabIndex = 0;
      // 
      // AppImage
      // 
      this.AppImage.Dock = System.Windows.Forms.DockStyle.Fill;
      this.AppImage.Image = ((System.Drawing.Image)(resources.GetObject("AppImage.Image")));
      this.AppImage.Location = new System.Drawing.Point(3, 3);
      this.AppImage.Name = "AppImage";
      tableLayoutPanel.SetRowSpan(this.AppImage, 6);
      this.AppImage.Size = new System.Drawing.Size(174, 272);
      this.AppImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.AppImage.TabIndex = 12;
      this.AppImage.TabStop = false;
      // 
      // labelProductName
      // 
      this.labelProductName.Dock = System.Windows.Forms.DockStyle.Fill;
      this.labelProductName.Location = new System.Drawing.Point(186, 0);
      this.labelProductName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
      this.labelProductName.MaximumSize = new System.Drawing.Size(0, 17);
      this.labelProductName.Name = "labelProductName";
      this.labelProductName.Size = new System.Drawing.Size(377, 17);
      this.labelProductName.TabIndex = 19;
      this.labelProductName.Text = "Product Name";
      this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // labelVersion
      // 
      this.labelVersion.Dock = System.Windows.Forms.DockStyle.Fill;
      this.labelVersion.Location = new System.Drawing.Point(186, 17);
      this.labelVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
      this.labelVersion.MaximumSize = new System.Drawing.Size(0, 17);
      this.labelVersion.Name = "labelVersion";
      this.labelVersion.Size = new System.Drawing.Size(377, 17);
      this.labelVersion.TabIndex = 0;
      this.labelVersion.Text = "Version";
      this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // labelCopyright
      // 
      this.labelCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
      this.labelCopyright.Location = new System.Drawing.Point(186, 34);
      this.labelCopyright.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
      this.labelCopyright.MaximumSize = new System.Drawing.Size(0, 17);
      this.labelCopyright.Name = "labelCopyright";
      this.labelCopyright.Size = new System.Drawing.Size(377, 17);
      this.labelCopyright.TabIndex = 21;
      this.labelCopyright.Text = "Copyright";
      this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // labelCompanyName
      // 
      this.labelCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
      this.labelCompanyName.Location = new System.Drawing.Point(186, 51);
      this.labelCompanyName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
      this.labelCompanyName.MaximumSize = new System.Drawing.Size(0, 17);
      this.labelCompanyName.Name = "labelCompanyName";
      this.labelCompanyName.Size = new System.Drawing.Size(377, 17);
      this.labelCompanyName.TabIndex = 22;
      this.labelCompanyName.Text = "Company Name";
      this.labelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // textBoxDescription
      // 
      this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textBoxDescription.Location = new System.Drawing.Point(186, 71);
      this.textBoxDescription.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
      this.textBoxDescription.Multiline = true;
      this.textBoxDescription.Name = "textBoxDescription";
      this.textBoxDescription.ReadOnly = true;
      this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.textBoxDescription.Size = new System.Drawing.Size(377, 175);
      this.textBoxDescription.TabIndex = 23;
      this.textBoxDescription.TabStop = false;
      this.textBoxDescription.Text = "Description";
      // 
      // okButton
      // 
      okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      okButton.Location = new System.Drawing.Point(488, 252);
      okButton.Name = "okButton";
      okButton.Size = new System.Drawing.Size(75, 23);
      okButton.TabIndex = 24;
      okButton.Text = "&OK";
      // 
      // AboutBox
      // 
      this.AcceptButton = okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = okButton;
      this.ClientSize = new System.Drawing.Size(584, 296);
      this.Controls.Add(tableLayoutPanel);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(600, 334);
      this.Name = "AboutBox";
      this.Padding = new System.Windows.Forms.Padding(9);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "About";
      tableLayoutPanel.ResumeLayout(false);
      tableLayoutPanel.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.AppImage)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label labelProductName;
    private System.Windows.Forms.Label labelVersion;
    private System.Windows.Forms.Label labelCopyright;
    private System.Windows.Forms.Label labelCompanyName;
    private System.Windows.Forms.TextBox textBoxDescription;
    private System.Windows.Forms.PictureBox AppImage;
  }
}
