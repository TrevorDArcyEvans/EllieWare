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
  public class FaceCurvatureColor : FaceCurvatureBase
  {
    public FaceCurvatureColor()
    {
    }

    public FaceCurvatureColor(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Change the color of all faces with a curvature below {0} {1} to {2}",
                        AreaThreshold.Value,
                        (Window.ActiveWindow != null) ? Window.ActiveWindow.Units.Length.Symbol : "mm",
                        ColorDlg.Color);

        return descrip;
      }
    }

    protected override bool ProcessFaces(Dictionary<DesignBody, IEnumerable<DesignFace>> smallFaces)
    {
      return ColorFaces(smallFaces);
    }
  }
}
