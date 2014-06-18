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
using System.Net.Sockets;
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

          try
          {
            Application.Run(new Main(root));
          }
          catch (SocketException)
          {
            var msg = string.Format("Unable to connect to scheduler {0} on {1}:{2}", Settings.Default.Scheduler, Settings.Default.Server, Settings.Default.Port);
            MessageBox.Show(msg, root.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
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
