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

namespace EllieWare.SpaceClaim
{
  public partial class ExportToPdf : SingleItemIOBase
  {
    public ExportToPdf()
    {
    }

    public ExportToPdf(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
    {
      SetSourceFileSelectorFilter(Utils.PdfFilesFilter);
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
                                if (!fileName.ToLowerInvariant().EndsWith(".pdf"))
                                {
                                  fileName = Path.ChangeExtension(fileName, ".pdf");

                                }
                                Window.ActiveWindow.ExportDrawingSheet(DrawingSheetWindowExportFormat.Pdf, fileName);
                              });

      return true;
    }
  }
}
