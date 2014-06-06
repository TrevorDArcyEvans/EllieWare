//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using EllieWare.Common;

namespace EllieWare.Imaging
{
  public abstract class ImagingFactoryBase : FactoryBase
  {
    public override string Keywords
    {
      get
      {
        return "image, png, gif, bmp, tif, tiff, jpg, jpeg";
      }
    }

    public override IEnumerable<string> Categories
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
  }
}
