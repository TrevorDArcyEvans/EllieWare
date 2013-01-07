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
  public class DirectoryDeleteFactory : FtpFactoryBase, IFactory
  {
    public override string Title
    {
      get
      {
        return "FTP directory delete";
      }
    }

    public override string Description
    {
      get
      {
        return "Delete a directory on an FTP site";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(DirectoryDelete);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new DirectoryDelete(root, callback, mgr);
    }
  }
}
