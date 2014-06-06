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
      System.Windows.Forms.StatusStrip statusStrip1;
      System.Windows.Forms.GroupBox groupBox1;
      System.Windows.Forms.GroupBox groupBox2;
      System.Windows.Forms.SplitContainer splitContainer1;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
      this.ServerConnectStatus = new System.Windows.Forms.ToolStripStatusLabel();
      this.StripStatusLabel_Job_Groups = new System.Windows.Forms.ToolStripStatusLabel();
      this.RefreshDate = new System.Windows.Forms.ToolStripStatusLabel();
      this.RefreshScheduler = new System.Windows.Forms.Timer(this.components);
      this.RunningJobs = new System.Windows.Forms.ListView();
      this.JobName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.JobDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.jobGroupsTreeView = new System.Windows.Forms.TreeView();
      this.CmdRefreshScheduled = new System.Windows.Forms.ToolStripButton();
      toolStrip1 = new System.Windows.Forms.ToolStrip();
      statusStrip1 = new System.Windows.Forms.StatusStrip();
      groupBox1 = new System.Windows.Forms.GroupBox();
      groupBox2 = new System.Windows.Forms.GroupBox();
      splitContainer1 = new System.Windows.Forms.SplitContainer();
      toolStrip1.SuspendLayout();
      statusStrip1.SuspendLayout();
      groupBox1.SuspendLayout();
      groupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(splitContainer1)).BeginInit();
      splitContainer1.Panel1.SuspendLayout();
      splitContainer1.Panel2.SuspendLayout();
      splitContainer1.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolStrip1
      // 
      toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmdRefreshScheduled});
      toolStrip1.Location = new System.Drawing.Point(0, 0);
      toolStrip1.Name = "toolStrip1";
      toolStrip1.Size = new System.Drawing.Size(547, 25);
      toolStrip1.TabIndex = 0;
      toolStrip1.Text = "toolStrip1";
      // 
      // statusStrip1
      // 
      statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ServerConnectStatus,
            this.StripStatusLabel_Job_Groups,
            this.RefreshDate});
      statusStrip1.Location = new System.Drawing.Point(0, 475);
      statusStrip1.Name = "statusStrip1";
      statusStrip1.Size = new System.Drawing.Size(547, 22);
      statusStrip1.TabIndex = 2;
      statusStrip1.Text = "statusStrip1";
      // 
      // ServerConnectStatus
      // 
      this.ServerConnectStatus.Name = "ServerConnectStatus";
      this.ServerConnectStatus.Size = new System.Drawing.Size(86, 17);
      this.ServerConnectStatus.Text = "Not connected";
      // 
      // StripStatusLabel_Job_Groups
      // 
      this.StripStatusLabel_Job_Groups.BackColor = System.Drawing.Color.LightCyan;
      this.StripStatusLabel_Job_Groups.Name = "StripStatusLabel_Job_Groups";
      this.StripStatusLabel_Job_Groups.Size = new System.Drawing.Size(0, 17);
      this.StripStatusLabel_Job_Groups.ToolTipText = "Last Refresh of Running Jobs";
      // 
      // RefreshDate
      // 
      this.RefreshDate.BackColor = System.Drawing.Color.LightCyan;
      this.RefreshDate.Name = "RefreshDate";
      this.RefreshDate.Size = new System.Drawing.Size(0, 17);
      this.RefreshDate.ToolTipText = "Last Refresh Date of Running Jobs";
      // 
      // RefreshScheduler
      // 
      this.RefreshScheduler.Interval = 5000;
      this.RefreshScheduler.Tick += new System.EventHandler(this.RefreshScheduler_Tick);
      // 
      // RunningJobs
      // 
      this.RunningJobs.AllowColumnReorder = true;
      this.RunningJobs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.JobName,
            this.JobDuration});
      this.RunningJobs.Dock = System.Windows.Forms.DockStyle.Fill;
      this.RunningJobs.Location = new System.Drawing.Point(3, 16);
      this.RunningJobs.Name = "RunningJobs";
      this.RunningJobs.Size = new System.Drawing.Size(535, 196);
      this.RunningJobs.Sorting = System.Windows.Forms.SortOrder.Ascending;
      this.RunningJobs.TabIndex = 15;
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
      // groupBox1
      // 
      groupBox1.Controls.Add(this.RunningJobs);
      groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      groupBox1.Location = new System.Drawing.Point(3, 3);
      groupBox1.Name = "groupBox1";
      groupBox1.Size = new System.Drawing.Size(541, 215);
      groupBox1.TabIndex = 16;
      groupBox1.TabStop = false;
      groupBox1.Text = "Running";
      // 
      // groupBox2
      // 
      groupBox2.Controls.Add(this.jobGroupsTreeView);
      groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
      groupBox2.Location = new System.Drawing.Point(3, 3);
      groupBox2.Name = "groupBox2";
      groupBox2.Size = new System.Drawing.Size(541, 219);
      groupBox2.TabIndex = 17;
      groupBox2.TabStop = false;
      groupBox2.Text = "Scheduled";
      // 
      // splitContainer1
      // 
      splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      splitContainer1.Location = new System.Drawing.Point(0, 25);
      splitContainer1.Name = "splitContainer1";
      splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      splitContainer1.Panel1.Controls.Add(groupBox2);
      splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3);
      // 
      // splitContainer1.Panel2
      // 
      splitContainer1.Panel2.Controls.Add(groupBox1);
      splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3);
      splitContainer1.Size = new System.Drawing.Size(547, 450);
      splitContainer1.SplitterDistance = 225;
      splitContainer1.TabIndex = 18;
      // 
      // jobGroupsTreeView
      // 
      this.jobGroupsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.jobGroupsTreeView.HideSelection = false;
      this.jobGroupsTreeView.Location = new System.Drawing.Point(3, 16);
      this.jobGroupsTreeView.Name = "jobGroupsTreeView";
      this.jobGroupsTreeView.Size = new System.Drawing.Size(535, 200);
      this.jobGroupsTreeView.TabIndex = 3;
      // 
      // CmdRefreshScheduled
      // 
      this.CmdRefreshScheduled.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.CmdRefreshScheduled.Image = ((System.Drawing.Image)(resources.GetObject("CmdRefreshScheduled.Image")));
      this.CmdRefreshScheduled.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.CmdRefreshScheduled.Name = "CmdRefreshScheduled";
      this.CmdRefreshScheduled.Size = new System.Drawing.Size(23, 22);
      this.CmdRefreshScheduled.Text = "Refresh";
      this.CmdRefreshScheduled.ToolTipText = "Refresh scheduled jobs";
      this.CmdRefreshScheduled.Click += new System.EventHandler(this.CmdRefreshScheduled_Click);
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(547, 497);
      this.Controls.Add(splitContainer1);
      this.Controls.Add(statusStrip1);
      this.Controls.Add(toolStrip1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Main";
      this.Text = "Form1";
      toolStrip1.ResumeLayout(false);
      toolStrip1.PerformLayout();
      statusStrip1.ResumeLayout(false);
      statusStrip1.PerformLayout();
      groupBox1.ResumeLayout(false);
      groupBox2.ResumeLayout(false);
      splitContainer1.Panel1.ResumeLayout(false);
      splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(splitContainer1)).EndInit();
      splitContainer1.ResumeLayout(false);
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
    private System.Windows.Forms.TreeView jobGroupsTreeView;
    private System.Windows.Forms.ToolStripButton CmdRefreshScheduled;
  }
}

