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
  public class ViewTranslate : MutableRunnableBase<ViewTranslateCtrl>
  {
    public ViewTranslate()
    {
    }

    public ViewTranslate(IRobotWare root, ICallback callback, IParameterManager mgr) :
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
      switch (mControl.TranslateType)
      {
        case TranslateType_e.MinusX:
          doc.ViewTranslateminusx();
          break;

        case TranslateType_e.PlusX:
          doc.ViewTranslateplusx();
          break;

        case TranslateType_e.MinusY:
          doc.ViewTranslateminusy();
          break;

        case TranslateType_e.PlusY:
          doc.ViewTranslateplusy();
          break;

        default:
          throw new ArgumentOutOfRangeException(@"Unknown translate type: " + mControl.TranslateType);
      }

      return true;
    }

    public enum TranslateType_e
    {
      MinusX = 0,
      PlusX,
      MinusY,
      PlusY
    }
  }
}
