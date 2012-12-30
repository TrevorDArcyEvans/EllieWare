//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Windows.Forms;

namespace EllieWare.Manager
{
  public partial class RequestLicense : Form
  {
    public RequestLicense()
    {
      InitializeComponent();
    }

    public RequestLicense(string appName) :
      this()
    {
      Product.Text = appName;
    }
  }
}
