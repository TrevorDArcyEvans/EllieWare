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
  public class FaceAreaPercentColor : FaceAreaPercentBase
  {
    public FaceAreaPercentColor()
    {
    }

    public FaceAreaPercentColor(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Change color of all faces below {0}% of the largest face to {1}",
                        AreaThreshold.Value,
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
