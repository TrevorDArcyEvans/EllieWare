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

namespace EllieWare.Macro
{
  public class MacroRunnerFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Run another macro file";
      }
    }

    public override string Description
    {
      get
      {
        return "Run another macro file";
      }
    }

    public override string Keywords
    {
      get
      {
        return "macro, runner, recursive";
      }
    }

    public override IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "Macro"
                     };
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(MacroRunner);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new MacroRunner(root, callback, mgr);
    }
  }
}
