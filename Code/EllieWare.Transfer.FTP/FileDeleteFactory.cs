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

namespace EllieWare.Transfer.FTP
{
  public class FileDeleteFactory : FtpFactoryBase, IFactory
  {
    public override string Title
    {
      get
      {
        return "FTP file delete";
      }
    }

    public override string Description
    {
      get
      {
        return "Delete a file on an FTP server";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(FileDelete);
      }
    }

    public override IRunnable Create(IEnumerable<object> roots, ICallback callback, IParameterManager mgr)
    {
      return new FileDelete(roots, callback, mgr);
    }
  }
}
