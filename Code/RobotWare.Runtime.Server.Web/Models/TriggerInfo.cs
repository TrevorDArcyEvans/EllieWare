//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using Quartz;

namespace RobotWare.Runtime.Server.Web.Models
{
  public class TriggerInfo
  {
    private readonly ITrigger mTrigger;

    public string Name
    {
      get
      {
        return mTrigger.Key.Name;
      }
    }

    public string Group
    {
      get
      {
        return mTrigger.Key.Group;
      }
    }

    public string Description
    {
      get
      {
        return mTrigger.Description;
      }
    }

    public CalendarInfo Calendar { get; private set; }

    public TriggerInfo(IScheduler sched, ITrigger trigger)
    {
      mTrigger = trigger;
      Calendar = new CalendarInfo(sched, trigger);
    }
  }
}
