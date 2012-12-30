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
  public class DirectoryUploadFactory : FtpFactoryBase, IFactory
  {
    public override string Title
    {
      get
      {
        return "FTP directory upload";
      }
    }

    public override string Description
    {
      get
      {
        return "Upload a directory to an FTP site";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(DirectoryUpload);
      }
    }

    public override IRunnable Create(IEnumerable<object> roots, ICallback callback, IParameterManager mgr)
    {
      return new DirectoryUpload(roots, callback, mgr);
    }
  }
}
