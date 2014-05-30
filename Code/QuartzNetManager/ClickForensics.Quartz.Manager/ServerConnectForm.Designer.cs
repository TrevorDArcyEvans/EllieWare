namespace ClickForensics.Quartz.Manager
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
      this.txtPort = new System.Windows.Forms.TextBox();
      this.txtScheduler = new System.Windows.Forms.TextBox();
      this.cboServer = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnConnect = new System.Windows.Forms.Button();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
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
      tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
      tableLayoutPanel1.Controls.Add(this.txtScheduler, 1, 2);
      tableLayoutPanel1.Controls.Add(this.cboServer, 1, 0);
      tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
      tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
      tableLayoutPanel1.Controls.Add(this.txtPort, 1, 1);
      tableLayoutPanel1.Controls.Add(this.btnCancel, 3, 3);
      tableLayoutPanel1.Controls.Add(this.btnConnect, 2, 3);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 4;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(284, 110);
      tableLayoutPanel1.TabIndex = 11;
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
      this.cboServer.SelectedIndexChanged += new System.EventHandler(this.cboServer_SelectedIndexChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 3);
      this.label1.Margin = new System.Windows.Forms.Padding(3);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Server:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(3, 56);
      this.label3.Margin = new System.Windows.Forms.Padding(3);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(58, 13);
      this.label3.TabIndex = 10;
      this.label3.Text = "Scheduler:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(3, 30);
      this.label2.Margin = new System.Windows.Forms.Padding(3);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(29, 13);
      this.label2.TabIndex = 8;
      this.label2.Text = "Port:";
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(206, 82);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 4;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // btnConnect
      // 
      this.btnConnect.Location = new System.Drawing.Point(125, 82);
      this.btnConnect.Name = "btnConnect";
      this.btnConnect.Size = new System.Drawing.Size(75, 23);
      this.btnConnect.TabIndex = 3;
      this.btnConnect.Text = "Connect";
      this.btnConnect.UseVisualStyleBackColor = true;
      this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
      // 
      // ServerConnectForm
      // 
      this.AcceptButton = this.btnConnect;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 110);
      this.Controls.Add(tableLayoutPanel1);
      this.MaximumSize = new System.Drawing.Size(900, 149);
      this.MinimumSize = new System.Drawing.Size(300, 149);
      this.Name = "ServerConnectForm";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "ServerConnectForm";
      this.Load += new System.EventHandler(this.ServerConnectForm_Load);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtScheduler;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboServer;
    }
}