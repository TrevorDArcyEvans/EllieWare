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

namespace EllieWare.Python
{
  public class PythonAddin : SerpentWareWrapperBase
  {
    public PythonAddin() :
      base("EllieWare.Python")
    {
    }

    public override IEnumerable<Assembly> Assemblies
    {
      get
      {
        return new Assembly[]{};
      }
    }
  }
}
