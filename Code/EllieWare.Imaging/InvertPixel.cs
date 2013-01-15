//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Windows.Forms;
using EllieWare.Common;
using EllieWare.Interfaces;
using Simplicode.Imaging.Filters.Pixel;

namespace EllieWare.Imaging
{
  public class InvertPixel : DualItemIOBase
  {
    public InvertPixel() :
      base()
    {
    }

    public InvertPixel(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
    {
      SetSourceFileSelectorFilter(Utils.ImageFilesFilter);
      SetDestinationFileSelectorFilter(Utils.ImageFilesFilter);
    }

    public override string Summary
    {
      get
      {
        var summ = string.Format("Invert the pixels in {0} and save it as {1}",
                                  SourceFilePathResolvedValue,
                                  DestinationFilePathResolvedValue);
        return summ;
      }
    }

    public override Control ConfigurationUserInterface
    {
      get
      {
        return this;
      }
    }

    public override bool Run()
    {
      var processor = new Simplicode.Imaging.ImageProcessor { JpegCompression = 90L };
      var filter = new InvertPixelFilter();

      processor.AddFilter(filter);
      processor.ProcessImage(SourceFilePathResolvedValue, DestinationFilePathResolvedValue);

      return true;
    }
  }
}
