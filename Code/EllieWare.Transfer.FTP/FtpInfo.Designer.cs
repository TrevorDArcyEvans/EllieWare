using EllieWare.Common;

namespace EllieWare.Transfer.FTP
{
  partial class FtpInfo
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
      this.Host = new EllieWare.Common.ParameterTextBox();
      this.UserName = new EllieWare.Common.ParameterTextBox();
      this.Password = new EllieWare.Common.ParameterTextBox();
      this.CmdTest = new System.Windows.Forms.Button();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      label1 = new System.Windows.Forms.Label();
      label2 = new System.Windows.Forms.Label();
      label3 = new System.Windows.Forms.Label();
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
      tableLayoutPanel1.Controls.Add(this.Host, 1, 0);
      tableLayoutPanel1.Controls.Add(this.UserName, 1, 1);
      tableLayoutPanel1.Controls.Add(this.Password, 1, 2);
      tableLayoutPanel1.Controls.Add(this.CmdTest, 2, 3);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 4;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.Size = new System.Drawing.Size(336, 108);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(3, 6);
      label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(32, 13);
      label1.TabIndex = 0;
      label1.Text = "Host:";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new System.Drawing.Point(3, 32);
      label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(63, 13);
      label2.TabIndex = 2;
      label2.Text = "User Name:";
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new System.Drawing.Point(3, 58);
      label3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(56, 13);
      label3.TabIndex = 4;
      label3.Text = "Password:";
      // 
      // Host
      // 
      tableLayoutPanel1.SetColumnSpan(this.Host, 2);
      this.Host.Dock = System.Windows.Forms.DockStyle.Top;
      this.Host.Location = new System.Drawing.Point(72, 3);
      this.Host.Name = "Host";
      this.Host.Size = new System.Drawing.Size(261, 20);
      this.Host.TabIndex = 1;
      this.Host.TextChanged += new System.EventHandler(this.Host_TextChanged);
      // 
      // UserName
      // 
      tableLayoutPanel1.SetColumnSpan(this.UserName, 2);
      this.UserName.Dock = System.Windows.Forms.DockStyle.Top;
      this.UserName.Location = new System.Drawing.Point(72, 29);
      this.UserName.Name = "UserName";
      this.UserName.Size = new System.Drawing.Size(261, 20);
      this.UserName.TabIndex = 3;
      this.UserName.TextChanged += new System.EventHandler(this.UserName_TextChanged);
      // 
      // Password
      // 
      tableLayoutPanel1.SetColumnSpan(this.Password, 2);
      this.Password.Dock = System.Windows.Forms.DockStyle.Top;
      this.Password.Location = new System.Drawing.Point(72, 55);
      this.Password.Name = "Password";
      this.Password.Size = new System.Drawing.Size(261, 20);
      this.Password.TabIndex = 5;
      this.Password.TextChanged += new System.EventHandler(this.Password_TextChanged);
      // 
      // CmdTest
      // 
      this.CmdTest.Location = new System.Drawing.Point(258, 81);
      this.CmdTest.Name = "CmdTest";
      this.CmdTest.Size = new System.Drawing.Size(75, 23);
      this.CmdTest.TabIndex = 6;
      this.CmdTest.Text = "Test";
      this.CmdTest.UseVisualStyleBackColor = true;
      this.CmdTest.Click += new System.EventHandler(this.CmdTest_Click);
      // 
      // FtpInfo
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(tableLayoutPanel1);
      this.Name = "FtpInfo";
      this.Size = new System.Drawing.Size(336, 108);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    public ParameterTextBox Host;
    public ParameterTextBox UserName;
    public ParameterTextBox Password;
    private System.Windows.Forms.Button CmdTest;
  }
}
