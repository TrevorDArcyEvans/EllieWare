//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Reflection;
using EllieWare.Licensing;
using SerpentWare.Interfaces;

namespace SerpentWare.Common
{
  public abstract class SerpentWareWrapperBase : ISerpentWare
  {
    // HKCU
    //  SOFTWARE
    //    EllieWare
    //      [ProductName]
    //        {WorkGroupSpecificationFolder} --> WorkGroupSpecificationFolder

    public bool IsLicensed
    {
      get
      {
        return LicenseManager.IsLicensed(ApplicationName, Version);
      }
    }

    public string ApplicationName { get; private set; }

    public Version Version
    {
      get
      {
        return Assembly.GetExecutingAssembly().GetName().Version;
      }
    }

    public abstract IEnumerable<Assembly> Assemblies
    {
      get;
    }

    public SerpentWareWrapperBase(string appName)
    {
      ApplicationName = appName;
    }
  }
}
