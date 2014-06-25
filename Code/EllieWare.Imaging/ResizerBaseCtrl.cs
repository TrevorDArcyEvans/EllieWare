//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using EllieWare.Common;

namespace EllieWare.Imaging
{
  public partial class ResizerBaseCtrl : DualItemIOBaseCtrl
  {
    public ResizerBaseCtrl()
    {
      InitializeComponent();

      ResizerMain.BringToFront();

      SourceFileSelector.Filter = FileExtensions.ImageFilesFilter;
      DestinationFileSelector.Filter = FileExtensions.ImageFilesFilter;
    }

    private void Dimension1_ValueChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void Dimension2_ValueChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }
  }
}
