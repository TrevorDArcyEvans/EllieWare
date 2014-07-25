//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using System.Linq;
using Quartz;

namespace RobotWare.Runtime.Server.Web.Models
{
  public class SchedulerInfo
  {
    public readonly IScheduler Scheduler;

    public string Name
    {
      get
      {
        return Scheduler.SchedulerName;
      }
    }

    public IEnumerable<JobGroupInfo> JobGroups { get; private set; }
    public IEnumerable<CalendarInfo> Calendars { get; private set; }

    public SchedulerInfo(IScheduler sched)
    {
      Scheduler = sched;
      JobGroups = from jobGroup in sched.GetJobGroupNames() select new JobGroupInfo(sched, jobGroup);
      Calendars = from calName in sched.GetCalendarNames()
                    select new CalendarInfo(Scheduler, TriggerBuilder.Create().ModifiedByCalendar(calName).Build());
    }
  }
}