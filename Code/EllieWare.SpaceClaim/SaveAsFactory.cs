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
  public class SaveAsFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Save current document to a different name";
      }
    }

    public string Description
    {
      get
      {
        return "Save current document to a different name";
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
        return typeof(SaveAs);
      }
    }

    public IRunnable Create(IEnumerable<object> roots, ICallback callback, IParameterManager mgr)
    {
      return new SaveAs(roots, callback, mgr);
    }
  }
}
