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
  public class InvertPixelFactory : ImagingFactoryBase, IFactory
  {
    public override string Title
    {
      get
      {
        return "Invert pixels in an image";
      }
    }

    public override string Description
    {
      get
      {
        return "Invert color of pixels in an image";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(InvertPixel);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new InvertPixel(root, callback, mgr);
    }
  }
}
