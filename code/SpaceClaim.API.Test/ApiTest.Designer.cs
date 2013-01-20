//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace SpaceClaim.API.Test
{
  partial class ApiTest
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
      System.Windows.Forms.Button CmdTest;
      this.ApiTests = new System.Windows.Forms.ComboBox();
      CmdTest = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // CmdTest
      // 
      CmdTest.Location = new System.Drawing.Point(95, 39);
      CmdTest.Name = "CmdTest";
      CmdTest.Size = new System.Drawing.Size(75, 23);
      CmdTest.TabIndex = 0;
      CmdTest.Text = "Test";
      CmdTest.UseVisualStyleBackColor = true;
      CmdTest.Click += new System.EventHandler(this.CmdTest_Click);
      // 
      // ApiTests
      // 
      this.ApiTests.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.ApiTests.FormattingEnabled = true;
      this.ApiTests.Location = new System.Drawing.Point(12, 12);
      this.ApiTests.Name = "ApiTests";
      this.ApiTests.Size = new System.Drawing.Size(240, 21);
      this.ApiTests.Sorted = true;
      this.ApiTests.TabIndex = 1;
      // 
      // ApiTest
      // 
      this.AcceptButton = CmdTest;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(264, 76);
      this.Controls.Add(this.ApiTests);
      this.Controls.Add(CmdTest);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "ApiTest";
      this.Text = "EllieWare API Tester";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ComboBox ApiTests;
  }
}