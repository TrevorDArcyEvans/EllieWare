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
  public class SaveFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Save the current document";
      }
    }

    public string Description
    {
      get
      {
        return "Save the current document";
      }
    }

    public string Keywords
    {
      get
      {
        return "SpaceClaim, file, IO, save";
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
        return typeof(Save);
      }
    }

    public IRunnable Create(object root, ICallback callback, IParameterManager mgr)
    {
      return new Save(root, callback, mgr);
    }
  }
}
