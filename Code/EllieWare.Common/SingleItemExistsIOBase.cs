using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public class SingleItemExistsIOBase : DualItemIOBase
  {
    public SingleItemExistsIOBase(object root, ICallback callback, IParameterManager mgr, bool fileBased) :
      base(root, callback, mgr, fileBased)
    {
      mDestinationLabel.Visible = mDestinationFilePath.Visible = CmdDestinationBrowse.Visible = false;
    }
  }
}
