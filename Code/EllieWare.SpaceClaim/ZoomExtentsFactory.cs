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
  public class ZoomExtentsFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Zoom the current view to the extents of the model";
      }
    }

    public string Description
    {
      get
      {
        return "Zoom the current view to the extents of the model";
      }
    }

    public string Keywords
    {
      get
      {
        return "SpaceClaim, view, zoom, extents";
      }
    }

    public IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "SpaceClaim",
                       "View"
                     };
      }
    }

    public Type CreatedType
    {
      get
      {
        return typeof(ZoomExtents);
      }
    }

    public IRunnable Create(object root, ICallback callback, IParameterManager mgr)
    {
      return new ZoomExtents(root, callback, mgr);
    }
  }
}
