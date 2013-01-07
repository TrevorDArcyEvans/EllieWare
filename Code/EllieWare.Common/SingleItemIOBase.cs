//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public class SingleItemIOBase : SingleItemExistsIOBase
  {
    public SingleItemIOBase()
    {
    }

    public SingleItemIOBase(IRobotWare root, ICallback callback, IParameterManager mgr, BrowserTypes browsers) :
      base(root, callback, mgr, browsers)
    {
      SetExistsVisible(false);
    }
  }
}
