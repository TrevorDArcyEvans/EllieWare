//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.IO;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public class RobotWareWrapper : IRobotWare
  {
    public bool IsLicensed { get; private set; }
    public string UserSpecificationFolder { get; private set; }
    public string ApplicationName { get; private set; }

    public RobotWareWrapper(string appName)
    {
      ApplicationName = appName;
      IsLicensed = Licensing.LicenseManager.IsLicensed(ApplicationName);

      var userDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
      UserSpecificationFolder = Path.Combine(userDocs, ApplicationName);
    }
  }
}
