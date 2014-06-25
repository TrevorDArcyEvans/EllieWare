//
//  Copyright (C) 2012 EllieWare
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

namespace EllieWare.DateTime
{
  public class Pause : MutableRunnableBase<PauseCtrl>
  {
    public Pause()
    {
    }

    public Pause(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      mControl.mTimeSpan.Value = new System.DateTime(2006, 2, 20, 0, 0, 0);
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Pause for {0}", mControl.mTimeSpan.Value.ToString("HH:mm:ss"));

        return descrip;
      }
    }

    public override bool Run()
    {
      var pause = new TimeSpan(mControl.mTimeSpan.Value.Hour, mControl.mTimeSpan.Value.Minute, mControl.mTimeSpan.Value.Second);

      Utils.Wait(pause);

      return true;
    }

    public override void ReadXml(XmlReader reader)
    {
      var pauseStr = reader.GetAttribute("Pause");
      mControl.mTimeSpan.Value = System.DateTime.Parse(pauseStr, CultureInfo.InvariantCulture);
    }

    public override void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("Pause", mControl.mTimeSpan.Value.ToString(CultureInfo.InvariantCulture));
    }
  }
}
