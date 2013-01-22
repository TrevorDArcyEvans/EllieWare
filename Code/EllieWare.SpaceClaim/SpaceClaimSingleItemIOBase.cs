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
  public class SpaceClaimSingleItemIOBase : SingleItemIOBase
  {
    public SpaceClaimSingleItemIOBase()
    {
    }

    public SpaceClaimSingleItemIOBase(IRobotWare root, ICallback callback, IParameterManager mgr, BrowserTypes browsers) :
      base(root, callback, mgr, browsers)
    {
    }

    protected virtual bool CanDoRun(Document doc)
    {
      return true;
    }

    protected virtual bool DoRun(Document doc)
    {
      throw new NotImplementedException();
    }

    public override sealed bool Run()
    {
      var doc = Window.ActiveWindow.Document;
      if (!CanDoRun(doc))
      {
        return false;
      }

      var evt = new AutoResetEvent(false);
      var retVal = false;

      WriteBlock.AppendTask(() =>
        {
          try
          {
            retVal = DoRun(doc);
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
