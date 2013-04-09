//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Win32;
using SerpentWare.Common;

namespace SerpentWare.SpaceClaim
{
  public class SerpentWareSpaceClaim : SerpentWareWrapperBase
  {
    public override IEnumerable<Assembly> Assemblies
    {
      get
      {
        const string ApiDirectoryPrefix = "SpaceClaim.Api.V";
        const string ApiPathTemplate = ApiDirectoryPrefix + @"{0}\" + ApiDirectoryPrefix + "{0}.dll";

        // work out path to API dll from registry:
        //    HKCR\SpaceClaim.Location
        //      {Path}
        var hkcrLoc = Registry.ClassesRoot.OpenSubKey("SpaceClaim.Location");
        var SCpath = (string)hkcrLoc.GetValue("Path");
        var apiDirPath = Path.Combine(SCpath, ApiDirectoryPrefix);
        var allApiDirs = Directory.EnumerateDirectories(SCpath).Where(x => x.Contains(apiDirPath));
        var allApiVersStrs = from thisAllApiDir in allApiDirs
                             select
                               thisAllApiDir.Substring(apiDirPath.Length,
                                                       thisAllApiDir.Length - apiDirPath.Length);
        var allApiVers = from thisApiVerStr in allApiVersStrs select int.Parse(thisApiVerStr);
        var latestApi = allApiVers.OrderBy(x => x).Last();
        var apiDllRelpath = string.Format(ApiPathTemplate, latestApi);
        var assyPath = Path.Combine(SCpath, apiDllRelpath);
        var assy = Assembly.LoadFile(assyPath);

        return new[] { assy };
      }
    }

    public SerpentWareSpaceClaim(string appName) :
      base(appName)
    {
    }
  }
}
