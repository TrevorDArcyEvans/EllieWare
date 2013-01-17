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
  public class FaceAreaPercentRemoveFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Remove all faces below a fraction of the largest face";
      }
    }

    public string Description
    {
      get
      {
        return "Remove all faces below a fraction of the largest face";
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
        return typeof(FaceAreaPercentRemove);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new FaceAreaPercentRemove(root, callback, mgr);
    }
  }
}
