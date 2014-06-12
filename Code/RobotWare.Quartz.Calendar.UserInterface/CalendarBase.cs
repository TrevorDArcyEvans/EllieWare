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

namespace RobotWare.Quartz.Calendar.UserInterface
{
  public partial class CalendarBase : UserControl
  {
    public event EventHandler CalendarChanged;

    public CalendarBase()
    {
      InitializeComponent();
    }

    public virtual Type CalendarType
    {
      get
      {
        throw new NotImplementedException("Must override in derived class - not abstract for VS designer support");
      }
    }

    public virtual ICalendar Calendar
    {
      get
      {
        throw new NotImplementedException("Must override in derived class - not abstract for VS designer support");
      }
    }

    protected virtual void UpdateUserInterface()
    {
    }

    protected virtual void FireCalendarChanged(object sender, EventArgs e)
    {
      UpdateUserInterface();

      var handler = CalendarChanged;
      if (handler != null)
      {
        handler(this, e);
      }
    }
  }
}
