﻿//
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
  public class EdgeLengthSelectFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Select all edges below a threshold length";
      }
    }

    public override string Description
    {
      get
      {
        return "Select all edges below a threshold length";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SpaceClaim, length,edge,  geometry";
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
        return typeof(EdgeLengthSelect);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new EdgeLengthSelect(root, callback, mgr);
    }
  }
}
