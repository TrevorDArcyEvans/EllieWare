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
  public class ProcessStartFactory : ProcessFactoryBase
  {
    public override string Title
    {
      get
      {
        return "Start a process";
      }
    }

    public override string Description
    {
      get
      {
        return "Start a process or file to open";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(ProcessStart);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new ProcessStart(root, callback, mgr);
    }
  }
}
