//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EllieWare.Common;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;

namespace EllieWare.SpaceClaim
{
  public partial class ImportFromForeign : SingleItemIOBase
  {
    private readonly Dictionary<string, PartExportFormat> BrepFormats = new Dictionary<string, PartExportFormat>
                                              {
                                                {".CATPart".ToLowerInvariant(), PartExportFormat.CatiaV5Part},
                                                {".CATProduct".ToLowerInvariant(), PartExportFormat.CatiaV5Assembly},
                                                {".cgr", PartExportFormat.CatiaV5Graphics},
                                                {".igs", PartExportFormat.Iges},
                                                {".iges", PartExportFormat.Iges},
                                                {".stp", PartExportFormat.Step},
                                                {".step", PartExportFormat.Step},
                                                {".vda", PartExportFormat.Vda},
                                                {".jt", PartExportFormat.JtOpen},
                                                {".x_t", PartExportFormat.ParasolidText},
                                                {".x_b", PartExportFormat.ParasolidBinary},
                                                {".sat", PartExportFormat.AcisText},
                                                {".sab", PartExportFormat.AcisBinary},
                                                {".3dm", PartExportFormat.Rhino},
                                                {".pdf", PartExportFormat.Pdf},
                                                {".skp", PartExportFormat.SketchUp}
                                              };

    private readonly Dictionary<string, PartWindowExportFormat> TessellatedFormats = new Dictionary<string, PartWindowExportFormat>
                                              {
                                                {".bip", PartWindowExportFormat.Bip},
                                                {".obj", PartWindowExportFormat.Obj},
                                                {".stl", PartWindowExportFormat.Stl},
                                                {".wrl", PartWindowExportFormat.Vrml},
                                                {".vrml", PartWindowExportFormat.Vrml},
                                                {".xaml", PartWindowExportFormat.Xaml}
                                              };
    public ImportFromForeign()
    {
    }

    public ImportFromForeign(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
    {
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
      if (extn == null || !BrepFormats.ContainsKey(extn.ToLowerInvariant()))
      {
        return PartExportFormat.AcisBinary;
      }

      return BrepFormats[extn.ToLowerInvariant()];
    }

    private string Extension(PartExportFormat fmt)
    {
      return BrepFormats.First(x => x.Value == fmt).Key;
    }

    public override bool Run()
    {
      WriteBlock.AppendTask(() =>
                              {
                                var fmt = Format(SourceFilePathResolvedValue);
                                var extn = Extension(fmt);
                                var fileName = Path.ChangeExtension(SourceFilePathResolvedValue, extn);
                                var opts = ImportOptions.Create();

                                opts.Acis.CreateAssembly = true;
                                opts.ImportCurves = true;
                                opts.ImportNames = true;
                                opts.ImportPoints = true;

                                Document.Open(fileName, opts);
                              });

      return true;
    }
  }
}
