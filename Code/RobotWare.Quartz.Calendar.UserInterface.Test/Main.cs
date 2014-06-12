//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Windows.Forms;

namespace RobotWare.Quartz.Calendar.UserInterface.Test
{
  public partial class Main : Form
  {
    public Main()
    {
      InitializeComponent();
    }

    private void CalCtrl_CalendarChanged(object sender, EventArgs e)
    {
      Description.Text = CalCtrl.Calendar.Description;
    }
  }
}
