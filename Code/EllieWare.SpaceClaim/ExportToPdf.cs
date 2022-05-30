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
  public class ExportToPdf : SpaceClaimSingleItemIOBase
  {
    public ExportToPdf()
    {
    }

    public ExportToPdf(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
    {
      mControl.SetSourceFileSelectorFilter(Common.FileExtensions.PdfFilesFilter);
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Export drawing sheet to {0}", mControl.SourceFilePathResolvedValue);

        return descrip;
      }
    }

    protected override bool DoRun()
    {
      var fileName = mControl.SourceFilePathResolvedValue;
      if (!fileName.ToLowerInvariant().EndsWith(Common.FileExtensions.PdfFileExtension))
      {
        fileName = Path.ChangeExtension(fileName, Common.FileExtensions.PdfFileExtension);
      }
      Window.ActiveWindow.ExportDrawingSheet(DrawingSheetWindowExportFormat.Pdf, fileName);

      return true;
    }
  }
}
