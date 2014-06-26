//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Diagnostics;
using System.Xml;
using EllieWare.Common;

namespace EllieWare.EventLogger
{
  public partial class LoggerCtrl : UserControlBase
  {
    public LoggerCtrl()
    {
      InitializeComponent();
    }

    public override string Summary
    {
      get
      {
        var levelName = Enum.GetNames(typeof (EventLogEntryType))[mLevel.SelectedIndex];
        return string.Format("{0} : {1} : {2}", mSource.ResolvedValue, levelName, mMessage.ResolvedValue);
      }
    }

    public override void ReadXml(XmlReader reader)
    {
      base.ReadXml(reader);

      mSource.Text = reader.GetAttribute("Source");
      var levelStr = reader.GetAttribute("Level");
      Debug.Assert(levelStr != null, "levelStr != null");
      mLevel.SelectedIndex = mLevel.Items.IndexOf(levelStr);
      mMessage.Text = reader.GetAttribute("Message");
    }

    public override void WriteXml(XmlWriter writer)
    {
      base.WriteXml(writer);

      writer.WriteAttributeString("Source", mSource.Text);
      writer.WriteAttributeString("Level", (string)mLevel.SelectedItem);
      writer.WriteAttributeString("Message", mMessage.Text);
    }

    private void Source_TextChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
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
