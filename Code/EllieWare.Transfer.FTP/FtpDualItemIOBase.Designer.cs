namespace EllieWare.Transfer.FTP
{
  partial class FtpDualItemIOBase
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
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      this.mDualItemIO = new EllieWare.Common.DualItemIOBase();
      this.mFtpInfo = new EllieWare.Transfer.FTP.FtpInfo();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 1;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.Controls.Add(this.mDualItemIO, 0, 1);
      tableLayoutPanel1.Controls.Add(this.mFtpInfo, 0, 0);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 2;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.Size = new System.Drawing.Size(372, 252);
      tableLayoutPanel1.TabIndex = 2;
      // 
      // mDualItemIO
      // 
      this.mDualItemIO.AllowDestinationBrowse = true;
      this.mDualItemIO.AllowSourceBrowse = true;
      this.mDualItemIO.Location = new System.Drawing.Point(3, 117);
      this.mDualItemIO.Name = "mDualItemIO";
      this.mDualItemIO.Size = new System.Drawing.Size(366, 132);
      this.mDualItemIO.TabIndex = 1;
      // 
      // mFtpInfo
      // 
      this.mFtpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mFtpInfo.Location = new System.Drawing.Point(3, 3);
      this.mFtpInfo.Name = "mFtpInfo";
      this.mFtpInfo.Size = new System.Drawing.Size(366, 108);
      this.mFtpInfo.TabIndex = 0;
      // 
      // FtpDualItemIOBase
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(tableLayoutPanel1);
      this.Name = "FtpDualItemIOBase";
      this.Size = new System.Drawing.Size(372, 252);
      tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    protected FtpInfo mFtpInfo;
    protected Common.DualItemIOBase mDualItemIO;
  }
}
