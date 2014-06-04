//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Windows.Forms;
using SerpentWare.Common;
using SerpentWare.Interfaces;

namespace SerpentWare.Windows
{
  static class Program
  {
    [STAThread]
    static void Main()
    {
      const string ApplicationName = "SerpentWare for Windows";

      ISerpentWare mLicenseWrapper = new SerpentWareWindows(ApplicationName);

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new PyConsole(mLicenseWrapper));
    }
  }
}
