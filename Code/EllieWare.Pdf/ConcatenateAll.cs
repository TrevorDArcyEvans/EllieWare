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
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace EllieWare.Pdf
{
  public class ConcatenateAll : DualItemIOBase
  {
    public ConcatenateAll()
    {
    }

    public ConcatenateAll(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.DirectoryFile)
    {
      mControl.SetDestinationFileSelectorFilter(Common.FileExtensions.PdfFilesFilter);
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Join all PDF files in {0} and save them as {1}",
                        mControl.SourceFilePathResolvedValue,
                        mControl.DestinationFilePathResolvedValue);

        return descrip;
      }
    }

    public bool Run()
    {
      var files = Directory.EnumerateFiles(mControl.SourceFilePathResolvedValue, "*.pdf");

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
      outputDocument.Save(mControl.DestinationFilePathResolvedValue);

      return true;
    }
  }
}
