//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using EllieWare.Common;

namespace EllieWare.IO
{
  public abstract class IOFactoryBase : FactoryBase
  {
    public override string Keywords
    {
      get
      {
        return "file system, IO, disk";
      }
    }

    public override IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "File system", 
                       "Disk"
                     };
      }
    }
  }
}
