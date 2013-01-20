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
      AreaLabel.Text = "Threshold";
      AreaUnits.Text = "%";
      AreaThreshold.Maximum = 25;
    }

    protected double GetLargestFaceArea(List<DesignFace> allFacesOrdered)
    {
      // define the 'largest' face to be the average of faces in the top 90-95%
      var allTopFaces = from designFace in allFacesOrdered
                        where
                          allFacesOrdered.IndexOf(designFace) >= 0.90 * allFacesOrdered.Count &&
                          allFacesOrdered.IndexOf(designFace) <= 0.95 * allFacesOrdered.Count
                        select designFace;
      return allTopFaces.Aggregate(0d, (x, df) => x + df.Area) / allTopFaces.Count();
    }

    protected List<DesignFace> GetAllFacesOrdered(Document doc)
    {
      return GetFacesBelowThreshold(doc, double.MaxValue).Values.SelectMany(bodyFaces => bodyFaces).OrderBy(x => x.Area).ToList();
    }
  }
}
