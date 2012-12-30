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

namespace EllieWare.Process
{
  public class ProcessStartFactory : ProcessFactoryBase, IFactory
  {
    public string Title
    {
      get
      {
        return "Start a process";
      }
    }

    public string Description
    {
      get
      {
        return "Start a process or file to open";
      }
    }

    public Type CreatedType
    {
      get
      {
        return typeof(ProcessStart);
      }
    }

    public IRunnable Create(IEnumerable<object> roots, ICallback callback, IParameterManager mgr)
    {
      return new ProcessStart(roots, callback, mgr);
    }
  }
}
