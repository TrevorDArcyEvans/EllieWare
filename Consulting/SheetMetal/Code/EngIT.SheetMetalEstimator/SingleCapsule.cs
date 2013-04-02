//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Drawing;
using EngIT.SheetMetalEstimator.Properties;
using SpaceClaim.Api.V10;

namespace EngIT.SheetMetalEstimator
{
  public class SingleCapsule : BaseCapsule
  {
    // The name must match the name specified in the ribbon bar XML.
    private const string CommandName = "EngIT.Single";

    public SingleCapsule()
      : base(CommandName, Resources.SingleText, Resources.sm_estimate_current_part_32x32, Resources.SingleHint)
    {
    }

    protected override void OnUpdate(Command command)
    {
      if (Window.ActiveWindow == null)
      {
        command.IsEnabled = false;

        return;
      }

      var doc = Window.ActiveWindow.Document;

      command.IsEnabled = IsSheetMetalPart(doc) && HasFlatPattern(doc);
    }

    protected override bool OnExecuteInternal(Command command, ExecutionContext context, Rectangle buttonRect)
    {
      Calculate(Window.ActiveWindow.Document);

      return true;
    }
  }
}
