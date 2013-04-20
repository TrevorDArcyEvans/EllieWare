//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//

namespace EngIT.SheetMetalEstimator
{
  public class SheetMetalResult
  {
    public string Path { get; private set; }
    public double Area { get; private set; }
    public double Perimeter { get; private set; }
    public int Bends { get; private set; }
    public int Holes { get; private set; }
    public double Thickness { get; private set; }
    public double LARWidth { get; private set; }
    public double LARHeight { get; private set; }

    public bool IsSheetMetalPart { get; private set; }
    public bool HasFlatPattern { get; private set; }
    public string Comment { get; private set; }

    private SheetMetalResult(
            string path,
            double area,
            double perimeter,
            int bends,
            int holes,
            double thk,
            double larwidth,
            double larheight,
            bool isSheet,
            bool hasFlatPatt)
    {
      Path = path;
      Area = area;
      Perimeter = perimeter;
      Bends = bends;
      Holes = holes;
      Thickness = thk;
      LARWidth = larwidth;
      LARHeight = larheight;

      IsSheetMetalPart = isSheet;
      HasFlatPattern = hasFlatPatt;
      Comment = string.Empty;
    }

    public SheetMetalResult(
            string path,
            double area,
            double perimeter,
            int bends,
            int holes,
            double thk,
            double larwidth,
            double larheight) :
      this(
      path,
      area,
      perimeter,
      bends,
      holes,
      thk,
      larwidth,
      larheight,
      true,
      true)
    {
    }

    public SheetMetalResult(
            string path,
            bool isSheet,
            bool hasFlatPatt) :
      this(
          path,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          isSheet,
          hasFlatPatt)
    {
    }

    public SheetMetalResult(
            string path,
            string errMsg) :
      this(
        path,
        false,
        false)
    {
      Comment = errMsg;
    }
  }
}
