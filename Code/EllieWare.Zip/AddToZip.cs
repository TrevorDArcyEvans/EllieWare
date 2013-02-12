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
      SetSourceFileSelectorFilter(Common.FileExtensions.AllFilesFilter);
      SetDestinationFileSelectorFilter(Common.FileExtensions.ZipFilesFilter);
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Add {0} to {1}", SourceFilePathResolvedValue, DestinationFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      using (var zip = Ionic.Zip.ZipFile.Read(DestinationFilePathResolvedValue))
      {
        zip.AddFile(SourceFilePathResolvedValue);
        zip.Save();
      }

      return true;
    }
  }
}
