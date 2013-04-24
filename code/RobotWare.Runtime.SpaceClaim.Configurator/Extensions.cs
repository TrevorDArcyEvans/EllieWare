//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;

namespace RobotWare.Runtime.SpaceClaim.Configurator
{
  public static class Extensions
  {
    public static void SafeAdd<T>(this HashSet<T> me, T val)
    {
      if (!me.Contains(val))
      {
        me.Add(val);
      }
    }
  }
}
