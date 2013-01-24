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
  public class FaceAreaPercentSelect : FaceAreaPercentBase
  {
    public FaceAreaPercentSelect() :
      base()
    {
      ColorLabel.Visible = ColorSwatch.Visible = false;
    }

    public FaceAreaPercentSelect(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      ColorLabel.Visible = ColorSwatch.Visible = false;
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Select all faces below {0}% of the largest face", AreaThreshold.Value);

        return descrip;
      }
    }

    protected override bool ProcessFaces(Dictionary<DesignBody, IEnumerable<DesignFace>> smallFaces)
    {
      return SelectFaces(smallFaces);
    }
  }
}
