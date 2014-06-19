//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//

using Quartz;

namespace RobotWare.Runtime.Server.Manager
{
  public class SchedulerNode : NodeBase
  {
    public IScheduler Scheduler { get; private set; }

    public SchedulerNode(IScheduler scheduler) :
      base(scheduler.SchedulerName, 1)
    {
      Scheduler = scheduler;
    }
  }
}
