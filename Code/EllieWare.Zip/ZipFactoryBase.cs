//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using EllieWare.Common;

namespace EllieWare.Zip
{
  public abstract class ZipFactoryBase : FactoryBase
  {
    public override string Keywords
    {
      get
      {
        return "compression zip archive";
      }
    }

    public override IEnumerable<string> Categories
    {
      get
      {
        return new[]
                 {
                   "Archive",
                   "Compression",
                   "Zip"
                 };
      }
    }
  }
}
