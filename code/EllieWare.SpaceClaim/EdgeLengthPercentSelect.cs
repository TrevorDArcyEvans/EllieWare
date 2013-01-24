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
  public class EdgeLengthPercentSelect : EdgeLengthBase
  {
    private double mLongestEdge;

    public EdgeLengthPercentSelect()
    {
    }

    public EdgeLengthPercentSelect(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      AreaLabel.Text = "Threshold:";
      AreaUnits.Text = "%";
      AreaThreshold.Maximum = 25;
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Select all edges below {0}% of the longest edge",
                        AreaThreshold.Value);

        return descrip;
      }
    }

    private double GetLongestEdge(List<DesignEdge> allEdgesOrdered)
    {
      // define the 'longest' edge to be the average of edges in the top 90-95%
      var allTopEdges = from desEdge in allEdgesOrdered
                        where
                          allEdgesOrdered.IndexOf(desEdge) >= 0.90 * allEdgesOrdered.Count &&
                          allEdgesOrdered.IndexOf(desEdge) <= 0.95 * allEdgesOrdered.Count
                        select desEdge;
      return allTopEdges.Aggregate(0d, (x, de) => x + de.Shape.Length) / allTopEdges.Count();
    }

    private void CalculateLongestEdge(List<DesignEdge> allEdgesOrdered)
    {
      mLongestEdge = GetLongestEdge(allEdgesOrdered);
    }

    private List<DesignEdge> GetAllEdgesOrdered(Document doc)
    {
      return GetEdges(doc, de => true).Values.SelectMany(de => de).OrderBy(de => de.Shape.Length).ToList();
    }

    public override bool CanRun
    {
      get
      {
        var allEdgesOrdered = GetAllEdgesOrdered(Window.ActiveWindow.Document);

        if (allEdgesOrdered.Count < 10)
        {
          return false;
        }

        CalculateLongestEdge(allEdgesOrdered);

        return true;
      }
    }

    protected override bool IsSmallEdge(DesignEdge desEdge)
    {
      var edgeLength = desEdge.Shape.Length;

      return edgeLength < mLongestEdge * (double)AreaThreshold.Value / 100d;
    }
  }
}
