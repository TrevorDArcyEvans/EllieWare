//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EngIT.SheetMetalEstimator.Properties;
using SpaceClaim.Api.V10;
using SpaceClaim.Api.V10.Extensibility;

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
      var actWind = Window.ActiveWindow;
      if (actWind == null)
      {
        command.IsEnabled = false;

        return;
      }

      var doc = actWind.Document;
      if (doc == null)
      {
        command.IsEnabled = false;

        return;
      }

      var parts = doc.Parts;
      var allFlatParts = from thisPart in parts where thisPart.FlatPattern != null select thisPart;

      command.IsEnabled = allFlatParts.SingleOrDefault() != null;
    }

    protected override void OnExecuteInternal(Command command, ExecutionContext context, Rectangle buttonRect)
    {
    }
  }
}
