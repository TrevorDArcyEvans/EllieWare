//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using System.Reflection;
using SerpentWare.Common;

namespace SerpentWare.Windows
{
  public class SerpentWareWindows : SerpentWareWrapperBase
  {
    public override IEnumerable<Assembly> Assemblies
    {
      get
      {
        return new List<Assembly>();
      }
    }

    public SerpentWareWindows(string appName) :
      base(appName)
    {
    }
  }
}
