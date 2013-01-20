//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Interfaces;
using Simplicode.Imaging.Filters;
using Simplicode.Imaging.Filters.Pixel;

namespace EllieWare.Imaging
{
  public class SepiaPixel : PixelBase
  {
    public SepiaPixel() :
      base()
    {
    }

    public SepiaPixel(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override string GetSummaryFormat()
    {
      return "Convert the pixels in {0} to sepia and save it as {1}";
    }

    public override IImageFilter GetFilter()
    {
      return new SepiaPixelFilter();
    }
  }
}
