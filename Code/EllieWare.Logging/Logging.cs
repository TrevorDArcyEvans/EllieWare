//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Globalization;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Logging
{
  public class Logging : MutableRunnableBase<LoggingCtrl>
  {
    public Logging()
    {
    }

    public Logging(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      mControl.mMessage.SetParameterManager(mgr);
      mControl.mLevel.SelectedIndex = 0;
    }

    public override string Summary
    {
      get
      {
        var level = (LogLevel) mControl.mLevel.SelectedIndex;

        return string.Format("{0} : {1}", level, mControl.mMessage.ResolvedValue);
      }
    }

    public override bool Run()
    {
      mCallback.Log((LogLevel)mControl.mLevel.SelectedIndex, mControl.mMessage.ResolvedValue);

      return true;
    }

    public override void ReadXml(XmlReader reader)
    {
      var levelStr = reader.GetAttribute("Level");
      var levelNum = int.Parse(levelStr, NumberStyles.Integer, CultureInfo.InvariantCulture);
      mControl.mLevel.SelectedIndex = levelNum;
      mControl.mMessage.Text = reader.GetAttribute("Message");
    }

    public override void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("Level", mControl.mLevel.SelectedIndex.ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("Message", mControl.mMessage.Text);
    }
  }
}
