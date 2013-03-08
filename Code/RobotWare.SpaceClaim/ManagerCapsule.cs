//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.IO;
using System.Windows.Forms;
using EllieWare.Common;
using EllieWare.Manager;
using RobotWare.SpaceClaim.Properties;
using SpaceClaim.Api.V10;
using SpaceClaim.Api.V10.Extensibility;
using Panel = SpaceClaim.Api.V10.Panel;

namespace RobotWare.SpaceClaim
{
  public class ManagerCapsule : CommandCapsule
  {
    private const string CommandName = "RobotWare.Manager";

    private const string ApplicationName = "RobotWare for SpaceClaim";

    private readonly RobotWareWrapper mLicenseWrapper = new RobotWareWrapper(ApplicationName);

    public ManagerCapsule()
      : base(CommandName, Resources.ManagerText, Resources.robot, Resources.ManagerHint)
    {
      Directory.CreateDirectory(mLicenseWrapper.UserSpecificationFolder);
    }

    protected override void OnInitialize(Command command)
    {
      // Add a keyboard shortcut for this command.
      // Show manager when Ctrl+M is pressed.
      const Keys shortcut = Keys.Control | Keys.M;
      if (Command.GetCommand(shortcut) == null) // else shortcut is already used by another command
      {
        command.Shortcuts = new[] { shortcut };
      }

      var cmd = Command.Create("EllieWare.RobotWare.SpaceClaim");
      cmd.Image = Resources.robot;
      cmd.Text = Resources.ManagerText;
      cmd.IsVisible = true;

      var mgrCtl = new ManagerCtl(mLicenseWrapper);
      var mgrTab = PanelTab.Create(cmd, mgrCtl, Panel.Structure);
    }

    protected override void OnUpdate(Command command)
    {
      // When a command is disabled, all UI components associated with the command are also disabled.
      command.IsEnabled = true;
    }
  }
}
