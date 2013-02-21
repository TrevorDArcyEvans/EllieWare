//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Threading;
using EllieWare.Common;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;

namespace EllieWare.SpaceClaim
{
  public class SpaceClaimMutableRunnableBase : MutableRunnableBase
  {
    public SpaceClaimMutableRunnableBase()
    {
    }

    public SpaceClaimMutableRunnableBase(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    protected virtual bool DoRun()
    {
      throw new NotImplementedException();
    }

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

      return evt.WaitOne(60 * 1000) && retVal;
    }
  }
}
