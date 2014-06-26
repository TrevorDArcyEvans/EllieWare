//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Imaging
{
  public abstract class ResizerBase : MutableRunnableBase<ResizerBaseCtrl>
  {
    public ResizerBase()
    {
    }

    public ResizerBase(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      mControl.Initialise(root, callback, mgr, BrowserTypes.BothFile);
    }
  }
}
