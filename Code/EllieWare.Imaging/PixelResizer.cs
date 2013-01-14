//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Windows.Forms;
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
      Label1.Text = "Pixels Wide:";
      Label2.Text = "Pixels High:";
      Dimension1.Maximum = Dimension2.Maximum = 10000;
    }

    public override string Summary
    {
      get
      {
        var summ = string.Format("Change the size of {0} to {1} pixels wide X {2} pixels high and save it to {3}",
                                  SourceFilePathResolvedValue,
                                  Dimension1.Value,
                                  Dimension2.Value,
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
      var resizer = new ResizeFilter((int)Dimension1.Value, (int)Dimension2.Value);

      processor.AddFilter(resizer);
      processor.ProcessImage(SourceFilePathResolvedValue, DestinationFilePathResolvedValue);

      return true;
    }
  }
}
