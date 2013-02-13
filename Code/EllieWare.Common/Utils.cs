//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public class Utils
  {
    public static IEnumerable<IFactory> GetFactories()
    {
      var retVal = new List<IFactory>();
      var callAssyLoc = Assembly.GetCallingAssembly().Location;
      var callAssyDir = Path.GetDirectoryName(callAssyLoc);
      var dllFiles = Directory.EnumerateFiles(callAssyDir, "*.dll");
      foreach (var thisDllFile in dllFiles)
      {
        try
        {
          var assy = Assembly.LoadFrom(thisDllFile);
          var factories = from t in assy.GetTypes()
                          where t.GetInterfaces().Contains(typeof(IFactory))
                          select Activator.CreateInstance(t) as IFactory;
          retVal.AddRange(factories);
        }
        catch (BadImageFormatException)
        {
          // might not be a .NET dll but how?
        }
      }

      return retVal;
    }

    public static bool IsValidFileName(string expression)
    {
      const string sPattern = @"^(?!^(PRN|AUX|CLOCK\$|NUL|CON|COM\d|LPT\d|\..*)(\..+)?$)[^\x00-\x1f\\?*:\"";|/]+$";

      return (Regex.IsMatch(expression, sPattern, RegexOptions.CultureInvariant));
    }

    public static void Wait(TimeSpan pause)
    {
      var now = DateTime.Now;
      var end = now.Add(pause);
      while (DateTime.Now < end)
      {
        Application.DoEvents();
        Thread.Sleep(100);
        Application.DoEvents();
      }
    }

    public static void Wait(int milliSecs)
    {
      Wait(new TimeSpan(0, 0, 0,0, milliSecs));
    }

    public static bool IsLocalSpecification(string userFolder, string filePath)
    {
      return filePath.ToLower(CultureInfo.CurrentCulture).StartsWith(userFolder.ToLower(CultureInfo.CurrentCulture));
    }
  }
}
