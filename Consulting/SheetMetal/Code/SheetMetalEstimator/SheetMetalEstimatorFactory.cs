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

namespace SheetMetalEstimator
{
  public class SheetMetalEstimatorFactory : Factory
  {
    public override string Title
    {
      get
      {
        return "Sheet metal estimator";
      }
    }

    public override string Description
    {
      get
      {
        return "Estimate area and cut length of a flattened sheet metal part";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SpaceClaim, sheet metal";
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

    public override bool IsLicensed
    {
      get
      {
        return true;
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(SheetMetalEstimator);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new SheetMetalEstimator(root, callback, mgr);
    }
  }
}
