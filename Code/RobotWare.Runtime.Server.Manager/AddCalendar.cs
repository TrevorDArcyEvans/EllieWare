//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Windows.Forms;
using Quartz;

namespace RobotWare.Runtime.Server.Manager
{
  public partial class AddCalendar : Form
  {
    public AddCalendar()
    {
      InitializeComponent();
    }

    private void Calendar_CalendarChanged(object sender, EventArgs e)
    {
      Description.Text = mCalendar.Calendar.Description;
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
