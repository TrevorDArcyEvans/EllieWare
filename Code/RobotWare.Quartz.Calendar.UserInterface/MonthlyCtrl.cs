//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Linq;
using Quartz;
using Quartz.Impl.Calendar;

namespace RobotWare.Quartz.Calendar.UserInterface
{
  public partial class MonthlyCtrl : CalendarBase
  {
    private readonly MonthlyCalendar mCalendar = new MonthlyCalendar();

    public MonthlyCtrl()
    {
      InitializeComponent();
    }

    public override Type CalendarType
    {
      get
      {
        return typeof(MonthlyCalendar);
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
      for (var i = 0; i < mCalendar.DaysExcluded.Count(); i++)
      {
        mCalendar.DaysExcluded[i] = false;
      }

      mCalendar.Description = "Excluding days ";
      foreach (int chk in DaysExcluded.CheckedIndices)
      {
        mCalendar.DaysExcluded[chk] = true;
        mCalendar.Description += chk + 1 + ", ";
      }
      mCalendar.Description = mCalendar.Description.TrimEnd(new[] {',', ' '});
    }
  }
}
