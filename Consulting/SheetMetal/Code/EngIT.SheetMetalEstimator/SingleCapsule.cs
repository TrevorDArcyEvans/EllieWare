//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Drawing;
using System.Windows.Forms;
using EngIT.SheetMetalEstimator.Properties;
using SpaceClaim.Api.V10;
using SpaceClaim.Api.V10.Extensibility;

namespace EngIT.SheetMetalEstimator
{
  public class SingleCapsule : CommandCapsule
  {
    // The name must match the name specified in the ribbon bar XML.
    private const string CommandName = "EngIT.Single";

    public SingleCapsule()
      : base(CommandName, Resources.SingleText, Resources.sm_estimate_current_part_32x32, Resources.SingleHint)
    {
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
      // TODO
      command.IsEnabled = true;
    }

    protected override void OnExecute(Command command, ExecutionContext context, Rectangle buttonRect)
    {
      // TODO
    }
  }
}
