using EllieWare.Interfaces;

namespace EllieWare.Manager
{
  public interface ICallbackEx : ICallback
  {
    void Clear();
    void Show();
    bool AllowClose { get; set; }
  }
}
