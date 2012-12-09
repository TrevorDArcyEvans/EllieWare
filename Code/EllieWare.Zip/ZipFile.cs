using System;
using System.IO;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Zip
{
  public class ZipFile : SingleItemIOBase
  {
    public ZipFile(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
    {
    }

    public override string Description
    {
      get
      {
        var descrip = string.Format("Compress {0} to a zip file", mSourceFilePath.Text);

        return descrip;
      }
    }

    public override bool Run()
    {
      try
      {
        var zipFileName = Path.ChangeExtension(mSourceFilePath.Text, ".zip");
        var zip = new Ionic.Zip.ZipFile(zipFileName);
        zip.AddFile(mSourceFilePath.Text);
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
