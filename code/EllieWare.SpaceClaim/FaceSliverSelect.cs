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
  public class FaceSliverSelect : FaceSliverBase
  {
    public FaceSliverSelect() :
      base()
    {
      ColorLabel.Visible = ColorSwatch.Visible = false;
    }

    public FaceSliverSelect(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      ColorLabel.Visible = ColorSwatch.Visible = false;
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Select all faces above {0} aspect ratio",
                        AreaThreshold.Value);

        return descrip;
      }
    }

    protected override bool ProcessFaces(Dictionary<DesignBody, IEnumerable<DesignFace>> smallFaces)
    {
      return SelectFaces(smallFaces);
    }
  }
}
