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
  public class SheetMetalEstimatorFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Sheet metal estimator";
      }
    }

    public string Description
    {
      get
      {
        return "Estimate area and cut length of a flattened sheet metal part";
      }
    }

    public string Keywords
    {
      get
      {
        return "SpaceClaim, sheet metal";
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

    public bool IsLicensed
    {
      get
      {
        return true;
      }
    }

    public Type CreatedType
    {
      get
      {
        return typeof(SheetMetalEstimator);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new SheetMetalEstimator(root, callback, mgr);
    }
  }
}
