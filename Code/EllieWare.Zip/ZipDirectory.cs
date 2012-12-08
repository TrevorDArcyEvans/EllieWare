using System;
using System.IO;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Zip
{
  public class ZipDirectory : SingleItemIOBase
  {
    public ZipDirectory(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, false)
    {
    }

    public override string Description
    {
      get
      {
        var descrip = string.Format("Compress {0} and all subdirectories to a zip file", mSourceFilePath.Text);

        return descrip;
      }
    }

    public override bool Run()
    {
      try
      {
        var zipFileName = Path.ChangeExtension(mSourceFilePath.Text, ".zip");
        var zip = new Ionic.Zip.ZipFile(zipFileName);
        var files = Directory.EnumerateFiles(mSourceFilePath.Text, "*", SearchOption.AllDirectories);
        zip.AddFiles(files);
        zip.Save();
      }
      catch (Exception ex)
      {
        mCallback.Log(LogLevel.Critical, ex.Message);

        return false;
      }

      return true;
    }
  }
}
