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
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;

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
    }

    public void WriteXml(XmlWriter writer)
    {
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
      var msg = string.Format("Area = {0} {1}^2\nPerimeter = {2} {3}",
                              area * areaFactor,
                              lengthUnit.Symbol,
                              perimeter * lengthFactor,
                              lengthUnit.Symbol);

      MessageBox.Show(msg);

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
  }
}
