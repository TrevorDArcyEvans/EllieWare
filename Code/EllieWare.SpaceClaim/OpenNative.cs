//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Linq;
using System.Threading;
using EllieWare.Common;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;

namespace EllieWare.SpaceClaim
{
  public class OpenNative : SpaceClaimSingleItemIOBase
  {
    public OpenNative()
    {
    }

    public OpenNative(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
    {
      SetSourceFileSelectorFilter(Utils.NativeFilter);
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Open {0}", SourceFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool CanRun
    {
      get
      {
        return true;
      }
    }

    protected override bool DoRun()
    {
      // if file is already open, then Document.DocumentCompleted event is never fired
      var windows = Document.Open(SourceFilePathResolvedValue, null);

      Window.ActiveWindow = windows.First();

      return true;
    }
  }
}
