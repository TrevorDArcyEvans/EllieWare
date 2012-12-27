//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using Controls.Development;

namespace EllieWare.Manager
{
  partial class LogWindow
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
      System.Windows.Forms.ImageList imageList1;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogWindow));
      this.mMessages = new Controls.Development.ImageListBox();
      imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.SuspendLayout();
      // 
      // mMessages
      // 
      this.mMessages.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mMessages.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
      this.mMessages.ImageList = imageList1;
      this.mMessages.Location = new System.Drawing.Point(0, 0);
      this.mMessages.Name = "mMessages";
      this.mMessages.Size = new System.Drawing.Size(697, 387);
      this.mMessages.TabIndex = 0;
      // 
      // imageList1
      // 
      imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      imageList1.TransparentColor = System.Drawing.Color.Transparent;
      imageList1.Images.SetKeyName(0, "bug_green.png");
      imageList1.Images.SetKeyName(1, "information2.png");
      imageList1.Images.SetKeyName(2, "sign_warning.png");
      imageList1.Images.SetKeyName(3, "brickwall_warning.png");
      imageList1.Images.SetKeyName(4, "error.png");
      // 
      // LogWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(697, 387);
      this.Controls.Add(this.mMessages);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "LogWindow";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Log Window";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogWindow_FormClosing);
      this.ResumeLayout(false);

    }

    #endregion

    private ImageListBox mMessages;

  }
}