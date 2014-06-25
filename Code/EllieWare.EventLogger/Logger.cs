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
using System.Security.Permissions;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.EventLogger
{
  [EventLogPermission(SecurityAction.Demand)]
  public class Logger : MutableRunnableBase<LoggerCtrl>
  {
    public Logger()
    {
    }

    public Logger(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      mControl.mSource.SetParameterManager(mgr);
      mControl.mMessage.SetParameterManager(mgr);

      // get Windows Event Log levels
      mControl.mLevel.DataSource = Enum.GetNames(typeof(EventLogEntryType)).ToList();
      mControl.mLevel.SelectedIndex = 0;
    }

    public override string Summary
    {
      get
      {
        var level = (LogLevel)mControl.mLevel.SelectedIndex;
        return string.Format("{0} : {1} : {2}", mControl.mSource.ResolvedValue, level, mControl.mMessage.ResolvedValue);
      }
    }

    public override bool Run()
    {
      // From:
      //    http://msdn.microsoft.com/en-us/library/6s7642se%28v=vs.110%29.aspx
      //
      // EventLog.SourceExists Method (String)
      //
      // Because this method accesses the registry, you must have the appropriate registry permissions on the local computer;
      // otherwise, a SecurityException will be thrown.
      //
      // Note
      //
      // To search for an event source in Windows Vista and later or Windows Server 2003, you must have administrative privileges.
      //
      // The reason for this requirement is that all event logs, including security, must be searched to determine whether the
      // event source is unique. Starting with Windows Vista, users do not have permission to access the security log;
      // therefore, a SecurityException is thrown.
      //
      // Starting with Windows Vista, User Account Control (UAC) determines the privileges of a user. If you are a member of the
      // Built-in Administrators group, you are assigned two run-time access tokens: a standard user access token and an
      // administrator access token. By default, you are in the standard user role. To execute the code that accesses performance
      // counters, you must first elevate your privileges from standard user to administrator. You can do this when you start an
      // application by right-clicking the application icon and indicating that you want to run as an administrator.
      //
      // Note
      //
      // A service that is executing under the LocalSystem account does not have the privileges required to execute this method.
      // The solution is to check whether the event source exists in the ServiceInstaller, and if it does not exist, to create
      // the source in the installer.
      if (!EventLog.SourceExists(mControl.mSource.ResolvedValue))
      {
        EventLog.CreateEventSource(mControl.mSource.ResolvedValue, "Application");
      }

      var level = (EventLogEntryType)Enum.Parse(typeof(EventLogEntryType), (string)mControl.mLevel.SelectedItem);
      EventLog.WriteEntry(mControl.mSource.ResolvedValue, mControl.mMessage.ResolvedValue, level);

      return true;
    }
  }
}
