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
  public class FileMoveFactory : IOFactoryBase
  {
    public override string Title
    {
      get
      {
        return "Move a file";
      }
    }

    public override string Description
    {
      get
      {
        return "Move a file from one place to another";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(FileMove);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new FileMove(root, callback, mgr);
    }
  }
}
