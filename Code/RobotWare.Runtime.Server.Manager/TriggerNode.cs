﻿//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Windows.Forms;
using Quartz;

namespace RobotWare.Runtime.Server.Manager
{
  public class TriggerNode : TreeNode
  {
    public ITrigger Trigger { get; private set; }

    public TriggerNode(ITrigger trigger)
    {
      // use description if we have it
      Name = Text = trigger.Description ?? trigger.Key.Name;
      Trigger = trigger;
    }
  }
}
