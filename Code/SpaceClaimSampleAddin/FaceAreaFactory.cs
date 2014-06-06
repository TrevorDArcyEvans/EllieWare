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

namespace SpaceClaimSampleAddin
{
  public class FaceAreaFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Calculate the area of holes on a face";
      }
    }

    public string Description
    {
      get
      {
        return "Calculate the area of holes on a single selected planar face and display them in a message box";
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
        return typeof(FaceArea);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new FaceArea(root, callback, mgr);
    }
  }
}
