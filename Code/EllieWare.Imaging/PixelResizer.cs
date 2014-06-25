//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Interfaces;
using Simplicode.Imaging.Filters;

namespace EllieWare.Imaging
{
  public class PixelResizer : ResizerBase
  {
    public PixelResizer()
    {
    }

    public PixelResizer(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      mControl.Label1.Text = @"Pixels Wide:";
      mControl.Label2.Text = @"Pixels High:";
      mControl.Dimension1.Maximum = mControl.Dimension2.Maximum = 10000;
    }

    public override string Summary
    {
      get
      {
        var summ = string.Format("Change the size of {0} to {1} pixels wide X {2} pixels high and save it to {3}",
                                  mControl.SourceFilePathResolvedValue,
                                  mControl.Dimension1.Value,
                                  mControl.Dimension2.Value,
                                  mControl.DestinationFilePathResolvedValue);
        return summ;
      }
    }

    public override bool Run()
    {
      var processor = new Simplicode.Imaging.ImageProcessor { JpegCompression = 90L };
      var resizer = new ResizeFilter((int)mControl.Dimension1.Value, (int)mControl.Dimension2.Value);

      processor.AddFilter(resizer);
      processor.ProcessImage(mControl.SourceFilePathResolvedValue, mControl.DestinationFilePathResolvedValue);

      return true;
    }
  }
}
