//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using Quartz;
using Quartz.Impl.Calendar;

namespace RobotWare.Quartz.Calendar.UserInterface
{
  public partial class DailyCtrl : CalendarBase
  {
    private readonly DailyCalendar mCalendar = new DailyCalendar(DateTime.Now.AddHours(-1), DateTime.Now);

    public DailyCtrl()
    {
      InitializeComponent();
    }

    public override Type CalendarType
    {
      get
      {
        return typeof (DailyCtrl);
      }
    }

    public override ICalendar Calendar
    {
      get
      {
        return (ICalendar)mCalendar.Clone();
      }
    }

    private void FireCalendarChangedInternal(object sender, EventArgs e)
    {
      FireCalendarChanged(sender, e);
    }

    protected override void UpdateUserInterface()
    {
      if (TimeFrom.Value >= TimeTo.Value)
      {
        TimeTo.Value = TimeFrom.Value.AddSeconds(5);
      }
      mCalendar.SetTimeRange(TimeFrom.Value, TimeTo.Value);
      mCalendar.InvertTimeRange = InvertRange.Checked;
      mCalendar.Description = string.Format("From {0} to {1}",
                                mCalendar.GetTimeRangeStartingTimeUtc(new DateTimeOffset()), 
                                mCalendar.GetTimeRangeEndingTimeUtc(new DateTimeOffset()));
    }
  }
}
