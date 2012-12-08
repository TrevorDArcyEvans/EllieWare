using System;
using System.IO;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public class DirectoryDelete : SingleItemIOBase
  {
    public DirectoryDelete(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, false)
    {
    }

    public override string Description
    {
      get
      {
        var descrip = string.Format("Delete {0} and any subdirectories and files", mSourceFilePath.Text);

        return descrip;
      }
    }

    public override bool Run()
    {
      try
      {
        Directory.Delete(mSourceFilePath.Text, true);
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
