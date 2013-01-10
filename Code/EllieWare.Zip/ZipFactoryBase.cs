//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;

namespace EllieWare.Zip
{
  public class ZipFactoryBase
  {
    public string Keywords
    {
      get
      {
        return "compression zip archive";
      }
    }

    public IEnumerable<string> Categories
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
