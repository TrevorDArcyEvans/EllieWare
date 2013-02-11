﻿//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using EllieWare.Interfaces;

namespace EllieWare.Batch
{
  public class BatchRunnerFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Run a series of macros with the same parameters";
      }
    }

    public string Description
    {
      get
      {
        return "Run a series of macros with the same parameters";
      }
    }

    public string Keywords
    {
      get
      {
        return "batch";
      }
    }

    public IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "Macro",
                       "Batch"
                     };
      }
    }

    public Type CreatedType
    {
      get
      {
        return typeof(BatchRunner);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new BatchRunner(root, callback, mgr);
    }
  }
}
