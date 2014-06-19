//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using Quartz.Impl.Triggers;

namespace RobotWare.Runtime.Server.Manager
{
  public class QuartzSchedulerFacade
  {
    private readonly IScheduler mScheduler;

    public string Address { get; private set; }

    public QuartzSchedulerFacade(string server, int port, string scheduler)
    {
      Address = string.Format("tcp://{0}:{1}/{2}", server, port, scheduler);
      var schedulerFactory = new StdSchedulerFactory(GetProperties(Address));

      try
      {
        mScheduler = schedulerFactory.GetScheduler();
      }
      catch (SchedulerException)
      {
        MessageBox.Show(@"Unable to connect to the specified server", @"Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private NameValueCollection GetProperties(string address)
    {
      var properties = new NameValueCollection();
      properties["quartz.scheduler.instanceName"] = "RemoteClient";
      properties["quartz.scheduler.proxy"] = "true";
      properties["quartz.threadPool.threadCount"] = "0";
      properties["quartz.scheduler.proxy.address"] = address;
      return properties;
    }

    public IScheduler GetScheduler()
    {
      return mScheduler;
    }

    public DataTable GetJobs()
    {
      var table = new DataTable();
      table.Columns.Add("GroupName");
      table.Columns.Add("JobName");
      table.Columns.Add("JobDescription");
      table.Columns.Add("TriggerName");
      table.Columns.Add("TriggerGroupName");
      table.Columns.Add("TriggerType");
      table.Columns.Add("TriggerState");
      table.Columns.Add("NextFireTime");
      table.Columns.Add("PreviousFireTime");
      var jobGroups = GetScheduler().GetJobGroupNames();
      foreach (var group in jobGroups)
      {
        var groupMatcher = GroupMatcher<JobKey>.GroupContains(group);
        var jobKeys = GetScheduler().GetJobKeys(groupMatcher);
        foreach (var jobKey in jobKeys)
        {
          var detail = GetScheduler().GetJobDetail(jobKey);
          var triggers = GetScheduler().GetTriggersOfJob(jobKey);
          foreach (var trigger in triggers)
          {
            var row = table.NewRow();
            row["GroupName"] = group;
            row["JobName"] = jobKey.Name;
            row["JobDescription"] = detail.Description;
            row["TriggerName"] = trigger.Key.Name;
            row["TriggerGroupName"] = trigger.Key.Group;
            row["TriggerType"] = trigger.GetType().Name;
            row["TriggerState"] = GetScheduler().GetTriggerState(trigger.Key);
            var nextFireTime = trigger.GetNextFireTimeUtc();
            if (nextFireTime.HasValue)
            {
              row["NextFireTime"] = TimeZone.CurrentTimeZone.ToLocalTime(nextFireTime.Value.DateTime);
            }

            var previousFireTime = trigger.GetPreviousFireTimeUtc();
            if (previousFireTime.HasValue)
            {
              row["PreviousFireTime"] = TimeZone.CurrentTimeZone.ToLocalTime(previousFireTime.Value.DateTime);
            }

            table.Rows.Add(row);
          }
        }
      }
      return table;
    }

    public void ScheduleOneTimeJob(Type jobType, JobDataMap dataMap, int clientID)
    {
      var name = string.Format("{0}-{1}", jobType.Name, clientID);
      var group = clientID.ToString(CultureInfo.InvariantCulture);
      var jobDetail = JobBuilder.
                        Create().
                        OfType(jobType).
                        WithIdentity(name, group).
                        WithDescription("One time job").
                        UsingJobData(dataMap).
                        Build();
      var trigger = TriggerBuilder.
                      Create().
                      ForJob(jobDetail).
                      WithIdentity(name, group).
                      WithSchedule(SimpleScheduleBuilder.Create().WithRepeatCount(0).WithInterval(TimeSpan.Zero)).
                      StartNow().
                      Build();
      GetScheduler().ScheduleJob(jobDetail, trigger);
    }

    public DataTable GetRunningJobs()
    {
      var table = new DataTable();
      table.Columns.Add("JobName", typeof(string));
      table.Columns.Add("RunTime", typeof(double));
      try
      {
        var contexts = GetScheduler().GetCurrentlyExecutingJobs();
        foreach (var context in contexts)
        {
          var row = table.NewRow();
          row["JobName"] = context.JobDetail.Key.Name;
          Debug.Assert(context.FireTimeUtc != null);
          row["RunTime"] = (DateTime.Now.ToUniversalTime() - ((DateTimeOffset)context.FireTimeUtc).DateTime).TotalSeconds;
          table.Rows.Add(row);
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return table;
    }

    public void BackupToFile(FileInfo file)
    {
      var scheduler = GetScheduler();
      var jobGroupNames = scheduler.GetJobGroupNames();
      var jobDetails = new List<IJobDetail>();
      foreach (var jobGroup in jobGroupNames)
      {
        var groupMatcher = GroupMatcher<JobKey>.GroupContains(jobGroup);

        var jobKeys = scheduler.GetJobKeys(groupMatcher);
        jobDetails.AddRange(jobKeys.Select(scheduler.GetJobDetail));
      }
      WriteToFile(file, jobDetails);
    }

    private void WriteToFile(FileInfo file, IEnumerable<IJobDetail> jobDetails)
    {
      using (StreamWriter writer = file.CreateText())
      {
        XNamespace ns = "http://quartznet.sourceforge.net/JobSchedulingData";
        var doc = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"),
                        new XElement(ns + "quartz",
                        new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
                        new XAttribute("version", "1.0"),
                        new XAttribute("overwrite-existing-jobs", "true")));
        foreach (var detail in jobDetails)
        {
          Debug.Assert(doc.Root != null);
          doc.Root.Add(
              new XElement(ns + "job",
                new XElement(ns + "job-detail",
                new XElement(ns + "name", detail.Key.Name),
                new XElement(ns + "group", detail.Key.Group),
                new XElement(ns + "description", detail.Description),
                new XElement(ns + "job-type", detail.JobType.FullName + "," + detail.JobType.Assembly.FullName),
                //TODO: Apparently volatile is no longer available. Check.
                //, new XElement(ns + "volatile", detail.Volatile)
                new XElement(ns + "durable", detail.Durable),
                new XElement(ns + "recover", detail.RequestsRecovery), GetJobDataMap(ns, detail.JobDataMap)),
                GetTriggers(ns, detail)));
        }
        writer.Write(doc);
        writer.Flush();
        writer.Close();
      }
    }

    private XElement GetJobDataMap(XNamespace ns, JobDataMap jobDataMap)
    {
      var map = new XElement(ns + "job-data-map");
      foreach (var key in jobDataMap.GetKeys())
      {
        map.Add(new XElement(ns + "entry",
          new XElement(ns + "key", key),
          new XElement(ns + "value", jobDataMap[key])));
      }

      return map;
    }

    private XElement[] GetTriggers(XNamespace ns, IJobDetail detail)
    {
      var triggers = mScheduler.GetTriggersOfJob(detail.Key);
      var elements = new XElement[triggers.Count];
      var i = 0;
      foreach (var trigger in triggers)
      {
        elements[i] = new XElement(ns + "trigger");
        if (triggers[i] is SimpleTriggerImpl)
        {
          elements[i].Add(GetSimpleTrigger(ns, (SimpleTriggerImpl)triggers[i]));
        }
        else if (triggers[i] is CronTriggerImpl)
        {
          elements[i].Add(GetCronTrigger(ns, (CronTriggerImpl)triggers[i]));
        }
        i++;
      }
      return elements;
    }

    private XElement GetCronTrigger(XNamespace ns, CronTriggerImpl trigger)
    {
      var cronTrigger = new XElement(ns + "cron");
      AddCommonTriggerData(ns, cronTrigger, trigger);
      cronTrigger.Add(new XElement(ns + "cron-expression", trigger.CronExpressionString));

      return cronTrigger;
    }

    private void AddCommonTriggerData(XNamespace ns, XElement rootTriggerElement, AbstractTrigger trigger)
    {
      rootTriggerElement.Add(
        new XElement(ns + "name", trigger.Key.Name),
        new XElement(ns + "group", trigger.Key.Group),
        new XElement(ns + "description", trigger.Description),
        new XElement(ns + "misfire-instruction", GetMisfireInstructionText(trigger)),
        //, new XElement(ns + "volatile", trigger.Volatile)
        new XElement(ns + "job-name", trigger.JobName),
        new XElement(ns + "job-group", trigger.JobGroup));
    }

    private string GetMisfireInstructionText(AbstractTrigger trigger)
    {
      if (trigger is CronTriggerImpl)
      {
        return GetCronTriggerMisfireInstructionText(trigger.MisfireInstruction);
      }
      return GetSimpleTriggerMisfireInstructionText(trigger.MisfireInstruction);
    }

    private string GetSimpleTriggerMisfireInstructionText(int misfireInstruction)
    {
      switch (misfireInstruction)
      {
        case 0:
          return "SmartPolicy";

        case 1:
          return "FireNow";

        case 2:
          return "RescheduleNowWithExistingRepeatCount";

        case 3:
          return "RescheduleNowWithRemainingRepeatCount";

        case 4:
          return "RescheduleNextWithRemainingCount";

        case 5:
          return "RescheduleNextWithExistingCount";

        default:
          throw new ArgumentOutOfRangeException(string.Format("{0} is not a supported misfire instruction for SimpleTrigger See Quartz.MisfireInstruction for more details.", misfireInstruction));
      }
    }

    private string GetCronTriggerMisfireInstructionText(int misfireInstruction)
    {
      switch (misfireInstruction)
      {
        case 0:
          return "SmartPolicy";

        case 1:
          return "FireOnceNow";

        case 2:
          return "DoNothing";

        default:
          throw new ArgumentOutOfRangeException(string.Format("{0} is not a supported misfire instruction for CronTrigger See Quartz.MisfireInstruction for more details.", misfireInstruction));
      }
    }

    private XElement GetSimpleTrigger(XNamespace ns, SimpleTriggerImpl trigger)
    {
      var simpleTrigger = new XElement(ns + "simple");
      AddCommonTriggerData(ns, simpleTrigger, trigger);
      simpleTrigger.Add(
        new XElement(ns + "repeat-count", trigger.RepeatCount),
        new XElement(ns + "repeat-interval", trigger.RepeatInterval.Milliseconds));

      return simpleTrigger;
    }
  }
}
