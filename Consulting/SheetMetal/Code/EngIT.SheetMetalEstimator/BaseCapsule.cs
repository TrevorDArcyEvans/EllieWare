//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using EngIT.SheetMetalEstimator.Properties;
using SpaceClaim.Api.V10;
using SpaceClaim.Api.V10.Extensibility;
using Image = System.Drawing.Image;

namespace EngIT.SheetMetalEstimator
{
  public abstract class BaseCapsule : CommandCapsule
  {
    protected BaseCapsule(string cmdName, string text, Image img, string hint)
      : base(cmdName, text, img, hint)
    {
    }

    protected abstract void OnExecuteInternal(Command command, ExecutionContext context, Rectangle buttonRect);

    protected override void OnExecute(Command command, ExecutionContext context, Rectangle buttonRect)
    {
      // TODO prompt for Excel file

      OnExecuteInternal(command, context, buttonRect);
    }
  }
}
