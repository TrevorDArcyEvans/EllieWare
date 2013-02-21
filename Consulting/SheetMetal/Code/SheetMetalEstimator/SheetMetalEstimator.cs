//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;
using SpaceClaim.Api.V10.Geometry;
using SpaceClaim.Api.V10.Modeler;

namespace SheetMetalEstimator
{
  public partial class SheetMetalEstimator : UserControl, IMutableRunnable
  {
    private readonly IRobotWare mRoot;
    private readonly ICallback mCallback;
    private readonly IParameterManager mParamMgr;

    public SheetMetalEstimator()
    {
      InitializeComponent();
    }

    public SheetMetalEstimator(IRobotWare root, ICallback callback, IParameterManager mgr) :
      this()
    {
      mRoot = root;
      mCallback = callback;
      mParamMgr = mgr;
    }

    public XmlSchema GetSchema()
    {
      return null;
    }

    public void ReadXml(XmlReader reader)
    {
      ExcelFilePath.Text = reader.GetAttribute("ExcelFilePath");
      var isChecked = reader.GetAttribute("OptGenerateDXF");
      OptGenerateDXF.Checked = bool.Parse(isChecked);
    }

    public void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("ExcelFilePath", ExcelFilePath.Text);
      writer.WriteAttributeString("OptGenerateDXF", OptGenerateDXF.Checked.ToString(CultureInfo.InvariantCulture));
    }

    public string Summary
    {
      get
      {
        return "Estimate area and cut length of a flattened sheet metal part";
      }
    }

    public Control ConfigurationUserInterface
    {
      get
      {
        return this;
      }
    }

    public bool CanRun
    {
      get
      {
        if (Window.ActiveWindow == null || Window.ActiveWindow.Document == null)
        {
          return false;
        }

        return GetFlatPart(Window.ActiveWindow.Document) != null;
      }
    }

    private Part GetFlatPart(Document doc)
    {
      var parts = doc.Parts;
      var allFlatParts = from thisPart in parts where thisPart.FlatPattern != null select thisPart;

      return allFlatParts.SingleOrDefault();
    }

    private bool DoRun()
    {
      var doc = Window.ActiveWindow.Document;
      var flatPart = GetFlatPart(doc);
      var flatPattern = flatPart.FlatPattern;
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

      var largestFace = firstBody.Faces.OrderBy(x => x.Area).Last();
      var lengthUnit = doc.Units.Length;
      var lengthFactor = lengthUnit.ConversionFactor;
      var areaFactor = lengthFactor * lengthFactor;
      var area = largestFace.Area;
      var perimeter = largestFace.Perimeter;
      var numHoles = largestFace.Loops.Where(x => !x.IsOuter).Count();
      var msg = string.Format("{0},{1},{2},{3},{4}",
                              Path.GetFileName(doc.Path),
                              Math.Round(area * areaFactor, 1),
                              Math.Round(perimeter * lengthFactor, 1),
                              flatPattern.BendFaces.Count(),
                              numHoles);
      var path = ExcelFilePath.Text;
      using (var sw = File.Exists(path) ? File.AppendText(path) : File.CreateText(path))
      {
        sw.WriteLine(msg);
      }

      if (OptGenerateDXF.Checked)
      {
        var dxfFilePath = Path.ChangeExtension(doc.Path, ".dxf");
        CreateFlatPatternDXF(dxfFilePath, firstBody);
      }

      return true;
    }

    private bool CreateFlatPatternDXF(string dxfFilePath, Body firstBody)
    {
      Face largestFace = firstBody.Faces.OrderBy(x => x.Area).Last();
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
      var firstTempWindow = Window.GetWindows(tempDoc).First();

      firstTempWindow.SetProjection(viewProj, true, false);
      firstTempWindow.Export(WindowExportFormat.AutoCadDxf, dxfFilePath);

      var evt = new AutoResetEvent(false);
      tempDoc.Closed += (s, e) => evt.Set();

      var allTempWindows = Window.GetWindows(tempDoc);
      foreach (var thisWindow in allTempWindows)
      {
        thisWindow.Close();
      }

      return evt.WaitOne(60 * 1000);
    }

    public bool Run()
    {
      var evt = new AutoResetEvent(false);
      var retVal = false;

      WriteBlock.AppendTask(() =>
        {
          try
          {
            retVal = DoRun();
          }
          finally
          {
            evt.Set();
          }
        });

      return evt.WaitOne(60 * 60 * 1000) && retVal;
    }

    public event EventHandler ConfigurationChanged;

    private void FireConfigurationChanged()
    {
      if (ConfigurationChanged != null)
      {
        ConfigurationChanged(this, new EventArgs());
      }
    }

    private void ExcelFilePath_TextChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void OptGenerateDXF_CheckedChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void BtnBrowse_Click(object sender, EventArgs e)
    {
      if (DlgOpenFile.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      ExcelFilePath.Text = DlgOpenFile.FileName;
    }
  }
}
