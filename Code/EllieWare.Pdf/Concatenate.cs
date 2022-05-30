//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Common;
using EllieWare.Interfaces;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace EllieWare.Pdf
{
  public class Concatenate : MutableRunnableBase<ConcatenateCtrl>
  {
    public Concatenate()
    {
    }

    public Concatenate(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      mControl.Initialise(root, callback, mgr, BrowserTypes.BothFile);

      mControl.mSourceLabel.Text = @"File 1:";
      mControl.mDestinationLabel.Text = @"File 2:";

      mControl.SourceFileSelector.Filter = Common.FileExtensions.PdfFilesFilter;
      mControl.DestinationFileSelector.Filter = Common.FileExtensions.PdfFilesFilter;
      mControl.OutputFileSelector.Filter = Common.FileExtensions.PdfFilesFilter;
    }

    public override bool Run()
    {
      var files = new[] { mControl.SourceFilePathResolvedValue, mControl.DestinationFilePathResolvedValue };

      // Open the output document
      var outputDocument = new PdfDocument();

      // Iterate files
      foreach (var file in files)
      {
        // Open the document to import pages from it.
        var inputDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import);

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

      // Save the document...
      outputDocument.Save(mControl.mOutputFilePath.ResolvedValue);

      return true;
    }
  }
}
