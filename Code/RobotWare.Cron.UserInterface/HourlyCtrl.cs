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

namespace RobotWare.Cron.UserInterface
{
  public partial class HourlyCtrl : CronCtrlBase
  {
    public HourlyCtrl() :
      base()
    {
      InitializeComponent();
    }

    private void FireExpressionChangedInternal(object sender, EventArgs e)
    {
      FireExpressionChanged(sender, e);
    }

    protected override void UpdateUserInterface()
    {
      HourlyValue.Enabled = !OptTime.Checked;
      HourlyTimeValue.Enabled = OptTime.Checked;
    }

    public override string Expression
    {
      get
      {
        if (OptHours.Checked)
        {
          return string.Format("0 0 0/{0} 1/1 * ? *", HourlyValue.Value);
        }

        return string.Format("0 {1} {0} 1/1 * ? *", HourlyTimeValue.Value.Hour, HourlyTimeValue.Value.Minute);
      }
    }

    #region Implementation of IXmlSerializable

    public override void ReadXml(XmlReader reader)
    {
      var optHoursStr = reader.GetAttribute("OptHours");
      OptHours.Checked = bool.Parse(optHoursStr);
      OptTime.Checked = !OptHours.Checked;
      var hourlyValueStr = reader.GetAttribute("HourlyValue");
      HourlyValue.Value = decimal.Parse(hourlyValueStr, CultureInfo.InvariantCulture);
      var hourlyTimeValueStr = reader.GetAttribute("HourlyTimeValue");
      HourlyTimeValue.Value = DateTime.ParseExact(hourlyTimeValueStr, "s", CultureInfo.InvariantCulture);
    }

    public override void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("OptHours", OptHours.Checked.ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("HourlyValue", HourlyValue.Value.ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("HourlyTimeValue", HourlyTimeValue.Value.ToString("s", CultureInfo.InvariantCulture));
    }

    #endregion
  }
}
