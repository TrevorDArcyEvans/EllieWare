//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace EllieWare.Common
{
  public class RobotWareWrapper : IRobotWare
  {
    public bool IsLicensed { get; private set; }

    public RobotWareWrapper(string appName)
    {
      IsLicensed = Licensing.LicenseManager.IsLicensed(appName);
    }
  }
}
