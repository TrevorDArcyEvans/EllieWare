using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public class SingleItemIOBase : SingleItemExistsIOBase
  {
    public SingleItemIOBase(object root, ICallback callback, IParameterManager mgr, bool fileBased) :
      base(root, callback, mgr, fileBased)
    {
      mExistsLabel.Visible = mExists.Visible =  false;
    }
  }
}
