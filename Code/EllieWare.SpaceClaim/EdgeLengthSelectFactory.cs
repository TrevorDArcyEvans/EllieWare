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
  public class EdgeLengthSelectFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Select all edges below a threshold length";
      }
    }

    public string Description
    {
      get
      {
        return "Select all edges below a threshold length";
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
        return typeof(EdgeLengthSelect);
      }
    }

    public IRunnable Create(IEnumerable<object> roots, ICallback callback, IParameterManager mgr)
    {
      return new EdgeLengthSelect(roots, callback, mgr);
    }
  }
}
