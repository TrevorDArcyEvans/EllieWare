//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace SerpentWare.Manager.Test
{
  partial class Form1
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
      this.CmdTest = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // CmdTest
      // 
      this.CmdTest.Location = new System.Drawing.Point(13, 13);
      this.CmdTest.Name = "CmdTest";
      this.CmdTest.Size = new System.Drawing.Size(75, 23);
      this.CmdTest.TabIndex = 0;
      this.CmdTest.Text = "Test";
      this.CmdTest.UseVisualStyleBackColor = true;
      this.CmdTest.Click += new System.EventHandler(this.CmdTest_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(224, 130);
      this.Controls.Add(this.CmdTest);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button CmdTest;
  }
}

