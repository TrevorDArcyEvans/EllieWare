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
  public class AssemblyDrawingsFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Create drawings from the current part or assembly";
      }
    }

    public override string Description
    {
      get
      {
        return "Create drawings from the current part or assembly";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SpaceClaim, drawing, assembly";
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
        return typeof(AssemblyDrawings);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new AssemblyDrawings(root, callback, mgr);
    }
  }
}
