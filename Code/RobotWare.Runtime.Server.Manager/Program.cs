//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using EllieWare.Common;
using EllieWare.Interfaces;
using RobotWare.Runtime.Server.Manager.Properties;

namespace RobotWare.Runtime.Server.Manager
{
  static class Program
  {
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool SetForegroundWindow(IntPtr hWnd);

    [STAThread]
    private static void Main()
    {
      bool createdNew;
      using (new Mutex(true, RobotWareServerWrapper.ServerApplicationName + "_" + Environment.UserName, out createdNew))
      {
        if (createdNew)
        {
          // enable these first as licensing will create UI windows
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);

          IRobotWare root = new RobotWareServerWrapper();

          if (!root.IsLicensed)
          {
            Utils.DoRequestLicense(root.ApplicationName, root.Version, Resources.robot_32x32, () => root.IsLicensed);
          }

          if (!root.IsLicensed)
          {
            return;
          }

          Application.Run(new Main(root));
        }
        else
        {
          var current = Process.GetCurrentProcess();
          var otherProc = Process.GetProcessesByName(current.ProcessName).Single(process => process.Id != current.Id);
          SetForegroundWindow(otherProc.MainWindowHandle);
        }
      }
    }
  }
}
