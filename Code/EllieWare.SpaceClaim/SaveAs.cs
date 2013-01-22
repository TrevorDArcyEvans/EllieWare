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

    protected override bool DoRun(Document doc)
    {
      doc.SaveAs(SourceFilePathResolvedValue);

      return true;
    }
  }
}
