//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using EllieWare.Interfaces;

namespace EllieWare.EventLogger
{
  public class LoggerFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Write a message to the Windows event log";
      }
    }

    public string Description
    {
      get
      {
        return "Write a message to the Windows event log";
      }
    }

    public string Keywords
    {
      get
      {
        return "event log, debug, message";
      }
    }

    public IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "Debugging",
                       "Logging",
                       "System"
                     };
      }
    }

    public Type CreatedType
    {
      get
      {
        return typeof(Logger);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new Logger(root, callback, mgr);
    }
  }
}
