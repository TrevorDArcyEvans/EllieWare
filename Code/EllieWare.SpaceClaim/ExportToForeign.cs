//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.IO;
using System.Linq;
using EllieWare.Common;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;

namespace EllieWare.SpaceClaim
{
  public class ExportToForeign : SpaceClaimSingleItemIOBase
  {
    public ExportToForeign()
    {
    }

    public ExportToForeign(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
    {
      mControl.SetSourceFileSelectorFilter(Utils.PartExportFilter);
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Export current part model to {0}", mControl.SourceFilePathResolvedValue);

        return descrip;
      }
    }

    private PartWindowExportFormat TessellatedFormat(string fileName)
    {
      var extn = Path.GetExtension(fileName);
      if (extn == null || !Utils.TessellatedFormats.ContainsKey(extn.ToLowerInvariant()))
      {
        return PartWindowExportFormat.Stl;
      }

      return Utils.TessellatedFormats[extn.ToLowerInvariant()];
    }

    private string TessellatedExtension(PartWindowExportFormat fmt)
    {
      return Utils.TessellatedFormats.First(x => x.Value == fmt).Key;
    }

    private bool IsBrepFormat(string fileName)
    {
      var extn = Path.GetExtension(fileName);
      if (extn == null)
      {
        return false;
      }

      return Utils.BrepFormats.ContainsKey(extn.ToLowerInvariant());
    }

    protected override bool DoRun()
    {
      if (IsBrepFormat(mControl.SourceFilePathResolvedValue))
      {
        var extn = Path.GetExtension(mControl.SourceFilePathResolvedValue).ToLowerInvariant();
        var fmt = Utils.BrepFormats[extn];
        var opts = ExportOptions.Create();

        opts.ExportNames = true;
        opts.Step.ExportIdentifiers = true;

        var doc = Window.ActiveWindow.Document;

        doc.MainPart.Export(fmt, mControl.SourceFilePathResolvedValue, true, opts);
      }
      else
      {
        var fmt = TessellatedFormat(mControl.SourceFilePathResolvedValue);
        var extn = TessellatedExtension(fmt);
        var fileName = Path.ChangeExtension(mControl.SourceFilePathResolvedValue, extn);

        Window.ActiveWindow.ExportPart(fmt, fileName);
      }

      return true;
    }
  }
}
