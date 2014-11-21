//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//

using System;
using System.Collections.Generic;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.SolidWorks
{
  public class RebuildFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Rebuild the current document";
      }
    }

    public override string Description
    {
      get
      {
        return "Force rebuild of all geometry for the current document";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SolidWorks, rebuild";
      }
    }

    public override IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "SolidWorks"
                     };
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(Rebuild);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new Rebuild(root, callback, mgr);
    }
  }
}
