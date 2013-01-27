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
using SpaceClaim.Api.V10.Modeler;

namespace EllieWare.SpaceClaim
{
  public abstract class FaceAreaBase : FaceEdgeOperation
  {
    public FaceAreaBase()
    {
    }

    public FaceAreaBase(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    private Dictionary<DesignBody, IEnumerable<DesignFace>> GetSmallFaces(Document doc, Func<DesignFace, bool> criteria)
    {
      var retval = new Dictionary<DesignBody, IEnumerable<DesignFace>>();
      var allParts = doc.Parts;
      foreach (var thisBody in allParts.SelectMany(thisPart => thisPart.Bodies))
      {
        retval[thisBody] = from thisFace in thisBody.Faces where criteria(thisFace) select thisFace;
      }

      return retval;
    }

    private Dictionary<DesignBody, IEnumerable<DesignFace>> GetSmallFaces(Document doc)
    {
      return GetSmallFaces(doc, IsSmallFace);
    }

    protected Dictionary<DesignBody, IEnumerable<DesignFace>> GetAllFaces(Document doc)
    {
      return GetSmallFaces(doc, df => true);
    }

    protected virtual bool IsSmallFace(DesignFace desFace)
    {
      var doc = desFace.Document;
      var lengthFactor = doc.Units.Length.ConversionFactor;
      var areaFactor = lengthFactor * lengthFactor;

      return desFace.Area * areaFactor < (double)AreaThreshold.Value;
    }

    protected bool ColorFaces(Dictionary<DesignBody, IEnumerable<DesignFace>> smallFaces)
    {
      var totalFaces = 0;
      foreach (var face in smallFaces.Values.SelectMany(bodyFaces => bodyFaces))
      {
        face.SetColor(null, ColorDlg.Color);
        totalFaces++;
      }

      mCallback.Log(LogLevel.Information, string.Format("Changed color of {0} faces", totalFaces));

      return true;
    }

    protected bool SelectFaces(Dictionary<DesignBody, IEnumerable<DesignFace>> smallFaces)
    {
      var allFaces = smallFaces.SelectMany(db => db.Value.ToList());
      Window.ActiveWindow.ActiveContext.Selection = allFaces.Cast<IDocObject>().ToList();

      mCallback.Log(LogLevel.Information, string.Format("Selected {0} faces", allFaces.Count()));

      return true;
    }

    protected bool RemoveFaces(Dictionary<DesignBody, IEnumerable<DesignFace>> smallFaces)
    {
      var totalFaces = 0;
      var successfulFaces = 0;
      foreach (var desBody in smallFaces.Keys)
      {
        var modFaces = from desFace in smallFaces[desBody] select desFace.Shape;
        foreach (var thisModFace in modFaces)
        {
          totalFaces++;
          try
          {
            // try to remove each face individually
            desBody.Shape.DeleteFaces(new[] { thisModFace }, RepairAction.GrowSurrounding);
            successfulFaces++;
          }
          catch (InvalidOperationException)
          {
            // Body.DeleteFaces() throws InvalidOperationException on failure
            // swallow exception as deleting faces is a difficult operation
          }
        }
      }

      mCallback.Log(LogLevel.Information, string.Format("Removed {0} / {1} faces", successfulFaces, totalFaces));

      return true;
    }

    protected abstract bool ProcessFaces(Dictionary<DesignBody, IEnumerable<DesignFace>> smallFaces);

    protected override sealed bool DoRun()
    {
      var doc = Window.ActiveWindow.Document;
      var smallFaces = GetSmallFaces(doc);

      return ProcessFaces(smallFaces);
    }
  }
}
