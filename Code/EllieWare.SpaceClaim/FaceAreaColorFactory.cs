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
  class FaceAreaColorFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Color all faces below a threshold area";
      }
    }

    public string Description
    {
      get
      {
        return "Color all faces below a threshold area";
      }
    }

    public string Keywords
    {
      get
      {
        return "SpaceClaim, area, geometry";
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
        return typeof(FaceAreaColor);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new FaceAreaColor(root, callback, mgr);
    }
  }
}
