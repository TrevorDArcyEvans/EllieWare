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
  public class SingleItemIOBase : MutableRunnableBase<SingleItemIOBaseCtrl>
  {
    public SingleItemIOBase()
    {
    }

    public SingleItemIOBase(IRobotWare root, ICallback callback, IParameterManager mgr, BrowserTypes browsers) :
      base(root, callback, mgr)
    {
      mControl.Initialise(root, callback, mgr, browsers);
    }
  }
}
