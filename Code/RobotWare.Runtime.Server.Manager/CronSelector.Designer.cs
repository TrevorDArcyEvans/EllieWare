namespace RobotWare.Runtime.Server.Manager
{
  partial class CronSelector
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CronSelector));
      this.mCron = new RobotWare.Cron.UserInterface.Cron();
      this.CmdOK = new System.Windows.Forms.Button();
      this.CmdCancel = new System.Windows.Forms.Button();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // mCron
      // 
      tableLayoutPanel1.SetColumnSpan(this.mCron, 3);
      this.mCron.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mCron.Location = new System.Drawing.Point(5, 5);
      this.mCron.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
      this.mCron.Name = "mCron";
      this.mCron.Size = new System.Drawing.Size(558, 358);
      this.mCron.TabIndex = 0;
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.Controls.Add(this.mCron, 0, 0);
      tableLayoutPanel1.Controls.Add(this.CmdOK, 1, 1);
      tableLayoutPanel1.Controls.Add(this.CmdCancel, 2, 1);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 2;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(568, 401);
      tableLayoutPanel1.TabIndex = 1;
      // 
      // CmdOK
      // 
      this.CmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.CmdOK.Location = new System.Drawing.Point(418, 371);
      this.CmdOK.Name = "CmdOK";
      this.CmdOK.Size = new System.Drawing.Size(75, 27);
      this.CmdOK.TabIndex = 1;
      this.CmdOK.Text = "OK";
      this.CmdOK.UseVisualStyleBackColor = true;
      // 
      // CmdCancel
      // 
      this.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.CmdCancel.Location = new System.Drawing.Point(499, 371);
      this.CmdCancel.Name = "CmdCancel";
      this.CmdCancel.Size = new System.Drawing.Size(66, 27);
      this.CmdCancel.TabIndex = 2;
      this.CmdCancel.Text = "Cancel";
      this.CmdCancel.UseVisualStyleBackColor = true;
      // 
      // CronSelector
      // 
      this.AcceptButton = this.CmdOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.CmdCancel;
      this.ClientSize = new System.Drawing.Size(568, 401);
      this.Controls.Add(tableLayoutPanel1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "CronSelector";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Select Schedule";
      tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private Cron.UserInterface.Cron mCron;
    private System.Windows.Forms.Button CmdOK;
    private System.Windows.Forms.Button CmdCancel;
  }
}