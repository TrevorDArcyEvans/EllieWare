//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using System.Linq;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;

namespace EllieWare.SpaceClaim
{
  public class EdgeLengthSelect : FaceAreaRemove
  {
    public EdgeLengthSelect()
    {
    }

    public EdgeLengthSelect(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      AreaLabel.Text = "Length:";
      AreaUnits.Text = Window.ActiveWindow.Units.Length.Symbol;
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

    protected Dictionary<DesignBody, IEnumerable<DesignEdge>> GetEdgesBelowThreshold(Document doc, double threshold)
    {
      var retval = new Dictionary<DesignBody, IEnumerable<DesignEdge>>();
      var lengthFactor = doc.Units.Length.ConversionFactor;
      var allParts = doc.Parts;
      foreach (var thisBody in allParts.SelectMany(thisPart => thisPart.Bodies))
      {
        retval[thisBody] = from thisEdge in thisBody.Edges where thisEdge.Shape.Length * lengthFactor < threshold select thisEdge;
      }

      return retval;
    }

    public override bool Run()
    {
      WriteBlock.AppendTask(() =>
                              {
                                var bodyAndEdges = GetEdgesBelowThreshold(Window.ActiveWindow.Document, (double)AreaThreshold.Value);
                                var allEdges = bodyAndEdges.SelectMany(thisBody => thisBody.Value);

                                Window.ActiveWindow.ActiveContext.Selection = allEdges.Cast<IDocObject>().ToList();
                              });

      return true;
    }
  }
}
