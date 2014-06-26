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
  public class UnZipFileFactory : ZipFactoryBase
  {
    public override string Title
    {
      get
      {
        return "Uncompress a zip archive into a directory";
      }
    }

    public override string Description
    {
      get
      {
        return "Uncompress a zip archive into a directory";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(UnZipFile);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new UnZipFile(root, callback, mgr);
    }
  }
}
