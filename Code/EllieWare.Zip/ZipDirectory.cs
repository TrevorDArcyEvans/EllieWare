﻿//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using System.IO;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Zip
{
  public class ZipDirectory : SingleItemIOBase
  {
    public ZipDirectory(IEnumerable<object> roots, ICallback callback, IParameterManager mgr) :
      base(roots, callback, mgr, BrowserTypes.BothDirectory)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Compress {0} and all subdirectories to a zip file", SourceFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      var zipFileName = Path.ChangeExtension(SourceFilePathResolvedValue, ".zip");
      using (var zip = new Ionic.Zip.ZipFile(zipFileName))
      {
        var files = Directory.EnumerateFiles(SourceFilePathResolvedValue, "*", SearchOption.AllDirectories);
        zip.AddFiles(files);
        zip.Save();
      }

      return true;
    }
  }
}
