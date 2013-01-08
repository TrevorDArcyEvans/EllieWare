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
  public class SetViewProjectionFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Set the current view to a predefined view";
      }
    }

    public string Description
    {
      get
      {
        return "Set the current view to a predefined view";
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
        return typeof(SetViewProjection);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new SetViewProjection(root, callback, mgr);
    }
  }
}
