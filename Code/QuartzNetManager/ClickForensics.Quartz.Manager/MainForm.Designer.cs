namespace ClickForensics.Quartz.Manager
{
    partial class MainForm
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
      this.listView_RunningJobs = new System.Windows.Forms.ListView();
      this.JobName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.JobDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.label2 = new System.Windows.Forms.Label();
      this.btnRefreshRunningJobs = new System.Windows.Forms.Button();
      this.pnlDetails = new System.Windows.Forms.Panel();
      this.label3 = new System.Windows.Forms.Label();
      this.btnRunJobNow = new System.Windows.Forms.Button();
      this.btnPause = new System.Windows.Forms.Button();
      this.btnDeleteJob = new System.Windows.Forms.Button();
      this.btnEdit = new System.Windows.Forms.Button();
      this.jobGroupsTreeView = new System.Windows.Forms.TreeView();
      this.label1 = new System.Windows.Forms.Label();
      this.btnRefreshJobGroups = new System.Windows.Forms.Button();
      this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
      this.schedulerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.jobsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.addJobToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.listenersStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.jobAssembliesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.addAssemblyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.deleteAssemblyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.globalListenersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.addGlobalJobListenerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.addTriggerListenerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.addJobListenerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.serverConnectStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.StripStatusLabel_Job_Groups = new System.Windows.Forms.ToolStripStatusLabel();
      this.StripStatusLabel_Jobs_Refresh_date = new System.Windows.Forms.ToolStripStatusLabel();
      this.ctxScheduler = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.timer_Refresh_Running_Jobs = new System.Windows.Forms.Timer(this.components);
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
      tableLayoutPanel3.SuspendLayout();
      tableLayoutPanel4.SuspendLayout();
      this.mainMenuStrip.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.ctxScheduler.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.AutoSize = true;
      tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel4.SetColumnSpan(tableLayoutPanel1, 2);
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
      tableLayoutPanel1.Controls.Add(this.listView_RunningJobs, 0, 1);
      tableLayoutPanel1.Controls.Add(this.btnRefreshRunningJobs, 1, 2);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(3, 385);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 3;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(1216, 376);
      tableLayoutPanel1.TabIndex = 15;
      // 
      // listView_RunningJobs
      // 
      this.listView_RunningJobs.AllowColumnReorder = true;
      this.listView_RunningJobs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.JobName,
            this.JobDuration});
      tableLayoutPanel1.SetColumnSpan(this.listView_RunningJobs, 3);
      this.listView_RunningJobs.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listView_RunningJobs.Location = new System.Drawing.Point(3, 22);
      this.listView_RunningJobs.Name = "listView_RunningJobs";
      this.listView_RunningJobs.Size = new System.Drawing.Size(1210, 322);
      this.listView_RunningJobs.Sorting = System.Windows.Forms.SortOrder.Ascending;
      this.listView_RunningJobs.TabIndex = 14;
      this.listView_RunningJobs.UseCompatibleStateImageBehavior = false;
      this.listView_RunningJobs.View = System.Windows.Forms.View.Details;
      // 
      // JobName
      // 
      this.JobName.Text = "Job Name";
      // 
      // JobDuration
      // 
      this.JobDuration.Text = "Duration";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(3, 3);
      this.label2.Margin = new System.Windows.Forms.Padding(3);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(72, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Running Jobs";
      // 
      // btnRefreshRunningJobs
      // 
      this.btnRefreshRunningJobs.Location = new System.Drawing.Point(570, 350);
      this.btnRefreshRunningJobs.Name = "btnRefreshRunningJobs";
      this.btnRefreshRunningJobs.Size = new System.Drawing.Size(75, 23);
      this.btnRefreshRunningJobs.TabIndex = 6;
      this.btnRefreshRunningJobs.Text = "Refresh";
      this.btnRefreshRunningJobs.UseVisualStyleBackColor = true;
      this.btnRefreshRunningJobs.Click += new System.EventHandler(this.btnRefreshRunningJobs_Click);
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.AutoSize = true;
      tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      tableLayoutPanel2.ColumnCount = 5;
      tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
      tableLayoutPanel2.Controls.Add(this.pnlDetails, 0, 1);
      tableLayoutPanel2.Controls.Add(this.btnRunJobNow, 0, 2);
      tableLayoutPanel2.Controls.Add(this.btnPause, 1, 2);
      tableLayoutPanel2.Controls.Add(this.btnDeleteJob, 2, 2);
      tableLayoutPanel2.Controls.Add(this.btnEdit, 3, 2);
      tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel2.Location = new System.Drawing.Point(614, 3);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 3;
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel2.Size = new System.Drawing.Size(605, 376);
      tableLayoutPanel2.TabIndex = 16;
      // 
      // pnlDetails
      // 
      this.pnlDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      tableLayoutPanel2.SetColumnSpan(this.pnlDetails, 5);
      this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlDetails.Location = new System.Drawing.Point(3, 22);
      this.pnlDetails.Name = "pnlDetails";
      this.pnlDetails.Size = new System.Drawing.Size(599, 322);
      this.pnlDetails.TabIndex = 11;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(3, 3);
      this.label3.Margin = new System.Windows.Forms.Padding(3);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(39, 13);
      this.label3.TabIndex = 12;
      this.label3.Text = "Details";
      // 
      // btnRunJobNow
      // 
      this.btnRunJobNow.Enabled = false;
      this.btnRunJobNow.Location = new System.Drawing.Point(3, 350);
      this.btnRunJobNow.Name = "btnRunJobNow";
      this.btnRunJobNow.Size = new System.Drawing.Size(65, 23);
      this.btnRunJobNow.TabIndex = 9;
      this.btnRunJobNow.Text = "Run";
      this.btnRunJobNow.UseVisualStyleBackColor = true;
      this.btnRunJobNow.Click += new System.EventHandler(this.btnRunJobNow_Click);
      // 
      // btnPause
      // 
      this.btnPause.Enabled = false;
      this.btnPause.Location = new System.Drawing.Point(74, 350);
      this.btnPause.Name = "btnPause";
      this.btnPause.Size = new System.Drawing.Size(65, 23);
      this.btnPause.TabIndex = 10;
      this.btnPause.Text = "Pause";
      this.btnPause.UseVisualStyleBackColor = true;
      this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
      // 
      // btnDeleteJob
      // 
      this.btnDeleteJob.Enabled = false;
      this.btnDeleteJob.Location = new System.Drawing.Point(145, 350);
      this.btnDeleteJob.Name = "btnDeleteJob";
      this.btnDeleteJob.Size = new System.Drawing.Size(65, 23);
      this.btnDeleteJob.TabIndex = 8;
      this.btnDeleteJob.Text = "Delete";
      this.btnDeleteJob.UseVisualStyleBackColor = true;
      this.btnDeleteJob.Click += new System.EventHandler(this.btnDeleteJob_Click);
      // 
      // btnEdit
      // 
      this.btnEdit.Enabled = false;
      this.btnEdit.Location = new System.Drawing.Point(216, 350);
      this.btnEdit.Name = "btnEdit";
      this.btnEdit.Size = new System.Drawing.Size(65, 23);
      this.btnEdit.TabIndex = 13;
      this.btnEdit.Text = "Edit";
      this.btnEdit.UseVisualStyleBackColor = true;
      this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
      // 
      // tableLayoutPanel3
      // 
      tableLayoutPanel3.AutoSize = true;
      tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      tableLayoutPanel3.ColumnCount = 2;
      tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
      tableLayoutPanel3.Controls.Add(this.btnRefreshJobGroups, 1, 2);
      tableLayoutPanel3.Controls.Add(this.jobGroupsTreeView, 0, 1);
      tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
      tableLayoutPanel3.Name = "tableLayoutPanel3";
      tableLayoutPanel3.RowCount = 3;
      tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel3.Size = new System.Drawing.Size(605, 376);
      tableLayoutPanel3.TabIndex = 17;
      // 
      // jobGroupsTreeView
      // 
      tableLayoutPanel3.SetColumnSpan(this.jobGroupsTreeView, 2);
      this.jobGroupsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.jobGroupsTreeView.HideSelection = false;
      this.jobGroupsTreeView.Location = new System.Drawing.Point(3, 22);
      this.jobGroupsTreeView.Name = "jobGroupsTreeView";
      this.jobGroupsTreeView.Size = new System.Drawing.Size(599, 322);
      this.jobGroupsTreeView.TabIndex = 2;
      this.jobGroupsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.jobGroupsTreeView_AfterSelect);
      this.jobGroupsTreeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.jobGroupsTreeView_MouseDown);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 3);
      this.label1.Margin = new System.Windows.Forms.Padding(3);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(94, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "Scheduler Objects";
      // 
      // btnRefreshJobGroups
      // 
      this.btnRefreshJobGroups.Location = new System.Drawing.Point(527, 350);
      this.btnRefreshJobGroups.Name = "btnRefreshJobGroups";
      this.btnRefreshJobGroups.Size = new System.Drawing.Size(75, 23);
      this.btnRefreshJobGroups.TabIndex = 7;
      this.btnRefreshJobGroups.Text = "Refresh";
      this.btnRefreshJobGroups.UseVisualStyleBackColor = true;
      this.btnRefreshJobGroups.Click += new System.EventHandler(this.btnRefreshJobGroups_Click);
      // 
      // tableLayoutPanel4
      // 
      tableLayoutPanel4.AutoSize = true;
      tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      tableLayoutPanel4.ColumnCount = 2;
      tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      tableLayoutPanel4.Controls.Add(tableLayoutPanel2, 1, 0);
      tableLayoutPanel4.Controls.Add(tableLayoutPanel1, 0, 1);
      tableLayoutPanel4.Controls.Add(tableLayoutPanel3, 0, 0);
      tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel4.Location = new System.Drawing.Point(0, 24);
      tableLayoutPanel4.Name = "tableLayoutPanel4";
      tableLayoutPanel4.RowCount = 2;
      tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      tableLayoutPanel4.Size = new System.Drawing.Size(1222, 764);
      tableLayoutPanel4.TabIndex = 18;
      // 
      // mainMenuStrip
      // 
      this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.schedulerToolStripMenuItem,
            this.jobsToolStripMenuItem,
            this.listenersStripMenuItem,
            this.jobAssembliesToolStripMenuItem});
      this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
      this.mainMenuStrip.Name = "mainMenuStrip";
      this.mainMenuStrip.Size = new System.Drawing.Size(1222, 24);
      this.mainMenuStrip.TabIndex = 0;
      this.mainMenuStrip.Text = "menuStrip1";
      // 
      // schedulerToolStripMenuItem
      // 
      this.schedulerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem});
      this.schedulerToolStripMenuItem.Name = "schedulerToolStripMenuItem";
      this.schedulerToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
      this.schedulerToolStripMenuItem.Text = "Scheduler";
      // 
      // connectToolStripMenuItem
      // 
      this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
      this.connectToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
      this.connectToolStripMenuItem.Text = "Connect";
      this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
      // 
      // jobsToolStripMenuItem
      // 
      this.jobsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addJobToolStripMenuItem});
      this.jobsToolStripMenuItem.Enabled = false;
      this.jobsToolStripMenuItem.Name = "jobsToolStripMenuItem";
      this.jobsToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
      this.jobsToolStripMenuItem.Text = "Jobs";
      // 
      // addJobToolStripMenuItem
      // 
      this.addJobToolStripMenuItem.Name = "addJobToolStripMenuItem";
      this.addJobToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
      this.addJobToolStripMenuItem.Text = "Add";
      this.addJobToolStripMenuItem.Click += new System.EventHandler(this.addJobToolStripMenuItem_Click);
      // 
      // listenersStripMenuItem
      // 
      this.listenersStripMenuItem.Name = "listenersStripMenuItem";
      this.listenersStripMenuItem.Size = new System.Drawing.Size(12, 20);
      // 
      // jobAssembliesToolStripMenuItem
      // 
      this.jobAssembliesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAssemblyMenuItem,
            this.deleteAssemblyMenuItem});
      this.jobAssembliesToolStripMenuItem.Name = "jobAssembliesToolStripMenuItem";
      this.jobAssembliesToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
      this.jobAssembliesToolStripMenuItem.Text = "Job Assemblies";
      // 
      // addAssemblyMenuItem
      // 
      this.addAssemblyMenuItem.Name = "addAssemblyMenuItem";
      this.addAssemblyMenuItem.Size = new System.Drawing.Size(107, 22);
      this.addAssemblyMenuItem.Text = "Add";
      this.addAssemblyMenuItem.Click += new System.EventHandler(this.addAssemblyMenuItem_Click);
      // 
      // deleteAssemblyMenuItem
      // 
      this.deleteAssemblyMenuItem.Name = "deleteAssemblyMenuItem";
      this.deleteAssemblyMenuItem.Size = new System.Drawing.Size(107, 22);
      this.deleteAssemblyMenuItem.Text = "Delete";
      this.deleteAssemblyMenuItem.Click += new System.EventHandler(this.deleteAssemblyMenuItem_Click);
      // 
      // globalListenersToolStripMenuItem
      // 
      this.globalListenersToolStripMenuItem.Name = "globalListenersToolStripMenuItem";
      this.globalListenersToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
      // 
      // addGlobalJobListenerToolStripMenuItem
      // 
      this.addGlobalJobListenerToolStripMenuItem.Name = "addGlobalJobListenerToolStripMenuItem";
      this.addGlobalJobListenerToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
      // 
      // addTriggerListenerToolStripMenuItem
      // 
      this.addTriggerListenerToolStripMenuItem.Name = "addTriggerListenerToolStripMenuItem";
      this.addTriggerListenerToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
      // 
      // addJobListenerToolStripMenuItem
      // 
      this.addJobListenerToolStripMenuItem.Name = "addJobListenerToolStripMenuItem";
      this.addJobListenerToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverConnectStatusLabel,
            this.StripStatusLabel_Job_Groups,
            this.StripStatusLabel_Jobs_Refresh_date});
      this.statusStrip1.Location = new System.Drawing.Point(0, 788);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(1222, 22);
      this.statusStrip1.TabIndex = 1;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // serverConnectStatusLabel
      // 
      this.serverConnectStatusLabel.Name = "serverConnectStatusLabel";
      this.serverConnectStatusLabel.Size = new System.Drawing.Size(86, 17);
      this.serverConnectStatusLabel.Text = "Not connected";
      // 
      // StripStatusLabel_Job_Groups
      // 
      this.StripStatusLabel_Job_Groups.BackColor = System.Drawing.Color.LightCyan;
      this.StripStatusLabel_Job_Groups.Name = "StripStatusLabel_Job_Groups";
      this.StripStatusLabel_Job_Groups.Size = new System.Drawing.Size(157, 17);
      this.StripStatusLabel_Job_Groups.Text = "StripStatusLabel_Job_Groups";
      this.StripStatusLabel_Job_Groups.ToolTipText = "Last Refresh of Job Groups";
      // 
      // StripStatusLabel_Jobs_Refresh_date
      // 
      this.StripStatusLabel_Jobs_Refresh_date.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.StripStatusLabel_Jobs_Refresh_date.Name = "StripStatusLabel_Jobs_Refresh_date";
      this.StripStatusLabel_Jobs_Refresh_date.Size = new System.Drawing.Size(191, 17);
      this.StripStatusLabel_Jobs_Refresh_date.Text = "StripStatusLabel_Jobs_Refresh_date";
      this.StripStatusLabel_Jobs_Refresh_date.ToolTipText = "Last Refresh Date of Running Jobs";
      // 
      // ctxScheduler
      // 
      this.ctxScheduler.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupToolStripMenuItem});
      this.ctxScheduler.Name = "ctxScheduler";
      this.ctxScheduler.Size = new System.Drawing.Size(114, 26);
      // 
      // backupToolStripMenuItem
      // 
      this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
      this.backupToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
      this.backupToolStripMenuItem.Text = "Backup";
      this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
      // 
      // timer_Refresh_Running_Jobs
      // 
      this.timer_Refresh_Running_Jobs.Interval = 30000;
      this.timer_Refresh_Running_Jobs.Tick += new System.EventHandler(this.timer_Refresh_Running_Jobs_Tick);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1222, 810);
      this.Controls.Add(tableLayoutPanel4);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.mainMenuStrip);
      this.MainMenuStrip = this.mainMenuStrip;
      this.Name = "MainForm";
      this.Text = "Quartz Manager";
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      tableLayoutPanel2.ResumeLayout(false);
      tableLayoutPanel2.PerformLayout();
      tableLayoutPanel3.ResumeLayout(false);
      tableLayoutPanel3.PerformLayout();
      tableLayoutPanel4.ResumeLayout(false);
      tableLayoutPanel4.PerformLayout();
      this.mainMenuStrip.ResumeLayout(false);
      this.mainMenuStrip.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ctxScheduler.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem schedulerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel serverConnectStatusLabel;
        private System.Windows.Forms.TreeView jobGroupsTreeView;
        private System.Windows.Forms.ToolStripMenuItem listenersStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem globalListenersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addGlobalJobListenerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTriggerListenerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addJobListenerToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem jobsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addJobToolStripMenuItem;
        private System.Windows.Forms.Button btnRefreshRunningJobs;
        private System.Windows.Forms.Button btnRefreshJobGroups;
        private System.Windows.Forms.Button btnDeleteJob;
        private System.Windows.Forms.Button btnRunJobNow;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ContextMenuStrip ctxScheduler;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.Timer timer_Refresh_Running_Jobs;
        private System.Windows.Forms.ToolStripStatusLabel StripStatusLabel_Jobs_Refresh_date;
        private System.Windows.Forms.ToolStripStatusLabel StripStatusLabel_Job_Groups;
        private System.Windows.Forms.ListView listView_RunningJobs;
        private System.Windows.Forms.ColumnHeader JobName;
        private System.Windows.Forms.ColumnHeader JobDuration;
        private System.Windows.Forms.ToolStripMenuItem jobAssembliesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAssemblyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAssemblyMenuItem;
    }
}

