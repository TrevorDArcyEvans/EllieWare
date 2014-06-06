//
//  Copyright (C) 2013 EllieWare
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
  public class EdgeLengthPercentSelectFactory: FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Select all edges below a fraction of the longest edge";
      }
    }

    public override string Description
    {
      get
      {
        return "Select all edges below a fraction of the longest edge";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SpaceClaim, length, edge, geometry";
      }
    }

    public override IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "SpaceClaim"
                     };
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(EdgeLengthPercentSelect);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new EdgeLengthPercentSelect(root, callback, mgr);
    }
  }
}
