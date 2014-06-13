//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//

namespace RobotWare.Runtime.Server.Manager
{
  public class SchedulerNode : NodeBase
  {
    public QuartzSchedulerFacade Scheduler { get; private set; }

    public SchedulerNode(QuartzSchedulerFacade scheduler) :
      base(scheduler.Address, 1)
    {
      Scheduler = scheduler;
    }
  }
}
