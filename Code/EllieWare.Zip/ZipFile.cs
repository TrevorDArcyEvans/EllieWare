using System;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Zip
{
  public class ZipFile : SingleItemIOBase
  {
    public ZipFile(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, true)
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
        //File.Delete(mSourceFilePath.Text);
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
