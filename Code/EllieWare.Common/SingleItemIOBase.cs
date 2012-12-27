//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public class SingleItemIOBase : SingleItemExistsIOBase
  {
    public SingleItemIOBase()
    {
    }

    public SingleItemIOBase(object root, ICallback callback, IParameterManager mgr, BrowserTypes browsers) :
      base(root, callback, mgr, browsers)
    {
      SetExistsVisible(false);
    }
  }
}
