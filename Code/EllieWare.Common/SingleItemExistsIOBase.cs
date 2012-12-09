using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public class SingleItemExistsIOBase : DualItemIOBase
  {
    public SingleItemExistsIOBase(object root, ICallback callback, IParameterManager mgr, BrowserTypes browsers) :
      base(root, callback, mgr, browsers)
    {
      mDestinationLabel.Visible = mDestinationFilePath.Visible = CmdDestinationBrowse.Visible = false;
      mExistsLabel.Visible = mExists.Visible = true;
    }
  }
}
