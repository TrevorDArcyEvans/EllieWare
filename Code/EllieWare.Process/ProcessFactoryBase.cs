//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;

namespace EllieWare.Process
{
  public class ProcessFactoryBase
  {
    public string Keywords
    {
      get
      {
        return "process start";
      }
    }

    public IEnumerable<string> Categories
    {
      get
      {
        return new[] { "Process" };
      }
    }

  }
}
