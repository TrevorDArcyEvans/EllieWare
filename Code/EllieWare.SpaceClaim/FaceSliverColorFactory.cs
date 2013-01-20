//
//  Copyright (C) 2013 EllieWare
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
  public class FaceSliverColorFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Color all faces above a threshold aspect ratio";
      }
    }

    public string Description
    {
      get
      {
        return "Color all faces above a threshold aspect ratio";
      }
    }

    public string Keywords
    {
      get
      {
        return "SpaceClaim, area, perimeter, geometry";
      }
    }

    public IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "SpaceClaim"
                     };
      }
    }

    public Type CreatedType
    {
      get
      {
        return typeof(FaceSliverColor);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new FaceSliverColor(root, callback, mgr);
    }
  }
}
