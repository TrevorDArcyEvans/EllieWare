//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Xml;
using EllieWare.Common;

namespace EllieWare.Pdf
{
  public partial class PrintCtrl : SingleItemIOBaseCtrl
  {
    public PrintCtrl()
    {
      InitializeComponent();

      PrintMain.BringToFront();

      Printers.Items.Clear();
      foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
      {
        Printers.Items.Add(printer);
      }

      SetSourceFileSelectorFilter(FileExtensions.PdfFilesFilter);
    }

    public override void ReadXml(XmlReader reader)
    {
      base.ReadXml(reader);

      var storedPrinter = reader.GetAttribute("Printer");
      var index = Printers.Items.IndexOf(storedPrinter);
      Printers.SelectedIndex = index;
    }

    public override void WriteXml(XmlWriter writer)
    {
      base.WriteXml(writer);

      writer.WriteAttributeString("Printer", Printers.Text);
    }

    private void Printers_SelectedIndexChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }
  }
}
