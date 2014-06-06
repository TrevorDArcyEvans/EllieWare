//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Windows.Forms;

namespace RobotWare.Runtime.Server.Manager
{
  public class SchedulerNode : TreeNode
  {
    public QuartzSchedulerFacade Scheduler { get; private set; }

    public SchedulerNode(QuartzSchedulerFacade scheduler)
    {
      Text = Name = scheduler.Address;
      Scheduler = scheduler;
    }
  }
}
