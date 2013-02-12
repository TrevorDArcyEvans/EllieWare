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
      SetSourceFileSelectorFilter(Common.FileExtensions.ImageFilesFilter);
      SetDestinationFileSelectorFilter(Common.FileExtensions.ImageFilesFilter);
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Convert {0} --> {1}", SourceFilePathResolvedValue, DestinationFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      var processor = new Simplicode.Imaging.ImageProcessor { JpegCompression = 90L };

      processor.ProcessImage(SourceFilePathResolvedValue, DestinationFilePathResolvedValue);

      return true;
    }
  }
}
