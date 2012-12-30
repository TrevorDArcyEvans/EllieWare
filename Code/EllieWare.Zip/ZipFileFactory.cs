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

namespace EllieWare.Zip
{
  public class ZipFileFactory : ZipFactoryBase, IFactory
  {
    public string Title
    {
      get
      {
        return "Compress a file into a zip archive";
      }
    }

    public string Description
    {
      get
      {
        return "Compress a file into a zip archive in the same directory";
      }
    }

    public Type CreatedType
    {
      get
      {
        return typeof(ZipFile);
      }
    }

    public IRunnable Create(IEnumerable<object> roots, ICallback callback, IParameterManager mgr)
    {
      return new ZipFile(roots, callback, mgr);
    }
  }
}
