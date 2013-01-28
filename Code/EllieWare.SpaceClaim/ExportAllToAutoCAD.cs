//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
    }

    public ExportAllToAutoCAD(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
    {
      InitializeComponent();

      SetSourceFileSelectorFilter(Utils.WindowVectorExportFilter);
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
      var fileName = SourceFilePathResolvedValue;
      WindowExportFormat fmt;
      var extn = Path.GetExtension(fileName);
      if (extn == null || !Utils.VectorFormats.ContainsKey(extn.ToLowerInvariant()))
      {
        fmt = WindowExportFormat.AutoCadDwg;
      }
      else
      {
        fmt = Utils.VectorFormats[extn.ToLowerInvariant()];
      }

      Window.ActiveWindow.Export(fmt, fileName);

      return true;
    }
  }
}
