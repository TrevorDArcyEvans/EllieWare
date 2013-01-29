//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;

namespace EllieWare.SpaceClaim
{
  public partial class ExportAllToAutoCAD : SpaceClaimSingleItemIOBase
  {
    public ExportAllToAutoCAD()
    {
      InitializeComponent();

      ExportMain.BringToFront();
    }

    public ExportAllToAutoCAD(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothDirectory)
    {
      InitializeComponent();

      ExportMain.BringToFront();

      SetSourceLabel("Directory:");

      FileFormat.Items.Clear();
      FileFormat.Items.AddRange(new object[] { "AutoCAD DWG files (*.dwg)", "AutoCAD DXF files (*.dxf)" });
      FileFormat.SelectedIndex = 0;
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Export all drawing sheets to {0}", SourceFilePathResolvedValue);

        return descrip;
      }
    }

    public override void ReadXml(XmlReader reader)
    {
      base.ReadXml(reader);

      var numStr = reader.GetAttribute("FileFormat");
      var num = int.Parse(numStr, NumberStyles.Integer, CultureInfo.InvariantCulture);
      FileFormat.SelectedIndex = num;
    }

    public override void WriteXml(XmlWriter writer)
    {
      base.WriteXml(writer);

      writer.WriteAttributeString("FileFormat", FileFormat.SelectedIndex.ToString(CultureInfo.InvariantCulture));
    }

    public override Control ConfigurationUserInterface
    {
      get
      {
        return this;
      }
    }

    protected override bool DoRun()
    {
      var fmt = FileFormat.SelectedIndex == 0 ? WindowExportFormat.AutoCadDwg : WindowExportFormat.AutoCadDxf;
      var fileExtn = (from extn in Utils.VectorFormats.Keys where Utils.VectorFormats[extn] == fmt select extn).Single();
      var doc = Window.ActiveWindow.Document;
      var fileName = Path.GetFileNameWithoutExtension(doc.Path ?? "Drawing");
      var idx = 1;
      var allSheets = doc.DrawingSheets;
      foreach (var drawingSheet in allSheets)
      {
        using (new AutoWindow(Window.Create(drawingSheet)))
        {
          var drawingFileNameNoExtn = String.Format("{0} - Sheet {1}", fileName, idx);
          var drawingFileName = Path.ChangeExtension(drawingFileNameNoExtn, fileExtn);
          var outputFilePath = Path.Combine(SourceFilePathResolvedValue, drawingFileName);

          Window.ActiveWindow.Export(fmt, outputFilePath);
        }
        idx++;
      }

      return true;
    }
  }
}
