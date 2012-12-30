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

namespace EllieWare.IO
{
  public class FileExistsFactory : IOFactoryBase, IFactory
  {
    public override string Title
    {
      get
      {
        return "File checker";
      }
    }

    public override string Description
    {
      get
      {
        return "Check if a file exists or not";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(FileExists);
      }
    }

    public override IRunnable Create(IEnumerable<object> roots, ICallback callback, IParameterManager mgr)
    {
      return new FileExists(roots, callback, mgr);
    }
  }
}
