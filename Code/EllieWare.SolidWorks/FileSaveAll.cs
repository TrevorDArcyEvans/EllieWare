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
  public class FileSaveAll : MutableRunnableBase<NullCtrl>
  {
    public FileSaveAll()
    {
    }

    public FileSaveAll(IRobotWare root, ICallback callback, IParameterManager mgr) :
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

        var doc = pSW.IGetFirstDocument2();
        while (doc != null)
        {
          if (string.IsNullOrEmpty(doc.GetPathName()))
          {
            return false;
          }

          doc = doc.IGetNext();
        }

        return true;
      }
    }

    public override bool Run()
    {
      var retval = true;
      var pSW = (ISldWorks)mRoot.ApplicationRoot;
      var doc = pSW.IGetFirstDocument2();
      while (doc != null)
      {
        var errors = default(int);
        var warnings = default(int);

        retval &= doc.Save3((int)swSaveAsOptions_e.swSaveAsOptions_Silent, ref errors, ref warnings);

        doc = doc.IGetNext();
      }

      return retval;
    }
  }
}
