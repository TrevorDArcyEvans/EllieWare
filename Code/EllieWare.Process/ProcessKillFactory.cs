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
  public class ProcessKillFactory : ProcessFactoryBase
  {
    public override string Title
    {
      get
      {
        return "Kill a process";
      }
    }

    public override string Description
    {
      get
      {
        return "Kill a running process";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(ProcessKill);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new ProcessKill(root, callback, mgr);
    }
  }
}
