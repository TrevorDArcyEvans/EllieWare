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
  public class SepiaPixelFactory : ImagingFactoryBase
  {
    public override string Title
    {
      get
      {
        return "Convert pixels in an image to sepia";
      }
    }

    public override string Description
    {
      get
      {
        return "Convert pixels in an image to sepia";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(SepiaPixel);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new SepiaPixel(root, callback, mgr);
    }
  }
}
