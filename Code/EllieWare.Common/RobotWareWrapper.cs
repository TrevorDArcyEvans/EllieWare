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

    private const string RegistryKey = "EllieWare";

    public bool IsLicensed
    {
      get
      {
        return Licensing.LicenseManager.IsLicensed(ApplicationName, Version);
      }
    }
    public string UserSpecificationFolder { get; private set; }
    public string WorkGroupSpecificationFolder { get; private set; }
    public string ApplicationName { get; private set; }
    public Version Version
    {
      get
      {
        return Assembly.GetExecutingAssembly().GetName().Version;
      }
    }

    public RobotWareWrapper(string appName)
    {
      ApplicationName = appName;

      var userDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
      UserSpecificationFolder = Path.Combine(userDocs, ApplicationName);

      // read work group folder out of registry for the moment
      var root = Registry.CurrentUser.OpenSubKey("SOFTWARE");
      var ellieWare = root.OpenSubKey(RegistryKey);
      if (ellieWare == null)
      {
        return;
      }

      var product = ellieWare.OpenSubKey(appName);
      if (product == null)
      {
        return;
      }

      WorkGroupSpecificationFolder = (string)product.GetValue("WorkGroupSpecificationFolder");
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
  }
}
