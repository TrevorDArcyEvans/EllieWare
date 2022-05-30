﻿//
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
  public class SpaceClaimSingleItemIOBase : SingleItemIOBase
  {
    public SpaceClaimSingleItemIOBase()
    {
    }

    public SpaceClaimSingleItemIOBase(IRobotWare root, ICallback callback, IParameterManager mgr, BrowserTypes browsers) :
      base(root, callback, mgr, browsers)
    {
    }

    public override bool CanRun
    {
      get
      {
        // export functions require a document
        // import functions do not require a document
        return Window.ActiveWindow != null;
      }
    }

    protected virtual bool DoRun()
    {
      throw new NotImplementedException();
    }

    public sealed override bool Run()
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
