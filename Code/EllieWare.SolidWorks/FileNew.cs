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
using SolidWorks.Interop.swconst;

namespace EllieWare.SolidWorks
{
  public class FileNew : MutableRunnableBase<FileNewCtrl>
  {
    public FileNew()
    {
    }

    public FileNew(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override bool Run()
    {
      var pSW = (ISldWorks)mRoot.ApplicationRoot;
      var defTempFileName = string.Empty; 
      switch (mControl.DocumentType)
      {
        case swDocumentTypes_e.swDocPART:
          defTempFileName = pSW.GetUserPreferenceStringValue((int)swUserPreferenceStringValue_e.swDefaultTemplatePart);
          break;

        case swDocumentTypes_e.swDocASSEMBLY:
          defTempFileName = pSW.GetUserPreferenceStringValue((int)swUserPreferenceStringValue_e.swDefaultTemplateAssembly);
          break;

        case swDocumentTypes_e.swDocDRAWING:
          defTempFileName = pSW.GetUserPreferenceStringValue((int)swUserPreferenceStringValue_e.swDefaultTemplateDrawing);
          break;

        default:
          throw new ArgumentOutOfRangeException(@"Unknown document type: " + mControl.DocumentType);
      }
      pSW.NewDocument(defTempFileName, (int)swDwgPaperSizes_e.swDwgPaperA1size, 0, 0);

      return true;
    }
  }
}
