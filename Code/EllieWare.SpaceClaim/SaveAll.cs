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
  public class SaveAll : SpaceClaimMutableRunnableBase
  {
    public SaveAll() :
      base()
    {
    }

    public SaveAll(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Save all documents");

        return descrip;
      }
    }

    protected override bool DoRun()
    {
      foreach (var window in Window.AllWindows)
      {
        window.Document.Save();
      }

      return true;
    }
  }
}
