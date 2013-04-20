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
using RobotWare.Runtime.SpaceClaim.Properties;
using SpaceClaim.Api.V10;
using SpaceClaim.Api.V10.Extensibility;

namespace RobotWare.Runtime.SpaceClaim
{
  public class RuntimeAddin : AddIn, IExtensibility, ICommandExtensibility, IRibbonExtensibility
  {
    private const string ApplicationName = "RobotWare Runtime for SpaceClaim";

    private readonly IRobotWare mRoot = new RobotWareWrapper(ApplicationName);
    private readonly LogWindow mCallback = new LogWindow();

    private readonly List<CommandCapsule> mCapsules = new List<CommandCapsule>
                                                             {
                                                               new CommandCapsule("RobotWare.Runtime.RibbonTab", Resources.RibbonTabText),
                                                               new CommandCapsule("RobotWare.Runtime.ManagerGroup", Resources.ManagerGroupText)
                                                             };

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
      // create LogWindow and add it to Structure panel
      var cmd = Command.Create("RobotWare.Runtime.SpaceClaim");
      cmd.Image = Resources.robot;
      cmd.Text = Resources.RibbonTabText;
      cmd.IsVisible = true;

      var rtTab = PanelTab.Create(cmd, mCallback, Panel.Structure);

      // load Commands.xml from disk
      var execAssy = Assembly.GetExecutingAssembly();
      var execAssyDir = Path.GetDirectoryName(execAssy.Location);
      var cmdsXmlFilePath = Path.Combine(execAssyDir, "Commands.xml");
      var cmds = RuntimeConfig.LoadFromFile(cmdsXmlFilePath);

      // create TemplateCapsule/s and add to list
      foreach (var thisCmd in cmds.CommandConfigs)
      {
        // load icon which should be next to dll
        var imgFilePath = Path.Combine(execAssyDir, thisCmd.Image);
        var img = System.Drawing.Image.FromFile(imgFilePath);
        var newCmd = new TemplateCapsule(thisCmd.Name, thisCmd.Text, img, thisCmd.Hint, mRoot, mCallback, thisCmd.SpecFilePath);

        mCapsules.Add(newCmd);
      }

      foreach (var commandCapsule in mCapsules)
      {
        commandCapsule.Initialize();
      }
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
