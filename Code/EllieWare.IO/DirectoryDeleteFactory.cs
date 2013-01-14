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
  public class DirectoryDeleteFactory : IOFactoryBase, IFactory
  {
    public override string Title
    {
      get
      {
        return "Delete a directory";
      }
    }

    public override string Description
    {
      get
      {
        return "Delete a directory and any subdirectories and files if it exists";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(DirectoryDelete);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new DirectoryDelete(root, callback, mgr);
    }
  }
}
