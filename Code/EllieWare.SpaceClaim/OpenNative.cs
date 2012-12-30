//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using EllieWare.Common;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;

namespace EllieWare.SpaceClaim
{
  public class OpenNative : SingleItemIOBase
  {
    public OpenNative()
    {
    }

    public OpenNative(IEnumerable<object> roots, ICallback callback, IParameterManager mgr) :
      base(roots, callback, mgr, BrowserTypes.BothFile)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Open {0}", SourceFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      WriteBlock.AppendTask(() => Document.Open(SourceFilePathResolvedValue, null));

      return true;
    }
  }
}
