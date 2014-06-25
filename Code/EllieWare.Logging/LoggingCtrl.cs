//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using EllieWare.Common;

namespace EllieWare.Logging
{
  public partial class LoggingCtrl : UserControlBase
  {
    public LoggingCtrl()
    {
      InitializeComponent();
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
