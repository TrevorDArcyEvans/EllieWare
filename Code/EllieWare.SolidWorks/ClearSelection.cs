//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//

using EllieWare.Common;
using EllieWare.Interfaces;
using SolidWorks.Interop.sldworks;

namespace EllieWare.SolidWorks
{
  public class ClearSelection : MutableRunnableBase<NullCtrl>
  {
    public ClearSelection()
    {
    }

    public ClearSelection(IRobotWare root, ICallback callback, IParameterManager mgr) :
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

      doc.ClearSelection2(true);

      return true;
    }
  }
}
