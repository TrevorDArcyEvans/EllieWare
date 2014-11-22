//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//

using System;
using System.Globalization;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.SolidWorks
{
  public partial class ViewZoomCtrl : UserControlBase
  {
    private IRobotWare mRoot;

    public ViewZoomCtrl()
    {
      InitializeComponent();

      mZoomType.SelectedIndex = 0;
    }

    public override string Summary
    {
      get
      {
        switch (ZoomType)
        {
          case ViewZoom.ZoomType_e.In:
            return @"Zoom in";

          case ViewZoom.ZoomType_e.Out:
            return @"Zoom out";

          case ViewZoom.ZoomType_e.Fit:
            return @"Zoom to fit";

          case ViewZoom.ZoomType_e.Selected:
            return @"Zoom to selection";
        }
        throw new ArgumentOutOfRangeException(@"Unknown zoom type: " + ZoomType);
      }
    }

    public override void ReadXml(XmlReader reader)
    {
      base.ReadXml(reader);

      var zoomTypeStr = reader.GetAttribute("ZoomType");
      var zoomType = int.Parse(zoomTypeStr, NumberStyles.Integer, CultureInfo.InvariantCulture);
      mZoomType.SelectedIndex = zoomType;
    }

    public override void WriteXml(XmlWriter writer)
    {
      base.WriteXml(writer);

      var zoomTypeIdx = mZoomType.SelectedIndex;
      writer.WriteAttributeString("ZoomType", zoomTypeIdx.ToString(CultureInfo.InvariantCulture));
    }

    public override void Initialise(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      mRoot = root;
    }

    public ViewZoom.ZoomType_e ZoomType
    {
      get
      {
        return (ViewZoom.ZoomType_e)mZoomType.SelectedIndex;
      }
    }
  }
}
