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
  public class SingleItemExistsIOBase : DualItemIOBase
  {
    public SingleItemExistsIOBase()
    {
    }

    public SingleItemExistsIOBase(IRobotWare root, ICallback callback, IParameterManager mgr, BrowserTypes browsers) :
      base(root, callback, mgr, browsers)
    {
      SetDestinationVisible(false);
      SetExistsVisible(true);
    }
  }
}
