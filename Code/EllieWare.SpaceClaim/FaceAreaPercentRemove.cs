//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Linq;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;
using SpaceClaim.Api.V10.Modeler;

namespace EllieWare.SpaceClaim
{
  public class FaceAreaPercentRemove : FaceAreaPercentBase
  {
    public FaceAreaPercentRemove() :
      base()
    {
      ColorLabel.Visible = ColorSwatch.Visible = false;
    }

    public FaceAreaPercentRemove(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      ColorLabel.Visible = ColorSwatch.Visible = false;
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Remove all faces below {0}% of the largest face", AreaThreshold.Value);

        return descrip;
      }
    }

    protected override void DoRun()
    {
      var doc = Window.ActiveWindow.Document;
      var allFacesOrdered = GetAllFacesOrdered(doc);

      if (allFacesOrdered.Count < 10)
      {
        return;
      }

      var largestFaceArea = GetLargestFaceArea(allFacesOrdered);
      var lengthFactor = doc.Units.Length.ConversionFactor;
      var areaFactor = lengthFactor * lengthFactor;
      var smallFaces = GetFacesBelowThreshold(doc, largestFaceArea* areaFactor  * (double)AreaThreshold.Value / 100d);

      foreach (var desBody in smallFaces.Keys)
      {
        var modFaces = from desFace in smallFaces[desBody] select desFace.Shape;
        desBody.Shape.DeleteFaces(modFaces.ToList(), RepairAction.GrowSurrounding);
      }
    }
  }
}
