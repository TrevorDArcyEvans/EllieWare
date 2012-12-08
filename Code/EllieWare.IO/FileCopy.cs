using System;
using System.IO;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public class FileCopy : DualItemIOBase
  {
    public FileCopy(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, true)
    {
    }

    public override string Description
    {
      get
      {
        var descrip = string.Format("Copy {0} --> {1}", mSourceFilePath.Text, mDestinationFilePath.Text);

        return descrip;
      }
    }

    public override bool Run()
    {
      try
      {
        File.Copy(mSourceFilePath.Text, mDestinationFilePath.Text);
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
