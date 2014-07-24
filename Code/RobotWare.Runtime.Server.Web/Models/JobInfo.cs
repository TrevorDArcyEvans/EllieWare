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
  public class JobInfo
  {
    private readonly IJobDetail mJobDetail;

    public string Name
    {
      get
      {
        return mJobDetail.Key.Name;
      }
    }

    public string Group
    {
      get
      {
        return mJobDetail.Key.Group;
      }
    }

    public IEnumerable<TriggerInfo> Triggers { get; private set; }

    public JobInfo(IScheduler sched, IJobDetail jobDetail)
    {
      mJobDetail = jobDetail;
      Triggers = from trig in sched.GetTriggersOfJob(new JobKey(jobDetail.Key.Name, jobDetail.Key.Group))
                 select new TriggerInfo(sched, trig);
    }
  }
}
