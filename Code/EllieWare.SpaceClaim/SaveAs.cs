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
using SpaceClaim.Api.V10;

namespace EllieWare.SpaceClaim
{
  public class SaveAs : SingleItemIOBase
  {
    public SaveAs()
    {
    }

    public SaveAs(IEnumerable<object> roots, ICallback callback, IParameterManager mgr) :
      base(roots, callback, mgr, BrowserTypes.BothFile)
    {
      SetSourceFileSelectorFilter(Utils.NativeFilter);
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Save current document as {0}", SourceFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      WriteBlock.AppendTask(() => Window.ActiveWindow.Document.SaveAs(SourceFilePathResolvedValue));

      return true;
    }
  }
}
