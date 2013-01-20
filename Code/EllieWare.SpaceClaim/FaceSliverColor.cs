﻿//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Interfaces;

namespace EllieWare.SpaceClaim
{
  public class FaceSliverColor : FaceSliverBase
  {
    public FaceSliverColor()
    {
    }

    public FaceSliverColor(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Change color of all faces above {0} aspect ratio to {1}",
                        AreaThreshold.Value,
                        ColorDlg.Color);

        return descrip;
      }
    }
  }
}
