using System;
using System.IO;
using System.Windows.Forms;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public class FileDelete : FileExists
  {
    public FileDelete(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      lblExists.Visible = mExists.Visible = false;
    }

    #region Implementation of IRunnable

    public override string Description
    {
      get
      {
        var descrip = string.Format("Delete {0}", mFilePath.Text);

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
        File.Delete(mFilePath.Text);
      }
      catch (Exception ex)
      {
        mCallback.Log(LogLevel.Critical, ex.Message);

        return false;
      }

      return true;
    }

    #endregion
  }
}
