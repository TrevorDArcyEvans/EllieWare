using System.IO;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public class DirectoryExists : SingleItemExistsIOBase
  {
    public DirectoryExists(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, false)
    {
    }

    public override string Description
    {
      get
      {
        var exist = mExists.SelectedIndex == 1;
        var descrip = string.Format("Check that {0} is ", mSourceFilePath.Text) + (exist ? "" : "not ") + "present";

        return descrip;
      }
    }

    public override bool Run()
    {
      var exist = mExists.SelectedIndex == 1;
      var dirExists = Directory.Exists(mSourceFilePath.Text);

      return exist ? dirExists : !dirExists;
    }
  }
}
