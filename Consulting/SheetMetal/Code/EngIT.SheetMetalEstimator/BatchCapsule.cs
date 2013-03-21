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
  public class BatchCapsule : CommandCapsule
  {
    // The name must match the name specified in the ribbon bar XML.
    private const string CommandName = "EngIT.Batch";

    public BatchCapsule()
      : base(CommandName, Resources.BatchText, Resources.sm_estimate_folder_32x32, Resources.BatchHint)
    {
    }

    protected override void OnInitialize(Command command)
    {
      // Add a keyboard shortcut for this command.
      // Show manager when Ctrl+B is pressed.
      const Keys shortcut = Keys.Control | Keys.B;
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
