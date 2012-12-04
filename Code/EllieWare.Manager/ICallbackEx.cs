using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
