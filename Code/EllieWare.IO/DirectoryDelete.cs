using System.IO;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public class DirectoryDelete : SingleItemIOBase
  {
    public DirectoryDelete()
    {
    }

    public DirectoryDelete(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothDirectory)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Delete {0} and any subdirectories and files", SourceFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      Directory.Delete(SourceFilePathResolvedValue, true);

      return true;
    }
  }
}
