//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public class LicensableWrapper : ILicensable
  {
    public bool IsLicensed { get; private set; }

    public LicensableWrapper(string appName)
    {
      IsLicensed = Licensing.LicenseManager.IsLicensed(appName);
    }
  }
}
