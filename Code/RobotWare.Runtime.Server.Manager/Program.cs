//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Windows.Forms;
using EllieWare.Common;
using EllieWare.Interfaces;
using RobotWare.Runtime.Server.Manager.Properties;

namespace RobotWare.Runtime.Server.Manager
{
  static class Program
  {
    [STAThread]
    static void Main()
    {
      // enable these first as licensing will create UI windows
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      IRobotWare root = new RobotWareServerWrapper();

      if (!root.IsLicensed)
      {
        Utils.DoRequestLicense(root.ApplicationName, root.Version, Resources.robot_32x32, () => root.IsLicensed);
      }

      if (!root.IsLicensed)
      {
        return;
      }

      Application.Run(new Main(root));
    }
  }
}
