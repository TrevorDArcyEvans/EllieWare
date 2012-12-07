using System;
using System.IO;
using System.Windows.Forms;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public class DirectoryMove : DirectoryCopy
  {
    public DirectoryMove()
    {
    }

    public DirectoryMove(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override string Description
    {
      get
      {
        var descrip = string.Format("Move {0} --> {1} including subdirectories", mSourceFilePath.Text, mDestinationFilePath.Text);

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
        Directory.Move(mSourceFilePath.Text, mDestinationFilePath.Text);
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
