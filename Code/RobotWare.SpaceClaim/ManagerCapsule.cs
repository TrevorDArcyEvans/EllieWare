//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using EllieWare.Manager;
using RobotWare.SpaceClaim.Properties;
using SpaceClaim.Api.V10;
using SpaceClaim.Api.V10.Extensibility;
using Application = SpaceClaim.Api.V10.Application;

namespace RobotWare.SpaceClaim
{
  public class ManagerCapsule : CommandCapsule
  {
    // The name must match the name specified in the ribbon bar XML.
    private const string CommandName = "RobotWare.Manager";

    private const string ApplicationName = "RobotWare for SpaceClaim";

    private readonly string mUserSpecsPath;
    private Lazy<Manager> mManager;

    public ManagerCapsule()
      : base(CommandName, Resources.ManagerText, Resources.robot, Resources.ManagerHint)
    {

      var userDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
      mUserSpecsPath = Path.Combine(userDocs, ApplicationName);
      Directory.CreateDirectory(mUserSpecsPath);

      mManager = new Lazy<Manager>(() => new Manager(null, ApplicationName, mUserSpecsPath));
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
    }

    protected override void OnUpdate(Command command)
    {
      // When a command is disabled, all UI components associated with the command are also disabled.
      command.IsEnabled = Window.ActiveWindow != null;
    }

    protected override void OnExecute(Command command, ExecutionContext context, Rectangle buttonRect)
    {
      if (mManager.Value.IsDisposed)
      {
        mManager = new Lazy<Manager>(() => new Manager(null, ApplicationName, mUserSpecsPath));
      }
      mManager.Value.Show(Application.MainWindow);
    }
  }
}
