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
  public class EdgeLengthPercentSelectFactory: IFactory
  {
    public string Title
    {
      get
      {
        return "Select all edges below a fraction of the longest edge";
      }
    }

    public string Description
    {
      get
      {
        return "Select all edges below a fraction of the longest edge";
      }
    }

    public string Keywords
    {
      get
      {
        return "SpaceClaim, length, edge, geometry";
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
        return typeof(EdgeLengthPercentSelect);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new EdgeLengthPercentSelect(root, callback, mgr);
    }
  }
}
