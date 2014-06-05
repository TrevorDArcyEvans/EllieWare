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
  static class Program
  {
    [STAThread]
    static void Main()
    {
      IRobotWare root = new RobotWareWrapper(Host.ApplicationName);

      if (!root.IsLicensed)
      {
        Utils.DoRequestLicense(root.ApplicationName, root.Version, Resources.robot_32x32, () => root.IsLicensed);
      }
    }
  }
}
