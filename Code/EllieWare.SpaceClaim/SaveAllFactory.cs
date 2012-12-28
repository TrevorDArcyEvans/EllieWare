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
  public class SaveAllFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Save all documents";
      }
    }

    public string Description
    {
      get
      {
        return "Save all documents";
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
        return typeof(SaveAll);
      }
    }

    public IRunnable Create(object root, ICallback callback, IParameterManager mgr)
    {
      return new SaveAll(root, callback, mgr);
    }
  }
}
