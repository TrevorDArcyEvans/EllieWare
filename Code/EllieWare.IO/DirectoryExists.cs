using System.IO;
using System.Windows.Forms;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public class DirectoryExists : DirectoryBase
  {
    public DirectoryExists(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override string Description
    {
      get
      {
        var exist = mExists.SelectedIndex == 1;
        var descrip = string.Format("Check that {0} is ", mDirectory.Text) + (exist ? "" : "not ") + "present";

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
      var exist = mExists.SelectedIndex == 1;
      var dirExists = Directory.Exists(mDirectory.Text);

      return exist ? dirExists : !dirExists;
    }
  }
}
