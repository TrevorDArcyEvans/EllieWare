using System;
using System.IO;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public class FileDelete : SingleItemIOBase
  {
    public FileDelete(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, true)
    {
    }

    public override string Description
    {
      get
      {
        var descrip = string.Format("Delete {0}", mSourceFilePath.Text);

        return descrip;
      }
    }

    public override bool Run()
    {
      try
      {
        File.Delete(mSourceFilePath.Text);
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
