//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using EllieWare.Interfaces;

namespace EllieWare.Logging
{
  public class DateTimeLogFactory : LoggingFactoryBase
  {
    public override string Title
    {
      get
      {
        return "Log current date and time";
      }
    }

    public override string Description
    {
      get
      {
        return "Log current date and time";
      }
    }

    public override string Keywords
    {
      get
      {
        return base.Keywords + " date time";
      }
    }

    public override Type CreatedType
    {
      get { return typeof(DateTimeLog); }
    }

    public override Runnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new DateTimeLog(root, callback, mgr);
    }
  }
}
