//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using EllieWare.Common;
using EllieWare.Interfaces;
using RobotWare.Runtime.SpaceClaim.Commands;
using SpaceClaim.Api.V10;
using SpaceClaim.Api.V10.Extensibility;

namespace RobotWare.Runtime.SpaceClaim
{
  public class RuntimeAddin : AddIn, IExtensibility, ICommandExtensibility, IRibbonExtensibility
  {
    private const string ApplicationName = "RobotWare Runtime for SpaceClaim";

    private readonly IRobotWare mRoot = new RobotWareWrapper(ApplicationName);
    private readonly LogWindow mCallback = new LogWindow();

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
      var cfgXmlFilePath = Path.Combine(execAssyDir, "Commands.xml");
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
      var uiXmlFilePath = Path.Combine(execAssyDir, "Ribbon.xml");
      var uiXml = File.ReadAllText(uiXmlFilePath);

      return uiXml;
    }

    #endregion
  }
}
