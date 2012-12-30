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

namespace EllieWare.DateTime
{
  public class PauseFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Pause for a period";
      }
    }

    public string Description
    {
      get
      {
        return "Pause for user defined interval";
      }
    }

    public string Keywords
    {
      get
      {
        return "pause wait delay";
      }
    }

    public IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "Time"
                     };
      }
    }

    public Type CreatedType
    {
      get
      {
        return typeof(Pause);
      }
    }

    public IRunnable Create(IEnumerable<object> roots, ICallback callback, IParameterManager mgr)
    {
      return new Pause(roots, callback, mgr);
    }
  }
}
