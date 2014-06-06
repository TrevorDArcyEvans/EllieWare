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
  public class DirectoryMoveFactory : IOFactoryBase
  {
    public override string Title
    {
      get
      {
        return "Move a directory";
      }
    }

    public override string Description
    {
      get
      {
        return "Move a directory from one place to another including subdirectories";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(DirectoryMove);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new DirectoryMove(root, callback, mgr);
    }
  }
}
