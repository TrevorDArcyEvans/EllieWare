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
  public class CloseNoSaveFactory : IFactory
  {
    public string Title
    {
      get 
      { 
        return "Close current document without saving";
      }
    }

    public string Description
    {
      get
      {
        return "Close the current document without saving";
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
        return typeof(CloseNoSave);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new CloseNoSave(root, callback, mgr);
    }
  }
}
