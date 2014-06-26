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
  public class DirectoryUploadFactory : FtpFactoryBase
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

    public override Runnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new DirectoryUpload(root, callback, mgr);
    }
  }
}
