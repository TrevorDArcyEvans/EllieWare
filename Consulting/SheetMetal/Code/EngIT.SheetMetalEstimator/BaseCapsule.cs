//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SpaceClaim.Api.V10;
using SpaceClaim.Api.V10.Extensibility;
using SpaceClaim.Api.V10.Geometry;
using SpaceClaim.Api.V10.Modeler;
using Point = SpaceClaim.Api.V10.Geometry.Point;

namespace EngIT.SheetMetalEstimator
{
  public abstract class BaseCapsule : CommandCapsule
  {
    private const string ExcelFileName = "SM-results.csv";

    string mResultsFilePath;

    protected BaseCapsule(string cmdName, string text, System.Drawing.Image img, string hint)
      : base(cmdName, text, img, hint)
    {
    }

    protected bool IsSheetMetalPart(Document doc)
    {
      if (doc == null ||
          string.IsNullOrEmpty(doc.Path))
      {
        return false;
      }

      return doc.Parts.Count(x => x.SheetMetal != null) > 0;
    }

    protected bool HasFlatPattern(Document doc)
    {
      return GetFlatPart(doc) != null;
    }

    private Part GetFlatPart(Document doc)
    {
      var parts = doc.Parts;
      var allFlatParts = from thisPart in parts where thisPart.FlatPattern != null select thisPart;

      return allFlatParts.SingleOrDefault();
    }

    private Part GetSheetMetalPart(Document doc)
    {
      var parts = doc.Parts;
      var allSheetMetalParts = from thisPart in parts where thisPart.SheetMetal != null select thisPart;

      return allSheetMetalParts.SingleOrDefault();
    }

    private SurfaceEvaluation EvalCentre(Face face)
    {
      var surface = face.Geometry;
      var box = face.BoxUV;
      var centre = box.Center;
      var surfEval = surface.Evaluate(centre);

      return surfEval;
    }

    private Point GetCentrePoint(Face face)
    {
      var centre = EvalCentre(face).Point;

      return centre;
    }

    private Direction GetCentreNormal(Face face)
    {
      var normal = EvalCentre(face).Normal;

      return normal;
    }

    // returns size of a arbitrarily oriented, minimal bounding box for the face
    private SizeF GetMinimalBoundingBoxSize(Face face)
    {
      var origin = GetCentrePoint(face);
      var normal = GetCentreNormal(face);
      var frame = Frame.Create(origin, normal);
      var proj = Matrix.CreateMapping(frame);
      var projInv = proj.Inverse;
      var line = Line.Create(origin, normal);
      var minArea = Double.MaxValue;

      var minBox = Box.Create(Point.Origin);
      for (var i = 0; i <= 180; i += 5)
      {
        var angleRad = i / Math.PI / 180;
        var rotation = Matrix.CreateRotation(line, angleRad);
        var bbox = face.GetBoundingBox(rotation);
        var invBbox = projInv * bbox;
        var area = invBbox.Size.X * invBbox.Size.Y;
        if (area < minArea)
        {
          minArea = area;
          minBox = invBbox;
        }
      }

      return new SizeF((float)minBox.Size.X, (float)minBox.Size.Y);
    }

    private bool CreateFlatPatternDXF(string dxfFilePath, Body firstBody)
    {
      var largestFace = firstBody.Faces.OrderBy(x => x.Area).Last();
      var tempDoc = Document.Create();
      var tempPart = tempDoc.MainPart;
      var tempMasterUnused = DesignBody.Create(tempPart, "Flat Pattern", firstBody);
      var largestSurface = largestFace.Geometry;
      var box = largestFace.BoxUV;
      var centre = box.Center;
      var surfEval = largestSurface.Evaluate(centre);
      var normal = surfEval.Normal;
      var origin = surfEval.Point;
      var frame = Frame.Create(origin, normal);
      var viewProj = Matrix.CreateMapping(frame);
      var viewProjInv = viewProj.Inverse;
      var firstTempWindow = Window.GetWindows(tempDoc).First();

      firstTempWindow.SetProjection(viewProjInv, true, false);

      // this is the API causing the problems :-(
      //firstTempWindow.Export(WindowExportFormat.AutoCadDxf, dxfFilePath);

      //var allTempWindows = Window.GetWindows(tempDoc);
      //foreach (var thisWindow in allTempWindows)
      //{
      //  thisWindow.Close();
      //}

      return true;
    }

    private void WriteResult(SheetMetalResult smr)
    {
      var msg = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}",
                              Path.GetFileName(smr.Path),
                              smr.IsSheetMetalPart,
                              smr.HasFlatPattern,
                              Math.Round(smr.Area, 1),
                              Math.Round(smr.Perimeter, 1),
                              smr.Bends,
                              smr.Holes,
                              Math.Round(smr.Thickness, 2),
                              Math.Round(smr.LARWidth, 1),
                              Math.Round(smr.LARHeight, 1),
                              DateTime.Now.ToString("s"));

      if (!File.Exists(mResultsFilePath))
      {
        const string header = @"Part Name,Sheet Metal,Flat Pattern,Area,Perimeter,No of Bends,No of Holes/Piercings,Thickness,LAR Width,LAR Height,Date-Time";

        using (var sw = File.CreateText(mResultsFilePath))
        {
          sw.WriteLine(header);
        }
      }

      using (var sw = File.AppendText(mResultsFilePath))
      {
        sw.WriteLine(msg);
      }

    }

    protected void Calculate(Document doc)
    {
      var resultsDir = Path.GetDirectoryName(doc.Path);

      mResultsFilePath = mResultsFilePath ?? Path.Combine(resultsDir, ExcelFileName);

      var sheetMetalPart = GetSheetMetalPart(doc);
      if (sheetMetalPart == null)
      {
        var smr1 = new SheetMetalResult(doc.Path, false, false);

        WriteResult(smr1);

        return;
      }

      var flatPart = GetFlatPart(doc);
      var flatPattern = flatPart.FlatPattern;
      if (flatPattern == null)
      {
        var smr2 = new SheetMetalResult(doc.Path, true, false);

        WriteResult(smr2);

        return;
      }

      var flatDesBodies = flatPattern.FlatBodies;
      var allDesBodies = new List<DesignBody>(flatDesBodies);
      var anchorDesFace = flatPattern.AnchorFace;
      var bendDesBodies = from thisDesFace in flatPattern.BendFaces select thisDesFace.Parent;

      allDesBodies.Add(anchorDesFace.Parent);
      allDesBodies.AddRange(bendDesBodies);

      var allBodies = (from desBody in allDesBodies select desBody.Shape.Copy()).ToList();
      var firstBody = allBodies.First();

      allBodies.Remove(firstBody);
      firstBody.Unite(allBodies);

      var orderedFaces = firstBody.Faces.OrderBy(x => x.Area).ToList();
      var largestFace = orderedFaces[orderedFaces.Count - 1];
      var opositeLargestFace = orderedFaces[orderedFaces.Count - 2];
      var larSize = GetMinimalBoundingBoxSize(largestFace);
      var separation = largestFace.GetClosestSeparation(opositeLargestFace);
      var thickness = separation.Distance;
      var lengthUnit = doc.Units.Length;
      var lengthFactor = lengthUnit.ConversionFactor;
      var areaFactor = lengthFactor * lengthFactor;
      var area = largestFace.Area;
      var perimeter = largestFace.Perimeter;
      var numHoles = largestFace.Loops.Where(x => !x.IsOuter).Count();
      var smr3 = new SheetMetalResult(
                      doc.Path,
                      area * areaFactor,
                      perimeter * lengthFactor,
                      flatPattern.BendFaces.Count(),
                      numHoles,
                      thickness * lengthFactor,
                      larSize.Width * lengthFactor,
                      larSize.Height * lengthFactor);

      WriteResult(smr3);

      if (false)
      {
        var dxfFilePath = Path.ChangeExtension(doc.Path, ".dxf");
        CreateFlatPatternDXF(dxfFilePath, firstBody);
      }
    }

    protected virtual bool OnPreExecute(Command command, ExecutionContext context, Rectangle buttonRect)
    {
      mResultsFilePath = null;

      return true;
    }

    protected override abstract void OnUpdate(Command command);
    protected abstract bool OnExecuteInternal(Command command, ExecutionContext context, Rectangle buttonRect);

    protected virtual void OnPostExecute(Command command, ExecutionContext context, Rectangle buttonRect)
    {
      MessageBox.Show("Finished!  Results written to: " + Environment.NewLine + mResultsFilePath);
    }

    protected sealed override void OnExecute(Command command, ExecutionContext context, Rectangle buttonRect)
    {
      if (!OnPreExecute(command, context, buttonRect))
      {
        return;
      }
      if (!OnExecuteInternal(command, context, buttonRect))
      {
        return;
      }
      OnPostExecute(command, context, buttonRect);
    }
  }
}
