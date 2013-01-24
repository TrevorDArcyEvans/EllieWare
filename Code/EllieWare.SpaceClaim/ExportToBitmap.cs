//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.IO;
using EllieWare.Common;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;
using System.Linq;

namespace EllieWare.SpaceClaim
{
  public class ExportToBitmap : SpaceClaimSingleItemIOBase
  {
    public ExportToBitmap()
    {
    }

    public ExportToBitmap(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
    {
      SetSourceFileSelectorFilter(Utils.WindowRasterExportFilter);
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Save current view as a bitmap to {0}", SourceFilePathResolvedValue);

        return descrip;
      }
    }

    private WindowExportFormat Format(string fileName)
    {
      var extn = Path.GetExtension(fileName);
      if (extn == null || !Utils.RasterFormats.ContainsKey(extn.ToLowerInvariant()))
      {
        return WindowExportFormat.Png;
      }

      return Utils.RasterFormats[extn.ToLowerInvariant()];
    }

    private string Extension(WindowExportFormat fmt)
    {
      return Utils.RasterFormats.First(x => x.Value == fmt).Key;
    }

    protected override bool DoRun()
    {
      var fmt = Format(SourceFilePathResolvedValue);
      var extn = Extension(fmt);
      var fileName = Path.ChangeExtension(SourceFilePathResolvedValue, extn);

      Window.ActiveWindow.Export(fmt, fileName);

      return true;
    }
  }
}
