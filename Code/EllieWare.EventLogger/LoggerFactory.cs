//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using EllieWare.Common;
using EllieWare.Interfaces;

// ReSharper disable once CheckNamespace
namespace EllieWare.EventLogger
{
  public class LoggerFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Write a message to the Windows event log";
      }
    }

    public override string Description
    {
      get
      {
        return "Write a message to the Windows event log";
      }
    }

    public override string Keywords
    {
      get
      {
        return "event log, debug, message";
      }
    }

    public override IEnumerable<string> Categories
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

    public override Type CreatedType
    {
      get
      {
        return typeof(Logger);
      }
    }

    public override Runnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new Logger(root, callback, mgr);
    }
  }
}
