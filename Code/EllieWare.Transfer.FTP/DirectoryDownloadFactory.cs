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
  public class DirectoryDownloadFactory : FtpFactoryBase, IFactory
  {
    public override string Title
    {
      get
      {
        return "FTP directory download";
      }
    }

    public override string Description
    {
      get
      {
        return "Download a directory from an FTP site";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(DirectoryDownload);
      }
    }

    public override IRunnable Create(IEnumerable<object> roots, ICallback callback, IParameterManager mgr)
    {
      return new DirectoryDownload(roots, callback, mgr);
    }
  }
}
