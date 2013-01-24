//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Threading;
using EllieWare.Common;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;

namespace EllieWare.SpaceClaim
{
  public abstract class SpaceClaimMutableRunnableBase : MutableRunnableBase
  {
    public SpaceClaimMutableRunnableBase()
    {
    }

    public SpaceClaimMutableRunnableBase(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    protected abstract bool DoRun();

    public override bool CanRun
    {
      get
      {
        // most functions require a document
        return Window.ActiveWindow != null;
      }
    }

    public override sealed bool Run()
    {
      var evt = new AutoResetEvent(false);
      var retVal = false;

      WriteBlock.AppendTask(() =>
        {
          try
          {
            retVal = DoRun();
          }
          finally
          {
            evt.Set();
          }
        });

      return evt.WaitOne(60000) && retVal;
    }
  }
}
