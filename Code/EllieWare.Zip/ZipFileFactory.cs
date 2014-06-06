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
  public class ZipFileFactory : ZipFactoryBase, IFactory
  {
    public override string Title
    {
      get
      {
        return "Compress a file into a zip archive";
      }
    }

    public override string Description
    {
      get
      {
        return "Compress a file into a zip archive in the same directory";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(ZipFile);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new ZipFile(root, callback, mgr);
    }
  }
}
