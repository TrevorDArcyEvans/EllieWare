using System;
using System.IO;
using System.Windows.Forms;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public class DirectoryDelete : DirectoryBase
  {
    public DirectoryDelete(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      lblExists.Visible = mExists.Visible = false;
    }

    public override string Description
    {
      get
      {
        var descrip = string.Format("Delete {0} and any subdirectories and files", mDirectory.Text);

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
        Directory.Delete(mDirectory.Text, true);
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
