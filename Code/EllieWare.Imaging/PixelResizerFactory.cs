//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using EllieWare.Interfaces;

namespace EllieWare.Imaging
{
  public class PixelResizerFactory : ImagingFactoryBase, IFactory
  {
    public override string Title
    {
      get
      {
        return "Resize an image by pixels";
      }
    }

    public override string Description
    {
      get
      {
        return "Resize an image by specifying the new size in pixels, maintaining the aspect ratio";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(PixelResizer);
      }
    }

    public override IRunnable Create(IEnumerable<object> roots, ICallback callback, IParameterManager mgr)
    {
      return new PixelResizer(roots, callback, mgr);
    }
  }
}
