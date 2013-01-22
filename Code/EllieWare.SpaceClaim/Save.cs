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
  public class Save : SpaceClaimMutableRunnableBase
  {
    public Save() :
      base()
    {
    }

    public Save(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Save the current document");

        return descrip;
      }
    }

    protected override bool DoRun(Document doc)
    {
      Window.ActiveWindow.Document.Save();

      return true;
    }
  }
}
