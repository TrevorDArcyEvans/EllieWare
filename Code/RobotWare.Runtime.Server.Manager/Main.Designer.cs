//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace RobotWare.Runtime.Server.Manager
{
  sealed partial class Main
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
      System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      System.Windows.Forms.StatusStrip statusStrip1;
      System.Windows.Forms.GroupBox groupBox1;
      System.Windows.Forms.GroupBox groupBox2;
      System.Windows.Forms.SplitContainer splitContainer2;
      System.Windows.Forms.ImageList imageList1;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
      System.Windows.Forms.SplitContainer splitContainer1;
      System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      System.Windows.Forms.ToolStripButton CmdAbout;
      this.ServerConnectStatus = new System.Windows.Forms.ToolStripStatusLabel();
      this.StripStatusLabel_Job_Groups = new System.Windows.Forms.ToolStripStatusLabel();
      this.RefreshDate = new System.Windows.Forms.ToolStripStatusLabel();
      this.RunningJobs = new System.Windows.Forms.ListView();
      this.JobName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.JobDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.SchedulerView = new System.Windows.Forms.TreeView();
      this.pnlDetails = new System.Windows.Forms.Panel();
      this.ScheduleToolstrip = new System.Windows.Forms.ToolStrip();
      this.CmdRefreshScheduled = new System.Windows.Forms.ToolStripButton();
      this.CmdRunJobNow = new System.Windows.Forms.ToolStripButton();
      this.CmdPause = new System.Windows.Forms.ToolStripButton();
      this.CmdDelete = new System.Windows.Forms.ToolStripButton();
      this.CmdAdd = new System.Windows.Forms.ToolStripButton();
      this.CmdEdit = new System.Windows.Forms.ToolStripButton();
      this.MainTab = new System.Windows.Forms.TabControl();
      this.SchedulesTab = new System.Windows.Forms.TabPage();
      this.SpecificationTab = new System.Windows.Forms.TabPage();
      this.RefreshScheduler = new System.Windows.Forms.Timer(this.components);
      toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      statusStrip1 = new System.Windows.Forms.StatusStrip();
      groupBox1 = new System.Windows.Forms.GroupBox();
      groupBox2 = new System.Windows.Forms.GroupBox();
      splitContainer2 = new System.Windows.Forms.SplitContainer();
      imageList1 = new System.Windows.Forms.ImageList(this.components);
      splitContainer1 = new System.Windows.Forms.SplitContainer();
      toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      CmdAbout = new System.Windows.Forms.ToolStripButton();
      statusStrip1.SuspendLayout();
      groupBox1.SuspendLayout();
      groupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(splitContainer2)).BeginInit();
      splitContainer2.Panel1.SuspendLayout();
      splitContainer2.Panel2.SuspendLayout();
      splitContainer2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(splitContainer1)).BeginInit();
      splitContainer1.Panel1.SuspendLayout();
      splitContainer1.Panel2.SuspendLayout();
      splitContainer1.SuspendLayout();
      this.ScheduleToolstrip.SuspendLayout();
      this.MainTab.SuspendLayout();
      this.SchedulesTab.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolStripSeparator1
      // 
      toolStripSeparator1.Name = "toolStripSeparator1";
      toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
      // 
      // statusStrip1
      // 
      statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ServerConnectStatus,
            this.StripStatusLabel_Job_Groups,
            this.RefreshDate});
      statusStrip1.Location = new System.Drawing.Point(0, 620);
      statusStrip1.Name = "statusStrip1";
      statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
      statusStrip1.Size = new System.Drawing.Size(935, 25);
      statusStrip1.TabIndex = 1;
      statusStrip1.Text = "statusStrip1";
      // 
      // ServerConnectStatus
      // 
      this.ServerConnectStatus.Name = "ServerConnectStatus";
      this.ServerConnectStatus.Size = new System.Drawing.Size(107, 20);
      this.ServerConnectStatus.Text = "Not connected";
      // 
      // StripStatusLabel_Job_Groups
      // 
      this.StripStatusLabel_Job_Groups.BackColor = System.Drawing.Color.LightCyan;
      this.StripStatusLabel_Job_Groups.Name = "StripStatusLabel_Job_Groups";
      this.StripStatusLabel_Job_Groups.Size = new System.Drawing.Size(0, 20);
      this.StripStatusLabel_Job_Groups.ToolTipText = "Last Refresh of Running Jobs";
      // 
      // RefreshDate
      // 
      this.RefreshDate.BackColor = System.Drawing.Color.LightCyan;
      this.RefreshDate.Name = "RefreshDate";
      this.RefreshDate.Size = new System.Drawing.Size(0, 20);
      this.RefreshDate.ToolTipText = "Last Refresh Date of Running Jobs";
      // 
      // groupBox1
      // 
      groupBox1.Controls.Add(this.RunningJobs);
      groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      groupBox1.Location = new System.Drawing.Point(4, 4);
      groupBox1.Margin = new System.Windows.Forms.Padding(4);
      groupBox1.Name = "groupBox1";
      groupBox1.Padding = new System.Windows.Forms.Padding(4);
      groupBox1.Size = new System.Drawing.Size(913, 260);
      groupBox1.TabIndex = 0;
      groupBox1.TabStop = false;
      groupBox1.Text = "Running";
      // 
      // RunningJobs
      // 
      this.RunningJobs.AllowColumnReorder = true;
      this.RunningJobs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.JobName,
            this.JobDuration});
      this.RunningJobs.Dock = System.Windows.Forms.DockStyle.Fill;
      this.RunningJobs.Location = new System.Drawing.Point(4, 19);
      this.RunningJobs.Margin = new System.Windows.Forms.Padding(4);
      this.RunningJobs.Name = "RunningJobs";
      this.RunningJobs.Size = new System.Drawing.Size(905, 237);
      this.RunningJobs.Sorting = System.Windows.Forms.SortOrder.Ascending;
      this.RunningJobs.TabIndex = 0;
      this.RunningJobs.UseCompatibleStateImageBehavior = false;
      this.RunningJobs.View = System.Windows.Forms.View.Details;
      // 
      // JobName
      // 
      this.JobName.Text = "Job Name";
      this.JobName.Width = 250;
      // 
      // JobDuration
      // 
      this.JobDuration.Text = "Duration (s)";
      this.JobDuration.Width = 80;
      // 
      // groupBox2
      // 
      groupBox2.Controls.Add(splitContainer2);
      groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
      groupBox2.Location = new System.Drawing.Point(4, 4);
      groupBox2.Margin = new System.Windows.Forms.Padding(4);
      groupBox2.Name = "groupBox2";
      groupBox2.Padding = new System.Windows.Forms.Padding(4);
      groupBox2.Size = new System.Drawing.Size(913, 265);
      groupBox2.TabIndex = 0;
      groupBox2.TabStop = false;
      groupBox2.Text = "Scheduled";
      // 
      // splitContainer2
      // 
      splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
      splitContainer2.Location = new System.Drawing.Point(4, 19);
      splitContainer2.Margin = new System.Windows.Forms.Padding(4);
      splitContainer2.Name = "splitContainer2";
      // 
      // splitContainer2.Panel1
      // 
      splitContainer2.Panel1.Controls.Add(this.SchedulerView);
      // 
      // splitContainer2.Panel2
      // 
      splitContainer2.Panel2.Controls.Add(this.pnlDetails);
      splitContainer2.Size = new System.Drawing.Size(905, 242);
      splitContainer2.SplitterDistance = 413;
      splitContainer2.SplitterWidth = 5;
      splitContainer2.TabIndex = 13;
      // 
      // SchedulerView
      // 
      this.SchedulerView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SchedulerView.HideSelection = false;
      this.SchedulerView.ImageIndex = 0;
      this.SchedulerView.ImageList = imageList1;
      this.SchedulerView.Location = new System.Drawing.Point(0, 0);
      this.SchedulerView.Margin = new System.Windows.Forms.Padding(4);
      this.SchedulerView.Name = "SchedulerView";
      this.SchedulerView.SelectedImageIndex = 0;
      this.SchedulerView.Size = new System.Drawing.Size(413, 242);
      this.SchedulerView.TabIndex = 0;
      this.SchedulerView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.SchedulerView_AfterSelect);
      // 
      // imageList1
      // 
      imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      imageList1.TransparentColor = System.Drawing.Color.Transparent;
      imageList1.Images.SetKeyName(0, "calendar_16x16.png");
      imageList1.Images.SetKeyName(1, "clock_16x16.png");
      imageList1.Images.SetKeyName(2, "hardhat_16x16.png");
      imageList1.Images.SetKeyName(3, "windup_key_6x16.png");
      imageList1.Images.SetKeyName(4, "users_family_16x16.png");
      imageList1.Images.SetKeyName(5, "date_time_16x16.png");
      imageList1.Images.SetKeyName(6, "schoolboy_16x16.png");
      imageList1.Images.SetKeyName(7, "factory_16x16.png");
      // 
      // pnlDetails
      // 
      this.pnlDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlDetails.Location = new System.Drawing.Point(0, 0);
      this.pnlDetails.Margin = new System.Windows.Forms.Padding(4);
      this.pnlDetails.Name = "pnlDetails";
      this.pnlDetails.Size = new System.Drawing.Size(487, 242);
      this.pnlDetails.TabIndex = 0;
      // 
      // splitContainer1
      // 
      splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      splitContainer1.Location = new System.Drawing.Point(3, 3);
      splitContainer1.Margin = new System.Windows.Forms.Padding(4);
      splitContainer1.Name = "splitContainer1";
      splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      splitContainer1.Panel1.Controls.Add(groupBox2);
      splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(4);
      // 
      // splitContainer1.Panel2
      // 
      splitContainer1.Panel2.Controls.Add(groupBox1);
      splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(4);
      splitContainer1.Size = new System.Drawing.Size(921, 546);
      splitContainer1.SplitterDistance = 273;
      splitContainer1.SplitterWidth = 5;
      splitContainer1.TabIndex = 18;
      // 
      // toolStripSeparator2
      // 
      toolStripSeparator2.Name = "toolStripSeparator2";
      toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
      // 
      // CmdAbout
      // 
      CmdAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      CmdAbout.Image = global::RobotWare.Runtime.Server.Manager.Properties.Resources.information_32x32;
      CmdAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
      CmdAbout.Name = "CmdAbout";
      CmdAbout.Size = new System.Drawing.Size(36, 36);
      CmdAbout.Text = "About...";
      CmdAbout.Click += new System.EventHandler(this.CmdAbout_Click);
      // 
      // ScheduleToolstrip
      // 
      this.ScheduleToolstrip.ImageScalingSize = new System.Drawing.Size(32, 32);
      this.ScheduleToolstrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmdRefreshScheduled,
            this.CmdRunJobNow,
            this.CmdPause,
            toolStripSeparator1,
            this.CmdDelete,
            this.CmdAdd,
            this.CmdEdit,
            toolStripSeparator2,
            CmdAbout});
      this.ScheduleToolstrip.Location = new System.Drawing.Point(0, 0);
      this.ScheduleToolstrip.Name = "ScheduleToolstrip";
      this.ScheduleToolstrip.Size = new System.Drawing.Size(935, 39);
      this.ScheduleToolstrip.TabIndex = 0;
      this.ScheduleToolstrip.Text = "toolStrip1";
      // 
      // CmdRefreshScheduled
      // 
      this.CmdRefreshScheduled.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.CmdRefreshScheduled.Image = global::RobotWare.Runtime.Server.Manager.Properties.Resources.refresh_32x32;
      this.CmdRefreshScheduled.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.CmdRefreshScheduled.Name = "CmdRefreshScheduled";
      this.CmdRefreshScheduled.Size = new System.Drawing.Size(36, 36);
      this.CmdRefreshScheduled.Text = "Refresh";
      this.CmdRefreshScheduled.ToolTipText = "Refresh scheduled jobs";
      this.CmdRefreshScheduled.Click += new System.EventHandler(this.CmdRefreshScheduled_Click);
      // 
      // CmdRunJobNow
      // 
      this.CmdRunJobNow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.CmdRunJobNow.Enabled = false;
      this.CmdRunJobNow.Image = global::RobotWare.Runtime.Server.Manager.Properties.Resources.media_play_green_32x32;
      this.CmdRunJobNow.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.CmdRunJobNow.Name = "CmdRunJobNow";
      this.CmdRunJobNow.Size = new System.Drawing.Size(36, 36);
      this.CmdRunJobNow.Text = "Run";
      this.CmdRunJobNow.ToolTipText = "Run selected job";
      this.CmdRunJobNow.Click += new System.EventHandler(this.CmdRunJobNow_Click);
      // 
      // CmdPause
      // 
      this.CmdPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.CmdPause.Enabled = false;
      this.CmdPause.Image = global::RobotWare.Runtime.Server.Manager.Properties.Resources.media_pause_32x32;
      this.CmdPause.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.CmdPause.Name = "CmdPause";
      this.CmdPause.Size = new System.Drawing.Size(36, 36);
      this.CmdPause.Text = "Pause";
      this.CmdPause.Click += new System.EventHandler(this.CmdPause_Click);
      // 
      // CmdDelete
      // 
      this.CmdDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.CmdDelete.Enabled = false;
      this.CmdDelete.Image = global::RobotWare.Runtime.Server.Manager.Properties.Resources.delete_32x32;
      this.CmdDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.CmdDelete.Name = "CmdDelete";
      this.CmdDelete.Size = new System.Drawing.Size(36, 36);
      this.CmdDelete.Text = "Delete";
      this.CmdDelete.Click += new System.EventHandler(this.CmdDelete_Click);
      // 
      // CmdAdd
      // 
      this.CmdAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.CmdAdd.Enabled = false;
      this.CmdAdd.Image = global::RobotWare.Runtime.Server.Manager.Properties.Resources.add_32x32;
      this.CmdAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.CmdAdd.Name = "CmdAdd";
      this.CmdAdd.Size = new System.Drawing.Size(36, 36);
      this.CmdAdd.Text = "Add...";
      this.CmdAdd.Click += new System.EventHandler(this.CmdAdd_Click);
      // 
      // CmdEdit
      // 
      this.CmdEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.CmdEdit.Enabled = false;
      this.CmdEdit.Image = global::RobotWare.Runtime.Server.Manager.Properties.Resources.pencil_32x32;
      this.CmdEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.CmdEdit.Name = "CmdEdit";
      this.CmdEdit.Size = new System.Drawing.Size(36, 36);
      this.CmdEdit.Text = "Edit...";
      this.CmdEdit.ToolTipText = "Edit...";
      this.CmdEdit.Click += new System.EventHandler(this.CmdEdit_Click);
      // 
      // MainTab
      // 
      this.MainTab.Controls.Add(this.SchedulesTab);
      this.MainTab.Controls.Add(this.SpecificationTab);
      this.MainTab.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MainTab.Location = new System.Drawing.Point(0, 39);
      this.MainTab.Name = "MainTab";
      this.MainTab.SelectedIndex = 0;
      this.MainTab.Size = new System.Drawing.Size(935, 581);
      this.MainTab.TabIndex = 19;
      this.MainTab.SelectedIndexChanged += new System.EventHandler(this.Tab_SelectedIndexChanged);
      // 
      // SchedulesTab
      // 
      this.SchedulesTab.Controls.Add(splitContainer1);
      this.SchedulesTab.Location = new System.Drawing.Point(4, 25);
      this.SchedulesTab.Name = "SchedulesTab";
      this.SchedulesTab.Padding = new System.Windows.Forms.Padding(3);
      this.SchedulesTab.Size = new System.Drawing.Size(927, 552);
      this.SchedulesTab.TabIndex = 0;
      this.SchedulesTab.Text = "Schedules";
      this.SchedulesTab.UseVisualStyleBackColor = true;
      // 
      // SpecificationTab
      // 
      this.SpecificationTab.Location = new System.Drawing.Point(4, 25);
      this.SpecificationTab.Name = "SpecificationTab";
      this.SpecificationTab.Padding = new System.Windows.Forms.Padding(3);
      this.SpecificationTab.Size = new System.Drawing.Size(927, 552);
      this.SpecificationTab.TabIndex = 1;
      this.SpecificationTab.Text = "Jobs";
      this.SpecificationTab.UseVisualStyleBackColor = true;
      // 
      // RefreshScheduler
      // 
      this.RefreshScheduler.Interval = 5000;
      this.RefreshScheduler.Tick += new System.EventHandler(this.RefreshScheduler_Tick);
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(935, 645);
      this.Controls.Add(this.MainTab);
      this.Controls.Add(statusStrip1);
      this.Controls.Add(this.ScheduleToolstrip);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "Main";
      this.Text = "Form1";
      statusStrip1.ResumeLayout(false);
      statusStrip1.PerformLayout();
      groupBox1.ResumeLayout(false);
      groupBox2.ResumeLayout(false);
      splitContainer2.Panel1.ResumeLayout(false);
      splitContainer2.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(splitContainer2)).EndInit();
      splitContainer2.ResumeLayout(false);
      splitContainer1.Panel1.ResumeLayout(false);
      splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(splitContainer1)).EndInit();
      splitContainer1.ResumeLayout(false);
      this.ScheduleToolstrip.ResumeLayout(false);
      this.ScheduleToolstrip.PerformLayout();
      this.MainTab.ResumeLayout(false);
      this.SchedulesTab.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStripStatusLabel ServerConnectStatus;
    private System.Windows.Forms.ToolStripStatusLabel StripStatusLabel_Job_Groups;
    private System.Windows.Forms.ToolStripStatusLabel RefreshDate;
    private System.Windows.Forms.ListView RunningJobs;
    private System.Windows.Forms.ColumnHeader JobName;
    private System.Windows.Forms.ColumnHeader JobDuration;
    private System.Windows.Forms.Timer RefreshScheduler;
    private System.Windows.Forms.TreeView SchedulerView;
    private System.Windows.Forms.ToolStripButton CmdRefreshScheduled;
    private System.Windows.Forms.Panel pnlDetails;
    private System.Windows.Forms.ToolStripButton CmdRunJobNow;
    private System.Windows.Forms.ToolStripButton CmdPause;
    private System.Windows.Forms.ToolStripButton CmdDelete;
    private System.Windows.Forms.ToolStripButton CmdEdit;
    private System.Windows.Forms.ToolStripButton CmdAdd;
    private System.Windows.Forms.TabControl MainTab;
    private System.Windows.Forms.ToolStrip ScheduleToolstrip;
    private System.Windows.Forms.TabPage SchedulesTab;
    private System.Windows.Forms.TabPage SpecificationTab;
  }
}

