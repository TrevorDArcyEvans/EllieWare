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
  public class FaceSliverSelectFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Select all faces below a threshold aspect ratio";
      }
    }

    public override string Description
    {
      get
      {
        return "Select all faces below a threshold aspect ratio";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SpaceClaim, area, perimeter, geometry";
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
        return typeof(FaceSliverSelect);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new FaceSliverSelect(root, callback, mgr);
    }
  }
}
