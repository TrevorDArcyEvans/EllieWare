﻿using System;
using System.Collections.Generic;
using EllieWare.Interfaces;

namespace EllieWare.DateTime
{
  public class PauseFactory : IFactory
  {
    #region Implementation of IFactory

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

    public IRunnable Create(object root, ICallback callback, IParameterManager mgr)
    {
      return new Pause(root, callback, mgr);
    }

    #endregion
  }
}