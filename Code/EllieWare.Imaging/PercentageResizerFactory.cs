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
  public class PercentageResizerFactory : ImagingFactoryBase, IFactory
  {
    public override string Title
    {
      get
      {
        return "Resize an image by a percentage";
      }
    }

    public override string Description
    {
      get
      {
        return "Resize an image by a percentage of the original size, maintaining the aspect ratio";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(PercentageResizer);
      }
    }

    public override IRunnable Create(IEnumerable<object> roots, ICallback callback, IParameterManager mgr)
    {
      return new PercentageResizer(roots, callback, mgr);
    }
  }
}
