using System;
using System.IO;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public class DirectoryCreate : SingleItemIOBase
  {
    public DirectoryCreate(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, false)
    {
    }

    public override string Description
    {
      get
      {
        var descrip = string.Format("Create {0}", mSourceFilePath.Text);

        return descrip;
      }
    }

    public override bool Run()
    {
      try
      {
        Directory.CreateDirectory(mSourceFilePath.Text);
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
