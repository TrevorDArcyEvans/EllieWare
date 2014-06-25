//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Common;
using EllieWare.Interfaces;
using Ionic.Zip;

namespace EllieWare.Zip
{
  public class UnZipFile : DualItemIOBase
  {
    public UnZipFile(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.FileDirectory)
    {
      mControl.SetSourceFileSelectorFilter(Common.FileExtensions.ZipFileExtension);
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Uncompress {0} to {1}",
                        mControl.SourceFilePathResolvedValue,
                        mControl.DestinationFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      using (var zip = Ionic.Zip.ZipFile.Read(mControl.SourceFilePathResolvedValue))
      {
        zip.ExtractExistingFile = ExtractExistingFileAction.OverwriteSilently;
        zip.ExtractAll(mControl.DestinationFilePathResolvedValue);
      }

      return true;
    }
  }
}
