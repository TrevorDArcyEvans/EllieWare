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

namespace EllieWare.Macro
{
  public class MacroRunnerFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Run another macro file";
      }
    }

    public string Description
    {
      get
      {
        return "Run another macro file";
      }
    }

    public string Keywords
    {
      get
      {
        return "macro, runner, recursive";
      }
    }

    public IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "Macro"
                     };
      }
    }

    public Type CreatedType
    {
      get
      {
        return typeof(MacroRunner);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new MacroRunner(root, callback, mgr);
    }
  }
}
