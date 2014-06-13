//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RobotWare.Runtime.Server.Manager
{
  public partial class CalendarSelector : Form
  {
    public CalendarSelector()
    {
      InitializeComponent();
    }

    public CalendarSelector(IEnumerable<string> allCals) :
      this()
    {
      Calendar.DataSource = allCals;
      CmdOK.Enabled = allCals.Any();
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
