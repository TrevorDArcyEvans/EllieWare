//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//

using System;
using EllieWare.Common;
using EllieWare.Interfaces;
using SolidWorks.Interop.sldworks;

namespace EllieWare.SolidWorks
{
  public class ViewZoom : MutableRunnableBase<ViewZoomCtrl>
  {
    public ViewZoom()
    {
    }

    public ViewZoom(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override bool CanRun
    {
      get
      {
        var pSW = (ISldWorks)mRoot.ApplicationRoot;

        return pSW.GetDocumentCount() != 0;
      }
    }

    public override bool Run()
    {
      var pSW = (ISldWorks)mRoot.ApplicationRoot;
      var doc = pSW.IActiveDoc2;
      switch (mControl.ZoomType)
      {
        case ZoomType_e.In:
          doc.ViewZoomin();
          break;

        case ZoomType_e.Out:
          doc.ViewZoomout();
          break;

        case ZoomType_e.Fit:
          doc.ViewZoomtofit2();
          break;

        case ZoomType_e.Selected:
          doc.ViewZoomToSelection();
          break;

        default:
          throw new ArgumentOutOfRangeException(@"Unknown zoom type: " + mControl.ZoomType);
      }

      return true;
    }

    public enum ZoomType_e
    {
      In = 0,
      Out,
      Fit,
      Selected
    }
  }
}
