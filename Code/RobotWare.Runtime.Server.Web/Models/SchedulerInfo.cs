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
    private readonly IScheduler mScheduler;

    public string Name
    {
      get
      {
        return mScheduler.SchedulerName;
      }
    }

    public IEnumerable<JobGroupInfo> JobGroups { get; private set; }

    public SchedulerInfo(IScheduler sched)
    {
      mScheduler = sched;
      JobGroups = from jobGroup in sched.GetJobGroupNames() select new JobGroupInfo(sched, jobGroup);
    }
  }
}