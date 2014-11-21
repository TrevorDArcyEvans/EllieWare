//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//

using EllieWare.Common;
using EllieWare.Interfaces;
using SolidWorks.Interop.sldworks;

namespace EllieWare.SolidWorks
{
  public class Exit : MutableRunnableBase<NullCtrl>
  {
    public Exit()
    {
    }

    public Exit(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override bool Run()
    {
      var pSW = (ISldWorks)mRoot.ApplicationRoot;

      pSW.ExitApp();

      return true;
    }
  }
}
