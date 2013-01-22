//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
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

    protected Dictionary<DesignBody, IEnumerable<DesignEdge>> GetEdges(Document doc, Func<DesignEdge, bool> criteria)
    {
      var retval = new Dictionary<DesignBody, IEnumerable<DesignEdge>>();
      var allParts = doc.Parts;
      foreach (var thisBody in allParts.SelectMany(thisPart => thisPart.Bodies))
      {
        retval[thisBody] = from thisEdge in thisBody.Edges where criteria(thisEdge) select thisEdge;
      }

      return retval;
    }

    protected virtual bool IsSmallEdge(DesignEdge desEdge)
    {
      var doc = desEdge.Document;
      var lengthFactor = doc.Units.Length.ConversionFactor;

      return desEdge.Shape.Length * lengthFactor < (double)AreaThreshold.Value;
    }

    protected virtual bool ProcessEdges(IEnumerable<DesignEdge> smallEdges)
    {
      Window.ActiveWindow.ActiveContext.Selection = smallEdges.Cast<IDocObject>().ToList();

      return true;
    }

    protected override bool DoRun(Document doc)
    {
      var bodyAndEdges = GetEdges(Window.ActiveWindow.Document, IsSmallEdge);
      var smallEdges = bodyAndEdges.SelectMany(thisBody => thisBody.Value);

      return ProcessEdges(smallEdges);
    }
  }
}
