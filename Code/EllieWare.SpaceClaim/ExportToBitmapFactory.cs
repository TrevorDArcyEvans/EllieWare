//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.SpaceClaim
{
  public class ExportToBitmapFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Export current view to a bitmap file";
      }
    }

    public override string Description
    {
      get
      {
        return "Export current view to a bitmap file.  Default is png (Portable Network Graphic).";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SpaceClaim, IO, bitmap, png, bmp, gif, tiff";
      }
    }

    public override IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "SpaceClaim",
                       "Bitmap", 
                       "IO"
                     };
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(ExportToBitmap);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new ExportToBitmap(root, callback, mgr);
    }
  }
}
