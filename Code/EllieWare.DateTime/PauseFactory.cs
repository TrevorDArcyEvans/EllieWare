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

namespace EllieWare.DateTime
{
  public class PauseFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Pause for a period";
      }
    }

    public override string Description
    {
      get
      {
        return "Pause for user defined interval";
      }
    }

    public override string Keywords
    {
      get
      {
        return "pause wait delay";
      }
    }

    public override IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "Time"
                     };
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(Pause);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new Pause(root, callback, mgr);
    }
  }
}
