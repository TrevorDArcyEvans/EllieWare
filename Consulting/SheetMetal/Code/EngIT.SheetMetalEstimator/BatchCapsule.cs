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
  public class BatchCapsule : BaseCapsule
  {
    // The name must match the name specified in the ribbon bar XML.
    private const string CommandName = "EngIT.Batch";

    public BatchCapsule()
      : base(CommandName, Resources.BatchText, Resources.sm_estimate_folder_32x32, Resources.BatchHint)
    {
    }

    protected override void OnUpdate(Command command)
    {
      command.IsEnabled = true;
    }

    protected override void OnExecuteInternal(Command command, ExecutionContext context, Rectangle buttonRect)
    {
      // TODO prompt for folder
    }
  }
}
