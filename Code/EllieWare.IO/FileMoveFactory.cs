﻿using System;
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

    public override IRunnable Create(object root, ICallback callback, IParameterManager mgr)
    {
      return new FileMove(root, callback, mgr);
    }
  }
}