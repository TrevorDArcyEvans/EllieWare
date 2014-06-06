//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using Common.Logging;
using CrashReporterDotNET;
using EllieWare.Common;
using EllieWare.Interfaces;
using EllieWare.Support;
using Quartz;
using Quartz.Core;
using Quartz.Impl.Matchers;
using RobotWare.Runtime.Server.Manager.Properties;

namespace RobotWare.Runtime.Server.Manager
{
  public sealed partial class Main : Form
  {
    private readonly IRobotWare mRoot = new RobotWareServerWrapper();
    private readonly QuartzSchedulerFacade mScheduler;
    private static readonly ILog Log = LogManager.GetLogger(typeof(Main));

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
          RefreshDate.Enabled = true;
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
      if (jobGroupsTreeView.Nodes.ContainsKey(schedulerNode.Name))
      {
        jobGroupsTreeView.Nodes.RemoveByKey(schedulerNode.Name);
      }
      jobGroupsTreeView.Nodes.Add(schedulerNode);
      var jobGroupsNode = schedulerNode.Nodes.Add("Job Groups");
      var jobGroups = mScheduler.GetScheduler().GetJobGroupNames();
      foreach (string jobGroup in jobGroups)
      {
        var jobGroupNode = jobGroupsNode.Nodes.Add(jobGroup);
        var jobsNode = jobGroupNode.Nodes.Add("Jobs");
        AddJobNodes(jobsNode);
      }

      jobGroupsTreeView.Nodes[0].Expand();
      jobGroupsNode.Expand();

      //loadOrphanJobs(schedulerNode);
      //loadStuckTriggers(schedulerNode);
      //loadCalendars(schedulerNode);
    }

    private void AddJobNodes(TreeNode node)
    {
      var group = node.Parent.Text;
      var groupMatcher = GroupMatcher<JobKey>.GroupContains(group);
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
      //var triggers = mScheduler.GetScheduler().GetTriggersOfJob(new JobKey(jobNode.Text, jobNode.Parent.Parent.Text));
      var triggers = mScheduler.GetScheduler().GetTriggersOfJob(new JobKey(jobNode.Detail.Key.Name, jobNode.Parent.Parent.Text));
      var triggersNode = jobNode.Nodes.Add("Triggers");
      foreach (var trigger in triggers)
      {
        var node = new TriggerNode(trigger);
        triggersNode.Nodes.Add(node);
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
  }
}
