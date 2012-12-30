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

namespace EllieWare.IO
{
  public class DirectoryMoveFactory : IOFactoryBase, IFactory
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

    public override IRunnable Create(IEnumerable<object> roots, ICallback callback, IParameterManager mgr)
    {
      return new DirectoryMove(roots, callback, mgr);
    }
  }
}
