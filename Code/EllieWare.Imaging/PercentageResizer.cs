//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using EllieWare.Interfaces;
using Simplicode.Imaging.Filters;

namespace EllieWare.Imaging
{
  public class PercentageResizer : ResizerBase
  {
    public PercentageResizer()
    {
    }

    public PercentageResizer(IEnumerable<object> roots, ICallback callback, IParameterManager mgr) :
      base(roots, callback, mgr)
    {
      Label1.Text = "Percentage:";
      Label2.Visible = Dimension2.Visible = false;

      // max = 1000% = 10x
      Dimension1.Maximum = 1000;
    }

    #region Implementation of IRunnable

    public override string Summary
    {
      get
      {
        var summ = string.Format("Change the size of {0} by {1}% and save it to {2}",
                                  SourceFilePathResolvedValue,
                                  Dimension1.Value,
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
      int newImgWidth;
      int newImgHeight;
      using (var img = Image.FromFile(SourceFilePathResolvedValue))
      {
        newImgWidth = img.Width * (int)Dimension1.Value / 100;
        newImgHeight = img.Height * (int)Dimension1.Value / 100;
      }

      var processor = new Simplicode.Imaging.ImageProcessor { JpegCompression = 90L };
      var resizer = new ResizeFilter(newImgWidth, newImgHeight);

      processor.AddFilter(resizer);
      processor.ProcessImage(SourceFilePathResolvedValue, DestinationFilePathResolvedValue);

      return true;
    }

    #endregion

  }
}
