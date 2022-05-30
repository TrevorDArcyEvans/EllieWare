//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Zip
{
  public class AddToZip : DualItemIOBase
  {
    public AddToZip(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
    {
      mControl.SetSourceFileSelectorFilter(Common.FileExtensions.AllFilesFilter);
      mControl.SetDestinationFileSelectorFilter(Common.FileExtensions.ZipFilesFilter);
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Add {0} to {1}", mControl.SourceFilePathResolvedValue, mControl.DestinationFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      using (var zip = Ionic.Zip.ZipFile.Read(mControl.DestinationFilePathResolvedValue))
      {
        zip.AddFile(mControl.SourceFilePathResolvedValue);
        zip.Save();
      }

      return true;
    }
  }
}
