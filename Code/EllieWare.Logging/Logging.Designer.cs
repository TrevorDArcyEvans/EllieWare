namespace EllieWare.Logging
{
  partial class Logging
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
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.mMessage = new System.Windows.Forms.TextBox();
      this.mLevel = new System.Windows.Forms.ComboBox();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.mMessage, 1, 1);
      this.tableLayoutPanel1.Controls.Add(this.mLevel, 1, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.Size = new System.Drawing.Size(328, 123);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 6);
      this.label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(36, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Level:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(3, 33);
      this.label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(53, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "Message:";
      // 
      // mMessage
      // 
      this.mMessage.Dock = System.Windows.Forms.DockStyle.Top;
      this.mMessage.Location = new System.Drawing.Point(62, 30);
      this.mMessage.Name = "mMessage";
      this.mMessage.Size = new System.Drawing.Size(263, 20);
      this.mMessage.TabIndex = 2;
      this.mMessage.TextChanged += new System.EventHandler(this.Message_TextChanged);
      // 
      // mLevel
      // 
      this.mLevel.Dock = System.Windows.Forms.DockStyle.Top;
      this.mLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.mLevel.FormattingEnabled = true;
      this.mLevel.Items.AddRange(new object[] {
            "Debug",
            "Information",
            "Warning",
            "Severe",
            "Critical"});
      this.mLevel.Location = new System.Drawing.Point(62, 3);
      this.mLevel.Name = "mLevel";
      this.mLevel.Size = new System.Drawing.Size(263, 21);
      this.mLevel.TabIndex = 3;
      this.mLevel.SelectedIndexChanged += new System.EventHandler(this.Level_SelectedIndexChanged);
      // 
      // Logging
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "Logging";
      this.Size = new System.Drawing.Size(328, 123);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox mMessage;
    private System.Windows.Forms.ComboBox mLevel;

  }
}
