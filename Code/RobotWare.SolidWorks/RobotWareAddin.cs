//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using EllieWare.Common;
using EllieWare.Manager;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swpublished;

namespace RobotWare.SolidWorks
{
  [Guid("3996542B-D2C9-4647-9FF9-AE03955E9D48")]
  [ComVisible(true)]
  [SwAddin("Automation made easy", "RobotWare for SolidWorks", true)]
  public class RobotWareAddin : ISwAddin
  {
    private readonly IDictionary<string, Assembly> mAdditionalAssys = new Dictionary<string, Assembly>();

    public RobotWareAddin()
    {
      LoadResolverAssemblies();

      // running inside SW app domain which has BaseDirectory of SW install directory
      // so we have to use assys from our directory
      AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
    }

    private void LoadResolverAssemblies()
    {
      // load .NET assys in our directory for assembly resolver
      var assy = Assembly.GetExecutingAssembly();
      var assyPath = assy.Location;
      var assyDir = Path.GetDirectoryName(assyPath);
      var addAssys = Directory.EnumerateFiles(assyDir, @"*.dll");
      foreach (var assemblyName in addAssys)
      {
        try
        {
          var assembly = Assembly.LoadFrom(assemblyName);
          mAdditionalAssys.Add(assembly.FullName, assembly);
        }
        catch (BadImageFormatException)
        {
          // might not be a .NET dll but how?
        }
        catch (ReflectionTypeLoadException)
        {
        }
      }
    }

    private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
      Assembly assy;
      mAdditionalAssys.TryGetValue(args.Name, out assy);

      return assy;
    }

    #region SolidWorks Registration

    [ComRegisterFunctionAttribute]
    public static void RegisterFunction(Type t)
    {
      #region Get Custom Attribute: SwAddinAttribute

      SwAddinAttribute swAttr = null;
      var type = typeof(RobotWareAddin);

      foreach (System.Attribute attr in type.GetCustomAttributes(false))
      {
        if (!(attr is SwAddinAttribute))
        {
          continue;
        }
        swAttr = (SwAddinAttribute)attr;
        break;
      }
      Debug.Assert(swAttr != null);

      #endregion

      try
      {
        var hklm = Microsoft.Win32.Registry.LocalMachine;
        var hkcu = Microsoft.Win32.Registry.CurrentUser;

        var keyname = "SOFTWARE\\SolidWorks\\Addins\\{" + t.GUID + "}";
        var addinkey = hklm.CreateSubKey(keyname);
        addinkey.SetValue(null, 0);

        addinkey.SetValue("Description", swAttr.Description);
        addinkey.SetValue("Title", swAttr.Title);

        keyname = "Software\\SolidWorks\\AddInsStartup\\{" + t.GUID + "}";
        addinkey = hkcu.CreateSubKey(keyname);
        addinkey.SetValue(null, Convert.ToInt32(swAttr.LoadAtStartup), Microsoft.Win32.RegistryValueKind.DWord);
      }
      catch (Exception e)
      {
        Console.WriteLine(@"There was a problem registering this dll: " + e.Message);
        MessageBox.Show(@"There was a problem registering this addin: " + System.Environment.NewLine + e.Message);
      }
    }

    [ComUnregisterFunctionAttribute]
    public static void UnregisterFunction(Type t)
    {
      try
      {
        var hklm = Microsoft.Win32.Registry.LocalMachine;
        var hkcu = Microsoft.Win32.Registry.CurrentUser;

        var keyname = "SOFTWARE\\SolidWorks\\Addins\\{" + t.GUID + "}";
        hklm.DeleteSubKey(keyname);

        keyname = "Software\\SolidWorks\\AddInsStartup\\{" + t.GUID + "}";
        hkcu.DeleteSubKey(keyname);
      }
      catch (Exception e)
      {
        Console.WriteLine(@"There was a problem unregistering this dll: " + e.Message);
        MessageBox.Show(@"There was a problem unregistering this DLL: " + System.Environment.NewLine + e.Message);
      }
    }

    #endregion

    public bool ConnectToSW(object thisSW, int cookie)
    {
      CreateTaskPane((ISldWorks)thisSW);

      return true;
    }

    public bool DisconnectFromSW()
    {
      //The addin _must_ call GC.Collect() here in order to retrieve all managed code pointers 
      GC.Collect();
      GC.WaitForPendingFinalizers();

      GC.Collect();
      GC.WaitForPendingFinalizers();

      return true;
    }

    private void CreateTaskPane(ISldWorks pSldWorks)
    {
      var thisAssembly = Assembly.GetAssembly(GetType());
      var bmp = new BitmapHandler();
      var icon = bmp.CreateFileFromResourceBitmap("RobotWare.SolidWorks.robot_16x18.bmp", thisAssembly);
      var view = pSldWorks.CreateTaskpaneView2(icon, @"RobotWare for SolidWorks");
      var ctrl = (ManagerCtrlX)view.AddControl(@"RobotWare.ActiveXUserControl", @"");
      var root = new RobotWareWrapper("RobotWare for SolidWorks", pSldWorks);
      var mgrCtl = new ManagerCtl(root)
                        {
                          Dock = DockStyle.Fill
                        };
      ctrl.Controls.Add(mgrCtl);
    }
  }
}
