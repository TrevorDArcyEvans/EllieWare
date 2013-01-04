//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace EllieWare.Pdf
{
  public partial class Concatenate : DualItemIOBase
  {
    public Concatenate()
    {
      InitializeComponent();

      ConcatenateMain.BringToFront();
    }

    public Concatenate(IEnumerable<object> roots, ICallback callback, IParameterManager mgr) :
      base(roots, callback, mgr, BrowserTypes.BothFile)
    {
      InitializeComponent();

      ConcatenateMain.BringToFront();

      SetSourceLabel("File 1:");
      SetDestinationLabel("File 2:");

      SetSourceFileSelectorFilter(Utils.PdfFilesFilter);
      SetDestinationFileSelectorFilter(Utils.PdfFilesFilter);
      OutputFileSelector.Filter = Utils.PdfFilesFilter;
    }

    public override void ReadXml(XmlReader reader)
    {
      base.ReadXml(reader);

      mOutputFilePath.Text = reader.GetAttribute("OutputFilePath");
    }

    public override void WriteXml(XmlWriter writer)
    {
      base.WriteXml(writer);

      writer.WriteAttributeString("OutputFilePath", mOutputFilePath.Text);
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Join {0} to {1} and save it as {2}",
                        SourceFilePathResolvedValue,
                        DestinationFilePathResolvedValue,
                        mOutputFilePath.ResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      var files = new[] { SourceFilePathResolvedValue, DestinationFilePathResolvedValue };

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
      outputDocument.Save(mOutputFilePath.ResolvedValue);

      return true;
    }

    private void OutputFilePath_TextChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void CmdOutputBrowse_Click(object sender, EventArgs e)
    {
      if (OutputFileSelector.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      mOutputFilePath.Text = OutputFileSelector.FileName;
    }
  }
}
