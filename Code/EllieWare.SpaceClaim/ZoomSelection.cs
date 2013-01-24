//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;

namespace EllieWare.SpaceClaim
{
  public class ZoomSelection : SpaceClaimMutableRunnableBase
  {
    public ZoomSelection()
    {
    }

    public ZoomSelection(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Zoom the current view to the selection");

        return descrip;
      }
    }

    protected override bool DoRun()
    {
      Window.ActiveWindow.ZoomSelection();
      Common.Utils.Wait(3000);

      return true;
    }
  }
}
