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
      IRobotWare mRoot = new RobotWareWrapper(Host.ApplicationName);

      if (!mRoot.IsLicensed)
      {
        Utils.DoRequestLicense(mRoot.ApplicationName, mRoot.Version, Resources.robot_32x32, () => mRoot.IsLicensed);
      }
    }
  }
}
