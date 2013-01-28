//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using System.IO;
using EllieWare.Common;
using EllieWare.Interfaces;
using EllieWare.Support;
using SpaceClaim.Api.V10;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace EllieWare.SpaceClaim
{
  public class ExportAllToPdf : SpaceClaimSingleItemIOBase
  {
    public ExportAllToPdf()
    {
    }

    public ExportAllToPdf(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
    {
      SetSourceFileSelectorFilter(Utils.PdfFilesFilter);
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
      // create PDFs of all drawing sheets in temp area
      var files = new List<string>();
      var allSheets = Window.ActiveWindow.Document.DrawingSheets;
      foreach (var drawingSheet in allSheets)
      {
        var tempFileName = Path.GetTempFileName();
        File.Delete(tempFileName);

        // Window.ExportDrawingSheet automatically adds .pdf extension
        tempFileName = Path.ChangeExtension(tempFileName, Utils.PdfFileExtension);

        using (new AutoWindow(Window.Create(drawingSheet)))
        {
          Window.ActiveWindow.ExportDrawingSheet(DrawingSheetWindowExportFormat.Pdf, tempFileName);
          files.Add(tempFileName);
        }
      }

      // add PDF file extension if needed
      var fileName = SourceFilePathResolvedValue;
      if (!fileName.ToLowerInvariant().EndsWith(Utils.PdfFileExtension))
      {
        fileName = Path.ChangeExtension(fileName, Utils.PdfFileExtension);
      }

      // Open the output document
      var outputDocument = new PdfDocument();

      // Iterate files
      foreach (var file in files)
      {
        using (new AutoFile(file))
        {
          // Open the document to import pages from it.
          using (var inputDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import))
          {
            // Iterate pages
            var count = inputDocument.PageCount;
            for (var idx = 0; idx < count; idx++)
            {
              // Get the page from the external document...
              var page = inputDocument.Pages[idx];

              // ...and add it to the output document.
              outputDocument.AddPage(page);
            }
          }
        }
      }

      // Save the document...
      outputDocument.Save(fileName);

      return true;
    }
  }
}
