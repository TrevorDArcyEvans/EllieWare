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
  public class FaceCurvatureRemoveFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Remove all faces below a threshold curvature";
      }
    }

    public override string Description
    {
      get
      {
        return "Remove all faces below a threshold curvature";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SpaceClaim, area, geometry";
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
        return typeof(FaceCurvatureRemove);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new FaceCurvatureRemove(root, callback, mgr);
    }
  }
}
