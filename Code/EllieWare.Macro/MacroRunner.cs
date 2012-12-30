//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using EllieWare.Common;
using EllieWare.Interfaces;
using EllieWare.Manager;

namespace EllieWare.Macro
{
  public partial class MacroRunner : SingleItemIOBase
  {
    public MacroRunner()
    {
    }

    public MacroRunner(IEnumerable<object> roots, ICallback callback, IParameterManager mgr) :
      base(roots, callback, mgr, BrowserTypes.BothFile)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Run {0}", SourceFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      // FIX ME!  potential licensing hole as demo mode is implemented in Editor
      var dlg = new Editor(null, mRoots, SourceFilePathResolvedValue);

      return dlg.Run();
    }
  }
}
