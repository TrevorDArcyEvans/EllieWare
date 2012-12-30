﻿//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public abstract class IOFactoryBase
  {
    public abstract string Title { get; }
    public abstract string Description { get; }

    public string Keywords
    {
      get
      {
        return "file system, IO, disk";
      }
    }

    public IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "File system", 
                       "Disk"
                     };
      }
    }

    public abstract Type CreatedType { get; }
    public abstract IRunnable Create(IEnumerable<object> roots, ICallback callback, IParameterManager mgr);
  }
}
