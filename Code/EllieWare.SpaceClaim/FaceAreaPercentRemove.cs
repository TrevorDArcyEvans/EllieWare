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
  public class FaceAreaPercentRemove : FaceAreaPercentBase
  {
    public FaceAreaPercentRemove() :
      base()
    {
      ColorLabel.Visible = ColorSwatch.Visible = false;
    }

    public FaceAreaPercentRemove(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      ColorLabel.Visible = ColorSwatch.Visible = false;
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Remove all faces below {0}% of the largest face", AreaThreshold.Value);

        return descrip;
      }
    }

    protected override void ProcessFaces(Dictionary<DesignBody, IEnumerable<DesignFace>> smallFaces)
    {
      RemoveFaces(smallFaces);
    }
  }
}
