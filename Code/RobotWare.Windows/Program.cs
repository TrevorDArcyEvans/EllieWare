//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.IO;
using System.Windows.Forms;
using EllieWare.Common;

namespace RobotWare.Windows
{
  static class Program
  {

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      const string ApplicationName = "RobotWare for Windows";

      var licWrapper = new RobotWareWrapper(ApplicationName);
      var userDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
      var userSpecsPath = Path.Combine(userDocs, ApplicationName);
      Directory.CreateDirectory(userSpecsPath);

      Application.Run(new EllieWare.Manager.Manager(new[] { licWrapper }, ApplicationName, userSpecsPath));
    }
  }
}
