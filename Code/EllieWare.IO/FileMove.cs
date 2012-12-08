using System;
using System.IO;
using System.Windows.Forms;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public class FileMove : FileCopy
  {
    public FileMove(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override string Description
    {
      get
      {
        var descrip = string.Format("Move {0} --> {1}", mSourceFilePath.Text, mDestinationFilePath.Text);

        return descrip;
      }
    }

    public override Control ConfigurationUserInterface
    {
      get
      {
        return this;
      }
    }

    public override bool Run()
    {
      try
      {
        File.Move(mSourceFilePath.Text, mDestinationFilePath.Text);
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
