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

    protected virtual void ProcessEdges(IEnumerable<DesignEdge> smallEdges)
    {
      Window.ActiveWindow.ActiveContext.Selection = smallEdges.Cast<IDocObject>().ToList();
    }

    public override bool Run()
    {
      WriteBlock.AppendTask(() =>
                              {
                                var bodyAndEdges = GetEdgesBelowThreshold(Window.ActiveWindow.Document, (double)AreaThreshold.Value);
                                var smallEdges = bodyAndEdges.SelectMany(thisBody => thisBody.Value);

                                ProcessEdges(smallEdges);
                              });

      return true;
    }
  }
}
