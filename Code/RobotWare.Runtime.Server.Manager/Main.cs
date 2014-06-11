﻿//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using Common.Logging;
using CrashReporterDotNET;
using CronExpressionDescriptor;
using EllieWare.Interfaces;
using EllieWare.Manager;
using EllieWare.Support;
using Quartz;
using Quartz.Impl.Matchers;
using Quartz.Job;
using RobotWare.Runtime.Server.Manager.Properties;

namespace RobotWare.Runtime.Server.Manager
{
  public sealed partial class Main : Form
  {
    private readonly IRobotWare mRoot = new RobotWareServerWrapper();
    private readonly QuartzSchedulerFacade mScheduler;
    private static readonly ILog Log = LogManager.GetLogger(typeof(Main));
    private const string TriggerXml = "TriggerXml";

    public Main()
    {
      InitializeComponent();

      // http://crashreporterdotnet.codeplex.com/documentation
      Application.ThreadException += ApplicationThreadException;

      // http://autoupdaterdotnet.codeplex.com/documentation
      const string EllieWare = @"http://www.EllieWare.com";
      var appCast = mRoot.ApplicationName.Replace(' ', '_') + ".xml";
      var appCastUrl = EllieWare + @"/" + appCast;
      AutoUpdater.Start(appCastUrl, mRoot.ApplicationName, mRoot.Version);

      using (new AutoCursor())
      {
        try
        {
          mScheduler = new QuartzSchedulerFacade(Settings.Default.Server, Settings.Default.Port, Settings.Default.Scheduler);
          ServerConnectStatus.Text = string.Format("Connected to {0}", mScheduler.Address);
          UpdateScheduledJobs();
          RefreshScheduler.Enabled = true;
        }
        catch (SocketException)
        {
          var msg = string.Format("Unable to connect to scheduler {0} on {1}:{2}", Settings.Default.Scheduler, Settings.Default.Server, Settings.Default.Port);
          MessageBox.Show(msg, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    public Main(IRobotWare root) :
      this()
    {
      mRoot = root;
      Text = mRoot.ApplicationName;

      var specifications = new ManagerCtl(mRoot)
      {
        Dock = DockStyle.Fill
      };
      SpecificationTab.Controls.Clear();
      SpecificationTab.Controls.Add(specifications);
    }

    private void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
    {
      var reportCrash = new ReportCrash
                              {
                                ToEmail = "support@EllieWare.com"
                              };

      reportCrash.Send(e.Exception);
    }

    private void RefreshScheduler_Tick(object sender, EventArgs e)
    {
      using (new AutoCursor())
      {
        try
        {
          RefreshScheduler.Stop();

          UpdateRunningJobs();

          RefreshDate.Text = DateTime.Now.ToString("yyyy.MM.dd HH:mm.ss");
        }
        finally
        {
          RefreshScheduler.Start();
        }
      }
    }

    private void UpdateRunningJobs()
    {
      RunningJobs.Items.Clear();
      var table = mScheduler.GetRunningJobs();
      foreach (var item in from DataRow row in table.Rows
                           select new ListViewItem(new[] { Convert.ToString(row["JobName"]), Convert.ToString(row["Runtime"]) }))
      {
        RunningJobs.Items.Add(item);
      }
    }

    private void UpdateScheduledJobs()
    {
      var schedulerNode = new SchedulerNode(mScheduler);
      if (SchedulerView.Nodes.ContainsKey(schedulerNode.Name))
      {
        SchedulerView.Nodes.RemoveByKey(schedulerNode.Name);
      }
      SchedulerView.Nodes.Add(schedulerNode);
      var jobGroups = mScheduler.GetScheduler().GetJobGroupNames();
      foreach (var jobGroup in jobGroups)
      {
        var jobGroupNode = new JobGroupNode(jobGroup);
        schedulerNode.Nodes.Add(jobGroupNode);
        AddJobNodes(jobGroupNode);
      }

      SchedulerView.Nodes[0].Expand();
      schedulerNode.Expand();
    }

    private void AddJobNodes(JobGroupNode node)
    {
      var groupMatcher = GroupMatcher<JobKey>.GroupContains(node.Group);
      var jobKeys = mScheduler.GetScheduler().GetJobKeys(groupMatcher);
      foreach (var jobKey in jobKeys)
      {
        try
        {
          var detail = mScheduler.GetScheduler().GetJobDetail(jobKey);
          var jobNode = new JobNode(detail);
          node.Nodes.Add(jobNode);
          AddTriggerNodes(jobNode);
        }
        catch (Exception ex)
        {
          node.Nodes.Add(string.Format("Unknown Job Type ({0})", jobKey.Name));
          //TODO: Do something useful with this exception. Most likely cause is the client does not have a copy of a given dll and can't load the type.
          Log.Error("Error loading jobs.", ex);
        }
      }
    }

    private void AddTriggerNodes(JobNode jobNode)
    {
      var triggers = mScheduler.GetScheduler().GetTriggersOfJob(new JobKey(jobNode.Detail.Key.Name, jobNode.Parent.Name));
      foreach (var trigger in triggers)
      {
        var node = new TriggerNode(trigger);
        jobNode.Nodes.Add(node);
        AddCalendarNode(node);
      }
    }

    private void AddCalendarNode(TriggerNode node)
    {
      if (node.Trigger.CalendarName != null)
      {
        //TODO: Convert this to a CalendarNode and implement CalendarDisplay controls
        node.Nodes.Add(node.Trigger.CalendarName);
      }
      else
      {
        node.Nodes.Add("No calendar found");
      }
    }

    private void CmdRefreshScheduled_Click(object sender, EventArgs e)
    {
      using (new AutoCursor())
      {
        UpdateScheduledJobs();
      }
    }

    private void JobDetailsToggle(bool isVisible)
    {
      if (isVisible == false)
      {
        pnlDetails.Controls.Clear();
      }
    }

    private void SetPauseButtonText(TriggerNode triggerNode)
    {
      CmdPause.Text = mScheduler.GetScheduler().GetTriggerState(triggerNode.Trigger.Key) == TriggerState.Paused ? @"Resume" : @"Pause";
    }

    private void SchedulerView_AfterSelect(object sender, TreeViewEventArgs e)
    {
      JobDetailsToggle(false);

      CmdDelete.Enabled = e.Node is TriggerNode || e.Node is JobNode;
      CmdAdd.Enabled = e.Node is JobGroupNode || e.Node is JobNode || e.Node is SchedulerNode;

      #region ToolTips

      // reset tooltips based on what is selected
      CmdDelete.ToolTipText = CmdAdd.ToolTipText = string.Empty;

      if (e.Node is TriggerNode)
      {
        CmdDelete.ToolTipText = @"Delete trigger";
      }
      if (e.Node is JobNode)
      {
        CmdDelete.ToolTipText = @"Delete job";
      }

      if (e.Node is JobGroupNode)
      {
        CmdAdd.ToolTipText = @"Add job";
      }
      if (e.Node is JobNode)
      {
        CmdAdd.ToolTipText = @"Add trigger";
      }
      if (e.Node is SchedulerNode)
      {
        CmdAdd.ToolTipText = @"Add job group";
      }

      #endregion

      var jobNode = e.Node as JobNode;
      if (jobNode != null)
      {
        CmdRunJobNow.Enabled = true;
        var ctrl = new NativeJobDetailDisplay(jobNode.Detail)
                    {
                      Dock = DockStyle.Fill
                    };
        pnlDetails.Controls.Add(ctrl);
        JobDetailsToggle(true);
      }
      else
      {
        CmdRunJobNow.Enabled = false;
      }

      var triggerNode = e.Node as TriggerNode;
      if (triggerNode != null)
      {
        CmdPause.Enabled = true;
        SetPauseButtonText(triggerNode);
        var trigger = triggerNode.Trigger as ICronTrigger;
        if (trigger != null)
        {
          var ctrl = new CronTriggerDisplay(trigger)
                            {
                              Dock = DockStyle.Fill
                            };
          pnlDetails.Controls.Add(ctrl);
          JobDetailsToggle(true);
        }

        var simpleTrigger = triggerNode.Trigger as ISimpleTrigger;
        if (simpleTrigger != null)
        {
          var ctrl = new SimpleTriggerDisplay(simpleTrigger)
                          {
                            Dock = DockStyle.Fill
                          };
          pnlDetails.Controls.Add(ctrl);
          JobDetailsToggle(true);
        }
        CmdEdit.Enabled = true;
      }
      else
      {
        CmdEdit.Enabled = false;
        CmdPause.Enabled = false;
      }
    }

    private void CmdRunJobNow_Click(object sender, EventArgs e)
    {
      var node = (JobNode)SchedulerView.SelectedNode;
      mScheduler.GetScheduler().TriggerJob(node.Detail.Key);
    }

    private void CmdPause_Click(object sender, EventArgs e)
    {
      var node = (TriggerNode)SchedulerView.SelectedNode;
      var sched = mScheduler.GetScheduler();
      if (sched.GetTriggerState(node.Trigger.Key) == TriggerState.Paused)
      {
        sched.ResumeTrigger(node.Trigger.Key);
      }
      else
      {
        sched.PauseTrigger(node.Trigger.Key);
      }
      SetPauseButtonText(node);
    }

    private void NullUpdateAction()
    {
    }

    #region Delete

    private void CmdDelete_Click(object sender, EventArgs e)
    {
      var selectedNode = SchedulerView.SelectedNode;
      if (selectedNode is JobNode)
      {
        DeleteJob((JobNode)selectedNode, UpdateScheduledJobs);
      }

      if (selectedNode is TriggerNode)
      {
        DeleteTrigger((TriggerNode)selectedNode, UpdateScheduledJobs);
      }
    }

    private void DeleteTrigger(TriggerNode selectedNode, Action updateAction)
    {
      var sched = mScheduler.GetScheduler();
      var bRet = sched.UnscheduleJob(selectedNode.Trigger.Key);
      Debug.Assert(bRet);
      updateAction();
    }

    private void DeleteJob(JobNode selectedNode, Action updateAction)
    {
      var sched = mScheduler.GetScheduler();
      var bRet = sched.DeleteJob(selectedNode.Detail.Key);
      Debug.Assert(bRet);
      updateAction();
    }

    private void CmdEdit_Click(object sender, EventArgs e)
    {
      var selectedNode = SchedulerView.SelectedNode;
      if (selectedNode is TriggerNode)
      {
        EditTrigger((TriggerNode)selectedNode, UpdateScheduledJobs);
      }
    }

    #endregion

    #region Edit

    private void EditTrigger(TriggerNode selectedNode, Action updateAction)
    {
      var frm = new CronSelector();
      var trigger = selectedNode.Trigger;
      var jobData = trigger.JobDataMap;
      if (jobData.ContainsKey(TriggerXml))
      {
        var oldCron = (string)jobData[TriggerXml];
        frm.SetXml(oldCron);
      }

      if (frm.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      // delete and re-add trigger so it survives a refresh
      DeleteTrigger(selectedNode, NullUpdateAction);
      var jobNode = (JobNode)selectedNode.Parent;
      AddTrigger(jobNode, frm, updateAction);
    }

    #endregion

    #region Add

    private void CmdAdd_Click(object sender, EventArgs e)
    {
      var selectedNode = SchedulerView.SelectedNode;
      if (selectedNode is JobGroupNode)
      {
        AddJob((JobGroupNode)selectedNode, UpdateScheduledJobs);
      }

      if (selectedNode is JobNode)
      {
        AddTrigger((JobNode)selectedNode, UpdateScheduledJobs);
      }

      if (selectedNode is SchedulerNode)
      {
        AddJobGroup((SchedulerNode)selectedNode, UpdateScheduledJobs);
      }
    }

    private void AddTrigger(JobNode selectedNode, Action updateAction)
    {
      var frm = new CronSelector();
      if (frm.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      // add cron trigger
      AddTrigger(selectedNode, frm, NullUpdateAction);
      updateAction();
    }

    private void AddTrigger(JobNode selectedNode, CronSelector frm, Action updateAction)
    {
      var sched = mScheduler.GetScheduler();
      var cronStr = frm.Expression;
      var cronDescrip = ExpressionDescriptor.GetDescription(cronStr);
      var newCronXml = frm.GetXml();
      var trigger = TriggerBuilder.Create().
                      WithCronSchedule(cronStr).
                      WithDescription(cronDescrip).
                      UsingJobData(TriggerXml, newCronXml).
                      ForJob(selectedNode.Detail).
                      Build();
      sched.ScheduleJob(trigger);
      updateAction();
    }

    private void AddJob(JobGroupNode selectedNode, Action updateAction)
    {
      var sched = mScheduler.GetScheduler();
      var frm = new AddJob(mRoot);
      if (frm.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      // add macro
      var selSpecPath = frm.SelectedSpecificationPath;
      var jobData = new JobDataMap
                          {
                            {Host.MacroFilePathKey, selSpecPath}
                          };
      var jobName = Path.GetFileNameWithoutExtension(selSpecPath);
      var job = JobBuilder.Create<Host>().
                  WithDescription("TODO extract description from spec").
                  WithIdentity(jobName, selectedNode.Group).
                  SetJobData(jobData).
                  StoreDurably().
                  Build();
      sched.AddJob(job, true);
      updateAction();
    }

    private void AddJobGroup(SchedulerNode schedulerNode, Action updateAction)
    {
      var sched = mScheduler.GetScheduler();
      var existJobGroups = sched.GetJobGroupNames();
      var frm = new AddJobGroup(existJobGroups);
      if (frm.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      var job = JobBuilder.Create<NoOpJob>().
                  WithDescription(string.Format("Empty job to ensure that {0} is created", frm.JobGroupName)).
                  WithIdentity("NoOp job", frm.JobGroupName).
                  StoreDurably().
                  Build();
      sched.AddJob(job, true);
      updateAction();
    }

    #endregion
  }
}
