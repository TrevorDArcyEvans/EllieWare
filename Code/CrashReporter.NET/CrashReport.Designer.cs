namespace CrashReporterDotNET
{
    partial class CrashReport
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
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
      this.tabControl = new System.Windows.Forms.TabControl();
      this.tabPageGeneral = new System.Windows.Forms.TabPage();
      this.textBoxEmail = new System.Windows.Forms.TextBox();
      this.labelEmail = new System.Windows.Forms.Label();
      this.textBoxUserMessage = new System.Windows.Forms.TextBox();
      this.labelMessage = new System.Windows.Forms.Label();
      this.textBoxTime = new System.Windows.Forms.TextBox();
      this.labelTime = new System.Windows.Forms.Label();
      this.textBoxApplicationVersion = new System.Windows.Forms.TextBox();
      this.labelVersion = new System.Windows.Forms.Label();
      this.textBoxApplicationName = new System.Windows.Forms.TextBox();
      this.labelApplication = new System.Windows.Forms.Label();
      this.textBoxExceptionMessage = new System.Windows.Forms.TextBox();
      this.pictureBoxError = new System.Windows.Forms.PictureBox();
      this.tabPageExceptions = new System.Windows.Forms.TabPage();
      this.textBoxException = new System.Windows.Forms.TextBox();
      this.labelExceptionType = new System.Windows.Forms.Label();
      this.textBoxSource = new System.Windows.Forms.TextBox();
      this.labelSource = new System.Windows.Forms.Label();
      this.textBoxStackTrace = new System.Windows.Forms.TextBox();
      this.labelStackTrace = new System.Windows.Forms.Label();
      this.textBoxMessage = new System.Windows.Forms.TextBox();
      this.labelExceptionMessage = new System.Windows.Forms.Label();
      this.tabPageScreenshot = new System.Windows.Forms.TabPage();
      this.linkLabelView = new System.Windows.Forms.LinkLabel();
      this.groupBoxScreenshot = new System.Windows.Forms.GroupBox();
      this.pictureBoxScreenshot = new System.Windows.Forms.PictureBox();
      this.checkBoxIncludeScreenshot = new System.Windows.Forms.CheckBox();
      this.buttonSave = new System.Windows.Forms.Button();
      this.buttonCancel = new System.Windows.Forms.Button();
      this.buttonSendReport = new System.Windows.Forms.Button();
      this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
      this.toolTip = new System.Windows.Forms.ToolTip(this.components);
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
      this.tabControl.SuspendLayout();
      this.tabPageGeneral.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxError)).BeginInit();
      this.tabPageExceptions.SuspendLayout();
      this.tabPageScreenshot.SuspendLayout();
      this.groupBoxScreenshot.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreenshot)).BeginInit();
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
      tableLayoutPanel3.SuspendLayout();
      tableLayoutPanel4.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl
      // 
      tableLayoutPanel1.SetColumnSpan(this.tabControl, 4);
      this.tabControl.Controls.Add(this.tabPageGeneral);
      this.tabControl.Controls.Add(this.tabPageExceptions);
      this.tabControl.Controls.Add(this.tabPageScreenshot);
      this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl.Location = new System.Drawing.Point(3, 4);
      this.tabControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.tabControl.Name = "tabControl";
      this.tabControl.SelectedIndex = 0;
      this.tabControl.Size = new System.Drawing.Size(618, 467);
      this.tabControl.TabIndex = 0;
      // 
      // tabPageGeneral
      // 
      this.tabPageGeneral.Controls.Add(tableLayoutPanel4);
      this.tabPageGeneral.Location = new System.Drawing.Point(4, 26);
      this.tabPageGeneral.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.tabPageGeneral.Name = "tabPageGeneral";
      this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.tabPageGeneral.Size = new System.Drawing.Size(610, 437);
      this.tabPageGeneral.TabIndex = 0;
      this.tabPageGeneral.Text = "General";
      this.tabPageGeneral.UseVisualStyleBackColor = true;
      // 
      // textBoxEmail
      // 
      this.textBoxEmail.BackColor = System.Drawing.SystemColors.Info;
      tableLayoutPanel4.SetColumnSpan(this.textBoxEmail, 3);
      this.textBoxEmail.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textBoxEmail.Location = new System.Drawing.Point(102, 179);
      this.textBoxEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.textBoxEmail.Name = "textBoxEmail";
      this.textBoxEmail.Size = new System.Drawing.Size(499, 25);
      this.textBoxEmail.TabIndex = 11;
      // 
      // labelEmail
      // 
      this.labelEmail.AutoSize = true;
      this.labelEmail.Location = new System.Drawing.Point(3, 181);
      this.labelEmail.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.labelEmail.Name = "labelEmail";
      this.labelEmail.Size = new System.Drawing.Size(39, 17);
      this.labelEmail.TabIndex = 10;
      this.labelEmail.Text = "Email";
      // 
      // textBoxUserMessage
      // 
      this.textBoxUserMessage.BackColor = System.Drawing.SystemColors.Info;
      tableLayoutPanel4.SetColumnSpan(this.textBoxUserMessage, 4);
      this.textBoxUserMessage.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textBoxUserMessage.Location = new System.Drawing.Point(3, 235);
      this.textBoxUserMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.textBoxUserMessage.Multiline = true;
      this.textBoxUserMessage.Name = "textBoxUserMessage";
      this.textBoxUserMessage.Size = new System.Drawing.Size(598, 190);
      this.textBoxUserMessage.TabIndex = 9;
      // 
      // labelMessage
      // 
      this.labelMessage.AutoSize = true;
      tableLayoutPanel4.SetColumnSpan(this.labelMessage, 4);
      this.labelMessage.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
      this.labelMessage.Location = new System.Drawing.Point(3, 214);
      this.labelMessage.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.labelMessage.Name = "labelMessage";
      this.labelMessage.Size = new System.Drawing.Size(322, 17);
      this.labelMessage.TabIndex = 8;
      this.labelMessage.Text = "Please tell us how application crashed so we can fix it.";
      // 
      // textBoxTime
      // 
      this.textBoxTime.Cursor = System.Windows.Forms.Cursors.IBeam;
      this.textBoxTime.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textBoxTime.Location = new System.Drawing.Point(357, 146);
      this.textBoxTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.textBoxTime.Name = "textBoxTime";
      this.textBoxTime.ReadOnly = true;
      this.textBoxTime.Size = new System.Drawing.Size(244, 25);
      this.textBoxTime.TabIndex = 7;
      // 
      // labelTime
      // 
      this.labelTime.AutoSize = true;
      this.labelTime.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
      this.labelTime.Location = new System.Drawing.Point(315, 148);
      this.labelTime.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.labelTime.Name = "labelTime";
      this.labelTime.Size = new System.Drawing.Size(36, 17);
      this.labelTime.TabIndex = 6;
      this.labelTime.Text = "Time";
      // 
      // textBoxApplicationVersion
      // 
      this.textBoxApplicationVersion.Cursor = System.Windows.Forms.Cursors.IBeam;
      this.textBoxApplicationVersion.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textBoxApplicationVersion.Location = new System.Drawing.Point(102, 146);
      this.textBoxApplicationVersion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.textBoxApplicationVersion.Name = "textBoxApplicationVersion";
      this.textBoxApplicationVersion.ReadOnly = true;
      this.textBoxApplicationVersion.Size = new System.Drawing.Size(207, 25);
      this.textBoxApplicationVersion.TabIndex = 5;
      // 
      // labelVersion
      // 
      this.labelVersion.AutoSize = true;
      this.labelVersion.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
      this.labelVersion.Location = new System.Drawing.Point(3, 148);
      this.labelVersion.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.labelVersion.Name = "labelVersion";
      this.labelVersion.Size = new System.Drawing.Size(52, 17);
      this.labelVersion.TabIndex = 4;
      this.labelVersion.Text = "Version";
      // 
      // textBoxApplicationName
      // 
      tableLayoutPanel4.SetColumnSpan(this.textBoxApplicationName, 3);
      this.textBoxApplicationName.Cursor = System.Windows.Forms.Cursors.IBeam;
      this.textBoxApplicationName.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textBoxApplicationName.Location = new System.Drawing.Point(102, 113);
      this.textBoxApplicationName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.textBoxApplicationName.Name = "textBoxApplicationName";
      this.textBoxApplicationName.ReadOnly = true;
      this.textBoxApplicationName.Size = new System.Drawing.Size(499, 25);
      this.textBoxApplicationName.TabIndex = 3;
      // 
      // labelApplication
      // 
      this.labelApplication.AutoSize = true;
      this.labelApplication.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
      this.labelApplication.Location = new System.Drawing.Point(3, 115);
      this.labelApplication.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.labelApplication.Name = "labelApplication";
      this.labelApplication.Size = new System.Drawing.Size(73, 17);
      this.labelApplication.TabIndex = 2;
      this.labelApplication.Text = "Application";
      // 
      // textBoxExceptionMessage
      // 
      tableLayoutPanel4.SetColumnSpan(this.textBoxExceptionMessage, 3);
      this.textBoxExceptionMessage.Cursor = System.Windows.Forms.Cursors.IBeam;
      this.textBoxExceptionMessage.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textBoxExceptionMessage.Location = new System.Drawing.Point(102, 4);
      this.textBoxExceptionMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.textBoxExceptionMessage.Multiline = true;
      this.textBoxExceptionMessage.Name = "textBoxExceptionMessage";
      this.textBoxExceptionMessage.ReadOnly = true;
      this.textBoxExceptionMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.textBoxExceptionMessage.Size = new System.Drawing.Size(499, 101);
      this.textBoxExceptionMessage.TabIndex = 1;
      // 
      // pictureBoxError
      // 
      this.pictureBoxError.Image = global::CrashReporterDotNET.Properties.Resources.warning_64;
      this.pictureBoxError.Location = new System.Drawing.Point(3, 4);
      this.pictureBoxError.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.pictureBoxError.Name = "pictureBoxError";
      this.pictureBoxError.Size = new System.Drawing.Size(93, 84);
      this.pictureBoxError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pictureBoxError.TabIndex = 0;
      this.pictureBoxError.TabStop = false;
      // 
      // tabPageExceptions
      // 
      this.tabPageExceptions.Controls.Add(tableLayoutPanel3);
      this.tabPageExceptions.Location = new System.Drawing.Point(4, 26);
      this.tabPageExceptions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.tabPageExceptions.Name = "tabPageExceptions";
      this.tabPageExceptions.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.tabPageExceptions.Size = new System.Drawing.Size(610, 437);
      this.tabPageExceptions.TabIndex = 1;
      this.tabPageExceptions.Text = "Exceptions";
      this.tabPageExceptions.UseVisualStyleBackColor = true;
      // 
      // textBoxException
      // 
      tableLayoutPanel3.SetColumnSpan(this.textBoxException, 2);
      this.textBoxException.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textBoxException.Location = new System.Drawing.Point(3, 21);
      this.textBoxException.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.textBoxException.Name = "textBoxException";
      this.textBoxException.ReadOnly = true;
      this.textBoxException.Size = new System.Drawing.Size(598, 25);
      this.textBoxException.TabIndex = 9;
      // 
      // labelExceptionType
      // 
      this.labelExceptionType.AutoSize = true;
      this.labelExceptionType.Location = new System.Drawing.Point(3, 0);
      this.labelExceptionType.Name = "labelExceptionType";
      this.labelExceptionType.Size = new System.Drawing.Size(96, 17);
      this.labelExceptionType.TabIndex = 7;
      this.labelExceptionType.Text = "Exception Type";
      // 
      // textBoxSource
      // 
      tableLayoutPanel3.SetColumnSpan(this.textBoxSource, 2);
      this.textBoxSource.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textBoxSource.Location = new System.Drawing.Point(3, 157);
      this.textBoxSource.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.textBoxSource.Name = "textBoxSource";
      this.textBoxSource.ReadOnly = true;
      this.textBoxSource.Size = new System.Drawing.Size(598, 25);
      this.textBoxSource.TabIndex = 6;
      // 
      // labelSource
      // 
      this.labelSource.AutoSize = true;
      this.labelSource.Location = new System.Drawing.Point(3, 136);
      this.labelSource.Name = "labelSource";
      this.labelSource.Size = new System.Drawing.Size(48, 17);
      this.labelSource.TabIndex = 5;
      this.labelSource.Text = "Source";
      // 
      // textBoxStackTrace
      // 
      tableLayoutPanel3.SetColumnSpan(this.textBoxStackTrace, 2);
      this.textBoxStackTrace.Cursor = System.Windows.Forms.Cursors.IBeam;
      this.textBoxStackTrace.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textBoxStackTrace.Location = new System.Drawing.Point(3, 207);
      this.textBoxStackTrace.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.textBoxStackTrace.Multiline = true;
      this.textBoxStackTrace.Name = "textBoxStackTrace";
      this.textBoxStackTrace.ReadOnly = true;
      this.textBoxStackTrace.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.textBoxStackTrace.Size = new System.Drawing.Size(598, 218);
      this.textBoxStackTrace.TabIndex = 4;
      // 
      // labelStackTrace
      // 
      this.labelStackTrace.AutoSize = true;
      this.labelStackTrace.Location = new System.Drawing.Point(3, 186);
      this.labelStackTrace.Name = "labelStackTrace";
      this.labelStackTrace.Size = new System.Drawing.Size(74, 17);
      this.labelStackTrace.TabIndex = 3;
      this.labelStackTrace.Text = "Stack Trace";
      // 
      // textBoxMessage
      // 
      tableLayoutPanel3.SetColumnSpan(this.textBoxMessage, 2);
      this.textBoxMessage.Cursor = System.Windows.Forms.Cursors.IBeam;
      this.textBoxMessage.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textBoxMessage.Location = new System.Drawing.Point(3, 71);
      this.textBoxMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.textBoxMessage.Multiline = true;
      this.textBoxMessage.Name = "textBoxMessage";
      this.textBoxMessage.ReadOnly = true;
      this.textBoxMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.textBoxMessage.Size = new System.Drawing.Size(598, 61);
      this.textBoxMessage.TabIndex = 2;
      // 
      // labelExceptionMessage
      // 
      this.labelExceptionMessage.AutoSize = true;
      this.labelExceptionMessage.Location = new System.Drawing.Point(3, 50);
      this.labelExceptionMessage.Name = "labelExceptionMessage";
      this.labelExceptionMessage.Size = new System.Drawing.Size(61, 17);
      this.labelExceptionMessage.TabIndex = 0;
      this.labelExceptionMessage.Text = "Message";
      // 
      // tabPageScreenshot
      // 
      this.tabPageScreenshot.Controls.Add(tableLayoutPanel2);
      this.tabPageScreenshot.Location = new System.Drawing.Point(4, 26);
      this.tabPageScreenshot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.tabPageScreenshot.Name = "tabPageScreenshot";
      this.tabPageScreenshot.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.tabPageScreenshot.Size = new System.Drawing.Size(610, 437);
      this.tabPageScreenshot.TabIndex = 2;
      this.tabPageScreenshot.Text = "Screenshot";
      this.tabPageScreenshot.UseVisualStyleBackColor = true;
      // 
      // linkLabelView
      // 
      this.linkLabelView.AutoSize = true;
      this.linkLabelView.Location = new System.Drawing.Point(475, 0);
      this.linkLabelView.Name = "linkLabelView";
      this.linkLabelView.Size = new System.Drawing.Size(126, 17);
      this.linkLabelView.TabIndex = 3;
      this.linkLabelView.TabStop = true;
      this.linkLabelView.Text = "View Full Screenshot";
      this.linkLabelView.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelViewLinkClicked);
      // 
      // groupBoxScreenshot
      // 
      tableLayoutPanel2.SetColumnSpan(this.groupBoxScreenshot, 3);
      this.groupBoxScreenshot.Controls.Add(this.pictureBoxScreenshot);
      this.groupBoxScreenshot.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBoxScreenshot.Location = new System.Drawing.Point(3, 33);
      this.groupBoxScreenshot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.groupBoxScreenshot.Name = "groupBoxScreenshot";
      this.groupBoxScreenshot.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.groupBoxScreenshot.Size = new System.Drawing.Size(598, 392);
      this.groupBoxScreenshot.TabIndex = 2;
      this.groupBoxScreenshot.TabStop = false;
      this.groupBoxScreenshot.Text = "Screenshot";
      // 
      // pictureBoxScreenshot
      // 
      this.pictureBoxScreenshot.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureBoxScreenshot.Location = new System.Drawing.Point(3, 22);
      this.pictureBoxScreenshot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.pictureBoxScreenshot.Name = "pictureBoxScreenshot";
      this.pictureBoxScreenshot.Size = new System.Drawing.Size(592, 366);
      this.pictureBoxScreenshot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBoxScreenshot.TabIndex = 0;
      this.pictureBoxScreenshot.TabStop = false;
      // 
      // checkBoxIncludeScreenshot
      // 
      this.checkBoxIncludeScreenshot.AutoSize = true;
      this.checkBoxIncludeScreenshot.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.checkBoxIncludeScreenshot.Location = new System.Drawing.Point(3, 4);
      this.checkBoxIncludeScreenshot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.checkBoxIncludeScreenshot.Name = "checkBoxIncludeScreenshot";
      this.checkBoxIncludeScreenshot.Size = new System.Drawing.Size(136, 21);
      this.checkBoxIncludeScreenshot.TabIndex = 1;
      this.checkBoxIncludeScreenshot.Text = "Include Screenshot";
      this.toolTip.SetToolTip(this.checkBoxIncludeScreenshot, "Add screenshot of error screen in your crash report.");
      this.checkBoxIncludeScreenshot.UseVisualStyleBackColor = true;
      // 
      // buttonSave
      // 
      this.buttonSave.AllowDrop = true;
      this.buttonSave.Image = global::CrashReporterDotNET.Properties.Resources.save_as;
      this.buttonSave.Location = new System.Drawing.Point(337, 479);
      this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.buttonSave.Name = "buttonSave";
      this.buttonSave.Size = new System.Drawing.Size(139, 56);
      this.buttonSave.TabIndex = 3;
      this.buttonSave.Text = "Save";
      this.buttonSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.buttonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.buttonSave.UseVisualStyleBackColor = true;
      this.buttonSave.Click += new System.EventHandler(this.ButtonSaveClick);
      // 
      // buttonCancel
      // 
      this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonCancel.Image = global::CrashReporterDotNET.Properties.Resources.stop;
      this.buttonCancel.Location = new System.Drawing.Point(482, 479);
      this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(139, 56);
      this.buttonCancel.TabIndex = 2;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
      // 
      // buttonSendReport
      // 
      this.buttonSendReport.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.buttonSendReport.Image = global::CrashReporterDotNET.Properties.Resources.email_go;
      this.buttonSendReport.Location = new System.Drawing.Point(192, 479);
      this.buttonSendReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.buttonSendReport.Name = "buttonSendReport";
      this.buttonSendReport.Size = new System.Drawing.Size(139, 56);
      this.buttonSendReport.TabIndex = 1;
      this.buttonSendReport.Text = "Send Report";
      this.buttonSendReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.buttonSendReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.buttonSendReport.UseVisualStyleBackColor = true;
      this.buttonSendReport.Click += new System.EventHandler(this.ButtonSendReportClick);
      // 
      // saveFileDialog
      // 
      this.saveFileDialog.Filter = "HTML files(*.html)|*.html";
      this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFileDialogFileOk);
      // 
      // toolTip
      // 
      this.toolTip.AutomaticDelay = 1;
      this.toolTip.AutoPopDelay = 50000000;
      this.toolTip.InitialDelay = 1;
      this.toolTip.IsBalloon = true;
      this.toolTip.ReshowDelay = 0;
      this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
      this.toolTip.ToolTipTitle = "Include application screenshot";
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 4;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.Controls.Add(this.tabControl, 0, 0);
      tableLayoutPanel1.Controls.Add(this.buttonCancel, 3, 1);
      tableLayoutPanel1.Controls.Add(this.buttonSave, 2, 1);
      tableLayoutPanel1.Controls.Add(this.buttonSendReport, 1, 1);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 2;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(624, 539);
      tableLayoutPanel1.TabIndex = 4;
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.ColumnCount = 3;
      tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel2.Controls.Add(this.checkBoxIncludeScreenshot, 0, 0);
      tableLayoutPanel2.Controls.Add(this.groupBoxScreenshot, 0, 1);
      tableLayoutPanel2.Controls.Add(this.linkLabelView, 2, 0);
      tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel2.Location = new System.Drawing.Point(3, 4);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 2;
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel2.Size = new System.Drawing.Size(604, 429);
      tableLayoutPanel2.TabIndex = 4;
      // 
      // tableLayoutPanel3
      // 
      tableLayoutPanel3.ColumnCount = 2;
      tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel3.Controls.Add(this.labelExceptionType, 0, 0);
      tableLayoutPanel3.Controls.Add(this.textBoxStackTrace, 0, 7);
      tableLayoutPanel3.Controls.Add(this.textBoxSource, 0, 5);
      tableLayoutPanel3.Controls.Add(this.labelStackTrace, 0, 6);
      tableLayoutPanel3.Controls.Add(this.textBoxException, 0, 1);
      tableLayoutPanel3.Controls.Add(this.labelSource, 0, 4);
      tableLayoutPanel3.Controls.Add(this.labelExceptionMessage, 0, 2);
      tableLayoutPanel3.Controls.Add(this.textBoxMessage, 0, 3);
      tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel3.Location = new System.Drawing.Point(3, 4);
      tableLayoutPanel3.Name = "tableLayoutPanel3";
      tableLayoutPanel3.RowCount = 8;
      tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel3.Size = new System.Drawing.Size(604, 429);
      tableLayoutPanel3.TabIndex = 10;
      // 
      // tableLayoutPanel4
      // 
      tableLayoutPanel4.AutoSize = true;
      tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      tableLayoutPanel4.ColumnCount = 4;
      tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel4.Controls.Add(this.pictureBoxError, 0, 0);
      tableLayoutPanel4.Controls.Add(this.textBoxUserMessage, 0, 5);
      tableLayoutPanel4.Controls.Add(this.textBoxEmail, 1, 3);
      tableLayoutPanel4.Controls.Add(this.labelMessage, 0, 4);
      tableLayoutPanel4.Controls.Add(this.textBoxExceptionMessage, 1, 0);
      tableLayoutPanel4.Controls.Add(this.labelEmail, 0, 3);
      tableLayoutPanel4.Controls.Add(this.labelApplication, 0, 1);
      tableLayoutPanel4.Controls.Add(this.textBoxApplicationName, 1, 1);
      tableLayoutPanel4.Controls.Add(this.labelVersion, 0, 2);
      tableLayoutPanel4.Controls.Add(this.textBoxTime, 3, 2);
      tableLayoutPanel4.Controls.Add(this.textBoxApplicationVersion, 1, 2);
      tableLayoutPanel4.Controls.Add(this.labelTime, 2, 2);
      tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel4.Location = new System.Drawing.Point(3, 4);
      tableLayoutPanel4.Name = "tableLayoutPanel4";
      tableLayoutPanel4.RowCount = 6;
      tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel4.Size = new System.Drawing.Size(604, 429);
      tableLayoutPanel4.TabIndex = 12;
      // 
      // CrashReport
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(624, 539);
      this.Controls.Add(tableLayoutPanel1);
      this.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "CrashReport";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "CrashReport";
      this.Load += new System.EventHandler(this.CrashReportLoad);
      this.tabControl.ResumeLayout(false);
      this.tabPageGeneral.ResumeLayout(false);
      this.tabPageGeneral.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxError)).EndInit();
      this.tabPageExceptions.ResumeLayout(false);
      this.tabPageScreenshot.ResumeLayout(false);
      this.groupBoxScreenshot.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreenshot)).EndInit();
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel2.ResumeLayout(false);
      tableLayoutPanel2.PerformLayout();
      tableLayoutPanel3.ResumeLayout(false);
      tableLayoutPanel3.PerformLayout();
      tableLayoutPanel4.ResumeLayout(false);
      tableLayoutPanel4.PerformLayout();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.TabPage tabPageExceptions;
        private System.Windows.Forms.Button buttonSendReport;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.PictureBox pictureBoxError;
        private System.Windows.Forms.TextBox textBoxExceptionMessage;
        private System.Windows.Forms.TextBox textBoxApplicationVersion;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.TextBox textBoxApplicationName;
        private System.Windows.Forms.Label labelApplication;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.TextBox textBoxUserMessage;
        private System.Windows.Forms.TextBox textBoxStackTrace;
        private System.Windows.Forms.Label labelStackTrace;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Label labelExceptionMessage;
        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxException;
        private System.Windows.Forms.Label labelExceptionType;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TabPage tabPageScreenshot;
        private System.Windows.Forms.PictureBox pictureBoxScreenshot;
        private System.Windows.Forms.GroupBox groupBoxScreenshot;
        private System.Windows.Forms.CheckBox checkBoxIncludeScreenshot;
        private System.Windows.Forms.LinkLabel linkLabelView;
    }
}