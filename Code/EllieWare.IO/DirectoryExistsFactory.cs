﻿using System;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public class DirectoryExistsFactory : IOFactoryBase, IFactory
  {
    public override string Title
    {
      get
      {
        return "Directory checker";
      }
    }

    public override string Description
    {
      get
      {
        return "Check if a directory exists or not";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(DirectoryExists);
      }
    }

    public override IRunnable Create(object root, ICallback callback, IParameterManager mgr)
    {
      return new DirectoryExists(root, callback, mgr);
    }
  }
}