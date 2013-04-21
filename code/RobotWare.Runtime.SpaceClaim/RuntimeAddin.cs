//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using AutoUpdaterDotNET;
using CrashReporterDotNET;
using EllieWare.Common;
using EllieWare.Interfaces;
using RobotWare.Runtime.SpaceClaim.Commands;
using RobotWare.Runtime.SpaceClaim.Properties;
using SpaceClaim.Api.V10;
using SpaceClaim.Api.V10.Extensibility;

namespace RobotWare.Runtime.SpaceClaim
{
  public class RuntimeAddin : AddIn, IExtensibility, ICommandExtensibility, IRibbonExtensibility
  {
    public const string ApplicationName = "RobotWare Runtime for SpaceClaim";
    public const string RuntimeConfigFileName = "Commands.xml";
    public const string CustomUIFileName = "Ribbon.xml";

    private readonly IRobotWare mRoot = new RobotWareWrapper(ApplicationName);
    private readonly LogWindow mCallback = new LogWindow();

    public RuntimeAddin()
    {
      if (!mRoot.IsLicensed)
      {
        Utils.DoRequestLicense(mRoot.ApplicationName, mRoot.Version, Resources.robot_32x32, () => mRoot.IsLicensed);
      }

      // http://crashreporterdotnet.codeplex.com/documentation
      System.Windows.Forms.Application.ThreadException += ApplicationThreadException;

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

    #region Implementation of IExtensibility

    public bool Connect()
    {
      return true;
    }

    public void Disconnect()
    {
    }

    #endregion

    #region Implementation of ICommandExtensibility

    public void Initialize()
    {
      // load Commands.xml from disk
      var execAssy = Assembly.GetExecutingAssembly();
      var execAssyDir = Path.GetDirectoryName(execAssy.Location);
      var cfgXmlFilePath = Path.Combine(execAssyDir, RuntimeConfigFileName);
      var cfg = RuntimeConfig.LoadFromFile(cfgXmlFilePath);
      var capsules = new List<CommandCapsule>
                              {
                                new CommandCapsule("RobotWare.Runtime.RibbonTab", cfg.RibbonText),
                                new CommandCapsule("RobotWare.Runtime.ManagerGroup", cfg.TabText)
                              };

      // create TemplateCapsule/s and add to list
      foreach (var thisCmd in cfg.CommandConfigs)
      {
        // load icon which should be next to dll
        var imgFilePath = Path.Combine(execAssyDir, thisCmd.Image);
        var img = System.Drawing.Image.FromFile(imgFilePath);
        var newCmd = new TemplateCapsule(thisCmd.Name, thisCmd.Text, img, thisCmd.Hint, mRoot, mCallback, thisCmd.SpecFileName);

        capsules.Add(newCmd);
      }

      foreach (var commandCapsule in capsules)
      {
        commandCapsule.Initialize();
      }

      // load panel icon which should be next to dll
      var icoFilePath = Path.Combine(execAssyDir, cfg.PanelIcon);
      var ico = System.Drawing.Image.FromFile(icoFilePath);

      // create LogWindow and add it to Structure panel
      var cmd = Command.Create("RobotWare.Runtime.SpaceClaim");
      cmd.Image = ico;
      cmd.Text = cfg.PanelText;
      cmd.IsVisible = true;

      var rtTab = PanelTab.Create(cmd, mCallback, Panel.Structure);
    }

    #endregion

    #region Implementation of IRibbonExtensibility

    public string GetCustomUI()
    {
      // load Ribbon.xml from disk
      var execAssy = Assembly.GetExecutingAssembly();
      var execAssyDir = Path.GetDirectoryName(execAssy.Location);
      var uiXmlFilePath = Path.Combine(execAssyDir, CustomUIFileName);
      var uiXml = File.ReadAllText(uiXmlFilePath);

      return uiXml;
    }

    #endregion
  }
}
