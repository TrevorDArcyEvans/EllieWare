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
  public partial class DailyCtrl : CronCtrlBase
  {
    public DailyCtrl() :
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
      DailyValue.Enabled = OptDay.Checked;
    }

    public override string Expression
    {
      get
      {
        if (OptDay.Checked)
        {
          return string.Format("0 {2} {1} 1/{0} * ? *", DailyValue.Value, DailyTimeValue.Value.Hour, DailyTimeValue.Value.Minute);
        }

        return string.Format("0 {1} {0} ? * MON-FRI *", DailyTimeValue.Value.Hour, DailyTimeValue.Value.Minute);
      }
    }

    #region Implementation of IXmlSerializable

    public override void ReadXml(XmlReader reader)
    {
      var optDayStr = reader.GetAttribute("OptDay");
      OptDay.Checked = bool.Parse(optDayStr);
      OptWeekDay.Checked = !OptDay.Checked;
      var dailyValueStr = reader.GetAttribute("DailyValue");
      DailyValue.Value = decimal.Parse(dailyValueStr, CultureInfo.InvariantCulture);
      var hourlyTimeValueStr = reader.GetAttribute("DailyTimeValue");
      DailyTimeValue.Value = DateTime.ParseExact(hourlyTimeValueStr, "s", CultureInfo.InvariantCulture);
    }

    public override void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("OptDay", OptDay.Checked.ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("DailyValue", DailyValue.Value.ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("DailyTimeValue", DailyTimeValue.Value.ToString("s", CultureInfo.InvariantCulture));
    }

    #endregion
  }
}
