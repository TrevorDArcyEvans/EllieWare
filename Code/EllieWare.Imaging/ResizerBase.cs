//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Globalization;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Imaging
{
  public class ResizerBase : MutableRunnableBase<ResizerBaseCtrl>
  {
    public ResizerBase()
    {
    }

    public ResizerBase(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      mControl.Initialise(root, callback, mgr, BrowserTypes.BothFile);
    }

    public override void ReadXml(XmlReader reader)
    {
      base.ReadXml(reader);

      var num1Str = reader.GetAttribute("Dimension1");
      var num1 = int.Parse(num1Str, NumberStyles.Integer, CultureInfo.InvariantCulture);
      mControl.Dimension1.Value = num1;

      var num2Str = reader.GetAttribute("Dimension2");
      var num2 = int.Parse(num2Str, NumberStyles.Integer, CultureInfo.InvariantCulture);
      mControl.Dimension2.Value = num2;
    }

    public override void WriteXml(XmlWriter writer)
    {
      base.WriteXml(writer);

      writer.WriteAttributeString("Dimension1", mControl.Dimension1.Value.ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("Dimension2", mControl.Dimension2.Value.ToString(CultureInfo.InvariantCulture));
    }
  }
}
