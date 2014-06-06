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
  public class DifferenceFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Compare two designs and put the differences into a new design";
      }
    }

    public override string Description
    {
      get
      {
        return "Compare two designs and put the differences into a new design";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SpaceClaim, difference, geometry";
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
        return typeof(Difference);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new Difference(root, callback, mgr);
    }
  
  }
}
