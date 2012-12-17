﻿using System;
using EllieWare.Interfaces;

namespace EllieWare.Logging
{
  public class LoggingFactory : LoggingFactoryBase, IFactory
  {
    public override string Title
    {
      get
      {
        return "Log a message";
      }
    }

    public override string Description
    {
      get
      {
        return "Log messages to the output window";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof (Logging);
      }
    }

    public override IRunnable Create(object root, ICallback callback, IParameterManager mgr)
    {
      return new Logging(root, callback, mgr);
    }
  }
}
