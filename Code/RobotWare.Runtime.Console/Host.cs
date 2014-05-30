//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.IO;
using System.Reflection;
using EllieWare.Common;
using EllieWare.Interfaces;
using RobotWare.Runtime.Console.Properties;
using FileExtensions = EllieWare.Interfaces.FileExtensions;

namespace RobotWare.Runtime.Console
{
  public class Host : ICallback
  {
    private const string ApplicationName = "RobotWare Runtime for Console";

    private static readonly Common.Logging.ILog mLogger = Common.Logging.LogManager.GetLogger(typeof(Host));

    static int Main(string[] args)
    {
      return new Host().Run(args) ? 1 : 0;
    }

    private bool Run(string[] args)
    {
      IRobotWare root = new RobotWareWrapper(ApplicationName);

      if (!root.IsLicensed)
      {
        Utils.DoRequestLicense(root.ApplicationName, root.Version, Resources.robot_32x32, () => root.IsLicensed);
      }

      if (!root.IsLicensed)
      {
        return false;
      }

      if (args.Length != 1)
      {
        PrintUsage();

        return false;
      }

      // run macro file specified on command line
      var eng = new Engine(root, this, args[0]);

      return eng.Run();
    }

    private void PrintUsage()
    {
      var assy = Assembly.GetExecutingAssembly();
      var assyFileName = Path.GetFileName(assy.Location);

      System.Console.WriteLine("Usage:");
      System.Console.WriteLine("  {0} [path to macro file (*{1})]", assyFileName, FileExtensions.MacroFileExtension);
      System.Console.WriteLine("");
      System.Console.WriteLine("Returns:");
      System.Console.WriteLine("  1 success");
      System.Console.WriteLine("  0 failure");
      System.Console.ReadKey();
    }

    public void Log(LogLevel level, string message)
    {
      // map RobotWare levels to Quartz.NET levels
      switch (level)
      {
        case LogLevel.Debug:
          mLogger.Debug(message);
          break;

        case LogLevel.Information:
          mLogger.Info(message);
          break;

        case LogLevel.Warning:
          mLogger.Warn(message);
          break;

        case LogLevel.Severe:
          mLogger.Error(message);
          break;

        case LogLevel.Critical:
          mLogger.Fatal(message);
          break;

        default:
          throw new ArgumentOutOfRangeException("Unknown enum value:" + level.ToString());
      }
    }
  }
}
