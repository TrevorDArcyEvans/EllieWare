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

namespace RobotWare.Quartz.Calendar.UserInterface
{
  public partial class CalendarCtrl : CalendarBase
  {
    public CalendarCtrl()
    {
      InitializeComponent();
    }

    private void FireCalendarChangedInternal(object sender, EventArgs e)
    {
      FireCalendarChanged(sender, e);
    }

    public override ICalendar Calendar
    {
      get
      {
        var selCalTab = Calendars.SelectedTab.Controls.OfType<CalendarBase>().Single();

        return selCalTab.Calendar;
      }
    }
  }
}
