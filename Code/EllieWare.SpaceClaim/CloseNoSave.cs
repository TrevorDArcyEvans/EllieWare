//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Threading;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;

namespace EllieWare.SpaceClaim
{
  public class CloseNoSave : SpaceClaimMutableRunnableBase
  {
    public CloseNoSave() :
      base()
    {
    }

    public CloseNoSave(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Close the current document without saving");

        return descrip;
      }
    }

    protected override bool DoRun()
    {
      var evt = new AutoResetEvent(false);
      var doc = Window.ActiveWindow.Document;

      doc.Closed += (s, e) => evt.Set();

      var allWindows = Window.GetWindows(doc);
      foreach (var thisWindow in allWindows)
      {
        thisWindow.Close();
      }

      return evt.WaitOne(60 * 1000);
    }
  }
}
