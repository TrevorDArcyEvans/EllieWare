//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Python
{
  public class PythonScriptFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Run a Python script";
      }
    }

    public override string Description
    {
      get
      {
        return "Run a Python script";
      }
    }

    public override string Keywords
    {
      get
      {
        return "IronPython, Python, script";
      }
    }

    public override IEnumerable<string> Categories
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

    public override Type CreatedType
    {
      get
      {
        return typeof(PythonScript);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new PythonScript(root, callback, mgr);
    }
  }
}
