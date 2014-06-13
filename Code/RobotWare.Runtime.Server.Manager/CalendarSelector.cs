//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using System.Windows.Forms;

namespace RobotWare.Runtime.Server.Manager
{
  public partial class CalendarSelector : Form
  {
    public CalendarSelector()
    {
      InitializeComponent();
    }

    public CalendarSelector(IList<string> allCals) :
      this()
    {
      Calendar.DataSource = allCals;
    }

    public string SelectedCalendar
    {
      get
      {
        return (string)Calendar.SelectedValue;
      }
    }
  }
}
