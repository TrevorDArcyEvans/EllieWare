//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using EllieWare.Interfaces;

namespace EllieWare.Process
{
  public class ProcessExistsFactory : ProcessFactoryBase
  {
    public override string Title
    {
      get
      {
        return "Check if a process is running";
      }
    }

    public override string Description
    {
      get
      {
        return "Check if a process is running or not";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(ProcessExists);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new ProcessExists(root, callback, mgr);
    }
  }
}
