//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using EllieWare.Common;

namespace EllieWare.EventLogger
{
  public partial class LoggerCtrl : UserControlBase
  {
    public LoggerCtrl()
    {
      InitializeComponent();
    }

    private void Source_TextChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void Level_SelectedIndexChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void Message_TextChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }
  }
}
