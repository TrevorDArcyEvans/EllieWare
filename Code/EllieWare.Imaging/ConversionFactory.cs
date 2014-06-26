//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using EllieWare.Interfaces;

namespace EllieWare.Imaging
{
  public class ConversionFactory : ImagingFactoryBase
  {
    public override string Title
    {
      get
      {
        return "Convert an image";
      }
    }

    public override string Description
    {
      get
      {
        return "Convert an image from one format to another";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(Conversion);
      }
    }

    public override Runnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new Conversion(root, callback, mgr);
    }
  }
}
