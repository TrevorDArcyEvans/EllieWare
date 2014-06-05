//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using CrashReporterDotNET;
using EllieWare.Common;
using EllieWare.Interfaces;
using RobotWare.Runtime.Windows.Properties;
using FileExtensions = EllieWare.Interfaces.FileExtensions;

namespace RobotWare.Runtime.Windows
{
  public sealed partial class Host : Form
  {
    private const string ApplicationName = "RobotWare Runtime for Windows";

    private readonly IRobotWare mRoot = new RobotWareWrapper(ApplicationName);
    private readonly Engine mEngine;
    private readonly string mMacroFilePath;

    public Host()
    {
      InitializeComponent();

      Text = ApplicationName;

      if (!mRoot.IsLicensed)
      {
        Utils.DoRequestLicense(mRoot.ApplicationName, mRoot.Version, Resources.robot_32x32, () => mRoot.IsLicensed);
      }

      if (mRoot.IsLicensed)
      {
        CmdRun.Enabled = true;

        // check for one macro file
        var assy = Assembly.GetExecutingAssembly();
        var assyDir = Path.GetDirectoryName(assy.Location);
        Debug.Assert(assyDir != null);
        mMacroFilePath = Directory.EnumerateFiles(assyDir, "*" + FileExtensions.MacroFileExtension).FirstOrDefault();
        if (!string.IsNullOrWhiteSpace(mMacroFilePath))
        {
          mEngine = new Engine(mRoot, mLogWindow, mMacroFilePath);
        }
      }

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

    private void Host_Load(object sender, EventArgs e)
    {
      if (mEngine == null)
      {
        var msg = string.Format("Could not find a macro file (*{0}) to run.", FileExtensions.MacroFileExtension);
        MessageBox.Show(msg, mRoot.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

        Close();
        return;
      }

      CmdRun_Click(this, new EventArgs());
    }

    private void CmdRun_Click(object sender, EventArgs e)
    {
      mLogWindow.Log(LogLevel.Information, string.Format("Starting {0}", mMacroFilePath));
      var bRet = mEngine.Run();
      mLogWindow.Log(LogLevel.Information, string.Format(bRet ? "Succeeded" : "Failed"));
    }
  }
}
