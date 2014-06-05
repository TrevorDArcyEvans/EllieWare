//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.IO;
using EllieWare.Common;

namespace RobotWare.Runtime.Server
{
  public class RobotWareServerWrapper : RobotWareWrapper
  {
    public const string ServerApplicationName = "RobotWare Runtime for Windows Server";

    public RobotWareServerWrapper():
      base(ServerApplicationName)
    {
      var appDocs = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
      UserSpecificationFolder = Path.Combine(appDocs, ServerApplicationName);
    }
  }
}
