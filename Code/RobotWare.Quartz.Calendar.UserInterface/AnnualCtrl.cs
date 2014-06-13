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
using Quartz.Collection;
using Quartz.Impl.Calendar;

namespace RobotWare.Quartz.Calendar.UserInterface
{
  public partial class AnnualCtrl : CalendarBase
  {
    private readonly HolidayCalendar mCalendar = new HolidayCalendar();
    private readonly TreeSet<DateTime> mExcludedDates = new TreeSet<DateTime>();

    public AnnualCtrl()
    {
      InitializeComponent();

      DaysExcluded.DataSource = mExcludedDates.ToList();
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
      CmdDelete.Enabled = DaysExcluded.SelectedIndex > -1;
      CmdAdd.Enabled = !mExcludedDates.Contains(ExcludeDay.Value.Date);

      foreach (var excDate in mCalendar.ExcludedDates)
      {
        mCalendar.RemoveExcludedDate(excDate);
      }

      foreach (var excDate in mExcludedDates)
      {
        mCalendar.AddExcludedDate(excDate);
      }

      mCalendar.Description = string.Format("Excluding {0} dates: ", mCalendar.ExcludedDates.Count);
      foreach (var excDate in mCalendar.ExcludedDates)
      {
        mCalendar.Description += excDate.Date.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern) + ", ";
      }
      mCalendar.Description = mCalendar.Description.TrimEnd(new[] { ',', ' ' });
    }

    private void CmdAdd_Click(object sender, EventArgs e)
    {
      mExcludedDates.Add(ExcludeDay.Value.Date);
      DaysExcluded.DataSource = mExcludedDates.ToList();
      FireCalendarChanged(sender, e);
    }

    private void CmdDelete_Click(object sender, EventArgs e)
    {
      mExcludedDates.RemoveAt(DaysExcluded.SelectedIndex);
      DaysExcluded.DataSource = mExcludedDates.ToList();
      FireCalendarChanged(sender, e);
    }
  }
}
