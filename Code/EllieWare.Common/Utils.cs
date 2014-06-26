//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
      Debug.Assert(callAssyDir != null);
      var dllFiles = Directory.EnumerateFiles(callAssyDir, "*.dll");
      foreach (var thisDllFile in dllFiles)
      {
        try
        {
          var assy = Assembly.LoadFrom(thisDllFile);
          var factories = from t in assy.GetTypes()
                          where t.IsSubclassOf(typeof(IFactory)) && t.IsClass && !t.IsAbstract && t.IsMarshalByRef
                          select (IFactory)Activator.CreateInstance(t);
          retVal.AddRange(factories);
        }
        catch (BadImageFormatException)
        {
          // might not be a .NET dll but how?
        }
        catch (ReflectionTypeLoadException)
        {
        }
      }

      return retVal;
    }

    public static bool IsValidFileName(string expression)
    {
      const string Pattern = @"^(?!^(PRN|AUX|CLOCK\$|NUL|CON|COM\d|LPT\d|\..*)(\..+)?$)[^\x00-\x1f\\?*:\"";|/]+$";

      return (Regex.IsMatch(expression, Pattern, RegexOptions.CultureInvariant));
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

    public static bool IsLocalSpecification(IRobotWare root, string filePath)
    {
      // use IRobotWare.UserSpecificationFolder as IRobotWare.WorkGroupSpecificationFolder can be null
      return filePath.ToLower(CultureInfo.CurrentCulture).StartsWith(root.UserSpecificationFolder.ToLower(CultureInfo.CurrentCulture));
    }

    public const string RegistryKey = "EllieWare";

    public static void DoRequestLicense(string appName, Version appVer, Icon appIcon, Func<bool> isLicensed)
    {
      var dlg = new RequestLicense(appName, appVer, appIcon);
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        // attempt to register with provided info
        Licensing.LicenseManager.Register(appName, appVer, dlg.UserName.Text, dlg.LicenseCode.Text);

        var msg = string.Format(isLicensed() ? "Successfully registered:" + Environment.NewLine +
                                             "  " + appName
                                  : "Information incorrect - product not registered");
        MessageBox.Show(msg, appName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
      }
    }

    public static void GetDependenciesForLocal(string fileName, HashSet<string> depends)
    {
      var assyPath = GetPathForLocal(fileName);
      var depAssy = Assembly.ReflectionOnlyLoadFrom(assyPath);
      var depTypes = depAssy.GetTypes();
      foreach (var thisDep in depTypes.Select(GetReferencesAssembliesPaths).SelectMany(deps => deps))
      {
        depends.SafeAdd(thisDep);
      }
    }

    public static string GetPathForLocal(string fileName)
    {
      var assy = Assembly.GetExecutingAssembly();
      var assyDir = Path.GetDirectoryName(assy.Location);
      Debug.Assert(assyDir != null);
      return Path.Combine(assyDir, fileName);
    }

    public static IEnumerable<string> GetReferencesAssembliesPaths(Type type)
    {
      yield return type.Assembly.Location;

      foreach (var assemblyName in type.Assembly.GetReferencedAssemblies())
      {
        yield return Assembly.ReflectionOnlyLoad(assemblyName.FullName).Location;
      }
    }
  }
}
