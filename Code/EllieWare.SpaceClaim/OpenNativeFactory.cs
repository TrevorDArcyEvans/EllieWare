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
  public class OpenNativeFactory : IFactory
  {
    public string Title
    {
      get 
      { 
        return "Open a SpaceClaim file";
      }
    }

    public string Description
    {
      get
      {
        return "Open a native Spaceclaim file on disk";
      }
    }

    public string Keywords
    {
      get
      {
        return "SpaceClaim, file, IO, open";
      }
    }

    public IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "SpaceClaim",
                       "File", 
                       "IO"
                     };
      }
    }

    public Type CreatedType
    {
      get
      {
        return typeof(OpenNative);
      }
    }

    public IRunnable Create(IEnumerable<object> roots, ICallback callback, IParameterManager mgr)
    {
      return new OpenNative(roots, callback, mgr);
    }
  }
}
