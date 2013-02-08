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
  public class ImportFromForeign : SpaceClaimSingleItemIOBase
  {
    public ImportFromForeign()
    {
    }

    public ImportFromForeign(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
    {
      SetSourceFileSelectorFilter(Utils.PartExportFilter);
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Import {0}", SourceFilePathResolvedValue);

        return descrip;
      }
    }

    private PartExportFormat Format(string fileName)
    {
      var extn = Path.GetExtension(fileName);
      if (extn == null || !Utils.BrepFormats.ContainsKey(extn.ToLowerInvariant()))
      {
        return PartExportFormat.AcisBinary;
      }

      return Utils.BrepFormats[extn.ToLowerInvariant()];
    }

    private string Extension(PartExportFormat fmt)
    {
      return Utils.BrepFormats.First(x => x.Value == fmt).Key;
    }

    public override bool CanRun
    {
      get
      {
        return true;
      }
    }

    protected override bool DoRun()
    {
      var fmt = Format(SourceFilePathResolvedValue);
      var extn = Extension(fmt);
      var fileName = Path.ChangeExtension(SourceFilePathResolvedValue, extn);
      var opts = ImportOptions.Create();

      opts.Acis.CreateAssembly = true;
      opts.ImportCurves = true;
      opts.ImportNames = true;
      opts.ImportPoints = true;

      var windows = Document.Open(fileName, opts);

      Window.ActiveWindow = windows.First();

      return true;
    }
  }
}
