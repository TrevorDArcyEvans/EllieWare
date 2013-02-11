//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Windows.Forms;
using EllieWare.Interfaces;

namespace EllieWare.Manager
{
  public partial class RequestLicense : Form
  {
    public RequestLicense()
    {
      InitializeComponent();
    }

    public RequestLicense(IRobotWare root) :
      this()
    {
      Product.Text = root.ApplicationName;
      Version.Text = root.Version.ToString(3);
    }

    private void RequestLicense_Shown(object sender, System.EventArgs e)
    {
      UserName.Focus();
    }
  }
}

