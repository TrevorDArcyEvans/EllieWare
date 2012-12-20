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
  public class DirectoryExistsFactory : FtpFactoryBase, IFactory
  {
    public override string Title
    {
      get
      {
        return "FTP directory checker";
      }
    }

    public override string Description
    {
      get
      {
        return "Check if an FTP directory exists or not";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(DirectoryExists);
      }
    }

    public override IRunnable Create(object root, ICallback callback, IParameterManager mgr)
    {
      return new DirectoryExists(root, callback, mgr);
    }
  }
}
