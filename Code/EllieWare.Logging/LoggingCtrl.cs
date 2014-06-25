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

namespace EllieWare.Logging
{
  public partial class LoggingCtrl : UserControlBase
  {
    public LoggingCtrl()
    {
      InitializeComponent();
    }

    public override void ReadXml(XmlReader reader)
    {
      base.ReadXml(reader);

      var levelStr = reader.GetAttribute("Level");
      var levelNum = int.Parse(levelStr, NumberStyles.Integer, CultureInfo.InvariantCulture);
      mLevel.SelectedIndex = levelNum;
      mMessage.Text = reader.GetAttribute("Message");
    }

    public override void WriteXml(XmlWriter writer)
    {
      base.WriteXml(writer);

      writer.WriteAttributeString("Level", mLevel.SelectedIndex.ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("Message", mMessage.Text);
    }

    private void Level_SelectedIndexChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void Message_TextChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }
  }
}
