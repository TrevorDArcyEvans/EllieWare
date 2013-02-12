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
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace EllieWare.Pdf
{
  public class Split : DualItemIOBase
  {
    public Split()
    {
    }

    public Split(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.FileDirectory)
    {
      SetSourceFileSelectorFilter(Common.FileExtensions.PdfFilesFilter);
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Split {0} into separate files and put them in {1}",
                        SourceFilePathResolvedValue, DestinationFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      // Open the file
      var inputDocument = PdfReader.Open(SourceFilePathResolvedValue, PdfDocumentOpenMode.Import);

      var name = Path.GetFileNameWithoutExtension(SourceFilePathResolvedValue);
      for (var idx = 0; idx < inputDocument.PageCount; idx++)
      {
        // Create new document
        var outputDocument = new PdfDocument { Version = inputDocument.Version };

        outputDocument.Info.Title = string.Format("Page {0} of {1}", idx + 1, inputDocument.Info.Title);
        outputDocument.Info.Creator = inputDocument.Info.Creator;

        // Add the page and save it
        outputDocument.AddPage(inputDocument.Pages[idx]);
        outputDocument.Save(Path.Combine(DestinationFilePathResolvedValue, String.Format("{0} - Page {1}.pdf", name, idx + 1)));
      }

      return true;
    }
  }
}
