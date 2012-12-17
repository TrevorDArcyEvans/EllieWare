using System;
using EllieWare.Common;
using EllieWare.Interfaces;
using Ionic.Zip;

namespace EllieWare.Zip
{
  public class UnZipFile : DualItemIOBase
  {
    public UnZipFile(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.FileDirectory)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Uncompress {0} to {1}", SourceFilePathResolvedValue, DestinationFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      using (var zip = Ionic.Zip.ZipFile.Read(SourceFilePathResolvedValue))
      {
        zip.ExtractExistingFile = ExtractExistingFileAction.OverwriteSilently;
        zip.ExtractAll(DestinationFilePathResolvedValue);
      }

      return true;
    }
  }
}
