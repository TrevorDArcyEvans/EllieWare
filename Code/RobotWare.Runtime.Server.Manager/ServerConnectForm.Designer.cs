//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace RobotWare.Runtime.Server.Manager
{
    partial class ServerConnectForm
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
      System.Windows.Forms.Label label3;
      System.Windows.Forms.Label label2;
      System.Windows.Forms.Button CmdCancel;
      System.Windows.Forms.Button CmdConnect;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerConnectForm));
      this.txtScheduler = new System.Windows.Forms.TextBox();
      this.cboServer = new System.Windows.Forms.ComboBox();
      this.txtPort = new System.Windows.Forms.TextBox();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      label1 = new System.Windows.Forms.Label();
      label3 = new System.Windows.Forms.Label();
      label2 = new System.Windows.Forms.Label();
      CmdCancel = new System.Windows.Forms.Button();
      CmdConnect = new System.Windows.Forms.Button();
      tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.AutoSize = true;
      tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      tableLayoutPanel1.ColumnCount = 4;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.Controls.Add(label1, 0, 0);
      tableLayoutPanel1.Controls.Add(this.txtScheduler, 1, 2);
      tableLayoutPanel1.Controls.Add(this.cboServer, 1, 0);
      tableLayoutPanel1.Controls.Add(label3, 0, 2);
      tableLayoutPanel1.Controls.Add(label2, 0, 1);
      tableLayoutPanel1.Controls.Add(this.txtPort, 1, 1);
      tableLayoutPanel1.Controls.Add(CmdCancel, 3, 3);
      tableLayoutPanel1.Controls.Add(CmdConnect, 2, 3);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 4;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(284, 111);
      tableLayoutPanel1.TabIndex = 11;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(3, 3);
      label1.Margin = new System.Windows.Forms.Padding(3);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(41, 13);
      label1.TabIndex = 2;
      label1.Text = "Server:";
      // 
      // txtScheduler
      // 
      tableLayoutPanel1.SetColumnSpan(this.txtScheduler, 3);
      this.txtScheduler.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtScheduler.Location = new System.Drawing.Point(67, 56);
      this.txtScheduler.Name = "txtScheduler";
      this.txtScheduler.Size = new System.Drawing.Size(214, 20);
      this.txtScheduler.TabIndex = 2;
      this.txtScheduler.Text = "QuartzScheduler";
      // 
      // cboServer
      // 
      tableLayoutPanel1.SetColumnSpan(this.cboServer, 3);
      this.cboServer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cboServer.FormattingEnabled = true;
      this.cboServer.Location = new System.Drawing.Point(67, 3);
      this.cboServer.Name = "cboServer";
      this.cboServer.Size = new System.Drawing.Size(214, 21);
      this.cboServer.TabIndex = 1;
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new System.Drawing.Point(3, 56);
      label3.Margin = new System.Windows.Forms.Padding(3);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(58, 13);
      label3.TabIndex = 10;
      label3.Text = "Scheduler:";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new System.Drawing.Point(3, 30);
      label2.Margin = new System.Windows.Forms.Padding(3);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(29, 13);
      label2.TabIndex = 8;
      label2.Text = "Port:";
      // 
      // txtPort
      // 
      tableLayoutPanel1.SetColumnSpan(this.txtPort, 3);
      this.txtPort.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtPort.Location = new System.Drawing.Point(67, 30);
      this.txtPort.Name = "txtPort";
      this.txtPort.Size = new System.Drawing.Size(214, 20);
      this.txtPort.TabIndex = 1;
      this.txtPort.Text = "555";
      // 
      // CmdCancel
      // 
      CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      CmdCancel.Location = new System.Drawing.Point(206, 82);
      CmdCancel.Name = "CmdCancel";
      CmdCancel.Size = new System.Drawing.Size(75, 23);
      CmdCancel.TabIndex = 4;
      CmdCancel.Text = "Cancel";
      CmdCancel.UseVisualStyleBackColor = true;
      // 
      // CmdConnect
      // 
      CmdConnect.DialogResult = System.Windows.Forms.DialogResult.OK;
      CmdConnect.Location = new System.Drawing.Point(125, 82);
      CmdConnect.Name = "CmdConnect";
      CmdConnect.Size = new System.Drawing.Size(75, 23);
      CmdConnect.TabIndex = 3;
      CmdConnect.Text = "Connect";
      CmdConnect.UseVisualStyleBackColor = true;
      // 
      // ServerConnectForm
      // 
      this.AcceptButton = CmdConnect;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = CmdCancel;
      this.ClientSize = new System.Drawing.Size(284, 111);
      this.Controls.Add(tableLayoutPanel1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximumSize = new System.Drawing.Size(900, 149);
      this.MinimumSize = new System.Drawing.Size(300, 149);
      this.Name = "ServerConnectForm";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "ServerConnectForm";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ServerConnectForm_FormClosed);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtScheduler;
        private System.Windows.Forms.ComboBox cboServer;
    }
}