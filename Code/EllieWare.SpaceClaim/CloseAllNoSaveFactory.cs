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
  public class CloseAllNoSaveFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Close all documents without saving";
      }
    }

    public string Description
    {
      get
      {
        return "Close all documents without saving";
      }
    }

    public string Keywords
    {
      get
      {
        return "SpaceClaim, file, IO, close";
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
        return typeof(CloseAllNoSave);
      }
    }

    public IRunnable Create(IEnumerable<object> roots, ICallback callback, IParameterManager mgr)
    {
      return new CloseAllNoSave(roots, callback, mgr);
    }
  }
}
