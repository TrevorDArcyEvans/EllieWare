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

namespace EllieWare.Transfer.FTP
{
  public class DirectoryCreateFactory : FtpFactoryBase, IFactory
  {
    public override string Title
    {
      get
      {
        return "FTP directory creator";
      }
    }

    public override string Description
    {
      get
      {
        return "Create a directory on an FTP site";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(DirectoryCreate);
      }
    }

    public override IRunnable Create(IEnumerable<object> roots, ICallback callback, IParameterManager mgr)
    {
      return new DirectoryCreate(roots, callback, mgr);
    }
  }
}
