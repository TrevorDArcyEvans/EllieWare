//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using EllieWare.Common;
using EllieWare.Interfaces;
using RobotWare.Runtime.Server.Properties;

namespace RobotWare.Runtime.Server
{
  internal static class Program
  {
    [STAThread]
    private static int Main(string[] args)
    {
      IRobotWare root = new RobotWareServerWrapper();

      if (!root.IsLicensed)
      {
        Utils.DoRequestLicense(root.ApplicationName, root.Version, Resources.robot_32x32, () => root.IsLicensed);
      }

      if (!root.IsLicensed)
      {
        return 0;
      }

      var host = new Host();
      var bRet = host.Run(args[0]);

      return bRet ? 1 : 0;
    }
  }
}
