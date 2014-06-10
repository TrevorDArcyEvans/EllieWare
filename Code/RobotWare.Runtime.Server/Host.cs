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
using System.Threading;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using CrashReporterDotNET;
using EllieWare.Interfaces;
using Quartz;
using RobotWare.Quartz.Extensions;

namespace RobotWare.Runtime.Server
{
  public class Host : ICallback, IJobInfo
  {
    public const string MacroFilePathKey = "MacroFilePath";

    private static readonly Common.Logging.ILog Logger = Common.Logging.LogManager.GetLogger(typeof(Host));

    private readonly IRobotWare mRoot = new RobotWareServerWrapper();

    public Host()
    {
      // http://crashreporterdotnet.codeplex.com/documentation
      Application.ThreadException += ApplicationThreadException;

      // http://autoupdaterdotnet.codeplex.com/documentation
      const string EllieWare = @"http://www.EllieWare.com";
      var appCast = mRoot.ApplicationName.Replace(' ', '_') + ".xml";
      var appCastUrl = EllieWare + @"/" + appCast;
      AutoUpdater.Start(appCastUrl, mRoot.ApplicationName, mRoot.Version);
    }

    private void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
    {
      var reportCrash = new ReportCrash
                              {
                                ToEmail = "support@EllieWare.com"
                              };

      reportCrash.Send(e.Exception);
    }

    public void Log(LogLevel level, string message)
    {
      // map RobotWare levels to Quartz.NET levels
      switch (level)
      {
        case LogLevel.Debug:
          Logger.Debug(message);
          break;

        case LogLevel.Information:
          Logger.Info(message);
          break;

        case LogLevel.Warning:
          Logger.Warn(message);
          break;

        case LogLevel.Severe:
          Logger.Error(message);
          break;

        case LogLevel.Critical:
          Logger.Fatal(message);
          break;

        default:
          throw new ArgumentOutOfRangeException("Unknown enum value:" + level);
      }
    }

    public bool Run(string macroFilePath)
    {
      var engine = new Engine(mRoot, this, macroFilePath);

      var bRet = engine.Run();
      Logger.Trace(string.Format("{0} finished {1} : {2}", mRoot.ApplicationName, macroFilePath, bRet ? "Succeeded" : "Failed"));

      return bRet;
    }

    public void Execute(IJobExecutionContext context)
    {
     if (!mRoot.IsLicensed)
      {
        Logger.Fatal(string.Format("{0} is not licensed", mRoot.ApplicationName));
        return;
      }

      // From:
      //    http://www.quartz-scheduler.net/documentation/quartz-2.x/tutorial/more-about-jobs.html
      //
      // Finally, we need to inform you of a few details of the IJob.Execute(..) method. The only type of exception
      // that you should throw from the execute method is the JobExecutionException. Because of this, you should
      // generally wrap the entire contents of the execute method with a 'try-catch' block. You should also spend
      // some time looking at the documentation for the JobExecutionException, as your job can use it to provide
      // the scheduler various directives as to how you want the exception to be handled.
      try
      {
        var macroFilePath = context.MergedJobDataMap.GetString(MacroFilePathKey);
        var assy = Assembly.GetExecutingAssembly();
        var assyPath = assy.Location;
        var proc = Process.Start(assyPath, "\"" + macroFilePath + "\"");

        proc.WaitForExit();
        var retVal = proc.ExitCode;
      }
      catch (Exception ex)
      {
        throw new JobExecutionException(ex);
      }
    }

    public IEnumerable<IJobDataInfo> JobDataInfos
    {
      get
      {
        return new[]
                {
                  new JobDataInfo(MacroFilePathKey, typeof (string), typeof (FileInfo), "")
                };
      }
    }
  }
}
