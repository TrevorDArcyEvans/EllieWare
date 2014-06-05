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
  public partial class YearlyCtrl : CronCtrlBase
  {
    public YearlyCtrl()
    {
      InitializeComponent();

      DayMonth.SelectedIndex = PeriodicInterval.SelectedIndex = PeriodicDay.SelectedIndex = PeriodicMonth.SelectedIndex = 0;
    }

    private void FireExpressionChangedInternal(object sender, EventArgs e)
    {
      FireExpressionChanged(sender, e);
    }

    protected override void UpdateUserInterface()
    {
      DayMonth.Enabled = DayValue.Enabled = OptDay.Checked;
      PeriodicInterval.Enabled = PeriodicDay.Enabled = PeriodicMonth.Enabled = !OptDay.Checked;
    }

    public override string Expression
    {
      get
      {
        if (OptDay.Checked)
        {
          return string.Format("0 {3} {2} {1} {0} ? *", DayMonth.SelectedIndex + 1, DayValue.Value, YearlyTimeValue.Value.Hour, YearlyTimeValue.Value.Minute);
        }

        var perDay = GetDay(PeriodicDay.SelectedIndex);
        return string.Format("0 {4} {3} ? {2} {1}#{0} *", PeriodicInterval.SelectedIndex + 1, perDay, PeriodicMonth.SelectedIndex + 1, YearlyTimeValue.Value.Hour, YearlyTimeValue.Value.Minute);
      }
    }

    #region Implementation of IXmlSerializable

    public override void ReadXml(XmlReader reader)
    {
      var optDayStr = reader.GetAttribute("OptDay");
      Debug.Assert(optDayStr != null, "optDayStr != null");
      OptDay.Checked = bool.Parse(optDayStr);
      OptPeriodic.Checked = !OptDay.Checked;

      var dayValueStr = reader.GetAttribute("DayValue");
      Debug.Assert(dayValueStr != null, "dayValueStr != null");
      DayValue.Value = decimal.Parse(dayValueStr, CultureInfo.InvariantCulture);

      var perInt = reader.GetAttribute("PeriodicInterval");
      PeriodicInterval.SelectedIndex = int.Parse(perInt, CultureInfo.InvariantCulture);

      var perDay = reader.GetAttribute("PeriodicDay");
      PeriodicDay.SelectedIndex = int.Parse(perDay, CultureInfo.InvariantCulture);

      var perMonth = reader.GetAttribute("PeriodicMonth");
      PeriodicMonth.SelectedIndex = int.Parse(perMonth, CultureInfo.InvariantCulture);

      var yearlyTimeValueStr = reader.GetAttribute("YearlyTimeValue");
      YearlyTimeValue.Value = DateTime.ParseExact(yearlyTimeValueStr, "s", CultureInfo.InvariantCulture);
    }

    public override void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("OptDay", OptDay.Checked.ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("DayValue", DayValue.Value.ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("PeriodicInterval", PeriodicInterval.SelectedIndex.ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("PeriodicDay", PeriodicDay.SelectedIndex.ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("PeriodicMonth", PeriodicMonth.SelectedIndex.ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("YearlyTimeValue", YearlyTimeValue.Value.ToString("s", CultureInfo.InvariantCulture));
    }

    #endregion
  }
}
