//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Linq;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;
using SpaceClaim.Api.V10.Modeler;

namespace EllieWare.SpaceClaim
{
  public class FaceSliverRemove : FaceSliverColor
  {
    public FaceSliverRemove()
    {
      ColorLabel.Visible = ColorSwatch.Visible = false;
    }

    public FaceSliverRemove(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      ColorLabel.Visible = ColorSwatch.Visible = false;
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Remove all faces above {0} aspect ratio",
                        AreaThreshold.Value);

        return descrip;
      }
    }

    protected override void DoRun()
    {
      var bodyAndFaces = GetFacesBelowThreshold(Window.ActiveWindow.Document, IsSliverFace);
      foreach (var desDody in bodyAndFaces.Keys)
      {
        var modFaces = from desFace in bodyAndFaces[desDody] select desFace.Shape;
        desDody.Shape.DeleteFaces(modFaces.ToList(), RepairAction.GrowSurrounding);
      }
    }
  }
}
