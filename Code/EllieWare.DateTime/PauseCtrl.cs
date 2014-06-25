//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using EllieWare.Common;

namespace EllieWare.DateTime
{
  public partial class PauseCtrl : UserControlBase
  {
    public PauseCtrl()
    {
      InitializeComponent();
    }

    private void TimeSpan_ValueChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }
  }
}
