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
  public class ReloadFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Reload the current document, discarding all changes";
      }
    }

    public string Description
    {
      get
      {
        return "Reload the current document, discarding all changes";
      }
    }

    public string Keywords
    {
      get
      {
        return "SpaceClaim, file, IO, reload";
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
        return typeof(Reload);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new Reload(root, callback, mgr);
    }
  }
}
