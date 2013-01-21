//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using EllieWare.Interfaces;

namespace EllieWare.SpaceClaim
{
  public class DifferenceFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Compare two designs and put the differences into a new design";
      }
    }

    public string Description
    {
      get
      {
        return "Compare two designs and put the differences into a new design";
      }
    }

    public string Keywords
    {
      get
      {
        return "SpaceClaim, difference, geometry";
      }
    }

    public IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "SpaceClaim"
                     };
      }
    }

    public Type CreatedType
    {
      get
      {
        return typeof(Difference);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new Difference(root, callback, mgr);
    }
  
  }
}
