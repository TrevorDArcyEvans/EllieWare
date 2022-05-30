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
using System.Xml;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;
using SpaceClaim.Api.V10.Geometry;

namespace EllieWare.SpaceClaim
{
  public partial class AssemblyDrawings : SpaceClaimMutableRunnableBase, IDisposable
  {
    private readonly List<KeyValuePair<string, DrawingViewStyle>> SupportedViewStyles = new List<KeyValuePair<string, DrawingViewStyle>>
                                                                                    {
                                                                                      new KeyValuePair<string, DrawingViewStyle >("Shaded", DrawingViewStyle.Shaded),
                                                                                      new KeyValuePair<string, DrawingViewStyle >("Wire Frame", DrawingViewStyle.WireFrame),
                                                                                      new KeyValuePair<string, DrawingViewStyle >("Hidden Edges Dashed", DrawingViewStyle.HiddenEdgesDashed),
                                                                                      new KeyValuePair<string, DrawingViewStyle >("Hidden Edges Removed", DrawingViewStyle.HiddenEdgesRemoved)
                                                                                    };

    private const string TemplateDir = @"Library\DrawingFormats";
    private const string SpaceClaimFileExtn = ".scdoc";

    public AssemblyDrawings() :
      base()
    {
      InitializeComponent();
    }

    public AssemblyDrawings(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();

      // populate templates
      var templateFullDirPath = Path.Combine(Utils.GetSpaceClaimInstallDirectory(), TemplateDir);
      var templates = from thisTemplate in Directory.EnumerateFiles(templateFullDirPath, "*" + SpaceClaimFileExtn)
                      select Path.GetFileNameWithoutExtension(thisTemplate);
      Template.DataSource = templates.ToList();
      if (Template.Items.Count > 0)
      {
        Template.SelectedIndex = 0;
      }

      // populate drawing view styles
      DrawingStyle.Items.Clear();

      foreach (var kvp in SupportedViewStyles)
      {
        DrawingStyle.Items.Add(kvp.Key);
      }
      DrawingStyle.SelectedIndex = 0;
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Create drawings from the current part or assembly");

        return descrip;
      }
    }

    public override void ReadXml(XmlReader reader)
    {
      var templateStr = reader.GetAttribute("Template");
      var index = Template.Items.IndexOf(templateStr);
      Template.SelectedIndex = index;

      var numStr = reader.GetAttribute("DrawingStyle");
      var num = int.Parse(numStr, NumberStyles.Integer, CultureInfo.InvariantCulture);
      DrawingStyle.SelectedIndex = num;
    }

    public override void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("Template", (string)Template.SelectedItem);
      writer.WriteAttributeString("DrawingStyle", DrawingStyle.SelectedIndex.ToString(CultureInfo.InvariantCulture));
    }

    private void ProcessPart(Document doc, Part part, DrawingSheet sheetTemplate)
    {
      var sheet = DrawingSheet.Create(doc, sheetTemplate);
      var sheetMajorDim = Math.Max(sheet.Width, sheet.Height);
      var frontOrigin = PointUV.Create(0.1 * sheetMajorDim, 0.1 * sheetMajorDim);
      var viewFront = DrawingView.CreateGeneralView(sheet, part, ViewProjection.Front, frontOrigin);
      var frontBox = viewFront.Extent;
      var viewTop = DrawingView.CreateProjectedView(viewFront, PointUV.Create(frontBox.Center.U, frontBox.Center.V + frontBox.RangeV.Span));
      var viewRight = DrawingView.CreateProjectedView(viewFront, PointUV.Create(frontBox.Center.U + frontBox.RangeU.Span, frontBox.Center.V));

      var isoOrigin = PointUV.Create(0.75 * sheetMajorDim, 0.75 * sheetMajorDim);
      var viewIso = DrawingView.CreateGeneralView(sheet, part, ViewProjection.Isometric, isoOrigin);

      var drawingStyle = SupportedViewStyles[DrawingStyle.SelectedIndex].Value;
      viewFront.Style = viewTop.Style = viewRight.Style = viewIso.Style = drawingStyle;
    }

    protected override bool DoRun()
    {
      var templatePath = Path.Combine(Utils.GetSpaceClaimInstallDirectory(), TemplateDir, (string)Template.SelectedItem);
      var templateFilePath = Path.ChangeExtension(templatePath, SpaceClaimFileExtn);
      var templateDoc = Document.Load(templateFilePath);
      var templateSheet = templateDoc.DrawingSheets.First();
      var doc = Window.ActiveWindow.Document;
      var allParts = doc.Parts;
      foreach (var part in allParts)
      {
        ProcessPart(doc, part, templateSheet);
      }

      return true;
    }

    private void Template_SelectedIndexChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void DrawingStyle_SelectedIndexChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    public void Dispose()
    {
      Dispose(true);
    }
  }
}
