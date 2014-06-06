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
  public class SetViewProjectionFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Set the current view to a predefined view";
      }
    }

    public override string Description
    {
      get
      {
        return "Set the current view to a predefined view";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SpaceClaim, view, zoom, extents";
      }
    }

    public override IEnumerable<string> Categories
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

    public override Type CreatedType
    {
      get
      {
        return typeof(SetViewProjection);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new SetViewProjection(root, callback, mgr);
    }
  }
}
