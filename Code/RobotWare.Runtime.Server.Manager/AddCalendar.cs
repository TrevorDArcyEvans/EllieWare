//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Quartz;

namespace RobotWare.Runtime.Server.Manager
{
  public partial class AddCalendar : Form
  {
    private readonly IEnumerable<string> mAllCalendars;

    public AddCalendar()
    {
      InitializeComponent();
    }

    public AddCalendar(IEnumerable<string> allCals) :
      this()
    {
      mAllCalendars = allCals;
    }

    private void Calendar_CalendarChanged(object sender, EventArgs e)
    {
      Description.Text = mCalendar.Calendar.Description;
      CmdOK.Enabled = !mAllCalendars.Contains(mCalendar.Calendar.Description);
    }

    public ICalendar Calendar
    {
      get
      {
        return mCalendar.Calendar;
      }
    }
  }
}
