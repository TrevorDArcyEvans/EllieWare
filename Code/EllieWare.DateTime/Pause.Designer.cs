namespace EllieWare.DateTime
{
  partial class Pause
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
      this.mTimeSpan = new System.Windows.Forms.DateTimePicker();
      this.SuspendLayout();
      // 
      // mTimeSpan
      // 
      this.mTimeSpan.CustomFormat = "HH:mm:ss";
      this.mTimeSpan.Dock = System.Windows.Forms.DockStyle.Top;
      this.mTimeSpan.Format = System.Windows.Forms.DateTimePickerFormat.Time;
      this.mTimeSpan.Location = new System.Drawing.Point(0, 0);
      this.mTimeSpan.Name = "mTimeSpan";
      this.mTimeSpan.ShowUpDown = true;
      this.mTimeSpan.Size = new System.Drawing.Size(223, 20);
      this.mTimeSpan.TabIndex = 0;
      this.mTimeSpan.ValueChanged += new System.EventHandler(this.TimeSpan_ValueChanged);
      // 
      // Pause
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.mTimeSpan);
      this.Name = "Pause";
      this.Size = new System.Drawing.Size(223, 150);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DateTimePicker mTimeSpan;
  }
}
