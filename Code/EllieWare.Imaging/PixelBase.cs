//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Common;
using EllieWare.Interfaces;
using Simplicode.Imaging.Filters;
using FileExtensions = EllieWare.Common.FileExtensions;

namespace EllieWare.Imaging
{
  public class PixelBase : DualItemIOBase
  {
    public PixelBase()
    {
    }

    public PixelBase(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
    {
      mControl.SetSourceFileSelectorFilter(FileExtensions.ImageFilesFilter);
      mControl.SetDestinationFileSelectorFilter(FileExtensions.ImageFilesFilter);
    }

    public override string Summary
    {
      get
      {
        var summ = string.Format(GetSummaryFormat(),
                                  mControl.SourceFilePathResolvedValue,
                                  mControl.DestinationFilePathResolvedValue);
        return summ;
      }
    }

    public virtual string GetSummaryFormat()
    {
      return string.Empty;
    }

    public virtual IImageFilter GetFilter()
    {
      return null;
    }

    public override bool Run()
    {
      var processor = new Simplicode.Imaging.ImageProcessor { JpegCompression = 90L };
      var filter = GetFilter();

      processor.AddFilter(filter);
      processor.ProcessImage(mControl.SourceFilePathResolvedValue, mControl.DestinationFilePathResolvedValue);

      return true;
    }
  }
}
