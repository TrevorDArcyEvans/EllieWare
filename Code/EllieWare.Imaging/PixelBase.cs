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
using Simplicode.Imaging.Filters;
using FileExtensions = EllieWare.Common.FileExtensions;

namespace EllieWare.Imaging
{
  public class PixelBase : DualItemIOBase
  {
    public PixelBase() :
      base()
    {
    }

    public PixelBase(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
    {
      SetSourceFileSelectorFilter(FileExtensions.ImageFilesFilter);
      SetDestinationFileSelectorFilter(FileExtensions.ImageFilesFilter);
    }

    public override string Summary
    {
      get
      {
        var summ = string.Format(GetSummaryFormat(),
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
      processor.ProcessImage(SourceFilePathResolvedValue, DestinationFilePathResolvedValue);

      return true;
    }
  }
}
