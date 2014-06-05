//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using Microsoft.Win32;

namespace RobotWare.Runtime.Server.Manager
{
  public class RegistryStore
  {
    public static List<ConnectionInfo> GetLastConnections()
    {
      var lastConnections = new List<ConnectionInfo>();

      var managerKey = Registry.CurrentUser.CreateSubKey("RobotRuntimeServerManager");
      if (managerKey == null)
      {
        return lastConnections;
      }

      var key = managerKey.CreateSubKey("MRUList");

      if (key == null)
      {
        return lastConnections;
      }
      //TODO: show more than one server in dropdown
      for (var i = 0; i < 1; i++)
      {
        ConnectionInfo info = ConnectionInfo.Parse((key.GetValue(string.Format("connection{0}", i), null) as string));
        if (info != null)
        {
          lastConnections.Add(info);
        }
      }

      key.Close();
      managerKey.Close();

      return lastConnections;
    }

    public static void AddConnection(ConnectionInfo info)
    {
      var managerKey = Registry.CurrentUser.CreateSubKey("RobotRuntimeServerManager");
      if (managerKey == null)
      {
        return;
      }

      var key = managerKey.CreateSubKey("MRUList");

      if (key == null)
      {
        return;
      }
      //TODO: check that the key doesn't exist before trying to add. if it exists, move it to the top, but don't add it

      //for (int i = 4; i > 0; i--)
      //{
      //    var previous = key.GetValue(string.Format("connection{0}", i - 1), null);
      //    if (previous != null)
      //    {
      //        key.SetValue(string.Format("connection{0}", i), previous);

      //    }
      //}
      key.SetValue("connection0", info, RegistryValueKind.String);
    }
  }
}
