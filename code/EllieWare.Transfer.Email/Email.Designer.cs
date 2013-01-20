//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace EllieWare.Transfer.Email
{
  partial class Email
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
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      System.Windows.Forms.Label label1;
      System.Windows.Forms.Label label2;
      System.Windows.Forms.Label label3;
      System.Windows.Forms.Label label4;
      System.Windows.Forms.ToolTip EmailToolTip;
      this.mRecipients = new EllieWare.Common.ParameterTextBox();
      this.mSubject = new EllieWare.Common.ParameterTextBox();
      this.mAttachments = new EllieWare.Common.ParameterTextBox();
      this.mMessage = new EllieWare.Common.ParameterTextBox();
      this.CmdBrowse = new System.Windows.Forms.Button();
      this.SourceFileSelector = new System.Windows.Forms.SaveFileDialog();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      label1 = new System.Windows.Forms.Label();
      label2 = new System.Windows.Forms.Label();
      label3 = new System.Windows.Forms.Label();
      label4 = new System.Windows.Forms.Label();
      EmailToolTip = new System.Windows.Forms.ToolTip(this.components);
      tableLayoutPanel1.SuspendLayout();
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
      tableLayoutPanel1.Controls.Add(this.mRecipients, 1, 0);
      tableLayoutPanel1.Controls.Add(this.mSubject, 1, 1);
      tableLayoutPanel1.Controls.Add(this.mAttachments, 1, 3);
      tableLayoutPanel1.Controls.Add(this.mMessage, 1, 2);
      tableLayoutPanel1.Controls.Add(this.CmdBrowse, 2, 3);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 4;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(370, 255);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(3, 6);
      label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(23, 13);
      label1.TabIndex = 0;
      label1.Text = "To:";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new System.Drawing.Point(3, 32);
      label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(46, 13);
      label2.TabIndex = 2;
      label2.Text = "Subject:";
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new System.Drawing.Point(3, 58);
      label3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(53, 13);
      label3.TabIndex = 4;
      label3.Text = "Message:";
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new System.Drawing.Point(3, 232);
      label4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label4.Name = "label4";
      label4.Size = new System.Drawing.Size(69, 13);
      label4.TabIndex = 6;
      label4.Text = "Attachments:";
      // 
      // mRecipients
      // 
      tableLayoutPanel1.SetColumnSpan(this.mRecipients, 2);
      this.mRecipients.Dock = System.Windows.Forms.DockStyle.Top;
      this.mRecipients.Location = new System.Drawing.Point(78, 3);
      this.mRecipients.Name = "mRecipients";
      this.mRecipients.Size = new System.Drawing.Size(289, 20);
      this.mRecipients.TabIndex = 1;
      EmailToolTip.SetToolTip(this.mRecipients, "Semicolon (;) separated list of email addresses");
      this.mRecipients.TextChanged += new System.EventHandler(this.Recipients_TextChanged);
      // 
      // mSubject
      // 
      tableLayoutPanel1.SetColumnSpan(this.mSubject, 2);
      this.mSubject.Dock = System.Windows.Forms.DockStyle.Top;
      this.mSubject.Location = new System.Drawing.Point(78, 29);
      this.mSubject.Name = "mSubject";
      this.mSubject.Size = new System.Drawing.Size(289, 20);
      this.mSubject.TabIndex = 3;
      this.mSubject.TextChanged += new System.EventHandler(this.Subject_TextChanged);
      // 
      // mAttachments
      // 
      this.mAttachments.Dock = System.Windows.Forms.DockStyle.Top;
      this.mAttachments.Location = new System.Drawing.Point(78, 229);
      this.mAttachments.Name = "mAttachments";
      this.mAttachments.Size = new System.Drawing.Size(257, 20);
      this.mAttachments.TabIndex = 7;
      EmailToolTip.SetToolTip(this.mAttachments, "Semicolon (;) separated list of file paths");
      this.mAttachments.TextChanged += new System.EventHandler(this.Attachments_TextChanged);
      // 
      // mMessage
      // 
      tableLayoutPanel1.SetColumnSpan(this.mMessage, 2);
      this.mMessage.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mMessage.Location = new System.Drawing.Point(78, 55);
      this.mMessage.Multiline = true;
      this.mMessage.Name = "mMessage";
      this.mMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.mMessage.Size = new System.Drawing.Size(289, 168);
      this.mMessage.TabIndex = 5;
      this.mMessage.TextChanged += new System.EventHandler(this.Message_TextChanged);
      // 
      // CmdBrowse
      // 
      this.CmdBrowse.AutoSize = true;
      this.CmdBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.CmdBrowse.Location = new System.Drawing.Point(341, 229);
      this.CmdBrowse.Name = "CmdBrowse";
      this.CmdBrowse.Size = new System.Drawing.Size(26, 23);
      this.CmdBrowse.TabIndex = 8;
      this.CmdBrowse.Text = "...";
      this.CmdBrowse.UseVisualStyleBackColor = true;
      this.CmdBrowse.Click += new System.EventHandler(this.CmdBrowse_Click);
      // 
      // SourceFileSelector
      // 
      this.SourceFileSelector.CheckPathExists = false;
      this.SourceFileSelector.Filter = "All files (*.*)|*.*";
      this.SourceFileSelector.OverwritePrompt = false;
      this.SourceFileSelector.RestoreDirectory = true;
      this.SourceFileSelector.Title = "Select File";
      // 
      // Email
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(tableLayoutPanel1);
      this.Name = "Email";
      this.Size = new System.Drawing.Size(370, 255);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private Common.ParameterTextBox mRecipients;
    private Common.ParameterTextBox mSubject;
    private Common.ParameterTextBox mAttachments;
    private Common.ParameterTextBox mMessage;
    private System.Windows.Forms.Button CmdBrowse;
    private System.Windows.Forms.SaveFileDialog SourceFileSelector;
  }
}
