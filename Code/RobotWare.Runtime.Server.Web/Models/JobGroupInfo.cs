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
using Quartz.Impl.Matchers;

namespace RobotWare.Runtime.Server.Web.Models
{
  public class JobGroupInfo
  {
    public string Name { get; private set; }
    public IEnumerable<JobInfo> Jobs { get; private set; }

    public JobGroupInfo(IScheduler sched, string name)
    {
      Name = name;

      var groupMatcher = GroupMatcher<JobKey>.GroupContains(Name);
      var jobKeys = sched.GetJobKeys(groupMatcher);

      Jobs = jobKeys.Select(sched.GetJobDetail).Select(detail => new JobInfo(sched, detail));
    }
  }
}
