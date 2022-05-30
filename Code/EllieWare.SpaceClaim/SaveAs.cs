//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Common;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;

namespace EllieWare.SpaceClaim
{
  public class SaveAs : SpaceClaimSingleItemIOBase
  {
    public SaveAs()
    {
    }

    public SaveAs(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
    {
      mControl.SetSourceFileSelectorFilter(Utils.NativeFilter);
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Save current document as {0}", mControl.SourceFilePathResolvedValue);

        return descrip;
      }
    }

    protected override bool DoRun()
    {
      var doc = Window.ActiveWindow.Document;
      doc.SaveAs(mControl.SourceFilePathResolvedValue);

      return true;
    }
  }
}
