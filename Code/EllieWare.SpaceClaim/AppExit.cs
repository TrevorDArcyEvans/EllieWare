//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;
using Application = SpaceClaim.Api.V10.Application;

namespace EllieWare.SpaceClaim
{
  public class AppExit : SpaceClaimMutableRunnableBase
  {
    public AppExit()
    {
    }

    public AppExit(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Exit SpaceClaim");

        return descrip;
      }
    }

    protected override bool DoRun(Document doc)
    {
      Application.Exit();

      return true;
    }
  }
}
