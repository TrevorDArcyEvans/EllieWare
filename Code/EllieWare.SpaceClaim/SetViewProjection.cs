//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using System.Xml;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;
using SpaceClaim.Api.V10.Geometry;

namespace EllieWare.SpaceClaim
{
  public partial class SetViewProjection : SpaceClaimMutableRunnableBase
  {
    private readonly List<KeyValuePair<string, Matrix>> SupportedViewprojections = new List<KeyValuePair<string, Matrix>>
                                                                                     {
                                                                                   new KeyValuePair<string, Matrix >("Back", ViewProjection.Back),
                                                                                   new KeyValuePair<string, Matrix >("Bottom", ViewProjection.Bottom),
                                                                                   new KeyValuePair<string, Matrix >("Front", ViewProjection.Front),
                                                                                   new KeyValuePair<string, Matrix >("Isometric", ViewProjection.Isometric),
                                                                                   new KeyValuePair<string, Matrix >("Left",ViewProjection.Left),
                                                                                   new KeyValuePair<string, Matrix >("Right",ViewProjection.Right),
                                                                                   new KeyValuePair<string, Matrix >("Top",ViewProjection.Top),
                                                                                   new KeyValuePair<string, Matrix >("Trimetric",ViewProjection.Trimetric)
                                                                                 };

    public SetViewProjection()
    {
      InitializeComponent();
    }

    public SetViewProjection(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();

      // populate with view projections
      SelViewProjection.Items.Clear();

      foreach (var kvp in SupportedViewprojections)
      {
        SelViewProjection.Items.Add(kvp.Key);
      }

      SelViewProjection.SelectedIndex = 0;
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Set current view to {0}", SupportedViewprojections[SelViewProjection.SelectedIndex].Key);

        return descrip;
      }
    }

    public override void ReadXml(XmlReader reader)
    {
      var numStr = reader.GetAttribute("ViewProjection");
      var num = int.Parse(numStr, NumberStyles.Integer, CultureInfo.InvariantCulture);
      SelViewProjection.SelectedIndex = num;
    }

    public override void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("ViewProjection", SelViewProjection.SelectedIndex.ToString(CultureInfo.InvariantCulture));
    }

    public override Control ConfigurationUserInterface
    {
      get
      {
        return this;
      }
    }

    protected override bool DoRun(Document doc)
    {
      Window.ActiveWindow.SetProjection(SupportedViewprojections[SelViewProjection.SelectedIndex].Value, false, true);
      Common.Utils.Wait(3000);

      return true;
    }

    private void SelViewProjection_SelectedIndexChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }
  }
}
