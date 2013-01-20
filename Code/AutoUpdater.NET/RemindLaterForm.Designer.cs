namespace AutoUpdaterDotNET
{
    partial class RemindLaterForm
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
      this.labelTitle = new System.Windows.Forms.Label();
      this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
      this.labelDescription = new System.Windows.Forms.Label();
      this.radioButtonYes = new System.Windows.Forms.RadioButton();
      this.radioButtonNo = new System.Windows.Forms.RadioButton();
      this.comboBoxRemindLater = new System.Windows.Forms.ComboBox();
      this.buttonOK = new System.Windows.Forms.Button();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // labelTitle
      // 
      this.labelTitle.AutoSize = true;
      this.tableLayoutPanel1.SetColumnSpan(this.labelTitle, 3);
      this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
      this.labelTitle.Location = new System.Drawing.Point(70, 6);
      this.labelTitle.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.labelTitle.Name = "labelTitle";
      this.labelTitle.Size = new System.Drawing.Size(280, 19);
      this.labelTitle.TabIndex = 0;
      this.labelTitle.Text = "Do you want to download updates later?";
      // 
      // pictureBoxIcon
      // 
      this.pictureBoxIcon.Image = global::AutoUpdaterDotNET.Properties.Resources.clock_go1;
      this.pictureBoxIcon.Location = new System.Drawing.Point(3, 3);
      this.pictureBoxIcon.Name = "pictureBoxIcon";
      this.pictureBoxIcon.Size = new System.Drawing.Size(61, 48);
      this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pictureBoxIcon.TabIndex = 1;
      this.pictureBoxIcon.TabStop = false;
      // 
      // labelDescription
      // 
      this.labelDescription.AutoSize = true;
      this.tableLayoutPanel1.SetColumnSpan(this.labelDescription, 3);
      this.labelDescription.Location = new System.Drawing.Point(70, 60);
      this.labelDescription.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.labelDescription.MaximumSize = new System.Drawing.Size(340, 0);
      this.labelDescription.Name = "labelDescription";
      this.labelDescription.Size = new System.Drawing.Size(330, 45);
      this.labelDescription.TabIndex = 2;
      this.labelDescription.Text = "You should download updates now. This only takes few minutes depending on your in" +
    "ternet connection and ensures you have latest version of AutoUpdaterTest.\r\n";
      // 
      // radioButtonYes
      // 
      this.radioButtonYes.AutoSize = true;
      this.radioButtonYes.Checked = true;
      this.radioButtonYes.Location = new System.Drawing.Point(70, 123);
      this.radioButtonYes.Name = "radioButtonYes";
      this.radioButtonYes.Size = new System.Drawing.Size(178, 19);
      this.radioButtonYes.TabIndex = 3;
      this.radioButtonYes.TabStop = true;
      this.radioButtonYes.Text = "Yes, please remind me later : ";
      this.radioButtonYes.UseVisualStyleBackColor = true;
      this.radioButtonYes.CheckedChanged += new System.EventHandler(this.RadioButtonYesCheckedChanged);
      // 
      // radioButtonNo
      // 
      this.radioButtonNo.AutoSize = true;
      this.tableLayoutPanel1.SetColumnSpan(this.radioButtonNo, 2);
      this.radioButtonNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
      this.radioButtonNo.Location = new System.Drawing.Point(70, 152);
      this.radioButtonNo.Name = "radioButtonNo";
      this.radioButtonNo.Size = new System.Drawing.Size(268, 19);
      this.radioButtonNo.TabIndex = 4;
      this.radioButtonNo.Text = "No, download updates now (recommended)";
      this.radioButtonNo.UseVisualStyleBackColor = true;
      // 
      // comboBoxRemindLater
      // 
      this.tableLayoutPanel1.SetColumnSpan(this.comboBoxRemindLater, 2);
      this.comboBoxRemindLater.FormattingEnabled = true;
      this.comboBoxRemindLater.Items.AddRange(new object[] {
            "After 30 minutes",
            "After 12 hours",
            "After 1 day",
            "After 2 days",
            "After 4 days",
            "After 8 days",
            "After 10 days"});
      this.comboBoxRemindLater.Location = new System.Drawing.Point(301, 123);
      this.comboBoxRemindLater.Name = "comboBoxRemindLater";
      this.comboBoxRemindLater.Size = new System.Drawing.Size(132, 23);
      this.comboBoxRemindLater.TabIndex = 5;
      // 
      // buttonOK
      // 
      this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.buttonOK.Image = global::AutoUpdaterDotNET.Properties.Resources.clock_play;
      this.buttonOK.Location = new System.Drawing.Point(359, 177);
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.Size = new System.Drawing.Size(74, 32);
      this.buttonOK.TabIndex = 6;
      this.buttonOK.Text = "OK";
      this.buttonOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.buttonOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.buttonOK.UseVisualStyleBackColor = true;
      this.buttonOK.Click += new System.EventHandler(this.ButtonOkClick);
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 4;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.Controls.Add(this.pictureBoxIcon, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.comboBoxRemindLater, 2, 2);
      this.tableLayoutPanel1.Controls.Add(this.buttonOK, 3, 4);
      this.tableLayoutPanel1.Controls.Add(this.labelTitle, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.labelDescription, 1, 1);
      this.tableLayoutPanel1.Controls.Add(this.radioButtonNo, 1, 3);
      this.tableLayoutPanel1.Controls.Add(this.radioButtonYes, 1, 2);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 5;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.Size = new System.Drawing.Size(436, 212);
      this.tableLayoutPanel1.TabIndex = 7;
      // 
      // RemindLaterForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(436, 212);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "RemindLaterForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Remind me later for update";
      this.Load += new System.EventHandler(this.RemindLaterFormLoad);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.RadioButton radioButtonYes;
        private System.Windows.Forms.RadioButton radioButtonNo;
        private System.Windows.Forms.ComboBox comboBoxRemindLater;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}