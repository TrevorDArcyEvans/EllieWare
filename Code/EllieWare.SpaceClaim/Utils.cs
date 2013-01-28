//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using SpaceClaim.Api.V10;

namespace EllieWare.SpaceClaim
{
  public class Utils
  {
    public static Dictionary<string, PartExportFormat> BrepFormats = new Dictionary<string, PartExportFormat>
                                              {
                                                {".CATPart".ToLowerInvariant(), PartExportFormat.CatiaV5Part},
                                                {".CATProduct".ToLowerInvariant(), PartExportFormat.CatiaV5Assembly},
                                                {".cgr", PartExportFormat.CatiaV5Graphics},
                                                {".igs", PartExportFormat.Iges},
                                                {".iges", PartExportFormat.Iges},
                                                {".stp", PartExportFormat.Step},
                                                {".step", PartExportFormat.Step},
                                                {".vda", PartExportFormat.Vda},
                                                {".jt", PartExportFormat.JtOpen},
                                                {".x_t", PartExportFormat.ParasolidText},
                                                {".x_b", PartExportFormat.ParasolidBinary},
                                                {".sat", PartExportFormat.AcisText},
                                                {".sab", PartExportFormat.AcisBinary},
                                                {".3dm", PartExportFormat.Rhino},
                                                {".pdf", PartExportFormat.Pdf},
                                                {".skp", PartExportFormat.SketchUp}
                                              };

    public static Dictionary<string, PartWindowExportFormat> TessellatedFormats = new Dictionary<string, PartWindowExportFormat>
                                              {
                                                {".bip", PartWindowExportFormat.Bip},
                                                {".obj", PartWindowExportFormat.Obj},
                                                {".stl", PartWindowExportFormat.Stl},
                                                {".wrl", PartWindowExportFormat.Vrml},
                                                {".vrml", PartWindowExportFormat.Vrml},
                                                {".xaml", PartWindowExportFormat.Xaml}
                                              };

    private const string AllFilesFilter = "All files (*.*)|*.*";

    private const string InternalPartExportFilter =
                          "Catia V5 part files (*.CATPart)|*.CATPart|" +
                          "Catia V5 assembly files (*.CATProduct)|*.CATProduct|" +
                          "Catia V5 graphics files (*.cgr)|*.cgr|" +
                          "IGES files (*.igs)|*.igs|" +
                          "IGES files (*.iges)|*.iges|" +
                          "STEP files (*.stp)|*.stp|" +
                          "STEP files (*.step)|*.step|" +
                          "VDA files (*.vda)|*.vda|" +
                          "JT Open files (*.)|*.jt|" +
                          "Parasolid text files (*.x_t)|*.x_t|" +
                          "Parasolid binary files (*.x_b)|*.x_b|" +
                          "ACIS text files (*.sat)|*.sat|" +
                          "ACIS binary files (*.sab)|*.sab|" +
                          "Rhino files (*.3dm)|*.3dm|" +
                          "3D PDF files (*.pdf)|*.pdf|" +
                          "SketchUp files (*.skp)|*.skp|";

    public const string PartExportFilter = InternalPartExportFilter + AllFilesFilter;

    private const string InternalPartWindowExportFilter =
                          "VRML files (*.wrl)|*.wrl|" +
                          "VRML files (*.vrml)|*.vrml|" +
                          "XAML files (*.xaml)|*.xaml|" +
                          "STL files (*.stl)|*.stl|" +
                          "Wavefront image files (*.obj)|*.obj|" +
                          "Luxion KeyShot scene files (*.bip)|*.bip|";

    public const string PartWindowExportFilter = InternalPartWindowExportFilter + AllFilesFilter;

    public const string AllPartExportFilter = InternalPartExportFilter + InternalPartWindowExportFilter + AllFilesFilter;

    public static readonly Dictionary<string, WindowExportFormat> RasterFormats = new Dictionary<string, WindowExportFormat>
                                                                                  {
                                                                                    {".bmp", WindowExportFormat.Bmp},
                                                                                    {".jpg", WindowExportFormat.Jpeg},
                                                                                    {".jpeg", WindowExportFormat.Jpeg},
                                                                                    {".png", WindowExportFormat.Png},
                                                                                    {".tif", WindowExportFormat.Tiff},
                                                                                    {".tiff", WindowExportFormat.Tiff}
                                                                                  };

    public static readonly Dictionary<string, WindowExportFormat> VectorFormats = new Dictionary<string, WindowExportFormat>
                                                                                  {
                                                                                    {".dwg", WindowExportFormat.AutoCadDwg},
                                                                                    {".dxf", WindowExportFormat.AutoCadDxf}
                                                                                  };

    private const string InternalWindowVectorExportFilter =
                          "AutoCAD DWG files (*.dwg)|*.dwg|" +
                          "AutoCAD DXF files (*.dxf)|*.dxf|";

    private const string InternalWindowRasterExportFilter =
                          "Windows bitmap files (*.bmp)|*.bmp|" +
                          "JPEG image files (*.jpg)|*.jpg|" +
                          "JPEG image files (*.jpeg)|*.jpeg|" +
                          "PNG image files (*.png)|*.png|" +
                          "TIFF image files (*.tif)|*.tif|" +
                          "TIFF image files (*.tiff)|*.tiff|" +
                          "GIF image files (*.gif)|*.gif|";

    public const string WindowVectorExportFilter = InternalWindowVectorExportFilter + AllFilesFilter;
    public const string WindowRasterExportFilter = InternalWindowRasterExportFilter + AllFilesFilter;
    public const string AllWindowRasterExportFilter = InternalWindowVectorExportFilter + InternalWindowRasterExportFilter + AllFilesFilter;

    private const string InternalPdfFilesFilter = 
                          "Adobe PDF files (*.pdf)|*.pdf|";

    public const string PdfFilesFilter = InternalPdfFilesFilter + AllFilesFilter;

    public const string PdfFileExtension = ".pdf";

    private const string InternalNativeFilter =
                          "SpaceClaim files (*.scdoc)|*.scdoc|";

    public const string NativeFilter = InternalNativeFilter + AllFilesFilter;

    public static string GetSpaceClaimInstallDirectory()
    {
      // work out where SpaceClaim lives
      var procs = Process.GetProcessesByName("SpaceClaim");
      var sc = procs.First();
      var scPath = sc.MainModule.FileName;
      var retVal = Path.GetDirectoryName(scPath);

      return retVal;
    }
  }
}
