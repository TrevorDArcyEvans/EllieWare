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
  public class DirectoryCopyFactory : IOFactoryBase, IFactory
  {
    public override string Title
    {
      get
      {
        return "Copy a directory";
      }
    }

    public override string Description
    {
      get
      {
        return "Copy a directory from one place to another including subdirectories";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(DirectoryCopy);
      }
    }

    public override IRunnable Create(object root, ICallback callback, IParameterManager mgr)
    {
      return new DirectoryCopy(root, callback, mgr);
    }
  }
}
