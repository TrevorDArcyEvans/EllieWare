//
//  Copyright (C) 2012 EllieWare
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
  public class AssemblyDrawingsFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Create drawings from the current part or assembly";
      }
    }

    public string Description
    {
      get
      {
        return "Create drawings from the current part or assembly";
      }
    }

    public string Keywords
    {
      get
      {
        return "SpaceClaim, drawing, assembly";
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
        return typeof(AssemblyDrawings);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new AssemblyDrawings(root, callback, mgr);
    }
  }
}
