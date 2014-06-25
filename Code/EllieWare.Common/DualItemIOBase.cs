//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Globalization;
using System.Xml;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public class DualItemIOBase : MutableRunnableBase<DualItemIOBaseCtrl>
  {
    public DualItemIOBase()
    {
    }

    public DualItemIOBase(IRobotWare root, ICallback callback, IParameterManager mgr, BrowserTypes browsers) :
      base(root, callback, mgr)
    {
      mControl.Initialise(root, callback, mgr, browsers);
    }

    public override void ReadXml(XmlReader reader)
    {
      mControl.mSourceFilePath.Text = reader.GetAttribute("Source");
      mControl.mDestinationFilePath.Text = reader.GetAttribute("Destination");

      var numStr = reader.GetAttribute("Exists");
      var num = int.Parse(numStr, NumberStyles.Integer, CultureInfo.InvariantCulture);
      mControl.mExists.SelectedIndex = num;
    }

    public override void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("Source", mControl.mSourceFilePath.Text);
      writer.WriteAttributeString("Destination", mControl.mDestinationFilePath.Text);
      writer.WriteAttributeString("Exists", mControl.mExists.SelectedIndex.ToString(CultureInfo.InvariantCulture));
    }
  }
}
