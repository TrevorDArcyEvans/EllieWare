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

namespace EllieWare.Batch
{
  public class BatchRunnerFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Run a series of macros with the same parameters";
      }
    }

    public override string Description
    {
      get
      {
        return "Run a series of macros with the same parameters";
      }
    }

    public override string Keywords
    {
      get
      {
        return "batch";
      }
    }

    public override IEnumerable<string> Categories
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

    public override Type CreatedType
    {
      get
      {
        return typeof(BatchRunner);
      }
    }

    public override Runnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new BatchRunner(root, callback, mgr);
    }
  }
}
