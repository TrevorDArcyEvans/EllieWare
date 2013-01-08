//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using System.Linq;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;
using SpaceClaim.Api.V10.Modeler;

namespace EllieWare.SpaceClaim
{
  public class FaceAreaRemove : FaceAreaColor
  {
    public FaceAreaRemove()
    {
      ColorLabel.Visible = ColorSwatch.Visible = false;
    }

    public FaceAreaRemove(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      ColorLabel.Visible = ColorSwatch.Visible = false;
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Remove all faces below {0} {1}^2", 
                        AreaThreshold.Value, 
                        Window.ActiveWindow.Units.Length.Symbol);

        return descrip;
      }
    }

    public override bool Run()
    {
      WriteBlock.AppendTask(() =>
                              {
                                var bodyAndFaces = GetFacesBelowThreshold(Window.ActiveWindow.Document, (double)AreaThreshold.Value);
                                foreach (var desDody in bodyAndFaces.Keys)
                                {
                                  var modFaces = from desFace in bodyAndFaces[desDody] select desFace.Shape;
                                  desDody.Shape.DeleteFaces(modFaces.ToList(), RepairAction.GrowSurrounding);
                                }
                              });

      return true;
    }
  }
}
