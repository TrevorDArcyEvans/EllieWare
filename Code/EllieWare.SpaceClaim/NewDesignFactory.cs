//
//  Copyright (C) 2012 EllieWare
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
  public class NewDesignFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Create a empty new design document";
      }
    }

    public override string Description
    {
      get
      {
        return "Create a new empty design document";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SpaceClaim, design";
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
        return typeof(NewDesign);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new NewDesign(root, callback, mgr);
    }
  }
}
