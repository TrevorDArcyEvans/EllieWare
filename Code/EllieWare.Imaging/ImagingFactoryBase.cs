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
  public abstract class ImagingFactoryBase
  {
    public abstract string Title { get; }
    public abstract string Description { get; }

    public string Keywords
    {
      get
      {
        return "image, png, gif, bmp, tif, tiff, jpg, jpeg";
      }
    }

    public IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "Imaging", 
                       "Conversion"
                     };
      }
    }

    public abstract Type CreatedType { get; }
    public abstract IRunnable Create(IEnumerable<object> roots, ICallback callback, IParameterManager mgr);
  }
}
