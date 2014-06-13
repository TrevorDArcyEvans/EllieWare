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
    private readonly DailyCalendar mCalendar = new DailyCalendar("09:00", "17:30");

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

    protected override sealed void UpdateUserInterface()
    {
      if (TimeFrom.Value >= TimeTo.Value)
      {
        TimeTo.Value = TimeFrom.Value.AddSeconds(5);
      }
      mCalendar.SetTimeRange(TimeFrom.Value, TimeTo.Value);
      mCalendar.InvertTimeRange = InvertRange.Checked;

      // If the property invertTimeRange is false(default), the time range defines a range 
      // of times in which triggers are not allowed to fire. If invertTimeRange is true, the
      // time range is inverted: that is, all times outside the defined time range are excluded.
      mCalendar.Description = string.Format("{0} {1} to {2}",
                                mCalendar.InvertTimeRange ? "Including" : "Excluding",
                                mCalendar.GetTimeRangeStartingTimeUtc(new DateTimeOffset()).ToString(TimeFrom.CustomFormat), 
                                mCalendar.GetTimeRangeEndingTimeUtc(new DateTimeOffset()).ToString(TimeTo.CustomFormat));
    }
  }
}
