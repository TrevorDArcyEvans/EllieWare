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

namespace EllieWare.Common
{
  public class RobotWareWrapper : IRobotWare
  {
    public bool IsLicensed { get; private set; }
    public string UserSpecificationFolder { get; private set; }
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
      IsLicensed = Licensing.LicenseManager.IsLicensed(ApplicationName, Version);

      var userDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
      UserSpecificationFolder = Path.Combine(userDocs, ApplicationName);
    }

    public IEnumerable<string> Specifications
    {
      get
      {
        var allSpecsWithExtn = Directory.EnumerateFiles(UserSpecificationFolder, "*" + Utils.MacroFileExtension);
        var allSpecsNoExten = from specWithExtn in allSpecsWithExtn select Path.GetFileNameWithoutExtension(specWithExtn);

        return allSpecsNoExten;
      }
    }
  }
}
