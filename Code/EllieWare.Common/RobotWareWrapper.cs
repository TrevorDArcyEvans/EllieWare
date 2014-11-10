//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using EllieWare.Interfaces;
using Microsoft.Win32;

namespace EllieWare.Common
{
  public class RobotWareWrapper : IRobotWare
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
        return Licensing.LicenseManager.IsLicensed(ApplicationName, Version);
      }
    }

    public string UserSpecificationFolder { get; protected set; }

    public string WorkGroupSpecificationFolder
    {
      get
      {
        // read work group folder out of registry for the moment
        var root = Registry.CurrentUser.OpenSubKey("SOFTWARE");
        var ellieWare = root.OpenSubKey(Utils.RegistryKey);
        if (ellieWare == null)
        {
          return null;
        }

        var product = ellieWare.OpenSubKey(ApplicationName);
        if (product == null)
        {
          return null;
        }

        return (string)product.GetValue("WorkGroupSpecificationFolder");
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

    public RobotWareWrapper(string appName, object appRoot)
    {
      ApplicationName = appName;
      ApplicationRoot = appRoot;

      var userDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
      UserSpecificationFolder = Path.Combine(userDocs, ApplicationName);
    }

    public RobotWareWrapper(string appName) :
      this(appName, null)
    {
    }

    public IEnumerable<string> Specifications
    {
      get
      {
        var allUserSpecsWithExtn = Directory.EnumerateFiles(UserSpecificationFolder, "*" + Interfaces.FileExtensions.MacroFileExtension);
        var retVal = allUserSpecsWithExtn.ToList();

        if (!string.IsNullOrEmpty(WorkGroupSpecificationFolder))
        {
          var allWorkGroupWithExtn = Directory.EnumerateFiles(WorkGroupSpecificationFolder, "*" + Interfaces.FileExtensions.MacroFileExtension);
          retVal.AddRange(allWorkGroupWithExtn);
        }

        return retVal;
      }
    }

    public object ApplicationRoot { get; private set; }
  }
}
