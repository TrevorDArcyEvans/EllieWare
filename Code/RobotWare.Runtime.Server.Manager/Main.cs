//
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
using System.Threading;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using Common.Logging;
using CrashReporterDotNET;
using CronExpressionDescriptor;
using EllieWare.Common;
using EllieWare.Interfaces;
using EllieWare.Manager;
using EllieWare.Support;
using Quartz;
using Quartz.Collection;
using Quartz.Impl.Matchers;
using Quartz.Impl.Triggers;
using Quartz.Job;
using Quartz.Util;
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
        mScheduler = new QuartzSchedulerFacade(Settings.Default.Server, Settings.Default.Port, Settings.Default.Scheduler);
        ServerConnectStatus.Text = string.Format("Connected to {0}", mScheduler.Address);
        LoadScheduledJobs();
        RefreshScheduler.Enabled = true;
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

          LoadRunningJobs();

          RefreshDate.Text = DateTime.Now.ToString("yyyy.MM.dd HH:mm.ss");
        }
        finally
        {
          RefreshScheduler.Start();
        }
      }
    }

    #region Load

    private void LoadRunningJobs()
    {
      RunningJobs.Items.Clear();
      var table = mScheduler.GetRunningJobs();
      foreach (var item in from DataRow row in table.Rows
                           select new ListViewItem(new[] { Convert.ToString(row["JobName"]), string.Format("{0:0.0}", (double)row["Runtime"]) }))
      {
        RunningJobs.Items.Add(item);
      }
    }

    private void LoadScheduledJobs()
    {
      var expNodePaths = SchedulerView.Nodes.GetExpansionState();
      var selNodePath = SchedulerView.SelectedNode != null ? SchedulerView.SelectedNode.GetNamesFullPath() : null;
      try
      {
        var schedulerNode = new SchedulerNode(mScheduler);
        if (SchedulerView.Nodes.ContainsKey(schedulerNode.Name))
        {
          SchedulerView.Nodes.RemoveByKey(schedulerNode.Name);
        }
        SchedulerView.Nodes.Add(schedulerNode);
        var jobGroupsIdx = schedulerNode.Nodes.Add(new JobGroupsNode("Job Groups"));
        var jobGroupsNode = schedulerNode.Nodes[jobGroupsIdx];
        var jobGroups = mScheduler.GetScheduler().GetJobGroupNames();
        foreach (var jobGroup in jobGroups)
        {
          var jobGroupNode = new JobGroupNode(jobGroup);
          jobGroupsNode.Nodes.Add(jobGroupNode);
          LoadJobNodes(jobGroupNode);
        }

        LoadOrphanJobs(schedulerNode);
        LoadCalendars(schedulerNode);
      }
      finally
      {
        SchedulerView.Nodes.SetExpansionState(expNodePaths);
        SchedulerView.SelectedNode = SchedulerView.Nodes.FindByNamesFullPath(selNodePath);
        SchedulerView_AfterSelect(this, new TreeViewEventArgs(SchedulerView.SelectedNode));
      }
    }

    private void LoadJobNodes(JobGroupNode node)
    {
      var group = node.Name;
      var groupMatcher = GroupMatcher<JobKey>.GroupContains(group);
      var sched = mScheduler.GetScheduler();
      var jobKeys = sched.GetJobKeys(groupMatcher);
      foreach (var jobKey in jobKeys)
      {
        try
        {
          var detail = sched.GetJobDetail(jobKey);
          var jobNode = new JobNode(detail);
          node.Nodes.Add(jobNode);
          LoadTriggerNodes(jobNode);
        }
        catch (Exception ex)
        {
          node.Nodes.Add(string.Format("Unknown Job Type ({0})", jobKey.Name));
          //TODO: Do something useful with this exception. Most likely cause is the client does not have a copy of a given dll and can't load the type.
          Log.Error("Error loading jobs.", ex);
        }
      }
    }

    private void LoadTriggerNodes(JobNode jobNode)
    {
      var sched = mScheduler.GetScheduler();
      var triggers = sched.GetTriggersOfJob(new JobKey(jobNode.Detail.Key.Name, jobNode.Parent.Text));
      foreach (var trigger in triggers)
      {
        var node = new TriggerNode(trigger);
        jobNode.Nodes.Add(node);
        LoadCalendarNode(node);
      }
    }

    private void LoadOrphanJobs(SchedulerNode schedulerNode)
    {
      var orphanJobsIdx = schedulerNode.Nodes.Add(new OrphanJobsNode("Orphan Jobs"));
      var orphanJobs = (OrphanJobsNode)schedulerNode.Nodes[orphanJobsIdx];
      var sched = schedulerNode.Scheduler.GetScheduler();
      var groupNames = sched.GetJobGroupNames();
      foreach (var jobGroupName in groupNames)
      {
        var matcher = GroupMatcher<JobKey>.GroupEquals(jobGroupName);
        var jobKeys = schedulerNode.Scheduler.GetScheduler().GetJobKeys(matcher);
        foreach (var jobKey in jobKeys)
        {
          try
          {
            var triggers = schedulerNode.Scheduler.GetScheduler().GetTriggersOfJob(jobKey);
            if (triggers.Count == 0)
            {
              var jobDetail = sched.GetJobDetail(jobKey);
              orphanJobs.Nodes.Add(new JobNode(jobDetail));
            }
          }
          catch (Exception ex)
          {
            Log.Error("Error loading orphan jobs.", ex);
            schedulerNode.Nodes.Add(string.Format("Unable to add job {0})", jobKey.Name));
          }
        }
      }
    }

    private void LoadCalendars(SchedulerNode schedulerNode)
    {
      var calendarsIdx = schedulerNode.Nodes.Add(new CalendarsNode("Calendars"));
      var calendarsNode = (CalendarsNode)schedulerNode.Nodes[calendarsIdx];
      var sched = schedulerNode.Scheduler.GetScheduler();
      foreach (var calendarName in sched.GetCalendarNames())
      {
        calendarsNode.Nodes.Add(new CalendarNode(calendarName));
      }
    }

    private void LoadCalendarNode(TriggerNode node)
    {
      if (node.Trigger.CalendarName != null)
      {
        node.Nodes.Add(new CalendarNode(node.Trigger.CalendarName));
      }
      else
      {
        node.Nodes.Add("No calendar found");
      }
    }

    #endregion

    private void CmdRefreshScheduled_Click(object sender, EventArgs e)
    {
      using (new AutoCursor())
      {
        LoadScheduledJobs();
      }
    }

    private void SetPauseButtonText(TriggerNode triggerNode)
    {
      CmdPause.Text = mScheduler.GetScheduler().GetTriggerState(triggerNode.Trigger.Key) == TriggerState.Paused ? @"Resume" : @"Pause";
    }

    private void SchedulerView_AfterSelect(object sender, TreeViewEventArgs e)
    {
      pnlDetails.Controls.Clear();

      UpdateButtons(e);
      UpdateToolTips(e);

      var jobNode = e.Node as JobNode;
      if (jobNode != null)
      {
        UpdateDetails(jobNode);
      }

      var triggerNode = e.Node as TriggerNode;
      if (triggerNode != null)
      {
        SetPauseButtonText(triggerNode);
        var trigger = triggerNode.Trigger as ICronTrigger;
        if (trigger != null)
        {
          UpdateDetails(trigger);
        }

        var simpleTrigger = triggerNode.Trigger as ISimpleTrigger;
        if (simpleTrigger != null)
        {
          UpdateDetails(simpleTrigger);
        }
      }

      var calendarNode = e.Node as CalendarNode;
      if (calendarNode != null)
      {
        UpdateDetails(calendarNode);
      }
    }

    #region Update

    private void UpdateDetails(JobNode jobNode)
    {
      var ctrl = new NativeJobDetailDisplay(jobNode.Detail)
      {
        Dock = DockStyle.Fill
      };
      pnlDetails.Controls.Clear();
      pnlDetails.Controls.Add(ctrl);
    }

    private void UpdateDetails(ICronTrigger trigger)
    {
      var ctrl = new CronTriggerDisplay(trigger)
      {
        Dock = DockStyle.Fill
      };
      pnlDetails.Controls.Clear();
      pnlDetails.Controls.Add(ctrl);
    }

    private void UpdateDetails(ISimpleTrigger simpleTrigger)
    {
      var ctrl = new SimpleTriggerDisplay(simpleTrigger)
      {
        Dock = DockStyle.Fill
      };
      pnlDetails.Controls.Clear();
      pnlDetails.Controls.Add(ctrl);
    }

    private void UpdateDetails(CalendarNode calendarNode)
    {
      var sched = mScheduler.GetScheduler();
      var cal = sched.GetCalendar(calendarNode.Name);
      var ctrl = new TextBox
      {
        Dock = DockStyle.Fill,
        ReadOnly = true,
        Text = cal.Description
      };
      pnlDetails.Controls.Clear();
      pnlDetails.Controls.Add(ctrl);
    }

    private void UpdateButtons(TreeViewEventArgs e)
    {
      CmdDelete.Enabled = e.Node is TriggerNode ||
                          e.Node is JobNode ||
                          e.Node is CalendarNode;
      CmdAdd.Enabled = e.Node is SchedulerNode ||
                       e.Node is JobGroupsNode ||
                       e.Node is JobGroupNode ||
                       e.Node is JobNode ||
                       e.Node is TriggerNode ||
                       e.Node is CalendarsNode;
      CmdEdit.Enabled = e.Node is TriggerNode;
      CmdRunJobNow.Enabled = e.Node is JobNode;
      CmdPause.Enabled = e.Node is TriggerNode;

      var sched = mScheduler.GetScheduler();

      // check if there are any calendars
      if (e.Node is TriggerNode)
      {
        CmdAdd.Enabled = sched.GetCalendarNames().Any();
      }

      // trying to delete calendar from top level calendars node
      if (e.Node is CalendarNode && e.Node.Parent is CalendarsNode)
      {
        // cannot delete a calendar if it is referenced by a trigger
        var triggerMatcher = GroupMatcher<TriggerKey>.GroupContains("");
        var calNode = (CalendarNode)e.Node;
        var refTriggers = sched.GetTriggerKeys(triggerMatcher).Where(x => sched.GetTrigger(x).CalendarName == calNode.Name);

        CmdDelete.Enabled = !refTriggers.Any();
      }
    }

    private void UpdateToolTips(TreeViewEventArgs e)
    {
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
      if (e.Node is CalendarNode)
      {
        CmdDelete.ToolTipText = @"Delete calendar";
      }

      if (e.Node is SchedulerNode || e.Node is JobGroupsNode)
      {
        CmdAdd.ToolTipText = @"Add job group";
      }
      if (e.Node is JobGroupNode)
      {
        CmdAdd.ToolTipText = @"Add job";
      }
      if (e.Node is JobNode)
      {
        CmdAdd.ToolTipText = @"Add trigger";
      }
      if (e.Node is TriggerNode)
      {
        CmdAdd.ToolTipText = @"Add calendar";
      }
      if (e.Node is CalendarsNode)
      {
        CmdAdd.ToolTipText = @"Add calendar";
      }

      if (e.Node is CalendarNode)
      {
        CmdEdit.ToolTipText = @"Edit calendar";
      }
      if (e.Node is TriggerNode)
      {
        CmdEdit.ToolTipText = @"Edit trigger";
      }
    }

    #endregion

    private void CmdRunJobNow_Click(object sender, EventArgs e)
    {
      var node = (JobNode)SchedulerView.SelectedNode;
      var sched = mScheduler.GetScheduler();
      sched.TriggerJob(node.Detail.Key);
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
        DeleteJob((JobNode)selectedNode, LoadScheduledJobs);
      }

      if (selectedNode is TriggerNode)
      {
        DeleteTrigger((TriggerNode)selectedNode, LoadScheduledJobs);
      }

      // deleting calendar from Calendars node
      if (selectedNode is CalendarNode && !(selectedNode.Parent is TriggerNode))
      {
        DeleteCalendar((CalendarNode)selectedNode, LoadScheduledJobs);
      }

      // deleting calendar from trigger node
      if (selectedNode is CalendarNode && selectedNode.Parent is TriggerNode)
      {
        DeleteCalendar((TriggerNode)selectedNode.Parent, LoadScheduledJobs);
      }
    }

    private void DeleteCalendar(CalendarNode selectedNode, Action updateAction)
    {
      var sched = mScheduler.GetScheduler();
      var bRet = sched.DeleteCalendar(selectedNode.Name);
      Debug.Assert(bRet);
      updateAction();
    }

    private void DeleteCalendar(TriggerNode selectedNode, Action updateAction)
    {
      // make a copy of the original
      var copyTrigger = (AbstractTrigger)selectedNode.Trigger.DeepClone();

      // delete the original
      var sched = mScheduler.GetScheduler();
      var bRet = sched.UnscheduleJob(selectedNode.Trigger.Key);
      Debug.Assert(bRet);

      // remove calendar
      copyTrigger.CalendarName = null;

      // add the copy, less the calendar
      sched.ScheduleJob(copyTrigger);
      updateAction();
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

    #endregion

    #region Edit

    private void CmdEdit_Click(object sender, EventArgs e)
    {
      var selectedNode = SchedulerView.SelectedNode;
      if (selectedNode is TriggerNode)
      {
        EditTrigger((TriggerNode)selectedNode, LoadScheduledJobs);
      }
    }

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

      // check if changed trigger conflicts with any calendar
      if (selectedNode.Trigger.CalendarName != null)
      {
        var sched = mScheduler.GetScheduler();
        var cronStr = frm.Expression;
        var selCal = sched.GetCalendar(selectedNode.Trigger.CalendarName);
        var tempTrigger = (AbstractTrigger)TriggerBuilder.Create().
                                              WithCronSchedule(cronStr).
                                              Build();
        var nextFire = tempTrigger.ComputeFirstFireTimeUtc(selCal);
        if (nextFire == null)
        {
          var msg = string.Format("Calendar '{0}' will not let trigger '{1}' fire.", selectedNode.Trigger.CalendarName, selectedNode.Trigger.Description);
          MessageBox.Show(msg, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
      }

      // delete and re-add trigger so it survives a refresh
      var calName = selectedNode.Trigger.CalendarName;
      DeleteTrigger(selectedNode, NullUpdateAction);
      var jobNode = (JobNode)selectedNode.Parent;
      AddTrigger(jobNode, frm, calName, updateAction);
    }

    #endregion

    #region Add

    private void CmdAdd_Click(object sender, EventArgs e)
    {
      var selectedNode = SchedulerView.SelectedNode;
      if (selectedNode is JobGroupNode)
      {
        var jobGroupNode = (JobGroupNode)selectedNode;
        AddJob(jobGroupNode, LoadScheduledJobs);
      }

      if (selectedNode is JobNode)
      {
        var jobNode = (JobNode)selectedNode;
        AddTrigger(jobNode, LoadScheduledJobs);
      }

      if (selectedNode is SchedulerNode || selectedNode is JobGroupsNode)
      {
        var schedNode = selectedNode is SchedulerNode ? (SchedulerNode)selectedNode : (SchedulerNode)selectedNode.Parent;
        AddJobGroup(schedNode, LoadScheduledJobs);
      }

      if (selectedNode is CalendarsNode)
      {
        var calNode = (CalendarsNode)selectedNode;
        AddCalendar(calNode, LoadScheduledJobs);
      }

      if (selectedNode is TriggerNode)
      {
        var triggerNode = (TriggerNode)selectedNode;
        AddCalendar(triggerNode, LoadScheduledJobs);
      }
    }

    private void AddCalendar(TriggerNode triggerNode, Action updateAction)
    {
      var sched = mScheduler.GetScheduler();
      var allCals = sched.GetCalendarNames();
      var frm = new CalendarSelector(allCals);
      if (frm.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      // check if calendar will allow trigger to fire
      var absTrigg = triggerNode.Trigger as AbstractTrigger;
      if (absTrigg != null)
      {
        var selCal = sched.GetCalendar(frm.SelectedCalendar);
        var nextFire = absTrigg.ComputeFirstFireTimeUtc(selCal);
        if (nextFire == null)
        {
          var msg = string.Format("Calendar '{0}' will not let trigger '{1}' fire.", frm.SelectedCalendar, absTrigg.Description);
          MessageBox.Show(msg, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
      }

      // create new trigger with calendar
      var trigger = triggerNode.Trigger;
      var newTrigger = trigger.GetTriggerBuilder().
                          ModifiedByCalendar(frm.SelectedCalendar).
                          Build();

      // unschedule existing job
      var bRet = sched.UnscheduleJob(trigger.Key);
      Debug.Assert(bRet);

      // reschedule it with new trigger
      // NOTE:  for some reason we have to use this API or it hangs - go figure
      var jobNode = (JobNode)triggerNode.Parent;
      sched.ScheduleJob(jobNode.Detail, new HashSet<ITrigger> { newTrigger }, true);

      updateAction();
    }

    private void AddCalendar(CalendarsNode calNode, Action updateAction)
    {
      var sched = mScheduler.GetScheduler();
      var allCals = sched.GetCalendarNames();
      var frm = new AddCalendar(allCals);
      if (frm.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      sched.AddCalendar(frm.Calendar.Description, frm.Calendar, true, true);
      updateAction();
    }

    private void AddTrigger(JobNode selectedNode, Action updateAction)
    {
      var frm = new CronSelector();
      if (frm.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      // add cron trigger
      AddTrigger(selectedNode, frm, null, NullUpdateAction);
      updateAction();
    }

    private void AddTrigger(JobNode selectedNode, CronSelector frm, string calendarName, Action updateAction)
    {
      var sched = mScheduler.GetScheduler();
      var cronStr = frm.Expression;
      var cronDescrip = ExpressionDescriptor.GetDescription(cronStr);
      var newCronXml = frm.GetXml();
      var trigger = TriggerBuilder.Create().
                      WithCronSchedule(cronStr).
                      WithDescription(cronDescrip).
                      ModifiedByCalendar(calendarName).
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
                  WithDescription("TODO extract description from spec").  // TODO extract description from spec
                  WithIdentity(jobName, selectedNode.Name).
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

    private void Tab_SelectedIndexChanged(object sender, EventArgs e)
    {
      ScheduleToolstrip.Enabled = MainTab.SelectedIndex == 0;
      SchedulerView_AfterSelect(sender, new TreeViewEventArgs(SchedulerView.SelectedNode));
    }

    private void CmdAbout_Click(object sender, EventArgs e)
    {
      var frm = new AboutBox(mRoot.ApplicationName);
      frm.ShowDialog();
    }
  }
}
