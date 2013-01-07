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
  public class FileCopyFactory : IOFactoryBase, IFactory
  {
    public override string Title
    {
      get
      {
        return "Copy a file";
      }
    }

    public override string Description
    {
      get
      {
        return "Copy a file from one place to another";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(FileCopy);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new FileCopy(root, callback, mgr);
    }
  }
}
