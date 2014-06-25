//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
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

    private void Printers_SelectedIndexChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }
  }
}
