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
  public class ViewRotate : MutableRunnableBase<ViewRotateCtrl>
  {
    public ViewRotate()
    {
    }

    public ViewRotate(IRobotWare root, ICallback callback, IParameterManager mgr) :
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
      switch (mControl.RotateType)
      {
        case ViewRotate_e.MinusX:
          doc.ViewRotateminusx();
          break;

        case ViewRotate_e.PlusX:
          doc.ViewRotateplusx();
          break;

        case ViewRotate_e.MinusY:
          doc.ViewRotateminusy();
          break;

        case ViewRotate_e.PlusY:
          doc.ViewRotateplusy();
          break;

        case ViewRotate_e.MinusZ:
          doc.ViewRotateminusz();
          break;

        case ViewRotate_e.PlusZ:
          doc.ViewRotateplusz();
          break;

        default:
          throw new ArgumentOutOfRangeException(@"Unknown rotate type: " + mControl.RotateType);
      }

      return true;
    }

    public enum ViewRotate_e
    {
      MinusX = 0,
      PlusX,
      MinusY,
      PlusY,
      MinusZ,
      PlusZ
    }
  }
}
