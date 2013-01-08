//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using EllieWare.Interfaces;

namespace EllieWare.SpaceClaim
{
  public class AppExitFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Exit SpaceClaim";
      }
    }

    public string Description
    {
      get
      {
        return "Exit SpaceClaim";
      }
    }

    public string Keywords
    {
      get
      {
        return "SpaceClaim, exit, quit";
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

    public Type CreatedType
    {
      get
      {
        return typeof(AppExit);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new AppExit(root, callback, mgr);
    }
  }
}
