//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;

namespace EllieWare.SpaceClaim
{
  public class FaceCurvatureRemove : FaceCurvatureBase
  {
    public FaceCurvatureRemove()
    {
      ColorLabel.Visible = ColorSwatch.Visible = false;
    }

    public FaceCurvatureRemove(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      ColorLabel.Visible = ColorSwatch.Visible = false;
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Remove all faces with a curvature below {0} {1}",
                        AreaThreshold.Value,
                        (Window.ActiveWindow != null) ? Window.ActiveWindow.Units.Length.Symbol : "mm");

        return descrip;
      }
    }

    protected override bool ProcessFaces(Dictionary<DesignBody, IEnumerable<DesignFace>> smallFaces)
    {
      return RemoveFaces(smallFaces);
    }
  }
}
