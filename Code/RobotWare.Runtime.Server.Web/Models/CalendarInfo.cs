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
  public class CalendarInfo
  {
    private readonly IScheduler mSched;
    private readonly ITrigger mTrigger;

    public string Name
    {
      get { return mTrigger.CalendarName; }
    }

    public CalendarInfo(IScheduler sched, ITrigger trigger)
    {
      mSched = sched;
      mTrigger = trigger;
    }
  }
}
