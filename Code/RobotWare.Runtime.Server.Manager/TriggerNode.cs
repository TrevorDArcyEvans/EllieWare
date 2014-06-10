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
  public class TriggerNode : NodeBase
  {
    public ITrigger Trigger { get; private set; }

    public TriggerNode(ITrigger trigger) :
      // use description if we have it
      base(trigger.Description ?? trigger.Key.Name)
    {
      Trigger = trigger;
    }
  }
}
