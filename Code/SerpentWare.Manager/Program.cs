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
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      const string ApplicationName = "SerpentWare for SpaceClaim";

      ISerpentWare mLicenseWrapper = new SerpentWareWindows(ApplicationName);

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new PyConsole(mLicenseWrapper));
    }
  }
}
