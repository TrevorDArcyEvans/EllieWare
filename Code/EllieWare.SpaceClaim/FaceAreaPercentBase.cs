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
  public class FaceAreaPercentBase : FaceAreaColor
  {
    private double mLargestFaceArea;

    public FaceAreaPercentBase() :
      base()
    {
      Initialise();
    }

    public FaceAreaPercentBase(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      Initialise();
    }

    private void Initialise()
    {
      AreaLabel.Text = "Threshold:";
      AreaUnits.Text = "%";
      AreaThreshold.Maximum = 25;
    }

    private double GetLargestFaceArea(List<DesignFace> allFacesOrdered)
    {
      // define the 'largest' face to be the average of faces in the top 90-95%
      var allTopFaces = from designFace in allFacesOrdered
                        where
                          allFacesOrdered.IndexOf(designFace) >= 0.90 * allFacesOrdered.Count &&
                          allFacesOrdered.IndexOf(designFace) <= 0.95 * allFacesOrdered.Count
                        select designFace;
      return allTopFaces.Aggregate(0d, (x, df) => x + df.Area) / allTopFaces.Count();
    }

    private List<DesignFace> GetAllFacesOrdered(Document doc)
    {
      return GetAllFaces(doc).Values.SelectMany(bodyFaces => bodyFaces).OrderBy(x => x.Area).ToList();
    }

    private void CalculateLargestFaceArea(List<DesignFace> allFacesOrdered)
    {
      mLargestFaceArea = GetLargestFaceArea(allFacesOrdered);
    }

    public override bool CanRun
    {
      get
      {
        var allFacesOrdered = GetAllFacesOrdered(Window.ActiveWindow.Document);

        if (allFacesOrdered.Count < 10)
        {
          return false;
        }

        CalculateLargestFaceArea(allFacesOrdered);

        return true;
      }
    }

    protected override bool IsSmallFace(DesignFace desFace)
    {
      return desFace.Area < mLargestFaceArea * (double)AreaThreshold.Value / 100d;
    }
  }
}
