﻿using System;
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

    public IRunnable Create(object root, ICallback callback, IParameterManager mgr)
    {
      return new ProcessStart(root, callback, mgr);
    }
  }
}