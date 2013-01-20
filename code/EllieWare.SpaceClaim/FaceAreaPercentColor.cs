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

namespace EllieWare.SpaceClaim
{
  public class FaceAreaPercentColor : FaceAreaPercentBase
  {
    public FaceAreaPercentColor()
    {
    }

    public FaceAreaPercentColor(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Color all faces below {0}% of the largest face {1}",
                        AreaThreshold.Value,
                        ColorDlg.Color);

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
      var smallFaces = GetFacesBelowThreshold(doc, largestFaceArea * areaFactor * (double)AreaThreshold.Value / 100d);
      foreach (var smallFace in smallFaces.Keys.SelectMany(desBody => smallFaces[desBody]))
      {
        smallFace.SetColor(null, ColorDlg.Color);
      }
    }
  }
}
