//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
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

    public MacroRunner(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
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
      var dlg = new Editor(null, mRoot, SourceFilePathResolvedValue);

      return dlg.Run();
    }
  }
}
