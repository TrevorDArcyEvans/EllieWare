//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
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
