//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using EllieWare.Interfaces;

namespace EllieWare.SpaceClaim
{
  class ExportToBitmapFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Export current view to a bitmap file";
      }
    }

    public string Description
    {
      get
      {
        return "Export current view to a bitmap file.  Default is png (Portable Network Graphic).";
      }
    }

    public string Keywords
    {
      get
      {
        return "SpaceClaim, IO, bitmap, png, bmp, gif, tiff";
      }
    }

    public IEnumerable<string> Categories
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

    public Type CreatedType
    {
      get
      {
        return typeof(ExportToBitmap);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new ExportToBitmap(root, callback, mgr);
    }
  }
}
