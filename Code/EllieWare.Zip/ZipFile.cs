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
      mControl.SetSourceFileSelectorFilter(Common.FileExtensions.AllFilesFilter);
      mControl.SetDestinationFileSelectorFilter(Common.FileExtensions.ZipFilesFilter);
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Compress {0} into {1}",
                        mControl.SourceFilePathResolvedValue,
                        mControl.DestinationFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      using (var zip = new Ionic.Zip.ZipFile(mControl.DestinationFilePathResolvedValue))
      {
        zip.AddFile(mControl.SourceFilePathResolvedValue);
        zip.Save();
      }

      return true;
    }
  }
}
