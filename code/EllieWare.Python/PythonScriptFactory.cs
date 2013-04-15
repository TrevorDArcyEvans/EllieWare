//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using EllieWare.Interfaces;

namespace EllieWare.Python
{
  public class PythonScriptFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Run a Python script";
      }
    }

    public string Description
    {
      get
      {
        return "Run a Python script";
      }
    }

    public string Keywords
    {
      get
      {
        return "IronPython, Python, script";
      }
    }

    public IEnumerable<string> Categories
    {
      get
      {
        return new[]
                 {
                   "IronPython",
                   "Python",
                   "script"
                 };
      }
    }

    public Type CreatedType
    {
      get
      {
        return typeof(PythonScript);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new PythonScript(root, callback, mgr);
    }
  }
}
