//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using EllieWare.Interfaces;

namespace EllieWare.Zip
{
  public class AddToZipFactory : ZipFactoryBase
  {
    public override string Title
    {
      get
      {
        return "Add a file to a zip file";
      }
    }

    public override string Description
    {
      get
      {
        return "Add a file to an existing zip file";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(AddToZip);
      }
    }

    public override Runnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new AddToZip(root, callback, mgr);
    }
  }
}
