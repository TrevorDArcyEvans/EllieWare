//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using CrashReporterDotNET;
using EllieWare.Common;
using EllieWare.Interfaces;
using Quartz.Core;
using RobotWare.Runtime.Server.Manager.Properties;

namespace RobotWare.Runtime.Server.Manager
{
  public partial class Main : Form
  {
    private readonly IRobotWare mRoot = new RobotWareServerWrapper();
    private readonly QuartzSchedulerFacade mScheduler;

    public Main()
    {
      InitializeComponent();

      // http://crashreporterdotnet.codeplex.com/documentation
      Application.ThreadException += ApplicationThreadException;

      // http://autoupdaterdotnet.codeplex.com/documentation
      const string EllieWare = @"http://www.EllieWare.com";
      var appCast = mRoot.ApplicationName.Replace(' ', '_') + ".xml";
      var appCastUrl = EllieWare + @"/" + appCast;
      AutoUpdater.Start(appCastUrl, mRoot.ApplicationName, mRoot.Version);

      try
      {
        mScheduler = new QuartzSchedulerFacade(Settings.Default.Server, Settings.Default.Port, Settings.Default.Scheduler);
        ServerConnectStatus.Text = string.Format("Connected to {0}", mScheduler.Address);
      }
      catch (SocketException ex)
      {
        var msg = string.Format("Unable to connect to scheduler {0} on {1}:{2}", Settings.Default.Scheduler, Settings.Default.Server, Settings.Default.Port);
      }
    }

    public Main(IRobotWare root) :
      this()
    {
      mRoot = root;
    }

    private void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
    {
      var reportCrash = new ReportCrash
                              {
                                ToEmail = "support@EllieWare.com"
                              };

      reportCrash.Send(e.Exception);
    }

    //jobsToolStripMenuItem.Enabled = true;
    //loadJobGroups(scheduler);
    //updateRunningJobs();
  }
}
