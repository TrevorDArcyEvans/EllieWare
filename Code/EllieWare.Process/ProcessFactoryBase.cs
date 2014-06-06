//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using EllieWare.Common;

namespace EllieWare.Process
{
  public abstract class ProcessFactoryBase : FactoryBase
  {
    public override string Keywords
    {
      get
      {
        return "process start";
      }
    }

    public override IEnumerable<string> Categories
    {
      get
      {
        return new[] { "Process" };
      }
    }

  }
}
