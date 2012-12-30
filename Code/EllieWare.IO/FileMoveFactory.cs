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
  public class FileMoveFactory : IOFactoryBase, IFactory
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

    public override IRunnable Create(IEnumerable<object> roots, ICallback callback, IParameterManager mgr)
    {
      return new FileMove(roots, callback, mgr);
    }
  }
}
