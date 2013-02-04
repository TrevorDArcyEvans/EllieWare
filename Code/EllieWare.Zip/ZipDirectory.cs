//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.IO;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Zip
{
  public class ZipDirectory : DualItemIOBase
  {
    public ZipDirectory(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.DirectoryFile)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Compress {0} and all subdirectories to {1}", 
                        SourceFilePathResolvedValue,
                        DestinationFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      var zipFileName = Path.ChangeExtension(DestinationFilePathResolvedValue, ".zip");
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
