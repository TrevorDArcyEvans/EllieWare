//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;

namespace EllieWare.SpaceClaim
{
  public abstract class FaceSliverBase : FaceAreaBase
  {
    public FaceSliverBase() :
      base()
    {
      Initialise();
    }

    public FaceSliverBase(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      Initialise();
    }

    private void Initialise()
    {
      AreaLabel.Text = "Sliver ratio:";
      AreaUnits.Text = "";
      AreaThreshold.Maximum = 100;
      AreaThreshold.Value = 25;
    }

    protected override sealed bool IsSmallFace(DesignFace desFace)
    {
      // From:
      //    http://www.cfd-online.com/Forums/cfx/19977-sliver-face.html
      //
      // Sliver face is defined as a face whose ratio of perimeter length to area is 
      // greater than the certain value. Default critical value is 25. Surfaces with 
      // a high sliver factor can result in a poor quality surface mesh.
      //
      // The sliver factor associated with a surface is computed, as:
      //
      //    Sliver factor = (perimeter length)^2 / (4Pi * surface area)
      var sliverFactor = Math.Pow(desFace.Perimeter, 2f) / (4f * Math.PI * desFace.Area);

      return sliverFactor > (double)AreaThreshold.Value;
    }
  }
}

