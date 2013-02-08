//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;
using SpaceClaim.Api.V10.Geometry;
using SpaceClaim.Api.V10.Modeler;
using Point = SpaceClaim.Api.V10.Geometry.Point;

namespace BottleSlicer
{
  public partial class BottleSlicerPlugin : UserControl, IMutableRunnable
  {
    private readonly IRobotWare mRoot;
    private readonly ICallback mCallback;
    private readonly IParameterManager mParamMgr;

    public BottleSlicerPlugin()
    {
      InitializeComponent();
    }

    public BottleSlicerPlugin(IRobotWare root, ICallback callback, IParameterManager mgr) :
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
      OutputDirectory.Text = reader.GetAttribute("OutputDirectory");

      var numStr = reader.GetAttribute("Sections");
      var num = Decimal.Parse(numStr, NumberStyles.Number, CultureInfo.InvariantCulture);
      Sections.Value = num;
    }

    public void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("OutputDirectory", OutputDirectory.Text);
      writer.WriteAttributeString("Sections", Sections.Value.ToString(CultureInfo.InvariantCulture));
    }

    public string Summary
    {
      get
      {
        var msg = string.Format("Section a bottle into {0} sections and put the results in a file in {1}",
                                Sections.Value,
                                OutputDirectory.Text);

        return msg;
      }
    }

    private static IList<ITrimmedCurve> CreatePolyline(params Point[] points)
    {
      Debug.Assert(points != null);

      var nSegments = points.Length - 1;
      Debug.Assert(nSegments > 0);

      var segments = new ITrimmedCurve[nSegments];
      for (var i = 0; i < nSegments; i++)
      {
        segments[i] = CurveSegment.Create(points[i], points[i + 1]);
      }

      return segments;
    }

    private static Body CreateBlock(Plane basePlane, double length, double width, double height)
    {
      var halfLength = length / 2;
      var halfWidth = width / 2;

      var point1 = Point.Create(-halfLength, -halfWidth, 0);
      var point2 = Point.Create(halfLength, -halfWidth, 0);
      var point3 = Point.Create(halfLength, halfWidth, 0);
      var point4 = Point.Create(-halfLength, halfWidth, 0);

      return Body.ExtrudeProfile(basePlane, CreatePolyline(point1, point2, point3, point4, point1), height);
    }

    private bool DoRun()
    {
      var doc = Window.ActiveWindow.Document;
      var part = doc.MainPart;
      var desBody = part.Bodies.Single();
      var body = desBody.Shape;
      var bodyCopy = body.Copy();
      var origVolume = bodyCopy.Volume;

      // calculating tight bounding box is *very* expensive and we were getting timeouts,
      // so just use approx bounding box which is good enough
      var bbox = bodyCopy.GetBoundingBox(Matrix.Identity);

      var maxPt = bbox.MaxCorner;
      var minPt = bbox.MinCorner;
      var height = maxPt.Z - minPt.Z;
      var width = maxPt.X - minPt.X;
      var length = maxPt.Y - minPt.Y;
      var majorDim = Math.Max(width, length);
      var lengthFactor = doc.Units.Length.ConversionFactor;
      var volumeFactor = Math.Pow(lengthFactor, 3d);


      // plane at bottom of bottle with normal pointing up
      var zAxis = Direction.Create(0d, 0d, maxPt.Z - minPt.Z);
      var botFrame = Frame.Create(minPt, zAxis);
      var botPlane = Plane.Create(botFrame);


      var fileName = Path.GetFileNameWithoutExtension(doc.Path);
      mCallback.Log(LogLevel.Information, "Processing: " + fileName);

      var now = DateTime.Now;
      var msgStart = now.ToLongDateString() + " " + now.ToLongTimeString();
      mCallback.Log(LogLevel.Information, "  " + msgStart);

      var msgVolume = string.Format("  Volume = {0} {1}^3",
                        origVolume * volumeFactor,
                        doc.Units.Length.Symbol);
      mCallback.Log(LogLevel.Information, msgVolume);

      var sb = new StringBuilder();

      for (var i = 1; i <= Sections.Value; i++)
      {
        var sectHeight = i * height / (double)Sections.Value;
        using (var sectBox = CreateBlock(Plane.PlaneXY, majorDim, majorDim, sectHeight))
        {
          bodyCopy.Subtract(new[] { sectBox });
        }

        var volume = bodyCopy.Volume;
        var sectVolume = origVolume - volume;
        var msg = string.Format("  [{0}] --> {1} {3} --> {2} {3}^3",
                                i,
                                sectHeight * lengthFactor,
                                sectVolume * volumeFactor,
                                doc.Units.Length.Symbol);
        mCallback.Log(LogLevel.Information, msg);

        var output = string.Format("{0},{1},{2}",
                                   i,
                                   sectHeight * lengthFactor,
                                   sectVolume * volumeFactor);
        sb.AppendLine(output);
      }

      var outFilePath = Path.Combine(OutputDirectory.Text, fileName);
      outFilePath = Path.ChangeExtension(outFilePath, ".csv");
      File.WriteAllText(outFilePath, sb.ToString());

      return true;
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

      // wait for 2 hours (!)
      return evt.WaitOne(2 * 60 * 60 * 1000) && retVal;
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
        return Window.ActiveWindow != null;
      }
    }

    protected void FireConfigurationChanged()
    {
      if (ConfigurationChanged != null)
      {
        ConfigurationChanged(this, new EventArgs());
      }
    }

    public event EventHandler ConfigurationChanged;

    private void Sections_ValueChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void OutputDirectory_TextChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void CmdDirectorySelect_Click(object sender, EventArgs e)
    {
      if (OutputDirectorySelectDialog.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      OutputDirectory.Text = OutputDirectorySelectDialog.SelectedPath;
    }
  }
}
