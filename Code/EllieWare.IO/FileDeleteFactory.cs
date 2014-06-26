//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public class FileDeleteFactory : IOFactoryBase
  {
    public override string Title
    {
      get
      {
        return "Delete a file";
      }
    }

    public override string Description
    {
      get
      {
        return "Delete a file if it exists";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(FileDelete);
      }
    }

    public override Runnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new FileDelete(root, callback, mgr);
    }
  }
}
