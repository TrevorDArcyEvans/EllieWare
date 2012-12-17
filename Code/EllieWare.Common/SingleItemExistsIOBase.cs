using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public class SingleItemExistsIOBase : DualItemIOBase
  {
    public SingleItemExistsIOBase()
    {
    }

    public SingleItemExistsIOBase(object root, ICallback callback, IParameterManager mgr, BrowserTypes browsers) :
      base(root, callback, mgr, browsers)
    {
      SetDestinationVisible(false);
      SetExistsVisible(true);
    }
  }
}
