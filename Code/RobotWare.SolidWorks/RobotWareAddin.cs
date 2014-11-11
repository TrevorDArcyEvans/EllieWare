//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swpublished;

namespace RobotWare.SolidWorks
{
  [Guid("3996542B-D2C9-4647-9FF9-AE03955E9D48")]
  [ComVisible(true)]
  [SwAddin("Automation made easy", "RobotWare for SolidWorks", true)]
  public class RobotWareAddin : ISwAddin
  {
    ISldWorks mSwApp;
    ICommandManager mCmdMgr;

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
        System.Windows.Forms.MessageBox.Show("There was a problem registering this addin: \""+ System.Environment.NewLine + e.Message + "\"");
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

      return true;
    }

    public bool DisconnectFromSW()
    {
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
  }
}
