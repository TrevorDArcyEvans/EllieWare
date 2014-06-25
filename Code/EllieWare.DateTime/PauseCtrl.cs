//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Globalization;
using System.Xml;
using EllieWare.Common;

namespace EllieWare.DateTime
{
  public partial class PauseCtrl : UserControlBase
  {
    public PauseCtrl()
    {
      InitializeComponent();
    }

    public override void ReadXml(XmlReader reader)
    {
      base.ReadXml(reader);

      var pauseStr = reader.GetAttribute("Pause");
      mTimeSpan.Value = System.DateTime.Parse(pauseStr, CultureInfo.InvariantCulture);
    }

    public override void WriteXml(XmlWriter writer)
    {
      base.WriteXml(writer);

      writer.WriteAttributeString("Pause", mTimeSpan.Value.ToString(CultureInfo.InvariantCulture));
    }

    private void TimeSpan_ValueChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }
  }
}
