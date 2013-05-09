//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EllieWare.Common
{
  public partial class RequestLicense : Form
  {
    public RequestLicense()
    {
      InitializeComponent();

      UserName.Text = Environment.UserName;
    }

    public RequestLicense(string appName, Version appVer, Icon appIcon) :
      this()
    {
      Product.Text = appName;
      Version.Text = appVer.ToString(3);
      Icon = appIcon;
    }

    private void RequestLicense_Shown(object sender, EventArgs e)
    {
      LicenseCode.Focus();
    }
  }
}

