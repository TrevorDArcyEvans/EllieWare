//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Zip
{
  public class ZipFile : DualItemIOBase
  {
    public ZipFile(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
    {
      SetSourceFileSelectorFilter(Common.FileExtensions.AllFilesFilter);
      SetDestinationFileSelectorFilter(Common.FileExtensions.ZipFilesFilter);
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Compress {0} into {1}",
                        SourceFilePathResolvedValue,
                        DestinationFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      using (var zip = new Ionic.Zip.ZipFile(DestinationFilePathResolvedValue))
      {
        zip.AddFile(SourceFilePathResolvedValue);
        zip.Save();
      }

      return true;
    }
  }
}
