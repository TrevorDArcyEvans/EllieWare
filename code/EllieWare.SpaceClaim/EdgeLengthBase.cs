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
  public abstract class EdgeLengthBase : FaceEdgeOperation
  {
    public EdgeLengthBase()
    {
      ColorLabel.Visible = ColorSwatch.Visible = false;
    }

    public EdgeLengthBase(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      ColorLabel.Visible = ColorSwatch.Visible = false;
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

    protected abstract bool IsSmallEdge(DesignEdge desEdge);

    protected bool ProcessEdges(IEnumerable<DesignEdge> smallEdges)
    {
      Window.ActiveWindow.ActiveContext.Selection = smallEdges.Cast<IDocObject>().ToList();

      return true;
    }

    protected override sealed bool DoRun(Document doc)
    {
      var bodyAndEdges = GetEdges(Window.ActiveWindow.Document, IsSmallEdge);
      var smallEdges = bodyAndEdges.SelectMany(thisBody => thisBody.Value);

      return ProcessEdges(smallEdges);
    }
  }
}
