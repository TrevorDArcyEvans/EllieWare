//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using EllieWare.Common;

namespace EllieWare.Pdf
{
  public partial class ProtectCtrl : DualItemIOBaseCtrl
  {
    public ProtectCtrl()
    {
      InitializeComponent();

      ProtectMain.BringToFront();
    }

    private void OwnerPassword_TextChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void UserPassword_TextChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void Options_SelectedIndexChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }
  }
}
