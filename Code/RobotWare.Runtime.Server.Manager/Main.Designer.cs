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
      System.Windows.Forms.ToolStrip toolStrip1;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
      System.Windows.Forms.StatusStrip statusStrip1;
      System.Windows.Forms.GroupBox groupBox1;
      System.Windows.Forms.GroupBox groupBox2;
      System.Windows.Forms.SplitContainer splitContainer2;
      System.Windows.Forms.SplitContainer splitContainer1;
      System.Windows.Forms.TabControl tabControl1;
      System.Windows.Forms.TabPage tabPage1;
      this.CmdRefreshScheduled = new System.Windows.Forms.ToolStripButton();
      this.CmdRunJobNow = new System.Windows.Forms.ToolStripButton();
      this.CmdPause = new System.Windows.Forms.ToolStripButton();
      this.CmdDelete = new System.Windows.Forms.ToolStripButton();
      this.CmdAdd = new System.Windows.Forms.ToolStripButton();
      this.CmdEdit = new System.Windows.Forms.ToolStripButton();
      this.ServerConnectStatus = new System.Windows.Forms.ToolStripStatusLabel();
      this.StripStatusLabel_Job_Groups = new System.Windows.Forms.ToolStripStatusLabel();
      this.RefreshDate = new System.Windows.Forms.ToolStripStatusLabel();
      this.RunningJobs = new System.Windows.Forms.ListView();
      this.JobName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.JobDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.SchedulerView = new System.Windows.Forms.TreeView();
      this.pnlDetails = new System.Windows.Forms.Panel();
      this.SpecificationTab = new System.Windows.Forms.TabPage();
      this.RefreshScheduler = new System.Windows.Forms.Timer(this.components);
      toolStrip1 = new System.Windows.Forms.ToolStrip();
      statusStrip1 = new System.Windows.Forms.StatusStrip();
      groupBox1 = new System.Windows.Forms.GroupBox();
      groupBox2 = new System.Windows.Forms.GroupBox();
      splitContainer2 = new System.Windows.Forms.SplitContainer();
      splitContainer1 = new System.Windows.Forms.SplitContainer();
      tabControl1 = new System.Windows.Forms.TabControl();
      tabPage1 = new System.Windows.Forms.TabPage();
      toolStrip1.SuspendLayout();
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
      tabControl1.SuspendLayout();
      tabPage1.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolStrip1
      // 
      toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmdRefreshScheduled,
            this.CmdRunJobNow,
            this.CmdPause,
            this.CmdDelete,
            this.CmdAdd,
            this.CmdEdit});
      toolStrip1.Location = new System.Drawing.Point(0, 0);
      toolStrip1.Name = "toolStrip1";
      toolStrip1.Size = new System.Drawing.Size(935, 27);
      toolStrip1.TabIndex = 0;
      toolStrip1.Text = "toolStrip1";
      // 
      // CmdRefreshScheduled
      // 
      this.CmdRefreshScheduled.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.CmdRefreshScheduled.Image = ((System.Drawing.Image)(resources.GetObject("CmdRefreshScheduled.Image")));
      this.CmdRefreshScheduled.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.CmdRefreshScheduled.Name = "CmdRefreshScheduled";
      this.CmdRefreshScheduled.Size = new System.Drawing.Size(62, 24);
      this.CmdRefreshScheduled.Text = "Refresh";
      this.CmdRefreshScheduled.ToolTipText = "Refresh scheduled jobs";
      this.CmdRefreshScheduled.Click += new System.EventHandler(this.CmdRefreshScheduled_Click);
      // 
      // CmdRunJobNow
      // 
      this.CmdRunJobNow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.CmdRunJobNow.Enabled = false;
      this.CmdRunJobNow.Image = ((System.Drawing.Image)(resources.GetObject("CmdRunJobNow.Image")));
      this.CmdRunJobNow.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.CmdRunJobNow.Name = "CmdRunJobNow";
      this.CmdRunJobNow.Size = new System.Drawing.Size(38, 24);
      this.CmdRunJobNow.Text = "Run";
      this.CmdRunJobNow.Click += new System.EventHandler(this.CmdRunJobNow_Click);
      // 
      // CmdPause
      // 
      this.CmdPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.CmdPause.Enabled = false;
      this.CmdPause.Image = ((System.Drawing.Image)(resources.GetObject("CmdPause.Image")));
      this.CmdPause.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.CmdPause.Name = "CmdPause";
      this.CmdPause.Size = new System.Drawing.Size(51, 24);
      this.CmdPause.Text = "Pause";
      this.CmdPause.Click += new System.EventHandler(this.CmdPause_Click);
      // 
      // CmdDelete
      // 
      this.CmdDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.CmdDelete.Enabled = false;
      this.CmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("CmdDelete.Image")));
      this.CmdDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.CmdDelete.Name = "CmdDelete";
      this.CmdDelete.Size = new System.Drawing.Size(57, 24);
      this.CmdDelete.Text = "Delete";
      this.CmdDelete.Click += new System.EventHandler(this.CmdDelete_Click);
      // 
      // CmdAdd
      // 
      this.CmdAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.CmdAdd.Enabled = false;
      this.CmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("CmdAdd.Image")));
      this.CmdAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.CmdAdd.Name = "CmdAdd";
      this.CmdAdd.Size = new System.Drawing.Size(50, 24);
      this.CmdAdd.Text = "Add...";
      this.CmdAdd.Click += new System.EventHandler(this.CmdAdd_Click);
      // 
      // CmdEdit
      // 
      this.CmdEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.CmdEdit.Enabled = false;
      this.CmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("CmdEdit.Image")));
      this.CmdEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.CmdEdit.Name = "CmdEdit";
      this.CmdEdit.Size = new System.Drawing.Size(48, 24);
      this.CmdEdit.Text = "Edit...";
      this.CmdEdit.Click += new System.EventHandler(this.CmdEdit_Click);
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
      groupBox1.Size = new System.Drawing.Size(913, 266);
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
      this.RunningJobs.Size = new System.Drawing.Size(905, 243);
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
      this.JobDuration.Text = "Duration";
      // 
      // groupBox2
      // 
      groupBox2.Controls.Add(splitContainer2);
      groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
      groupBox2.Location = new System.Drawing.Point(4, 4);
      groupBox2.Margin = new System.Windows.Forms.Padding(4);
      groupBox2.Name = "groupBox2";
      groupBox2.Padding = new System.Windows.Forms.Padding(4);
      groupBox2.Size = new System.Drawing.Size(913, 271);
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
      splitContainer2.Size = new System.Drawing.Size(905, 248);
      splitContainer2.SplitterDistance = 413;
      splitContainer2.SplitterWidth = 5;
      splitContainer2.TabIndex = 13;
      // 
      // SchedulerView
      // 
      this.SchedulerView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SchedulerView.HideSelection = false;
      this.SchedulerView.Location = new System.Drawing.Point(0, 0);
      this.SchedulerView.Margin = new System.Windows.Forms.Padding(4);
      this.SchedulerView.Name = "SchedulerView";
      this.SchedulerView.Size = new System.Drawing.Size(413, 248);
      this.SchedulerView.TabIndex = 0;
      this.SchedulerView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.SchedulerView_AfterSelect);
      // 
      // pnlDetails
      // 
      this.pnlDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlDetails.Location = new System.Drawing.Point(0, 0);
      this.pnlDetails.Margin = new System.Windows.Forms.Padding(4);
      this.pnlDetails.Name = "pnlDetails";
      this.pnlDetails.Size = new System.Drawing.Size(487, 248);
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
      splitContainer1.Size = new System.Drawing.Size(921, 558);
      splitContainer1.SplitterDistance = 279;
      splitContainer1.SplitterWidth = 5;
      splitContainer1.TabIndex = 18;
      // 
      // tabControl1
      // 
      tabControl1.Controls.Add(tabPage1);
      tabControl1.Controls.Add(this.SpecificationTab);
      tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      tabControl1.Location = new System.Drawing.Point(0, 27);
      tabControl1.Name = "tabControl1";
      tabControl1.SelectedIndex = 0;
      tabControl1.Size = new System.Drawing.Size(935, 593);
      tabControl1.TabIndex = 19;
      // 
      // tabPage1
      // 
      tabPage1.Controls.Add(splitContainer1);
      tabPage1.Location = new System.Drawing.Point(4, 25);
      tabPage1.Name = "tabPage1";
      tabPage1.Padding = new System.Windows.Forms.Padding(3);
      tabPage1.Size = new System.Drawing.Size(927, 564);
      tabPage1.TabIndex = 0;
      tabPage1.Text = "Schedules";
      tabPage1.UseVisualStyleBackColor = true;
      // 
      // SpecificationTab
      // 
      this.SpecificationTab.Location = new System.Drawing.Point(4, 25);
      this.SpecificationTab.Name = "SpecificationTab";
      this.SpecificationTab.Padding = new System.Windows.Forms.Padding(3);
      this.SpecificationTab.Size = new System.Drawing.Size(721, 531);
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
      this.Controls.Add(tabControl1);
      this.Controls.Add(statusStrip1);
      this.Controls.Add(toolStrip1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "Main";
      this.Text = "Form1";
      toolStrip1.ResumeLayout(false);
      toolStrip1.PerformLayout();
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
      tabControl1.ResumeLayout(false);
      tabPage1.ResumeLayout(false);
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
    private System.Windows.Forms.TabPage SpecificationTab;
  }
}

