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
using Microsoft.Win32;
using PdfSharp.Pdf.Printing;

namespace EllieWare.Pdf
{
  public class Print : MutableRunnableBase<PrintCtrl>
  {
    public Print()
    {
    }

    public Print(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      mControl.Initialise(root, callback, mgr, BrowserTypes.BothFile);
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Print {0} to {1}", mControl.SourceFilePathResolvedValue, mControl.Printers.Text);

        return descrip;
      }
    }

    public override bool Run()
    {
      var adobe = Registry.LocalMachine.OpenSubKey("Software").OpenSubKey("Microsoft").OpenSubKey("Windows").OpenSubKey("CurrentVersion").OpenSubKey("App Paths").OpenSubKey("AcroRd32.exe");
      var path = (string)adobe.GetValue("");

      // remove parameters and quotes:
      //      "C:\Program Files (x86)\Adobe\Acrobat 10.0\Acrobat\Acrobat.exe" /u "%1"
      // see:
      //      http://stackoverflow.com/questions/10891939/how-to-get-adobe-reader-full-pathincluding-executable-file-name
      var adobeOtherWay = Registry.LocalMachine.OpenSubKey("Software").OpenSubKey("Classes").OpenSubKey("acrobat").OpenSubKey("shell").OpenSubKey("open").OpenSubKey("command");
      var quotedRegValueOtherWay = (string)adobeOtherWay.GetValue("");
      var quotedPathOtherWay = quotedRegValueOtherWay.Substring(0, quotedRegValueOtherWay.Length - " /u \"%1\"".Length);
      var pathOtherWay = quotedPathOtherWay.Remove(0, 1);
      pathOtherWay = pathOtherWay.Remove(pathOtherWay.Length - 1, 1);

      if (File.Exists(path))
      {
        PdfFilePrinter.AdobeReaderPath = path;
      }
      else if (File.Exists(pathOtherWay))
      {
        PdfFilePrinter.AdobeReaderPath = pathOtherWay;
      }
      else
      {
        mCallback.Log(LogLevel.Critical, "Adobe Acrobat Reader not found");

        return false;
      }

      var printer = new PdfFilePrinter(mControl.SourceFilePathResolvedValue, mControl.Printers.Text);

      try
      {
        printer.Print();
      }
      catch (Exception ex)
      {
        mCallback.Log(LogLevel.Critical, ex.Message);
      }

      return true;
    }
  }
}
