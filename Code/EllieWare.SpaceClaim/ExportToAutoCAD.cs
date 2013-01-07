//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.IO;
using EllieWare.Common;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;

namespace EllieWare.SpaceClaim
{
  public class ExportToAutoCAD : SingleItemIOBase
  {
    public ExportToAutoCAD()
    {
    }

    public ExportToAutoCAD(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
    {
      SetSourceFileSelectorFilter(Utils.WindowVectorExportFilter);
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Export drawing sheet to {0}", SourceFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      WriteBlock.AppendTask(() =>
                              {
                                var fileName = SourceFilePathResolvedValue;
                                WindowExportFormat fmt;
                                var extn = Path.GetExtension(fileName);
                                if (extn == null || !Utils.VectorFormats.ContainsKey(extn.ToLowerInvariant()))
                                {
                                  fmt = WindowExportFormat.AutoCadDwg;
                                }
                                else
                                {
                                  fmt = Utils.VectorFormats[extn.ToLowerInvariant()];
                                }

                                Window.ActiveWindow.Export(fmt, fileName);
                              });

      return true;
    }
  }
}
