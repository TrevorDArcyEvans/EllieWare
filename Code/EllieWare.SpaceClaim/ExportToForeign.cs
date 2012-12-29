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
  public partial class ExportToForeign : SingleItemIOBase
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

    public ExportToForeign()
    {
    }

    public ExportToForeign(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Export current part model to {0}", SourceFilePathResolvedValue);

        return descrip;
      }
    }

    private PartWindowExportFormat TessellatedFormat(string fileName)
    {
      var extn = Path.GetExtension(fileName);
      if (extn == null || !TessellatedFormats.ContainsKey(extn.ToLowerInvariant()))
      {
        return PartWindowExportFormat.Stl;
      }

      return TessellatedFormats[extn.ToLowerInvariant()];
    }

    private string TessellatedExtension(PartWindowExportFormat fmt)
    {
      return TessellatedFormats.First(x => x.Value == fmt).Key;
    }

    private bool IsBrepFormat(string fileName)
    {
      var extn = Path.GetExtension(fileName);
      if (extn == null)
      {
        return false;
      }

      return BrepFormats.ContainsKey(extn.ToLowerInvariant());
    }

    public override bool Run()
    {
      WriteBlock.AppendTask(() =>
                              {
                                if (IsBrepFormat(SourceFilePathResolvedValue))
                                {
                                  var extn = Path.GetExtension(SourceFilePathResolvedValue).ToLowerInvariant();
                                  var fmt = BrepFormats[extn];
                                  var opts = ExportOptions.Create();

                                  opts.ExportNames = true;
                                  opts.Step.ExportIdentifiers = true;

                                  Window.ActiveWindow.Document.MainPart.Export(fmt, SourceFilePathResolvedValue, true, opts);
                                }
                                else
                                {
                                  var fmt = TessellatedFormat(SourceFilePathResolvedValue);
                                  var extn = TessellatedExtension(fmt);
                                  var fileName = Path.ChangeExtension(SourceFilePathResolvedValue, extn);

                                  Window.ActiveWindow.ExportPart(fmt, fileName);
                                }
                              });

      return true;
    }
  }
}
