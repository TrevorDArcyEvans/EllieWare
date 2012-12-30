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
  public class ZoomSelectionFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Zoom the current view to the selection";
      }
    }

    public string Description
    {
      get
      {
        return "Zoom the current view to the selection";
      }
    }

    public string Keywords
    {
      get
      {
        return "SpaceClaim, view, zoom, selection";
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
        return typeof(ZoomSelection);
      }
    }

    public IRunnable Create(IEnumerable<object> roots, ICallback callback, IParameterManager mgr)
    {
      return new ZoomSelection(roots, callback, mgr);
    }
  }
}
