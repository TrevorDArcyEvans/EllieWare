//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.IO;
using EllieWare.Common;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;

namespace EllieWare.SpaceClaim
{
  public class ExportAllToPdf : SpaceClaimSingleItemIOBase
  {
    public ExportAllToPdf()
    {
    }

    public ExportAllToPdf(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothDirectory)
    {
      SetSourceFileSelectorFilter(Common.FileExtensions.PdfFilesFilter);
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Export all drawing sheets to {0}", SourceFilePathResolvedValue);

        return descrip;
      }
    }

    protected override bool DoRun()
    {
      var doc = Window.ActiveWindow.Document;
      var fileName = Path.GetFileNameWithoutExtension(doc.Path ?? "Drawing");
      var idx = 1;
      var allSheets = doc.DrawingSheets;
      foreach (var drawingSheet in allSheets)
      {
        using (new AutoWindow(Window.Create(drawingSheet)))
        {
          var drawingFileNameNoExtn = String.Format("{0} - Sheet {1}", fileName, idx);
          var drawingFileName = Path.ChangeExtension(drawingFileNameNoExtn, Common.FileExtensions.PdfFileExtension);
          var outputFilePath = Path.Combine(SourceFilePathResolvedValue, drawingFileName);

          Window.ActiveWindow.ExportDrawingSheet(DrawingSheetWindowExportFormat.Pdf, outputFilePath);
        }
        idx++;
      }

      return true;
    }
  }
}
