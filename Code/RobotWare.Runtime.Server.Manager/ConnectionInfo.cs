//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;

namespace RobotWare.Runtime.Server.Manager
{
  public class ConnectionInfo
  {
    public ConnectionInfo(string serverName, int port, string schedName)
    {
      ServerName = serverName;
      Port = port;
      SchedulerName = schedName;
    }

    public static ConnectionInfo Parse(string connectionString)
    {
      if (connectionString == null)
      {
        return null;
      }
      var parameters = connectionString.Split(new string[] { "|" }, StringSplitOptions.None);

      return parameters.Length != 3 ? null : new ConnectionInfo(parameters[0], int.Parse(parameters[1]), parameters[2]);
    }

    public string ServerName { get; private set; }

    public int Port { get; private set; }

    public string SchedulerName { get; private set; }

    public override string ToString()
    {
      return string.Format("{0}|{1}|{2}", ServerName, Port, SchedulerName);
    }
  }
}
