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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogWindow));
      this.mMessages = new ImageListBox();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.SuspendLayout();
      // 
      // mMessages
      // 
      this.mMessages.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mMessages.Location = new System.Drawing.Point(0, 0);
      this.mMessages.Name = "mMessages";
      this.mMessages.Size = new System.Drawing.Size(697, 387);
      this.mMessages.ImageList = this.imageList1;
      this.mMessages.TabIndex = 0;
      // 
      // imageList1
      // 
      this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList1.Images.SetKeyName(0, "bug_green.png");
      this.imageList1.Images.SetKeyName(1, "information2.png");
      this.imageList1.Images.SetKeyName(2, "sign_warning.png");
      this.imageList1.Images.SetKeyName(3, "brickwall_warning.png");
      this.imageList1.Images.SetKeyName(4, "error.png");
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
    private System.Windows.Forms.ImageList imageList1;

  }
}