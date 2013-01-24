//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;

namespace EllieWare.SpaceClaim
{
  public class EdgeLengthSelect : EdgeLengthBase
  {
    public EdgeLengthSelect()
    {
    }

    public EdgeLengthSelect(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      AreaLabel.Text = "Length:";
      AreaUnits.Text = string.Format("{0}", (Window.ActiveWindow != null) ? Window.ActiveWindow.Units.Length.Symbol : "mm");
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Select all edges below {0} {1}",
                        AreaThreshold.Value,
                        Window.ActiveWindow.Units.Length.Symbol);

        return descrip;
      }
    }

    protected override bool IsSmallEdge(DesignEdge desEdge)
    {
      var doc = desEdge.Document;
      var lengthFactor = doc.Units.Length.ConversionFactor;

      return desEdge.Shape.Length * lengthFactor < (double)AreaThreshold.Value;
    }
  }
}
