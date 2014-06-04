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
  public partial class MonthlyCtrl : CronCtrlBase
  {
    public MonthlyCtrl()
    {
      InitializeComponent();

      PeriodicInterval.SelectedIndex = PeriodicDay.SelectedIndex = 0;
    }

    private void FireExpressionChangedInternal(object sender, EventArgs e)
    {
      FireExpressionChanged(sender, e);
    }

    protected override void UpdateUserInterface()
    {
      DayValue.Enabled = DayMonth.Enabled = OptDay.Checked;
      PeriodicInterval.Enabled = PeriodicDay.Enabled = PeriodicMonth.Enabled = !OptDay.Checked;
    }

    public override string Expression
    {
      get
      {
        if (OptDay.Checked)
        {
          return string.Format("0 {3} {2} {0} 1/{1} ? *", DayValue.Value, DayMonth.Value, MonthlyTimeValue.Value.Hour, MonthlyTimeValue.Value.Minute);
        }

        var perInt = GetPeriodicInterval();
        var perDay = GetDay(PeriodicDay.SelectedIndex);
        return string.Format("0 {3} {2} ? 1/{4} {1}#{0} *", perInt, perDay, MonthlyTimeValue.Value.Hour, MonthlyTimeValue.Value.Minute, PeriodicMonth.Value);
      }
    }

    #region Implementation of IXmlSerializable

    public override void ReadXml(XmlReader reader)
    {
      var optDayStr = reader.GetAttribute("OptDay");
      OptDay.Checked = bool.Parse(optDayStr);
      OptPeriodic.Checked = !OptDay.Checked;
      var dayValueStr = reader.GetAttribute("DayValue");
      DayValue.Value = decimal.Parse(dayValueStr, CultureInfo.InvariantCulture);
      var dayMonthStr = reader.GetAttribute("DayMonth");
      DayMonth.Value = decimal.Parse(dayMonthStr, CultureInfo.InvariantCulture);
      var perInt = reader.GetAttribute("PeriodicInterval");
      PeriodicInterval.SelectedIndex = int.Parse(perInt, CultureInfo.InvariantCulture);
      var perDay = reader.GetAttribute("PeriodicDay");
      PeriodicDay.SelectedIndex = int.Parse(perDay, CultureInfo.InvariantCulture);
      var perMonth = reader.GetAttribute("PeriodicMonth");
      PeriodicMonth.Value = decimal.Parse(perMonth, CultureInfo.InvariantCulture);
      var monthlyTimeValueStr = reader.GetAttribute("MonthlyTimeValue");
      MonthlyTimeValue.Value = DateTime.ParseExact(monthlyTimeValueStr, "s", CultureInfo.InvariantCulture);
    }

    public override void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("OptDay", OptDay.Checked.ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("DayValue", DayValue.Value.ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("DayMonth", DayMonth.Value.ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("PeriodicInterval", PeriodicInterval.SelectedIndex.ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("PeriodicDay", PeriodicDay.SelectedIndex.ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("PeriodicMonth", PeriodicMonth.Value.ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("MonthlyTimeValue", MonthlyTimeValue.Value.ToString("s", CultureInfo.InvariantCulture));
    }

    #endregion

    private string GetPeriodicInterval()
    {
      return (PeriodicInterval.SelectedIndex + 1).ToString();
    }
  }
}
