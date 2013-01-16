using System.Threading;

namespace AutoUpdaterDotNET
{
    partial class UpdateForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForm));
      this.webBrowser = new System.Windows.Forms.WebBrowser();
      this.labelUpdate = new System.Windows.Forms.Label();
      this.labelDescription = new System.Windows.Forms.Label();
      this.labelReleaseNotes = new System.Windows.Forms.Label();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.buttonSkip = new System.Windows.Forms.Button();
      this.buttonUpdate = new System.Windows.Forms.Button();
      this.buttonRemindLater = new System.Windows.Forms.Button();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.tableLayoutPanel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      tableLayoutPanel1.ColumnCount = 4;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
      tableLayoutPanel1.Controls.Add(this.webBrowser, 1, 3);
      tableLayoutPanel1.Controls.Add(this.labelReleaseNotes, 1, 2);
      tableLayoutPanel1.Controls.Add(this.labelUpdate, 1, 0);
      tableLayoutPanel1.Controls.Add(this.labelDescription, 1, 1);
      tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 4);
      tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 5;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(725, 585);
      tableLayoutPanel1.TabIndex = 9;
      // 
      // webBrowser
      // 
      tableLayoutPanel1.SetColumnSpan(this.webBrowser, 3);
      this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
      this.webBrowser.Location = new System.Drawing.Point(76, 72);
      this.webBrowser.Margin = new System.Windows.Forms.Padding(0);
      this.webBrowser.MinimumSize = new System.Drawing.Size(23, 23);
      this.webBrowser.Name = "webBrowser";
      this.webBrowser.Size = new System.Drawing.Size(649, 475);
      this.webBrowser.TabIndex = 0;
      // 
      // labelUpdate
      // 
      this.labelUpdate.AutoSize = true;
      tableLayoutPanel1.SetColumnSpan(this.labelUpdate, 3);
      this.labelUpdate.Dock = System.Windows.Forms.DockStyle.Top;
      this.labelUpdate.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
      this.labelUpdate.Location = new System.Drawing.Point(79, 6);
      this.labelUpdate.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.labelUpdate.MaximumSize = new System.Drawing.Size(560, 0);
      this.labelUpdate.Name = "labelUpdate";
      this.labelUpdate.Size = new System.Drawing.Size(560, 19);
      this.labelUpdate.TabIndex = 5;
      this.labelUpdate.Text = "A new version of AutoUpdater.NET is available!";
      // 
      // labelDescription
      // 
      this.labelDescription.AutoSize = true;
      tableLayoutPanel1.SetColumnSpan(this.labelDescription, 3);
      this.labelDescription.Dock = System.Windows.Forms.DockStyle.Top;
      this.labelDescription.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
      this.labelDescription.Location = new System.Drawing.Point(79, 31);
      this.labelDescription.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.labelDescription.Name = "labelDescription";
      this.labelDescription.Size = new System.Drawing.Size(643, 15);
      this.labelDescription.TabIndex = 6;
      this.labelDescription.Text = "AutoUpdaterTest 1.1.1.0 is now available. You have version 1.0.0.0 installed. Wou" +
    "ld you like to download it now?";
      // 
      // labelReleaseNotes
      // 
      this.labelReleaseNotes.AutoSize = true;
      tableLayoutPanel1.SetColumnSpan(this.labelReleaseNotes, 3);
      this.labelReleaseNotes.Dock = System.Windows.Forms.DockStyle.Top;
      this.labelReleaseNotes.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
      this.labelReleaseNotes.Location = new System.Drawing.Point(79, 52);
      this.labelReleaseNotes.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.labelReleaseNotes.Name = "labelReleaseNotes";
      this.labelReleaseNotes.Size = new System.Drawing.Size(643, 17);
      this.labelReleaseNotes.TabIndex = 7;
      this.labelReleaseNotes.Text = "Release Notes :";
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::AutoUpdaterDotNET.Properties.Resources.update;
      this.pictureBox1.Location = new System.Drawing.Point(3, 3);
      this.pictureBox1.Name = "pictureBox1";
      tableLayoutPanel1.SetRowSpan(this.pictureBox1, 3);
      this.pictureBox1.Size = new System.Drawing.Size(70, 66);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pictureBox1.TabIndex = 8;
      this.pictureBox1.TabStop = false;
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.AutoSize = true;
      this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.tableLayoutPanel2.ColumnCount = 3;
      tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 3);
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      this.tableLayoutPanel2.Controls.Add(this.buttonSkip, 0, 0);
      this.tableLayoutPanel2.Controls.Add(this.buttonUpdate, 2, 0);
      this.tableLayoutPanel2.Controls.Add(this.buttonRemindLater, 1, 0);
      this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel2.Location = new System.Drawing.Point(79, 550);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 1;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(643, 32);
      this.tableLayoutPanel2.TabIndex = 9;
      // 
      // buttonSkip
      // 
      this.buttonSkip.DialogResult = System.Windows.Forms.DialogResult.Abort;
      this.buttonSkip.Dock = System.Windows.Forms.DockStyle.Top;
      this.buttonSkip.Image = global::AutoUpdaterDotNET.Properties.Resources.hand_point;
      this.buttonSkip.Location = new System.Drawing.Point(2, 2);
      this.buttonSkip.Margin = new System.Windows.Forms.Padding(2);
      this.buttonSkip.Name = "buttonSkip";
      this.buttonSkip.Size = new System.Drawing.Size(210, 28);
      this.buttonSkip.TabIndex = 1;
      this.buttonSkip.Text = "Skip this version";
      this.buttonSkip.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.buttonSkip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.buttonSkip.UseVisualStyleBackColor = true;
      this.buttonSkip.Click += new System.EventHandler(this.ButtonSkipClick);
      // 
      // buttonUpdate
      // 
      this.buttonUpdate.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.buttonUpdate.Dock = System.Windows.Forms.DockStyle.Top;
      this.buttonUpdate.Image = global::AutoUpdaterDotNET.Properties.Resources.download;
      this.buttonUpdate.Location = new System.Drawing.Point(430, 2);
      this.buttonUpdate.Margin = new System.Windows.Forms.Padding(2);
      this.buttonUpdate.Name = "buttonUpdate";
      this.buttonUpdate.Size = new System.Drawing.Size(211, 28);
      this.buttonUpdate.TabIndex = 2;
      this.buttonUpdate.Text = "Update";
      this.buttonUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.buttonUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.buttonUpdate.UseVisualStyleBackColor = true;
      this.buttonUpdate.Click += new System.EventHandler(this.ButtonUpdateClick);
      // 
      // buttonRemindLater
      // 
      this.buttonRemindLater.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonRemindLater.Dock = System.Windows.Forms.DockStyle.Top;
      this.buttonRemindLater.Image = global::AutoUpdaterDotNET.Properties.Resources.clock_go;
      this.buttonRemindLater.Location = new System.Drawing.Point(216, 2);
      this.buttonRemindLater.Margin = new System.Windows.Forms.Padding(2);
      this.buttonRemindLater.Name = "buttonRemindLater";
      this.buttonRemindLater.Size = new System.Drawing.Size(210, 28);
      this.buttonRemindLater.TabIndex = 3;
      this.buttonRemindLater.Text = "Remind me later";
      this.buttonRemindLater.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.buttonRemindLater.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.buttonRemindLater.UseVisualStyleBackColor = true;
      this.buttonRemindLater.Click += new System.EventHandler(this.ButtonRemindLaterClick);
      // 
      // UpdateForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(749, 609);
      this.Controls.Add(tableLayoutPanel1);
      this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(2);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(765, 647);
      this.Name = "UpdateForm";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Software Update";
      this.Load += new System.EventHandler(this.UpdateFormLoad);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.tableLayoutPanel2.ResumeLayout(false);
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonRemindLater;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonSkip;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Label labelUpdate;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelReleaseNotes;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;

    }
}