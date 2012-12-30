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
  public class ProcessExistsFactory : ProcessFactoryBase, IFactory
  {
    public string Title
    {
      get
      {
        return "Check if a process is running";
      }
    }

    public string Description
    {
      get
      {
        return "Check if a process is running or not";
      }
    }

    public Type CreatedType
    {
      get
      {
        return typeof(ProcessExists);
      }
    }

    public IRunnable Create(IEnumerable<object> roots, ICallback callback, IParameterManager mgr)
    {
      return new ProcessExists(roots, callback, mgr);
    }
  }
}
