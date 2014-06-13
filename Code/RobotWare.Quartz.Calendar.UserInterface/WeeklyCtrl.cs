//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Globalization;
using System.Linq;
using Quartz;
using Quartz.Impl.Calendar;

namespace RobotWare.Quartz.Calendar.UserInterface
{
  public partial class WeeklyCtrl : CalendarBase
  {
    private readonly WeeklyCalendar mCalendar = new WeeklyCalendar();

    public WeeklyCtrl()
    {
      InitializeComponent();
      DaysExcluded.DataSource = CultureInfo.CurrentCulture.DateTimeFormat.DayNames;
    }

    public override Type CalendarType
    {
      get
      {
        return typeof(WeeklyCalendar);
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

      mCalendar.Description = string.Format("Excluding {0}", DaysExcluded.CheckedIndices.Count > 0 ? string.Empty : "no days");
      foreach (int chk in DaysExcluded.CheckedIndices)
      {
        mCalendar.DaysExcluded[chk] = true;
        mCalendar.Description += CultureInfo.CurrentCulture.DateTimeFormat.DayNames[chk] + ", ";
      }
      mCalendar.Description = mCalendar.Description.TrimEnd(new[] { ',', ' ' });
    }
  }
}
