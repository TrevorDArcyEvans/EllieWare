//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using EllieWare.Interfaces;

namespace EllieWare.Zip
{
  public class ZipDirectoryFactory : ZipFactoryBase, IFactory
  {
    public string Title
    {
      get
      {
        return "Compress a directory into a zip archive";
      }
    }

    public string Description
    {
      get
      {
        return "Compress a directory and all subdirectories into a zip archive in the same directory";
      }
    }

    public Type CreatedType
    {
      get
      {
        return typeof(ZipDirectory);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new ZipDirectory(root, callback, mgr);
    }
  }
}
