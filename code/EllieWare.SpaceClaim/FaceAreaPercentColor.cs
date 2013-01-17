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
using System.Text;
using System.Threading;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;

namespace EllieWare.SpaceClaim
{
  public class FaceAreaPercentColor : FaceAreaColor
  {
    public FaceAreaPercentColor()
    {
      Initialise();
    }

    public FaceAreaPercentColor(IRobotWare root, ICallback callback, IParameterManager mgr) :
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

    private void DoRun(AutoResetEvent evt)
    {
      try
      {
        var allFacesOrdered = GetFacesBelowThreshold(Window.ActiveWindow.Document, double.MaxValue).Values.SelectMany(bodyFaces => bodyFaces).OrderBy(x => x.Area).ToList();

        if (allFacesOrdered.Count < 10)
        {
          return;
        }

        // define the 'largest' face to be the average of faces in the top 90-95%
        var allTopFaces = from designFace in allFacesOrdered
                          where
                            allFacesOrdered.IndexOf(designFace) >= 0.90 * allFacesOrdered.Count &&
                            allFacesOrdered.IndexOf(designFace) <= 0.95 * allFacesOrdered.Count
                          select designFace;
        var largestFaceArea = allTopFaces.Aggregate(0d, (x, df) => x + df.Area);

        foreach (var face in allFacesOrdered.Where(x => x.Area < largestFaceArea * (double)AreaThreshold.Value / 100d))
        {
          face.SetColor(null, ColorDlg.Color);
        }
      }
      finally
      {
        evt.Set();
      }
    }

    public override bool Run()
    {
      var evt = new AutoResetEvent(false);

      WriteBlock.AppendTask(() => DoRun(evt));

      return evt.WaitOne(30000);
    }

  }
}
