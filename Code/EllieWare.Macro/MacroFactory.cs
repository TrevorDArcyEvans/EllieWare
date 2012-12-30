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
  public class MacroFactory : IFactory
  {
    #region Implementation of IFactory

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

    public IRunnable Create(IEnumerable<object> roots, ICallback callback, IParameterManager mgr)
    {
      return new MacroRunner(roots, callback, mgr);
    }

    #endregion
  }
}
