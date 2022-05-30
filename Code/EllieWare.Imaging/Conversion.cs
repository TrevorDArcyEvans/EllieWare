//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Imaging
{
  public class Conversion : DualItemIOBase
  {
    public Conversion()
    {
    }

    public Conversion(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
    {
      mControl.SetSourceFileSelectorFilter(Common.FileExtensions.ImageFilesFilter);
      mControl.SetDestinationFileSelectorFilter(Common.FileExtensions.ImageFilesFilter);
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Convert {0} --> {1}", mControl.SourceFilePathResolvedValue, mControl.DestinationFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      var processor = new Simplicode.Imaging.ImageProcessor { JpegCompression = 90L };

      processor.ProcessImage(mControl.SourceFilePathResolvedValue, mControl.DestinationFilePathResolvedValue);

      return true;
    }
  }
}
