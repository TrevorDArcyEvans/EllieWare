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
  public class InvertPixel : PixelBase
  {
    public InvertPixel()
    {
    }

    public InvertPixel(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override string GetSummaryFormat()
    {
      return "Invert the pixels in {0} and save it as {1}";
    }

    public override IImageFilter GetFilter()
    {
      return new InvertPixelFilter();
    }
  }
}
