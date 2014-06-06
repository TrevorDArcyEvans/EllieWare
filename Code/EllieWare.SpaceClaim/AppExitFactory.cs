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
  public class AppExitFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Exit SpaceClaim";
      }
    }

    public override string Description
    {
      get
      {
        return "Exit SpaceClaim";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SpaceClaim, exit, quit";
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
        return typeof(AppExit);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new AppExit(root, callback, mgr);
    }
  }
}
