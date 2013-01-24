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
  public class FaceAreaColor : FaceAreaBase
  {
    public FaceAreaColor()
    {
    }

    public FaceAreaColor(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      AreaUnits.Text = string.Format("{0}^2", (Window.ActiveWindow != null) ? Window.ActiveWindow.Units.Length.Symbol : "mm");
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Change color of all faces below {0} {1}^2 to {2}",
                        AreaThreshold.Value,
                        Window.ActiveWindow.Units.Length.Symbol,
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
