//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using EllieWare.Common;

namespace EllieWare.Logging
{
  public abstract class LoggingFactoryBase : FactoryBase
  {
    public override string Keywords
    {
      get
      {
        return "log debug ";
      }
    }

    public override IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "Logging", 
                       "Debugging"
                     };
      }
    }
  }
}
