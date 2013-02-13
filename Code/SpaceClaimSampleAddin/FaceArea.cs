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
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;
using SpaceClaim.Api.V10.Geometry;
using SpaceClaim.Api.V10.Modeler;

namespace SpaceClaimSampleAddin
{
  public partial class FaceArea : UserControl, IRunnable
  {
    // retain these for future use
    private readonly IRobotWare mRoot;
    private readonly ICallback mCallback;
    private readonly IParameterManager mParamMgr;

    // default constructor required for:
    //    Microsoft Visual Studio designer
    //    IXmlSerializable infrastructure
    public FaceArea()
    {
      InitializeComponent();
    }

    // called by RobotWare when:
    //    adding step to a specification
    //    loading or running specification
    //
    // All initialisation should be done here and everything
    // should be set to a safe state.
    public FaceArea(IRobotWare root, ICallback callback, IParameterManager mgr) :
      this()
    {
      mRoot = root;
      mCallback = callback;
      mParamMgr = mgr;
    }

    #region Implementation of IXmlSerializable

    // must return null - see MSDN documentation
    public XmlSchema GetSchema()
    {
      return null;
    }

    // called by RobotWare when loading or running specification
    // so addin can read settings from specification file
    public void ReadXml(XmlReader reader)
    {
      // no settings to read
    }

    // called by RobotWare when loading or running specification
    // so addin can save settings to specification file
    public void WriteXml(XmlWriter writer)
    {
      // no settings to save
    }

    #endregion

    #region Implementation of IRunnable

    public string Summary
    {
      get
      {
        return "Calculate the area of holes on a selected face";
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
        // could do a licensing check here...

        // must have an open document
        if (Window.ActiveWindow == null)
        {
          return false;
        }

        // must have only one thing selected
        var singleSelection = Window.ActiveWindow.ActiveContext.SingleSelection;
        if (singleSelection == null)
        {
          return false;
        }

        // must have a planar face selected
        var face = (IDesignFace)singleSelection;
        var geometry = face.Shape.Geometry as Plane;
        if (geometry == null)
        {
          return false;
        }

        return true;
      }
    }

    public bool Run()
    {
      var activeWindow = Window.ActiveWindow;
      var singleSelection = Window.ActiveWindow.ActiveContext.SingleSelection;
      if (singleSelection == null)
      {
        return false;
      }

      var face = (IDesignFace)singleSelection;
      var geometry = face.Shape.Geometry as Plane;
      if (geometry == null)
      {
        return false;
      }

      // get all loops on the selected face
      var allLoops = face.Master.Shape.Loops;
      var sb = new StringBuilder();
      var num = 1;
      foreach (var loop in allLoops)
      {
        if (loop.IsOuter && (allLoops.Count > 1))
        {
          // skip the outer loop as this is the outer perimeter of the face
          // we are only interested in the holes on the face ie inner loops
          continue;
        }

        // get all the edges which make up the perimeter of the hole
        var edges = loop.Edges;
        var profile = new List<ITrimmedCurve>();
        foreach (var edge in edges)
        {
          profile.Add(CurveSegment.Create(edge.Geometry, edge.Bounds));
        }

        // create a planar body of the hole
        var planarBody = Body.CreatePlanarBody(geometry, profile);

        // the body should only contain one face
        var planarBodyFace = planarBody.Faces.First();

        // get the area of the face and convert it to user units
        var areaFactor = activeWindow.Document.Units.Length.ConversionFactor * activeWindow.Document.Units.Length.ConversionFactor;
        var area = planarBodyFace.Area * areaFactor;
        var areaText = string.Format("Loop {0}: {1} {2}^2",
                                 num,
                                 Math.Round(area, 3),
                                 activeWindow.Document.Units.Length.Symbol);

        sb.Append(areaText);
        num++;
      }
      MessageBox.Show(sb.ToString());

      return true;
    }

    #endregion
  }
}
