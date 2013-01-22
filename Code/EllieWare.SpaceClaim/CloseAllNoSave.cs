//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Common;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;

namespace EllieWare.SpaceClaim
{
  public class CloseAllNoSave : SpaceClaimMutableRunnableBase
  {
    public CloseAllNoSave() :
      base()
    {
    }

    public CloseAllNoSave(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Close all documents without saving");

        return descrip;
      }
    }

    protected override bool DoRun(Document doc)
    {
      while (Window.ActiveWindow != null)
      {
        Window.ActiveWindow.Close();
      }

      return true;
    }
  }
}
