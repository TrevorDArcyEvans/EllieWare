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
using EllieWare.Common;
using EllieWare.Interfaces;
using EllieWare.Manager;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using SolidWorks.Interop.swpublished;

namespace RobotWare.SolidWorks
{
  [Guid("3996542B-D2C9-4647-9FF9-AE03955E9D48")]
  [ComVisible(true)]
  [SwAddin("Automation made easy", "RobotWare for SolidWorks", true)]
  public class RobotWareAddin : ISwAddin
  {
    public const int MainCmdGroupID = 23;

    private ISldWorks mSwApp;
    private ICommandManager mCmdMgr;
    private IRobotWare mRobotWare;
    private readonly Lazy<Manager> mManager;
    private readonly BitmapHandler mBitmap = new BitmapHandler();

    private readonly IDictionary<string, Assembly> mAdditionalAssys = new Dictionary<string, Assembly>();

    public RobotWareAddin()
    {
      mManager = new Lazy<Manager>(() => new Manager(mRobotWare));

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

      // running inside SW app domain which has BaseDirectory of SW install directory
      // so we have to use assys from our directory
      AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
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
        Console.WriteLine(e.Message);
        System.Windows.Forms.MessageBox.Show("There was a problem registering this addin: \"" + System.Environment.NewLine + e.Message + "\"");
      }
    }

    [ComUnregisterFunctionAttribute]
    public static void UnregisterFunction(Type t)
    {
      try
      {
        var hklm = Microsoft.Win32.Registry.LocalMachine;
        var hkcu = Microsoft.Win32.Registry.CurrentUser;

        string keyname = "SOFTWARE\\SolidWorks\\Addins\\{" + t.GUID + "}";
        hklm.DeleteSubKey(keyname);

        keyname = "Software\\SolidWorks\\AddInsStartup\\{" + t.GUID + "}";
        hkcu.DeleteSubKey(keyname);
      }
      catch (Exception e)
      {
        Console.WriteLine("There was a problem unregistering this dll: " + e.Message);
        System.Windows.Forms.MessageBox.Show("There was a problem unregistering this DLL: \"" + System.Environment.NewLine + e.Message + "\"");
      }
    }

    #endregion

    public bool ConnectToSW(object thisSW, int cookie)
    {
      mSwApp = (ISldWorks)thisSW;

      // setup callbacks
      mSwApp.SetAddinCallbackInfo(0, this, cookie);

      mCmdMgr = mSwApp.GetCommandManager(cookie);
      AddCommandManager();

      mRobotWare = new RobotWareWrapper("RobotWare for SolidWorks", mSwApp);

      return true;
    }

    public bool DisconnectFromSW()
    {
      mBitmap.Dispose();

      RemoveCommandMgr();

      Marshal.ReleaseComObject(mCmdMgr);
      mCmdMgr = null;
      Marshal.ReleaseComObject(mSwApp);
      mSwApp = null;

      //The addin _must_ call GC.Collect() here in order to retrieve all managed code pointers 
      GC.Collect();
      GC.WaitForPendingFinalizers();

      GC.Collect();
      GC.WaitForPendingFinalizers();

      return true;
    }

    private void AddCommandManager()
    {
      const string Title = "RobotWare";
      const string ToolTip = "Show RobotWare manager";
      const string Hint = "Manage RobotWare macros";

      const int MainItemID1 = 0;

      var docTypes = new[] 
                      {
                        (int)swDocumentTypes_e.swDocNONE,
                        (int)swDocumentTypes_e.swDocASSEMBLY,
                        (int)swDocumentTypes_e.swDocDRAWING,
                        (int)swDocumentTypes_e.swDocPART
                      };

      var thisAssembly = Assembly.GetAssembly(GetType());
      var cmdGroup = mCmdMgr.CreateCommandGroup(MainCmdGroupID, Title, ToolTip, Hint, -1);
      cmdGroup.LargeIconList = mBitmap.CreateFileFromResourceBitmap("RobotWare.SolidWorks.ToolbarLarge.bmp", thisAssembly);
      cmdGroup.SmallIconList = mBitmap.CreateFileFromResourceBitmap("RobotWare.SolidWorks.ToolbarSmall.bmp", thisAssembly);
      cmdGroup.LargeMainIcon = mBitmap.CreateFileFromResourceBitmap("RobotWare.SolidWorks.MainIconLarge.bmp", thisAssembly);
      cmdGroup.SmallMainIcon = mBitmap.CreateFileFromResourceBitmap("RobotWare.SolidWorks.MainIconSmall.bmp", thisAssembly);

      var menuToolbarOption = (int)(swCommandItemType_e.swMenuItem | swCommandItemType_e.swToolbarItem);
      var cmdIndex0 = cmdGroup.AddCommandItem2("RobotWare manager...", -1, "Manage RobotWare macros", "Show RobotWare manager", 0, "ShowRobotWareManager", "", MainItemID1, menuToolbarOption);

      cmdGroup.HasToolbar = true;
      cmdGroup.HasMenu = true;
      cmdGroup.Activate();
    }

    public void RemoveCommandMgr()
    {
      mCmdMgr.RemoveCommandGroup(MainCmdGroupID);
    }

    public void ShowRobotWareManager()
    {
      mManager.Value.ShowDialog();
    }
  }
}
