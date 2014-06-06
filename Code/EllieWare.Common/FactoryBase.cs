//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public abstract class FactoryBase : IFactory
  {
    public abstract string Title { get; }

    public abstract string Description { get; }

    public abstract string Keywords { get; }

    public abstract IEnumerable<string> Categories { get; }

    public bool IsLicensed
    {
      get
      {
        return true;
      }
    }

    public abstract Type CreatedType { get; }

    public abstract IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr);
  }
}
