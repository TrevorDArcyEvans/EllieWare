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
using SolidWorks.Interop.swconst;

namespace EllieWare.SolidWorks
{
  public class FileSave : MutableRunnableBase<NullCtrl>
  {
    public FileSave()
    {
    }

    public FileSave(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override bool CanRun
    {
      get
      {
        var pSW = (ISldWorks)mRoot.ApplicationRoot;

        if (pSW.GetDocumentCount() == 0)
        {
          return false;
        }

        var doc = pSW.IActiveDoc2;

        return !string.IsNullOrEmpty(doc.GetPathName());
      }
    }

    public override bool Run()
    {
      var pSW = (ISldWorks)mRoot.ApplicationRoot;
      var doc = pSW.IActiveDoc2;
      var errors = default(int);
      var warnings = default(int);

      return doc.Save3((int)swSaveAsOptions_e.swSaveAsOptions_Silent, ref errors, ref warnings);
    }
  }
}
