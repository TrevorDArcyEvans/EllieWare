//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Diagnostics;
using System.Globalization;
using System.Xml;

namespace RobotWare.Cron.UserInterface
{
  public partial class MinutesCtrl : CronCtrlBase
  {
    public MinutesCtrl()
    {
      InitializeComponent();
    }

    private void FireExpressionChangedInternal(object sender, EventArgs e)
    {
      FireExpressionChanged(sender, e);
    }

    public override string Expression
    {
      get
      {
        return string.Format("0 0/{0} * 1/1 * ? *", MinutesValue.Value);
      }
    }

    #region Implementation of IXmlSerializable

    public override void ReadXml(XmlReader reader)
    {
      var valStr = reader.GetAttribute("MinutesValue");
      Debug.Assert(valStr != null, "valStr != null");
      MinutesValue.Value = decimal.Parse(valStr, CultureInfo.InvariantCulture);
    }

    public override void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("MinutesValue", MinutesValue.Value.ToString(CultureInfo.InvariantCulture));
    }

    #endregion
  }
}
