//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using EllieWare.Interfaces;

namespace EllieWare.Transfer.FTP
{
  public class FileExistsFactory : FtpFactoryBase, IFactory
  {
    public override string Title
    {
      get
      {
        return "FTP file checker";
      }
    }

    public override string Description
    {
      get
      {
        return "Check if an FTP file exists or not";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(FileExists);
      }
    }

    public override IRunnable Create(object root, ICallback callback, IParameterManager mgr)
    {
      return new FileExists(root, callback, mgr);
    }
  }
}
