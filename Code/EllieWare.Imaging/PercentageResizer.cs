//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Drawing;
using EllieWare.Interfaces;
using Simplicode.Imaging.Filters;

namespace EllieWare.Imaging
{
  public class PercentageResizer : ResizerBase
  {
    public PercentageResizer()
    {
    }

    public PercentageResizer(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      mControl.Label1.Text = @"Percentage:";
      mControl.Label2.Visible = mControl.Dimension2.Visible = false;

      // max = 1000% = 10x
      mControl.Dimension1.Maximum = 1000;
    }

    public override string Summary
    {
      get
      {
        var summ = string.Format("Change the size of {0} by {1}% and save it to {2}",
                                  mControl.SourceFilePathResolvedValue,
                                  mControl.Dimension1.Value,
                                  mControl.DestinationFilePathResolvedValue);
        return summ;
      }
    }

    public override bool Run()
    {
      int newImgWidth;
      int newImgHeight;
      using (var img = Image.FromFile(mControl.SourceFilePathResolvedValue))
      {
        newImgWidth = img.Width * (int)mControl.Dimension1.Value / 100;
        newImgHeight = img.Height * (int)mControl.Dimension1.Value / 100;
      }

      var processor = new Simplicode.Imaging.ImageProcessor { JpegCompression = 90L };
      var resizer = new ResizeFilter(newImgWidth, newImgHeight);

      processor.AddFilter(resizer);
      processor.ProcessImage(mControl.SourceFilePathResolvedValue, mControl.DestinationFilePathResolvedValue);

      return true;
    }
  }
}
