//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Drawing;
using System.Windows.Forms;
using SpaceClaim.Api.V10;
using SpaceClaim.Api.V10.Extensibility;
using SpaceClaim.API.Test.Properties;
using Application = SpaceClaim.Api.V10.Application;

namespace SpaceClaim.API.Test
{
  public class ManagerCapsule : CommandCapsule
  {
    private Lazy<ApiTest> mTester;

    // The name must match the name specified in the ribbon bar XML.
    private const string CommandName = "EllieWare.Manager";

    public ManagerCapsule()
      : base(CommandName, Resources.ManagerText, Resources.robot, Resources.ManagerHint)
    {
      mTester = new Lazy<ApiTest>(() => new ApiTest());
    }

    protected override void OnInitialize(Command command)
    {
      // Add a keyboard shortcut for this command.
      // Show manager when Ctrl+E is pressed.
      const Keys shortcut = Keys.Control | Keys.E;
      if (Command.GetCommand(shortcut) == null) // else shortcut is already used by another command
      {
        command.Shortcuts = new[] { shortcut };
      }
    }

    protected override void OnUpdate(Command command)
    {
      // When a command is disabled, all UI components associated with the command are also disabled.
      command.IsEnabled = true;
    }

    protected override void OnExecute(Command command, ExecutionContext context, Rectangle buttonRect)
    {
      if (mTester.Value.IsDisposed)
      {
        mTester = new Lazy<ApiTest>(() => new ApiTest());
      }
      mTester.Value.Show(Application.MainWindow);
    }
  }
}
