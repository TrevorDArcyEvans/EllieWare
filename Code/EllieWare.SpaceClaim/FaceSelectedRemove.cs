//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
using System;
using System.Linq;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;
using SpaceClaim.Api.V10.Modeler;

namespace EllieWare.SpaceClaim
{
  public class FaceSelectedRemove : SpaceClaimMutableRunnableBase
  {
    public FaceSelectedRemove()
    {
    }

    public FaceSelectedRemove(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Remove selected faces");

        return descrip;
      }
    }

    protected override bool DoRun()
    {
      var totalFaces = 0;
      var successfulFaces = 0;
      var ctx = Window.ActiveWindow.ActiveContext;
      var selection = ctx.Selection;
      var desFaces = selection.OfType<DesignFace>();
      var modFaces = from thisDesFace in desFaces select thisDesFace.Shape;
      foreach (var thisModFace in modFaces)
      {
        totalFaces++;
        try
        {
          var desBody = thisModFace.Body;
          desBody.DeleteFaces(new[] { thisModFace }, RepairAction.GrowSurrounding);
          successfulFaces++;
        }
        catch (InvalidOperationException)
        {
          // Body.DeleteFaces() throws InvalidOperationException on failure
          // swallow exception as deleting faces is a difficult operation
        }
      }

      mCallback.Log(LogLevel.Information, string.Format("Removed {0} / {1} faces", successfulFaces, totalFaces));

      return true;
    }
  }
}
