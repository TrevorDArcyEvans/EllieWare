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
using System.Windows.Forms;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Imaging
{
  public partial class ResizerBase : DualItemIOBase
  {
    public ResizerBase()
    {
      InitializeComponent();
    }

    public ResizerBase(IEnumerable<object> roots, ICallback callback, IParameterManager mgr) :
      base(roots, callback, mgr, BrowserTypes.BothFile)
    {
      InitializeComponent();

      ResizerMain.BringToFront();

      SetSourceFileSelectorFilter(Utils.ImageFilesFilter);
      SetDestinationFileSelectorFilter(Utils.ImageFilesFilter);
    }

    public override void ReadXml(XmlReader reader)
    {
      base.ReadXml(reader);

      var num1Str = reader.GetAttribute("Dimension1");
      var num1 = int.Parse(num1Str, NumberStyles.Integer, CultureInfo.InvariantCulture);
      Dimension1.Value = num1;

      var num2Str = reader.GetAttribute("Dimension2");
      var num2 = int.Parse(num2Str, NumberStyles.Integer, CultureInfo.InvariantCulture);
      Dimension2.Value = num2;
    }

    public override void WriteXml(XmlWriter writer)
    {
      base.WriteXml(writer);

      writer.WriteAttributeString("Dimension1", Dimension1.Value.ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("Dimension2", Dimension2.Value.ToString(CultureInfo.InvariantCulture));
    }

    private void Dimension1_ValueChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void Dimension2_ValueChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }
  }
}
